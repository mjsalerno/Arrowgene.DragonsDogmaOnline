using Arrowgene.Ddon.Database.Model;
using Arrowgene.Ddon.GameServer.Characters;
using Arrowgene.Ddon.GameServer.Handler;
using Arrowgene.Ddon.Shared.Entity.PacketStructure;
using Arrowgene.Ddon.Shared.Model;
using Arrowgene.Ddon.Shared.Network;
using System.Collections.Generic;
using System.Linq;

namespace Arrowgene.Ddon.GameServer.Chat.Command.Commands
{
    public class PartyInviteCommand : ChatCommand
    {
        public override AccountStateType AccountState => AccountStateType.User;

        public override string Key => "invite";
        public override string HelpText => "usage: `/invite [Pawn/Player Name]`";

        private DdonGameServer _server;
        private PartyPartyInviteCharacterHandler _inviteCharacterHandler;
        private PawnJoinPartyMypawnHandler _inviteMypawnHandler;
        private PawnJoinPartyRentedPawnHandler _inviteRentedPawnHandler;

        private HashSet<uint> BannedStageIds = new()
        {
            347
        };

        public PartyInviteCommand(DdonGameServer server)
        {
            _server = server;
            _inviteCharacterHandler = new PartyPartyInviteCharacterHandler(server);
            _inviteMypawnHandler = new PawnJoinPartyMypawnHandler(server);
            _inviteRentedPawnHandler = new PawnJoinPartyRentedPawnHandler(server);
        }

        public override void Execute(string[] command, GameClient client, ChatMessage message, List<ChatResponse> responses)
        {
            if (command.Length == 0)
            {
                // check expected length before accessing
                responses.Add(ChatResponse.CommandError(client, "No arguments provided."));
                return;
            }

            if (client.Party.ContentId != 0)
            {
                responses.Add(ChatResponse.CommandError(client, "Use the recruitment board to invite players to the party."));
                return;
            }

            if (client.GameMode == GameMode.BitterblackMaze && client.Party.Members.Count >= 4)
            {
                responses.Add(ChatResponse.CommandError(client, "This game mode only supports 4 players."));
                return;
            }

            if (!client.Party.GetPlayerPartyMember(client).IsLeader)
            {
                responses.Add(ChatResponse.CommandError(client, "Only the party leader can invite."));
                return;
            }

            if (!StageManager.IsSafeArea(client.Character.Stage))
            {
                responses.Add(ChatResponse.CommandError(client, "You must be in a safe area to invite others."));
                return;
            }

            // TODO: What happens if some smartass decides to place a space in their pawns name?
            if (command.Length == 1)
            {
                var myTuple = client.Character.Pawns
                    .Select((pawn, index) => new { pawn = pawn, pawnNumber = (byte)(index + 1) })
                    .FirstOrDefault(tuple => tuple.pawn.Name == command[0]);
                //var rentedTuple = client.Character.RentedPawns
                //    .Select((pawn, index) => new { pawn = pawn, pawnNumber = (byte)(index + 1) })
                //    .FirstOrDefault(tuple => tuple.pawn.Name == command[0]);

                if (myTuple != null)
                {
                    if (client.Party.Contains(myTuple.pawn))
                    {
                        responses.Add(ChatResponse.CommandError(client, "The party already contains that pawn."));
                        return;
                    }
                    _inviteMypawnHandler.Handle(client, new StructurePacket<C2SPawnJoinPartyMypawnReq>(new C2SPawnJoinPartyMypawnReq()
                    {
                        PawnNumber = myTuple.pawnNumber
                    }));
                }
                //else if (rentedTuple != null)
                //{
                //    if (client.Party.Contains(rentedTuple.pawn))
                //    {
                //        responses.Add(ChatResponse.CommandError(client, "The party already contains that pawn."));
                //        return;
                //    }

                //    _inviteMypawnHandler.Handle(client, new StructurePacket<C2SPawnJoinPartyRentedPawnReq>(new C2SPawnJoinPartyRentedPawnReq()
                //    {
                //        SlotNo = myTuple.pawnNumber
                //    }));
                //}
                else
                {
                    responses.Add(ChatResponse.CommandError(client, "No pawn was found by that name."));
                    return;
                }
            }
            else
            {
                GameClient targetClient = _server.ClientLookup.GetClientByCharacterName(command[0], command[1]);

                if (targetClient == null)
                {
                    responses.Add(ChatResponse.CommandError(client, "No player was found by that name."));
                    return;
                }

                if (targetClient == client)
                {
                    responses.Add(ChatResponse.CommandError(client, "You cannot invite yourself."));
                    return;
                }

                if (targetClient.GameMode != client.GameMode)
                {
                    responses.Add(ChatResponse.CommandError(client, "You cannot invite players which are in different game modes."));
                    return;
                }

                if (BannedStageIds.Contains(client.Character.Stage.Id))
                {
                    responses.Add(ChatResponse.CommandError(client, "You cannot use invite players from this area."));
                    return;
                }

                if (client.Party.Contains(targetClient.Character))
                {
                    responses.Add(ChatResponse.CommandError(client, "The party already contains that player."));
                }

                if (!StageManager.IsSafeArea(targetClient.Character.Stage))
                {
                    responses.Add(ChatResponse.CommandError(client, "The invited player is not in a safe area."));
                    return;
                }

                //TODO: Revisit how to check if a player can actually receive an invite or not.

                _inviteCharacterHandler.Handle(client, new StructurePacket<C2SPartyPartyInviteCharacterReq>(new C2SPartyPartyInviteCharacterReq()
                {
                    CharacterId = targetClient.Character.CharacterId
                }));

                responses.Add(ChatResponse.ServerMessage(client, $"Party invite sent to {targetClient.Character.FirstName} {targetClient.Character.LastName}."));
            }
        }
    }
}

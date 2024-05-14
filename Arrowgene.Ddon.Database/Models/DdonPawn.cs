using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonPawn
{
    public int PawnId { get; set; }

    public int CharacterCommonId { get; set; }

    public int CharacterId { get; set; }

    public string Name { get; set; }

    public short HmType { get; set; }

    public short PawnType { get; set; }

    public virtual DdonCharacter Character { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }

    public virtual ICollection<DdonPawnReaction> DdonPawnReactions { get; set; } = new List<DdonPawnReaction>();

    public virtual DdonSpSkill DdonSpSkill { get; set; }
}

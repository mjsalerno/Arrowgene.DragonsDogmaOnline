using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonCharacterMatchingProfile
{
    public int CharacterId { get; set; }

    public short EntryJob { get; set; }

    public int EntryJobLevel { get; set; }

    public short CurrentJob { get; set; }

    public int CurrentJobLevel { get; set; }

    public int ObjectiveType1 { get; set; }

    public int ObjectiveType2 { get; set; }

    public int PlayStyle { get; set; }

    public string Comment { get; set; }

    public bool IsJoinParty { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

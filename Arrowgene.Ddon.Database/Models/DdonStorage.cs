using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonStorage
{
    public int CharacterId { get; set; }

    public short StorageType { get; set; }

    public short SlotMax { get; set; }

    public byte[] ItemSort { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

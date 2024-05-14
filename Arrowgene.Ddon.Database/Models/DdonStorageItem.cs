using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonStorageItem
{
    public string ItemUid { get; set; }

    public int CharacterId { get; set; }

    public short StorageType { get; set; }

    public short SlotNo { get; set; }

    public int ItemNum { get; set; }

    public virtual DdonCharacter Character { get; set; }

    public virtual DdonItem ItemU { get; set; }
}

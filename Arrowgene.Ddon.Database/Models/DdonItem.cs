using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonItem
{
    public string Uid { get; set; }

    public int ItemId { get; set; }

    public short Unk3 { get; set; }

    public short Color { get; set; }

    public short PlusValue { get; set; }

    public virtual ICollection<DdonEquipItem> DdonEquipItems { get; set; } = new List<DdonEquipItem>();

    public virtual ICollection<DdonEquipJobItem> DdonEquipJobItems { get; set; } = new List<DdonEquipJobItem>();

    public virtual ICollection<DdonStorageItem> DdonStorageItems { get; set; } = new List<DdonStorageItem>();
}

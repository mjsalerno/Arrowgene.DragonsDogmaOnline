using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonEquipJobItem
{
    public string ItemUid { get; set; }

    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public short EquipSlot { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }

    public virtual DdonItem ItemU { get; set; }
}

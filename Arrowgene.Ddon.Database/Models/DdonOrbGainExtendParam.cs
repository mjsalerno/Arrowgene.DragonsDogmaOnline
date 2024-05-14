using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonOrbGainExtendParam
{
    public int CharacterCommonId { get; set; }

    public int HpMax { get; set; }

    public int StaminaMax { get; set; }

    public int PhysicalAttack { get; set; }

    public int PhysicalDefence { get; set; }

    public int MagicAttack { get; set; }

    public int MagicDefence { get; set; }

    public int AbilityCost { get; set; }

    public int JewelrySlot { get; set; }

    public int UseItemSlot { get; set; }

    public int MaterialItemSlot { get; set; }

    public int EquipItemSlot { get; set; }

    public int MainPawnSlot { get; set; }

    public int SupportPawnSlot { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

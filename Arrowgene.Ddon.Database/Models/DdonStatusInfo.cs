using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonStatusInfo
{
    public int CharacterCommonId { get; set; }

    public int Hp { get; set; }

    public int Stamina { get; set; }

    public short RevivePoint { get; set; }

    public int MaxHp { get; set; }

    public int MaxStamina { get; set; }

    public int WhiteHp { get; set; }

    public int GainHp { get; set; }

    public int GainStamina { get; set; }

    public int GainAttack { get; set; }

    public int GainDefense { get; set; }

    public int GainMagicAttack { get; set; }

    public int GainMagicDefense { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

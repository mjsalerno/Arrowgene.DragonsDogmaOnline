using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonCharacterJobDatum
{
    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public int Exp { get; set; }

    public int JobPoint { get; set; }

    public int Lv { get; set; }

    public short Atk { get; set; }

    public short Def { get; set; }

    public short MAtk { get; set; }

    public short MDef { get; set; }

    public short Strength { get; set; }

    public short DownPower { get; set; }

    public short ShakePower { get; set; }

    public short StunPower { get; set; }

    public short Consitution { get; set; }

    public short Guts { get; set; }

    public short FireResist { get; set; }

    public short IceResist { get; set; }

    public short ThunderResist { get; set; }

    public short HolyResist { get; set; }

    public short DarkResist { get; set; }

    public short SpreadResist { get; set; }

    public short FreezeResist { get; set; }

    public short ShockResist { get; set; }

    public short AbsorbResist { get; set; }

    public short DarkElmResist { get; set; }

    public short PoisonResist { get; set; }

    public short SlowResist { get; set; }

    public short SleepResist { get; set; }

    public short StunResist { get; set; }

    public short WetResist { get; set; }

    public short OilResist { get; set; }

    public short SealResist { get; set; }

    public short CurseResist { get; set; }

    public short SoftResist { get; set; }

    public short StoneResist { get; set; }

    public short GoldResist { get; set; }

    public short FireReduceResist { get; set; }

    public short IceReduceResist { get; set; }

    public short ThunderReduceResist { get; set; }

    public short HolyReduceResist { get; set; }

    public short DarkReduceResist { get; set; }

    public short AtkDownResist { get; set; }

    public short DefDownResist { get; set; }

    public short MAtkDownResist { get; set; }

    public short MDefDownResist { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

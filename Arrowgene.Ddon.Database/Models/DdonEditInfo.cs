using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonEditInfo
{
    public int CharacterCommonId { get; set; }

    public short Sex { get; set; }

    public short Voice { get; set; }

    public short VoicePitch { get; set; }

    public short Personality { get; set; }

    public short SpeechFreq { get; set; }

    public short BodyType { get; set; }

    public short Hair { get; set; }

    public short Beard { get; set; }

    public short Makeup { get; set; }

    public short Scar { get; set; }

    public short EyePresetNo { get; set; }

    public short NosePresetNo { get; set; }

    public short MouthPresetNo { get; set; }

    public short EyebrowTexNo { get; set; }

    public short ColorSkin { get; set; }

    public short ColorHair { get; set; }

    public short ColorBeard { get; set; }

    public short ColorEyebrow { get; set; }

    public short ColorREye { get; set; }

    public short ColorLEye { get; set; }

    public short ColorMakeup { get; set; }

    public short Sokutobu { get; set; }

    public short Hitai { get; set; }

    public short MimiJyouge { get; set; }

    public short Kannkaku { get; set; }

    public short MabisasiJyouge { get; set; }

    public short HanakuchiJyouge { get; set; }

    public short AgoSakiHaba { get; set; }

    public short AgoZengo { get; set; }

    public short AgoSakiJyouge { get; set; }

    public short HitomiOokisa { get; set; }

    public short MeOokisa { get; set; }

    public short MeKaiten { get; set; }

    public short MayuKaiten { get; set; }

    public short MimiOokisa { get; set; }

    public short MimiMuki { get; set; }

    public short ElfMimi { get; set; }

    public short MikenTakasa { get; set; }

    public short MikenHaba { get; set; }

    public short HohoboneRyou { get; set; }

    public short HohoboneJyouge { get; set; }

    public short Hohoniku { get; set; }

    public short ErahoneJyouge { get; set; }

    public short ErahoneHaba { get; set; }

    public short HanaJyouge { get; set; }

    public short HanaHaba { get; set; }

    public short HanaTakasa { get; set; }

    public short HanaKakudo { get; set; }

    public short KuchiHaba { get; set; }

    public short KuchiAtsusa { get; set; }

    public short EyebrowUvOffsetX { get; set; }

    public short EyebrowUvOffsetY { get; set; }

    public short Wrinkle { get; set; }

    public short WrinkleAlbedoBlendRate { get; set; }

    public short WrinkleDetailNormalPower { get; set; }

    public short MuscleAlbedoBlendRate { get; set; }

    public short MuscleDetailNormalPower { get; set; }

    public short Height { get; set; }

    public short HeadSize { get; set; }

    public short NeckOffset { get; set; }

    public short NeckScale { get; set; }

    public short UpperBodyScaleX { get; set; }

    public short BellySize { get; set; }

    public short TeatScale { get; set; }

    public short TekubiSize { get; set; }

    public short KoshiOffset { get; set; }

    public short KoshiSize { get; set; }

    public short AnkleOffset { get; set; }

    public short Fat { get; set; }

    public short Muscle { get; set; }

    public short MotionFilter { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonCharacterCommon
{
    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public bool HideEquipHead { get; set; }

    public bool HideEquipLantern { get; set; }

    public virtual ICollection<DdonCharacterJobDatum> DdonCharacterJobData { get; set; } = new List<DdonCharacterJobDatum>();

    public virtual ICollection<DdonCharacter> DdonCharacters { get; set; } = new List<DdonCharacter>();

    public virtual ICollection<DdonDragonForceAugmentation> DdonDragonForceAugmentations { get; set; } = new List<DdonDragonForceAugmentation>();

    public virtual DdonEditInfo DdonEditInfo { get; set; }

    public virtual ICollection<DdonEquipItem> DdonEquipItems { get; set; } = new List<DdonEquipItem>();

    public virtual ICollection<DdonEquipJobItem> DdonEquipJobItems { get; set; } = new List<DdonEquipJobItem>();

    public virtual ICollection<DdonLearnedAbility> DdonLearnedAbilities { get; set; } = new List<DdonLearnedAbility>();

    public virtual ICollection<DdonLearnedCustomSkill> DdonLearnedCustomSkills { get; set; } = new List<DdonLearnedCustomSkill>();

    public virtual ICollection<DdonNormalSkillParam> DdonNormalSkillParams { get; set; } = new List<DdonNormalSkillParam>();

    public virtual DdonOrbGainExtendParam DdonOrbGainExtendParam { get; set; }

    public virtual ICollection<DdonPawn> DdonPawns { get; set; } = new List<DdonPawn>();

    public virtual DdonStatusInfo DdonStatusInfo { get; set; }

    public virtual ICollection<DdonUnlockedSecretAbility> DdonUnlockedSecretAbilities { get; set; } = new List<DdonUnlockedSecretAbility>();
}

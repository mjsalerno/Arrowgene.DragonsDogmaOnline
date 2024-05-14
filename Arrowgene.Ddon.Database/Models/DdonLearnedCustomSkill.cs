using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonLearnedCustomSkill
{
    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public int SkillId { get; set; }

    public short SkillLv { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }

    public virtual ICollection<DdonEquippedCustomSkill> DdonEquippedCustomSkills { get; set; } = new List<DdonEquippedCustomSkill>();
}

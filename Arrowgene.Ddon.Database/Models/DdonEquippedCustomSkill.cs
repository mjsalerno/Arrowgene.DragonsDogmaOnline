using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonEquippedCustomSkill
{
    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public short SlotNo { get; set; }

    public int SkillId { get; set; }

    public virtual DdonLearnedCustomSkill DdonLearnedCustomSkill { get; set; }
}

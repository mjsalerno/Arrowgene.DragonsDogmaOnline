using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonNormalSkillParam
{
    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public int SkillNo { get; set; }

    public int Index { get; set; }

    public int PreSkillNo { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

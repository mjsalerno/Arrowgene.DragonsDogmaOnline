using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonSpSkill
{
    public int PawnId { get; set; }

    public short SpSkillId { get; set; }

    public short SpSkillLv { get; set; }

    public virtual DdonPawn Pawn { get; set; }
}

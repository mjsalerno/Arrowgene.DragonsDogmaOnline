using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonPawnReaction
{
    public int PawnId { get; set; }

    public short ReactionType { get; set; }

    public int MotionNo { get; set; }

    public virtual DdonPawn Pawn { get; set; }
}

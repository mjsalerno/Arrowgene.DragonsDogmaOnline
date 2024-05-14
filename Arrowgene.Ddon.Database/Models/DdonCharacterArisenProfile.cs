using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonCharacterArisenProfile
{
    public int CharacterId { get; set; }

    public short BackgroundId { get; set; }

    public int TitleUid { get; set; }

    public int TitleIndex { get; set; }

    public short MotionId { get; set; }

    public int MotionFrameNo { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

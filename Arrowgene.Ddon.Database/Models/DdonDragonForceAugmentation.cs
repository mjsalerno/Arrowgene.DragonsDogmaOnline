using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonDragonForceAugmentation
{
    public int CharacterCommonId { get; set; }

    public int ElementId { get; set; }

    public int PageNo { get; set; }

    public int GroupNo { get; set; }

    public int IndexNo { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

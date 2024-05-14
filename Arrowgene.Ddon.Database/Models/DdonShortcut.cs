using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonShortcut
{
    public int CharacterId { get; set; }

    public int PageNo { get; set; }

    public int ButtonNo { get; set; }

    public int ShortcutId { get; set; }

    public int U32Data { get; set; }

    public int F32Data { get; set; }

    public short ExexType { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

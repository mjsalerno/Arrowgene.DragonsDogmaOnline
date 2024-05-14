using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonCommunicationShortcut
{
    public int CharacterId { get; set; }

    public int PageNo { get; set; }

    public int ButtonNo { get; set; }

    public short Type { get; set; }

    public short Category { get; set; }

    public int Id { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

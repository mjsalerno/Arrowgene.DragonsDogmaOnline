using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonWalletPoint
{
    public int CharacterId { get; set; }

    public short Type { get; set; }

    public int Value { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

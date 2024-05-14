using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonConnection
{
    public int ServerId { get; set; }

    public int AccountId { get; set; }

    public int Type { get; set; }

    public DateTime Created { get; set; }

    public virtual Account Account { get; set; }
}

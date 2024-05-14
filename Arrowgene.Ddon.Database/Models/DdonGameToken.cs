using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonGameToken
{
    public int AccountId { get; set; }

    public int CharacterId { get; set; }

    public string Token { get; set; }

    public DateTime Created { get; set; }

    public virtual Account Account { get; set; }

    public virtual DdonCharacter Character { get; set; }
}

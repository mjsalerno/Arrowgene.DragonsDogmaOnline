using System;
using System.Collections.Generic;
using Arrowgene.Ddon.Shared.Model;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonContactList
{
    public int Id { get; set; }

    public int RequesterCharacterId { get; set; }

    public int RequestedCharacterId { get; set; }

    public ContactListStatus Status { get; set; }

    public ContactListType Type { get; set; }

    public bool RequesterFavorite { get; set; }

    public bool RequestedFavorite { get; set; }

    public virtual DdonCharacter RequestedCharacter { get; set; }

    public virtual DdonCharacter RequesterCharacter { get; set; }
}

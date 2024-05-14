using System;
using System.Collections.Generic;
using Arrowgene.Ddon.Database.Model;

namespace Arrowgene.Ddon.Database.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string NormalName { get; set; }

    public string Hash { get; set; }

    public string Mail { get; set; }

    public bool MailVerified { get; set; }

    public DateTime? MailVerifiedAt { get; set; }

    public string MailToken { get; set; }

    public string PasswordToken { get; set; }

    public string LoginToken { get; set; }

    public DateTime? LoginTokenCreated { get; set; }

    public AccountStateType State { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime Created { get; set; }

    public virtual ICollection<DdonCharacter> DdonCharacters { get; set; } = new List<DdonCharacter>();

    public virtual DdonGameToken DdonGameToken { get; set; }
}

using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonLearnedAbility
{
    public int CharacterCommonId { get; set; }

    public short Job { get; set; }

    public int AbilityId { get; set; }

    public short AbilityLv { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }

    public virtual ICollection<DdonEquippedAbility> DdonEquippedAbilities { get; set; } = new List<DdonEquippedAbility>();
}

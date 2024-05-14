using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonEquippedAbility
{
    public int CharacterCommonId { get; set; }

    public short EquippedToJob { get; set; }

    public short Job { get; set; }

    public short SlotNo { get; set; }

    public int AbilityId { get; set; }

    public virtual DdonLearnedAbility DdonLearnedAbility { get; set; }
}

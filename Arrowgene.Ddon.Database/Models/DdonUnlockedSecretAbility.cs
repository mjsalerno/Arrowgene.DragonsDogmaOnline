using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonUnlockedSecretAbility
{
    public int CharacterCommonId { get; set; }

    public int AbilityId { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }
}

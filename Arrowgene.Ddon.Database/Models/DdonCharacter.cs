using System;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Database.Models;

public partial class DdonCharacter
{
    public int CharacterId { get; set; }

    public int CharacterCommonId { get; set; }

    public int AccountId { get; set; }

    public int Version { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Created { get; set; }

    public short MyPawnSlotNum { get; set; }

    public short RentalPawnSlotNum { get; set; }

    public bool HideEquipHeadPawn { get; set; }

    public bool HideEquipLanternPawn { get; set; }

    public short ArisenProfileShareRange { get; set; }
    
    public int FavWarpSlotNum { get; set; }

    public virtual Account Account { get; set; }

    public virtual DdonCharacterCommon CharacterCommon { get; set; }

    public virtual DdonCharacterArisenProfile DdonCharacterArisenProfile { get; set; }

    public virtual DdonCharacterMatchingProfile DdonCharacterMatchingProfile { get; set; }

    public virtual ICollection<DdonCommunicationShortcut> DdonCommunicationShortcuts { get; set; } = new List<DdonCommunicationShortcut>();

    public virtual ICollection<DdonContactList> DdonContactListRequestedCharacters { get; set; } = new List<DdonContactList>();

    public virtual ICollection<DdonContactList> DdonContactListRequesterCharacters { get; set; } = new List<DdonContactList>();

    public virtual ICollection<DdonGameToken> DdonGameTokens { get; set; } = new List<DdonGameToken>();

    public virtual ICollection<DdonPawn> DdonPawns { get; set; } = new List<DdonPawn>();

    public virtual ICollection<DdonShortcut> DdonShortcuts { get; set; } = new List<DdonShortcut>();

    public virtual ICollection<DdonStorageItem> DdonStorageItems { get; set; } = new List<DdonStorageItem>();

    public virtual ICollection<DdonStorage> DdonStorages { get; set; } = new List<DdonStorage>();

    public virtual ICollection<DdonWalletPoint> DdonWalletPoints { get; set; } = new List<DdonWalletPoint>();
}

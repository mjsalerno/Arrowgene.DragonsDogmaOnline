using System;
using System.Collections.Generic;
using System.IO;
using Arrowgene.Ddon.Database.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Arrowgene.Ddon.Database.Context;

public partial class DdonDbContext : DbContext
{
    private DatabaseSetting _settings { get; set; }


    public DdonDbContext()
    {
    }
    public DdonDbContext(DatabaseSetting settings)
    {
        _settings = settings;
    }
    
    public DdonDbContext(DbContextOptions<DdonDbContext> options)
        : base(options)
    {
    }

    public DdonDbContext(DbContextOptions<DdonDbContext> options, DatabaseSetting settings)
        : base(options)
    {
        _settings = settings;
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<DdonCharacter> DdonCharacters { get; set; }

    public virtual DbSet<DdonCharacterArisenProfile> DdonCharacterArisenProfiles { get; set; }

    public virtual DbSet<DdonCharacterCommon> DdonCharacterCommons { get; set; }

    public virtual DbSet<DdonCharacterJobDatum> DdonCharacterJobData { get; set; }

    public virtual DbSet<DdonCharacterMatchingProfile> DdonCharacterMatchingProfiles { get; set; }

    public virtual DbSet<DdonCommunicationShortcut> DdonCommunicationShortcuts { get; set; }

    public virtual DbSet<DdonConnection> DdonConnections { get; set; }

    public virtual DbSet<DdonContactList> DdonContactLists { get; set; }

    public virtual DbSet<DdonDragonForceAugmentation> DdonDragonForceAugmentations { get; set; }

    public virtual DbSet<DdonEditInfo> DdonEditInfos { get; set; }

    public virtual DbSet<DdonEquipItem> DdonEquipItems { get; set; }

    public virtual DbSet<DdonEquipJobItem> DdonEquipJobItems { get; set; }

    public virtual DbSet<DdonEquippedAbility> DdonEquippedAbilities { get; set; }

    public virtual DbSet<DdonEquippedCustomSkill> DdonEquippedCustomSkills { get; set; }

    public virtual DbSet<DdonGameToken> DdonGameTokens { get; set; }

    public virtual DbSet<DdonItem> DdonItems { get; set; }

    public virtual DbSet<DdonLearnedAbility> DdonLearnedAbilities { get; set; }

    public virtual DbSet<DdonLearnedCustomSkill> DdonLearnedCustomSkills { get; set; }

    public virtual DbSet<DdonNormalSkillParam> DdonNormalSkillParams { get; set; }

    public virtual DbSet<DdonOrbGainExtendParam> DdonOrbGainExtendParams { get; set; }

    public virtual DbSet<DdonPawn> DdonPawns { get; set; }

    public virtual DbSet<DdonPawnReaction> DdonPawnReactions { get; set; }

    public virtual DbSet<DdonShortcut> DdonShortcuts { get; set; }

    public virtual DbSet<DdonSpSkill> DdonSpSkills { get; set; }

    public virtual DbSet<DdonStatusInfo> DdonStatusInfos { get; set; }

    public virtual DbSet<DdonStorage> DdonStorages { get; set; }

    public virtual DbSet<DdonStorageItem> DdonStorageItems { get; set; }

    public virtual DbSet<DdonUnlockedSecretAbility> DdonUnlockedSecretAbilities { get; set; }

    public virtual DbSet<DdonWalletPoint> DdonWalletPoints { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO use settings instead of hard coded
        // TODO support other DB types

        if (_settings == null)
        {
            optionsBuilder.UseSqlite("DataSource=migrations.db.v1.sqlite");
            return;
        }
        
        var builder = new SqliteConnectionStringBuilder();               
        builder.DataSource = Path.GetFullPath(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,_settings.DatabaseFolder, "db.v1.sqlite"));
        var connectionString = builder.ToString();
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_pkey");

            entity.ToTable("account");

            entity.HasIndex(e => e.LoginToken, "uq_account_login_token").IsUnique();

            entity.HasIndex(e => e.Mail, "uq_account_mail").IsUnique();

            entity.HasIndex(e => e.Name, "uq_account_name").IsUnique();

            entity.HasIndex(e => e.NormalName, "uq_account_normal_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Hash)
                .IsRequired()
                .HasColumnName("hash");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LoginToken).HasColumnName("login_token");
            entity.Property(e => e.LoginTokenCreated).HasColumnName("login_token_created");
            entity.Property(e => e.Mail)
                .IsRequired()
                .HasColumnName("mail");
            entity.Property(e => e.MailToken).HasColumnName("mail_token");
            entity.Property(e => e.MailVerified).HasColumnName("mail_verified");
            entity.Property(e => e.MailVerifiedAt).HasColumnName("mail_verified_at");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
            entity.Property(e => e.NormalName)
                .IsRequired()
                .HasColumnName("normal_name");
            entity.Property(e => e.PasswordToken).HasColumnName("password_token");
            entity.Property(e => e.State).HasColumnName("state");
        });

        modelBuilder.Entity<DdonCharacter>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("ddon_character_pkey");

            entity.ToTable("ddon_character");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ArisenProfileShareRange).HasColumnName("arisen_profile_share_range");
            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name");
            entity.Property(e => e.HideEquipHeadPawn).HasColumnName("hide_equip_head_pawn");
            entity.Property(e => e.HideEquipLanternPawn).HasColumnName("hide_equip_lantern_pawn");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("last_name");
            entity.Property(e => e.MyPawnSlotNum).HasColumnName("my_pawn_slot_num");
            entity.Property(e => e.RentalPawnSlotNum).HasColumnName("rental_pawn_slot_num");
            entity.Property(e => e.Version).HasColumnName("version");
            entity.Property(e => e.FavWarpSlotNum)
                .IsRequired()
                .HasColumnName("fav_warp_slot_num");

            entity.HasOne(d => d.Account).WithMany(p => p.DdonCharacters)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_character_account_id");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonCharacters)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_character_character_common_id");
        });

        modelBuilder.Entity<DdonCharacterArisenProfile>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("ddon_character_arisen_profile_pkey");

            entity.ToTable("ddon_character_arisen_profile");

            entity.Property(e => e.CharacterId)
                .ValueGeneratedNever()
                .HasColumnName("character_id");
            entity.Property(e => e.BackgroundId).HasColumnName("background_id");
            entity.Property(e => e.MotionFrameNo).HasColumnName("motion_frame_no");
            entity.Property(e => e.MotionId).HasColumnName("motion_id");
            entity.Property(e => e.TitleIndex).HasColumnName("title_index");
            entity.Property(e => e.TitleUid).HasColumnName("title_uid");

            entity.HasOne(d => d.Character).WithOne(p => p.DdonCharacterArisenProfile)
                .HasForeignKey<DdonCharacterArisenProfile>(d => d.CharacterId)
                .HasConstraintName("fk_arisen_profile_character_id");
        });

        modelBuilder.Entity<DdonCharacterCommon>(entity =>
        {
            entity.HasKey(e => e.CharacterCommonId).HasName("ddon_character_common_pkey");

            entity.ToTable("ddon_character_common");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.HideEquipHead).HasColumnName("hide_equip_head");
            entity.Property(e => e.HideEquipLantern).HasColumnName("hide_equip_lantern");
            entity.Property(e => e.Job).HasColumnName("job");
        });

        modelBuilder.Entity<DdonCharacterJobDatum>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job }).HasName("pk_character_job_data");

            entity.ToTable("ddon_character_job_data");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.AbsorbResist).HasColumnName("absorb_resist");
            entity.Property(e => e.Atk).HasColumnName("atk");
            entity.Property(e => e.AtkDownResist).HasColumnName("atk_down_resist");
            entity.Property(e => e.Consitution).HasColumnName("consitution");
            entity.Property(e => e.CurseResist).HasColumnName("curse_resist");
            entity.Property(e => e.DarkElmResist).HasColumnName("dark_elm_resist");
            entity.Property(e => e.DarkReduceResist).HasColumnName("dark_reduce_resist");
            entity.Property(e => e.DarkResist).HasColumnName("dark_resist");
            entity.Property(e => e.Def).HasColumnName("def");
            entity.Property(e => e.DefDownResist).HasColumnName("def_down_resist");
            entity.Property(e => e.DownPower).HasColumnName("down_power");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.FireReduceResist).HasColumnName("fire_reduce_resist");
            entity.Property(e => e.FireResist).HasColumnName("fire_resist");
            entity.Property(e => e.FreezeResist).HasColumnName("freeze_resist");
            entity.Property(e => e.GoldResist).HasColumnName("gold_resist");
            entity.Property(e => e.Guts).HasColumnName("guts");
            entity.Property(e => e.HolyReduceResist).HasColumnName("holy_reduce_resist");
            entity.Property(e => e.HolyResist).HasColumnName("holy_resist");
            entity.Property(e => e.IceReduceResist).HasColumnName("ice_reduce_resist");
            entity.Property(e => e.IceResist).HasColumnName("ice_resist");
            entity.Property(e => e.JobPoint).HasColumnName("job_point");
            entity.Property(e => e.Lv).HasColumnName("lv");
            entity.Property(e => e.MAtk).HasColumnName("m_atk");
            entity.Property(e => e.MAtkDownResist).HasColumnName("m_atk_down_resist");
            entity.Property(e => e.MDef).HasColumnName("m_def");
            entity.Property(e => e.MDefDownResist).HasColumnName("m_def_down_resist");
            entity.Property(e => e.OilResist).HasColumnName("oil_resist");
            entity.Property(e => e.PoisonResist).HasColumnName("poison_resist");
            entity.Property(e => e.SealResist).HasColumnName("seal_resist");
            entity.Property(e => e.ShakePower).HasColumnName("shake_power");
            entity.Property(e => e.ShockResist).HasColumnName("shock_resist");
            entity.Property(e => e.SleepResist).HasColumnName("sleep_resist");
            entity.Property(e => e.SlowResist).HasColumnName("slow_resist");
            entity.Property(e => e.SoftResist).HasColumnName("soft_resist");
            entity.Property(e => e.SpreadResist).HasColumnName("spread_resist");
            entity.Property(e => e.StoneResist).HasColumnName("stone_resist");
            entity.Property(e => e.Strength).HasColumnName("strength");
            entity.Property(e => e.StunPower).HasColumnName("stun_power");
            entity.Property(e => e.StunResist).HasColumnName("stun_resist");
            entity.Property(e => e.ThunderReduceResist).HasColumnName("thunder_reduce_resist");
            entity.Property(e => e.ThunderResist).HasColumnName("thunder_resist");
            entity.Property(e => e.WetResist).HasColumnName("wet_resist");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonCharacterJobData)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_character_job_data_character_common_id");
        });

        modelBuilder.Entity<DdonCharacterMatchingProfile>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("ddon_character_matching_profile_pkey");

            entity.ToTable("ddon_character_matching_profile");

            entity.Property(e => e.CharacterId)
                .ValueGeneratedNever()
                .HasColumnName("character_id");
            entity.Property(e => e.Comment)
                .IsRequired()
                .HasColumnName("comment");
            entity.Property(e => e.CurrentJob).HasColumnName("current_job");
            entity.Property(e => e.CurrentJobLevel).HasColumnName("current_job_level");
            entity.Property(e => e.EntryJob).HasColumnName("entry_job");
            entity.Property(e => e.EntryJobLevel).HasColumnName("entry_job_level");
            entity.Property(e => e.IsJoinParty).HasColumnName("is_join_party");
            entity.Property(e => e.ObjectiveType1).HasColumnName("objective_type1");
            entity.Property(e => e.ObjectiveType2).HasColumnName("objective_type2");
            entity.Property(e => e.PlayStyle).HasColumnName("play_style");

            entity.HasOne(d => d.Character).WithOne(p => p.DdonCharacterMatchingProfile)
                .HasForeignKey<DdonCharacterMatchingProfile>(d => d.CharacterId)
                .HasConstraintName("fk_matching_profile_character_id");
        });

        modelBuilder.Entity<DdonCommunicationShortcut>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.PageNo, e.ButtonNo }).HasName("pk_ddon_communication_shortcut");

            entity.ToTable("ddon_communication_shortcut");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.PageNo).HasColumnName("page_no");
            entity.Property(e => e.ButtonNo).HasColumnName("button_no");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonCommunicationShortcuts)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("fk_communication_shortcut_character_id");
        });

        modelBuilder.Entity<DdonConnection>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ddon_connection");

            entity.HasIndex(e => new { e.ServerId, e.AccountId }, "uq_connection_server_id_account_id").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.ServerId).HasColumnName("server_id");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_connection_token_account_id");
        });

        modelBuilder.Entity<DdonContactList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ddon_contact_list_pkey");

            entity.ToTable("ddon_contact_list");

            entity.HasIndex(e => new { e.RequesterCharacterId, e.RequestedCharacterId }, "ddon_contact_list_requester_character_id_requested_characte_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RequestedCharacterId).HasColumnName("requested_character_id");
            entity.Property(e => e.RequestedFavorite).HasColumnName("requested_favorite");
            entity.Property(e => e.RequesterCharacterId).HasColumnName("requester_character_id");
            entity.Property(e => e.RequesterFavorite).HasColumnName("requester_favorite");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.RequestedCharacter).WithMany(p => p.DdonContactListRequestedCharacters)
                .HasForeignKey(d => d.RequestedCharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ddon_contact_list_requested_character_id_fkey");

            entity.HasOne(d => d.RequesterCharacter).WithMany(p => p.DdonContactListRequesterCharacters)
                .HasForeignKey(d => d.RequesterCharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ddon_contact_list_requester_character_id_fkey");
        });

        modelBuilder.Entity<DdonDragonForceAugmentation>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.ElementId }).HasName("pk_ddon_dragon_force_augmentation");

            entity.ToTable("ddon_dragon_force_augmentation");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.ElementId).HasColumnName("element_id");
            entity.Property(e => e.GroupNo).HasColumnName("group_no");
            entity.Property(e => e.IndexNo).HasColumnName("index_no");
            entity.Property(e => e.PageNo).HasColumnName("page_no");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonDragonForceAugmentations)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_character_dragon_force_augmentation_character_common_id");
        });

        modelBuilder.Entity<DdonEditInfo>(entity =>
        {
            entity.HasKey(e => e.CharacterCommonId).HasName("ddon_edit_info_pkey");

            entity.ToTable("ddon_edit_info");

            entity.Property(e => e.CharacterCommonId)
                .ValueGeneratedNever()
                .HasColumnName("character_common_id");
            entity.Property(e => e.AgoSakiHaba).HasColumnName("ago_saki_haba");
            entity.Property(e => e.AgoSakiJyouge).HasColumnName("ago_saki_jyouge");
            entity.Property(e => e.AgoZengo).HasColumnName("ago_zengo");
            entity.Property(e => e.AnkleOffset).HasColumnName("ankle_offset");
            entity.Property(e => e.Beard).HasColumnName("beard");
            entity.Property(e => e.BellySize).HasColumnName("belly_size");
            entity.Property(e => e.BodyType).HasColumnName("body_type");
            entity.Property(e => e.ColorBeard).HasColumnName("color_beard");
            entity.Property(e => e.ColorEyebrow).HasColumnName("color_eyebrow");
            entity.Property(e => e.ColorHair).HasColumnName("color_hair");
            entity.Property(e => e.ColorLEye).HasColumnName("color_l_eye");
            entity.Property(e => e.ColorMakeup).HasColumnName("color_makeup");
            entity.Property(e => e.ColorREye).HasColumnName("color_r_eye");
            entity.Property(e => e.ColorSkin).HasColumnName("color_skin");
            entity.Property(e => e.ElfMimi).HasColumnName("elf_mimi");
            entity.Property(e => e.ErahoneHaba).HasColumnName("erahone_haba");
            entity.Property(e => e.ErahoneJyouge).HasColumnName("erahone_jyouge");
            entity.Property(e => e.EyePresetNo).HasColumnName("eye_preset_no");
            entity.Property(e => e.EyebrowTexNo).HasColumnName("eyebrow_tex_no");
            entity.Property(e => e.EyebrowUvOffsetX).HasColumnName("eyebrow_uv_offset_x");
            entity.Property(e => e.EyebrowUvOffsetY).HasColumnName("eyebrow_uv_offset_y");
            entity.Property(e => e.Fat).HasColumnName("fat");
            entity.Property(e => e.Hair).HasColumnName("hair");
            entity.Property(e => e.HanaHaba).HasColumnName("hana_haba");
            entity.Property(e => e.HanaJyouge).HasColumnName("hana_jyouge");
            entity.Property(e => e.HanaKakudo).HasColumnName("hana_kakudo");
            entity.Property(e => e.HanaTakasa).HasColumnName("hana_takasa");
            entity.Property(e => e.HanakuchiJyouge).HasColumnName("hanakuchi_jyouge");
            entity.Property(e => e.HeadSize).HasColumnName("head_size");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Hitai).HasColumnName("hitai");
            entity.Property(e => e.HitomiOokisa).HasColumnName("hitomi_ookisa");
            entity.Property(e => e.HohoboneJyouge).HasColumnName("hohobone_jyouge");
            entity.Property(e => e.HohoboneRyou).HasColumnName("hohobone_ryou");
            entity.Property(e => e.Hohoniku).HasColumnName("hohoniku");
            entity.Property(e => e.Kannkaku).HasColumnName("kannkaku");
            entity.Property(e => e.KoshiOffset).HasColumnName("koshi_offset");
            entity.Property(e => e.KoshiSize).HasColumnName("koshi_size");
            entity.Property(e => e.KuchiAtsusa).HasColumnName("kuchi_atsusa");
            entity.Property(e => e.KuchiHaba).HasColumnName("kuchi_haba");
            entity.Property(e => e.MabisasiJyouge).HasColumnName("mabisasi_jyouge");
            entity.Property(e => e.Makeup).HasColumnName("makeup");
            entity.Property(e => e.MayuKaiten).HasColumnName("mayu_kaiten");
            entity.Property(e => e.MeKaiten).HasColumnName("me_kaiten");
            entity.Property(e => e.MeOokisa).HasColumnName("me_ookisa");
            entity.Property(e => e.MikenHaba).HasColumnName("miken_haba");
            entity.Property(e => e.MikenTakasa).HasColumnName("miken_takasa");
            entity.Property(e => e.MimiJyouge).HasColumnName("mimi_jyouge");
            entity.Property(e => e.MimiMuki).HasColumnName("mimi_muki");
            entity.Property(e => e.MimiOokisa).HasColumnName("mimi_ookisa");
            entity.Property(e => e.MotionFilter).HasColumnName("motion_filter");
            entity.Property(e => e.MouthPresetNo).HasColumnName("mouth_preset_no");
            entity.Property(e => e.Muscle).HasColumnName("muscle");
            entity.Property(e => e.MuscleAlbedoBlendRate).HasColumnName("muscle_albedo_blend_rate");
            entity.Property(e => e.MuscleDetailNormalPower).HasColumnName("muscle_detail_normal_power");
            entity.Property(e => e.NeckOffset).HasColumnName("neck_offset");
            entity.Property(e => e.NeckScale).HasColumnName("neck_scale");
            entity.Property(e => e.NosePresetNo).HasColumnName("nose_preset_no");
            entity.Property(e => e.Personality).HasColumnName("personality");
            entity.Property(e => e.Scar).HasColumnName("scar");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Sokutobu).HasColumnName("sokutobu");
            entity.Property(e => e.SpeechFreq).HasColumnName("speech_freq");
            entity.Property(e => e.TeatScale).HasColumnName("teat_scale");
            entity.Property(e => e.TekubiSize).HasColumnName("tekubi_size");
            entity.Property(e => e.UpperBodyScaleX).HasColumnName("upper_body_scale_x");
            entity.Property(e => e.Voice).HasColumnName("voice");
            entity.Property(e => e.VoicePitch).HasColumnName("voice_pitch");
            entity.Property(e => e.Wrinkle).HasColumnName("wrinkle");
            entity.Property(e => e.WrinkleAlbedoBlendRate).HasColumnName("wrinkle_albedo_blend_rate");
            entity.Property(e => e.WrinkleDetailNormalPower).HasColumnName("wrinkle_detail_normal_power");

            entity.HasOne(d => d.CharacterCommon).WithOne(p => p.DdonEditInfo)
                .HasForeignKey<DdonEditInfo>(d => d.CharacterCommonId)
                .HasConstraintName("fk_edit_info_character_common_id");
        });

        modelBuilder.Entity<DdonEquipItem>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job, e.EquipType, e.EquipSlot }).HasName("pk_ddon_equip_item");

            entity.ToTable("ddon_equip_item");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.EquipType).HasColumnName("equip_type");
            entity.Property(e => e.EquipSlot).HasColumnName("equip_slot");
            entity.Property(e => e.ItemUid)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("item_uid");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonEquipItems)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_equip_item_character_common_id");

            entity.HasOne(d => d.ItemU).WithMany(p => p.DdonEquipItems)
                .HasForeignKey(d => d.ItemUid)
                .HasConstraintName("fk_equip_item_item_uid");
        });

        modelBuilder.Entity<DdonEquipJobItem>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job, e.EquipSlot }).HasName("pk_ddon_equip_job_item");

            entity.ToTable("ddon_equip_job_item");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.EquipSlot).HasColumnName("equip_slot");
            entity.Property(e => e.ItemUid)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("item_uid");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonEquipJobItems)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_equip_job_item_character_common_id");

            entity.HasOne(d => d.ItemU).WithMany(p => p.DdonEquipJobItems)
                .HasForeignKey(d => d.ItemUid)
                .HasConstraintName("fk_equip_job_item_item_uid");
        });

        modelBuilder.Entity<DdonEquippedAbility>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.EquippedToJob, e.SlotNo }).HasName("pk_ddon_equipped_ability");

            entity.ToTable("ddon_equipped_ability");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.EquippedToJob).HasColumnName("equipped_to_job");
            entity.Property(e => e.SlotNo).HasColumnName("slot_no");
            entity.Property(e => e.AbilityId).HasColumnName("ability_id");
            entity.Property(e => e.Job).HasColumnName("job");

            entity.HasOne(d => d.DdonLearnedAbility).WithMany(p => p.DdonEquippedAbilities)
                .HasForeignKey(d => new { d.CharacterCommonId, d.Job, d.AbilityId })
                .HasConstraintName("fk_equipped_ability_character_common_id");
        });

        modelBuilder.Entity<DdonEquippedCustomSkill>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job, e.SlotNo }).HasName("pk_ddon_equipped_custom_skill");

            entity.ToTable("ddon_equipped_custom_skill");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.SlotNo).HasColumnName("slot_no");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.DdonLearnedCustomSkill).WithMany(p => p.DdonEquippedCustomSkills)
                .HasForeignKey(d => new { d.CharacterCommonId, d.Job, d.SkillId })
                .HasConstraintName("fk_equipped_custom_skill_character_common_id");
        });

        modelBuilder.Entity<DdonGameToken>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("ddon_game_token_pkey");

            entity.ToTable("ddon_game_token");

            entity.HasIndex(e => e.Token, "uq_game_token_token").IsUnique();

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("account_id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("token");

            entity.HasOne(d => d.Account).WithOne(p => p.DdonGameToken)
                .HasForeignKey<DdonGameToken>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_game_token_account_id");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonGameTokens)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_game_token_character_id");
        });

        modelBuilder.Entity<DdonItem>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("ddon_item_pkey");

            entity.ToTable("ddon_item");

            entity.Property(e => e.Uid)
                .HasMaxLength(8)
                .HasColumnName("uid");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.PlusValue).HasColumnName("plus_value");
            entity.Property(e => e.Unk3).HasColumnName("unk3");
        });

        modelBuilder.Entity<DdonLearnedAbility>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job, e.AbilityId }).HasName("ddon_learned_ability_pkey");

            entity.ToTable("ddon_learned_ability");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.AbilityId).HasColumnName("ability_id");
            entity.Property(e => e.AbilityLv).HasColumnName("ability_lv");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonLearnedAbilities)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_learned_ability_character_common_id");
        });

        modelBuilder.Entity<DdonLearnedCustomSkill>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job, e.SkillId }).HasName("ddon_learned_custom_skill_pkey");

            entity.ToTable("ddon_learned_custom_skill");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.SkillLv).HasColumnName("skill_lv");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonLearnedCustomSkills)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_learned_custom_skill_character_common_id");
        });

        modelBuilder.Entity<DdonNormalSkillParam>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.Job, e.SkillNo }).HasName("pk_ddon_normal_skill_param");

            entity.ToTable("ddon_normal_skill_param");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.SkillNo).HasColumnName("skill_no");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.PreSkillNo).HasColumnName("pre_skill_no");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonNormalSkillParams)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_normal_skill_param_character_common_id");
        });

        modelBuilder.Entity<DdonOrbGainExtendParam>(entity =>
        {
            entity.HasKey(e => e.CharacterCommonId).HasName("ddon_orb_gain_extend_param_pkey");

            entity.ToTable("ddon_orb_gain_extend_param");

            entity.Property(e => e.CharacterCommonId)
                .ValueGeneratedNever()
                .HasColumnName("character_common_id");
            entity.Property(e => e.AbilityCost).HasColumnName("ability_cost");
            entity.Property(e => e.EquipItemSlot).HasColumnName("equip_item_slot");
            entity.Property(e => e.HpMax).HasColumnName("hp_max");
            entity.Property(e => e.JewelrySlot).HasColumnName("jewelry_slot");
            entity.Property(e => e.MagicAttack).HasColumnName("magic_attack");
            entity.Property(e => e.MagicDefence).HasColumnName("magic_defence");
            entity.Property(e => e.MainPawnSlot).HasColumnName("main_pawn_slot");
            entity.Property(e => e.MaterialItemSlot).HasColumnName("material_item_slot");
            entity.Property(e => e.PhysicalAttack).HasColumnName("physical_attack");
            entity.Property(e => e.PhysicalDefence).HasColumnName("physical_defence");
            entity.Property(e => e.StaminaMax).HasColumnName("stamina_max");
            entity.Property(e => e.SupportPawnSlot).HasColumnName("support_pawn_slot");
            entity.Property(e => e.UseItemSlot).HasColumnName("use_item_slot");

            entity.HasOne(d => d.CharacterCommon).WithOne(p => p.DdonOrbGainExtendParam)
                .HasForeignKey<DdonOrbGainExtendParam>(d => d.CharacterCommonId)
                .HasConstraintName("fk_character_orb_gain_extend_param_character_common_id");
        });

        modelBuilder.Entity<DdonPawn>(entity =>
        {
            entity.HasKey(e => e.PawnId).HasName("ddon_pawn_pkey");

            entity.ToTable("ddon_pawn");

            entity.Property(e => e.PawnId).HasColumnName("pawn_id");
            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.HmType).HasColumnName("hm_type");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
            entity.Property(e => e.PawnType).HasColumnName("pawn_type");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonPawns)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_pawn_character_common_id");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonPawns)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("fk_character_character_id");
        });

        modelBuilder.Entity<DdonPawnReaction>(entity =>
        {
            entity.HasKey(e => new { e.PawnId, e.ReactionType }).HasName("pk_ddon_pawn_reaction");

            entity.ToTable("ddon_pawn_reaction");

            entity.Property(e => e.PawnId).HasColumnName("pawn_id");
            entity.Property(e => e.ReactionType).HasColumnName("reaction_type");
            entity.Property(e => e.MotionNo).HasColumnName("motion_no");

            entity.HasOne(d => d.Pawn).WithMany(p => p.DdonPawnReactions)
                .HasForeignKey(d => d.PawnId)
                .HasConstraintName("fk_pawn_reaction_pawn_id");
        });

        modelBuilder.Entity<DdonShortcut>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.PageNo, e.ButtonNo }).HasName("pk_ddon_shortcut");

            entity.ToTable("ddon_shortcut");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.PageNo).HasColumnName("page_no");
            entity.Property(e => e.ButtonNo).HasColumnName("button_no");
            entity.Property(e => e.ExexType).HasColumnName("exex_type");
            entity.Property(e => e.F32Data).HasColumnName("f32_data");
            entity.Property(e => e.ShortcutId).HasColumnName("shortcut_id");
            entity.Property(e => e.U32Data).HasColumnName("u32_data");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonShortcuts)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("fk_shortcut_character_id");
        });

        modelBuilder.Entity<DdonSpSkill>(entity =>
        {
            entity.HasKey(e => e.PawnId).HasName("pk_ddon_sp_skill");

            entity.ToTable("ddon_sp_skill");

            entity.Property(e => e.PawnId)
                .ValueGeneratedNever()
                .HasColumnName("pawn_id");
            entity.Property(e => e.SpSkillId).HasColumnName("sp_skill_id");
            entity.Property(e => e.SpSkillLv).HasColumnName("sp_skill_lv");

            entity.HasOne(d => d.Pawn).WithOne(p => p.DdonSpSkill)
                .HasForeignKey<DdonSpSkill>(d => d.PawnId)
                .HasConstraintName("fk_sp_skill_pawn_id");
        });

        modelBuilder.Entity<DdonStatusInfo>(entity =>
        {
            entity.HasKey(e => e.CharacterCommonId).HasName("ddon_status_info_pkey");

            entity.ToTable("ddon_status_info");

            entity.Property(e => e.CharacterCommonId)
                .ValueGeneratedNever()
                .HasColumnName("character_common_id");
            entity.Property(e => e.GainAttack).HasColumnName("gain_attack");
            entity.Property(e => e.GainDefense).HasColumnName("gain_defense");
            entity.Property(e => e.GainHp).HasColumnName("gain_hp");
            entity.Property(e => e.GainMagicAttack).HasColumnName("gain_magic_attack");
            entity.Property(e => e.GainMagicDefense).HasColumnName("gain_magic_defense");
            entity.Property(e => e.GainStamina).HasColumnName("gain_stamina");
            entity.Property(e => e.Hp).HasColumnName("hp");
            entity.Property(e => e.MaxHp).HasColumnName("max_hp");
            entity.Property(e => e.MaxStamina).HasColumnName("max_stamina");
            entity.Property(e => e.RevivePoint).HasColumnName("revive_point");
            entity.Property(e => e.Stamina).HasColumnName("stamina");
            entity.Property(e => e.WhiteHp).HasColumnName("white_hp");

            entity.HasOne(d => d.CharacterCommon).WithOne(p => p.DdonStatusInfo)
                .HasForeignKey<DdonStatusInfo>(d => d.CharacterCommonId)
                .HasConstraintName("fk_status_info_character_common_id");
        });

        modelBuilder.Entity<DdonStorage>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.StorageType }).HasName("pk_ddon_storage");

            entity.ToTable("ddon_storage");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.StorageType).HasColumnName("storage_type");
            entity.Property(e => e.ItemSort)
                .IsRequired()
                .HasColumnName("item_sort");
            entity.Property(e => e.SlotMax).HasColumnName("slot_max");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonStorages)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("fk_storage_character_id");
        });

        modelBuilder.Entity<DdonStorageItem>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.StorageType, e.SlotNo }).HasName("pk_ddon_storage_item");

            entity.ToTable("ddon_storage_item");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.StorageType).HasColumnName("storage_type");
            entity.Property(e => e.SlotNo).HasColumnName("slot_no");
            entity.Property(e => e.ItemNum).HasColumnName("item_num");
            entity.Property(e => e.ItemUid)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("item_uid");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonStorageItems)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("fk_storage_item_character_id");

            entity.HasOne(d => d.ItemU).WithMany(p => p.DdonStorageItems)
                .HasForeignKey(d => d.ItemUid)
                .HasConstraintName("fk_storage_item_item_uid");
        });

        modelBuilder.Entity<DdonUnlockedSecretAbility>(entity =>
        {
            entity.HasKey(e => new { e.CharacterCommonId, e.AbilityId }).HasName("pk_ddon_unlocked_secret_ability");

            entity.ToTable("ddon_unlocked_secret_ability");

            entity.Property(e => e.CharacterCommonId).HasColumnName("character_common_id");
            entity.Property(e => e.AbilityId).HasColumnName("ability_id");

            entity.HasOne(d => d.CharacterCommon).WithMany(p => p.DdonUnlockedSecretAbilities)
                .HasForeignKey(d => d.CharacterCommonId)
                .HasConstraintName("fk_unlocked_secret_ability_character_common_id");
        });

        modelBuilder.Entity<DdonWalletPoint>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.Type }).HasName("pk_ddon_wallet_point");

            entity.ToTable("ddon_wallet_point");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Character).WithMany(p => p.DdonWalletPoints)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("fk_wallet_point_character_id");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("setting_pkey");

            entity.ToTable("setting");

            entity.Property(e => e.Key)
                .HasMaxLength(32)
                .HasColumnName("key");
            entity.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arrowgene.Ddon.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    normal_name = table.Column<string>(type: "TEXT", nullable: false),
                    hash = table.Column<string>(type: "TEXT", nullable: false),
                    mail = table.Column<string>(type: "TEXT", nullable: false),
                    mail_verified = table.Column<bool>(type: "INTEGER", nullable: false),
                    mail_verified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    mail_token = table.Column<string>(type: "TEXT", nullable: true),
                    password_token = table.Column<string>(type: "TEXT", nullable: true),
                    login_token = table.Column<string>(type: "TEXT", nullable: true),
                    login_token_created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    state = table.Column<int>(type: "INTEGER", nullable: false),
                    last_login = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ddon_character_common",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    hide_equip_head = table.Column<bool>(type: "INTEGER", nullable: false),
                    hide_equip_lantern = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_character_common_pkey", x => x.character_common_id);
                });

            migrationBuilder.CreateTable(
                name: "ddon_item",
                columns: table => new
                {
                    uid = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    item_id = table.Column<int>(type: "INTEGER", nullable: false),
                    unk3 = table.Column<short>(type: "INTEGER", nullable: false),
                    color = table.Column<short>(type: "INTEGER", nullable: false),
                    plus_value = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_item_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "setting",
                columns: table => new
                {
                    key = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("setting_pkey", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "ddon_connection",
                columns: table => new
                {
                    server_id = table.Column<int>(type: "INTEGER", nullable: false),
                    account_id = table.Column<int>(type: "INTEGER", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_connection_token_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ddon_character",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    account_id = table.Column<int>(type: "INTEGER", nullable: false),
                    version = table.Column<int>(type: "INTEGER", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    my_pawn_slot_num = table.Column<short>(type: "INTEGER", nullable: false),
                    rental_pawn_slot_num = table.Column<short>(type: "INTEGER", nullable: false),
                    hide_equip_head_pawn = table.Column<bool>(type: "INTEGER", nullable: false),
                    hide_equip_lantern_pawn = table.Column<bool>(type: "INTEGER", nullable: false),
                    arisen_profile_share_range = table.Column<short>(type: "INTEGER", nullable: false),
                    fav_warp_slot_num = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_character_pkey", x => x.character_id);
                    table.ForeignKey(
                        name: "fk_character_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_character_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_character_job_data",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    exp = table.Column<int>(type: "INTEGER", nullable: false),
                    job_point = table.Column<int>(type: "INTEGER", nullable: false),
                    lv = table.Column<int>(type: "INTEGER", nullable: false),
                    atk = table.Column<short>(type: "INTEGER", nullable: false),
                    def = table.Column<short>(type: "INTEGER", nullable: false),
                    m_atk = table.Column<short>(type: "INTEGER", nullable: false),
                    m_def = table.Column<short>(type: "INTEGER", nullable: false),
                    strength = table.Column<short>(type: "INTEGER", nullable: false),
                    down_power = table.Column<short>(type: "INTEGER", nullable: false),
                    shake_power = table.Column<short>(type: "INTEGER", nullable: false),
                    stun_power = table.Column<short>(type: "INTEGER", nullable: false),
                    consitution = table.Column<short>(type: "INTEGER", nullable: false),
                    guts = table.Column<short>(type: "INTEGER", nullable: false),
                    fire_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    ice_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    thunder_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    holy_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    dark_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    spread_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    freeze_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    shock_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    absorb_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    dark_elm_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    poison_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    slow_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    sleep_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    stun_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    wet_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    oil_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    seal_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    curse_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    soft_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    stone_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    gold_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    fire_reduce_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    ice_reduce_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    thunder_reduce_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    holy_reduce_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    dark_reduce_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    atk_down_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    def_down_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    m_atk_down_resist = table.Column<short>(type: "INTEGER", nullable: false),
                    m_def_down_resist = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_character_job_data", x => new { x.character_common_id, x.job });
                    table.ForeignKey(
                        name: "fk_character_job_data_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_dragon_force_augmentation",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    element_id = table.Column<int>(type: "INTEGER", nullable: false),
                    page_no = table.Column<int>(type: "INTEGER", nullable: false),
                    group_no = table.Column<int>(type: "INTEGER", nullable: false),
                    index_no = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_dragon_force_augmentation", x => new { x.character_common_id, x.element_id });
                    table.ForeignKey(
                        name: "fk_character_dragon_force_augmentation_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_edit_info",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    sex = table.Column<short>(type: "INTEGER", nullable: false),
                    voice = table.Column<short>(type: "INTEGER", nullable: false),
                    voice_pitch = table.Column<short>(type: "INTEGER", nullable: false),
                    personality = table.Column<short>(type: "INTEGER", nullable: false),
                    speech_freq = table.Column<short>(type: "INTEGER", nullable: false),
                    body_type = table.Column<short>(type: "INTEGER", nullable: false),
                    hair = table.Column<short>(type: "INTEGER", nullable: false),
                    beard = table.Column<short>(type: "INTEGER", nullable: false),
                    makeup = table.Column<short>(type: "INTEGER", nullable: false),
                    scar = table.Column<short>(type: "INTEGER", nullable: false),
                    eye_preset_no = table.Column<short>(type: "INTEGER", nullable: false),
                    nose_preset_no = table.Column<short>(type: "INTEGER", nullable: false),
                    mouth_preset_no = table.Column<short>(type: "INTEGER", nullable: false),
                    eyebrow_tex_no = table.Column<short>(type: "INTEGER", nullable: false),
                    color_skin = table.Column<short>(type: "INTEGER", nullable: false),
                    color_hair = table.Column<short>(type: "INTEGER", nullable: false),
                    color_beard = table.Column<short>(type: "INTEGER", nullable: false),
                    color_eyebrow = table.Column<short>(type: "INTEGER", nullable: false),
                    color_r_eye = table.Column<short>(type: "INTEGER", nullable: false),
                    color_l_eye = table.Column<short>(type: "INTEGER", nullable: false),
                    color_makeup = table.Column<short>(type: "INTEGER", nullable: false),
                    sokutobu = table.Column<short>(type: "INTEGER", nullable: false),
                    hitai = table.Column<short>(type: "INTEGER", nullable: false),
                    mimi_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    kannkaku = table.Column<short>(type: "INTEGER", nullable: false),
                    mabisasi_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    hanakuchi_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    ago_saki_haba = table.Column<short>(type: "INTEGER", nullable: false),
                    ago_zengo = table.Column<short>(type: "INTEGER", nullable: false),
                    ago_saki_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    hitomi_ookisa = table.Column<short>(type: "INTEGER", nullable: false),
                    me_ookisa = table.Column<short>(type: "INTEGER", nullable: false),
                    me_kaiten = table.Column<short>(type: "INTEGER", nullable: false),
                    mayu_kaiten = table.Column<short>(type: "INTEGER", nullable: false),
                    mimi_ookisa = table.Column<short>(type: "INTEGER", nullable: false),
                    mimi_muki = table.Column<short>(type: "INTEGER", nullable: false),
                    elf_mimi = table.Column<short>(type: "INTEGER", nullable: false),
                    miken_takasa = table.Column<short>(type: "INTEGER", nullable: false),
                    miken_haba = table.Column<short>(type: "INTEGER", nullable: false),
                    hohobone_ryou = table.Column<short>(type: "INTEGER", nullable: false),
                    hohobone_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    hohoniku = table.Column<short>(type: "INTEGER", nullable: false),
                    erahone_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    erahone_haba = table.Column<short>(type: "INTEGER", nullable: false),
                    hana_jyouge = table.Column<short>(type: "INTEGER", nullable: false),
                    hana_haba = table.Column<short>(type: "INTEGER", nullable: false),
                    hana_takasa = table.Column<short>(type: "INTEGER", nullable: false),
                    hana_kakudo = table.Column<short>(type: "INTEGER", nullable: false),
                    kuchi_haba = table.Column<short>(type: "INTEGER", nullable: false),
                    kuchi_atsusa = table.Column<short>(type: "INTEGER", nullable: false),
                    eyebrow_uv_offset_x = table.Column<short>(type: "INTEGER", nullable: false),
                    eyebrow_uv_offset_y = table.Column<short>(type: "INTEGER", nullable: false),
                    wrinkle = table.Column<short>(type: "INTEGER", nullable: false),
                    wrinkle_albedo_blend_rate = table.Column<short>(type: "INTEGER", nullable: false),
                    wrinkle_detail_normal_power = table.Column<short>(type: "INTEGER", nullable: false),
                    muscle_albedo_blend_rate = table.Column<short>(type: "INTEGER", nullable: false),
                    muscle_detail_normal_power = table.Column<short>(type: "INTEGER", nullable: false),
                    height = table.Column<short>(type: "INTEGER", nullable: false),
                    head_size = table.Column<short>(type: "INTEGER", nullable: false),
                    neck_offset = table.Column<short>(type: "INTEGER", nullable: false),
                    neck_scale = table.Column<short>(type: "INTEGER", nullable: false),
                    upper_body_scale_x = table.Column<short>(type: "INTEGER", nullable: false),
                    belly_size = table.Column<short>(type: "INTEGER", nullable: false),
                    teat_scale = table.Column<short>(type: "INTEGER", nullable: false),
                    tekubi_size = table.Column<short>(type: "INTEGER", nullable: false),
                    koshi_offset = table.Column<short>(type: "INTEGER", nullable: false),
                    koshi_size = table.Column<short>(type: "INTEGER", nullable: false),
                    ankle_offset = table.Column<short>(type: "INTEGER", nullable: false),
                    fat = table.Column<short>(type: "INTEGER", nullable: false),
                    muscle = table.Column<short>(type: "INTEGER", nullable: false),
                    motion_filter = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_edit_info_pkey", x => x.character_common_id);
                    table.ForeignKey(
                        name: "fk_edit_info_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_learned_ability",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    ability_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ability_lv = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_learned_ability_pkey", x => new { x.character_common_id, x.job, x.ability_id });
                    table.ForeignKey(
                        name: "fk_learned_ability_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_learned_custom_skill",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    skill_id = table.Column<int>(type: "INTEGER", nullable: false),
                    skill_lv = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_learned_custom_skill_pkey", x => new { x.character_common_id, x.job, x.skill_id });
                    table.ForeignKey(
                        name: "fk_learned_custom_skill_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_normal_skill_param",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    skill_no = table.Column<int>(type: "INTEGER", nullable: false),
                    index = table.Column<int>(type: "INTEGER", nullable: false),
                    pre_skill_no = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_normal_skill_param", x => new { x.character_common_id, x.job, x.skill_no });
                    table.ForeignKey(
                        name: "fk_normal_skill_param_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_orb_gain_extend_param",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    hp_max = table.Column<int>(type: "INTEGER", nullable: false),
                    stamina_max = table.Column<int>(type: "INTEGER", nullable: false),
                    physical_attack = table.Column<int>(type: "INTEGER", nullable: false),
                    physical_defence = table.Column<int>(type: "INTEGER", nullable: false),
                    magic_attack = table.Column<int>(type: "INTEGER", nullable: false),
                    magic_defence = table.Column<int>(type: "INTEGER", nullable: false),
                    ability_cost = table.Column<int>(type: "INTEGER", nullable: false),
                    jewelry_slot = table.Column<int>(type: "INTEGER", nullable: false),
                    use_item_slot = table.Column<int>(type: "INTEGER", nullable: false),
                    material_item_slot = table.Column<int>(type: "INTEGER", nullable: false),
                    equip_item_slot = table.Column<int>(type: "INTEGER", nullable: false),
                    main_pawn_slot = table.Column<int>(type: "INTEGER", nullable: false),
                    support_pawn_slot = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_orb_gain_extend_param_pkey", x => x.character_common_id);
                    table.ForeignKey(
                        name: "fk_character_orb_gain_extend_param_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_status_info",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    hp = table.Column<int>(type: "INTEGER", nullable: false),
                    stamina = table.Column<int>(type: "INTEGER", nullable: false),
                    revive_point = table.Column<short>(type: "INTEGER", nullable: false),
                    max_hp = table.Column<int>(type: "INTEGER", nullable: false),
                    max_stamina = table.Column<int>(type: "INTEGER", nullable: false),
                    white_hp = table.Column<int>(type: "INTEGER", nullable: false),
                    gain_hp = table.Column<int>(type: "INTEGER", nullable: false),
                    gain_stamina = table.Column<int>(type: "INTEGER", nullable: false),
                    gain_attack = table.Column<int>(type: "INTEGER", nullable: false),
                    gain_defense = table.Column<int>(type: "INTEGER", nullable: false),
                    gain_magic_attack = table.Column<int>(type: "INTEGER", nullable: false),
                    gain_magic_defense = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_status_info_pkey", x => x.character_common_id);
                    table.ForeignKey(
                        name: "fk_status_info_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_unlocked_secret_ability",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ability_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_unlocked_secret_ability", x => new { x.character_common_id, x.ability_id });
                    table.ForeignKey(
                        name: "fk_unlocked_secret_ability_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_equip_item",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    equip_type = table.Column<short>(type: "INTEGER", nullable: false),
                    equip_slot = table.Column<short>(type: "INTEGER", nullable: false),
                    item_uid = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_equip_item", x => new { x.character_common_id, x.job, x.equip_type, x.equip_slot });
                    table.ForeignKey(
                        name: "fk_equip_item_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_equip_item_item_uid",
                        column: x => x.item_uid,
                        principalTable: "ddon_item",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_equip_job_item",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    equip_slot = table.Column<short>(type: "INTEGER", nullable: false),
                    item_uid = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_equip_job_item", x => new { x.character_common_id, x.job, x.equip_slot });
                    table.ForeignKey(
                        name: "fk_equip_job_item_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_equip_job_item_item_uid",
                        column: x => x.item_uid,
                        principalTable: "ddon_item",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_character_arisen_profile",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    background_id = table.Column<short>(type: "INTEGER", nullable: false),
                    title_uid = table.Column<int>(type: "INTEGER", nullable: false),
                    title_index = table.Column<int>(type: "INTEGER", nullable: false),
                    motion_id = table.Column<short>(type: "INTEGER", nullable: false),
                    motion_frame_no = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_character_arisen_profile_pkey", x => x.character_id);
                    table.ForeignKey(
                        name: "fk_arisen_profile_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_character_matching_profile",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    entry_job = table.Column<short>(type: "INTEGER", nullable: false),
                    entry_job_level = table.Column<int>(type: "INTEGER", nullable: false),
                    current_job = table.Column<short>(type: "INTEGER", nullable: false),
                    current_job_level = table.Column<int>(type: "INTEGER", nullable: false),
                    objective_type1 = table.Column<int>(type: "INTEGER", nullable: false),
                    objective_type2 = table.Column<int>(type: "INTEGER", nullable: false),
                    play_style = table.Column<int>(type: "INTEGER", nullable: false),
                    comment = table.Column<string>(type: "TEXT", nullable: false),
                    is_join_party = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_character_matching_profile_pkey", x => x.character_id);
                    table.ForeignKey(
                        name: "fk_matching_profile_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_communication_shortcut",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    page_no = table.Column<int>(type: "INTEGER", nullable: false),
                    button_no = table.Column<int>(type: "INTEGER", nullable: false),
                    type = table.Column<short>(type: "INTEGER", nullable: false),
                    category = table.Column<short>(type: "INTEGER", nullable: false),
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_communication_shortcut", x => new { x.character_id, x.page_no, x.button_no });
                    table.ForeignKey(
                        name: "fk_communication_shortcut_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_contact_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    requester_character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    requested_character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<byte>(type: "INTEGER", nullable: false),
                    type = table.Column<byte>(type: "INTEGER", nullable: false),
                    requester_favorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    requested_favorite = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_contact_list_pkey", x => x.id);
                    table.ForeignKey(
                        name: "ddon_contact_list_requested_character_id_fkey",
                        column: x => x.requested_character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id");
                    table.ForeignKey(
                        name: "ddon_contact_list_requester_character_id_fkey",
                        column: x => x.requester_character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id");
                });

            migrationBuilder.CreateTable(
                name: "ddon_game_token",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "INTEGER", nullable: false),
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    token = table.Column<string>(type: "TEXT", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_game_token_pkey", x => x.account_id);
                    table.ForeignKey(
                        name: "fk_game_token_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_game_token_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id");
                });

            migrationBuilder.CreateTable(
                name: "ddon_pawn",
                columns: table => new
                {
                    pawn_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    hm_type = table.Column<short>(type: "INTEGER", nullable: false),
                    pawn_type = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ddon_pawn_pkey", x => x.pawn_id);
                    table.ForeignKey(
                        name: "fk_character_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pawn_character_common_id",
                        column: x => x.character_common_id,
                        principalTable: "ddon_character_common",
                        principalColumn: "character_common_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_shortcut",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    page_no = table.Column<int>(type: "INTEGER", nullable: false),
                    button_no = table.Column<int>(type: "INTEGER", nullable: false),
                    shortcut_id = table.Column<int>(type: "INTEGER", nullable: false),
                    u32_data = table.Column<int>(type: "INTEGER", nullable: false),
                    f32_data = table.Column<int>(type: "INTEGER", nullable: false),
                    exex_type = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_shortcut", x => new { x.character_id, x.page_no, x.button_no });
                    table.ForeignKey(
                        name: "fk_shortcut_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_storage",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    storage_type = table.Column<short>(type: "INTEGER", nullable: false),
                    slot_max = table.Column<short>(type: "INTEGER", nullable: false),
                    item_sort = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_storage", x => new { x.character_id, x.storage_type });
                    table.ForeignKey(
                        name: "fk_storage_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_storage_item",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    storage_type = table.Column<short>(type: "INTEGER", nullable: false),
                    slot_no = table.Column<short>(type: "INTEGER", nullable: false),
                    item_uid = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    item_num = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_storage_item", x => new { x.character_id, x.storage_type, x.slot_no });
                    table.ForeignKey(
                        name: "fk_storage_item_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_storage_item_item_uid",
                        column: x => x.item_uid,
                        principalTable: "ddon_item",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_wallet_point",
                columns: table => new
                {
                    character_id = table.Column<int>(type: "INTEGER", nullable: false),
                    type = table.Column<short>(type: "INTEGER", nullable: false),
                    value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_wallet_point", x => new { x.character_id, x.type });
                    table.ForeignKey(
                        name: "fk_wallet_point_character_id",
                        column: x => x.character_id,
                        principalTable: "ddon_character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_equipped_ability",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    equipped_to_job = table.Column<short>(type: "INTEGER", nullable: false),
                    slot_no = table.Column<short>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    ability_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_equipped_ability", x => new { x.character_common_id, x.equipped_to_job, x.slot_no });
                    table.ForeignKey(
                        name: "fk_equipped_ability_character_common_id",
                        columns: x => new { x.character_common_id, x.job, x.ability_id },
                        principalTable: "ddon_learned_ability",
                        principalColumns: new[] { "character_common_id", "job", "ability_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_equipped_custom_skill",
                columns: table => new
                {
                    character_common_id = table.Column<int>(type: "INTEGER", nullable: false),
                    job = table.Column<short>(type: "INTEGER", nullable: false),
                    slot_no = table.Column<short>(type: "INTEGER", nullable: false),
                    skill_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_equipped_custom_skill", x => new { x.character_common_id, x.job, x.slot_no });
                    table.ForeignKey(
                        name: "fk_equipped_custom_skill_character_common_id",
                        columns: x => new { x.character_common_id, x.job, x.skill_id },
                        principalTable: "ddon_learned_custom_skill",
                        principalColumns: new[] { "character_common_id", "job", "skill_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_pawn_reaction",
                columns: table => new
                {
                    pawn_id = table.Column<int>(type: "INTEGER", nullable: false),
                    reaction_type = table.Column<short>(type: "INTEGER", nullable: false),
                    motion_no = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_pawn_reaction", x => new { x.pawn_id, x.reaction_type });
                    table.ForeignKey(
                        name: "fk_pawn_reaction_pawn_id",
                        column: x => x.pawn_id,
                        principalTable: "ddon_pawn",
                        principalColumn: "pawn_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ddon_sp_skill",
                columns: table => new
                {
                    pawn_id = table.Column<int>(type: "INTEGER", nullable: false),
                    sp_skill_id = table.Column<short>(type: "INTEGER", nullable: false),
                    sp_skill_lv = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ddon_sp_skill", x => x.pawn_id);
                    table.ForeignKey(
                        name: "fk_sp_skill_pawn_id",
                        column: x => x.pawn_id,
                        principalTable: "ddon_pawn",
                        principalColumn: "pawn_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "uq_account_login_token",
                table: "account",
                column: "login_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_account_mail",
                table: "account",
                column: "mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_account_name",
                table: "account",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_account_normal_name",
                table: "account",
                column: "normal_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ddon_character_account_id",
                table: "ddon_character",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_character_character_common_id",
                table: "ddon_character",
                column: "character_common_id");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_connection_account_id",
                table: "ddon_connection",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "uq_connection_server_id_account_id",
                table: "ddon_connection",
                columns: new[] { "server_id", "account_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ddon_contact_list_requester_character_id_requested_characte_key",
                table: "ddon_contact_list",
                columns: new[] { "requester_character_id", "requested_character_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ddon_contact_list_requested_character_id",
                table: "ddon_contact_list",
                column: "requested_character_id");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_equip_item_item_uid",
                table: "ddon_equip_item",
                column: "item_uid");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_equip_job_item_item_uid",
                table: "ddon_equip_job_item",
                column: "item_uid");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_equipped_ability_character_common_id_job_ability_id",
                table: "ddon_equipped_ability",
                columns: new[] { "character_common_id", "job", "ability_id" });

            migrationBuilder.CreateIndex(
                name: "IX_ddon_equipped_custom_skill_character_common_id_job_skill_id",
                table: "ddon_equipped_custom_skill",
                columns: new[] { "character_common_id", "job", "skill_id" });

            migrationBuilder.CreateIndex(
                name: "IX_ddon_game_token_character_id",
                table: "ddon_game_token",
                column: "character_id");

            migrationBuilder.CreateIndex(
                name: "uq_game_token_token",
                table: "ddon_game_token",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ddon_pawn_character_common_id",
                table: "ddon_pawn",
                column: "character_common_id");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_pawn_character_id",
                table: "ddon_pawn",
                column: "character_id");

            migrationBuilder.CreateIndex(
                name: "IX_ddon_storage_item_item_uid",
                table: "ddon_storage_item",
                column: "item_uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ddon_character_arisen_profile");

            migrationBuilder.DropTable(
                name: "ddon_character_job_data");

            migrationBuilder.DropTable(
                name: "ddon_character_matching_profile");

            migrationBuilder.DropTable(
                name: "ddon_communication_shortcut");

            migrationBuilder.DropTable(
                name: "ddon_connection");

            migrationBuilder.DropTable(
                name: "ddon_contact_list");

            migrationBuilder.DropTable(
                name: "ddon_dragon_force_augmentation");

            migrationBuilder.DropTable(
                name: "ddon_edit_info");

            migrationBuilder.DropTable(
                name: "ddon_equip_item");

            migrationBuilder.DropTable(
                name: "ddon_equip_job_item");

            migrationBuilder.DropTable(
                name: "ddon_equipped_ability");

            migrationBuilder.DropTable(
                name: "ddon_equipped_custom_skill");

            migrationBuilder.DropTable(
                name: "ddon_game_token");

            migrationBuilder.DropTable(
                name: "ddon_normal_skill_param");

            migrationBuilder.DropTable(
                name: "ddon_orb_gain_extend_param");

            migrationBuilder.DropTable(
                name: "ddon_pawn_reaction");

            migrationBuilder.DropTable(
                name: "ddon_shortcut");

            migrationBuilder.DropTable(
                name: "ddon_sp_skill");

            migrationBuilder.DropTable(
                name: "ddon_status_info");

            migrationBuilder.DropTable(
                name: "ddon_storage");

            migrationBuilder.DropTable(
                name: "ddon_storage_item");

            migrationBuilder.DropTable(
                name: "ddon_unlocked_secret_ability");

            migrationBuilder.DropTable(
                name: "ddon_wallet_point");

            migrationBuilder.DropTable(
                name: "setting");

            migrationBuilder.DropTable(
                name: "ddon_learned_ability");

            migrationBuilder.DropTable(
                name: "ddon_learned_custom_skill");

            migrationBuilder.DropTable(
                name: "ddon_pawn");

            migrationBuilder.DropTable(
                name: "ddon_item");

            migrationBuilder.DropTable(
                name: "ddon_character");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "ddon_character_common");
        }
    }
}

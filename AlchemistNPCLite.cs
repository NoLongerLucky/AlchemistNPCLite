﻿using AlchemistNPCLite.Interface;
using AlchemistNPCLite.Items;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLite : Mod
    {
        public AlchemistNPCLite()
        {
            ;
        }

        public static Mod Instance;
        internal static AlchemistNPCLite instance;
        internal static ModConfiguration modConfiguration;
        public static ModKeybind DiscordBuff;
        public static bool SF = false;
        public static bool GreaterDangersense = false;
        public static int DTH = 0;
        public static float ppx = 0f;
        public static float ppy = 0f;
        public static string GithubUserName { get { return "VVV101"; } }
        public static string GithubProjectName { get { return "AlchemistNPCLite"; } }
        public static int ReversivityCoinTier1ID;
        public static int ReversivityCoinTier2ID;
        public static int ReversivityCoinTier3ID;
        public static int ReversivityCoinTier4ID;
        public static int ReversivityCoinTier5ID;
        public static int ReversivityCoinTier6ID;
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;

        public override void Load()
        {
            Instance = this;
            string DiscordBuffTeleportation = Language.GetTextValue("Discord Buff Teleportation");
            DiscordBuff = KeybindLoader.RegisterKeybind(this, DiscordBuffTeleportation, "Q");
            SetTranslation();
            instance = this;
            if (!Main.dedServ)
            {
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);

                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);

                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);

                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);
            }
        }

        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("Census", out Mod censusMod);
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Alchemist>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Brewer>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Jeweler>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Tinkerer>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Architect>(), "Have any 3 other NPC present");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Operator>(), "Defeat Eater of Worlds/Brain of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Musician>(), "Defeat Skeletron");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.YoungBrewer>(), "World state is Hardmode and both Alchemist and Operator are alive");
            }
        }

        public override void Unload()
        {
            Instance = null;
            instance = null;
            DiscordBuff = null;
            modConfiguration = null;
        }

        public override void AddRecipeGroups()
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPCLite.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPCLite.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPCLite.tier3HardmodeBar");
            string hardmodeComponent = Language.GetTextValue("Mods.AlchemistNPCLite.hardmodeComponent");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPCLite.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPCLite.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPCLite.evilComponent");
            string evilDrop = Language.GetTextValue("Mods.AlchemistNPCLite.evilDrop");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPCLite.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPCLite.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPCLite.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPCLite.CelestialWings");
            string LunarHamaxe = Language.GetTextValue("Mods.AlchemistNPCLite.LunarHamaxe");
            string tier3Watch = Language.GetTextValue("Mods.AlchemistNPCLite.tier3Watch");

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:CultistMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:Tier3Bar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + hardmodeComponent, new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:HardmodeComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilBar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilMushroom, new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilMush", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilComponent, new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilDrop, new int[]
             {
                 ItemID.RottenChunk, ItemID.Vertebrae
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilDrop", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2anvil, new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2forge, new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyForge", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier1anvil, new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyPreHMAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + celestialWings, new int[]
             {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyCelestialWings", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + LunarHamaxe, new int[]
             {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyLunarHamaxe", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3Watch, new int[]
             {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyWatch", group);

        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AlchemistNPCLiteMessageType msgType = (AlchemistNPCLiteMessageType)reader.ReadByte();
            switch (msgType)
            {
                case AlchemistNPCLiteMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                default:
                    Logger.Error("AlchemistNPCLite: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum AlchemistNPCLiteMessageType : byte
        {
            TeleportPlayer
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.Sundial)
                .AddIngredient(ItemID.CelestialStone)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.Obsidian, 5)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearLava)
                .Register();

            Recipe.Create(ItemID.HoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.CrispyHoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearLava)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.Stopwatch)
                .AddRecipeGroup("AlchemistNPCLite:AnyWatch")
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Wire, 15)
                .AddIngredient(ItemID.Wood, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.DPSMeter)
                .AddRecipeGroup("AlchemistNPCLite:EvilBar", 10)
                .AddRecipeGroup("AlchemistNPCLite:AnyWatch")
                .AddIngredient(ItemID.Wire, 25)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.LifeformAnalyzer)
                .AddIngredient(ItemID.TallyCounter)
                .AddIngredient(ItemID.BlackLens)
                .AddIngredient(ItemID.AntlionMandible)
                .AddRecipeGroup("AlchemistNPCLite:EvilDrop")
                .AddRecipeGroup("AlchemistNPCLite:EvilComponent")
                .AddIngredient(ItemID.Feather)
                .AddIngredient(ItemID.TatteredCloth)
                .AddIngredient(ItemID.Bone)
                .AddIngredient(ItemID.Wire, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.PurificationPowder, 5)
                .AddIngredient(ItemID.Mushroom)
                .AddIngredient(ItemID.Daybloom)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CorruptSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CrimsonSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();
        }

        //SBMW:Transtation method
        public void SetTranslation()
        {
            ModTranslation text = LocalizationLoader.CreateTranslation(this, "DiscordBuffTeleportation");
            text.SetDefault("Discord Buff Teleportation");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混乱药剂传送");
            LocalizationLoader.AddTranslation(text);

            //SBMW:RecipeGroups
            text = LocalizationLoader.CreateTranslation(this, "evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐化/血腥Boss面具");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "cultist");
            text.SetDefault("Cultist mask/hood");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪教徒面具/兜帽");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier3HardmodeBar");
            text.SetDefault("tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级肉后锭(精金/钛金)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "hardmodeComponent");
            text.SetDefault("Hardmode component");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔金/血腥锭");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilMushroom");
            text.SetDefault("evil mushroom");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶蘑菇");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilComponent");
            text.SetDefault("evil component");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶材料(暗影鳞片/组织样本)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilDrop");
            text.SetDefault("evil drop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶掉落物(腐肉/椎骨)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier2anvil");
            text.SetDefault("tier 2 anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级砧(秘银/山铜砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier2forge");
            text.SetDefault("tier 2 forge");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级熔炉(精金/钛金熔炉)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier1anvil");
            text.SetDefault("tier 1 anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一级砧(铁/铅砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CelestialWings");
            text.SetDefault("Celestial Wings");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "四柱翅膀");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "LunarHamaxe");
            text.SetDefault("Lunar Hamaxe");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier3Watch");
            text.SetDefault("tier 3 Watch");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级表(金表/铂金表)");
            LocalizationLoader.AddTranslation(text);
        }
    }
}


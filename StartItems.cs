using System;
using System.Collections.Generic;
using Modding;
using UnityEngine;

namespace StartItems
{
    public class StartItems : Mod, IMenuMod, IGlobalSettings<Settings> {
        internal static StartItems Instance;
        public static Settings GlobalSettings { get; set; } = new Settings();
        public bool ToggleButtonInsideMenu => false;

        public override string GetVersion() => "1.0.0.0";

        public StartItems() : base("StartItems")
        {
            Instance = this;
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            ModHooks.GetPlayerIntHook += getIntHook;
            On.HeroController.Awake += HeroControllerAwake;
            Log("Initialized startItems");
        }

        private int getIntHook(string name, int orig)
        {
            if (name == nameof(PlayerData.charmCost_30) && this.DreamWielder) return 0;
            if (name == nameof(PlayerData.charmCost_36) && this.KingsSoul) return 0;
            return orig;
        }

        private void HeroControllerAwake(On.HeroController.orig_Awake orig, HeroController self)
        {
            orig(self);
            PlayerData pd = PlayerData.instance;

            if (IsmaTear) pd.hasAcidArmour = true;
            if (Wings) pd.hasDoubleJump = true;
            if (Cloak1) pd.hasDash = true;
            if (Cloak2)
            {
                pd.hasDash = true;
                pd.hasShadowDash = true;
            }
            if (AllMaps)
            {
                pd.mapAllRooms = true;
                pd.hasQuill = true;
                pd.mapCrossroads = true;
                pd.mapGreenpath = true;
                pd.mapFungalWastes = true;
                pd.mapFogCanyon = true;
                pd.mapCity = true;
                pd.mapRoyalGardens = true;
                pd.mapDeepnest = true;
                pd.mapCliffs = true;
                pd.mapOutskirts = true;
                pd.mapWaterways = true;
                pd.mapAbyss = true;
                pd.mapMines = true;
                pd.mapAbyss = true;
                pd.mapRestingGrounds = true;
                pd.hasMap = true;
                pd.UpdateGameMap();
            }
            if (Claw) pd.hasWalljump = true;
            if (Lantern) pd.hasLantern = true;
            if (TramPass) pd.hasTramPass = true;
            if (KingsBrand) pd.hasKingsBrand = true;
            if (DreamNail) pd.hasDreamNail = true;
            if (DreamWielder)
            {
                pd.gotCharm_30 = true;
                pd.EquipCharm(30);
            }
            if (KingsSoul)
            {
                pd.gotShadeCharm = false;
                pd.gotCharm_36 = true;
                pd.royalCharmState = 3;
                pd.EquipCharm(36);
            }
            if (VoidHeart)
            {
                pd.gotShadeCharm = true;
                pd.gotCharm_36 = true;
                pd.royalCharmState = 5;
                pd.EquipCharm(36);
            }
            if (CityCrest)
            {
                pd.openedCityGate = true;
                pd.cityGateClosed = false;
            }
            if (Blessing) pd.salubraBlessing = true;
            if (CrystalHeart) pd.hasSuperDash = true;
            if (DreamGate) pd.hasDreamGate = true;
            if (VengefulSpirit)
            {
                pd.fireballLevel = 1;
                pd.shadeFireballLevel = 1;
            }
            if (ShadeSoul)
            {
                pd.fireballLevel = 2;
                pd.shadeFireballLevel = 2;
            }
            if (DesolateDive)
            {
                pd.quakeLevel = 1;
                pd.shadeQuakeLevel = 1;
            }
            if (DDark)
            {
                pd.quakeLevel = 2;
                pd.shadeQuakeLevel = 2;
            }
            if (Wraits)
            {
                pd.screamLevel = 1;
                pd.shadeScreamLevel = 1;
            }
            if (Shriek)
            {
                pd.screamLevel = 2;
                pd.shadeScreamLevel = 2;
            }
            if (CycloneSlash) pd.hasCyclone = true;
            if (DashSlash) pd.hasUpwardSlash = true;
            if (GreatSlash) pd.hasDashSlash = true;
            
            GlobalSettings.CopyFrom();
        }

        #region properties
        public bool IsmaTear = false;
        public bool Wings = false;
        public bool Cloak1 = false;
        public bool Cloak2 = false;
        public bool Claw = false;
        public bool Lantern = false;
        public bool TramPass = false;
        public bool KingsBrand = false;
        public bool DreamNail = false;
        public bool DreamWielder = false;
        public bool KingsSoul = false;
        public bool VoidHeart = false;
        public bool CityCrest = false;
        public bool AllMaps = false;
        public bool Blessing = false;
        public bool CrystalHeart = false;
        public bool DreamGate = false;
        public bool VengefulSpirit = false;
        public bool DesolateDive = false;
        public bool Wraits = false;
        public bool ShadeSoul = false;
        public bool DDark = false;
        public bool Shriek = false;
        public bool CycloneSlash = false;
        public bool DashSlash = false;
        public bool GreatSlash = false;
        #endregion

        public List<IMenuMod.MenuEntry> GetAllMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return new List<IMenuMod.MenuEntry>
            {
                GetMenuBoolEntry("Isma's Tear", () => IsmaTear, val => IsmaTear = val),
                GetMenuBoolEntry("Monarch Wings", () => Wings, val => Wings = val),
                new IMenuMod.MenuEntry {
                    Name = "Dashes",
                    Description = "Choose your dash upgrade",
                    Values = new string[] {
                        "None",
                        "Mothwing Cloak",
                        "Shade Cloak"
                    },
                    Saver = opt => {
                        Cloak1 = opt >= 1;
                        Cloak2 = opt == 2;
                    },
                    Loader = () => {
                        if (Cloak2) return 2;
                        if (Cloak1) return 1;
                        return 0;
                    }
                },
                GetMenuBoolEntry("Mantis Claw", () => Claw, val => Claw = val),
                GetMenuBoolEntry("Lantern", () => Lantern, val => Lantern = val),
                GetMenuBoolEntry("Tram Pass", () => TramPass, val => TramPass = val),
                GetMenuBoolEntry("King's Brand", () => KingsBrand, val => KingsBrand = val),
                GetMenuBoolEntry("Dream Nail", () => DreamNail, val => DreamNail = val),
                new IMenuMod.MenuEntry {
                    Name = "Charms",
                    Description = "Charms to be auto-equiped (no notch cost)",
                    Values = new string[] {
                        "None",
                        "Dream Wielder",
                        "KingsSoul",
                        "Void Heart",
                        "Dream Wielder & KingsSoul",
                        "Dream Wielder & Void Heart",
                    },
                    Saver = opt => {
                        DreamWielder = (opt == 1 || opt == 4 || opt == 5);
                        KingsSoul = (opt == 2 || opt == 4);
                        VoidHeart = (opt == 3 || opt == 5);
                    },
                    Loader = () => {
                        if (DreamWielder && KingsSoul) return 4;
                        if (DreamWielder && VoidHeart) return 5;
                        if (KingsSoul) return 2;
                        if (VoidHeart) return 3;
                        if (DreamWielder) return 1;
                        return 0;
                    }
                },
                GetMenuBoolEntry("City Crest", () => CityCrest, val => CityCrest = val),
                GetMenuBoolEntry("All Maps", () => AllMaps, val => AllMaps = val),
                GetMenuBoolEntry("Blessing", () => Blessing, val => Blessing = val),
                GetMenuBoolEntry("Crystal Heart", () => CrystalHeart, val => CrystalHeart = val),
                GetMenuBoolEntry("Dream Gate", () => DreamGate, val => DreamGate = val),
                new IMenuMod.MenuEntry {
                    Name = "Fireball",
                    Description = null,
                    Values = new string[] {
                        "None",
                        "Vengeful Spirit",
                        "Shade Soul"
                    },
                    Saver = opt => {
                        VengefulSpirit = opt == 1;
                        ShadeSoul = opt == 2;
                    },
                    Loader = () => {
                        if (ShadeSoul) return 2;
                        if (VengefulSpirit) return 1;
                        return 0;
                    }
                },
                new IMenuMod.MenuEntry {
                    Name = "Dive",
                    Description = null,
                    Values = new string[] {
                        "None",
                        "Desolate Dive",
                        "Descending Dark"
                    },
                    Saver = opt => {
                        DesolateDive = opt == 1;
                        DDark = opt == 2;
                    },
                    Loader = () => {
                        if (DDark) return 2;
                        if (DesolateDive) return 1;
                        return 0;
                    }
                },
                new IMenuMod.MenuEntry {
                    Name = "Scream",
                    Description = null,
                    Values = new string[] {
                        "None",
                        "Howling Wraits",
                        "Abyss Shriek"
                    },
                    Saver = opt => {
                        Wraits = opt == 1;
                        Shriek = opt == 2;
                    },
                    Loader = () => {
                        if (Shriek) return 2;
                        if (Wraits) return 1;
                        return 0;
                    }
                },
                GetMenuBoolEntry("Cyclone Slash", () => CycloneSlash, val => CycloneSlash = val),
                GetMenuBoolEntry("Dash Slash", () => DashSlash, val => DashSlash = val),
                GetMenuBoolEntry("Great Slash", () => GreatSlash, val => GreatSlash = val)
            };
        }
        private IMenuMod.MenuEntry GetMenuBoolEntry(string name, Func<bool> getter, Action<bool> setter) {
            return new IMenuMod.MenuEntry {
                Name = name,
                Description = null,
                Values = new string[] { "Off", "On" },
                Saver = opt => setter(opt switch {
                    0 => false,
                    1 => true,
                    _ => throw new InvalidOperationException()
                }),
                Loader = () => getter() ? 1 : 0
            };
        }

        List<IMenuMod.MenuEntry> IMenuMod.GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return GetAllMenuData(toggleButtonEntry);
        }

        public void OnLoadGlobal(Settings s)
        {
            GlobalSettings = s;
            GlobalSettings.PasteFrom();
        }

        public Settings OnSaveGlobal()
        {
            return GlobalSettings;
        }
    }
}
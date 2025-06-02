using System;
using System.Collections.Generic;
using Modding;
using UnityEngine;

namespace StartItems
{
    public class StartItems : Mod, IMenuMod
    {
        internal static StartItems Instance;

        public bool ToggleButtonInsideMenu => throw new NotImplementedException();

        public override string GetVersion() => "v0.1";

        public StartItems() : base("StartItems")
        {
            Instance = this;
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Log("Initializing startItems");

            Instance = this;

            Log("Initialized startItems");
        }

        public bool IsmaTear = false;
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
        public bool CycloneShlash = false;
        public bool DashSlash = false;
        public bool GreatSlash = false;

        public List<IMenuMod.MenuEntry> GetAllMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            return new List<IMenuMod.MenuEntry>
            {
                GetMenuBoolEntry("Isma's Tear", () => IsmaTear, val => IsmaTear = val),
                GetMenuBoolEntry("Mothwing Cloak", () => Cloak1, val => Cloak1 = val),
                GetMenuBoolEntry("Shade Cloak", () => Cloak2, val => Cloak2 = val),
                GetMenuBoolEntry("Mantis Claw", () => Claw, val => Claw = val),
                GetMenuBoolEntry("Lantern", () => Lantern, val => Lantern = val),
                GetMenuBoolEntry("Tram Pass", () => TramPass, val => TramPass = val),
                GetMenuBoolEntry("King's Brand", () => KingsBrand, val => KingsBrand = val),
                GetMenuBoolEntry("Dream Nail", () => DreamNail, val => DreamNail = val),
                GetMenuBoolEntry("Dream Wielder", () => DreamWielder, val => DreamWielder = val),
                GetMenuBoolEntry("King's Soul", () => KingsSoul, val => KingsSoul = val),
                GetMenuBoolEntry("Void Heart", () => VoidHeart, val => VoidHeart = val),
                GetMenuBoolEntry("City Crest", () => CityCrest, val => CityCrest = val),
                GetMenuBoolEntry("All Maps", () => AllMaps, val => AllMaps = val),
                GetMenuBoolEntry("Blessing", () => Blessing, val => Blessing = val),
                GetMenuBoolEntry("Crystal Heart", () => CrystalHeart, val => CrystalHeart = val),
                GetMenuBoolEntry("Dream Gate", () => DreamGate, val => DreamGate = val),
                GetMenuBoolEntry("Vengeful Spirit", () => VengefulSpirit, val => VengefulSpirit = val),
                GetMenuBoolEntry("Desolate Dive", () => DesolateDive, val => DesolateDive = val),
                GetMenuBoolEntry("Howling Wraiths", () => Wraits, val => Wraits = val),
                GetMenuBoolEntry("Shade Soul", () => ShadeSoul, val => ShadeSoul = val),
                GetMenuBoolEntry("Descending Dark", () => DDark, val => DDark = val),
                GetMenuBoolEntry("Abyss Shriek", () => Shriek, val => Shriek = val),
                GetMenuBoolEntry("Cyclone Slash", () => CycloneShlash, val => CycloneShlash = val),
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
    }
}
namespace StartItems
{
    public class Settings
    {
        public bool IsmaTear, Wings, Cloak1, Cloak2, Claw, Lantern, TramPass,
        KingsBrand, DreamNail, DreamWielder, KingsSoul, VoidHeart, CityCrest,
        AllMaps, Blessing, CrystalHeart, DreamGate, VengefulSpirit, DesolateDive,
        Wraits, ShadeSoul, DDark, Shriek, CycloneSlash, DashSlash, GreatSlash;
        public void CopyFrom()
        {
            var modInstance = StartItems.Instance;
            IsmaTear = modInstance.IsmaTear;
            Wings = modInstance.Wings;
            Cloak1 = modInstance.Cloak1;
            Cloak2 = modInstance.Cloak2;
            Claw = modInstance.Claw;
            Lantern = modInstance.Lantern;
            TramPass = modInstance.TramPass;
            KingsBrand = modInstance.KingsBrand;
            DreamNail = modInstance.DreamNail;
            DreamWielder = modInstance.DreamWielder;
            KingsSoul = modInstance.KingsSoul;
            VoidHeart = modInstance.VoidHeart;
            CityCrest = modInstance.CityCrest;
            AllMaps = modInstance.AllMaps;
            Blessing = modInstance.Blessing;
            CrystalHeart = modInstance.CrystalHeart;
            DreamGate = modInstance.DreamGate;
            VengefulSpirit = modInstance.VengefulSpirit;
            DesolateDive = modInstance.DesolateDive;
            Wraits = modInstance.Wraits;
            ShadeSoul = modInstance.ShadeSoul;
            DDark = modInstance.DDark;
            Shriek = modInstance.Shriek;
            CycloneSlash = modInstance.CycloneSlash;
            DashSlash = modInstance.DashSlash;
            GreatSlash = modInstance.GreatSlash;
        }

        public void PasteFrom()
        {
            var mod = StartItems.Instance;
            mod.IsmaTear = IsmaTear;
            mod.Wings = Wings;
            mod.Cloak1 = Cloak1;
            mod.Cloak2 = Cloak2;
            mod.Claw = Claw;
            mod.Lantern = Lantern;
            mod.TramPass = TramPass;
            mod.KingsBrand = KingsBrand;
            mod.DreamNail = DreamNail;
            mod.DreamWielder = DreamWielder;
            mod.KingsSoul = KingsSoul;
            mod.VoidHeart = VoidHeart;
            mod.CityCrest = CityCrest;
            mod.AllMaps = AllMaps;
            mod.Blessing = Blessing;
            mod.CrystalHeart = CrystalHeart;
            mod.DreamGate = DreamGate;
            mod.VengefulSpirit = VengefulSpirit;
            mod.DesolateDive = DesolateDive;
            mod.Wraits = Wraits;
            mod.ShadeSoul = ShadeSoul;
            mod.DDark = DDark;
            mod.Shriek = Shriek;
            mod.CycloneSlash = CycloneSlash;
            mod.DashSlash = DashSlash;
            mod.GreatSlash = GreatSlash;
        }
    }
}
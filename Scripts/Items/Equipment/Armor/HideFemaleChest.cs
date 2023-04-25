namespace Server.Items
{
    [Flipable(0x2B79, 0x3170)]
    public class HideFemaleChest : BaseArmor
    {
        private bool _ElvesOnly;
        
        [CommandProperty(AccessLevel.GameMaster)]
        public bool ElfOnly { get { return _ElvesOnly; } set { _ElvesOnly = value; } }
        
        [Constructable]
        public HideFemaleChest()
            : base(0x2B79)
        {
            Weight = 16.0;
        }

        public HideFemaleChest(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 3;
        public override int BaseFireResistance => 5;
        public override int BaseColdResistance => 5;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 35;
        public override int InitMaxHits => 45;
        public override int StrReq => 50;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
        public override bool AllowMaleWearer => false;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();
        }
    }
}

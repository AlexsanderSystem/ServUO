namespace Server.Items
{
    [Flipable(0x2B73, 0x316A)]
    public class WingedHelm : BaseArmor
    {
        private bool _ElvesOnly;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool ElfOnly { get { return _ElvesOnly; } set { _ElvesOnly = value; } }
        
        [Constructable]
        public WingedHelm()
            : base(0x2B73)
        {
            Weight = 15.0;
        }

        public WingedHelm(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 8;
        public override int BaseFireResistance => 4;
        public override int BaseColdResistance => 4;
        public override int BasePoisonResistance => 4;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 45;
        public override int InitMaxHits => 55;
        public override int StrReq => 60;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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

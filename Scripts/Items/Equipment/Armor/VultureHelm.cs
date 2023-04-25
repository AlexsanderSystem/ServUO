namespace Server.Items
{
    [Flipable(0x2B72, 0x3169)]
    public class VultureHelm : BaseArmor
    {
        private bool _ElvesOnly;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool ElfOnly { get { return _ElvesOnly; } set { _ElvesOnly = value; } }
        
        [Constructable]
        public VultureHelm()
            : base(0x2B72)
        {
            Weight = 15.0;
        }

        public VultureHelm(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 8;
        public override int BaseFireResistance => 4;
        public override int BaseColdResistance => 4;
        public override int BasePoisonResistance => 4;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;
        public override int StrReq => 70;
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

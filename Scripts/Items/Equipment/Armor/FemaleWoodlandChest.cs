namespace Server.Items
{
    [Flipable(0x2B6D, 0x3164)]
    public class FemaleElvenPlateChest : BaseArmor
    {
        [Constructable]
        public FemaleElvenPlateChest()
            : base(0x2B6D)
        {
            Weight = 18.0;
        }

        public FemaleElvenPlateChest(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 2;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 6;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;
        public override int StrReq => 95;
        public override bool AllowMaleWearer => false;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Wood;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();
        }
    }
}

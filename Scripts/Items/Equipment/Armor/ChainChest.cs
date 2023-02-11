namespace Server.Items
{
    [Flipable(0x13bf, 0x13c4)]
    public class ChainChest : BaseArmor
    {
        public override int BasePhysicalResistance => 9;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 45;
        public override int InitMaxHits => 60;
        public override int StrReq => 70;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

        [Constructable]
        public ChainChest()
            : base(0x13BF)
        {
            Weight = 35.0;
        }

        public ChainChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}

using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishPlateKilt))]
    [Flipable(0x13eb, 0x13f2)]
    public class RingmailGloves : BaseArmor
    {
        [Constructable]
        public RingmailGloves()
            : base(0x13EB)
        {
            Weight = 10.0;
        }

        public RingmailGloves(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 7;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 40;
        public override int InitMaxHits => 50;
        public override int StrReq => 45;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;
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

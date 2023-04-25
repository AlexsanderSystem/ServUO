using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishPlateKilt))]
    [Flipable(0x1414, 0x1418)]
    public class PlateGloves : BaseArmor
    {
        [Constructable]
        public PlateGloves()
            : base(0x1414)
        {
            Weight = 18.0;
        }

        public PlateGloves(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 14;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;
        public override int StrReq => 90;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

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

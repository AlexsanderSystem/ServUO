namespace Server.Items
{
    public class BoneMachete : ElvenMachete
    {
        public override int InitMinHits => 31;
        public override int InitMaxHits => 70;
        public override int LabelNumber => 1020526; // bone machete
        public override int StrengthReq => 50;
        public override int MinDamage => 10;
        public override int MaxDamage => 17;
        

        [Constructable]
        public BoneMachete()
        {
        }

        public BoneMachete(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();
        }
    }
}
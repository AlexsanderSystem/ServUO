using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DualShortAxes))]
    [Flipable(0x2D28, 0x2D34)]
    public class OrnateAxe : BaseAxe
    {
        [Constructable]
        public OrnateAxe()
            : base(0x2D28)
        {
            Weight = 12.0;
            Layer = Layer.TwoHanded;
        }

        public OrnateAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.Disarm;
        public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;
        public override int StrengthReq => 85;
        public override int MinDamage => 32;
        public override int MaxDamage => 40;
        public override float Speed => 4.25f;

        public override int DefMissSound => 0x239;
        public override int InitMinHits => 30;
        public override int InitMaxHits => 60;
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

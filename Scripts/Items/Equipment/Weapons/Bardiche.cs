using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishBardiche))]
    [Flipable(0xF4D, 0xF4E)]
    public class Bardiche : BasePoleArm
    {
        [Constructable]
        public Bardiche()
            : base(0xF4D)
        {
            Weight = 10.0;
        }

        public Bardiche(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

        public override int StrengthReq => 80;

        public override int MinDamage => 35;
        public override int MaxDamage => 37;

        public override float Speed => 3.00f;

        public override int InitMinHits => 31;
        public override int InitMaxHits => 70;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
using Server.Engines.Craft;
using Server.Engines.Harvest;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishScythe))]
    [Flipable(0x26BA, 0x26C4)]
    public class Scythe : BasePoleArm
    {
        [Constructable]
        public Scythe()
            : base(0x26BA)
        {
            Weight = 8.0;
        }

        public Scythe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
        public override int StrengthReq => 70;
        public override int MinDamage => 23;
        public override int MaxDamage => 38;
        public override float Speed => 2.50f;

        public override int InitMinHits => 31;
        public override int InitMaxHits => 70;
        public override HarvestSystem HarvestSystem => null;
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

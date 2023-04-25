using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishAxe))]
    [Flipable(0xF49, 0xF4A)]
    public class Axe : BaseAxe
    {
        [Constructable]
        public Axe()
            : base(0xF49)
        {
            Weight = 10.0;
        }

        public Axe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

        public override int StrengthReq => 65;

        public override int MinDamage => 22;
        public override int MaxDamage => 28;

        public override float Speed => 2.00f;

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
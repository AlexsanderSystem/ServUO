using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DiscMace))]
    [Flipable(0x1407, 0x1406)]
    public class WarMace : BaseBashing
    {
        [Constructable]
        public WarMace()
            : base(0x1407)
        {
            Weight = 10.0;
        }

        public WarMace(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int StrengthReq => 65;
        public override int MinDamage => 25;
        public override int MaxDamage => 39;
        public override float Speed => 2.90f;

        public override int InitMinHits => 31;
        public override int InitMaxHits => 110;
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

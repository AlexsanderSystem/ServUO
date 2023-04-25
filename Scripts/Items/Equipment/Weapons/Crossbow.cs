using System;

namespace Server.Items
{
    [Flipable(0xF50, 0xF4F)]
    public class Crossbow : BaseRanged
    {
        [Constructable]
        public Crossbow()
            : base(0xF50)
        {
            Weight = 12.0;
            Layer = Layer.TwoHanded;
        }

        public Crossbow(Serial serial)
            : base(serial)
        {
        }

        public override int EffectID => 0x1BFE;
        public override Type AmmoType => typeof(Bolt);
        public override Item Ammo => new Bolt();
        public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int StrengthReq => 50;
        public override int MinDamage => 19;
        public override int MaxDamage => 27;
        public override float Speed => 2.50f;

        public override int DefMaxRange => 11;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 80;
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
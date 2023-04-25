using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishBoneHarvester))]
    [Flipable(0x26BB, 0x26C5)]
    public class BoneHarvester : BaseSword
    {
        [Constructable]
        public BoneHarvester()
            : base(0x26BB)
        {
            Weight = 5.0;
        }

        public BoneHarvester(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int StrengthReq => 50;
        public override int MinDamage => 10;
        public override int MaxDamage => 17;
        public override float Speed => 1.50f;

        public override int DefHitSound => 0x23B;
        public override int DefMissSound => 0x23A;
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

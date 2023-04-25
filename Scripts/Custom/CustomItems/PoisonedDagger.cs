using System;
using Server.Network;

namespace Server.Items
{
    public class PoisonedDagger : BaseMeleeWeapon
    {
        [Constructable]
        public PoisonedDagger()
            : base(0xF52)
        {
            Name = "Adaga Envenenada";
            Hue = 1150;
            Weight = 2.0;

            WeaponAttributes.HitPoisonArea = 25;
            //WeaponAttributes.HitPoison = 100;


            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 20;
            Attributes.AttackChance = 15;
            Attributes.DefendChance = 10;
            //Attributes.Luck = ;
        }

        public PoisonedDagger(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

    }
}

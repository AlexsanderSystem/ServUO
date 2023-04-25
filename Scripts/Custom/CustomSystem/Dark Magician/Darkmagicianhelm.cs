// Created By Erad of AOW

using System;
using Server;

namespace Server.Items
{
    public class Darkmagicianhelm : CloseHelm
    {
        public override int InitMinHits{ get{ return 100; } }
        public override int InitMaxHits{ get{ return 155; } }

        [Constructable]
        public Darkmagicianhelm()
        {
            Name = "Darkmagicianhelm";
            Hue = 2183;
            Attributes.BonusStr = 10;
            Attributes.BonusHits = 10;
            Attributes.WeaponDamage = 10;
            Attributes.WeaponSpeed = 2;
            Attributes.Luck = 200;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 100;
            ArmorAttributes.LowerStatReq = 10;
            Attributes.CastSpeed = 20;
            Attributes.CastRecovery = 20;
            Attributes.LowerManaCost = 20;
            Attributes.LowerRegCost = 20;
            SkillBonuses.SetValues( 0, SkillName.Magery, 15.0 );
        }

        public Darkmagicianhelm(Serial serial) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    } // End Class
} // End Namespace

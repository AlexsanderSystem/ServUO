using System;
using Server.Mobiles;

namespace Server.Custom
{
    public class TrollMago : BaseCreature
    {
        [Constructable]
        public TrollMago() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.1, 0.3)
        {
            Name = "Troll Mago";
            Body = 77;
            BaseSoundID = 461;

            SetStr(191, 220);
            SetDex(61, 80);
            SetInt(186, 210);

            SetHits(115, 132);
            SetMana(186, 210);

            SetDamage(7, 14);

            SetSkill(SkillName.EvalInt, 85.1, 100.0);
            SetSkill(SkillName.Magery, 85.1, 100.0);
            SetSkill(SkillName.MagicResist, 85.1, 100.0);
            SetSkill(SkillName.Tactics, 45.1, 70.0);
            SetSkill(SkillName.Wrestling, 45.1, 70.0);

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 28;

            //PackReg(20);
        }

        public TrollMago(Serial serial) : base(serial) { }

        public override void OnDamagedBySpell(Mobile from)
        {
            base.OnDamagedBySpell(from);

            if (from == null || from.Deleted)
                return;

            if (from is BaseCreature)
                return;

            this.Say("Grrrrrrrrrr!");
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}

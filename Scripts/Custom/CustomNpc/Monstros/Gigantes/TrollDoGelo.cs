using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    public class IceTroll : BaseCreature
    {
        [Constructable]
        public IceTroll() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.2)
        {
            Name = "Troll do Gelo";
            Body = 53;
            BaseSoundID = 461;

            SetStr(356, 385);
            SetDex(96, 115);
            SetInt(61, 85);

            SetHits(214, 231);

            SetDamage(12, 18);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 40, 50);
            SetResistance(ResistanceType.Cold, 60, 70);

            SetSkill(SkillName.MagicResist, 85.1, 110.0);
            SetSkill(SkillName.Tactics, 85.1, 100.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 45;

            PackItem(new Club());
        }

        /*
        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.3)
                c.DropItem(new IceCrystal());
        } */

public override void OnGotMeleeAttack(Mobile attacker)
{
    base.OnGotMeleeAttack(attacker);

    if (attacker is BaseCreature)
        return;

    if (Utility.RandomDouble() < 1)
    {
        this.Say("*ACERTA UM GOLPE DEVASTADOR!*");
        attacker.Frozen = true;
        attacker.SendMessage("Você foi congelado!");
        Timer.DelayCall(TimeSpan.FromSeconds(7), () =>
        {
            attacker.Frozen = false;
            attacker.SendMessage("O gelo derrete e você pode se mover novamente.");
        });
    }
}


        public IceTroll(Serial serial) : base(serial)
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

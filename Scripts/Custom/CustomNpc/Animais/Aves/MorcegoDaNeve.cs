using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;


namespace Server.Mobiles

{
    [CorpseName("Corpo de Morcego das Neves")]
    public class SnowBat : BaseCreature
    {
        private DateTime m_NextUptime;

        [Constructable]
        public SnowBat() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.1, 0.4)
        {
            Name = "Morcego das Neves";
            Body = 317;
            Hue = 0;
            BaseSoundID = 0x270;

            SetStr(76, 100);
            SetDex(56, 75);
            SetInt(21, 45);

            SetHits(46, 120);
            SetMana(25, 50);

            SetDamage(3, 7);

            SetSkill(SkillName.MagicResist, 30.0, 52.5);
            SetSkill(SkillName.Tactics, 30.0, 52.5);
            SetSkill(SkillName.Wrestling, 30.0, 52.5);
            SetSkill(SkillName.Magery, 30.0, 52.5);

            VirtualArmor = 10;

            Fame = 400;
            Karma = -400;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 30.1;
        }
        public override bool CanFly => true;
        public override bool AlwaysMurderer => true;

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (Utility.RandomDouble() < 0.25)
            {
                int bleedingSeconds = 10; // duração do sangramento em segundos
                int damagePerSecond = 2; // quantidade de dano por segundo

                defender.SendMessage("Você está sangrando!");
                defender.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
                defender.PlaySound(0x1FA);

                Timer.DelayCall(TimeSpan.FromSeconds(bleedingSeconds), () =>
                {
                    if (defender != null && !defender.Deleted)
                    {
                        defender.SendMessage("O sangramento parou.");
                    }
                });

                Timer bleedTimer = new BleedTimer(this, defender, bleedingSeconds, damagePerSecond);
                bleedTimer.Start();
            }
        }
        public override void OnThink()
        {
            base.OnThink();

            if (Combatant != null && DateTime.UtcNow > m_NextUptime)
            {
                m_NextUptime = DateTime.UtcNow + TimeSpan.FromSeconds(10);

                if (Utility.RandomDouble() < 0.5)
                {
                    Emote("*voa em círculos*");
                }
            }
        }

        public SnowBat(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        private class BleedTimer : Timer
        {
            private Mobile m_Attacker;
            private Mobile m_Defender;
            private int m_DamagePerSecond;

            public BleedTimer(Mobile attacker, Mobile defender, int duration, int damagePerSecond) : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0), duration)
            {
                m_Attacker = attacker;
                m_Defender = defender;
                m_DamagePerSecond = damagePerSecond;
            }

            protected override void OnTick()
            {
            base.OnTick();
        }
    }
}
}

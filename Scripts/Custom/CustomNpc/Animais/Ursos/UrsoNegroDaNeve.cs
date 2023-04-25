using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace CustomNpc
{
    [CorpseName("Corpo de um Urso Negro da Neve")]
    public class SnowBlackBear : BaseCreature
    {
        private DateTime m_NextUptime;

        [Constructable]
        public SnowBlackBear() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.1, 0.3)
        {
            Name = "Urso Negro da Neve";
            Body = 212;
            Hue = 1109;
            BaseSoundID = 0xA3;

            SetStr(126, 155);
            SetDex(56, 75);
            SetInt(11, 20);

            SetHits(50, 400);
            SetMana(0);

            SetDamage(5, 10);

            SetSkill(SkillName.MagicResist, 30.0, 52.5);
            SetSkill(SkillName.Tactics, 50.0, 72.5);
            SetSkill(SkillName.Wrestling, 50.0, 72.5);

            VirtualArmor = 20;

            Fame = 600;
            Karma = -600;
        }

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
                    Emote("*Rosna*");
                }
            }

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 80.1;
        }
        
        public override bool AlwaysMurderer => true;

        public SnowBlackBear(Serial serial) : base(serial)
        {
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
}}

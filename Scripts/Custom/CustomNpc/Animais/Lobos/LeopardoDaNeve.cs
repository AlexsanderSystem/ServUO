using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace CustomNpc

{
    [CorpseName("Corpo de um Leopardo da Neve")]
    public class SnowLeopard : BaseCreature
    {
        private DateTime m_NextUptime;

        [Constructable]
        public SnowLeopard() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.3)
        {
            Name = "Leopardo da Neve";
            Body = 63;
            Hue = 0;
            BaseSoundID = 0x73;

            SetStr(126, 150);
            SetDex(126, 145);
            SetInt(51, 75);

            SetHits(76, 90);
            SetMana(0);

            SetDamage(10, 20);

            SetSkill(SkillName.MagicResist, 45.0, 67.5);
            SetSkill(SkillName.Tactics, 60.0, 82.5);
            SetSkill(SkillName.Wrestling, 60.0, 82.5);

            VirtualArmor = 25;

            Fame = 1500;
            Karma = -1500;
            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 60.1;
        }
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
                m_NextUptime = DateTime.UtcNow + TimeSpan.FromSeconds(30);

                if (Utility.RandomDouble() < 0.5)
                {
                    Emote("*Rugido*");
                }
            }
        }

        public SnowLeopard(Serial serial) : base(serial)
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
}}

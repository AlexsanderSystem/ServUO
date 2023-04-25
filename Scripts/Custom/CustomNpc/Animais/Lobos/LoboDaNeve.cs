using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("Corpo de um Lobo da Neve")]
    public class SnowWolf : BaseCreature
    {
        private DateTime m_NextUptime;

        [Constructable]
        public SnowWolf() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.15, 0.4)
        {
            Name = "Lobo da Neve";
            Body = 225;
            Hue = 1154;
            BaseSoundID = 0xE5;

            SetStr(76, 100);
            SetDex(56, 75);
            SetInt(11, 25);

            SetHits(46, 60);
            SetMana(0);

            SetDamage(8, 14);

            SetSkill(SkillName.MagicResist, 25.0, 47.5);
            SetSkill(SkillName.Tactics, 45.0, 67.5);
            SetSkill(SkillName.Wrestling, 45.0, 67.5);

            VirtualArmor = 16;

            Fame = 500;
            Karma = -500;
            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 45.1;
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
                m_NextUptime = DateTime.UtcNow + TimeSpan.FromSeconds(10);

                if (Utility.RandomDouble() < 0.5)
                {
                    Emote("*uiva*");
                }
            }
        }

        public SnowWolf(Serial serial) : base(serial)
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

            // Check if the NPC is currently in combat
}
}
}
}
               

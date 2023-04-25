using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corpo de um Bandido")]
    public class LadinoVenom : BaseCreature
    {
        private const int PoisonChance = 25; // Chance de envenenar a vítima

        private static readonly Type[] _LootList =
        {
            typeof(PoisonPotion), typeof(Gold)
        };

        [Constructable]
        public LadinoVenom()
            : base(AIType.AI_Ninja, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SpeechHue = Utility.RandomDyedHue();
            Title = "O Envenenador";
            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
                SetWearable(new Skirt(), Utility.RandomNeutralHue(), dropChance: 1);
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                SetWearable(new ShortPants(), Utility.RandomNeutralHue(), dropChance: 1);
            }

            SetStr(86, 100);
            SetDex(81, 95);
            SetInt(61, 75);

            SetDamage(10, 23);

            SetSkill(SkillName.Fencing, 66.0, 97.5);
            SetSkill(SkillName.Poisoning, 80.0, 100.0);
            SetSkill(SkillName.Tactics, 65.0, 87.5);
            SetSkill(SkillName.Wrestling, 15.0, 37.5);

            Fame = 1000;
            Karma = -10000;

            SetWearable(new Boots(), Utility.RandomNeutralHue(), dropChance: 1);
            SetWearable(new LeatherChest(), dropChance: 1);
            SetWearable(new LeatherGloves(), Utility.RandomNeutralHue(), dropChance: 1);
            SetWearable(new LeatherGorget(), Utility.RandomNeutralHue(), dropChance: 1);
            SetWearable(new Cap(), dropChance: 1);

            SetWearable(new Dagger(), Utility.RandomNeutralHue(), dropChance: 1);
            SetWearable(new Cloak(), Utility.RandomNeutralHue(), dropChance: 1);

            SetWearable((Item)Activator.CreateInstance(Utility.RandomList(_LootList)), dropChance: 1);

            Utility.AssignRandomHair(this);
        }

        public LadinoVenom(Serial serial)
            : base(serial)
        {
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            base.OnDamage(amount, from, willKill);

            if (!willKill && PoisonChance >= Utility.Random(100))
            {
                from.ApplyPoison(this, Poison.Lethal);
                from.SendLocalizedMessage(1049459); // You have been poisoned!
            }
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

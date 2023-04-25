using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Pirata
{
    [CorpseName("Corpo de um Pirata")]
    public class Pirata : BaseCreature
    {
        [Constructable]
        public Pirata() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Pirata";
            Body = 0x190;
            Hue = 0x83EA;
            BaseSoundID = 0x48D;

            SetStr(60);
            SetDex(60);
            SetInt(25);

            SetHits(160);
            SetMana(0);

            SetDamage(15, 20);

            SetSkill(SkillName.Swords, 65);
            SetSkill(SkillName.Tactics, 65);
            SetSkill(SkillName.Parry, 50);

            Fame = 0;
            Karma = -15000;

            VirtualArmor = 10;

            // Give him some clothing
            SetWearable(new Bandana(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Shirt(), dropChance: 1);
			SetWearable(new ShortPants(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Boots(), Utility.RandomNeutralHue(), dropChance: 1);

            Utility.AssignRandomHair(this);

            // Give him a bow and some arrows
            AddItem(new Cutlass());
            //PackItem(new Arrow(20));
            PackItem(new Gold(4, 12));
        }
                public override bool AlwaysMurderer => true;


        public Pirata(Serial serial) : base(serial)
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

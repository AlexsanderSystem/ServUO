using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace PirataParrudo
{
    [CorpseName("Corpo de um Pirata")]
    public class PirataParrudo : BaseCreature
    {
        [Constructable]
        public PirataParrudo() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Pirata Forte";
            Body = 0x190;
            Hue = 0x83EA;
            BaseSoundID = 0x48D;

            SetStr(90);
            SetDex(60);
            SetInt(25);

            SetHits(180);
            SetMana(0);

            SetDamage(15, 20);

            SetSkill(SkillName.Swords, 80);
            SetSkill(SkillName.Tactics, 80);
            SetSkill(SkillName.Parry, 70);

            Fame = 0;
            Karma = -15000;

            VirtualArmor = 10;

            // Give him some clothing
            SetWearable(new SkullCap(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Shirt(), dropChance: 1);
			SetWearable(new ShortPants(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Boots(), Utility.RandomNeutralHue(), dropChance: 1);

            // Give him a bow and some arrows
            AddItem(new Cutlass());
            //PackItem(new Arrow(20));
            PackItem(new Gold(4, 22));
        }

        public override bool AlwaysMurderer => true;



        public PirataParrudo(Serial serial) : base(serial)
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

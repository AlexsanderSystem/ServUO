using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace PirataDeArco
{
    [CorpseName("Corpo de um Pirata")]
    public class PirataDeArco : BaseCreature
    {
        [Constructable]
        public PirataDeArco() : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Pirata de Arco";
            Body = 0x190;
            Hue = 0x83EA;
            BaseSoundID = 0x48D;

            SetStr(60);
            SetDex(60);
            SetInt(25);

            SetHits(160);
            SetMana(0);

            SetDamage(15, 20);

            SetSkill(SkillName.Archery, 65);
            SetSkill(SkillName.Tactics, 65);
            SetSkill(SkillName.MagicResist, 50);

            Fame = 0;
            Karma = -15000;

            VirtualArmor = 10;

            // Give him some clothing
            SetWearable(new Bandana(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Shirt(), dropChance: 1);
			SetWearable(new ShortPants(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Boots(), Utility.RandomNeutralHue(), dropChance: 1);

            // Give him a bow and some arrows
            AddItem(new Bow());
            PackItem(new Arrow(20));
            PackItem(new Gold(4, 12));
        }
        public override bool AlwaysMurderer => true;

        public PirataDeArco(Serial serial) : base(serial)
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

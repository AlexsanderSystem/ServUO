using Server.Items;

namespace Server.Mobiles
{
    public class HirePeasant : BaseHire
    {
        [Constructable]
        public HirePeasant()
        {
            SpeechHue = Utility.RandomDyedHue();
            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");

                switch (Utility.Random(2))
                {
                    case 0:
                        SetWearable(new Skirt(), Utility.RandomNeutralHue(), 1);
                        break;
                    case 1:
						SetWearable(new Kilt(), Utility.RandomNeutralHue(), 1);
                        break;
                }
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
				SetWearable(new ShortPants(), Utility.RandomNeutralHue(), 1);
            }
            Title = "Camponês";
            HairItemID = Race.RandomHair(Female);
            HairHue = Race.RandomHairHue();
            Race.RandomFacialHair(this);

			SetWearable(new Katana(), dropChance: 1);

            SetStr(40, 60);
            SetDex(40, 60);
            SetInt(16, 16);

            SetDamage(10, 15);

            SetSkill(SkillName.Tactics, 20, 30);
            SetSkill(SkillName.Wrestling, 20, 30);
            SetSkill(SkillName.Swords, 20, 30);

            Fame = 1000;
            Karma = 0;

			SetWearable(new Sandals(), Utility.RandomNeutralHue(), 1);
            switch (Utility.Random(2))
            {
                case 0:
					SetWearable(new Doublet(), Utility.RandomNeutralHue(), 1);
                    break;
                case 1:
					SetWearable(new Shirt(), Utility.RandomNeutralHue(), 1);
                    break;
            }

            PackGold(0, 0);
        }

        public HirePeasant(Serial serial)
            : base(serial)
        {
        }

        public override bool ClickTitle => false;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);// version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
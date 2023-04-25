using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Custom.NPCs
{
    [CorpseName("o corpo de um Viking Saqueador")]
    public class VikingSaqueador : BaseCreature
    {
        [Constructable]
        public VikingSaqueador() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
                    Title = "Saqueador";
        SpeechHue = Utility.RandomDyedHue();
        Hue = Utility.RandomSkinHue();
        Body = Female ? 0x191 : 0x190;

        if (Female)
            Name = NameList.RandomName("female");
        else
            Name = NameList.RandomName("male");

            SetStr(150);
            SetDex(75);
            SetInt(25);

            SetHits(800);
            SetMana(0);

            SetDamage(20, 35);

            SetSkill(SkillName.Swords, 90.0, 120.0);
            SetSkill(SkillName.Parry, 100.0, 120.0);
            SetSkill(SkillName.Tactics, 100.0, 120.0);
            SetSkill(SkillName.MagicResist, 60.0, 80.0);

            Item shield = new MetalKiteShield();
            shield.Hue = 0x973;
            shield.Movable = false;
            AddItem(shield);

            Item helmet = new NorseHelm();
            helmet.Hue = 0x973;
            helmet.Movable = false;
            AddItem(helmet);

            Item armor = new RingmailChest();
            armor.Hue = 0x973;
            armor.Movable = false;
            AddItem(armor);

            Item legs = new RingmailLegs();
            legs.Hue = 0x973;
            legs.Movable = false;
            AddItem(legs);

            Item gloves = new RingmailGloves();
            gloves.Hue = 0x973;
            gloves.Movable = false;
            AddItem(gloves);

            Item boots = new Boots();
            boots.Hue = 0x973;
            boots.Movable = false;
            AddItem(boots);

            Item sword = new VikingSword();
            sword.Hue = 0x973;
            sword.Movable = false;
            AddItem(sword);
        }

                public override bool AlwaysMurderer => true;


        public VikingSaqueador(Serial serial) : base(serial)
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
    }
}

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace SnowWolfGiant
{
    [CorpseName("Corpo de um Lobo Gigante")]
    public class SnowWolfGiant : BaseCreature
    {
        [Constructable]
        public SnowWolfGiant() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Lobo Gigante das Neves"; // Define o nome do NPC
            Body = 277; // Define o ID do corpo do NPC (corpo do lobo gigante)
            Hue = 0;
            BaseSoundID = 0xE5; // Define o som do NPC (som de lobo)

            SetStr(226, 255); // Define a força do NPC
            SetDex(141, 160); // Define a destreza do NPC
            SetInt(61, 85); // Define a inteligência do NPC

            SetHits(136, 153); // Define os pontos de vida do NPC
            SetDamage(15, 25); // Define o dano do NPC

            SetSkill(SkillName.MagicResist, 50.0, 75.0); // Define a resistência à magia do NPC
            SetSkill(SkillName.Tactics, 70.0, 85.0); // Define a habilidade tática do NPC
            SetSkill(SkillName.Wrestling, 70.0, 85.0); // Define a habilidade de luta do NPC

            Fame = 5000; // Define a fama do NPC
            Karma = -5000; // Define o karma do NPC

            VirtualArmor = 40; // Define a armadura virtual do NPC

            // Define os itens que o NPC vai deixar cair ao morrer
            PackItem(new ArcticLichen(2)); // Líquen Ártico

            // Define que o NPC é uma criatura de gelo
            ColdDamage = 100;

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 100.0;
        }
        public override bool AlwaysMurderer => true;


        public SnowWolfGiant(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // versão
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class ArcticLichen : Item
    {
        [Constructable]
        public ArcticLichen() : this(1)
        {
        }

        [Constructable]
        public ArcticLichen(int amount) : base(0xF86)
        {
            Name = "Líquen Ártico"; // Define o nome do item
            Hue = 1150; // Define a cor do item (verde claro)

            Stackable = true; // Define se o item pode ser empilhado
            Amount = amount; // Define a quantidade do item

            Weight = 1.0; // Define o peso do item
        }

        public ArcticLichen(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // versão
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace IceSquirrel
{
    [CorpseName("Corpo de um esquilo")]
    public class IceSquirrel : BaseCreature
    {
        [Constructable]
        public IceSquirrel() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Esquilo do Gelo";
            Body = 278; // Define o ID do corpo do NPC (corpo do esquilo)
            Hue = 1153; // Define a cor do NPC (cor do esquilo do gelo)

            SetStr(26, 50); // Define a força do NPC
            SetDex(41, 55); // Define a destreza do NPC
            SetInt(6, 10); // Define a inteligência do NPC

            SetHits(16, 30); // Define os pontos de vida do NPC
            SetDamage(3, 6); // Define o dano do NPC

            SetSkill(SkillName.MagicResist, 5.0, 10.0); // Define a resistência à magia do NPC
            SetSkill(SkillName.Tactics, 20.0, 35.0); // Define a habilidade tática do NPC
            SetSkill(SkillName.Wrestling, 20.0, 35.0); // Define a habilidade de luta do NPC

            Fame = 150; // Define a fama do NPC
            Karma = 0; // Define o karma do NPC

            VirtualArmor = 10; // Define a armadura virtual do NPC

            // Define os itens que o NPC vai deixar cair ao morrer
            PackItem(new Fur()); // Pele de animal
            PackItem(new RawLambLeg()); // Perna de carneiro crua

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 19.1;
        }


        public IceSquirrel(Serial serial) : base(serial)
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

using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
[CorpseName("um corpo de lagarto do gelo")]
public class IceLizard : BaseCreature
{
[Constructable]
public IceLizard() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
{
Name = "Lagarto do Gelo";
Body = 202;
BaseSoundID = 0x5A;
        SetStr(126, 155);
        SetDex(41, 65);
        SetInt(11, 20);

        SetHits(76, 200);
        SetMana(0);

        SetDamage(5, 8);

        SetDamageType(ResistanceType.Physical, 100);

        SetResistance(ResistanceType.Physical, 30, 35);
        SetResistance(ResistanceType.Cold, 60, 80);
        SetResistance(ResistanceType.Poison, 15, 20);

        SetSkill(SkillName.MagicResist, 25.0);
        SetSkill(SkillName.Tactics, 45.0, 57.5);
        SetSkill(SkillName.Wrestling, 45.0, 57.5);

        Fame = 600;
        Karma = -600;

        VirtualArmor = 34;

        Tamable = true;
        ControlSlots = 1;
        MinTameSkill = 57.1;
    }

    public override int Meat{ get{ return 2; } }
    //public override int Hides{ get{ return 14; } }
    //public override HideType HideType{ get{ return HideType.Regular; } }

    //public override void GenerateLoot()
   // {
   //     AddLoot(LootPack.Poor);
    //}

    public override bool BleedImmune{ get{ return true; } }
    //public override bool CanRegenHits{ get{ return true; } }
    //public override bool CanRegenMana{ get{ return false; } }
    //public override bool CanRummageCorpses{ get{ return true; } }
    //public override bool IsScaredOfScaryThings{ get{ return false; } }
    //public override bool BardImmune{ get{ return true; } }

    public override Poison PoisonImmune{ get{ return Poison.Regular; } }

    public IceLizard(Serial serial) : base(serial)
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
}
}
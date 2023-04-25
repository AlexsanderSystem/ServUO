// Created By Erad of AOW

using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of a Dark Magician" )]
              public class Darkmagician : JukaMage
              {
                                 [Constructable]
                                    public Darkmagician() : base()
                            {
                                               Name = "Dark Magician";
                                               Hue = 2183;
                                               SetStr( 80 );
                                               SetDex( 40 );
                                               SetInt( 500 );
                                               SetHits( 15000 );
                                               SetDamage( 20 );
                                               SetDamageType( ResistanceType.Physical, 100 );
                                               SetDamageType( ResistanceType.Cold, 50 );
                                               SetDamageType( ResistanceType.Fire, 15 );
                                               SetDamageType( ResistanceType.Energy, 100 );
                                               SetDamageType( ResistanceType.Poison, 100 );

                                               SetResistance( ResistanceType.Physical, 100 );
                                               SetResistance( ResistanceType.Cold, 59 );
                                               SetResistance( ResistanceType.Fire, 24 );
                                               SetResistance( ResistanceType.Energy, 100 );
                                               SetResistance( ResistanceType.Poison, 100 );
                                               Fame = 5000;
                                               Karma = 25000;
                                               VirtualArmor = 40;

                                               switch (Utility.Random(6))
                                               {
                                                   case 0: AddItem(new Darkmagicianchest()); break;
                                                   case 1: AddItem(new Darkmagicianlegs()); break;
                                                   case 2: AddItem(new Darkmagicianarms()); break;
                                                   case 3: AddItem(new Darkmagiciangloves()); break;
                                                   case 4: AddItem(new Darkmagicianstaff()); break;
                                                   case 5: AddItem(new Darkmagicianhelm()); break;
                                                   //case 6: AddItem( new () ); break;
                                               }
                            }

                                 public override void GenerateLoot()
                                 {
                                     PackGold(50000, 80000);
                                     AddLoot(LootPack.FilthyRich, 2);
                                     AddLoot(LootPack.Gems, Utility.Random(0, 6));

                            }

public Darkmagician( Serial serial ) : base( serial )
                      {
                      }

public override void Serialize( GenericWriter writer )
                      {
                                        base.Serialize( writer );
                                        writer.Write( (int) 0 );
                      }

        public override void Deserialize( GenericReader reader )
                      {
                                        base.Deserialize( reader );
                                        int version = reader.ReadInt();
                      }
    }
}

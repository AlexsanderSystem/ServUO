using Server.Engines.Craft;

namespace Server.Items
{
    public abstract class BaseMiddleTorso : BaseClothing
    {
        public BaseMiddleTorso(int itemID)
            : this(itemID, 0)
        {
        }

        public BaseMiddleTorso(int itemID, int hue)
            : base(itemID, Layer.MiddleTorso, hue)
        {
        }

        public BaseMiddleTorso(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Alterable(typeof(DefTailoring), typeof(GargishSash))]
    [Flipable(0x1541, 0x1542)]
    public class BodySash : BaseMiddleTorso
    {
        public override int BasePhysicalResistance => 0;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;

        [Constructable]
        public BodySash()
            : this(0)
        {
        }

        [Constructable]
        public BodySash(int hue)
            : base(0x1541, hue)
        {
            
            Weight = 4.0;
        }

        public BodySash(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x153d, 0x153e)]
    [Alterable(typeof(DefTailoring), typeof(GargoyleHalfApron))]
    public class FullApron : BaseMiddleTorso
    {
        public override int BasePhysicalResistance => 0;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;

        [Constructable]
        public FullApron()
            : this(0)
        {
        }

        [Constructable]
        public FullApron(int hue)
            : base(0x153d, hue)
        {
            Weight = 7.0;
        }

        public FullApron(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1f7b, 0x1f7c)]
    public class Doublet : BaseMiddleTorso

    
    {
        public override int BasePhysicalResistance => 0;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;

        [Constructable]
        public Doublet()
            : this(0)
        {
        }

        [Constructable]
        public Doublet(int hue)
            : base(0x1F7B, hue)
        {
            Weight = 4.0;
        }

        public Doublet(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1ffd, 0x1ffe)]
    public class Surcoat : BaseMiddleTorso
    {
        public override int BasePhysicalResistance => 1;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;
        [Constructable]
        public Surcoat()
            : this(0)
        {
        }

        [Constructable]
        public Surcoat(int hue)
            : base(0x1FFD, hue)
        {
            Weight = 8.0;
        }

        public Surcoat(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1fa1, 0x1fa2)]
    public class Tunic : BaseMiddleTorso
    {
        public override int BasePhysicalResistance => 2;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;

        [Constructable]
        public Tunic()
            : this(0)
        {
        }

        [Constructable]
        public Tunic(int hue)
            : base(0x1FA1, hue)
        {
            Weight = 10.0;
        }

        public Tunic(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x2310, 0x230F)]
    public class FormalShirt : BaseMiddleTorso //REVISAR
    {
        [Constructable]
        public FormalShirt()
            : this(0)
        {
        }

        [Constructable]
        public FormalShirt(int hue)
            : base(0x2310, hue)
        {
            Weight = 4.0;
        }

        public FormalShirt(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1f9f, 0x1fa0)]
    public class JesterSuit : BaseMiddleTorso
    {
        public override int BasePhysicalResistance => 3;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;

        [Constructable]
        public JesterSuit()
            : this(0)
        {
        }

        [Constructable]
        public JesterSuit(int hue)
            : base(0x1F9F, hue)
        {
            Weight = 8.0;
        }

        public JesterSuit(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x27A1, 0x27EC)]
    public class JinBaori : BaseMiddleTorso
    {
        public override int BasePhysicalResistance => 0;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;

        [Constructable]
        public JinBaori()
            : this(0)
        {
        }

        [Constructable]
        public JinBaori(int hue)
            : base(0x27A1, hue)
        {
            Weight = 5.0;
        }

        public JinBaori(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x46B4, 0x46B5)]
    public class GargishSash : BaseClothing
    {
        [Constructable]
        public GargishSash()
            : this(0)
        {
        }

        [Constructable]
        public GargishSash(int hue)
            : base(0x46B4, Layer.MiddleTorso, hue)
        {
            Weight = 1.0;
        }

        public GargishSash(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}

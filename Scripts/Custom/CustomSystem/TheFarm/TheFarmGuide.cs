namespace Server.Items
{
    public class TheFarmGuide : BlueBook
    {
        public static readonly BookContent Content = new BookContent(
            "The Farm", "Generic Player",
            new BookPageInfo(
                "Welcome to The Farm!",
                "Small Dungeon, 4",
                "spawns of 5",
                "mobs at a time.",
                "PvP is Enabled",
                "Pets are not allowed"),
            new BookPageInfo(
                "Everything auto",
                "Dispels",
                "Bring your friends"),
            new BookPageInfo(
                "Farm Mobs have a 10%",
                "chance of",
                "dropping a Farm",
                "Ticket directly",
                "into your",
                "backpack on death.",
                "Take these tickets",
                "Home to redeem them"),
            new BookPageInfo(
                "For your rewards!"));
        [Constructable]
        public TheFarmGuide()
            : base(false)
        {
			Name = "Guide: The Farm";
			LootType = LootType.Blessed;
        }

        public TheFarmGuide(Serial serial)
            : base(serial)
        {
        }

        public override BookContent DefaultContent => Content;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
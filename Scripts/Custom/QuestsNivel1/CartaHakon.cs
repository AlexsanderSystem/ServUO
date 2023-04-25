namespace Server.Items
{
    public class CartaHakon : BrownBook
    {
        public static readonly BookContent Content = new BookContent(
            "Carta de Recomendação", "Hákon",
            new BookPageInfo(
                "Saudações, nobre aventureiro!",
                "Convidamos você a se juntar a nós",
                "no Clá de Aço",
                "um grupo de militares vikings que"),
            new BookPageInfo(
                "combate feras e monstros ao redor",
                "das vilas. Sua habilidade em batalha",
                "seria uma grande adição à nossa",
                "causa. Junte-se a nós e lute com",
                "honra e bravura. Aguardamos sua",
                "resposta."));
        [Constructable]
        public CartaHakon()
            : base(false)
        {
            Hue = 2210;
        }

        public CartaHakon(Serial serial)
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

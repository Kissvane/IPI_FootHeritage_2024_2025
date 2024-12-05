namespace IPI_FootHeritage_2024_2025_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player olive = new Player("Olive");
            Player marc = new Player("Marc");
            Player bruce = new Defender("Bruce");

            //example
            /*olive.QuiSuisJe();
            bruce.QuiSuisJe();
            ((Defender)bruce).QuiSuisJe();*/

            olive.Dribble(marc);

            olive.Dribble(bruce);
            
            olive.Pass(marc, new List<Player>(){ bruce });
        }
    }
}

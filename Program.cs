using IPI_FootHeritage_2024_2025;

namespace IPI_FootHeritage_2024_2025_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player olive = new Player("Olive");
            Player marc = new Player("Marc");
            Player bruce = new Player("Bruce");
            olive.Pass(marc, new List<Player>(){ bruce });
        }
    }
}

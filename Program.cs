namespace IPI_FootHeritage_2024_2025_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player olive = new MiddleFielder("Olive");
            Player sonic = new Winger("Sonic");
            Player marc = new OffensiveMidfielder("Marc");
            Player bruce = new DefensiveMidFielder("Bruce");
            Player tom = new GoalKeeper("Tom");
            Player machin = new OffensiveMidfielder("Machin");
            //example
            /*olive.QuiSuisJe();
            bruce.QuiSuisJe();
            ((Defender)bruce).QuiSuisJe();*/

            olive.Dribble(marc);

            olive.Dribble(bruce);

            sonic.Pass(machin, null);
            
            marc.Pass(machin, new List<Player>(){bruce});
            marc.Shoot((GoalKeeper)tom, null);
        }
    }
}

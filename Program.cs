﻿namespace IPI_FootHeritage_2024_2025_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player olive = new MiddleFielder("Olive");
            Player marc = new Forward("Marc");
            Player bruce = new Defender("Bruce");
            Player tom = new GoalKeeper("Tom");
            Player machin = new OffensiveMidfielder("Machin");
            //example
            /*olive.QuiSuisJe();
            bruce.QuiSuisJe();
            ((Defender)bruce).QuiSuisJe();*/

            olive.Dribble(marc);

            olive.Dribble(bruce);
            
            machin.Pass(marc, new List<Player>(){});

            machin.Shoot((GoalKeeper)tom, null);
        }
    }
}

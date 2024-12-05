using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    public class Defender : Player
    {
        public Defender(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {

        }

        protected override int CalculateTackleScore(Player opponent)
        {
            int result = Strength + Speed + Agility + GetLuck();
            MyLog($"{Name} fait un tacle glissé sur {opponent.Name}. TacleScore {result}");
            return result;
        }

        //example
        /*public new void QuiSuisJe()
        {
            MyLog("Je suis un defenseur.");
        }*/
    }
}

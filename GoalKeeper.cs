using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{

    public class GoalKeeper : Player
    {
        public GoalKeeper(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        public bool TryToStopShoot(int interceptionDifficulty)
        {
            int interceptScore = Agility + (Reflexs * 2) + GetLuck();
            if (interceptScore >= interceptionDifficulty)
            {
                MyLog($"{Name} fait un arret. interceptScore {interceptScore} >= interceptiondifficulty {interceptionDifficulty}");
                return true;
            }
            else
            {
                MyLog($"{Name} rate son interception. interceptScore {interceptScore} < interceptiondifficulty {interceptionDifficulty}");
                return false;
            }
        }
    }
}

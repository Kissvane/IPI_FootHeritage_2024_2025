using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    //il peut faire des passes lobbé => difficulté d'interception +50%
    //score de dribble agilité X2 au lieu d'agilité
    public class Winger : Player, I_ImprovedAction
    {
        public Winger(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        public List<Actions> actions => new List<Actions> { Actions.Pass };

        public double ImprovementBonus => 1.5;
    }
}

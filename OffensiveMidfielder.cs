using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    //il peut faire des passes lobbé => difficulté d'interception +50%
    //opportuniste faire 2 fois get luck dans le score de shoot
    public class OffensiveMidfielder : Player, I_Opportunist, I_AerialPass
    {
        public OffensiveMidfielder(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }
    }
}

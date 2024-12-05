using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    //score d'interception de passe +50%
    //tacle chanceux deux fois luck dans le score de tacle
    public class DefensiveMidFielder : Player, I_ImprovedInterception, I_LuckyTackle
    {
        public DefensiveMidFielder(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }
    }
}

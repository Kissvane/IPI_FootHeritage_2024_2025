using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    //when making a pass reception difficulty base score = 150 instead of 200
    public class MiddleFielder : Player
    {
        public MiddleFielder(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        protected override int CalculateReceptionDifficultyScore()
        {
            int baseScore = base.CalculateReceptionDifficultyScore();
            int modifiedScore = Math.Max(baseScore - 50, 0);
            MyLog($"{Name} fait une passe avec un spin. La difficulté de reception passe de {baseScore} à {modifiedScore}");
            return modifiedScore;
        }
    }
}

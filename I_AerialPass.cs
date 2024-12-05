using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    internal interface I_AerialPass
    {
        public string Name { get; }

        public int ImproveInterceptionDifficulty(int baseScore)
        {
            int result = (int)(baseScore * 1.5);
            MyLog($"{Name} fait une passe lobbé. Difficulté d'interception {baseScore} => {result}");
            return result;
        }

        protected void MyLog(string value);
    }
}

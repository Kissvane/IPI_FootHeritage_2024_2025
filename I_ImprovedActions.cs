using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    public enum Actions
    {
        Pass, Shoot, Intercept, Dribble, Tackle, Reception, Keep
    }

    internal interface I_ImprovedAction
    {
        public string Name { get; }
        public List<Actions> actions { get; }

        public double ImprovementBonus { get; }

        public int ImproveAction(int baseScore, Actions currentAction)
        {
            if (!actions.Contains(currentAction)) 
            {
                return 0;
            }
            int result = (int)(baseScore * ImprovementBonus);
            MyLog($"{Name} est spécialiste de cette action. score {baseScore} => {result}");
            return result;
        }

        protected void MyLog(string value);
    }
}

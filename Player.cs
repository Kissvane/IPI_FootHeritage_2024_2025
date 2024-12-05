using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    public class Player
    {
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public int Agility { get; private set; }
        public int Strength { get; private set; }
        public int Reflexs { get; private set; }
        public int Luck { get; private set; }

        private Random random;

        public Player(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50)
        {
            Name = name;
            Speed = speed;
            Agility = agility;
            Strength = strength;
            Reflexs = reflexs;
            Luck = luck;
            random = new Random(GetSeed());
        }

        /*public virtual void QuiSuisJe()
        {
            MyLog("Je suis un joueur.");
        }*/

        public virtual void Pass(Player target, List<Player> opponents)
        {
            int interceptionDifficulty = CalculateInterceptionDifficultyScore();
            if (this is I_AerialPass aerial)
            {
               interceptionDifficulty = aerial.ImproveInterceptionDifficulty(interceptionDifficulty);
            }
            int receptionDifficulty = CalculateReceptionDifficultyScore();
            MyLog($"{Name} fait une passe a {target.Name}. Precision {interceptionDifficulty} | difficulté de reception {receptionDifficulty}");
            if (TryToIntercept(interceptionDifficulty, opponents))
            {
                return;
            }

            //reception
            target.ReceiptPass(receptionDifficulty);
        }

        protected int CalculateInterceptionDifficultyScore()
        {
            int result = Agility + Reflexs + GetLuck();
            return result;
        }

        protected virtual int CalculateReceptionDifficultyScore()
        {
            return 200 - (Agility + Strength + GetLuck());
        }

        public virtual void ReceiptPass(int receptionDifficulty)
        {
            int reception = Agility + Reflexs + GetLuck();
            ShowReceptionResult(reception, receptionDifficulty);
        }

        protected virtual void ShowReceptionResult(int reception, int receptionDifficulty)
        {
            if (reception > receptionDifficulty)
            {
                MyLog($"{Name} receptionne la passe. Reception {reception} > difficulté de reception {receptionDifficulty}");
            }
            else
            {
                MyLog($"{Name} manque sa réception. Reception {reception} < difficulté de reception {reception}");
            }
        }

        public virtual void MyLog(string value)
        {
            Console.WriteLine(value);
        }

        public bool Intercept(int interceptionDifficulty)
        {
            int interceptScore = Agility + Reflexs + GetLuck();
            if (interceptScore >= interceptionDifficulty)
            {
                MyLog($"{Name} intercepte le ballon. interceptScore {interceptScore} >= interceptiondifficulty {interceptionDifficulty}");
                return true;
            }
            else
            {
                MyLog($"{Name} rate son interception. interceptScore {interceptScore} < interceptiondifficulty {interceptionDifficulty}");
                return false;
            }
        }

        protected int CalculateInterceptionScore()
        {
            int result = Agility + Reflexs + GetLuck();
            if (this is I_ImprovedInterception improved)
            {
               result = improved.ImproveInterception(result);
            }
            return result;
        } 

        public void Shoot(GoalKeeper keeper, List<Player> opponents)
        {
            int shootScore = CalculateShootScore();
            if (this is I_Opportunist)
            {
                int luckBoost = GetLuck();
                MyLog($"{Name} est opportuniste, il surprend le gardien ce qui améliore sa frappe. ShootScore {shootScore} => {shootScore + luckBoost}");
                shootScore += luckBoost;
            }
            MyLog($"{Name} tire. Shootscore {shootScore}");
            if (TryToIntercept(shootScore, opponents))
            {
                return;
            }

            //le gardien essaye d'arrêter le but
            if(keeper != null)
            {
                if (keeper.TryToStopShoot(shootScore))
                {
                    return;
                }
            }

            MyLog($"{Name} marque un but.");
        }

        protected int CalculateShootScore()
        {
            return Strength + Speed + GetLuck();
        }

        public bool TryToIntercept(int shootScore, List<Player> opponents)
        {
            bool interception = false;
            if (opponents != null)
            {
                foreach (Player opponent in opponents)
                {
                    interception = opponent.Intercept(shootScore);
                    if (interception)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Tackle(int dribbleScore, Player opponent)
        {
            int tackleScore = CalculateTackleScore(opponent);
            if (tackleScore >= dribbleScore)
            {
                MyLog($"{Name} récupère le ballon avec son tacle. Tacle score {tackleScore} >= dribble score {dribbleScore}");
            }
            else
            {
                MyLog($"{Name} ne réussi pas son tacle. Tacle score {tackleScore} < dribble score {dribbleScore}");
            }
        }

        protected virtual int CalculateTackleScore(Player opponent)
        {
            int result = Strength + Speed + GetLuck();
            MyLog($"{Name} tacle {opponent.Name}. TacleScore {result}");
            if (this is I_LuckyTackle tackle)
            {
                result += GetLuck();
                MyLog($"{Name} fait un tacle chanceux. TacleScore {result}");
            }
            return result;
        }

        public void Dribble(Player opponent)
        {
            int dribbleScore = Agility + Speed + GetLuck();
            MyLog($"{Name} tente de dribbler {opponent.Name}. DribbleScore {dribbleScore}");
            opponent.Tackle(dribbleScore, this);
        }

        public int GetLuck()
        {
            return random.Next(Luck);
        }

        private int GetSeed()
        {
            int result = 0;
            int index = 1;
            foreach (char c in Name)
            {
                result += ((int)c) * index;
                index++;
            }

            return result;
        }
    }
}

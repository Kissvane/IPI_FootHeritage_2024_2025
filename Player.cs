using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
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

        public void Pass(Player target, List<Player> opponents)
        {
            int interceptionDifficulty = Agility + Reflexs + GetLuck();
            int receptionDifficulty = 200 - (Agility + Strength + GetLuck());
            MyLog($"{Name} fait une passe a {target.Name}. Precision {interceptionDifficulty} | difficulté de reception {receptionDifficulty}");
            if (TryToIntercept(interceptionDifficulty, opponents))
            {
                return;
            }

            //reception
            target.ReceiptPass(result.receptionDifficulty);
        }

        public void ReceiptPass(int receptionDifficulty)
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

        protected virtual void MyLog(string value)
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

        public void Shoot(List<Player> opponents, Goalkeeper goalkeeper)
        {
            int shootScore = Strength + Speed + GetLuck();
            MyLog($"{Name} tire. Shootscore {shootScore}");
            if (TryToIntercept(shootScore, opponents))
            {
                return;
            }

            goalkeeper.StopShoot(shootScore);
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
            int tackleScore = Strength + Speed + GetLuck();
            MyLog($"{Name} tackle {opponent.Name}. TacleScore {tackleScore}");
            if (tackleScore >= dribbleScore)
            {
                MyLog($"{Name} récupère le ballon avec son tacle. Tacle score {tackleScore} >= dribble score {dribbleScore}");
            }
            else
            {
                MyLog($"{Name} ne réussi pas son tacle. Tacle score {tackleScore} < dribble score {dribbleScore}");
            }
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

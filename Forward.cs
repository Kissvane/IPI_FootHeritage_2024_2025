using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025_v2
{
    //Forward divide by 2 reception difficulty when receiving a pass
    //feedback controle orienté
    public class Forward : Player
    {
        public Forward(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        public override void ReceiptPass(int receptionDifficulty)
        {
            int reception = Agility + Reflexs + GetLuck();
            int modifiedReceptionDifficulty = receptionDifficulty / 2;
            MyLog($"{Name} fait un contrôle orienté. La difficulté de réception passe de {receptionDifficulty} à {modifiedReceptionDifficulty}");
            ShowReceptionResult(reception, modifiedReceptionDifficulty);
        }
    }
}

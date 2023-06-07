using System.Collections.Generic;

namespace FirstWebApp.Models
{
    public class TicTacToeModel
    {
        public string playerName { get; set; }
        public string[] boardRandom;
        public TicTacToeModel(string Name)
        {
            playerName = Name;
            Random rnd = new Random();
            boardRandom = new string[9] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            for (int i = 0; i < boardRandom.Length; ++i)
            {
                if (rnd.Next(0, 10) % 2 == 0)
                {
                    boardRandom[rnd.Next(0, 9)] = "O";
                }
                else
                {
                    boardRandom[rnd.Next(0, 9)] = "X";
                }
            }
        }
    }
}

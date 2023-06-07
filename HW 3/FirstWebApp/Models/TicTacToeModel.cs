using System.Collections.Generic;

namespace FirstWebApp.Models
{
    public class TicTacToeModel
    {
        public string firstPlayerName { get; set; }
        public string lastPlayerName { get; set; }
        public string makeMoveName { get; set; }
        public string winnerName { get; set; }
        public string[] boardRandom;
        public TicTacToeModel()
        {
            firstPlayerName = string.Empty;
            lastPlayerName = string.Empty;
            makeMoveName = string.Empty;
            winnerName = string.Empty;
            Random rnd = new Random();
            boardRandom = new string[9] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            //for (int i = 0; i < boardRandom.Length; ++i)
            //{
            //    if (rnd.Next(0, 10) % 2 == 0)
            //    {
            //        boardRandom[rnd.Next(0, 9)] = "O";
            //    }
            //    else
            //    {
            //        boardRandom[rnd.Next(0, 9)] = "X";
            //    }
            //}
        }
    }
}

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
        }
	}
}

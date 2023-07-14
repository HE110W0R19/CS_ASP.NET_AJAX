using FirstWebApp.Models;

namespace FirstWebApp.Database
{
    public static class TicTacToeDatabase
    {
        public static TicTacToeModel boardInfo = new TicTacToeModel();
        public static bool isX = true;
        public static void restart()
        {
            boardInfo = new TicTacToeModel() { firstPlayerName = boardInfo.firstPlayerName, lastPlayerName = boardInfo.lastPlayerName, makeMoveName = boardInfo.firstPlayerName };
        }
    }
}

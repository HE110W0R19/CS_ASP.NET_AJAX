using FirstWebApp.Database;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Database.TicTacToeDatabase.restart();
            return View("Index");
        }

        [HttpPost]
        public IActionResult GamePage
            ([FromForm(Name = "firstName")] string nameForX,
            [FromForm(Name = "lastName")] string nameForO,
            [FromForm(Name = "index")] string index = "-1")
        {
            UpdateDatabaseInfo(nameForX, nameForO, index);

            var freshTicTacToeModel = TicTacToeDatabase.boardInfo;

			if (isWinnerChecker(freshTicTacToeModel.boardRandom) == true)
			{
				return base.View("WinnerPage", freshTicTacToeModel);
			}
            return base.View(freshTicTacToeModel);
        }

        public void UpdateDatabaseInfo(string nameForX, string nameForO, string index)
        {
            Database.TicTacToeDatabase.boardInfo.firstPlayerName = nameForX;
            Database.TicTacToeDatabase.boardInfo.lastPlayerName = nameForO;
            
            int indexInt = Convert.ToInt32(index);
            if (indexInt >= 0 && indexInt <= 8)
            {
                putPoint(indexInt);
            }
        }

        public IActionResult refreshGamePage()
        {
            Database.TicTacToeDatabase.restart();
            return base.View("GamePage", Database.TicTacToeDatabase.boardInfo);
        }

        public void putPoint(int index)
        {
            if (Database.TicTacToeDatabase.isX == true)
            {
                Database.TicTacToeDatabase.boardInfo.boardRandom[index] = "X";
                Database.TicTacToeDatabase.isX = false;
                Database.TicTacToeDatabase.boardInfo.makeMoveName = Database.TicTacToeDatabase.boardInfo.lastPlayerName;
            }
            else
            {
                Database.TicTacToeDatabase.boardInfo.boardRandom[index] = "O";
                Database.TicTacToeDatabase.isX = true;
                Database.TicTacToeDatabase.boardInfo.makeMoveName = Database.TicTacToeDatabase.boardInfo.firstPlayerName;
            }
        }

        public bool isWinnerChecker(string[] ticTactToeBoardModel)
        {
            if (
                ((ticTactToeBoardModel[0] == ticTactToeBoardModel[4]) & (ticTactToeBoardModel[4] == ticTactToeBoardModel[8]) &
                (ticTactToeBoardModel[0] != " " & ticTactToeBoardModel[4] != " " & ticTactToeBoardModel[8] != " ")) ||

                ((ticTactToeBoardModel[2] == ticTactToeBoardModel[4]) & (ticTactToeBoardModel[4] == ticTactToeBoardModel[6]) &
                (ticTactToeBoardModel[2] != " " & ticTactToeBoardModel[4] != " " & ticTactToeBoardModel[6] != " ")) ||

                ((ticTactToeBoardModel[2] == ticTactToeBoardModel[5]) & (ticTactToeBoardModel[5] == ticTactToeBoardModel[8]) &
                (ticTactToeBoardModel[2] != " " & ticTactToeBoardModel[5] != " " & ticTactToeBoardModel[8] != " ")) ||

                ((ticTactToeBoardModel[1] == ticTactToeBoardModel[4]) & (ticTactToeBoardModel[4] == ticTactToeBoardModel[7]) &
                (ticTactToeBoardModel[1] != " " & ticTactToeBoardModel[4] != " " & ticTactToeBoardModel[7] != " ")) ||

                ((ticTactToeBoardModel[0] == ticTactToeBoardModel[3]) & (ticTactToeBoardModel[3] == ticTactToeBoardModel[6]) &
                (ticTactToeBoardModel[0] != " " & ticTactToeBoardModel[3] != " " & ticTactToeBoardModel[6] != " ")) ||

                ((ticTactToeBoardModel[6] == ticTactToeBoardModel[7]) & (ticTactToeBoardModel[7] == ticTactToeBoardModel[8]) &
                (ticTactToeBoardModel[6] != " " & ticTactToeBoardModel[7] != " " & ticTactToeBoardModel[8] != " ")) ||

                ((ticTactToeBoardModel[3] == ticTactToeBoardModel[4]) & (ticTactToeBoardModel[4] == ticTactToeBoardModel[5]) &
                (ticTactToeBoardModel[3] != " " & ticTactToeBoardModel[4] != " " & ticTactToeBoardModel[5] != " ")) ||

                ((ticTactToeBoardModel[0] == ticTactToeBoardModel[1]) & (ticTactToeBoardModel[1] == ticTactToeBoardModel[2]) &
                (ticTactToeBoardModel[0] != " " & ticTactToeBoardModel[1] != " " & ticTactToeBoardModel[2] != " "))
                )
            {
                if (Database.TicTacToeDatabase.isX == false)
                    Database.TicTacToeDatabase.boardInfo.winnerName = Database.TicTacToeDatabase.boardInfo.firstPlayerName;
                else
                    Database.TicTacToeDatabase.boardInfo.winnerName = Database.TicTacToeDatabase.boardInfo.lastPlayerName;

                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
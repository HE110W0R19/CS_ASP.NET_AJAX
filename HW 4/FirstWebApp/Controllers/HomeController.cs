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
            BoardModel.restart();
            return View("Index");
        }

        [HttpPost]
        public IActionResult GamePage
            ([FromForm(Name = "firstName")] string firstName,
            [FromForm(Name = "lastName")] string lastName,
            [FromForm(Name = "index")] string index = "-1")
        {
            int indexInt = Convert.ToInt32(index);

            if (indexInt >= 0 && indexInt <= 8)
            {
                putPoint(indexInt);
                if (isWinnerChecker(BoardModel.boardInfo.boardRandom) == true)
                {
                    return View("WinnerPage", BoardModel.boardInfo);
                }
            }

            BoardModel.boardInfo.firstPlayerName = firstName;
            BoardModel.boardInfo.lastPlayerName = lastName;
            return View(BoardModel.boardInfo);
        }

        public IActionResult refreshGamePage()
        {
            BoardModel.restart();
            return View("GamePage", BoardModel.boardInfo);
        }

        public void putPoint(int index)
        {
            if (BoardModel.isX == true)
            {
                BoardModel.boardInfo.boardRandom[index] = "X";
                BoardModel.isX = false;
                BoardModel.boardInfo.makeMoveName = BoardModel.boardInfo.lastPlayerName;
            }
            else
            {
                BoardModel.boardInfo.boardRandom[index] = "O";
                BoardModel.isX = true;
                BoardModel.boardInfo.makeMoveName = BoardModel.boardInfo.firstPlayerName;
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
                if (BoardModel.isX == false)
                    BoardModel.boardInfo.winnerName = BoardModel.boardInfo.firstPlayerName;
                else
                    BoardModel.boardInfo.winnerName = BoardModel.boardInfo.lastPlayerName;

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
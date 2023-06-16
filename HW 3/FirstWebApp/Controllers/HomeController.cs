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
            staticBoardModel.restart();
            return View("Index");
        }


        [HttpPost]
        public IActionResult GamePage
            ([FromForm(Name = "firstName")] string firstName,
            [FromForm(Name = "lastName")] string lastName,
            [FromForm(Name = "index")] string index = "-1")
        {
            int indexInt = Convert.ToInt32(index);
            switch (indexInt)
            {
                case 0:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 1:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 2:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 3:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 4:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 5:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 6:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 7:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                case 8:
                    putPoint(indexInt);
                    if (isWinnerChecker(staticBoardModel.boardInfo.boardRandom) == true)
                    {
                        return View("WinnerPage", staticBoardModel.boardInfo);
                    }
                    break;
                default:
                    break;
            }
            staticBoardModel.boardInfo.firstPlayerName = firstName;
            staticBoardModel.boardInfo.lastPlayerName = lastName;
            return View(staticBoardModel.boardInfo);
        }

        public IActionResult refreshGamePage()
        {
            staticBoardModel.restart();
            return View("GamePage", staticBoardModel.boardInfo);
        }

        public static void putPoint(int index)
        {
            if (staticBoardModel.isX == true)
            {
                staticBoardModel.boardInfo.boardRandom[index] = "X";
                staticBoardModel.isX = false;
                staticBoardModel.boardInfo.makeMoveName = staticBoardModel.boardInfo.lastPlayerName;
            }
            else
            {
                staticBoardModel.boardInfo.boardRandom[index] = "O";
                staticBoardModel.isX = true;
                staticBoardModel.boardInfo.makeMoveName = staticBoardModel.boardInfo.firstPlayerName;
            }
        }

        public static bool isWinnerChecker(string[] ticTactToeBoardModel)
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
                if (staticBoardModel.isX == false)
                    staticBoardModel.boardInfo.winnerName = staticBoardModel.boardInfo.firstPlayerName;
                else
                    staticBoardModel.boardInfo.winnerName = staticBoardModel.boardInfo.lastPlayerName;

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
using System.Diagnostics;

namespace GameZone.Controllers;
public class HomeController : Controller
{
    private readonly IGamesService _gamesService;
    private readonly ICategoriesService _categoriesService;
    private readonly IDevicesService _devicesService;
    public HomeController(IGamesService gamesService, ICategoriesService categoriesService, IDevicesService devicesService)
    {
        _gamesService = gamesService;
        _categoriesService = categoriesService;
        _devicesService = devicesService;
    }

    public IActionResult Index(string searchTerm = "", int? categoryId=null, int? deviceId = null)
    {
        ViewBag.Categories = _categoriesService.GetSelectList();
        ViewBag.Devices = _devicesService.GetSelectList();
        var games = _gamesService.GetAll(searchTerm,categoryId, deviceId);
        return View(games);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }




    public IActionResult Details(int id)
    {
        var game = _gamesService.GetById(id);

        if (game is null)
            return NotFound();

        return View(game);
    }
}

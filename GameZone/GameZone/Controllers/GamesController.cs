
namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;
		public GamesController(ICategoriesService categoriesService,
            IDevicesService devicesService,
			IGamesService gamesService)
		{
			//_context = context;
			_categoriesService = categoriesService;
			_devicesService = devicesService;
			_gamesService = gamesService;
		}

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                //get the list of category in Db
                //convert category list to SelectListItem
                Categories = _categoriesService.GetCategories(),
                Devices = _devicesService.GetDevices(),

			};
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (! ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetCategories();
                model.Devices =_devicesService.GetDevices();
				return View(model);
			}
            
                //save game in DB
                //save cover to server
                await _gamesService.Create(model);
				return RedirectToAction(nameof(Index));
        }
    }
}

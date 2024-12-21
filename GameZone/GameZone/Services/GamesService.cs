




namespace GameZone.Services
{
	public class GamesService : IGamesService
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;//location od save img
		private readonly string _imagesPath;
		public GamesService(ApplicationDbContext context,
			IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			//{ _webHostEnvironment.WebRootPath }==> wwwroot
			_imagesPath = $"{ _webHostEnvironment.WebRootPath }{FileSettings.ImagesPath}";
		}

		public IEnumerable<Game> GetAll()
		{
			return _context.Games
				.Include(g=> g.category)
				.Include(d=> d.Devices)
				.ThenInclude(d=> d.device)
				.AsNoTracking()
				.ToList();
		}
		public async Task Create(CreateGameFormViewModel model)
		{
			// save cover in server
			// Unique value and Extension 
			var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";//img.png
			//the location to save cover ==> _imagesPath
			//the Name of  cover ==> coverName
			var path = Path.Combine(_imagesPath , coverName);
			//copy into path
			 var stream = File.Create(path);
			await model.Cover.CopyToAsync(stream);
			/*stream.Dispose();*///save cover to server self

			//save game in db
			Game game = new()
			{
				Name = model.Name,
				Description = model.Description,
				CategoryId = model.CategoryId,
				Cover = coverName,
				Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
			};
			_context.Add(game);
			_context.SaveChanges();

		}

		
	}
}

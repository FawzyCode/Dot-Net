

using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }//one Category to show for user
										   //get the list of Categories from DB
		
		public IEnumerable<SelectListItem> Categories {  get; set; }= Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;//list from devices to show for user
        //get the list of Devices from DB
        public IEnumerable<SelectListItem> Devices { get; set; }=Enumerable.Empty<SelectListItem>();
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        //Validate Extension and Size 
        [AllowedExtensions(FileSettings.AllowedExtension) ,
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}

namespace GameZone.Attributes
{
	public class AllowedExtensionsAttribute :ValidationAttribute
	{
		private readonly string _allowedExtensions;
        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile; //convert value from obj to IFormFile
			if (file is not null)
			{
				var extension = Path.GetExtension(file.FileName); //file extension that return form
		        var isAllowed = _allowedExtensions.Split(',')
					.Contains(extension,StringComparer.OrdinalIgnoreCase);

				if (!isAllowed)
				{
					return new ValidationResult($"Only{_allowedExtensions} are allowed !");
				}
			}
			return ValidationResult.Success;
		}
	}
}

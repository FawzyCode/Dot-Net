namespace MVC_ITI.Models
{
	public class ProductBL
	{
		List<Product> products;
        public ProductBL()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1 , Name = "shepsi" ,Salary = 10 ,ImageURL ="shepsi.jpg" });
			products.Add(new Product() { Id = 2, Name = "Pepsi",  Salary  = 15, ImageURL = "pepsi.jpg" });
			products.Add(new Product() { Id = 3, Name = "Basqawet", Salary = 5, ImageURL = "basqawet.jpg" });
			products.Add(new Product() { Id = 4, Name = "cheese", Salary = 50, ImageURL = "cheese.jpg" });
			
		}
		public List<Product> GetAll()
		{
			return products;
		}

		public Product GetById(int id)
		{
			return products.FirstOrDefault(I=> I.Id==id);
		}
    }
}

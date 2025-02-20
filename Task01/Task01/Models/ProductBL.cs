namespace Task01.Models
{
    public class ProductBL
    {
        public List<Product> Products;
        public ProductBL()
        {
            Products = new List<Product>();
            Products.Add(new Product() { Id = 1, Name = "Chesse", Price = 140, Description = "Normal", ImageUrl = "1.png" });
            Products.Add(new Product() { Id = 2, Name = "Tea250gm", Price = 80, Description = "High", ImageUrl = "2.png" });
            Products.Add(new Product() { Id = 3, Name = "Water Bottle", Price = 10, Description = "Normal", ImageUrl = "3.png" });
            Products.Add(new Product() { Id = 4, Name = "Yogurt 100 gm", Price = 15, Description = "Normal", ImageUrl = "4.png" });
            Products.Add(new Product() { Id = 5, Name = "Coffee 100 gm", Price = 80, Description = "High", ImageUrl = "5.png" });

        }

        public List<Product> GetAll()
        {
            return Products;
        }
        public Product GetById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
    }
}

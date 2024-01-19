namespace TestAPI.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private List<Product> list;

        public ProductRepository()
        {
            list = new List<Product>
            {
                new Product { Id = 1,Name="Pen",Price=15.99},
                new Product { Id = 2,Name="Eraser",Price=5.99},
                new Product { Id = 3,Name="Pencil",Price=9.99},
                new Product { Id = 4,Name="Wireless Mouse",Price=499.55},
                new Product { Id = 5,Name="External HDD",Price=4859.55}
            };
        }
        public Product Add(Product product)
        {
            var id = list.Max(x => x.Id) + 1;
            product.Id = id;
            list.Add(product);
            return product;
        }

        public Product Delete(int id)
        {
            var p = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(p);
            return p;
        }

        public Product Get(int id)
        {
            return list.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return list;
        }

        public Product Update(Product product)
        {
            var p = list.Where(x => x.Id == product.Id).FirstOrDefault();

            p.Name = product.Name;
            p.Price = product.Price;

            return p;
        }
    }
}

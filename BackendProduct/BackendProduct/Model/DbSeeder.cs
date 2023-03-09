namespace BackendProduct.Model
{
    public static class DbSeeder
    {
        public static void DoSeeding(AppDbContext? dbContext)
        {
            SeedProducts(dbContext);
        }

        private static void SeedProducts(AppDbContext? dbContext)
        {
            if (!dbContext!.Products.Any())
            {
                var products = new Product[]
                {
                    new Product()
                    {
                        Id = 1,
                        Name = "Banana",
                        Description = "Banana amarilla",
                        Price = 10.0m,
                        StockCount = 1000
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Mango",
                        Description = "Mango rojo",
                        Price = 15.0m,
                        StockCount = 2000
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Manzana",
                        Description = "Manzana verde",
                        Price = 20.0m,
                        StockCount = 3000
                    },
                    new Product()
                    {
                        Id = 4,
                        Name = "Lima",
                        Description = "Lima verde",
                        Price = 12.0m,
                        StockCount = 800
                    },
                    new Product()
                    {
                        Id = 5,
                        Name = "Sandia",
                        Description = "Sandia grande",
                        Price = 100.35m,
                        StockCount = 1000
                    }
                };
                foreach (Product product in products)
                {
                    dbContext.Products.Add(product);
                }
                dbContext?.SaveChanges();
            }
        }
    }
}
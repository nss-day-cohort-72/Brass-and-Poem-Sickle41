
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product>()
        {
            new Product() { Name = "Trumpet", Price = 789.98m, ProductTypeId = 1 },
            new Product() { Name = "Tuba", Price = 1288.98m, ProductTypeId = 1 },
            new Product() { Name = "Trombone", Price = 1111.99m, ProductTypeId = 1 },
            new Product() { Name = "Poet Poet", Price = 29.99m, ProductTypeId = 2 },
            new Product() { Name = "100 Poems That Will Make You Cry", Price = 19.99m, ProductTypeId = 2 }
        };


//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
        {
            new ProductType() { Title = "brass", Id = 1 },
            new ProductType() { Title = "poem", Id = 2 }
        };

//put your greeting here

Console.Write("Welcome to the Brass & Poem shop!");

//implement your loop here

bool running = true;
while (running)
{
    DisplayMenu();

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;
        case "2":
            DeleteProduct(products, productTypes);
            break;
        case "3":
            AddProduct(products, productTypes);
            break;
        case "4":
            UpdateProduct(products, productTypes);
            break;
        case "5":
            running = false;
            Console.WriteLine("Thank you for visiting Brass and Poem!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

void DisplayMenu()
{
     Console.WriteLine("\n1. Display all products");
            Console.WriteLine("2. Delete a product");
            Console.WriteLine("3. Add a new product");
            Console.WriteLine("4. Update product properties");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
   foreach (var product in products)
            {
                var productType = productTypes.First(pt => pt.Id == product.ProductTypeId);
                Console.WriteLine($"{product.Name} - ${product.Price} ({productType.Title})");
            }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
            Console.Write("Enter the name of the product to delete: ");
            string name = Console.ReadLine();

            var productToRemove = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Product deleted.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.Write("Enter the name of the new product: ");
            string name = Console.ReadLine();

            Console.Write("Enter the price of the new product: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Choose a product type: ");
                for (int i = 0; i < productTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
                }

                Console.Write("Enter the product type number: ");
                if (int.TryParse(Console.ReadLine(), out int productTypeId) && productTypeId > 0 && productTypeId <= productTypes.Count)
                {
                    products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
                    Console.WriteLine("Product added.");
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid price.");
            }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
     DisplayAllProducts(products, productTypes);
            Console.Write("Enter the name of the product to update: ");
            string name = Console.ReadLine();

            var productToUpdate = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToUpdate != null)
            {
                Console.Write($"Enter new name for {productToUpdate.Name} (or press Enter to keep unchanged): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    productToUpdate.Name = newName;
                }

                Console.Write($"Enter new price for {productToUpdate.Price} (or press Enter to keep unchanged): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                {
                    productToUpdate.Price = newPrice;
                }

                Console.WriteLine("Choose a new product type: ");
                for (int i = 0; i < productTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
                }

                Console.Write("Enter the product type number: ");
                if (int.TryParse(Console.ReadLine(), out int newProductTypeId) && newProductTypeId > 0 && newProductTypeId <= productTypes.Count)
                {
                    productToUpdate.ProductTypeId = newProductTypeId;
                    Console.WriteLine("Product updated.");
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }
}

// don't move or change this!
public partial class Program { }

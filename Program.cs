using ExerciciosTooC_.ExPost;
using ExerciciosTooC_.ExProduct;
using System;
using System.Collections.Generic;

namespace ExerciciosTooC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExProduct();
            ExPost();
        }

        static void ExPost()
        {
            Post post1 = new Post("Traveling to New Zealand", "I'm going to visit this wonderful country!", DateTime.Now);

            post1.AddComment(new Comment("Have a nice trip"));
            post1.AddComment(new Comment("Wow that's awesome!"));
            post1.AddComment(new Comment("Good luck!"));

            post1.Like();
            post1.Like();
            post1.Like();
            post1.Like();

            Console.WriteLine(post1);
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Post post2 = new Post("Good night guys", "See you tomorrow", DateTime.Now);
            post2.AddComment(new Comment("Good night"));
            post2.AddComment(new Comment("May the Force be with you"));
            post2.Like();
            post2.Like();

            Console.WriteLine(post2);

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();

        }
        static void ExProduct()
        {
            ProductList list = new ProductList();

            // example products

            List<string> categories = new List<string>
            {
                "Bebidas",
                "Alcoólicas"
            };

            list.AddProduct(new Product("Vinho", 35.99, "Vinho tinto", categories));
            list.AddProduct(new Product("Cerveja", 5.99, "Cerveja pilsen", categories));
            list.AddProduct(new Product("Cachaça", 15.99, "Cachaça artesanal", categories));

            categories.Remove("Alcoólicas");
            categories.Add("Refrigerantes");

            list.AddProduct(new Product("Coca-Cola", 4.99, "Refrigerante de cola", categories));
            list.AddProduct(new Product("Guaraná", 4.99, "Refrigerante de guaraná", categories));
            list.AddProduct(new Product("Fanta", 4.99, "Refrigerante de laranja", categories));
            list.AddProduct(new Product("Pepsi", 4.99, "Refrigerante de cola", categories));

            categories.Clear();
            categories.Add("Alimentos");
            categories.Add("Carnes");

            list.AddProduct(new Product("Carne", 34.99, "Coxao duro", categories));
            list.AddProduct(new Product("Frango", 24.99, "Peito de frango", categories));
            list.AddProduct(new Product("Peixe", 29.99, "Peixe fresco", categories));

            categories.Remove("Carnes");
            categories.Add("Massas");

            list.AddProduct(new Product("Macarrão", 4.99, "Macarrão espaguete", categories));

            categories.Remove("Massas");
            categories.Add("Grãos");

            list.AddProduct(new Product("Arroz", 4.99, "Arroz branco", categories));
            list.AddProduct(new Product("Feijão", 4.99, "Feijão carioca", categories));

            foreach (Product product in list.PList)
            {
                product.AddQuantity(100);
            }

            list.ConsoleMenu();
        }
    }
}

using System.Collections.Generic;

namespace ExerciciosTooC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            // example products

            List<string> categories = new List<string>
            {
                "Bebidas",
                "Alcoólicas"
            };

            list.Add(new Product("Vinho", 35.99, "Vinho tinto", categories));
            list.Add(new Product("Cerveja", 5.99, "Cerveja pilsen", categories));
            list.Add(new Product("Cachaça", 15.99, "Cachaça artesanal", categories));

            categories.Remove("Alcoólicas");
            categories.Add("Refrigerantes");

            list.Add(new Product("Coca-Cola", 4.99, "Refrigerante de cola", categories));
            list.Add(new Product("Guaraná", 4.99, "Refrigerante de guaraná", categories));
            list.Add(new Product("Fanta", 4.99, "Refrigerante de laranja", categories));
            list.Add(new Product("Pepsi", 4.99, "Refrigerante de cola", categories));

            categories.Clear();
            categories.Add("Alimentos");
            categories.Add("Carnes");

            list.Add(new Product("Carne", 34.99, "Coxao duro", categories));
            list.Add(new Product("Frango", 24.99, "Peito de frango", categories));
            list.Add(new Product("Peixe", 29.99, "Peixe fresco", categories));

            categories.Remove("Carnes");
            categories.Add("Massas");

            list.Add(new Product("Macarrão", 4.99, "Macarrão espaguete", categories));

            categories.Remove("Massas");
            categories.Add("Grãos");

            list.Add(new Product("Arroz", 4.99, "Arroz branco", categories));
            list.Add(new Product("Feijão", 4.99, "Feijão carioca", categories));

            foreach (Product product in list)
            {
                product.AddQuantity(100);
            }

            ProductList productList = new ProductList(list);

            productList.ConsoleMenu();
        }


    }
}

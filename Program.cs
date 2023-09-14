using System;
using System.Collections.Generic;

namespace ExerciciosTooC_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> listProducts = new List<Product>();

            // example products

            List<string> categories = new List<string>
            {
                "Bebidas",
                "Alcoólicas"
            };

            listProducts.Add(new Product("Vinho", 35.99, "Vinho tinto", categories));
            listProducts.Add(new Product("Cerveja", 5.99, "Cerveja pilsen", categories));
            listProducts.Add(new Product("Cachaça", 15.99, "Cachaça artesanal", categories));

            categories.Remove("Alcoólicas");
            categories.Add("Refrigerantes");

            listProducts.Add(new Product("Coca-Cola", 4.99, "Refrigerante de cola", categories));
            listProducts.Add(new Product("Guaraná", 4.99, "Refrigerante de guaraná", categories));
            listProducts.Add(new Product("Fanta", 4.99, "Refrigerante de laranja", categories));
            listProducts.Add(new Product("Pepsi", 4.99, "Refrigerante de cola", categories));

            categories.Clear();
            categories.Add("Alimentos");
            categories.Add("Carnes");

            listProducts.Add(new Product("Carne", 34.99, "Coxao duro", categories));
            listProducts.Add(new Product("Frango", 24.99, "Peito de frango", categories));
            listProducts.Add(new Product("Peixe", 29.99, "Peixe fresco", categories));

            categories.Remove("Carnes");
            categories.Add("Massas");

            listProducts.Add(new Product("Macarrão", 4.99, "Macarrão espaguete", categories));

            categories.Remove("Massas");
            categories.Add("Grãos");

            listProducts.Add(new Product("Arroz", 4.99, "Arroz branco", categories));
            listProducts.Add(new Product("Feijão", 4.99, "Feijão carioca", categories));

            int option;
            do
            {
                Console.Clear();

                Console.WriteLine("Menu:\n0- Sair\n1- Criar Produto\n2- Deletar Produto por ID\n3- Mostrar um Produto\n4- Mostrar Todos os Produtos");
                Console.WriteLine("5- Acessar um Produto\n");
                Console.WriteLine("Escolha:");


                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        AddProduct(listProducts);
                        break;

                    case 2:

                        DeleteProduct(listProducts);
                        break;

                    case 3:

                        ShowProduct(listProducts);
                        break;

                    case 4:
                        ShowAllProducts(listProducts);
                        break;

                    case 5:
                        Product product = AcessProduct(listProducts);
                        ManipuleAProduct(product);
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        AwaitEnter();
                        break;

                }
            } while (option != 0);
        }

        static void AwaitEnter()
        {
            Console.WriteLine("\nAperte Enter para continuar...");
            Console.ReadLine();
        }
        static void AddProduct(List<Product> listProducts)
        {
            Console.WriteLine("Nome:");
            string name = Console.ReadLine();
            Console.WriteLine("Preço:");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Descrição:");
            string description = Console.ReadLine();
            Console.WriteLine("Categoria:");
            int option;
            List<string> category = new List<string>();

            do
            {
                Console.WriteLine("0- Sair\n1- Adicionar Categoria\n2- Remover Categoria\nEscolha:");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite a categoria a ser adicionada:");
                        string categoryToAdd = Console.ReadLine();
                        category.Add(categoryToAdd);
                        break;

                    case 2:
                        Console.WriteLine("Digite a categoria a ser removida:");
                        string categoryToRemove = Console.ReadLine();
                        category.Remove(categoryToRemove);
                        break;
                }
            } while (option != 0);

            listProducts.Add(new Product(name, price, description, category));

            Console.WriteLine("\nProduto adicionado com sucesso!");

            AwaitEnter();
        }

        static void DeleteProduct(List<Product> listProducts)
        {
            Console.WriteLine("Digite o Id do Produto a ser deletado:");
            int id = int.Parse(Console.ReadLine());
            Product product = listProducts.Find(productToFind => productToFind.Id == id);

            if (product != null)
            {
                listProducts.Remove(product);
                Console.WriteLine("\nProduto deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado!");
            }

            AwaitEnter();
        }

        static void ShowProduct(List<Product> listProducts)
        {
            Console.WriteLine("Digite o Nome do Produto a ser mostrado:");
            string name = Console.ReadLine();
            Product product = listProducts.Find(productToFind => productToFind.Name.ToLower() == name.ToLower());

            if (product != null)
            {
                Console.WriteLine($"\n{product}\n");
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado!");
            }

            AwaitEnter();
        }

        static void ShowAllProducts(List<Product> listProducts)
        {

            Console.WriteLine("Digite o tipo de impressão:\n1- Completa\n2- Apenas Nome e Id\nEscolha:");
            int type = int.Parse(Console.ReadLine());

            if (type == 1)
            {
                foreach (Product productToPrint in listProducts)
                {
                    Console.WriteLine($"\n{productToPrint}\n");
                }
            }
            else if (type == 2)
            {
                foreach (Product productToPrint in listProducts)
                {
                    Console.WriteLine($"\nId: {productToPrint.Id}\nNome: {productToPrint.Name}\n");
                }
            }
            else
            {
                Console.WriteLine("\nTipo de impressão inválido!");
            }

            AwaitEnter();
        }

        static Product AcessProduct(List<Product> listProducts)
        {

            Console.WriteLine("Digite o Id do Produto a ser acessado:");
            int id = int.Parse(Console.ReadLine());
            Product product = listProducts.Find(productToFind => productToFind.Id == id);

            if (product != null)
            {
                return product;
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado!");
                return null;
            }
        }

        static void ManipuleAProduct(Product product)
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("Produto:");
                Console.WriteLine();
                Console.WriteLine(product);
                Console.WriteLine();
                Console.WriteLine("Digite o que deseja fazer:\n0- Sair\n1- Adicionar Quantidade\n2- Remover Quantidade\n3- Adicionar Categoria\n4- Remover Categoria");
                Console.WriteLine("5- Alterar Preco\n6- Alterar Descicao");
                Console.WriteLine("Escolha:");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite a quantidade a ser adicionada:");
                        int quantityToAdd = int.Parse(Console.ReadLine());
                        product.AddQuantity(quantityToAdd);
                        Console.WriteLine("\nQuantidade adicionada com sucesso!");
                        break;

                    case 2:
                        Console.WriteLine("Digite a quantidade a ser removida:");
                        int quantityToRemove = int.Parse(Console.ReadLine());
                        product.RemoveQuantity(quantityToRemove);
                        Console.WriteLine("\nQuantidade removida com sucesso!");
                        break;

                    case 3:
                        Console.WriteLine("Digite a categoria a ser adicionada:");
                        string categoryToAdd = Console.ReadLine();
                        product.AddCategory(categoryToAdd);
                        Console.WriteLine("\nCategoria adicionada com sucesso!");
                        break;

                    case 4:
                        Console.WriteLine("Digite a categoria a ser removida:");
                        string categoryToRemove = Console.ReadLine();
                        product.RemoveCategory(categoryToRemove);
                        Console.WriteLine("\nCategoria removida com sucesso!");
                        break;

                    case 5:
                        Console.WriteLine("Digite o novo preço:");
                        double price = double.Parse(Console.ReadLine());
                        product.Price = price;
                        Console.WriteLine("\nPreço alterado com sucesso!");
                        break;

                    case 6:
                        Console.WriteLine("Digite a nova descrição:");
                        string description = Console.ReadLine();
                        product.Description = description;
                        Console.WriteLine("\nDescrição alterada com sucesso!");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }
            } while (option != 0);

        }
    }
}

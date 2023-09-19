using System;
using System.Collections.Generic;

namespace ExerciciosTooC_.ExProduct
{
    internal class ProductList
    {
        public List<Product> PList { get; private set; }
        public ProductList()
        {
            PList = new List<Product>();
        }
        private void AwaitEnter()
        {
            Console.WriteLine("\nAperte Enter para continuar...");
            Console.ReadLine();
        }

        public void ConsoleMenu()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Menu:\n0- Sair\n1- Criar Produto\n2- Deletar Produto por ID\n3- Mostrar um Produto\n4- Mostrar Todos os Produtos");
                Console.WriteLine("5- Acessar um Produto\n");
                Console.WriteLine("Escolha:");


                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        AddProduct();
                        break;

                    case 2:

                        DeleteProduct();
                        break;

                    case 3:

                        ShowProduct();
                        break;

                    case 4:
                        ShowAllProducts();
                        break;

                    case 5:
                        ManipuleAProductWithConsole(AcessProduct());
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Console.WriteLine("\nAperte Enter para continuar...");
                        Console.ReadLine();
                        break;

                }
            } while (option != 0);
        }

        public void AddProduct(Product product)
        {
            PList.Add(product);
            Console.WriteLine("\nProduto adicionado com sucesso!");
            AwaitEnter();
        }
        public void AddProduct()
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
                Console.Clear();
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

            AddProduct(new Product(name, price, description, category));
        }

        public void DeleteProduct(int id)
        {
            Product product = PList.Find(productToFind => productToFind.Id == id);

            if (product != null)
            {
                PList.Remove(product);
                Console.WriteLine("\nProduto deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado!");
            }
            AwaitEnter();
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Digite o Id do Produto a ser deletado:");
            int id = int.Parse(Console.ReadLine());
            DeleteProduct(id);
        }

        public void ShowProduct(string name)
        {
            Product product = PList.Find(productToFind => productToFind.Name.ToLower() == name.ToLower());

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

        public void ShowProduct()
        {
            Console.WriteLine("Digite o Nome do Produto a ser mostrado:");
            string name = Console.ReadLine();
            ShowProduct(name);
        }

        public void ShowAllProducts(int type)
        {
            if (type == 1)
            {
                foreach (Product productToPrint in PList)
                {
                    Console.WriteLine($"\n{productToPrint}\n");
                }
            }
            else if (type == 2)
            {
                foreach (Product productToPrint in PList)
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

        public void ShowAllProducts()
        {

            Console.WriteLine("Digite o tipo de impressão:\n1- Completa\n2- Apenas Nome e Id\nEscolha:");
            int type = int.Parse(Console.ReadLine());
            ShowAllProducts(type);
        }

        public Product AcessProduct(int id)
        {
            Product product = PList.Find(productToFind => productToFind.Id == id);

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

        public Product AcessProduct()
        {
            Console.WriteLine("Digite o Id do Produto a ser acessado:");
            int id = int.Parse(Console.ReadLine());
            return AcessProduct(id);
        }

        public void ManipuleAProductWithConsole(Product product)
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

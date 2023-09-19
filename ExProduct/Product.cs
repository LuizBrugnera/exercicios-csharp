using System.Collections.Generic;

namespace ExerciciosTooC_.ExProduct
{
    internal class Product
    {
        private static int IdCounter = 0;
        private List<string> categories { get; set; } = new List<string>();
        private int Quantity { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Id { get; }

        public List<string> Categories
        {
            get { return categories; }
        }

        public Product(string name, double price, string description)
        {
            Id = IdCounter;
            IdCounter++;

            Name = name;
            Price = price;
            Description = description;
        }

        public Product(string name, double price, string description, int quantity) : this(name, price, description)
        {
            Quantity = quantity;
        }

        public Product(string name, double price, string description, List<string> categories) : this(name, price, description)
        {
            foreach (string category in categories)
            {
                Categories.Add(category);
            }
        }

        public Product(string name, double price, string description, int quantity, List<string> categories) : this(name, price, description, quantity)
        {
            foreach (string category in categories)
            {
                Categories.Add(category);
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}\nNome: {Name}\nPreco: $ {Price}\nDescricao: {Description}\nCategoria: {CategoriesToString()}\nQuantidade: {Quantity}\nValor Total em Estoque: $ {GetTotalPrice()}";
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (Quantity >= quantity)
            {
                Quantity -= quantity;
            }
        }

        public void AddCategory(string category)
        {
            Categories.Add(category);
        }

        public void RemoveCategory(string category)
        {
            Categories.Remove(category);
        }

        public string CategoriesToString()
        {
            string categoriesString = "";
            foreach (string category in Categories)
            {
                categoriesString += $"{category}, ";
            }
            return categoriesString;
        }
        public long GetTotalPrice()
        {
            long total = (long)(Price * Quantity);
            return total;
        }

        public bool IsAvailable()
        {
            return Quantity > 0;
        }

        public bool IsAvailable(int quantity)
        {
            return Quantity >= quantity;
        }

        public bool IsAvailable(double price)
        {
            return Price <= price;
        }
    }
}

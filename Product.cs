using System.Collections.Generic;

namespace ExerciciosTooC_
{
    internal class Product
    {
        private static int IdCounter = 0;
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        private List<string> categories { get; set; } = new List<string>();
        public List<string> Categories
        {
            get { return categories; }
            set
            {
                categories.Clear();
                foreach (string category in value)
                {
                    categories.Add(category);
                }
            }
        }

        private int Quantity { get; set; }
        public int Id { get; }

        public Product(string name, double price, string description, List<string> categories)
        {
            Id = IdCounter;
            IdCounter++;

            Name = name;
            Price = price;
            Description = description;
            Quantity = 0;

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
        public double GetTotalPrice()
        {
            return Price * Quantity;
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

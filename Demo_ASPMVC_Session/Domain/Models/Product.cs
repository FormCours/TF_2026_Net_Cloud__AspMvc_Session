namespace Demo_ASPMVC_Session.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public decimal Price { get; set; }
        public string Ean13 { get; set; }

        public Product(string name, string? desc, decimal price, string ean13)  
        {
            if(name.Length < 3 || price < 0 || ean13.Length != 13)
            {
                throw new ArgumentException("Boum");
            }

            this.Id = 0;
            this.Name = name;
            this.Desc = desc; 
            this.Price = price; 
            this.Ean13 = ean13;
        }

        public Product(int id, string name, string? desc, decimal price, string ean13)
            : this(name, desc, price, ean13)
        {
            this.Id = id;
        }
    }
}

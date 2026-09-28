using Demo_ASPMVC_Session.Domain.Models;

namespace Demo_ASPMVC_Session.Domain.Services
{
    public class ProductService
    {
        #region FakeData
        private static List<Product> _products = [
            new Product(1, "Cafetière Filtre", "Machine à café 12 tasses avec programmation", 49.99m, "3600524021752"),
            new Product(2, "Bouilloire Électrique", "Capacité 1.7L en acier inoxydable", 29.95m, "3600524021769"),
            new Product(3, "Grille-Pain", "2 fentes larges avec fonction décongélation", 34.90m, "3600524021776"),
            new Product(4, "Mug en Céramique", null, 8.50m, "3600524021783"),
            new Product(5, "Set de 3 Poêles", "Revêtement antiadhésif, compatibles induction", 79.99m, "3600524021790"),
            new Product(6, "Couteau de Chef", "Lame en acier de 20cm", 24.50m, "3600524021806"),
            new Product(7, "Planche à Découper", "En bois de bambou naturel", 15.00m, "3600524021813"),
            new Product(8, "Balance de Cuisine", null, 12.99m, "3600524021820"),
            new Product(9, "Minuteur Électronique", "Affichage LCD et alarme sonore", 7.00m, "3600524021837"),
            new Product(10, "Dessous de Plat", null, 5.50m, "3600524021844")
        ];
        private static int _nextProductId = 11;
        #endregion

        #region CRUD
        public Product Create(Product data)
        {
            Product productToAdd = new Product(
                  _nextProductId++,
                  data.Name,
                  data.Desc, 
                  data.Price, 
                  data.Ean13
            );

            _products.Add(productToAdd);
            return productToAdd;
        }

        public void Update(int id, Product data)
        {
            Product productToUpdate = _products.Single(p => p.Id == id);

            productToUpdate.Name = data.Name;
            productToUpdate.Desc = data.Desc;
            productToUpdate.Price = data.Price;
            productToUpdate.Ean13 = data.Ean13;
        }

        public void Delete(int id)
        {
            Product productToRemove = _products.Single(p => p.Id == id);
            _products.Remove(productToRemove);
        }

        public Product GetById(int id)
        {
            Product p = _products.Single(p => p.Id == id);
            return new Product(p.Id, p.Name, p.Desc, p.Price, p.Ean13);
        }

        public IEnumerable<Product> GetAll()
        {
            // TODO Cas réel → Ajouter de la pagination (exemple : offset/limit)

            return _products.Select((p) =>
            {
                return new Product(p.Id, p.Name, p.Desc, p.Price, p.Ean13);
            });
        } 
        #endregion
    }
}

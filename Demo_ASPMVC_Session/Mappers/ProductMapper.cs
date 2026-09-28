using Demo_ASPMVC_Session.Domain.Models;
using Demo_ASPMVC_Session.Models;

namespace Demo_ASPMVC_Session.Mappers
{
    public static class ProductMapper
    {

        public static Product ToProduct(this ProductFormModel model)
        {
            return new Product(
                model.Name.Trim(),
                !string.IsNullOrWhiteSpace(model.Desc) ? model.Desc.Trim() : null,
                model.Price, 
                model.Ean13
            );
        }
    }
}

using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class OrderComposition : DomainObject
    {
        //От заказов id заказа - fk заказа
        //От Каталоги продукции id продукта - fk товара
        public Batch Batch { get; set; }
        public Order Order { get; set; }
    }
}

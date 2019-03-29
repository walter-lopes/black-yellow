using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.CustomerManagementAPI.Domain
{
    public class Cart
    {
        private ISet<CartItem> _items; 
        public Guid Id { get; private set; }

        public DateTime CreatAt { get; private set; }

        public IEnumerable<CartItem> Items
        {
            get => _items;
            set => _items = new HashSet<CartItem>(value);
        }

        public Cart(Guid userId)
        {
            this.Id = userId;
            this.CreatAt = DateTime.Now;
            _items = new HashSet<CartItem>();
        }

        public void AddProduct(Product product, int quantity)
        {
            var item = this.GetCartItem(product.Id);

            if(item is null)
            {
                item = new CartItem(product.Id, product.Name, product.Price, quantity);
                return;
            }

            item.IncreaseQuantity(quantity);
            _items.Add(item);
        }

        public void DeleteProduct(Guid productId)
        {
            var item = this.GetCartItem(productId);
            
            if(item is null)
            {
                throw new Exception();
            }

            _items.Remove(item);
        }

        private CartItem GetCartItem(Guid productId)
           => _items.SingleOrDefault(x => x.ProductId == productId);
    }
}

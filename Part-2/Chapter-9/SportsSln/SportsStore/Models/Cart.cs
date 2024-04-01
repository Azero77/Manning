namespace SportsStore.Models
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; } = new();

        public virtual void AddItem(Product p, int quantity = 1)
        {
            var cart = CartLines.Where(cart => cart.Product.ProductID == p.ProductID).FirstOrDefault();
            if (cart is not null)
            {
                cart.Quantity += quantity;
            }
            else 
            {
                CartLines.Add(new CartLine { Product = p, Quantity = quantity });
            }
        }

        public virtual void RemoveItem(int ProductId) 
        {
            //getting the product
            var product = CartLines.Where(cart => cart.Product.ProductID == ProductId).FirstOrDefault();
            if (product is not null)
            {
                CartLines.Remove(product);
            }
            else 
            {
                throw new InvalidDataException();
            }
        }

        public virtual void Clear() => CartLines.Clear();

        public decimal ComputeTotalValue() 
        {
            return CartLines.Sum(p=> p.Product.Price * p.Quantity);
        }

    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}

using SportsStore.Infrastructure;
using System.Text.Json.Serialization;

namespace SportsStore.Models
{
    public class SessionCart:Cart
    {
        //Session
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider service) 
        {
            var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart cart =session?.GetJson<SessionCart>("Cart") ?? new();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product p, int quantity = 1)
        {
            base.AddItem(p, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void RemoveItem(int ProductId)
        {
            base.RemoveItem(ProductId);
            Session?.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.SetJson("Cart", this);
        }
    }
}

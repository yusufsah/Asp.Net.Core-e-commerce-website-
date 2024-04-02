using Entites.Models;
using StoreApp.Infrastruckte.Extensions;
using System.Text.Json.Serialization;

namespace StoreApp.Models
{
    public class SessionCart : Cart   // unutma kart sınıf miras normalde cart sınıf entity lerde olması lazımdı
    {
        [JsonIgnore]
        public ISession? Session { get; set; }


        public static Cart GetCart(IServiceProvider service)
        {

         ISession? session = service.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;

        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart",this);
        }

        public override void clear()
        {
            base.clear();
            Session.Remove("cart");
        }
        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session?.SetJson<SessionCart>("cart",this);
        }


    }
}

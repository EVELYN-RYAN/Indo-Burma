using System;
using System.Text.Json.Serialization;
using Indo_Burma.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Indo_Burma.Models
{
    public class SessionCart: Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book bk, int qty)
        {
            base.AddItem(bk, qty);
            Session.SetJson("Cart", this);
        }
        public override void RemoveItem(Book bk)
        {
            base.RemoveItem(bk);
            Session.SetJson("Cart", this);
        }
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}

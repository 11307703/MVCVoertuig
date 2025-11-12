using Microsoft.IdentityModel.Tokens;
using MVCVoertuig.Models;

namespace MVCVoertuig.Data
{
    public static class DefaultData
    {

        public static void EnsurePopulated(WebApplication app)
        {
            //StoreDbContext context=new store
            using (var scope = app.Services.CreateScope())
            {

                var context = scope.ServiceProvider.GetRequiredService<VoertuigDbContext>();
                if (!context.Voertuigen.Any())
                {
                    var products = GetVoertuigen();
                    foreach (var product in products)
                    {
                        context.Voertuigen.Add(product);
                    }
                    context.SaveChanges();
                }

            }
        }


        private static IEnumerable<Voertuig> GetVoertuigen()
        {
           List<Voertuig> voertuigen = new List<Voertuig>();

            voertuigen.Add(new Voertuig()
            {
                Merk = "BMW",
                MerkType = "M5",
                Bouwjaar = 2024,
                Km = 15,
                VerkoopPrijs = 25500
            });
            voertuigen.Add(new Voertuig()
            {
                Merk = "Volkswagen",
                MerkType = "Golf",
                Bouwjaar = 2023,
                Km = 75000,
                VerkoopPrijs = 15200
            });

            return voertuigen;  
        }

    }
}

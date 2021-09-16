using Newtonsoft.Json;
using Prevoz.Model;
using Stripe;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        string apiUri = "http://localhost/api/Payments/";
        public async Task<bool> PayWithCard(Uplate paymentModel)
        {
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(apiUri) })
            {
                try
                {
                    var content = JsonConvert.SerializeObject(paymentModel);
                    HttpContent postContent = new StringContent(content, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("PayWithCard", postContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        return default;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception exp)
                {
                    throw;
                }
            }
        }

        public string GeneratePaymentToken(CreditCardModel cardModel)
        {
            StripeConfiguration.ApiKey = "pk_test_51JSjRAFzqt6OnFqZAQBbgCEnBM8K6noiE2NfXPuDOTsdKGLdtmDQeqb56WSEJEPoTa1DIXovKqyuHlaE44nbB6VC00Tu4Jp4yG";
            var option = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = cardModel.Number,
                    ExpMonth = cardModel.ExpMonth,
                    ExpYear = cardModel.ExpYear,
                    Cvc = cardModel.Cvc,
                    Currency = "EUR",
                    Name = cardModel.Name,
                    AddressCity = cardModel.AddressCity,
                    AddressZip = cardModel.AddressZip,
                    AddressLine1 = cardModel.AddressLine1,
                    AddressCountry = cardModel.AddressCountry
                }
            };
            var service = new TokenService();
            var token = service.Create(option);
            return token.Id;
        }
    }
}

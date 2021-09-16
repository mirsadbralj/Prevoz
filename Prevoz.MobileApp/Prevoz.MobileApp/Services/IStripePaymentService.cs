using Prevoz.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prevoz.MobileApp.Services
{
    public interface IStripePaymentService
    {
        Task<bool> PayWithCard(Uplate paymentModel);
        string GeneratePaymentToken(CreditCardModel cardModel);
    }
}

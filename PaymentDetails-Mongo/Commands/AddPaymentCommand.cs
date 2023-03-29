using MediatR;
using PaymentDetails_Mongo.Models;

namespace PaymentDetails_Mongo.Commands
{
   

        public record AddPaymentCommand(Payments payment) : IRequest;
    
}

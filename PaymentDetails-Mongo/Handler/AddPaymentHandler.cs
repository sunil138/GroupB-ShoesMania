using MediatR;
using PaymentDetails_Mongo.Commands;
using PaymentDetails_Mongo.Service;

namespace PaymentDetails_Mongo.Handler
{
    public class AddPaymentHandler : IRequestHandler<AddPaymentCommand>
    {
        private readonly PaymentService _paymentService;
        public AddPaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<Unit> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            await _paymentService.CreateAsync(request.payment);
            return Unit.Value;

        }
    }

}

using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class AddressExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IAddressRepository _addressRepository;

        public AddressExistenceBehavior(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is IRequireAddressValidation addressRequest)
            {
                var address = await _addressRepository.GetByIdAsync(addressRequest.AddressId);

                // TODO: Check for more specific error
                if (address.IsError)
                {
                    return (dynamic)Errors.Address.NotFound(addressRequest.AddressId);
                }
            }

            return await next();
        }
    }
}
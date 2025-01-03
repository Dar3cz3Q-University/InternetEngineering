using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class ValidateAddressExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IAddressRepository _addressRepository;

        public ValidateAddressExistenceBehavior(IAddressRepository addressRepository)
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
                var address = _addressRepository.GetById(addressRequest.AddressId);

                if (address is null)
                {
                    return (dynamic)Errors.Address.NotFound(addressRequest.AddressId);
                }
            }

            return await next();
        }
    }
}
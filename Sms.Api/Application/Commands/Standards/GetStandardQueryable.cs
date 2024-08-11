using Domain.Data;
using Domain.Models;
using MediatR;

namespace Application.Commands.Standards
{
    public class GetStandardQueryable : IRequest<IQueryable<Standard>>
    {
        public class Handler : IRequestHandler<GetStandardQueryable, IQueryable<Standard>>
        {
            private readonly SmsDevContext _context;
            public Handler(SmsDevContext context)
            {
                _context = context;
            }
            public async Task<IQueryable<Standard>> Handle(GetStandardQueryable request, CancellationToken cancellationToken)
            {
                return _context.Standards.AsQueryable();
            }
        }
    }
}

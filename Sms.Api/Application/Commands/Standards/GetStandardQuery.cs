using Application.Common.Exceptions;
using Domain.Data;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Standards
{
    public class GetStandardQuery : IRequest<Standard>
    {
        public int Key { get; set; }
        public class Handler : IRequestHandler<GetStandardQuery, Standard>
        {
            private readonly SmsDevContext _context;
            public Handler(SmsDevContext context)
            {
                _context = context;
            }
            public async Task<Standard> Handle(GetStandardQuery query, CancellationToken cancellationToken)
            {
                var entity = await _context.Standards.FirstOrDefaultAsync(i => i.StandardId == query.Key);
                if (entity == null)
                    throw new NotFoundException(nameof(Standard), query.Key);

                return entity;
            }
        }
    }
}

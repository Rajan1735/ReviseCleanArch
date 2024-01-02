using Domain;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetAllStudentQuery: IRequest<IEnumerable<Student>>
    {
        public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
        {
            private readonly IAppDbContext context;
            public GetAllStudentQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery query, CancellationToken cancellationToken)
            {
                var studentList = await context.Students.ToListAsync();

                if(studentList==null)
                {
                    return null;
                }

                return studentList.AsReadOnly();
            }
        }
    }
}

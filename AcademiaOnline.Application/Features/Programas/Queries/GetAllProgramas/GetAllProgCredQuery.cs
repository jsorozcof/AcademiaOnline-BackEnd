using AcademiaOnline.Application.Features.Programas.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Programas.Queries.GetAllProgramas
{

    public record GetAllProgCredQuery : IRequest<List<GetAllProgramasCredDto>>;
}

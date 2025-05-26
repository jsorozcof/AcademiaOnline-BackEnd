using AcademiaOnline.Application.Features.Materias.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Materias.Queries.GetProfMaterias
{
    public record GetProfMateriasQuery : IRequest<List<ProfMateriasDto>>;
}

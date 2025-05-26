using AcademiaOnline.Application.Features.Materias.Dtos;
using MediatR;

namespace AcademiaOnline.Application.Features.Materias.Queries.GetAllMaterias
{
    public record GetAllMateriasQuery : IRequest<List<MateriasDto>>;
}

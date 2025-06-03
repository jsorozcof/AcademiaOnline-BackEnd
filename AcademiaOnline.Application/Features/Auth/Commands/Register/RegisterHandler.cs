using AcademiaOnline.Application.Common.ManejadorError;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;


namespace AcademiaOnline.Application.Features.Auth.Commands.Register
{

    public class RegisterHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly UserManager<TbUsuario> _userManager;
        private readonly SignInManager<TbUsuario> _signInManager;
        private readonly IEstudianteService _estudianteService;
        private readonly IJwtUtils _jwtUtils;

        public RegisterHandler(
            UserManager<TbUsuario> userManager, 
            SignInManager<TbUsuario> signInManager,
            IEstudianteService estudianteService,
            IJwtUtils jwtUtils)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _estudianteService = estudianteService;
            _jwtUtils = jwtUtils;

        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _userManager.FindByEmailAsync(request.Correo);
            if (usuario != null)
            {
                throw new ManejadorExcepcion(HttpStatusCode.BadRequest, "El usuario ya existe.");
            }

            // Creamos el Alumno
            var result = await _estudianteService.CrearAlumnoBasicAsync(request.Nombre, request.Correo);
            if(result.Item1)
            {
                var user = new TbUsuario
                {
                    NombreCompleto = request.Nombre,
                    UserName = request.Correo,
                    Email = request.Correo,
                    EmailConfirmed = true
                };

                var resultado = await _userManager.CreateAsync(user, request.Password);

                return resultado.Succeeded;
            }

            throw new ManejadorExcepcion(HttpStatusCode.BadRequest, result.Item2);

        }
    }

}

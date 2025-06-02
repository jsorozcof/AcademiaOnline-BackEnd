using AcademiaOnline.Application.Common.ManejadorError;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Application.Services;
using AcademiaOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace AcademiaOnline.Application.Features.Auth.Commands.Login
{

    public class LoginHandler : IRequestHandler<LoginCommand, LoginAuthUsuarioDto>
    {
        private readonly UserManager<TbUsuario> _userManager;
        private readonly SignInManager<TbUsuario> _signInManager;
        private readonly IEstudianteService _estudianteService;
        private readonly IJwtUtils _jwtUtils;

        public LoginHandler(
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

        public async Task<LoginAuthUsuarioDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _userManager.FindByEmailAsync(request.UserName);
            if (usuario == null)
            {
                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, "El usuario no existe.");
            }
            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
            var resultadoRoles = await _userManager.GetRolesAsync(usuario);
            var listaRoles = new List<string>(resultadoRoles);

            if (resultado.Succeeded)
            {
                var estudiante = await _estudianteService.ObtenerEstudiantePorEmailAsync(request.UserName);

                return new LoginAuthUsuarioDto 
                {
                    UserId = usuario.Id,
                    EstudianteId = estudiante.Id,
                    NombreCompleto = usuario.NombreCompleto,
                    AccessToken = _jwtUtils.GenerateToken(usuario.Id, usuario.NombreCompleto, usuario.UserName, usuario.Email, listaRoles),
                    UserName = usuario.UserName,
                    Email = usuario.Email,
                    IsSuccess = resultado.Succeeded
                };
            }

            throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, "Las credenciales son incorrectas.");

        }
    }

}

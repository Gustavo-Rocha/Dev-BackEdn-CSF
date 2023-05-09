using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager,
            TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario => 
                    usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser != null)
                {
                var code = _signInManager.UserManager.ResetPasswordAsync(identityUser,request.Token,request.Password).Result;
                return Result.Ok().WithSuccess("senha redefinida com sucesso");
            }

            return Result.Fail("Falha ao solicitar redefinição");
            
        }

        public Result SolicitarResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());

            if(identityUser is not null)
            {
                string codigoRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }
            return Result.Fail("Falha ao solicitar requisicao");

        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email) =>
            _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedEmail == email);
    }
}

using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmesApi.Authorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            if(!context.User.HasClaim(claim => claim.Type == ClaimTypes.DateOfBirth))
                return Task.CompletedTask;

            var dataNascimento = Convert.ToDateTime(context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth).Value);

            var idadeObtida = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Today.AddYears(-idadeObtida))
                idadeObtida--;

            if (idadeObtida >= requirement.IdadeMinima)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

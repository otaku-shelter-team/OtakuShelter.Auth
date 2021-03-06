using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Accounts
{
	public static class AccountsAuthenticationExtensions
	{
		public static IServiceCollection AddAccountsAuthentication(
			this IServiceCollection services,
			AccountsJwtConfiguration configuration)
		{
			services.TryAddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

			services.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = configuration.SymmetricSecurityKey,
						ValidateIssuer = true,
						ValidIssuer = configuration.Issuer,
						ValidateAudience = true,
						ValidAudience = configuration.Audience
					};
				});

			return services;
		}
	}
}
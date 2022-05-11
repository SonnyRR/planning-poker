namespace PlanningPoker.WebAPI.Extensions
{
	using Ardalis.GuardClauses;

	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.ResponseCompression;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;

	using OpenIddict.Validation.AspNetCore;

	using PlanningPoker.SharedKernel.Models.Configuration;

	using System.Collections.Generic;
	using System.Net.Mime;

	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
		{
			Guard.Against.Null(services, nameof(services));
			Guard.Against.Null(configuration, nameof(configuration));

			services.Configure<PlanningPokerOptions>(configuration);
			services.AddOidcServices();
			services.AddControllers();
			services.AddResponseCompression(opts =>
				opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
				{
						MediaTypeNames.Application.Octet
				}
			);
			services.AddSwaggerGen();

			return services;
		}

		public static IServiceCollection AddOidcServices(this IServiceCollection services)
		{
			Guard.Against.Null(services, nameof(services));

			using var serviceProvider = services.BuildServiceProvider();
			var oidcConfiguration = serviceProvider.GetService<IOptions<PlanningPokerOptions>>()?.Value?.OidcConfiguration;

			// Register the OpenIddict validation components.
			services.AddOpenIddict()
				.AddValidation(options =>
				{
					// Note: the validation handler uses OpenID Connect discovery
					// to retrieve the address of the introspection endpoint.
					options.SetIssuer(oidcConfiguration.Authority);
					options.AddAudiences(oidcConfiguration.ClientId);

					// Configure the validation handler to use introspection and register the client
					// credentials used when communicating with the remote introspection endpoint.
					options.UseIntrospection().SetClientId(oidcConfiguration.ClientId).SetClientSecret(oidcConfiguration.ClientSecret);

					// Register the System.Net.Http integration.
					options.UseSystemNetHttp();

					// Register the ASP.NET Core host.
					options.UseAspNetCore();
				});

			services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
			services.AddAuthorization();

			return services;
		}
	}
}

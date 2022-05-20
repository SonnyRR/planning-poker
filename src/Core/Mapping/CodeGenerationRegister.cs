namespace PlanningPoker.Core.Mapping
{
	using Mapster;
	using PlanningPoker.Persistence;
	using PlanningPoker.Persistence.Entities;
	using System;
	using System.Linq;
	using System.Reflection;

	public class CodeGenerationRegister : ICodeGenerationRegister
	{
		public void Register(CodeGenerationConfig config)
		{
			var types = Assembly
				.GetAssembly(typeof(PlanningPokerDbContext))
				.GetTypes()
				.Where(t => typeof(BaseEntity<Guid>).IsAssignableFrom(t) && !t.IsInterface)
				.ToArray();

			config.AdaptTwoWays("[name]Dto")
				.ForTypes(types)
				.ForType<User>(cfg =>
				{
					cfg.Ignore(e => e.AccessFailedCount);
					cfg.Ignore(e => e.ConcurrencyStamp);
					cfg.Ignore(e => e.DeletedOn);
					cfg.Ignore(e => e.Email);
					cfg.Ignore(e => e.EmailConfirmed);
					cfg.Ignore(e => e.IsDeleted);
					cfg.Ignore(e => e.LockoutEnabled);
					cfg.Ignore(e => e.LockoutEnd);
					cfg.Ignore(e => e.NormalizedEmail);
					cfg.Ignore(e => e.NormalizedUserName);
					cfg.Ignore(e => e.PasswordHash);
					cfg.Ignore(e => e.PhoneNumber);
					cfg.Ignore(e => e.PhoneNumberConfirmed);
					cfg.Ignore(e => e.SecurityStamp);
					cfg.Ignore(e => e.TwoFactorEnabled);
				});

			//config.AdaptTo("[name]Dto")
			//	.ForType<User>(cfg =>
			//	{
			//		cfg.Ignore(e => e.AccessFailedCount);
			//		cfg.Ignore(e => e.ConcurrencyStamp);
			//		cfg.Ignore(e => e.DeletedOn);
			//		cfg.Ignore(e => e.Email);
			//		cfg.Ignore(e => e.EmailConfirmed);
			//		cfg.Ignore(e => e.IsDeleted);
			//		cfg.Ignore(e => e.LockoutEnabled);
			//		cfg.Ignore(e => e.LockoutEnd);
			//		cfg.Ignore(e => e.NormalizedEmail);
			//		cfg.Ignore(e => e.NormalizedUserName);
			//		cfg.Ignore(e => e.PasswordHash);
			//		cfg.Ignore(e => e.PhoneNumber);
			//		cfg.Ignore(e => e.PhoneNumberConfirmed);
			//		cfg.Ignore(e => e.SecurityStamp);
			//		cfg.Ignore(e => e.TwoFactorEnabled);
			//	});

			config.GenerateMapper("[name]Mapper")
				.ForTypes(types);
		}
	}
}

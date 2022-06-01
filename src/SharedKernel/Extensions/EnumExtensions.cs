namespace PlanningPoker.SharedKernel.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Reflection;

	public static class EnumExtensions
	{
		private static readonly Lazy<Dictionary<Type, MemberInfo[]>> cache = new Lazy<Dictionary<Type, MemberInfo[]>>();

		/// <summary>
		/// Retrieves all display names for a given enumeration."/>
		/// </summary>
		/// <param name="enum">The enumeration.</param>
		/// <returns>All display name values from <see cref="DisplayAttribute"/> or the default identifier names.</returns>
		public static string[] GetEnumDisplayNames(this Enum @enum)
		{
			var enumType = @enum.GetType();
			return CacheMembers(enumType).Select(m => m.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? m.Name).ToArray();
		}

		/// <summary>
		/// Retrieves the display name of a given <see cref="Enum"/> member.
		/// </summary>
		/// <param name="enum">The enum member.</param>
		/// <returns>The display name value from a <see cref="DisplayAttribute"/> or the default identifier name.</returns>
		public static string GetEnumDisplayName(this Enum @enum)
		{
			var enumType = @enum.GetType();
			return CacheMembers(enumType)
				.SingleOrDefault(x => x.Name == @enum.ToString())
				.GetCustomAttribute<DisplayAttribute>()
				?.GetName() ?? @enum.ToString();
		}

		/// <summary>
		/// Caches enumeration types & their members in order to do less reflection operations.
		/// </summary>
		/// <param name="type">The type of the enum.</param>
		/// <returns>A <see cref="MemberInfo[]"/> instance.</returns>
		private static MemberInfo[] CacheMembers(Type @type)
		{
			if (!cache.Value.TryGetValue(@type, out var members))
			{
				members = @type.GetMembers();
				cache.Value.Add(@type, members);
			}

			return members;
		}
	}
}

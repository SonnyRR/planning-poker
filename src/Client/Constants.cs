namespace PlanningPoker.Client
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Immutable;

	/// <summary>
	/// Global constans for this assembly.
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Constants related to HTTP clients.
		/// </summary>
		public static class Http
		{
			public const string AUTHORIZED_CLIENT_ID = "authorized";
			public const string UNAUTHORIZED_CLIENT_ID = "default";
		}

		/// <summary>
		/// Constants related to Blazor pages.
		/// </summary>
		public static class Routes
		{
			public const string INDEX = "/";
			public const string TABLE = $"{TABLE_PREFIX}/{{id:guid}}";
			public const string TABLE_PREFIX = "/table";
			public const string CREATE_TABLE = $"{TABLE_PREFIX}/create";
		}

		/// <summary>
		/// Constants related to poker voting cards.
		/// </summary>
		public static class Cards
		{
			public static readonly Lazy<IImmutableDictionary<CardStates, string>> CARD_STYLES = new(() =>
			{
				return new Dictionary<CardStates, string>
				{
					{ CardStates.Pending, "p-1 mx-auto player plain-card" },
					{ CardStates.Voted, "p-1 mx-auto player voted-card" },
					{ CardStates.Revealing, "p-1 mx-auto player voted-card card-rotation" },
					{ CardStates.Revealed, "p-1 mx-auto player result-card" }
				}
				.ToImmutableDictionary();
			});
		}
	}
}

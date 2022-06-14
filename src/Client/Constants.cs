namespace PlanningPoker.Client
{
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

		public static class Routes
		{
			public const string INDEX = "/";
			public const string TABLE = $"{TABLE_PREFIX}/{{id:guid}}";
			public const string TABLE_PREFIX = "/table";
			public const string CREATE_TABLE = $"{TABLE_PREFIX}/create";
		}
	}
}

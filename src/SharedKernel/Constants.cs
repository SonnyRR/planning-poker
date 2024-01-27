namespace PlanningPoker.SharedKernel
{
	public static class Constants
	{
		public static class Colors
		{
			public const string PRIMARY = "#598087";
		}

		public static class Hubs
		{
			public const string ADDED_TO_TABLE_FUNC = "AddedToTable";
			public const string POKER_HUB_URI = "/poker";
            public const string USER_GROUP_PREFIX = "g_";
		}

        public static class LogMessages
        {
            public const string TABLE_NOT_FOUND = "Table with id '{Id}' not found.";
        }
	}
}

namespace PlanningPoker.Client.Records
{
	/// <summary>
	/// Represents a drop-down KVP.
	/// </summary>
	/// <typeparam name="TValue">The value type.</typeparam>
	public record DropDownEntry<TValue>
	{
		public DropDownEntry(string displayName, TValue value)
		{
			this.DisplayName = displayName;
			this.Value = value;
		}

		public string DisplayName { get; }

		public TValue Value { get; }
	}
}

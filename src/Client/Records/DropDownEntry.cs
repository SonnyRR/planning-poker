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

        /// <summary>
        /// The display name used in the input field.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// The backing field value.
        /// </summary>
        public TValue Value { get; }
    }
}

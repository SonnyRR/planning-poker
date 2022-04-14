namespace PlanningPoker.Client.Models
{
    /// <summary>
    /// Represents the information about a given poker table.
    /// </summary>
    public sealed class TableMetadata
    {
        public TableMetadata()
        {
        }

        public TableMetadata(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        public string Name { get; set; }

        public string Code { get; set; }

        // TODO: Add remaining properties.
    }
}

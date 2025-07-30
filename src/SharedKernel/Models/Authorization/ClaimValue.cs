namespace PlanningPoker.SharedKernel.Models.Authorization
{
    public class ClaimValue
    {
        public ClaimValue()
        {
        }

        public ClaimValue(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}

namespace PlanningPoker.Client.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    public partial class Card
	{
        private bool clicking;

		[Parameter]
		public string UnicodeValue { get; set; }

		[Parameter]
		public float Value { get; set; }

        [Parameter]
        public EventCallback<float> Click { get; set; }

        public virtual async Task OnClick()
        {
            if (this.clicking)
            {
                return;
            }

            try
            {
                this.clicking = true;

                await this.Click.InvokeAsync(this.Value);
            }
            finally
            {
                this.clicking = false;
            }
        }
	}
}

namespace PlanningPoker.Client.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    public partial class Card
	{
        private bool clicking;

		[Parameter]
		public string UnicodeValue { get; set; }

		[Parameter]
		public int Value { get; set; }

        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<MouseEventArgs> Click { get; set; }

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public virtual async Task OnClick(MouseEventArgs args)
        {
            if (this.clicking)
            {
                return;
            }

            try
            {
                this.clicking = true;

                await this.Click.InvokeAsync(args);
            }
            finally
            {
                this.clicking = false;
            }
        }
	}
}

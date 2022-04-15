using Microsoft.AspNetCore.Components;

using Radzen;

namespace PlanningPoker.Client.Components.Dialogs
{
    public partial class UsernameDialog
    {
        [Inject]
        public DialogService DialogService { get; set; }

        public string Username { get; set; }

        public void OnSubmit()
        {
            this.DialogService.Close(this.Username);
        }
    }
}

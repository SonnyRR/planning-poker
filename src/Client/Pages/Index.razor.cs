using System.Threading.Tasks;

using Ardalis.GuardClauses;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using PlanningPoker.Client.Components.Dialogs;
using PlanningPoker.Client.Services;
using PlanningPoker.SharedKernel.Models.Tables;

using Radzen;

namespace PlanningPoker.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public ILogger<Index> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public IPlayerService PlayerService { get; set; }

        public string RoomId { get; set; }

        public bool ShowRoomIdentifierInput { get; set; }

        public void JoinExistingTable(JoinExistingTableRequest joinTableParameters)
        {
            Guard.Against.Null(joinTableParameters, nameof(joinTableParameters));
            //NavigationManager.NavigateTo($"/room/{tableId}");
        }

        public void OnTableCreationSubmit() => this.NavigationManager.NavigateTo("/create");

        protected override async Task OnInitializedAsync()
        {
            //if (!await this.PlayerService.CheckIfUsernameHasBeenEntered())
            //{
            //    this.Logger.LogInformation("Missing username, prompting the user to enter one.");
            //    var opts = new DialogOptions
            //    {
            //        ShowClose = false,
            //        CloseDialogOnEsc = false,
            //        CloseDialogOnOverlayClick = false
            //    };

            //    var userName = await DialogService.OpenAsync<UsernameDialog>("Username", null, opts);
            //    await this.PlayerService.SaveUsername(userName);
            //}
        }
    }
}

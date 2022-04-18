using System;
using System.Text.Json;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using PlanningPoker.Client.Components.Dialogs;

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
        public ILocalStorageService LocalStorageService { get; set; }

        public string RoomId { get; set; }

        public bool ShowRoomIdentifierInput { get; set; }

        public void JoinExistingTable(string tableId)
        {
            Guard.Against.NullOrWhiteSpace(tableId, nameof(tableId));
            //NavigationManager.NavigateTo($"/room/{tableId}");
        }

        void OnTableCreationSubmit() => this.NavigationManager.NavigateTo("/create");

        protected override async Task OnInitializedAsync()
        {
            if (!await LocalStorageService.ContainKeyAsync("username"))
            {
                this.Logger.LogInformation("Missing username, prompting the user to enter one.");
                var opts = new DialogOptions
                {
                    ShowClose = false,
                    CloseDialogOnEsc = false,
                    CloseDialogOnOverlayClick = false
                };

                var userName = await DialogService.OpenAsync<UsernameDialog>("Username", null, opts);
                await this.LocalStorageService.SetItemAsStringAsync("username", userName);
            }
        }
    }
}

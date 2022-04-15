using System;
using System.Text.Json;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using PlanningPoker.Client.Components.Dialogs;

using Radzen;

namespace PlanningPoker.Client.Pages
{
    public partial class TableSelector
    {
        [Inject]
        public ILogger<TableSelector> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        public string RoomId { get; set; }

        public bool ShowRoomIdentifierInput { get; set; }

        public void JoinExistingTable()
        {
            this.Logger.LogInformation("I am here");
            //NavigationManager.NavigateTo($"/room/{tableId}");
        }

        void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            this.Logger.LogError("InvalidSubmit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
        }

        void OnTableCreationSubmit()
        {
            this.NavigationManager.NavigateTo("/create");
        }

        protected override async Task OnInitializedAsync()
        {
            if (!await LocalStorageService.ContainKeyAsync("username"))
            {
                var opts = new DialogOptions
                {
                    ShowClose = false,
                    CloseDialogOnEsc = false,
                    CloseDialogOnOverlayClick = false
                };

                var userName = await DialogService.OpenAsync<UsernameDialog>("Test title", null, opts);
                await this.LocalStorageService.SetItemAsStringAsync("username", userName);
            }
        }
    }
}

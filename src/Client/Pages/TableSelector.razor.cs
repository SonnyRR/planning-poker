using System;
using System.Text.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using Radzen;

namespace PlanningPoker.Client.Pages
{
    public partial class TableSelector
    {
        [Inject]
        public ILogger<TableSelector> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
    }
}

using System.Text.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using Radzen;

namespace PlanningPoker.Client.Pages
{
    public partial class RoomSelector
    {
        [Inject]
        public ILogger<RoomSelector> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool ShowRoomIdentifierInput { get; set; }

        public string RoomId { get; set; };

        public void JoinExistingTable()
        {
            Logger.LogInformation("I am here");
            //NavigationManager.NavigateTo($"/room/{tableId}");
        }

        void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            Logger.LogError("InvalidSubmit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }
}

namespace PlanningPoker.Client.Features.Index
{
    using Ardalis.GuardClauses;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using Radzen;
    using SharedKernel.Models.Tables;
    using static Constants;

    public partial class Index
    {
        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public ILogger<Index> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string RoomId { get; set; }

        public bool ShowRoomIdentifierInput { get; set; }

        public void JoinExistingTable(JoinExistingTableRequest joinTableParameters)
        {
            Guard.Against.Null(joinTableParameters, nameof(joinTableParameters));
            this.NavigationManager.NavigateTo($"{Routes.TABLE_PREFIX}/{joinTableParameters.Code}");
        }

        public void OnTableCreationSubmit() => this.NavigationManager.NavigateTo(Routes.CREATE_TABLE);
    }
}

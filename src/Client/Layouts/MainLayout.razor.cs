namespace PlanningPoker.Client.Layouts
{
    using Microsoft.AspNetCore.Components;
    using System;

    public partial class MainLayout
    {
        public string FooterCopyrightContent { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.FooterCopyrightContent = $"Vasil Kotsev, Copyright Ⓒ {DateTimeOffset.Now.Year}";
        }
    }
}

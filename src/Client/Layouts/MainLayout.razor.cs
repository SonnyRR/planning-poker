using System;

namespace PlanningPoker.Client.Layouts
{
    public partial class MainLayout
    {
        public string FooterCopyrightContent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.FooterCopyrightContent = $"Vasil Kotsev, Copyright Ⓒ {DateTimeOffset.Now.Year}";
        }
    }
}

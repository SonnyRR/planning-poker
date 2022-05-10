namespace PlanningPoker.Client.Layouts
{
	using System;

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

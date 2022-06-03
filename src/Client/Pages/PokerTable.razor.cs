﻿namespace PlanningPoker.Client.Pages
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.AspNetCore.SignalR.Client;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public sealed partial class PokerTable : IAsyncDisposable
	{
		private readonly List<string> messages = new();
		private HubConnection hubConnection;
		private string messageInput;
		private string userInput;

		public bool IsConnected => this.hubConnection?.State == HubConnectionState.Connected;

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public Guid Id { get; set; }

		public async ValueTask DisposeAsync()
		{
			if (this.hubConnection is not null)
			{
				await this.hubConnection.DisposeAsync();
			}
		}

		protected override async Task OnInitializedAsync()
		{
			this.hubConnection = new HubConnectionBuilder()
				.WithUrl(this.NavigationManager.ToAbsoluteUri("/poker"))
				.Build();

			this.hubConnection.On<string>("AddedToTable", (name) =>
			{
				var encodedMsg = $"User has been added to: {name}";
				this.messages.Add(encodedMsg);
				this.StateHasChanged();
			});

			await this.hubConnection.StartAsync();
		}

		private async Task Send()
		{
			if (this.hubConnection is not null)
			{
				await this.hubConnection.SendAsync("AddToTable", this.userInput);
			}
		}
	}
}

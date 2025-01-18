namespace PlanningPoker.WebAPI
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using PlanningPoker.Core;
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Binding;
    using PlanningPoker.Sockets;
    using PlanningPoker.WebAPI.Controllers;
    using PlanningPoker.WebAPI.Hubs;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Responsible for managing work item estimation rounds.
    /// </summary>
    [Authorize]
    public class RoundsController : BasePokerController
    {
        private const string ID_ROUTE_PARAM = "{id:guid}";

        private readonly IRoundService roundService;
        private readonly IHubContext<PokerHub, IPokerClient> pokerHub;

        /// <summary>
        /// Instantiates a new rounds controller.
        /// </summary>
        /// <param name="roundService"></param>
        /// <param name="pokerHub"></param>
        public RoundsController(IRoundService roundService, IHubContext<PokerHub, IPokerClient> pokerHub)
        {
            this.roundService = roundService;
            this.pokerHub = pokerHub;
        }

        /// <summary>
        /// Creates a new work item estimation round.
        /// </summary>
        /// <param name="bindingModel">The input model.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An instance of <see cref="RoundModel"/>.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoundBindingModel bindingModel, CancellationToken ct)
        {
            var round = await this.roundService.CreateAsync(bindingModel, ct);
            await this.pokerHub.Clients.Group(bindingModel.TableId.ToString()).CreateVotingRound(round);
            return this.Created();
        }

        /// <summary>
        /// Deletes a work item estimation round.
        /// </summary>
        /// <param name="id">The round's identifier.</param>
        /// <param name="tableId"></param>
        /// <param name="ct">The cancellation token.</param>
        [HttpDelete(ID_ROUTE_PARAM +"/{tableId:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, [FromRoute] Guid tableId, CancellationToken ct)
        {
            await this.roundService.DeleteAsync(id, ct);
            await this.pokerHub.Clients.Group(tableId.ToString()).DeleteVotingRound(id);
            return this.NoContent();
        }

        /// <summary>
        /// Finalizes a work item estimation round.
        /// </summary>
        /// <param name="id">The round's identifier.</param>
        /// <param name="ct">The cancellation token.</param>
        [HttpPost($"{ID_ROUTE_PARAM}/finalize")]
        public IActionResult Finalize([FromRoute] Guid id, CancellationToken ct)
        {
            return this.Ok();
        }
    }
}

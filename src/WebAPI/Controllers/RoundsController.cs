namespace PlanningPoker.WebAPI
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PlanningPoker.Core;
    using PlanningPoker.SharedKernel;
    using PlanningPoker.SharedKernel.Models.Generated;
    using PlanningPoker.WebAPI.Controllers;

    /// <summary>
    /// Responsible for managing work item estimation rounds.
    /// </summary>
    [Authorize]
    public class RoundsController : BasePokerController
    {
        private const string ID_ROUTE_PARAM = "{id:guid}";

        private readonly IRoundService roundService;

        /// <summary>
        /// Instantiates a new rounds controller.
        /// </summary>
        /// <param name="roundService"></param>
        public RoundsController(IRoundService roundService) => this.roundService = roundService;

        /// <summary>
        /// Creates a new work item estimation round.
        /// </summary>
        /// <param name="bindingModel">The input model.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An instance of <see cref="RoundModel"/>.</returns>
        [HttpPost]
        public async Task<RoundModel> CreateAsync([FromBody] RoundBindingModel bindingModel, CancellationToken ct)
            => await this.roundService.CreateAsync(bindingModel, ct);

        /// <summary>
        /// Deletes a work item estimation round.
        /// </summary>
        /// <param name="id">The round's identifier.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns></returns>
        [HttpDelete(ID_ROUTE_PARAM)]
        public async Task DeleteAsync([FromRoute] Guid id, CancellationToken ct)
            => await this.roundService.DeleteAsync(id, ct);

        /// <summary>
        /// Finalizes a work item estimation round.
        /// </summary>
        /// <param name="id">The round's identifier.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost($"{ID_ROUTE_PARAM}/finalize")]
        public IActionResult Finalize([FromRoute] Guid id, CancellationToken ct)
        {
            return this.Ok();
        }
    }
}

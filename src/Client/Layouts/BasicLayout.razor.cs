using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using AntDesign;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

using PlanningPoker.Client.Models;

namespace PlanningPoker.Client.Layouts
{
    public partial class BasicLayout
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public IOptions<LayoutSettings> LayoutSettings { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var githubLink = this.LayoutSettings
                .Value
                .Links?
                .SingleOrDefault(l => l.Key.Contains("github", StringComparison.InvariantCultureIgnoreCase));

            if (githubLink is not null)
            {
#pragma warning disable IDE0004
                githubLink.Title = (RenderFragment)(builder =>
                {
                    builder.OpenComponent(0, typeof(Icon));
                    builder.AddAttribute(1, "Type", IconType.Fill.Github);
                    builder.CloseComponent();
                });
            }
#pragma warning restore IDE0004
        }
    }
}

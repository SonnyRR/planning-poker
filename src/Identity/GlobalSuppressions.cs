// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S6931:ASP.NET controller actions should not have a route template starting with \"/\"", Justification = "I don't want to apply it.", Scope = "namespaceanddescendants", Target = "~N:PlanningPoker.Identity.Controllers")]
[assembly: SuppressMessage("Major Code Smell", "S6934:A Route attribute should be added to the controller when a route template is specified at the action level", Justification = "I don't want to apply it.", Scope = "type", Target = "~T:PlanningPoker.Identity.Controllers.ErrorController")]
[assembly: SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "Commented out code is used as example.", Scope = "member", Target = "~M:PlanningPoker.Identity.Controllers.AuthorizationController.Exchange~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Minor Code Smell", "S2325:Methods and properties that don't access instance data should be static", Justification = "This method accesses isntance data.", Scope = "member", Target = "~M:PlanningPoker.Identity.Startup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder,Microsoft.AspNetCore.Hosting.IWebHostEnvironment)")]
[assembly: SuppressMessage("Minor Code Smell", "S2325:Methods and properties that don't access instance data should be static", Justification = "This method accesses isntance data.", Scope = "member", Target = "~M:PlanningPoker.Identity.Areas.Identity.Pages.Account.RegisterModel.CreateUser~PlanningPoker.Persistence.Entities.User")]

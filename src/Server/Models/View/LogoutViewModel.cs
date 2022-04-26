﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PlanningPoker.BFF.Models.View
{
    public sealed class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}

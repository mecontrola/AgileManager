﻿using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum StatusCategories : uint
    {
        [Description("No Category")]
        NoCategory = 1,
        [Description("To Do")]
        ToDo = 2,
        [Description("Done")]
        Done = 3,
        [Description("In Progress")]
        InProgress = 4
    }
}
using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lartisan.Options
{
    class StartOptions : VerbOptionsBase
    {
        [OptionName("projectdir", Description = "Laravel project directory.")]
        [OptionName("p", Description = "Laravel project directory.")]
        public string ProjectDir { get; set; }
    }
}

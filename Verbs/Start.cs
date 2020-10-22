using CommandCore.Library.Attributes;
using CommandCore.Library.PublicBase;
using Lartisan.Options;
using Lartisan.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lartisan.Verbs
{
    [VerbName("start", Description = "Start the artisan.")]
    [VerbName("start-artisan", Description = "Start the artisan.")]
    class Start : VerbBase<StartOptions>
    {
        private readonly IOutputWriter _outputWriter;

        public Start(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public override VerbViewBase Run()
        {
            return new StartView(Options, _outputWriter);
        }
    }
}

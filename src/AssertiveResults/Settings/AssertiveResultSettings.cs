using System;

namespace AssertiveResults.Settings
{
    internal sealed class AssertiveResultSettings
    {
        private static readonly Lazy<AssertiveResultSettings> lazy = new Lazy<AssertiveResultSettings>(() => new AssertiveResultSettings());
        public static AssertiveResultSettings Instance => lazy.Value;

        private AssertiveResultSettings() { }

        public BreakBehavior DefaultBreakBehavior { get; internal set; } = BreakBehavior.Default;
    }
}
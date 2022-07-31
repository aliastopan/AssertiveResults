using System;

namespace AssertiveResults.Settings
{
    public static class AssertiveResult
    {
        public static void Configure(Action<SettingOptions> options)
        {
            var Options = new SettingOptions();
            options?.Invoke(Options);
        }
    }
}
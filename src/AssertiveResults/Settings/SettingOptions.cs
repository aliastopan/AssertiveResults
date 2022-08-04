namespace AssertiveResults.Settings
{
    public sealed class SettingOptions
    {
        internal SettingOptions() { }

        public void SetDefaultBreakBehavior(BreakBehavior breakBehavior)
        {
            if(breakBehavior == BreakBehavior.Default)
                breakBehavior = BreakBehavior.FirstError;

            AssertiveResultSettings.Instance.DefaultBreakBehavior = breakBehavior;
        }
    }
}
namespace AssertiveResults.Settings
{
    public sealed class SettingOptions
    {
        internal SettingOptions() { }

        public void SetDefaultBreakMethod(BreakMethod breakMethod)
        {
            if(breakMethod == BreakMethod.Default)
                breakMethod = BreakMethod.FirstError;

            AssertiveResultSettings.Instance.DefaultBreakMethod = breakMethod;
        }
    }
}
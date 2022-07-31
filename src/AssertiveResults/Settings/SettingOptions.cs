namespace AssertiveResults.Settings
{
    public sealed class SettingOptions
    {
        internal SettingOptions() { }

        public void SetDefaultAssertMethod(ResolveMethod resolveMethod)
        {
            if(resolveMethod == ResolveMethod.Default)
                AssertiveResultSettings.Instance.DefaultResolveMethod = ResolveMethod.Strict;
            else
                AssertiveResultSettings.Instance.DefaultResolveMethod = resolveMethod;
        }
    }
}
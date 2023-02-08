namespace repo.Tools
{
    public static class Helper
    {
        public static void AddArgumentSwitches(this Dictionary<string,string> argumentSwitchList, string @switch,string value)
        {
            var argumentSwitch = Repo.validArgumentSwitches.FirstOrDefault(i => i == @switch);

            if (argumentSwitch is not null)
                argumentSwitchList.Add(argumentSwitch,value);
        }

        public static string ToBaseSwitch(this string @switch)
        {
            if (string.IsNullOrEmpty(@switch))
                return null;

            @switch = @switch.Remove(0); // this action removes the - from the start of the switch

            var baseSwitch = Repo.config.CommandAllies.FirstOrDefault(i => i.Key == @switch).Value;
            if (baseSwitch is null)
                return null;

            return baseSwitch;
        }
    }
}

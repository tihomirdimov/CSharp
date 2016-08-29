namespace _20160710.Commands
{
    using System.Text.RegularExpressions;
    class CommandsEngine
    {
        private string input;
        public CommandsEngine(string input)
        {
            this.input = input;
        }
        public void run()
        {
            string registerPowerHardwarePattern = @"RegisterPowerHardware\(([A-Za-z0-9]+), ([0-9]+), ([0-9]+)\)";
            string registerHeavyHardwarePattern = @"RegisterHeavyHardware\(([A-Za-z0-9]+), ([0-9]+), ([0-9]+)\)";
            string registerExpressSoftware = @"RegisterExpressSoftware\(([A-Za-z0-9]+), ([A-Za-z0-9]+), ([0-9]+), ([0-9]+)\)";
            string registerLightSoftware = @"RegisterLightSoftware\(([A-Za-z0-9]+), ([A-Za-z0-9]+), ([0-9]+), ([0-9]+)\)";
            string releaseSoftwareComponent = @"ReleaseSoftwareComponent\(([A - Za - z0 - 9] +), ([A - Za - z0 - 9] +)\)";
            if (Regex.IsMatch(this.input, registerPowerHardwarePattern))
            {
                Regex regex = new Regex(registerPowerHardwarePattern);
                Match match = regex.Match(this.input);
            }
        }
    }
}
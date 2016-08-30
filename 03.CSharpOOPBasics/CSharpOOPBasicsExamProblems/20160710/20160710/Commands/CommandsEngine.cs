namespace _20160710.Commands
{
    using System.Text.RegularExpressions;
    using _20160710.Models;
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
                RegisterPowerHardware toRegister = new RegisterPowerHardware(new PowerHardware(
                    match.Groups[1].ToString(),
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value)));
                toRegister.register();
            }
            else if (Regex.IsMatch(this.input, registerHeavyHardwarePattern))
            {
                Regex regex = new Regex(registerHeavyHardwarePattern);
                Match match = regex.Match(this.input);
                RegisterHeavyHardware toRegister = new RegisterHeavyHardware(new HeavyHardware(
                    match.Groups[1].ToString(),
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value)));
                toRegister.register();
            }
            else if (input.Equals("System Split"))
            {
                TheSystem.SystemSplit();
            }
        }
    }
}
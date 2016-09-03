namespace _20160710.Commands
{
    using System;
    using _20160710.Output;
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
            string registerExpressSoftwarePattern = @"RegisterExpressSoftware\(([A-Za-z0-9]+), ([A-Za-z0-9]+), ([0-9]+), ([0-9]+)\)";
            string registerLightSoftwarePattern = @"RegisterLightSoftware\(([A-Za-z0-9]+), ([A-Za-z0-9]+), ([0-9]+), ([0-9]+)\)";
            string releaseSoftwareComponentPattern = @"ReleaseSoftwareComponent\(([A-Za-z0-9]+), ([A-Za-z0-9]+)\)";
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
            else if (Regex.IsMatch(this.input, registerExpressSoftwarePattern))
            {
                Regex regex = new Regex(registerExpressSoftwarePattern);
                Match match = regex.Match(this.input);
                RegisterExpressSoftware toRegister = new RegisterExpressSoftware(new ExpressSoftware(
                    match.Groups[1].ToString(),
                    match.Groups[2].ToString(),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value)));
                toRegister.register();
            }
            else if (Regex.IsMatch(this.input, registerLightSoftwarePattern))
            {
                Regex regex = new Regex(registerLightSoftwarePattern);
                Match match = regex.Match(this.input);
                RegisterLightSoftware toRegister = new RegisterLightSoftware(new ExpressSoftware(
                    match.Groups[1].ToString(),
                    match.Groups[2].ToString(),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value)));
                toRegister.register();
            }
            else if (Regex.IsMatch(this.input, releaseSoftwareComponentPattern))
            {
                Regex regex = new Regex(releaseSoftwareComponentPattern);
                Match match = regex.Match(this.input);
                ReleaseSoftwareComponent toRelease = new ReleaseSoftwareComponent(match.Groups[1].ToString(), match.Groups[2].ToString());
                toRelease.Release();
            }
            else if (input.Equals("Analyze()"))
            {
                Output.Analyze.Run();
            }
            else if (input.Equals("System Split"))
            {
                Output.SystemSplit.Run();
            }
        }
    }
}
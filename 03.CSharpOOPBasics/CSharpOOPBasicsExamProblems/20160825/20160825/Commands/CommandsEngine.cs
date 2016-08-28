namespace _20160825.Commands
{
    using System.Text.RegularExpressions;
    using Models.Centers;
    using Models.Animals;
    class CommandsEngine
    {
        private readonly string input;
        public CommandsEngine(string input)
        {
            this.input = input;
        }
        public void ReadCommand()
        {
            if (this.input.Equals("Paw Paw Pawah"))
            {
                PawInc.Result();
            }
            else
            {
                string registerAdoptionCenterPattern = @"RegisterAdoptionCenter\s\|\s(.+)";
                string registerCleansingCenterPattern = @"RegisterCleansingCenter\s\|\s(.+)";
                string registerDogPattern = @"RegisterDog\s\|\s(.+)\s\|\s([0-9]+)\s\|\s([0-9]+)\s\|\s(.+)";
                string registerCatPattern = @"RegisterCat\s\|\s(.+)\s\|\s([0-9]+)\s\|\s([0-9]+)\s\|\s(.+)";
                string cleansePattern = @"Cleanse\s\|\s(.+)";
                string adoptPattern = @"Adopt\s\|\s(.+)";
                string sendForClenasingPattern = @"SendForCleansing\s\|\s(.+)\s\|\s(.+)";
                if (Regex.IsMatch(this.input, registerAdoptionCenterPattern))
                {
                    Regex regex = new Regex(registerAdoptionCenterPattern);
                    Match match = regex.Match(this.input);
                    RegisterAdoptionCenter toAdd = new RegisterAdoptionCenter(match.Groups[1].ToString());
                    toAdd.Execute();
                }
                else if (Regex.IsMatch(this.input, registerCleansingCenterPattern))
                {
                    Regex regex = new Regex(registerCleansingCenterPattern);
                    Match match = regex.Match(this.input);
                    RegisterCleansingCenter toAdd = new RegisterCleansingCenter(match.Groups[1].ToString());
                    toAdd.Execute();
                }
                else if (Regex.IsMatch(this.input, registerDogPattern))
                {
                    Regex regex = new Regex(registerDogPattern);
                    Match match = regex.Match(this.input);
                    RegisterDog toAdd = new RegisterDog(new Dog(
                        match.Groups[1].ToString(),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        match.Groups[4].ToString()));
                    toAdd.Execute();
                }
                else if (Regex.IsMatch(this.input, registerCatPattern))
                {
                    Regex regex = new Regex(registerCatPattern);
                    Match match = regex.Match(this.input);
                    RegisterCat toAdd = new RegisterCat(new Cat(
                        match.Groups[1].ToString(),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        match.Groups[4].ToString()));
                    toAdd.Execute();
                }
                else if (Regex.IsMatch(this.input, cleansePattern))
                {
                    Regex regex = new Regex(cleansePattern);
                    Match match = regex.Match(this.input);
                    Cleanse backFrom = new Cleanse(match.Groups[1].ToString());
                    backFrom.Execute();
                }
                else if (Regex.IsMatch(this.input, sendForClenasingPattern))
                {
                    Regex regex = new Regex(sendForClenasingPattern);
                    Match match = regex.Match(this.input);
                    SendForClenasing sentFor = new SendForClenasing(match.Groups[1].ToString(), match.Groups[2].ToString());
                    sentFor.Execute();
                }
                else if (Regex.IsMatch(this.input, adoptPattern))
                {
                    Regex regex = new Regex(adoptPattern);
                    Match match = regex.Match(this.input);
                    Adopt adopt = new Adopt(match.Groups[1].ToString());
                    adopt.Execute();
                }
            }
        }
    }
}
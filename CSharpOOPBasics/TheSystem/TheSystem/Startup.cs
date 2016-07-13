using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

//не съм събмитвал в judge. не се справих с абстракцията и представям само просто код зап проверка

namespace TheSystem
{
    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();
            HashSet<Hardware> theSystem = new HashSet<Hardware>();
            while (input != "System Split")
            {
                Regex softwarePattern = new Regex(@"([A-Za-z]+)\(([A-Za-z]+)\,\s*([A-Za-z0-9]+)\,\s*([A-Za-z0-9]+)\,\s*([0-9]+)\)");
                Regex hardwarePattern = new Regex(@"([A-Za-z]+)\(([A-Za-z0-9]+)\,\s*([0-9]+)\,\s*([0-9]+)\)");
                Regex releasePattern = new Regex(@"([A-Za-z]+)\(([A-Za-z0-9]+)\,\s*([A-Za-z0-9]+)\)");
                Regex analyzePattern = new Regex(@"Analyze\(\s*\)");
                Match mSoftware = softwarePattern.Match(input);
                Match mHardware = hardwarePattern.Match(input);
                Match mRelease = releasePattern.Match(input);
                Match mAnalyze = analyzePattern.Match(input);
                if (mHardware.Success)
                {
                    if (mHardware.Groups[1].ToString().Equals("RegisterPowerHardware"))
                    {
                        theSystem.Add(new Hardware(mHardware.Groups[2].ToString(), "Power",
                           int.Parse(mHardware.Groups[3].ToString()), int.Parse(mHardware.Groups[4].ToString())));
                    }
                    else if (mHardware.Groups[1].ToString().Equals("RegisterHeavyHardware"))
                    {
                        theSystem.Add(new Hardware(mHardware.Groups[2].ToString(), "Heavy",
                            int.Parse(mHardware.Groups[3].ToString()), int.Parse(mHardware.Groups[4].ToString())));
                    }
                }
                else if (mSoftware.Success)
                {
                    if (mSoftware.Groups[1].ToString().Equals("RegisterExpressSoftware"))
                    {
                        Software currentSoftware = new Software(mSoftware.Groups[3].ToString(), "Express",
                            int.Parse(mSoftware.Groups[4].ToString()), int.Parse(mSoftware.Groups[5].ToString()));
                        Console.WriteLine(currentSoftware.GetCapacity().ToString());
                        Console.WriteLine(currentSoftware.GetMemory().ToString());
                    }
                    else if (mSoftware.Groups[1].ToString().Equals("RegisterLightSoftware"))
                    {
                        Software currentSoftware = new Software(mSoftware.Groups[3].ToString(), "Light",
                            int.Parse(mSoftware.Groups[4].ToString()), int.Parse(mSoftware.Groups[5].ToString()));
                        Console.WriteLine(currentSoftware.GetCapacity().ToString());
                        Console.WriteLine(currentSoftware.GetMemory().ToString());
                    }
                }
                else if (mRelease.Success)
                {
                    
                }
                else if (mAnalyze.Success)
                {

                }
                input = Console.ReadLine();
            }
            Console.WriteLine("{0}",theSystem.Count);
        }
    }
}
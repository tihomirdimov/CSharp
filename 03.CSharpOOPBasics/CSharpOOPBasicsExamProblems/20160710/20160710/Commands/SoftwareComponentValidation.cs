using System.Linq;
using _20160710.Models;

namespace _20160710.Commands
{
    public class SoftwareComponentValidation
    {
        private readonly Software software;
        private readonly string hardware;
        public SoftwareComponentValidation(Software software, string hardware)
        {
            this.software = software;
            this.hardware = hardware;
        }
        public bool IsValid()
        {
            bool isHardwareExist = TheSystem.Components.Any(s => s.Name.Equals(hardware));
            int hardwareMaximumCapacity = TheSystem.Components.FirstOrDefault(h => h.Name.Equals(hardware)).MaximumCapacity;
            int hardwareMaximumMemory = TheSystem.Components.FirstOrDefault(h => h.Name.Equals(hardware)).MaximumMemory;
            int hardwareCurrentCapacity = TheSystem.Components.FirstOrDefault(h => h.Name.Equals(hardware)).Software.Sum(s => s.CapacityConsumption);
            int hardwareCurrentMemory = TheSystem.Components.FirstOrDefault(h => h.Name.Equals(hardware)).Software.Sum(s => s.MemoryConsumption);
            if (isHardwareExist && software.CapacityConsumption + hardwareCurrentCapacity <= hardwareMaximumCapacity && software.MemoryConsumption + hardwareCurrentMemory <= hardwareMaximumMemory)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

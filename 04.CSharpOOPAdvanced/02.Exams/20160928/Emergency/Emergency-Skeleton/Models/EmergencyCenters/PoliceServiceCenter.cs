namespace Emergency_Skeleton.Models.EmergencyCenters
{
    public class PoliceServiceCenter : BaseEmergencyCenter
    {
        public PoliceServiceCenter(string name, int amountOfMaximumEmergencies) : base(name, amountOfMaximumEmergencies)
        {
        }

        public override bool isForRetirement()
        {
            return false;
        }
    }
}

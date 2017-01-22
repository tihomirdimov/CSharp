namespace Emergency_Skeleton.Models.EmergencyCenters
{
    public class FiremanServiceCenter : BaseEmergencyCenter
    {
        public FiremanServiceCenter(string name, int amountOfMaximumEmergencies) : base(name, amountOfMaximumEmergencies)
        {
        }

        public override bool isForRetirement()
        {
            return false;
        }
    }
}

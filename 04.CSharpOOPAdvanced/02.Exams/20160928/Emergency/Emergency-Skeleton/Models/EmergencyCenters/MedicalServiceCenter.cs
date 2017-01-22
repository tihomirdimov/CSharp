namespace Emergency_Skeleton.Models.EmergencyCenters
{
    public class MedicalServiceCenter : BaseEmergencyCenter
    {
        public MedicalServiceCenter(string name, int amountOfMaximumEmergencies) : base(name, amountOfMaximumEmergencies)
        {
        }

        public override bool isForRetirement()
        {
            return false;
        }
    }
}

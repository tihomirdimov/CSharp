namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class PublicHealthEmergency : BaseEmergency
    {
        private int casualties;

        public PublicHealthEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int casualties)
            : base(description, emergencyLevel, registrationTime)
        {
            this.Casualties = casualties;
        }

        public int Casualties { get; private set; }
    }
}
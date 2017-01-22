namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    class PublicOrderEmergency : BaseEmergency
    {
        private bool specialCase;

        public PublicOrderEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, bool specialCase)
            : base(description, emergencyLevel, registrationTime)
        {
            this.SpecialCase = specialCase;
        }

        public bool SpecialCase { get; private set; }
    }
}

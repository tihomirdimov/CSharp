namespace Emergency_Skeleton.Models
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public abstract class BaseEmergency
    {

        private string description;
        private EmergencyLevel emergencyLevel;
        private RegistrationTime registrationTime;

        protected BaseEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime)
        {
            this.Description = description;
            this.emergencyLevel = emergencyLevel;
            this.registrationTime = registrationTime;
        }

        public string Description { get; protected set; }
        public EmergencyLevel Level { get; protected set; }
        public RegistrationTime Time { get; protected set; }
    }
}

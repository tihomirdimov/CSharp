namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    class PublicPropertyEmergency:BaseEmergency
    {
        private int propertyDamage;

        public PublicPropertyEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int propertyDamage) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.PropertyDamage = propertyDamage;
        }

        public int PropertyDamage { get; private set; }
    }
}

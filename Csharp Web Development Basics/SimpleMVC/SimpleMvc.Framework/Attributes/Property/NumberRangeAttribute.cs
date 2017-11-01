namespace SimpleMvc.Framework.Attributes.Property
{
    class NumberRangeAttribute : PropertyAttribute
    {
        private readonly double minimumValue;

        private readonly double maximumValue;

        public NumberRangeAttribute(double minimumValue, double maximumValue)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        public override bool IsValid(object value)
        {
            return this.minimumValue <= (double) value && this.maximumValue >= (double) value;
        }
    }
}

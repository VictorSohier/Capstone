using Ardalis.SmartEnum;

namespace Capstone.Core.Enums
{
    public sealed class GenderEnum : SmartEnum<GenderEnum>
    {
        private GenderEnum(string name, int value) : base(name, value)
        {

        }

        private GenderEnum() : base("", 0)
        {

        }

        public static readonly GenderEnum MALE = new GenderEnum("male", 1);
        public static readonly GenderEnum FEMALE = new GenderEnum("female", 2);
    }
}
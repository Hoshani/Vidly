namespace Vidly.Models
{
    public class MembershipType
    {
        public enum Types : byte
        {
            Unknown = 0,
            PayAsYouGo = 1,
            Monthly = 2,
            Quarterly = 3,
            Annually = 4
        }

        public byte Id { get; set; }

        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}
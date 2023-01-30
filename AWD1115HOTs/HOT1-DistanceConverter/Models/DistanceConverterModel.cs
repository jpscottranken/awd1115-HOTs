using System.ComponentModel.DataAnnotations;

namespace HOT1_DistanceConverter.Models
{
    public class DistanceConverterModel
    {
        public const decimal CM_PER_IN = 2.54m;

        [Required(ErrorMessage = "Distance In Inches Value Is Required")]
        [Range(1, 500, ErrorMessage = "Distance In Inches Must Be Between 1 And 500")]

        public decimal? Distance { get; set; }

        public decimal DistanceInInches()
        {
            if (Distance.HasValue)
            {
                return Distance.Value;
            }
            
            return 0.0m;
        }

        public decimal DistanceInCentimeters()
        {
            if (Distance.HasValue)
            {
                return Distance.Value * CM_PER_IN;
            }

            return 0.0m;
        }
    }
}

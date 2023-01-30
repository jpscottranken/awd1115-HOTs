using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HOT1_2_OrderForm.Models
{
    public class OrderForm
    {
        const decimal TSHIRTPRICE = 15.00M;
        const decimal TAXRATE     =  0.08M;
        const string  TEN         = "10% discount applied";
        const string  TWENTY      = "20% discount applied";
        const string  THIRTY      = "30% discount applied";
        const string  INVDC       = "Invalid discount code";

        [Required(ErrorMessage = "You Must Enter A Quantity!")]
        [Range(1, 100, ErrorMessage = "Quantity Must Be Between 1 And 500")]
        public int? Quantity { get; set; }
        public string? DiscountCode { get; set; }
        public string? DiscountMessage { get; set; }
        public decimal PricePerShirt { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public int DisplayQuantity()
        {
            if (Quantity.HasValue)
            {
                return Quantity.Value;
            }
            else
            {
                return 0;
            }
        }

        public string DisplayDiscountCode()
        {
            if ((DiscountCode == "6175")   ||
                (DiscountCode == "1390")   ||
                (DiscountCode == "BB88"))
            {
                return DiscountCode;
            }
            else
            {
                return "";
            }
        }


        public string DisplayDiscountMessage()
        {
            switch (DiscountCode)
            {
                case "":
                    DiscountMessage = "";
                    break;

                case "BB88":
                    DiscountMessage = TEN;
                    break;

                case "1390":
                    DiscountMessage = TWENTY;
                    break;

                case "6175":
                    DiscountMessage = THIRTY;
                    break;

                default:
                    DiscountMessage = INVDC;
                    break;
            }

            return DiscountMessage;
        }

        public decimal DisplayPricePerShirt()
        {
            switch (DiscountCode)
            {
                case "":
                    PricePerShirt = TSHIRTPRICE;
                    break;

                case "BB88":
                    PricePerShirt = TSHIRTPRICE * 0.9m;
                    break;

                case "1390":
                    PricePerShirt = TSHIRTPRICE * 0.8m;
                    break;

                case "6175":
                    PricePerShirt = TSHIRTPRICE * 0.7m;
                    break;

                default:
                    PricePerShirt = TSHIRTPRICE;
                    break;
            }

            return PricePerShirt;
        }


        public decimal DisplaySubtotal()
        {
            return Quantity.Value * PricePerShirt;
        }

        public decimal DisplayTax()
        {
            return DisplaySubtotal() * TAXRATE;
        }

        public decimal DisplayTotal()
        {
            return DisplaySubtotal() + DisplayTax();
        }
    }
}

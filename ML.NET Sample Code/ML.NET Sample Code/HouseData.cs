using System;
using Microsoft.ML.Data;

namespace ML.NET_Sample_Code
{
    public class HouseData
    {
        [LoadColumn(0)]  // price
        [ColumnName("Label")]
        public float Price { get; set; }

        [LoadColumn(1)]  // area
        public float Area { get; set; }

        [LoadColumn(2)]  // bedrooms
        public float Bedrooms { get; set; }

        [LoadColumn(3)]  // bathrooms
        public float Bathrooms { get; set; }

        [LoadColumn(4)]  // stories
        public float Stories { get; set; }

        [LoadColumn(5)]  // mainroad
        public float Mainroad { get; set; }

        [LoadColumn(6)]  // guestroom
        public float Guestroom { get; set; }

        [LoadColumn(7)]  // basement
        public float Basement { get; set; }

        [LoadColumn(8)]  // hotwaterheating
        public float Hotwaterheating { get; set; }

        [LoadColumn(9)]  // airconditioning
        public float Airconditioning { get; set; }

        [LoadColumn(10)]  // parking
        public float Parking { get; set; }

        [LoadColumn(11)]  // prefarea
        public float Prefarea { get; set; }
    }
}

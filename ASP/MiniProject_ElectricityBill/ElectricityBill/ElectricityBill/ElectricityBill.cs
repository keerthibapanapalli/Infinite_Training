using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ElectricityBill
{
    public class ElectricityBill
    {
       
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get { return consumerNumber; }
            set { consumerNumber = value; }
        }

        public string ConsumerName
        {
            get { return consumerName; }
            set { consumerName = value; }
        }

        public int UnitsConsumed
        {
            get { return unitsConsumed; }
            set { unitsConsumed = value; }
        }

        public double BillAmount
        {
            get { return billAmount; }
            set { billAmount = value; }
        }

        public void ValidateConsumerNumberOrThrow(string consumerNumber)
        {
            if (string.IsNullOrWhiteSpace(consumerNumber))
                throw new FormatException("Invalid Consumer Number");


            if (!Regex.IsMatch(consumerNumber, @"^EB\d{5}$"))
                throw new FormatException("Invalid Consumer Number");

        }

    }
}
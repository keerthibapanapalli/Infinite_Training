using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBill
{
    public class ElectricityBoard
    {
        private readonly DBHandler db;

        public ElectricityBoard()
        {
            db = new DBHandler();
        }


        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double total = 0;
            int remaining = units;

            int slab = Math.Min(remaining, 100);
            total += slab * 0;
            remaining -= slab;

            if (remaining > 0)
            {
                slab = Math.Min(remaining, 200);
                total += slab * 1.5;
                remaining -= slab;
            }


            if (remaining > 0)
            {
                slab = Math.Min(remaining, 300);
                total += slab * 3.5;
                remaining -= slab;
            }

            if (remaining > 0)
            {
                slab = Math.Min(remaining, 400);
                total += slab * 5.5;
                remaining -= slab;
            }

            if (remaining > 0)
            {
                total += remaining * 7.5;
            }

            ebill.BillAmount = total;
        }


        public void AddBill(ElectricityBill ebill)
        {
            using (SqlConnection con = db.GetConnection())
            {
                const string sql = "Insert Into ElectricityBill(consumer_number, consumer_name, units_consumed, bill_amount) " +
                                   "Values (@num, @name, @units, @amount)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                    cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            var bills = new List<ElectricityBill>();

            using (SqlConnection con = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "Select Top (@n) consumer_number, consumer_name, units_consumed, bill_amount " +
                "From ElectricityBill Order By consumer_number Desc", con))
            {
                cmd.Parameters.AddWithValue("@n", num);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bills.Add(new ElectricityBill
                        {
                            ConsumerNumber = reader.GetString(0),
                            ConsumerName = reader.GetString(1),
                            UnitsConsumed = reader.GetInt32(2),
                            BillAmount = Convert.ToDouble(reader.GetValue(3))
                        });
                    }
                }
            }

            return bills;
        }

    }

}
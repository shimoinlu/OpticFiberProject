using System;
using System.Collections.Generic;
using Convers = OpticFiberTest_ver1.Converstions;


namespace OpticFiberTest_ver1.Classes_SFF8636
{
    class DateCode : SFF8636
    {
        public DateCode()
        {
            m_title = "Date Code";
            m_size = 8;
            m_address = 212;
            Months = new Dictionary<string, string>
            {
                {"1", "January" },
                {"2", "February" },
                {"3", "Merch" },
                {"4", "April" },
                {"5", "May" },
                {"6", "June" },
                {"7", "July" },
                {"8", "August" },
                {"9", "September" },
                {"10", "October" },
                {"11", "November" },
                {"12", "December" }
            };
        }
        /****************************************************************
        * This function is encoding, comparing and define the value according sff-8636
        ***************************************************************/
        public override void EncodeValue(string name) 
        {
           
            string[] bitsAdrr = name.Split(' '); //split the value
            int year = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[0] + bitsAdrr[1])); //convert to ascii
            string strYear = ""; //the year value
            int month = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[2] + bitsAdrr[3])); //convect to ascii
            DateTime localDate = DateTime.Now; 

            if (year >= 0 && year < localDate.Year) //validate year
                if (Convert.ToString(year).Length == 1)
                    strYear += "200" + Convert.ToString(year);
                else
                    strYear += "20" + Convert.ToString(year);
            else if (year >= 90 && year <= 99)
                strYear += "19" + Convert.ToString(year);
            else
                throw new Exception();
             
            int daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(strYear), month); //month

            int dayOfMonth = Convert.ToInt32(Convers.HexToAsc.Convert2Asc(bitsAdrr[4] + bitsAdrr[5]));
            if (dayOfMonth < 0 && dayOfMonth > daysInMonth) //validate month
                throw new Exception();

            string venSpec = Convers.HexToAsc.Convert2Asc(bitsAdrr[6] + bitsAdrr[7]);
            if (venSpec == "00")
                venSpec = "";

            m_storedValue += dayOfMonth + " " +
                            Months[Convers.HexToAsc.Convert2Asc(bitsAdrr[1])] + " " +
                            year + "\n" + venSpec;
        }
        Dictionary<string, string> Months;
    }
}

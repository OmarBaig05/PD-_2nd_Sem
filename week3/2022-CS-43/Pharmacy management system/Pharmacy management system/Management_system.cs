using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_management_system
{
    public class admin
    {
        public string name;
        public string password;
    }
    public class medicine
    {
        public string medicineName;
        public string password;
        public string quantity;
        public int price;
        public string stock;
    }

    public class worker
    {
        public string workername;
        public string password;
        public string salary;
    }

    public class supplier
    {
        public string supplierName;
        public string suppliedMedicineName;
        public string suppliedMedicineQuantity;
        public int suppliedMedicinePrice;
        public string suppliedmedicineStock;
    }


    class Management_system
    {
    }
}

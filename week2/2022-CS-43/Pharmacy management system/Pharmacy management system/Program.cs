using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
    class Program
    {
        
        static void Main(string[] args)
        {

            //..........................................................Admin/User realted declaration 
            string path = "admins.txt";

            admin ad = new admin();
            List<admin> admin_data = new List<admin>();

            //..........................................................Worker realted declaration 
            string pathWorker = "workers.txt";

            worker wor = new worker();
            List<worker> worker_data = new List<worker>();
            //..........................................................Medicines realted declaration 

            string pathMedicine = "medicines.txt";
             medicine med = new medicine();
             List<medicine> med_data = new List<medicine>(); 
            //..........................................................Supplier realted declaration 

            string pathSupplier = "suppliers.txt";

            supplier sup = new supplier();
            List<supplier> sup_data = new List<supplier>();

            int option;
            bool check = false;
            int adminChoice;

            readDataMedicine(pathMedicine, med_data);
            readDataSupplier(pathSupplier, sup_data);
            readDataWorer( pathWorker, worker_data);
            readData(path, admin_data);
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();

                    check = signIn(ad ,n, p , admin_data);
                    while (check == true)
                    {
                        adminChoice = adminFunctions();
                        if (adminChoice == 1)
                        {
                            Console.WriteLine("This menu is related to the check and balance of sales and profit management , and we are only makin the menu of admin so their is nothing to displayed here :)");
                        }
                        else if (adminChoice == 2)
                        {
                            addingMedicine( med,med_data);
                            continue;
                        }
                        else if (adminChoice == 3)
                        {
                            removeMedicine(med,  med_data);
                            continue;
                        }
                        else if (adminChoice == 4)
                        {
                            updatingMedicinePrice(med_data);
                            continue;
                        }
                        else if (adminChoice == 5)
                        {
                            stock(med, med_data);
                            continue;
                        }
                        else if (adminChoice == 6)
                        {
                            supplierAnalytics(sup, sup_data);
                            continue;
                        }
                        else if (adminChoice == 7)
                        {
                            addSupplier(sup, sup_data);
                            continue;
                        }
                        else if (adminChoice == 8)
                        {
                           
                            removeWorker( wor,worker_data);
                            continue;
                        }
                        else if (adminChoice == 9)
                        {
                            addWorker(wor, worker_data);
                            continue;
                        }
                        else if (adminChoice == 10)
                        {
                            workerDetails(worker_data);
                            continue;
                        }
                        else if (adminChoice == 0)
                        {
                            break;
                        }
                        else if (adminChoice < 1 || adminChoice > 10)
                        {
                            Console.WriteLine(".............Invalide input.........");
                            continue;
                        }

                    }
                }
                else if (option == 2)
                {

                    signUp(path,admin_data);
                }
                else if(option == 3)
                {
                    supplierSave( pathSupplier, sup_data);
                    workerSave(pathWorker,  worker_data);
                    medicineSave(pathMedicine,med_data);
                    Console.WriteLine("...........Data saved..........");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.Read();
                }
            } while (option < 3);
            Console.Read();
        }
       

        static int menu()
        {
            Console.Clear();
            int option;
            
            Console.WriteLine("1.  Sign in");
            Console.WriteLine("2.  Sign up");
            Console.WriteLine("3.  To save data");
            Console.WriteLine("Enter option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static int adminFunctions()
        {
            Console.Clear();
            int option;
            Console.WriteLine("1.       Dashboard");
            Console.WriteLine("2.       Adding Medicines");
            Console.WriteLine("3.       Deleting the Medicines");
            Console.WriteLine("4.       Updating Prices of Medicines");
            Console.WriteLine("5.       Stock");
            Console.WriteLine("6.       Supplier's Analytics");
            Console.WriteLine("7.       Add Supplier's Info");
            Console.WriteLine("8.       Remove Worker");
            Console.WriteLine("9.       Add Worker");
            Console.WriteLine("10.      Workers Details");
            Console.WriteLine("");
            Console.WriteLine("0.      Enter anyother key To Go back");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("............. Enter your choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
            
        }
        static bool addingMedicine(medicine med , List<medicine> med_data)
        {
            string option = "1";
            while(option != "0")
            {
                Console.Clear();
                med = new medicine();
                Console.WriteLine(" Enter Medicine name: ");
                med.medicineName = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Quantity (mg): ");
                med.quantity = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Price: ");
                med.price = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter Medicine Counts/Stock: ");
                med.stock = Console.ReadLine();
                med_data.Add(med);
                Console.WriteLine("");
                Console.WriteLine("...........Medicine added successfully..............");
                Console.WriteLine("");
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if(option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static bool updatingMedicinePrice(List<medicine> med_data)
        {
            string medicine;
            string quantity;
            int price;
            int newprice;
            bool flag = false;
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine(" Enter Medicine name: ");
                medicine = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Quantity (mg): ");
                quantity = Console.ReadLine();
                Console.WriteLine(" Enter current Medicine Price: ");
                price = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter new Medicine Price: ");
                newprice = int.Parse(Console.ReadLine());
                for(int i = 0; i < med_data.Count(); i++)
                {
                    if (med_data[i].medicineName == medicine && med_data[i].quantity == quantity && med_data[i].price == price)
                    {
                        med_data[i].price = newprice;
                        Console.ReadLine();
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                    Console.WriteLine("medicine price updated ");
                if (flag == false)
                    Console.WriteLine("medicine not found");
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if(option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static bool stock(medicine med, List<medicine> med_data)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine("Medicine\t\tmg\t\t\tPrice\t\t\tstock");
                
                for(int i = 0; i < med_data.Count(); i++)
                {
                    Console.WriteLine(med_data[i].medicineName + "\t\t\t" + med_data[i].quantity + "\t\t\t" + med_data[i].price + "\t\t\t" + med_data[i].stock + "\t\t\t");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter 0 to exit.............");
                option = Console.ReadLine();

                if(option =="0")
                {
                    break;
                }
            }
            return true;
        }
        static bool supplierAnalytics(supplier sup, List<supplier> sup_data)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine("Supplier \t\t" + "Medicine \t\t" + "mg \t\t\t" + "Price\t\t\t" + "stock");

                for (int i = 0; i < sup_data.Count(); i++)
                {
                    Console.WriteLine(sup_data[i].supplierName + "\t\t" + sup_data[i].suppliedMedicineName + "\t\t" + sup_data[i].suppliedMedicineQuantity + "\t\t" + sup_data[i].suppliedMedicinePrice + "\t\t" + sup_data[i].suppliedmedicineStock );

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter 0 to exit.............");
                option = Console.ReadLine();

                if (option =="0")
                {
                    break;
                }
            }
            return true;
        }
        static bool removeMedicine(medicine med, List<medicine> med_data)
        {
            string medicine;
            string quantity;
            int price;
            string stock;
            bool check = false;
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine(" Enter Medicine name: ");
                medicine = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Quantity (mg): ");
                quantity = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Price: ");
                price = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter Medicine Counts/Stock: ");
                stock = Console.ReadLine();
                for(int i = 0; i < med_data.Count(); i++)
                {
                    if(med_data[i].medicineName == medicine && med_data[i].quantity == quantity && med_data[i].price == price && med_data[i].stock == stock)
                    {
                        med_data.RemoveAt(i);
                        check = true;
                    }
                }
                if(check == true)
                {
                    Console.WriteLine("...............Medicine removed Successfully");
                }
                else if(check == false)
                {
                    Console.WriteLine("...............Medicine not found");
                }
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if(option =="0")
                {
                    break;
                }
            }
            return true;
        }
        static bool addSupplier(supplier sup, List<supplier> sup_data)
        {
            string option = "1";
            while (option != "0")
            {
                Console.Clear();
                sup = new supplier();
                Console.WriteLine(" Enter Supplier name: ");
                sup.supplierName = Console.ReadLine();
                Console.WriteLine(" Enter Medicine name: ");
                sup.suppliedMedicineName = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Quantity (mg): ");
                sup.suppliedMedicineQuantity = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Price: ");
                sup.suppliedMedicinePrice = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter Medicine Counts/Stock: ");
                sup.suppliedmedicineStock = Console.ReadLine();

                sup_data.Add(sup);

                Console.WriteLine("");
                Console.WriteLine("...........Supplier Details added successfully..............");
                Console.WriteLine("");
                Console.WriteLine(" Enter 0 to go back......... ");
                option = (Console.ReadLine());
                if (option == "0")
                {
                    break;
                }
            }
            return true;
        }
        static bool addWorker(worker wor, List<worker> worker_data)
        {
            string check = "1";
            
            while(check != "0")
            {
                Console.Clear();
                wor = new worker();
                Console.WriteLine("Worker Name: ");
                 wor.workername = Console.ReadLine();
                Console.WriteLine("Worker Password: ");
                wor.password = Console.ReadLine();
                Console.WriteLine("Worker SALLARY: ");
                wor.salary = Console.ReadLine();
                worker_data.Add(wor);
                Console.WriteLine(" ");
                Console.WriteLine( "Worker added successfully");
                Console.WriteLine(" ");
                Console.WriteLine("Press 0 to go back");
                check=Console.ReadLine();
                if(check == "0")
                {
                    break;
                }
            }
            return true;

        }
        static bool removeWorker(worker wor, List<worker> worker_data)
        {
            string check = "1";
            bool flag = false;
            string workerPass;
            string name;
            
            while(check != "0")
            {
                Console.Clear();
                Console.WriteLine("Worker Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Worker Password: ");
                workerPass = Console.ReadLine();
                for(int i = 0; i < worker_data.Count(); i++)
                {
                    if (worker_data[i].workername == name  && worker_data[i].password == workerPass)
                    {
                        worker_data.RemoveAt(i);
                        flag = true;
                    }
                }
                Console.WriteLine("");
                if(flag == true)
                    Console.WriteLine("Worker reomved ");
                else if (flag == false)
                    Console.WriteLine("Worker not found");
                Console.WriteLine("Press 0 to go back");
                check=Console.ReadLine();
                if(check == "0")
                {
                    break;
                }
            }
            return true;
        }
        static void workerDetails(List<worker> worker_data)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine("workerName \t " + "workerSalary \t\t");

                for (int i = 0; i < worker_data.Count(); i++)
                {

                    Console.WriteLine(worker_data[i].workername + "\t\t"+ worker_data[i].salary);

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter 0 to exit.............");
                option = Console.ReadLine();

                if (option == "0")
                {
                    break;
                }
            }
        }
        static string parseData(string record, int field)
        {

            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Count(); i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void readData(string path, List<admin> admin_data)
        {
            int x = 0;
            StreamReader filevariable = new StreamReader(path);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                admin ad = new admin();
                ad.name = parseData(record, 1);
                ad.password = parseData(record, 2);
                x++;
                admin_data.Add(ad);
                if (x >= admin_data.Count())
                {
                    break;
                }
            }
            filevariable.Close();
        }
        static bool signIn(admin ad, string n, string p , List<admin> admin_data)
        {
            Console.Clear();
            bool flag = false;
            for (int x = 0; x < admin_data.Count(); x++)
            {
                if (n == admin_data[x].name && p == admin_data[x].password)
                {
                    Console.WriteLine("Valid user");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            return flag;
            Console.ReadKey();
        }
        static void signUp(string path, List<admin> admin_data)
        {
            Console.Clear();
            admin ad = new admin();
            Console.WriteLine("Enter New Name: ");
            ad.name = Console.ReadLine();
            Console.WriteLine("Enter New Password: ");
            ad.password = Console.ReadLine();
            admin_data.Add(ad);

            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(ad.name + "," + ad.password);
            file.Flush();
            file.Close();
        }
        static void medicineSave(string pathMedicine, List<medicine> med_data)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathMedicine, true);
            for(int i = 0; i < med_data.Count(); i++)
            {
            file.WriteLine(med_data[i].medicineName + "," + med_data[i].quantity + "," + med_data[i].price + "," + med_data[i].stock);
            }
            file.Flush();
            file.Close();
        }
        static void workerSave(string pathWorker, List<worker> wor_data)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathWorker, true);
            for(int i = 0; i < wor_data.Count(); i++)
            {
            file.WriteLine(wor_data[i].workername + "," + wor_data[i].password + "," + wor_data[i].salary);
            }
            file.Flush();
            file.Close();
        }
        static void supplierSave(string pathSupplier ,List<supplier> sup_data)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathSupplier, true);
            for(int i = 0; i < sup_data.Count(); i++)
            {
            file.WriteLine(sup_data[i].supplierName + "," + sup_data[i].suppliedMedicineName + "," + sup_data[i].suppliedMedicineQuantity + "," + sup_data[i].suppliedMedicinePrice + "," + sup_data[i].suppliedmedicineStock);
            }
            file.Flush();
            file.Close();
        }
        static void readDataMedicine(string pathMedicine, List<medicine> med_data)
        {
            StreamReader filevariable = new StreamReader(pathMedicine);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                medicine med = new medicine();
                med.medicineName = parseData(record, 1);
                med.quantity = parseData(record, 2);
                med.price = int.Parse(parseData(record, 3));
                med.stock = parseData(record, 4);
                med_data.Add(med);
            }
            filevariable.Close();
        }
        static void readDataSupplier(string pathSupplier, List<supplier> sup_data)
        {
            StreamReader filevariable = new StreamReader(pathSupplier);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                supplier sup = new supplier();
                sup.supplierName = parseData(record, 1);
                sup.suppliedMedicineName = parseData(record, 2);
                sup.suppliedMedicineQuantity = (parseData(record, 3));
                sup.suppliedMedicinePrice = int.Parse(parseData(record, 4));
                sup.suppliedmedicineStock = (parseData(record, 5));
                sup_data.Add(sup);
            }
            filevariable.Close();
        }
        static void readDataWorer(string pathWorker, List<worker> wor_data)
        {
            StreamReader filevariable = new StreamReader(pathWorker);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                worker wor = new worker();
                wor.workername = parseData(record, 1);
                wor.password = parseData(record, 2);
                wor.salary = (parseData(record, 3));
                wor_data.Add(wor);
            }
            filevariable.Close();
        }

      
    }
}

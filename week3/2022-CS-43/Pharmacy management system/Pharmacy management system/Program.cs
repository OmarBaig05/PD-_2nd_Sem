using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pharmacy_management_system
{

    //..........................................................Admin Class
    public class Admin
    {

        public string name;
        public string password;

        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Admin functions

        public Admin(string name , string password)
        {
            this.name = name;
            this.password = password;
        }

    }

    //..........................................................Medicines Class
    public class Medicine
    {
        public string medicineName;
        public string quantity;
        public int price;
        public string stock;

        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Medicines functions

        public Medicine(string name,string quantity,int price,string stock)
        {
            this.medicineName = name;
            this.quantity = quantity;
            this.price = price;
            this.stock = stock;
        }
    }


    //..........................................................Worker Class
    public class Worker
    {
        public string workername;
        public string password;
        public string salary;

        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Worker functions

        public Worker(string name, string pass,string salary)
        {
            this.workername = name;
            this.password = pass;
            this.salary = salary;
        }
    }


    //..........................................................Supplier Class
    public class Supplier
    {
        public string supplierName;
        public string suppliedMedicineName;
        public string suppliedMedicineQuantity;
        public int suppliedMedicinePrice;
        public string suppliedmedicineStock;

        public Supplier(string name, string suppliedMedicineName, string suppliedMedicineQuantity, int suppliedMedicinePrice, string suppliedmedicineStock)
        {
            this.supplierName = name;
            this.suppliedMedicineName = suppliedMedicineName;
            this.suppliedMedicineQuantity = suppliedMedicineQuantity;
            this.suppliedMedicinePrice = suppliedMedicinePrice;
            this.suppliedmedicineStock = suppliedmedicineStock;
        }

        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Medicines functions
    }
    class Program
    {
        
        static void Main(string[] args)
        {

            //..........................................................Admin/User realted declaration 
            string path = "admins.txt";

            List<Admin> admin_data = new List<Admin>();

            //..........................................................Worker realted declaration 
            string pathWorker = "workers.txt";

            List<Worker> worker_data = new List<Worker>();
            //..........................................................Medicines realted declaration 

            string pathMedicine = "medicines.txt";

             List<Medicine> med_data = new List<Medicine>(); 
            //..........................................................Supplier realted declaration 

            string pathSupplier = "suppliers.txt";

            List<Supplier> sup_data = new List<Supplier>();

            int option;
            bool check = false;
            int adminChoice;

            readDataMedicine(pathMedicine, med_data);
            readDataSupplier(pathSupplier, sup_data);
            readDataWorker( pathWorker, worker_data);
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
                    Admin ad = new Admin(n, p);

                    check = signIn(ad ,admin_data);
                    if(check == true)
                    { 
                        while (check == true)
                        {
                            adminChoice = adminFunctions();
                            if (adminChoice == 1)
                            {
                                Console.WriteLine("This menu is related to the check and balance of sales and profit management , and we are only making the menu of admin so their is nothing to displayed here :)");
                            }
                            else if (adminChoice == 2)
                            {
                                Medicine passingMed = addingMedicine(med_data);
                                if(passingMed != null)
                                { 
                                    storeInListMed(med_data, passingMed);
                                    Console.WriteLine("Medicine added successfully");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Medicine added successfully");
                                    Console.ReadKey();
                                }
                                continue;
                            }
                            else if (adminChoice == 3)
                            {
                                removeMedicine( med_data);
                                continue;
                            }
                            else if (adminChoice == 4)
                            {
                                updatingMedicinePrice(med_data);
                                continue;
                            }
                            else if (adminChoice == 5)
                            {
                                stock(med_data);
                                continue;
                            }
                            else if (adminChoice == 6)
                            {
                                supplierAnalytics(sup_data);
                                continue;
                            }
                            else if (adminChoice == 7)
                            {
                                Supplier passingSupplierObject =  addSupplier( sup_data);
                                if (passingSupplierObject != null)
                                {
                                    storeInListSup(sup_data, passingSupplierObject);
                                    Console.WriteLine("Supplier Added Successfully");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Supplier is not Added");
                                    Console.ReadKey();
                                }
                                continue;
                            }
                            else if (adminChoice == 8)
                            {
                               
                                removeWorker(worker_data);
                                continue;
                            }
                            else if (adminChoice == 9)
                            {
                                Worker passingWorkerObject = addWorker(worker_data);
                                if(passingWorkerObject != null)
                                {
                                    storeInListWor(worker_data, passingWorkerObject);
                                    Console.WriteLine("Worker Added Successfully");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Worker is not Added");
                                    Console.ReadKey();
                                }
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
                    else if (check == false)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Invalid User .......");
                        Console.ReadKey();
                    }

                }
                else if (option == 2)
                {
                    Admin passingAdminObject = signUp(admin_data);
                    storeInListAdmin(admin_data, passingAdminObject);
                    writeAdminDataInFile(admin_data ,path);
                }
                else if(option == 3)
                {
                    supplierSave( pathSupplier, sup_data);
                    workerSave(pathWorker,  worker_data);
                    medicineSave(pathMedicine,med_data);
                    writeAdminDataInFile(admin_data, path);

                    Console.WriteLine("...........Data saved..........");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to Close application");
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


        // ****************************************************************         Admin functions
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
        static bool signIn(Admin ad,List<Admin> admin_data)
        {
            Console.Clear();
            bool flag = false;
            foreach (Admin x in admin_data)
            {
                if (ad.name == x.name && ad.password == x.password)
                {
                    flag = true;
                }
            }
            return flag;
        }
        static Admin signUp(List<Admin> admin_data)
        {
            Console.Clear();
            Console.WriteLine("Enter New Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter New Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                Admin ad = new Admin(name, password);
                return ad;
            }
            return null;
        }
        static void writeAdminDataInFile(List<Admin> admin_data , string path)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(path, true);
            for (int i = 0; i < admin_data.Count(); i++)
            {
                file.WriteLine(admin_data[i].name + "," + admin_data[i].password);
            }
            file.Flush();
            file.Close();
        }
        static void storeInListAdmin(List<Admin> admin_data , Admin ad )
        {
            admin_data.Add(ad);
        }
        static void readData(string path, List<Admin> admin_data)
        {
            StreamReader filevariable = new StreamReader(path);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                string name = parseData(record, 1);
                string password = parseData(record, 2);
                Admin ad = new Admin(name , password);
                storeInListAdmin(admin_data, ad);
            }
            filevariable.Close();
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++         Medicines functions
        static void medicineSave(string pathMedicine, List<Medicine> med_data)
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
        static void readDataMedicine(string pathMedicine, List<Medicine> med_data)
        {
            StreamReader filevariable = new StreamReader(pathMedicine);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                string medicineName = parseData(record, 1);
                string quantity = parseData(record, 2);
                int price = int.Parse(parseData(record, 3));
                string stock = parseData(record, 4);
                Medicine med = new Medicine(medicineName, quantity, price, stock);
                storeInListMed(med_data, med);
            }
            filevariable.Close();
        }
        static void storeInListMed(List<Medicine> admin_data, Medicine ad)
        {
            admin_data.Add(ad);
        }
        static Medicine addingMedicine(List<Medicine> med_data)
        {
            Console.Clear();
            Console.WriteLine(" Enter Medicine name: ");
            string medicineName = Console.ReadLine();
            Console.WriteLine(" Enter Medicine Quantity (mg): ");
            string quantity = Console.ReadLine();
            Console.WriteLine(" Enter Medicine Price: ");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Medicine Counts/Stock: ");
            string stock = Console.ReadLine();
            if(medicineName != null && quantity != null && stock != null )
            { 
                Medicine med = new Medicine(medicineName, quantity, price, stock);
                return med;
            }
            return null;
        }
        static bool removeMedicine( List<Medicine> med_data)
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
        static bool updatingMedicinePrice(List<Medicine> med_data)
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
        static bool stock( List<Medicine> med_data)
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

        // ------------------------------------------------------------------       Worker functions
        static void workerSave(string pathWorker, List<Worker> wor_data)
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
        static void readDataWorker(string pathWorker, List<Worker> wor_data)
        {
            StreamReader filevariable = new StreamReader(pathWorker);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                
                string workername = parseData(record, 1);
                string password = parseData(record, 2);
                string salary = (parseData(record, 3));
                Worker wor = new Worker(workername, password, salary);
                storeInListWor(wor_data, wor);
            }
            filevariable.Close();
        }
        static void storeInListWor(List<Worker> worker_data, Worker ad)
        {
            worker_data.Add(ad);
        }
        static void workerDetails(List<Worker> worker_data)
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
        static Worker addWorker(List<Worker> worker_data)
        {
            
            Console.Clear();
            Console.WriteLine("Worker Name: ");
            string workername = Console.ReadLine();
            Console.WriteLine("Worker Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Worker SALLARY: ");
            string salary = Console.ReadLine();
            if (workername != null && password != null)
            {
                Worker wor = new Worker(workername, password, salary);
                return wor;
            }
            return null;

        }
        static bool removeWorker(List<Worker> worker_data)
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

        //`????????????????????????????????????????????????????????????????????      Supplier functions
        static void readDataSupplier(string pathSupplier, List<Supplier> sup_data)
        {
            StreamReader filevariable = new StreamReader(pathSupplier);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                
                string supplierName = parseData(record, 1);
                string suppliedMedicineName = parseData(record, 2);
                string suppliedMedicineQuantity = (parseData(record, 3));
                int suppliedMedicinePrice = int.Parse(parseData(record, 4));
                string suppliedmedicineStock = (parseData(record, 5));
                Supplier sup = new Supplier(supplierName, suppliedMedicineName, suppliedMedicineQuantity, suppliedMedicinePrice, suppliedmedicineStock);
                storeInListSup(sup_data ,sup);
            }
            filevariable.Close();
        }
        static Supplier addSupplier( List<Supplier> sup_data)
        {
            Console.Clear();
            Console.WriteLine(" Enter Supplier name: ");
            string supplierName = Console.ReadLine();
            Console.WriteLine(" Enter Medicine name: ");
            string suppliedMedicineName = Console.ReadLine();
            Console.WriteLine(" Enter Medicine Quantity (mg): ");
            string suppliedMedicineQuantity = Console.ReadLine();
            Console.WriteLine(" Enter Medicine Price: ");
            int suppliedMedicinePrice = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Medicine Counts/Stock: ");
            string suppliedmedicineStock = Console.ReadLine();

            Supplier sup = new Supplier(supplierName, suppliedMedicineName, suppliedMedicineQuantity, suppliedMedicinePrice, suppliedmedicineStock);
            if (sup != null)
            { 
                return sup;
            }
                return null;
                
        }
        static bool supplierAnalytics(List<Supplier> sup_data)
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
        static void supplierSave(string pathSupplier ,List<Supplier> sup_data)
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
        static void storeInListSup(List<Supplier> suplier_data, Supplier sup)
        {
            suplier_data.Add(sup);
        }
        // ............................................................Parse Data
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
    }
}

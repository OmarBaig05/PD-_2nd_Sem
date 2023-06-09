using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pharmacy_management_system
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //..........................................................Admin/User realted declaration 
            string path = "admin.txt";

            string[] names = new string[5];
            string[] password = new string[5];

            //..........................................................Worker realted declaration 
            string pathWorker = "worker.txt";
            int workerCounter = 1;
            string[] workerName = new string[5];
            string[] workerPassword = new string[5];
            string[] workerSallary = new string[5];
            //..........................................................Medicines realted declaration 

            string pathMedicine = "medicine.txt";
            int medicineCounter = 1;
            string[] medicineName = new string[1000];
            string[] medicineQuantity = new string[1000];
            int[] medicinePrice = new int[1000];
            string[] medicineStock = new string[1000];
            //..........................................................Supplier realted declaration 

            string pathSupplier = "supplier.txt";
            int supplierCounter = 1;
            string[] supplierName = new string[1000];
            string[] suppliedMedicineName = new string[1000];
            string[] suppliedMedicineQuantity = new string[1000];
            int[] suppliedMedicinePrice = new int[1000];
            string[] suppliedmedicineStock = new string[1000];

            int option;
            bool check = false;
            int adminChoice;

            readDataMedicine(pathMedicine,  medicineCounter, medicineName, medicineQuantity, medicinePrice,  medicineStock);
            readDataSupplier(pathSupplier, supplierCounter, supplierName, suppliedMedicineName, suppliedMedicineQuantity, suppliedMedicinePrice,  suppliedmedicineStock);
            readDataWorer( pathWorker, workerCounter, workerName, workerPassword, workerSallary);
            readData(path, names, password);
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
                    check = signIn(n, p, names, password);
                    while (check == true)
                    {
                        adminChoice = adminFunctions();
                        if (adminChoice == 1)
                        {
                            Console.WriteLine("This menu is related to the check and balance of sales and profit management , and we are only makin the menu of admin so their is nothing to displayed here :)");
                        }
                        else if (adminChoice == 2)
                        {
                            addingMedicine(ref medicineCounter, medicineName, medicineQuantity, medicinePrice, medicineStock);
                            continue;
                        }
                        else if (adminChoice == 3)
                        {
                            removeMedicine(ref medicineCounter, medicineName, medicineQuantity, medicinePrice, medicineStock);
                            continue;
                        }
                        else if (adminChoice == 4)
                        {
                            updatingMedicinePrice(medicineCounter, medicineName, medicineQuantity, medicinePrice);
                            continue;
                        }
                        else if (adminChoice == 5)
                        {
                            stock(medicineCounter, medicineName, medicineQuantity, medicinePrice, medicineStock);
                            continue;
                        }
                        else if (adminChoice == 6)
                        {
                            supplierAnalytics(supplierCounter, supplierName, suppliedMedicineName, suppliedMedicineQuantity, suppliedMedicinePrice, suppliedmedicineStock);
                            continue;
                        }
                        else if (adminChoice == 7)
                        {
                            addSupplier(ref  supplierCounter,supplierName,suppliedMedicineName, suppliedMedicineQuantity,suppliedMedicinePrice, suppliedmedicineStock);
                            continue;
                        }
                        else if (adminChoice == 8)
                        {
                           
                            removeWorker(ref workerCounter, workerName, workerPassword, workerSallary);
                            continue;
                        }
                        else if (adminChoice == 9)
                        {
                            addWorker(ref workerCounter, workerName,  workerPassword, workerSallary);
                            continue;
                        }
                        else if (adminChoice == 10)
                        {
                            workerDetails(ref workerCounter, workerName, workerPassword, workerSallary);
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
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
                else if(option == 3)
                {
                    supplierSave( pathSupplier, supplierCounter, supplierName, suppliedMedicineName, suppliedMedicineQuantity, suppliedMedicinePrice, suppliedmedicineStock);
                    workerSave(pathWorker,  workerCounter,workerName, workerPassword, workerSallary);
                    medicineSave(pathMedicine,medicineCounter, medicineName,  medicineQuantity, medicinePrice, medicineStock);
                    Console.WriteLine("...........Data saved..........");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.Read();
                }
            } while (option < 3);
            Console.Read();
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

        static bool addingMedicine(ref int medicineCounter ,string[] medicineName , string[] medicineQuantity , int[] medicinePrice , string[] medicineStock)
        {
            string option = "1";
            while(option != "0")
            {
            Console.Clear();
                Console.WriteLine(" Enter Medicine name: ");
                medicineName[medicineCounter] = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Quantity (mg): ");
                medicineQuantity[medicineCounter] = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Price: ");
                medicinePrice[medicineCounter] = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter Medicine Counts/Stock: ");
                medicineStock[medicineCounter] = Console.ReadLine();
                medicineCounter++;
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
        
        static bool updatingMedicinePrice(int medicineCounter ,string[] medicineName , string[] medicineQuantity , int[] medicinePrice)
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
                for(int i = 0; i <= medicineCounter; i++)
                {
                    if (medicineName[i] == medicine && medicineQuantity[i] == quantity && medicinePrice[i] == price)
                    {
                        medicinePrice[i] = newprice;
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
        static bool stock(int medicineCounter ,string[] medicineName , string[] medicineQuantity , int[] medicinePrice , string[] medicineStock)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine("Medicine \t\t" + "mg \t\t\t" + "Price\t\t\t" + "stock");
                
                for(int i = 0; i < medicineCounter; i++)
                {
                    Console.WriteLine(medicineName[i] + "\t\t\t" + medicineQuantity[i] + "\t\t\t" + medicinePrice[i] + "\t\t\t" + medicineStock[i] + "\t\t\t");
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

        static bool supplierAnalytics(int medicineCounter, string[] supplierName , string[] suppliedMedicineName, string[] suppliedMedicineQuantity, int[] suppliedMedicinePrice, string[] suppliedMedicineStock)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine("Supplier \t\t" + "Medicine \t\t" + "mg \t\t\t" + "Price\t\t\t" + "stock");

                for (int i = 0; i < medicineCounter; i++)
                {
                    Console.WriteLine(supplierName[i] + "\t\t" + suppliedMedicineName[i] + "\t\t" + suppliedMedicineQuantity[i] + "\t\t" + suppliedMedicinePrice[i] + "\t\t" + suppliedMedicineStock[i] + "\t\t");

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

        static bool removeMedicine(ref int medicineCounter ,string[] medicineName , string[] medicineQuantity , int[] medicinePrice , string[] medicineStock)
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
                for(int i = 0; i <= medicineCounter; i++)
                {
                    if(medicineName[i] == medicine && medicineQuantity[i] == quantity && medicinePrice[i] == price && medicineStock[i] == stock)
                    {
                        for(int x = i; x < medicineCounter; x++)
                        {
                            medicineName[x] = medicineName[x + 1];
                            medicineQuantity[x] = medicineQuantity[x + 1];
                            medicinePrice[x] = medicinePrice[x + 1];
                            medicineStock[x] = medicineStock[x + 1];
                        }
                        medicineCounter--;
                        check = true;
                        break;
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

        static bool addSupplier(ref int supplierCounter, string[] supplierName, string[] suppliedMedicineName, string[] suppliedMedicineQuantity, int[] suppliedMedicinePrice, string[] suppliedMedicineStock)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine(" Enter Supplier name: ");
                supplierName[supplierCounter] = Console.ReadLine();
                Console.WriteLine(" Enter Medicine name: ");
                suppliedMedicineName[supplierCounter] = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Quantity (mg): ");
                suppliedMedicineQuantity[supplierCounter] = Console.ReadLine();
                Console.WriteLine(" Enter Medicine Price: ");
                suppliedMedicinePrice[supplierCounter] = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter Medicine Counts/Stock: ");
                suppliedMedicineStock[supplierCounter] = Console.ReadLine();
                supplierCounter++;
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

        static bool addWorker(ref int workerCount , string[] workerName, string[] workerPassword , string[] workerSalary)
        {
            string check = "1";
            
            while(check != "0")
            {
                Console.Clear();
                Console.WriteLine("Worker Name: ");
                workerName[workerCount] = Console.ReadLine();
                Console.WriteLine("Worker Password: ");
                workerPassword[workerCount] = Console.ReadLine();
                Console.WriteLine("Worker SALLARY: ");
                workerSalary[workerCount] = Console.ReadLine();
                workerCount++;
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

        static bool removeWorker(ref int workerCount , string[] workerName, string[] workerPassword, string[] workerSalary)
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
                for(int i = 0; i <= workerCount; i++)
                {
                    if (workerName[workerCount] == name  && workerPassword[workerCount] == workerPass)
                    {
                        for (int x = i; x < workerCount; x++)
                        {
                            workerName[x] = workerName[x + 1];
                            workerPassword[x] = workerPassword[x + 1];
                            workerSalary[x] = workerSalary[x + 1];
                        }
                        workerCount--;
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

        static void workerDetails(ref int workerCount, string[] workerName, string[] workerPassword, string[] workerSalary)
        {
            string option = "1";
            while (option != "0")
            {
            Console.Clear();
                Console.WriteLine("workerName \t " + "workerSalary \t\t");

                for (int i = 0; i < workerCount; i++)
                {

                    Console.WriteLine(workerName[i] + "\t\t"+workerSalary[i]);

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
            for (int i = 0; i < record.Length; i++)
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

        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                filevariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static bool signIn(string n, string p, string[] names, string[] password)
        {
        Console.Clear();
        bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == password[x])
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
        static void signUp(string path, string n, string p)
        {
        Console.Clear();
        StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static void medicineSave(string pathMedicine, int medicineCounter, string[] medicineName , string[] medicineQuantity, int[] medicinePrice, string[] medicineStock)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathMedicine, true);
            for(int i = 0; i < medicineCounter; i++)
            {
            file.WriteLine(medicineName[i] + "," + medicineQuantity[i] + "," + medicinePrice[i] + "," + medicineStock[i]);
            }
            file.Flush();
            file.Close();
        }
        static void workerSave(string pathWorker, int workerCounter, string[] workerName , string[] workerPassword, string[] workerSalary)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathWorker, true);
            for(int i = 0; i < workerCounter; i++)
            {
            file.WriteLine(workerName[i] + "," + workerPassword[i] + "," + workerSalary[i]);
            }
            file.Flush();
            file.Close();
        }
        static void supplierSave(string pathSupplier, int supplierCounter, string[] supplierName, string[] suppliedMedicineName, string[] suppliedMedicineQuantity, int[] suppliedMedicinePrice, string[] suppliedMedicineStock)
        {
            Console.Clear();
            StreamWriter file = new StreamWriter(pathSupplier, true);
            for(int i = 0; i < supplierCounter; i++)
            {
            file.WriteLine(supplierName[i] + "," + suppliedMedicineName[i] + "," + suppliedMedicineQuantity[i] + "," + suppliedMedicinePrice[i] + "," + suppliedMedicineStock[i] );
            }
            file.Flush();
            file.Close();
        }
        static void readDataMedicine(string pathMedicine, int medicineCounter, string[] medicineName, string[] medicineQuantity, int[] medicinePrice, string[] medicineStock)
        {
            int x = 0;
            StreamReader filevariable = new StreamReader(pathMedicine);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                medicineName[medicineCounter] = parseData(record, 1);
                medicineQuantity[medicineCounter] = parseData(record, 2);
                medicinePrice[medicineCounter] = int.Parse(parseData(record, 3));
                medicineStock[medicineCounter] = parseData(record, 4);
                medicineCounter++;
                x++;
                if (x >= 1000)
                {
                    break;
                }
            }
            filevariable.Close();
        }
        static void readDataSupplier(string pathSupplier, int supplierCounter, string[] supplierName, string[] suppliedMedicineName, string[] suppliedMedicineQuantity, int[] suppliedMedicinePrice, string[] suppliedMedicineStock)
        {
            int x = 0;
            StreamReader filevariable = new StreamReader(pathSupplier);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                supplierName[x] = parseData(record, 1);
                suppliedMedicineName[x] = parseData(record, 2);
                suppliedMedicineQuantity[x] = parseData(record, 3);
                suppliedMedicinePrice[x] = int.Parse(parseData(record, 4));
                suppliedMedicineStock[x] = parseData(record, 5);
                supplierCounter++;
                x++;
                if (x >= 1000)
                {
                    break;
                }
            }
            filevariable.Close();
        }
        static void readDataWorer(string pathWorker, int workerCounter, string[] workerName, string[] workerPassword, string[] workerSalary)
        {
            int x = 0;
            StreamReader filevariable = new StreamReader(pathWorker);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                workerName[x] = parseData(record, 1);
                workerPassword[x] = parseData(record, 2);
                workerSalary[x] = parseData(record, 3);
                workerCounter++;
                x++;
                if (x >= 5)
                {
                    break;
                }
            }
            filevariable.Close();
        }
    }
}

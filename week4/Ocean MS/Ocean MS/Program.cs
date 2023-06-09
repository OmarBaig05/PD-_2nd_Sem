using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ocean_MS
{
    class Program
    {
        //public class Angle
        //{
        //    public int degree;
        //    public float minutes;
        //    public char direction;

        //    public Angle(int degree, float minutes, char direction)
        //    {
        //        this.degree = degree;
        //        this.minutes = minutes;
        //        this.direction = direction;
        //    }
        //}

        //public class Ship
        //{
        //    public string code;
        //    public Angle latitude;
        //    public Angle longitude;

        //    public Ship(string code, Angle latitude, Angle longitude)
        //    {
        //        this.code = code;
        //        this.latitude = latitude;
        //        this.longitude = longitude;
        //    }
        //    public Ship( Angle latitude, Angle longitude)
        //    {
        //        this.latitude = latitude;
        //        this.longitude = longitude;
        //    }
        //    public Ship(string code)
        //    {
        //        this.code = code;
        //    }

        //    public string serialNumber(List<Ship> ship_list,Angle longitude,Angle latitude)
        //    {
        //        for (int i =0; i< ship_list.Count;i++)
        //        {
        //            int dL = ship_list[i].longitude.degree;
        //            float mL = ship_list[i].longitude.minutes;
        //            char diL = ship_list[i].longitude.direction;
        //            int dLt = ship_list[i].latitude.degree;
        //            float mLt = ship_list[i].latitude.minutes;
        //            char diLt = ship_list[i].latitude.direction;
        //            if (dL == longitude.degree && mL == longitude.minutes && diL == longitude.direction && dLt == latitude.degree && mLt == latitude.minutes && diLt == latitude.direction)
        //            {
        //                return ship_list[i].code;
        //            }
        //        }
        //        return null;
        //    }

        //    public Ship coordinates(List<Ship> ship_list, string number)
        //    {
        //        for (int i = 0; i < ship_list.Count; i++)
        //        {
        //            int d = ship_list[i].longitude.degree;
        //            float m = ship_list[i].longitude.minutes;
        //            char di = ship_list[i].longitude.direction;
        //            if (ship_list[i].code == number)
        //            {
        //               return ship_list[i];
        //            }
        //        }
        //        return null;
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    bool check = true;
        //    Ship s;

        //    List<Ship> ship_list = new List<Ship>();
        //    do
        //    {
        //        while (true)
        //        {

        //            int option = menu();

        //            if (option == 1)
        //            {
        //                s = addShip();
        //                addShipToList(ship_list, s);
        //            }
        //            else if (option == 2)
        //            {
        //                s = fetchObj(ship_list);
        //                shipPosition(s);
        //            }
        //            else if (option == 3)
        //            {
        //                Console.WriteLine("Serial number is :" + serialNumber(ship_list));
        //                Console.ReadKey();
        //            }
        //            else if (option == 4)
        //            {
        //                changeposition(ship_list);
        //                Console.WriteLine("Info updated");
        //                Console.ReadKey();
        //            }
        //            else if (option == 5)
        //            {
        //                break;
        //                check = false;
        //            }
        //            else
        //            {
        //                Console.Clear();
        //                Console.WriteLine("Invalid Input");
        //            }
        //        }
        //    } while (check == true);
        //}

        //static int menu()
        //{
        //    Console.Clear();
        //    Console.WriteLine("1.   Add ship");
        //    Console.WriteLine("2.   View ship position");
        //    Console.WriteLine("3.   View Ship serial number");
        //    Console.WriteLine("4.   Change Ship position");
        //    Console.WriteLine("5.   Exit");
        //    Console.WriteLine("Enter option");
        //    int option = int.Parse(Console.ReadLine());
        //    return option;
        //}
        //static Ship addShip()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Enter Ship Number:");
        //    string code = Console.ReadLine();
        //    //....................................  Latitude
        //    Console.WriteLine("");
        //    Console.WriteLine("Enter Ship latitude:");

        //    Console.WriteLine("Latitude degree:");
        //    int Latdegree = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Latitude minutes:");
        //    float Latmin = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Latitude direction: ");
        //    char Latdirection = char.Parse(Console.ReadLine());
        //    Angle latitude = new Angle(Latdegree, Latmin, Latdirection);

        //    //....................................  Longitude
        //    Console.WriteLine("");
        //    Console.WriteLine("Enter Ship Longitude:");

        //    Console.WriteLine("Longitude degree:");
        //    int Londegree = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Longitude minutes:");
        //    float Lonmin = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Longitude direction: ");
        //    char Londirection = char.Parse(Console.ReadLine());
        //    Angle longitude = new Angle(Londegree, Lonmin, Londirection);

        //    Ship shipDetail = new Ship(code, latitude, longitude);
        //    return shipDetail;
        //}
        //static void addShipToList(List<Ship> s, Ship obj)
        //{
        //    s.Add(obj);
        //}

        //static void shipPosition(Ship s)
        //{
        //    Console.WriteLine("Ship is at " + s.latitude.degree + "\u00b0" + s.latitude.minutes + "´" + s.latitude.direction + " and " + s.longitude.degree + "\u00b0" + s.longitude.minutes + "´" + s.longitude.direction);
        //    Console.ReadKey();
        //}

        //static string serialNumber(List<Ship> ship_list)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Enter Ship latitude:");

        //    Console.WriteLine("Latitude degree:");
        //    int Latdegree = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Latitude minutes:");
        //    float Latmin = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Latitude direction: ");
        //    char Latdirection = char.Parse(Console.ReadLine());
        //    Angle latitude = new Angle(Latdegree, Latmin, Latdirection);
        //    //....................................  Longitude
        //    Console.WriteLine("");
        //    Console.WriteLine("Enter Ship Longitude:");

        //    Console.WriteLine("Longitude degree:");
        //    int Londegree = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Longitude minutes:");
        //    float Lonmin = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Longitude direction: ");
        //    char Londirection = char.Parse(Console.ReadLine());
        //    Angle longitude = new Angle(Londegree, Lonmin, Londirection);
        //    Ship s = new Ship(latitude,longitude);
        //    string number = s.serialNumber(ship_list,longitude,latitude);
        //    return number;
        //}

        //static Ship fetchObj(List<Ship> ship_list)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Enter Ship serial Number:");
        //    string code = Console.ReadLine();
        //    Ship s = new Ship(code);
        //    s = s.coordinates(ship_list, code);
        //    return s;
        //}
        //static Ship changeposition(List<Ship> ship_list)
        //{
        //    Ship s = fetchObj(ship_list);
        //    Console.WriteLine("");
        //    Console.WriteLine("Enter Ship New latitude:");

        //    Console.WriteLine("Latitude degree:");
        //    int Latdegree = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Latitude minutes:");
        //    float Latmin = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Latitude direction: ");
        //    char Latdirection = char.Parse(Console.ReadLine());
        //    Angle latitude = new Angle(Latdegree, Latmin, Latdirection);

        //    //....................................  Longitude
        //    Console.WriteLine("");
        //    Console.WriteLine("Enter Ship New Longitude:");

        //    Console.WriteLine("Longitude degree:");
        //    int Londegree = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Longitude minutes:");
        //    float Lonmin = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Longitude direction: ");
        //    char Londirection = char.Parse(Console.ReadLine());
        //    Angle longitude = new Angle(Londegree, Lonmin, Londirection);

        //    s.latitude = latitude;
        //    s.longitude = longitude;
        //    return s;
        //}
        public class omar
        {
            public omar(string name)
            {
                Console.WriteLine("This is an Name: " + name);
            }
            public omar()
            {
                Console.WriteLine("Default parent: " );
            }
        }
        public class animal : omar
        {
            public animal(string name) : base(name)
            {
                Console.WriteLine("Name Called in Animals Class: ");
                name = "lol";
                Console.WriteLine(name);
            }
            public animal()
            {
                Console.WriteLine("Default child animal");
            }
        }
        class snake : animal
        {
            private string h;
            private string u;
            public snake (string name) : base (name)
            {
                Console.WriteLine("Snake Class: ");
            }
        }
        static void Main(string[] args)
        {
            omar item = new animal ("Chawal");
            Console.ReadLine();
        }
    }
}

using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public static int Count { get; private set; }

    public Person()
    {
        Count++;
    }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;

        Count++;
    }

    public void PrintPerson()
    {
        Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", FirstName, LastName, Age);
    }

    public static void PrintCount()
    {
        Console.WriteLine("Number of persons: {0}", Count);
    }
}

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms{get; set;}
}

public class Room
{
    [JsonPropertyName("roomId")]
    public string RoomId {get; set;}

    [JsonPropertyName("roomName")]
    public string RoomName {get; set;}

    [JsonPropertyName("capacity")]
    public int Capacity{get; set;}
}
public class ReservationHandler
{
    private List<Reservation> reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation)
    {
        try
        {
            reservations.Add(reservation);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }
    public void DeleteReservation(Reservation reservation)
    {
        try
        {
            reservations.Remove(reservation);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }

    public void DisplayWeeklySchedule()
    {
        try
        {
            foreach (var reservation in reservations)
            {
                Console.WriteLine("Reservation Time: {0}, Date: {1}, Reserver Name: {2}, Room: {3}",
                    reservation.Time, reservation.Date, reservation.ReserverName, reservation.Room.RoomName);
            }
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }
}

public class Reservation
{
    public DateTime Time { get; set; }
    public DateTime Date { get; set; }
    public string ReserverName { get; set; }
    public Room Room { get; set; }

    public Reservation(DateTime time, DateTime date, Person person, Room room)
    {
        try
        {
            Time = time;
            Date = date;
            ReserverName = person.FirstName;
            Room = room;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }
}




class Program
{
    static void Main()
    {
        // Kişileri oluştur
        Person person1 = new Person("Ali", "Yılmaz", 30);
        Person person2 = new Person("Ayşe", "Kara", 25);
        Person person3 = new Person("Mehmet", "Çelik", 40);

        // Oda bilgilerini oluştur
        Room room1 = new Room { RoomId = "101", RoomName = "Toplantı Odası 1", Capacity = 15 };
        Room room2 = new Room { RoomId = "102", RoomName = "Toplantı Odası 2", Capacity = 20 };
        Room room3 = new Room { RoomId = "103", RoomName = "Toplantı Odası 3", Capacity = 10 };

        // Rezervasyonları oluştur
        Reservation reservation1 = new Reservation(DateTime.Now.AddHours(2), DateTime.Today, person1, room1);
        Reservation reservation2 = new Reservation(DateTime.Now.AddHours(4), DateTime.Today, person2, room2);
        Reservation reservation3 = new Reservation(DateTime.Now.AddHours(6), DateTime.Today, person3, room3);

        // Rezervasyon yöneticisini oluştur ve rezervasyonları ekle
        ReservationHandler handler = new ReservationHandler();
        handler.AddReservation(reservation1);
        handler.AddReservation(reservation2);
        handler.AddReservation(reservation3);

        // Haftalık programı göster
        handler.DisplayWeeklySchedule();
    }
}



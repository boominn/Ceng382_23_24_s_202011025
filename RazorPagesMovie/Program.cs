using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms{get; set;}
}
public class Room
{
    [JsonPropertyName("roomId")]
    public string roomId {get; set;}

    [JsonPropertyName("roomName")]
    public string roomName {get; set;}

    [JsonPropertyName("capacity")]
    public int capacity{get; set;}
}

class Program
{
    static void Main(String[]args)
    {
        //define file path
        string filePath = "Data.json";

        //Read from json
        // 1 -> json to text // todo try catch 
        string jsonString = File.ReadAllText(filePath);
        // 2 -> decode text into meaningful classes
        var roomData = JsonSerializer.Deserialize<RoomData>(
                                jsonString, 
                                new JsonSerializerOptions()
        {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | 
                JsonNumberHandling.WriteAsString
        });

        //print
        if(roomData?.Rooms != null)
        {
            foreach (var room in roomData.Rooms)
            {
                Console.WriteLine($"Room ID : {room.roomId} RoomName : {room.roomName} Capacity : {room.capacity}");
            }
        }

    }
}

// See https://aka.ms/new-console-template for more informatiom

using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Xml;
using SocketClient;

List<Person> people = new List<Person>();

Person p1 = new Person("Robert", "Denior",23,165.00,true,'M',new string[]{"Ping-pong"});
Person p2 = new Person("Andrzej", "Dudu",39,170.00,true,'M',new string[]{"Politics","Horses"});
Person p3 = new Person("Adam", "Malysz",40,175.00,true,'M',new string[]{"Ski-Jumping"});

people.Add(p1);
people.Add(p2);
people.Add(p3);

using TcpClient client = new TcpClient("127.0.0.1", 5000);
using NetworkStream stream = client.GetStream();



HandleCommunication();



void HandleCommunication()
{


    StreamReader sReader = new StreamReader(stream, Encoding.ASCII);
    StreamWriter sWriter = new StreamWriter(stream, Encoding.ASCII);
    
    byte[] dataToServer = Encoding.ASCII.GetBytes("Hello from client");
    stream.Write(dataToServer, 0, dataToServer.Length);

    byte[] dataFromServer = new byte[1024];
    int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
    string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
    Console.WriteLine(response);

     
}

// if you want to receive anything
    
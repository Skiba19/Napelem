using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Napelem_API.Connection
{
    public class TCPConnection
    {
        private TcpListener listener;

        public void StartListening()
        {
            // Szerver IP címe és port száma
            IPAddress serverIpAddress = IPAddress.Loopback;
            int port = 12345;

            // IP cím és port szám alapján IPEndPoint létrehozása
            IPEndPoint endPoint = new IPEndPoint(serverIpAddress, port);

            // TCP szerver socket létrehozása
            listener = new TcpListener(endPoint);
            listener.Start();

            Console.WriteLine("Várakozás a kapcsolatra...");

            // Végtelen ciklus az új kapcsolatok figyelésére
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient(); // Új kliens kapcsolat fogadása
                Console.WriteLine("Kapcsolat létrejött.");

                // Új szál indítása a klienssel való kommunikációhoz
                Thread clientThread = new Thread(HandleClientCommunication);
                clientThread.Start(client);
            }
        }

        private void HandleClientCommunication(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length); // Adat fogadása a kliensről

                    if (bytesRead > 0)
                    {
                        string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.WriteLine("Kliens üzenete: " + data);

                        if (data == "Close connection")
                        {
                            stream.Close();
                            client.Close();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiba kezelése (pl. kapcsolat megszakadása)
                    Console.WriteLine("Hiba történt: " + ex.Message);
                    stream.Close();
                    client.Close();
                    break;
                }
            }

            Console.WriteLine("Kapcsolat lezárva.");
        }

        public void StopListening()
        {
            if (listener != null)
            {
                listener.Stop();
                Console.WriteLine("Szerver leállítva.");
            }
        }
    }
}

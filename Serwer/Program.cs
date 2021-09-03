
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class serv
{
    public static void Main()
    {
        try
        {
            IPAddress ipAd = IPAddress.Parse("192.168.1.107");
         
            TcpListener myList = new TcpListener(ipAd, 8001);

      
            myList.Start();

            Console.WriteLine("Serwer działa na porcie 8001...");
            Console.WriteLine("Lokalny punkt końcowy to :" +
                              myList.LocalEndpoint);
            Console.WriteLine("Oczekiwanie na połączenie.....");

            Socket s = myList.AcceptSocket();
            Console.WriteLine("Połączenie zaakceptowane od " + s.RemoteEndPoint);

            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Otrzymano...");
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("Ciąg został odebrany przez serwer."));
            Console.WriteLine("\nWysłane potwierdzenie");
           
            s.Close();
            myList.Stop();
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd..... " + e.StackTrace);
        }
    }

}

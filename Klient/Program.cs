using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;


public class clnt
{

    public static void Main()
    {

        try
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("łączenie .....");

            tcpclnt.Connect("192.168.1.107", 8001);
            

            Console.WriteLine("Połączono ");
            Console.Write("Wprowadź ciąg do przesłania : ");

            String str = Console.ReadLine();
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitowanie.....");

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(bb[i]));

            tcpclnt.Close();
            Console.ReadKey();
        }

        catch (Exception e)
        {
            Console.WriteLine("Błąd..... " + e.StackTrace);
        }
    }

}
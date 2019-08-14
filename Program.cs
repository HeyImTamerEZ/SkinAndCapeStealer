using System;
using System.IO;
using System.Net;

namespace SkinAndCapeStealer
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (!Directory.Exists(@"Result"))  Directory.CreateDirectory(@"Result");
            Console.WriteLine("[!] Choice\n1 - Optifine Cape Stealer\n2- Skin Stealer");
            int i = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            switch (i)
            {
                case 1:
                    OptifineCape(username);
                    break; 
                    
                case 2:
                    Skin(username);
                    break;
            }
        }

        public static void OptifineCape(string username)
        {
            string saveLocation = $@"Result\{username}_Cape.png";
            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create($"http://s.optifine.net/capes/"+username+".png");
            WebResponse imageResponse = imageRequest.GetResponse();

            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream ))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }
        public static void Skin(string username)
        {
            string saveLocation = $@"Result\{username}_Skin.png";
            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create($"https://minotar.net/skin/"+username);
            WebResponse imageResponse = imageRequest.GetResponse();

            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream ))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Threading;
using static System.Console; 


namespace Dz_20_File2
{
    class Program
    {
        static void Main(string[] args)
        {
            File f = new File();
            int choise = 0;
            int flag = 0;

            while (flag == 0)
            {
                //Thread.Sleep(1000);
                Clear();
                WriteLine("1. Day17\n2. YourFile\n3. Выход");
                choise = Convert.ToInt32(ReadLine());

                switch (choise)
                {
                    case 1: f.OpenFile(1); 
                        break;
                    case 2:
                        {
                            f.NewFile();
                            if (f.CheckFile() == true) f.OpenFile(2);
                            else  WriteLine("try again");
                        }
                        break;
                    case 3: flag++;
                        break;
                    default:
                        break;
                } 
            }  
        }
    }

    class File
    {
        string fileN = "Day17.txt";
        string Name { get; set; }
        int[,] a = new int[3, 3];
        double[,] b = new double[3, 3];

        public void NewFile()
        {
            WriteLine("Введите путь к файлу: ");
            Name = ReadLine(); 
        }

        public bool CheckFile()
        {
            try
            { 
                StreamReader sr = new StreamReader(Name, Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return false;
            }
        }

        public void OpenFile(int i)
        {
            StreamWriter sw;

            if (i == 1) sw = new StreamWriter(fileN, true);
            else sw = new StreamWriter(Name, true);

            Clear();
            string line;
            Write("Имя? ");
            line = ReadLine();
            sw.WriteLine("Имя " + line);
            Write("Дата? ");
            line = ReadLine();
            sw.WriteLine("Дата " + line);
            RadnomMasInt();
            RadnomMasDouble();

            int ch = 0;
            WriteLine("1. Мартица\n2. С новой строки\n3. В строку ");
            ch = Convert.ToInt32(ReadLine());


            switch (ch)
            {
                case 1:
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int j = 0; j < 3; j++)
                                sw.Write(a[x, j] + "\t");
                            sw.WriteLine();
                        }

                        for (int x = 0; x < 3; x++)
                        {
                            for (int j = 0; j < 3; j++)
                                sw.Write(b[x, j] + "\t");
                            sw.WriteLine();
                        }
                    }
                    break;
                case 2:
                    {
                        for (int x = 0; x < 3; x++)
                            for (int j = 0; j < 3; j++)
                                sw.WriteLine(a[x, j]);  

                        for (int x = 0; x < 3; x++)
                            for (int j = 0; j < 3; j++)
                                sw.WriteLine(b[x, j]);  
                    }
                    break;
                case 3:
                    {
                        for (int x = 0; x < 3; x++)
                            for (int j = 0; j < 3; j++)
                                sw.Write(a[x, j] + " ");
                        sw.WriteLine();
                        for (int x = 0; x < 3; x++)
                            for (int j = 0; j < 3; j++)
                                sw.Write(b[x, j] + " ");
                    }
                    break;
                default:
                    break;
            }

            
            sw.Close();
        } 
        
        public void RadnomMasInt()
        {
            Random r = new Random();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++) 
                    a[i, j] = r.Next();  
        }

        public void RadnomMasDouble()
        {
            Random r = new Random();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    b[i, j] = r.NextDouble();
        }
    } 
}
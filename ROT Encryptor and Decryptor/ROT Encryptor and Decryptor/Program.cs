using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ROT_Encryptor_and_Decryptor
{
    class input
    {
        static int method=0;
        public static int opt = 0;
        string originaltext;
        int[] arr;

        public input(int op, int o)
        {
            if (op >= 1 && op <= 25)
            {
                opt = op;
                method = o;
            }
            else
            {
                Console.WriteLine("Please choose number between 1 to 25");
            }
        }

        public input(string text)
        {
            originaltext = text;
            int size = text.Count();
            arr = new int[size];

            for (int i = 0; i < text.Length; i++)
            {
                arr[i] = (text[i]);
            }


            // Converting for encrypt
            if (method == 1)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= 65 && arr[i] <= 90 || arr[i] >= 97 && arr[i] <= 122)
                    {
                        
                        if ( arr[i] - opt == arr[i] - opt && arr[i] <= 122-opt)
                        {
                            arr[i] += opt;
                        }
                        else if (arr[i] >= 90 && arr[i] <= 122)
                        {
                            arr[i] -= 26;
                            arr[i] += opt;
                        }
                        

                    }
                }
            }

            // Converting for decrypt
            else if (method == 2)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= 65 && arr[i] <= 90 || arr[i] >= 97 && arr[i] <= 122)
                    {
                        if (arr[i] + opt == arr[i] + opt && arr[i] > 122 - opt)
                        {
                            arr[i] -= opt;
                        }
                        else if (arr[i] >= 90 && arr[i] <= 122)
                        {
                            arr[i] += 26;
                            arr[i] -= opt;
                        }
                    }
                }
            }

            FileStream fs = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string outputsave = "";

            // Original text
            Console.WriteLine("Orginal text (Input)\n\n");
            Console.WriteLine(originaltext+"\n\n\n");
            Console.WriteLine("________________________________________________________________________________\n\n");

            // Output
            Console.WriteLine("Result (Output)\n\n");
            for (int i = 0; i < arr.Length; i++)
            {
                outputsave += (char)arr[i];

                Console.Write((char)arr[i]);
            }
            Console.WriteLine("\n\n\n");

            // Save output in txt file
            for (int j = 0; j < outputsave.Length; j++)
            {
                fs.WriteByte((byte)outputsave[j]);
            }
            

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Press 1 for Encrypt\nPress 2 for Decrypt\n\n");
                int o = int.Parse(Console.ReadLine());
                Console.Clear();


                Console.WriteLine("Choose ROT 1 to 25\n pick a number");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                input obj = new input(option, o);


                if (input.opt != 0)
                {
                    string usr="";
                    Console.WriteLine("press 1 for enter text\nPress 2 for access from txt file");
                    int ai = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (ai == 1)
                    {
                        Console.WriteLine("Enter your text");
                        usr = Console.ReadLine().ToLower();
                        input user = new input(usr);
                    }
                    else if(ai==2)
                    {
                        FileStream fa = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                        for (int i = 0; i < fa.Length; i++)
                        {
                            usr += Convert.ToString((char)(fa.ReadByte()));
                        }
                        input user = new input(usr);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROT_Encryptor_and_Decryptor
{
    class input
    {
        static int method=0;
        public static int opt = 0;
        string usertxt;
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
            int size = text.Count();
            arr = new int[size];

            for (int i = 0; i < text.Length; i++)
            {
                arr[i] = (text[i]);
            }


            // Converting for encrypt
            if (method == 1)
            {
                //int temp;
                //int less;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= 65 && arr[i] <= 90 || arr[i] >= 97 && arr[i] <= 122)
                    {
                        //temp = arr[i];

                        arr[i] += opt;

                        //if(arr[i] > 90 )
                        //{
                        //    less = arr[i]-25;
                        //    Console.WriteLine("agay "+less);
                        //}

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
                        arr[i] -= opt;
                    }
                }
            }

            // Out put
            Console.WriteLine("Output \n\n");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write((char)arr[i]);
            }
            Console.WriteLine("\n");

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
                    Console.WriteLine("Enter your text");
                    string usr = Console.ReadLine();
                    input user = new input(usr);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}


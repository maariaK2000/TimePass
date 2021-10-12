using System;
using System.Collections.Generic;

namespace Hungary
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> min = new List<int>();
            List<int> colmin = new List<int>();
            int mymin = 100;
            int[,] myempjob =
            {
                {13,8,16,18,19 },
                {9,15,24,9,12 },
                {12,9,4,4,4 },
                {6,12,10,8,13 },
                {15,17,18,12,20 },
            };
            int[,] myrowreduced =new int[5, 5];
            int[,] mycolreduced = new int[5, 5];

            //Dis is used for retrieving min from each row nd stored in list of min
            for (int i = 0; i < myempjob.GetLength(0); i++)
            {
                for (int j = 0; j < myempjob.GetLength(0); j++)
                {
                    //mymin = myempjob[i, j];
                    if (myempjob[i, j] < mymin)
                    {
                        mymin = myempjob[i, j];
                    }
                    
                }
                min.Add(mymin);
                mymin = 100;
            }
            foreach(var e in min)
            {
                Console.WriteLine(e);

            }
            
            //Now we subtract min from each row with each entry of that specific row
            for (int i = 0; i < myempjob.GetLength(0); i++)
            {
                for (int j = 0; j < myempjob.GetLength(0); j++)
                {
                    myrowreduced[i, j] = myempjob[i, j] - min[i];
                    Console.Write(myrowreduced[i,j]+" ");
                }
                Console.WriteLine();

            }
            //Dis is used for retrieving min from each column nd stored in list of colmin
            mymin = 100;
            for(int i = 0; i < myrowreduced.GetLength(0); i++)
            {
                for (int j = 0; j < myrowreduced.GetLength(0); j++)
                {
                    if (myrowreduced[j, i] < mymin)
                    {
                        mymin = myrowreduced[j, i];

                    }
                   
                }
                colmin.Add(mymin);
                mymin = 100;
            }
            //colmin values
            foreach (var e in colmin)
            {
                Console.WriteLine(e);

            }

            //Now we subtract min from each column with each entry of that specific column
            for (int i = 0; i < myrowreduced.GetLength(0); i++)
            {
                for (int j = 0; j < myrowreduced.GetLength(0); j++)
                {
                    mycolreduced[j, i] = myrowreduced[j, i] - colmin[i];
                    Console.Write(mycolreduced[j, i] + " ");
                }
                Console.WriteLine();

            }





        }
    }
}

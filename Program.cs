using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace KillerSDK
{
    internal class Program
    {
        public class SoudookuLine
        {
            public string s;
            public int[,]solveGrid  = new int[9, 9]; 
            
        }

        static void InitGrid(ref int[,] grid)
        {
            
            for (int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {                    
                    grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                   
                }
               
            }
                        
        }
        static void DebugGrid(ref int[,] grid)
        {
            string s;
            int sep = 0;
            s = null;
            for(int i=0;i<9;i++)
            {
                s += "｜";
                for(int j=0;j<9;j++)
                {
                    s += grid[i, j].ToString();

                    sep = j % 3;
                    if (sep == 2)
                    {
                        s+= "｜";
                    }
                }         
                s += "\n";
            }
            Console.WriteLine(s);
            
        }
        static void ShuffleNum(ref int[,] grid, int shuffleAmount)
        {
            Random random= new Random();
            for(int i = 0; i<shuffleAmount;i++)
            {
                int rnd1 =random.Next(1, 10);
                int rnd2 =random.Next(1, 10);
                
                
                MixTwoGridCells(ref grid,rnd1, rnd2);
            }
            
            DebugGrid(ref grid);


        }
        static void MixTwoGridCells(ref int[,] grid, int value1,int value2)
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            for(int i=0; i<9;i+=3)
            {
                for(int j=0;j<9;j+=3)
                {
                    for (int k=0;k<3; k++)
                    {
                        for (int l=0;l<3;l++)
                        {
                            if (grid[i+k,j+l]==value1)
                            {
                                x1 = i+k;
                                y1 = j+l;
                            }
                            if (grid[i+k,j+l]==value2)
                            {
                                x2 = i+k;
                                y2 = j+l;
                            }
                        }
                    }
                    grid[x1, y1] = value2;
                    grid[x2, y2] = value1;
                }
            }
            
        }


        
        static void Main(string[] args)
        {
            //SudoukoNum(); // 한줄생성
            int[,]solveGrid = new int[9,9 ];
            //InitGrid(ref solveGrid);
            InitGrid(ref solveGrid);
            DebugGrid(ref solveGrid);
            ShuffleNum(ref solveGrid,25); 
            //ShuffleNum(ref solveGrid, 1);
            //SDKfour();
        }
        static void SudoukoNum() // 난수 생성 한줄
        {
            bool[] used = new bool[10];
            Random rnd = new Random();

            int count = 0;
            while (count < 9)
            {

                int number = rnd.Next(1, 10);


                if (used[number] == false)
                {
                    Console.Write(number + " ");
                    used[number] = true;
                    count++;
                }

            }
            Console.WriteLine();
        }
        //static void SDKfour()
        //{
        //    bool[] used = new bool[5];
        //    bool[] used2 = new bool[5];
        //    Random rnd = new Random();
        //    Random rnd2 = new Random();

        //    int number = 0;
        //    int number2 = 0;
        //    int count = 0;
        //    int count2 = 0;
        //    while (count < 4)
        //    {

        //        number = rnd.Next(1, 5);
        //        if (used[number] == false)
        //        {
        //            Console.Write(number + " ");
        //            used[number] = true;
        //            count++;
                    
        //        }

        //    }
        //    Console.WriteLine();
        //    while(count2<4)
        //    {
        //        number2 = rnd2.Next(1, 5);
        //        if (used2[number2] == false)
        //        {
        //            Console.Write(number2 + " ");
        //            used2[number2] = true;
                    
        //        }
        //        if (used2[number2] == used[number])
        //        {
        //            count++;
        //        }
        //    }

           
        //}

           

        
            
        
        
    }
}

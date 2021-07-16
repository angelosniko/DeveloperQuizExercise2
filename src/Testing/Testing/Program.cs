using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
    



            int[][] goodSudoku1 = {
               new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5  },
                new int[] {3,5,7,  8,4,6  },
                new int[] {4,6,1,  9,2,3  },

                new int[] {8,7,6,  2,1},
                new int[] {2,4,3,  5,9},
                new int[] {1,9,5,  2,8,7}
    };

            //Check for row 
            bool _resultRow = false;
            for (int i = 0; i < goodSudoku1.Length; i++)
            {
                var query = goodSudoku1[i].OrderBy(x => x).Distinct().ToArray();

                HashSet<int> myHashSet = new HashSet<int>();

                for (int j = 0; j < query.Length; j++)
                {
                    if (query[j] > query.Length || query[j] <= 0) { _resultRow = false; }
                    else
                    {
                        myHashSet.Add(query[j]);
                    }
                }

                var nRow = myHashSet.Count;

                if (nRow < query.Length)
                {
                    _resultRow = false;
                    break;

                }
                else if (nRow == query.Length) { _resultRow = true; }
            }



            // check column 
            bool boolcol = false;
            HashSet<int> myHashSetCol = new HashSet<int>();


            int sum = 0;
            int factorial = 0;

            for (int i = 1; i < goodSudoku1.Length + 1; i++)
            {
                factorial += i;
            }



            for (int i = 0; i < goodSudoku1.Length; i++)
            {
                for (int j = 0; j < goodSudoku1.Length; j++)
                {
                    if (goodSudoku1[j][i] > 0 && goodSudoku1[j][i] <= goodSudoku1.Length) { myHashSetCol.Add(goodSudoku1[j][i]); }
                    myHashSetCol.Add(goodSudoku1[j][i]);

                }

                int countvalue = myHashSetCol.Count;
                //Console.WriteLine(sum);
                if (countvalue == goodSudoku1.Length)
                {
                    myHashSetCol.Clear();
                    boolcol = true;

                }
                else
                {

                    boolcol = false;
                    break;

                }
            }






            


            ///// cube 
            ///// 
            HashSet<int> Hashsetcell = new HashSet<int>();

            bool _resultCube = false;
            bool _resultCube1 = false;
            bool _resultCube2 = false;
            bool _resultCube3 = false;
            int len = (int)Math.Sqrt(goodSudoku1.Length);


            if (goodSudoku1.Length == 9)
            {

                ////check first column cell


                for (int k = 0; k < goodSudoku1.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = 0; j < len; j++)
                        {
                            if (goodSudoku1[j][i] > 0 && goodSudoku1[j][i] <= goodSudoku1.Length) { Hashsetcell.Add(goodSudoku1[j][i]); }
                            Hashsetcell.Add(goodSudoku1[j][i]);
                        }



                    }




                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == goodSudoku1.Length)
                    {
                        Hashsetcell.Clear();
                        _resultCube1 = true;

                    }
                    else
                    {

                        _resultCube1 = false;
                        break;

                    }




                }




                //////check cell column 2  






                for (int k = 0; k < goodSudoku1.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = len; j < len * 2; j++)
                        {
                            try
                            {
                                if (goodSudoku1[j][i] > 0 && goodSudoku1[j][i] <= goodSudoku1.Length) { Hashsetcell.Add(goodSudoku1[j][i]); }
                                Hashsetcell.Add(goodSudoku1[j][i]);

                            }
                            catch {

                               
                            }

                        }



                    }



                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == goodSudoku1.Length)
                    {
                        Hashsetcell.Clear();
                        _resultCube2 = true;

                    }
                    else
                    {

                        _resultCube2 = false;
                        break;

                    }



                }





                //    //////check column 3 for cell 


                for (int k = 0; k < goodSudoku1.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = len * 2; j < len * 3; j++)
                        {
                            try
                            {
                                if (goodSudoku1[j][i] > 0 && goodSudoku1[j][i] <= goodSudoku1.Length) { Hashsetcell.Add(goodSudoku1[j][i]); }
                                Hashsetcell.Add(goodSudoku1[j][i]);


                            }

                            catch {

                    
                            }
                          
                        }



                    }





                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == goodSudoku1.Length)
                    {
                        Hashsetcell.Clear();
                        _resultCube3 = true;

                    }
                    else
                    {

                        _resultCube3 = false;
                        break;
                    }



                }


               


                if (_resultCube3 && _resultCube2 && _resultCube1)
                {


                    _resultCube = true;

                }
                else { _resultCube = false; }




            }
            else {

                ////check first column cell


                for (int k = 0; k < goodSudoku1.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = 0; j < len; j++)
                        {
                            if (goodSudoku1[j][i] > 0 && goodSudoku1[j][i] <= goodSudoku1.Length) { Hashsetcell.Add(goodSudoku1[j][i]); }
                            Hashsetcell.Add(goodSudoku1[j][i]);
                        }



                    }




                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == goodSudoku1.Length)
                    {
                        Hashsetcell.Clear();
                        _resultCube1 = true;

                    }
                    else
                    {

                        _resultCube1 = false;
                        break;

                    }




                }
       




                //////check cell column 2  






                for (int k = 0; k < goodSudoku1.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = len; j < len * 2; j++)
                        {
                            try
                            {
                                if (goodSudoku1[j][i] > 0 && goodSudoku1[j][i] <= goodSudoku1.Length) { Hashsetcell.Add(goodSudoku1[j][i]); }
                                Hashsetcell.Add(goodSudoku1[j][i]);
                            }
                            catch {

                                Console.WriteLine("");

                            }


                        }



                    }



                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == goodSudoku1.Length)
                    {
                        Hashsetcell.Clear();
                        _resultCube2 = true;

                    }
                    else
                    {

                        _resultCube2 = false;
                        break;

                    }



                }


                if ( _resultCube2 && _resultCube1)
                {


                    _resultCube = true;

                }
                else { _resultCube = false; }






            }








            if (_resultCube && _resultRow && boolcol)
            {


                Console.WriteLine("Valid Sudoku");


            }
            else
            {
                Console.WriteLine("Not Valid Sudoku");
            }














        }
    }

}

            


        




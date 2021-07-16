/*
 * Given a Sudoku data structure with size NxN, N > 0 and vN == integer, write a method to validate if it has been filled out correctly.
 * The data structure is a multi-dimensional Array, ie:

    [
      [7,8,4,  1,5,9,  3,2,6],
      [5,3,9,  6,7,2,  8,4,1],
      [6,1,2,  4,3,8,  7,5,9],

      [9,2,8,  7,1,5,  4,6,3],
      [3,5,7,  8,4,6,  1,9,2],
      [4,6,1,  9,2,3,  5,8,7],

      [8,7,6,  3,9,4,  2,1,5],
      [2,4,3,  5,6,1,  9,7,8],
      [1,9,5,  2,8,7,  6,3,4]
    ]


 * Rules for validation

 * Data structure dimension: NxN where N > 0 and vN == integer
 * Rows may only contain integers: 1..N (N included)
 * Columns may only contain integers: 1..N (N included)
 * 'Little squares' (3x3 in example above) may also only contain integers: 1..N (N included)

 * taken from http://www.codewars.com/kata/540afbe2dc9f615d5e000425/train/javascript
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };

            Debug.Assert(ValidateSudoku(goodSudoku1), "This is supposed to validate! It's a good sudoku!");
            Debug.Assert(ValidateSudoku(goodSudoku2), "This is supposed to validate! It's a good sudoku!");
            Debug.Assert(!ValidateSudoku(badSudoku1), "This isn't supposed to validate! It's a bad sudoku!");
            Debug.Assert(!ValidateSudoku(badSudoku2), "This isn't supposed to validate! It's a bad sudoku!");
        }


        public static bool ValidateRow(int[][] puzzle)
        {

            bool _resultRow = false;
            for (int i = 0; i < puzzle.Length; i++)
            {
                var query = puzzle[i].OrderBy(x => x).Distinct().ToArray();

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


                }
                else if (nRow == query.Length) { _resultRow = true; }

            }
            return _resultRow;
        }

        public static bool ValidateColumn(int[][] puzzle)
        {
            // check column 
            bool boolcol = false;
            HashSet<int> myHashSetCol = new HashSet<int>();
            int sum = 0;
            int factorial = 0;

            for (int i = 1; i < puzzle.Length + 1; i++)
            {
                factorial += i;
            }

            for (int i = 0; i < puzzle.Length; i++)
            {
                for (int j = 0; j < puzzle.Length; j++)
                {
                    if (puzzle[j][i] > 0 && puzzle[j][i] <= puzzle.Length) { myHashSetCol.Add(puzzle[j][i]); }
                    myHashSetCol.Add(puzzle[j][i]);
                }

                int countvalue = myHashSetCol.Count;
                //Console.WriteLine(sum);
                if (countvalue == puzzle.Length)
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

            return boolcol;
        }


        public static bool ValidateCell(int[][] puzzle)
        {

            ///// cube 
            ///// 
            HashSet<int> Hashsetcell = new HashSet<int>();

            bool _resultCube = false;
            bool _resultCube1 = false;
            bool _resultCube2 = false;
            bool _resultCube3 = false;
            int len = (int)Math.Sqrt(puzzle.Length);


            if (puzzle.Length == 9)
            {
                ////check first column cell

                for (int k = 0; k < puzzle.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = 0; j < len; j++)
                        {
                            try
                            {
                                if (puzzle[j][i] > 0 && puzzle[j][i] <= puzzle.Length) { Hashsetcell.Add(puzzle[j][i]); }
                                Hashsetcell.Add(puzzle[j][i]);
                            }
                            catch { }

                        }
                    }
                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == puzzle.Length)
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

                for (int k = 0; k < puzzle.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = len; j < len * 2; j++)
                        {
                            try
                            {
                                if (puzzle[j][i] > 0 && puzzle[j][i] <= puzzle.Length) { Hashsetcell.Add(puzzle[j][i]); }
                                Hashsetcell.Add(puzzle[j][i]);

                            }
                            catch { }



                        }
                    }

                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == puzzle.Length)
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


                for (int k = 0; k < puzzle.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = len * 2; j < len * 3; j++)
                        {
                            try
                            {
                                if (puzzle[j][i] > 0 && puzzle[j][i] <= puzzle.Length) { Hashsetcell.Add(puzzle[j][i]); }
                                Hashsetcell.Add(puzzle[j][i]);
                            }

                            catch { }

                        }

                    }

                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == puzzle.Length)
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
            else
            {

                ////check first column cell


                for (int k = 0; k < puzzle.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = 0; j < len; j++)
                        {
                            try
                            {
                                if (puzzle[j][i] > 0 && puzzle[j][i] <= puzzle.Length) { Hashsetcell.Add(puzzle[j][i]); }
                                Hashsetcell.Add(puzzle[j][i]);
                            }

                            catch { }

                        }

                    }

                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == puzzle.Length)
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

                for (int k = 0; k < puzzle.Length; k = k + len)
                {
                    for (int i = k; i < k + len; i++)
                    {
                        for (int j = len; j < len * 2; j++)
                        {
                            try
                            {
                                if (puzzle[j][i] > 0 && puzzle[j][i] <= puzzle.Length) { Hashsetcell.Add(puzzle[j][i]); }
                                Hashsetcell.Add(puzzle[j][i]);
                            }
                            catch
                            {


                            }

                        }
                    }



                    int countvalue = Hashsetcell.Count;
                    //Console.WriteLine(sum);
                    if (countvalue == puzzle.Length)
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

                if (_resultCube2 && _resultCube1)
                {

                    _resultCube = true;

                }
                else { _resultCube = false; }

            }

            return _resultCube;

        }

        static bool ValidateSudoku(int[][] puzzle)
        {

            if (ValidateRow(puzzle) && ValidateColumn(puzzle) && ValidateCell(puzzle)) { return true; }
            else
            {

                return false;

            }

        }
    }
}
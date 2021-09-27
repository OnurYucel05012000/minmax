using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Game
    {
        //BOARD 
        //2D Array to 1D
        //array1D[i*c+j]

        
        

        static char[] Board = new char[9];
        bool sira = true;
        int Xwin, Owin;

        public Game()
        {          
            Init();
        }
        public void Init()
        {
            Clear();
        }
        public int getOwin()
        {
            return Owin;
        }
        public int getXwin()
        {
            return Xwin;
        }
        public void Custom_game()
        {
            Board[0] = 'X'; Board[1] = 'O'; Board[2] = 'X';
            Board[3] = 'O'; Board[4] = 'a'; Board[5] = 'a';
            Board[6] = 'a'; Board[7] = 'a'; Board[8] = 'O';
            
        }
        public void Start()
        {
            int i = -1;
            Clear();
           // Custom_game();
            while (i < 9)
            {

                Draw();
                
                if (CheckBoard(Board) == 'X')
                {
                    Xwin++;
                    Console.WriteLine("X kazandi");
                    break;
                }else if (CheckBoard(Board) == 'O')
                {
                    Owin++;
                    Console.WriteLine("O kazandi");
                    break;
                }
                if (!CheckGameState()) { break;}
                input();

                i++;
            }
            Draw();
            Console.WriteLine(i);
        }
        public void Clear()
        {
            for(int i = 0; i < 9; i++)
            {
                Board[i] = 'a';
            }
        }
        public void Draw()
        {
           // Console.SetCursorPosition(0, 0);
            for(int i = 0; i < 9; i++)
            {
                    Console.Write(Board[i]);
                    Console.Write("|");

                if ((i+1)% 3 == 0) {
                    Console.WriteLine();
                    Console.WriteLine("------");
                }
            }

        }
        public void input()
        {
            int i;

            if (sira)
            {


                Console.WriteLine("X player");

                //X player i,j input
                //Console.WriteLine("i");
                //i = Convert.ToInt16(Console.ReadLine());

                //i = Convert.ToInt16(randomplayer());

                MinMax1D mM = new MinMax1D();
                i = mM.Run(0, Board, 'X');
                Board[i] = 'X';
                //Console.WriteLine("O played at : " + index);


                Board[i] = 'X';
                sira = false;
            }
            else
            {
                Console.WriteLine("O player");
                /*
                //Y player i,j input
                Console.WriteLine("i");
                i = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("j");
                j = Convert.ToInt16(Console.ReadLine());
                */

                MinMax1D mM = new MinMax1D();
                i = mM.Run(0, Board, 'O');

                // i = Convert.ToInt16(randomplayer());

                Board[i] = 'O';
                Console.WriteLine("O played at : " + i);

                sira = true;
            }

        }
        
        //input
        private int randomplayer()
        {
            Random rnd = new Random();
            int r = rnd.Next(9);
            while (true)
            {
                
                if (Board[r] == 'a') break;
                r = rnd.Next(9);

            }
            return r;
        }
        public static bool CheckGameState()
        {
            for(int i = 0; i < 9; i++)
            {
                if (Board[i] == 'a')
                {
                    return true;
                }
            }return false;
        }
        public static char CheckBoard(char[] board)
        {
            //---X--//
            //---Yatay--//
            if (board[0]=='X' && board[1]=='X' && board[2]=='X') { return 'X'; }
            else if(board[3] == 'X' && board[4] == 'X' && board[5] == 'X') { return 'X'; }
            else if (board[6] == 'X' && board[7] == 'X' && board[8] == 'X') { return 'X'; }
            //---Dusey--//
            if (board[0] == 'X' && board[3] == 'X' && board[6] == 'X') { return 'X'; }
            else if (board[1] == 'X' && board[4] == 'X' && board[7] == 'X') { return 'X'; }
            else if (board[2] == 'X' && board[5] == 'X' && board[8] == 'X') { return 'X'; }
            //---Capraz--//
            if (board[0] == 'X' && board[4] == 'X' && board[8] == 'X') { return 'X'; }
            else if (board[2] == 'X' && board[4] == 'X' && board[6] == 'X') { return 'X'; }

            //---O--//
            //---Yatay--//
           
            if (board[0] == 'O' && board[1] == 'O' && board[2] == 'O') { return 'O'; }
            else if (board[3] == 'O' && board[4] == 'O' && board[5] == 'O') { return 'O'; }
            else if (board[6] == 'O' && board[7] == 'O' && board[8] == 'O') { return 'O'; }
            //---Dusey--//

            if (board[0] == 'O' && board[3] == 'O' && board[6] == 'O') { return 'O'; }
            else if (board[1] == 'O' && board[4] == 'O' && board[7] == 'O') { return 'O'; }
            else if (board[2] == 'O' && board[5] == 'O' && board[8] == 'O') { return 'O'; }
            //---Capraz--//
            if (board[0] == 'O' && board[4] == 'O' && board[8] == 'O') { return 'O'; }
            else if (board[2] == 'O' && board[4] == 'O' && board[6] == 'O') { return 'O'; }

            return '*';
        }
        
    }//class
}//namespace

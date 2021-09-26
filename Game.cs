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
        int test = 0;

        public Game()
        {          
            Init();
        }
        public void Init()
        {
            Clear();
        }

        public void Custom_game()
        {
            Board[0] = 'O'; Board[1] = 'O'; Board[2] = 'X';
            Board[3] = 'a'; Board[4] = 'a'; Board[5] = 'O';
            Board[6] = 'a'; Board[7] = 'X'; Board[8] = 'X';
            
        }
        public void Start()
        {
            int i = 0;
            Custom_game();
            while (i < 9)
            {

                Draw();
                input();
                if (CheckBoard(Board) == 'X')
                {
                    Console.WriteLine("X kazandi");
                    break;
                }else if (CheckBoard(Board) == 'O')
                {
                    Console.WriteLine("O kazandi");
                    break;
                }
                if (!CheckGameState()) { break;}
                
                
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
            short i;

            if (sira)
            {
                
                
                    Console.WriteLine("X player");

                    //X player i,j input
                    Console.WriteLine("i");
                    i = Convert.ToInt16(Console.ReadLine());


                

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
                int index = mM.Run(0, Board, 'O');
                Board[index] = 'O';
                Console.WriteLine("O played at : " + index);

                sira = true;
            }
            
        }//input
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

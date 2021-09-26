using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MinMax1D
    {
        public MinMax1D()
        {

        }
        public int Run(int depth, char[] board, char MaximumPlayer)
        {
            int bestscore = 0, score = 0;
            int i = 0;
            int index = -1;
            for (; i < 9; i++)
            {
                //alan bossa
                //maksimum oyuncuyu koy
                if (board[i] == 'a')
                {
                    //RUN
                    board[i] = MaximumPlayer;

                    
                                          
                        score = minimax(0, board, false);
                        if (score >= bestscore)
                        {
                            bestscore = score;
                            index = i;
                        }
                    
                    board[i] = 'a';
                }
            }//for i end
            
            return index;
        }//method end
    
        //Bos alan varsa oyunu bir taraf kazanmadikca oyuna devam et
        private bool checkgame(char[] board)
        {
            
            for(int i = 0; i < 9; i++)
            {
                if (board[i] == 'a') return false;
            }
            //Oyun bittiyse
            return true;
        }

        //True O false X olsun
        private int minimax(int depth,char[] board,bool siradaki)
        {
            int score;

            //Bos yer varmi?
            //eger bos yer yoksa oyun berabere demek
            char a = Game.CheckBoard(board);
            if(a =='*')return 0;
            if (a == 'O') return 1;
            else if (a == 'X') return -1;
            
            if (siradaki)
            {
                int bestscore = -1;
                for (int i = 0; i < 9; i++)
                {
                    //Bos yer yoksa devam et bul 
                    if (board[i] == 'a')
                    {
                            board[i] = 'O';
                            
                            score = minimax(++depth, board, false);
                            board[i] = 'a';
                            if (score > bestscore)
                            {
                                bestscore = score;
                            }
                                                
                    }
                }
                return bestscore;
            }
            else
            {
                int bestscore = 1;
                for (int i = 0; i < 9; i++)
                {
                    //Bos yer yoksa devam et bul 
                    if (board[i] == 'a')
                    {

                        board[i] = 'X';                        
                        score = minimax(++depth, board, true);
                        board[i] = 'a';

                        if (score < bestscore)
                        {
                            bestscore = score;
                        }



                    }
                }
                return bestscore;
            }

        }

    }
}

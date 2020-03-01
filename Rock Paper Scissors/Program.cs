using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare and Initialize variables
            bool play = true;
            int gameover = 0; //Stored in an int because we need more than two values to determine the state of the game: (0-Game is not over, 1-Player Wins, 2-Opponent Wins)
            int playerhand = -1;
            int opponenthand = -1;
            string[] moves = { "Rock", "Paper", "Scissors" }; //Stores data for the moveset; used to display move on screen
            int[] scoreboard = { 0, 0 };

            //Opening Text
            Console.WriteLine("Rock Paper Scissors");
            Console.WriteLine();
            Console.WriteLine("Enter anything to begin");
            Console.ReadLine();

            //While the player wants to keep playing, restart the game
            while (play)
            {
                Console.WriteLine("YOU: {0} ; CPU: {1}", scoreboard[0], scoreboard[1]); //Display scoreboard

                Console.WriteLine("Enter 0-Rock, 1-Paper, 2-Scissors");

                try //Try to convert the string input from the player into an int for the playerhand variable. If they do not enter in the correct format, then force there answer to be a -1.
                {
                    playerhand = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    playerhand = -1;
                }

                //Checks if the player has inputed a # from 0-2, skip the loop is so, asks the player to input again if not
                while (!(playerhand >= 0 && playerhand <= 2))
                {
                    Console.WriteLine("Please enter a # from 0-2: Enter 0-Rock, 1-Paper, 2-Scissors");
                    try
                    {
                        playerhand = Convert.ToInt16(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        playerhand = -1;
                    }
                }
                
                Console.WriteLine("YOU: "+moves[playerhand]); //Writes the player move to the console

                //Randomly generates an input for the opponent
                Random r = new Random();
                opponenthand = r.Next(0, 3);

                //Writes the player move to the console
                Console.WriteLine("CPU: " + moves[opponenthand]);

                //Figure out who won the first round
                if (playerhand == opponenthand)
                {
                    Console.WriteLine("Tie");
                }
                else
                {
                    if (playerhand == 0)
                    {
                        if (opponenthand == 1)
                        {
                            Console.WriteLine("CPU Win");
                            scoreboard[1]++;
                        }
                        else
                        {
                            Console.WriteLine("YOU Win");
                            scoreboard[0]++;
                        }
                    }
                    else if(playerhand == 1)
                    {
                        if (opponenthand == 0)
                        {
                            Console.WriteLine("YOU Win");
                            scoreboard[0]++;
                        }
                        else
                        {
                            Console.WriteLine("CPU Win");
                            scoreboard[1]++;
                        }
                    }
                    else
                    {
                        if (opponenthand == 0)
                        {
                            Console.WriteLine("CPU Win");
                            scoreboard[1]++;
                        }
                        else
                        {
                            Console.WriteLine("YOU Win");
                            scoreboard[0]++;
                        }
                    }
                }

                Console.WriteLine();

                //Figure out if there is a winner, end the game if so, end the game if not
                if (scoreboard[0] >= 3)
                {
                    Console.WriteLine("YOU Win");
                    gameover = 1;
                }
                else if (scoreboard[1] >= 3)
                {
                    Console.WriteLine("CPU Wins");
                    gameover = 2;
                }

                //Figure out if the player wants to end the game, end the program if so, continue if not
                if (gameover!=0)
                {
                    Console.WriteLine("YOU: {0} ; CPU: {1}", scoreboard[0], scoreboard[1]); //Display scoreboard
                    Console.WriteLine("Enter nothing to end the game, enter otherwise to continue");
                    string answer = Console.ReadLine();

                    if (answer.Equals(""))
                    {
                        play = false;
                    }
                    else
                    {
                        playerhand = -1;
                        opponenthand = -1;
                        scoreboard = new int[] { 0, 0 };
                        gameover = 0;
                        Console.Clear();
                    }
                }

            }
        }
    }
}

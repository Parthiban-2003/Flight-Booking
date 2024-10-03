using System;

namespace FlightBooking
{
    public class SeatBooking
    {
        public static void Main(string[] args)
        {
            const int nRows = 10;
            const int nSeatsPerRow = 5;

            string[,] strSeats = new string[nRows, nSeatsPerRow];
            string[] strSeatNum = { "A", "B", "C", "D", "E" };

            while (true)
            {
                DisplaySeats(strSeats);

                Console.WriteLine("Enter passenger name:");
                string? strName = Console.ReadLine();


                Console.WriteLine("Enter passenger gender:");
                string? strGender = Console.ReadLine();

                Console.WriteLine("Enter passenger age:");
                int nAge = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter row number (1-10):");
                int nRow = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Enter seat letter (A-E):");
                string? strSeatLetter = Console.ReadLine().ToUpper();

                int nSeat = Array.IndexOf(strSeatNum, strSeatLetter.ToUpper());

                if (nRow < 0 || nRow >= nRows || nSeat < 0 || nSeat >= nSeatsPerRow)
                {
                    Console.WriteLine("Invalid Seats :( Please try again..!!");
                    continue;
                }

                if (nAge > 2 && nAge < 12)
                {
                    Console.WriteLine("50% Discount..!!");
                }
                else if (nAge > 12)
                {
                    Console.WriteLine("No Discount for above 12 years..!!");
                }

                if (strSeats[nRow, nSeat] == null)
                {
                    if(nAge > 2)
                    {
                        strSeats[nRow, nSeat] = $"{strName}, {strGender}, {nAge}";
                        Console.WriteLine($"Your :) Seat {nRow + 1}{strSeatLetter} booked successfully..!!");
                    }
                    else
                    {
                        Console.WriteLine("Less than 2 Years , No Fare & seats are does not be allocated..!!");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"Seat {nRow + 1}{strSeatLetter} is booked Already..!!");

                    bool bSeatFound = false;
                    for (int i = 0; i < nSeatsPerRow; i++)
                    {

                        if (strSeats[nRow, i] == null)
                        {
                            strSeats[nRow, i] = $"{strName}, {strGender}, {nAge}";

                            Console.WriteLine($"Seat {nRow + 1}{strSeatNum[i]} Now availble... If you interested to booking to simply you can type (YES)..!!");
                            string StrConfirm = Console.ReadLine();

                            if (StrConfirm == "yes")
                            {
                                bSeatFound = true;
                                Console.WriteLine($"Your :) Seat {nRow + 1}{strSeatNum[i]} booked successfully..!!");
                                break;
                            }
                            else
                            {
                               Console.WriteLine(":) ThankYou ..!!");
                            }

                        }
                    }

                    if (!bSeatFound)
                    {
                        Console.WriteLine("No available seats in the row..!!");
                        continue;
                    }
                }

                if(nRows == 0 && nSeatsPerRow == 0)
                {
                    Console.WriteLine("There are no seats availables in this flight");
                }

                Console.WriteLine("You want to book another seat? (yes/no):");
                string? strContinue = Console.ReadLine();

                if (strContinue == "yes")
                {
                    continue;
                }
                else if(strContinue == "no")
                {
                    break;
                }
            }
        }

        public static void DisplaySeats(string[,] strSeats)
        {
            Console.WriteLine("Current Seat Status:");
            Console.WriteLine("         A(W) B(M) C(A) D(A) E(W)     ");
            for (int i = 0; i < strSeats.GetLength(0); i++)
            {
                Console.Write($"[ {i + 1 +"Row"} ]");
                for (int j = 0; j < strSeats.GetLength(1); j++)
                {
                    if (strSeats[i, j] == null)
                    {
                        Console.Write(" AAA ");
                    }
                    else
                    {
                        Console.Write(" XXX ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine();
        }
    }
}


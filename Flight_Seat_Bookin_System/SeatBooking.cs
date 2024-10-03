using System;

namespace FlightBooking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int nRows = 10;
            const int nSeatsPerRow = 5;

            string[,] strSeats = new string[nRows, nSeatsPerRow];
            string[] strSeatNum = { "A", "B", "C", "D", "E" };

            while (true)
            {
                Console.WriteLine("Enter passenger name:");
                string? strName = Console.ReadLine();

                Console.WriteLine("Enter passenger gender:");
                string? strGender = Console.ReadLine();

                Console.WriteLine("Enter passenger age:");
                int nAge = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter row number (1-10):");
                int nRow = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter seat letter (A-E):");
                string? strSeatLetter = Console.ReadLine();

                int nSeat = Array.IndexOf(strSeatNum, strSeatLetter);

                if (nRow < 0 || nRow >= nRows || nSeat < 0 || nSeat >= nSeatsPerRow)
                {
                    Console.WriteLine("Invalid Seats Please try again..!!");
                    continue;
                }

                if (strSeats[nRow, nSeat] == null)
                {
                    strSeats[nRow, nSeat] = $"{strName}, {strGender}, {nAge}";
                    Console.WriteLine($"Your :) Seat {nRow}{strSeatLetter} booked successfully..!!");
                }
                else
                {
                    bool bSeatFound = false;
                    for (int i = 0; i < nSeatsPerRow; i++)
                    {
                        if (strSeats[nRow, i] == null)
                        {
                            strSeats[nRow, i] = $"{strName}, {strGender}, {nAge}";
                            Console.WriteLine($"Seat {nRow + 1}{strSeatNum[i]} booked Already..!!");
                            break;
                        }
                    }

                Console.WriteLine("You want to book another seat..? (yes/no):");
                string? strContinue = Console.ReadLine();

                    if (strContinue == "yes")
                    {
                        continue;
                    }
                    else if (strContinue == "no")
                    {
                        break;
                    }
                }
            }
        }
    }
}

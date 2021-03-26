using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class PieceInfo  //This class must be in separate file, here is only for tutorial purposes !
    {
        public string Composer { get; set; }
        public string Key { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, PieceInfo> pieces = new Dictionary<string, PieceInfo>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(data[0], new PieceInfo{ Composer = data[1], Key = data[2] });

            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] token = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                switch (token[0])
                {
                    case "Add":
                        if (pieces.ContainsKey(token[1]))
                        {
                            Console.WriteLine($"{token[1]} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(token[1], new PieceInfo{ Composer = token[2], Key = token[3] });
                            Console.WriteLine($"{token[1]} by {token[2]} in {token[3]} added to the collection!");
                        }

                        break;
                    case "Remove":
                        if (pieces.ContainsKey(token[1]))
                        {
                            Console.WriteLine($"Successfully removed {token[1]}!");
                            pieces.Remove(token[1]);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {token[1]} does not exist in the collection.");
                        }

                        break;
                    case "ChangeKey":
                        if (pieces.ContainsKey(token[1]))
                        {
                            pieces[token[1]].Key = token[2];
                            Console.WriteLine($"Changed the key of {token[1]} to {token[2]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {token[1]} does not exist in the collection.");
                        }

                        break;
                }
            }

            pieces = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value.Composer)
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}

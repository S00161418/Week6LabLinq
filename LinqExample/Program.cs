using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{

    public class Player
    {
        Guid _id;
        string _name;
        int _xp;

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public override string ToString()
        {
            return _id.ToString() + " " + _name + " " + _xp.ToString();
        }
    }

    class Program
    {
       static List<Player> players = new List<Player>()
        {
            new Player
            {
                Id = Guid.NewGuid(), Name= "Colin Master", Xp=75
            },
            new Player
            {
                Id = Guid.NewGuid(), Name= "John Smith", Xp=100
            },
            new Player
            {
                Id = Guid.NewGuid(), Name= "Frank Sin", Xp=27
            },
            new Player
            {
                Id = Guid.NewGuid(), Name= "John Johnston", Xp=135
            }
        };
        static void Main(string[] args)
        {
            //return the first occurance of the match or null
            Player found = players.FirstOrDefault(p => p.Name == "Frank Sin");
            if (found != null)
            {
                Console.WriteLine("{0}", found.ToString());
                
            }
            else Console.WriteLine("Not Found");

            Player found1 = players.FirstOrDefault(p => p.Name.Contains("John"));
            if (found1 != null)
            {
                Console.WriteLine("{0}", found1.ToString());

            }
            else Console.WriteLine("Not Found");

            Console.WriteLine("\n");

            //Return all those with an Xp value over 100
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if(topPlayers.Count >0)
            foreach (var item in topPlayers)
            {
                Console.WriteLine("{0}", item.ToString());
            }
            else Console.WriteLine("No match found");

            Console.WriteLine("\n");

            var ScoreBoard = players.OrderByDescending(o => o.Xp)
                                             .Select(scores => new { scores.Name, scores.Xp });

            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0} {1}" , item.Name, item.Xp);
            }
                    

            Console.ReadKey();
        }
    }
}

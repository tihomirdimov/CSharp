using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05CommunicationAndEventsProblem02
{
    public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

    public class King
    {
        private string name;

        public King(string name)
        {
            this.name = name;
        }

        public event KingUnderAttackEventHandler KingAttacked;

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.name} is under attack!");
            this.OnKingAttack(new EventArgs());
        }

        public void OnKingAttack(EventArgs args)
        {
            this.KingAttacked?.Invoke(this, args);
        }
    }
    public abstract class Troop
    {
        protected Troop(string name)
        {
            this.Name = name;
        }

        protected string Name { get; }

        public abstract void OnKingAttack(object sender, EventArgs args);
    }
    public class Footman : Troop
    {
        public Footman(string name)
            : base(name)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }

    public class RoyalGuard : Troop
    {
        public RoyalGuard(string name)
            : base(name)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            var troops = new Dictionary<string, Troop>();
            var king = new King(Console.ReadLine());

            var guards = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var guarndName in guards)
            {
                var royalGuard = new RoyalGuard(guarndName);
                troops.Add(guarndName, royalGuard);
                king.KingAttacked += royalGuard.OnKingAttack;
            }

            var footmen = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var footmanName in footmen)
            {
                var footman = new Footman(footmanName);
                troops.Add(footmanName, footman);
                king.KingAttacked += footman.OnKingAttack;
            }

            var command = Console.ReadLine();

            while (!command.Equals("End"))
            {
                var parameters = command.Split();

                switch (parameters[0])
                {
                    case "Attack":
                        king.RespondToAttack();
                        break;
                    case "Kill":
                        var soldierToRemove = troops[parameters[1]];
                        king.KingAttacked -= soldierToRemove.OnKingAttack;
                        troops.Remove(parameters[1]);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
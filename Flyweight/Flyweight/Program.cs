using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class BuildingPassport
    {
        public int Levels { get; set; }

        public int Appartments { get; set; }

        public string BuildingType { get; set; }

        public override int GetHashCode()
        {

            String str = BuildingType + "|" + Levels + "|" + Appartments;
            return str.GetHashCode();
        }
    }

    class PassportFactory
    {
        private static PassportFactory _pfInstance;
        private PassportFactory() { }

        BuildingPassport bp = new BuildingPassport() { Levels = 0, Appartments = 0, BuildingType = "" };

        HashSet<BuildingPassport> _passport = new HashSet<BuildingPassport>();
        public BuildingPassport GetPassport(int levels, int appartments, string buildingtype)
        {

            bp.Levels = levels;
            bp.Appartments = appartments;
            bp.BuildingType = buildingtype;


            if (_passport.Contains(bp))
            {
                return _passport.First(p => p.GetHashCode() == bp.GetHashCode());
            }
            else
            {
                _passport.Add(bp);
                return bp;
            }
        }

        public static PassportFactory GetInstance()
        {
            if (_pfInstance == null)
                _pfInstance = new PassportFactory();
            return _pfInstance;
        }
    }


    class Building
    {
        BuildingPassport Passport;

        public int Id { get; set; }

        public void PrintPassport()
        {
            Console.WriteLine(Id);
            Console.WriteLine(Passport.Levels);
            Console.WriteLine(Passport.Appartments);
            Console.WriteLine(Passport.BuildingType);

        }

        public Building(PassportFactory pf, int id, int levels, int appartments, string buildintype)
        {
            Id = id;
            Passport = pf.GetPassport(levels, appartments, buildintype);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PassportFactory pf = PassportFactory.GetInstance();

            Building b1 = new Building(pf, 1, 10, 100, "Bricks");
            b1.PrintPassport();
        }
    }
}

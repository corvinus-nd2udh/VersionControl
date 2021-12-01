using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week09.Entities;

namespace week09
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rng = new Random(1234);
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        private void Simulation()
        {
            for (int year = 2005; year <= numericUpDownCloseDate.Value; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int numberOfMales = (from x in Population
                                     where x.Gender == Gender.Male && x.IsAlive
                                     select x).Count();
                int numberOfFemales = (from x in Population
                                       where x.Gender == Gender.Female && x.IsAlive
                                       select x).Count();
                Console.WriteLine(string.Format("Év: {0}, Férfiak: {1}, Nők: {2}", year, numberOfMales, numberOfFemales));
            }
        }

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;
            byte age = (byte)(year - person.BirthYear);
            double ProbOfDeath = (from x in DeathProbabilities
                                  where x.Gender == person.Gender && x.Age == age
                                  select x.ProbabilityOfDeath).FirstOrDefault();
            if (rng.NextDouble() <= ProbOfDeath) person.IsAlive = false;
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                double ProbOfBirth = (from x in BirthProbabilities
                                      where x.Age == age && x.NumberOfChildren == person.NumberOfChildren
                                      select x.ProbabilityOfBirth).FirstOrDefault();
                if (rng.NextDouble() <= ProbOfBirth)
                {
                    Person newBorn = new Person()
                    {
                        BirthYear = year,
                        Gender = (Gender)rng.Next(1, 3),
                        NumberOfChildren = 0,
                    };
                    Population.Add(newBorn);
                }
            }
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Person p = new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NumberOfChildren = int.Parse(line[2])
                    };
                    population.Add(p);
                }
            }
            return population;
        }

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> births = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    BirthProbability bp = new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NumberOfChildren = int.Parse(line[1]),
                        ProbabilityOfBirth = double.Parse(line[2], CultureInfo.GetCultureInfo("hu-HU"))
                    };
                    births.Add(bp);
                }
            }
            return births;
        }

        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> deaths = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    DeathProbability bp = new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        ProbabilityOfDeath = double.Parse(line[2], CultureInfo.GetCultureInfo("hu-HU"))
                    };
                    deaths.Add(bp);
                }
            }
            return deaths;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Simulation();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.DefaultExt = ".csv";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}

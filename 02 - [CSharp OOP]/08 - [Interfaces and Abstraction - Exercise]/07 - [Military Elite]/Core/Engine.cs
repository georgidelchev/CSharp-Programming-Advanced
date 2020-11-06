using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine
    {
        public void Proceed()
        {
            var soldiers = new List<ISoldier>();
            var privates = new List<IPrivate>();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                string type, firstName, lastName;
                int id;

                ParseArgs(splittedInput, out type, out id, out firstName, out lastName);

                SwitchJobs(soldiers, privates, splittedInput, type, firstName, lastName, id);
            }

            Output(soldiers);
        }

        private static void SwitchJobs(List<ISoldier> soldiers, List<IPrivate> privates, List<string> splittedInput, string type, string firstName, string lastName, int id)
        {
            switch (type)
            {
                case "Private":
                    CreatePrivate(soldiers, privates, splittedInput, id, firstName, lastName);
                    break;
                case "LieutenantGeneral":
                    CreateLieutenantGeneral(soldiers, privates, splittedInput, id, firstName, lastName);
                    break;
                case "Engineer":
                    CreateEngineer(soldiers, splittedInput, id, firstName, lastName);
                    break;
                case "Commando":
                    CreateCommando(soldiers, splittedInput, id, firstName, lastName);
                    break;
                case "Spy":
                    CreateSpy(soldiers, splittedInput, id, firstName, lastName);
                    break;
            }
        }

        private static void CreatePrivate(List<ISoldier> soldiers, List<IPrivate> privates, List<string> splittedInput, int id, string firstName, string lastName)
        {
            var salary = ParseSalary(splittedInput);

            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);

            privates.Add(privateSoldier);
            soldiers.Add(privateSoldier);
        }

        private static void CreateLieutenantGeneral(List<ISoldier> soldiers, List<IPrivate> privates, List<string> splittedInput, int id, string firstName, string lastName)
        {
            var salary = ParseSalary(splittedInput);

            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            splittedInput = Skipping(splittedInput, 5);

            for (int i = 0; i < splittedInput.Count; i++)
            {
                var privateToAdd = privates
                    .FirstOrDefault(x => x.Id == int.Parse(splittedInput[i]));

                lieutenantGeneral.AddPrivate(privateToAdd);
            }

            soldiers.Add(lieutenantGeneral);
        }

        private static void CreateEngineer(List<ISoldier> soldiers, List<string> splittedInput, int id, string firstName, string lastName)
        {
            var salary = ParseSalary(splittedInput);

            var corp = splittedInput[5];

            if (!Enum.IsDefined(typeof(Corps), corp))
            {
                return;
            }

            IEngineer engineer = new Engineer(id, firstName, lastName, salary, (Corps)Enum.Parse(typeof(Corps), corp));

            splittedInput = Skipping(splittedInput, 6);

            for (int i = 0; i < splittedInput.Count; i += 2)
            {
                var partName = splittedInput[i];
                var workedHours = int.Parse(splittedInput[i + 1]);

                IRepair repair = new Repair(partName, workedHours);
                engineer.AddRepair(repair);
            }

            soldiers.Add(engineer);
        }

        private static void CreateCommando(List<ISoldier> soldiers, List<string> splittedInput, int id, string firstName, string lastName)
        {
            decimal salary = ParseSalary(splittedInput);
            var corp = splittedInput[5];

            if (!Enum.IsDefined(typeof(Corps), corp))
            {
                return;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary, (Corps)Enum.Parse(typeof(Corps), corp));

            splittedInput = Skipping(splittedInput, 6);

            for (int i = 0; i < splittedInput.Count; i += 2)
            {
                var codeName = splittedInput[i];
                var state = splittedInput[i + 1];

                if (!Enum.IsDefined(typeof(MissionStates), state))
                {
                    continue;
                }

                IMission mission = new Mission(codeName, (MissionStates)Enum.Parse(typeof(MissionStates), state));

                commando.AddMission(mission);
            }

            soldiers.Add(commando);
        }

        private static void CreateSpy(List<ISoldier> soldiers, List<string> splittedInput, int id, string firstName, string lastName)
        {
            var codeNumber = int.Parse(splittedInput[4]);

            ISpy spy = new Spy(id, firstName, lastName, codeNumber);

            soldiers.Add(spy);
        }

        private static void ParseArgs(List<string> splittedInput, out string type, out int id, out string firstName, out string lastName)
        {
            type = splittedInput[0];
            id = int.Parse(splittedInput[1]);

            firstName = splittedInput[2];
            lastName = splittedInput[3];
        }

        private static decimal ParseSalary(List<string> splittedInput)
                => decimal.Parse(splittedInput[4]);

        private static List<string> Skipping(List<string> splittedInput, int count)
        {
            splittedInput = splittedInput
                            .Skip(count)
                            .ToList();

            return splittedInput;
        }

        private static void Output(List<ISoldier> soldiers)
        {
            foreach (var item in soldiers)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

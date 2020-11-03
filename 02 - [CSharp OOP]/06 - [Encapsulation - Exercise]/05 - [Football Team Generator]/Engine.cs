using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {
        public void Proceed()
        {
            List<Team> teams = new List<Team>();

            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                try
                {
                    ExecutingCommands(teams, tokens, command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void ExecutingCommands(List<Team> teams, string[] tokens, string command)
        {
            switch (command)
            {
                case "Team":
                    AddTeam(teams, tokens);
                    break;
                case "Add":
                    AddPlayer(teams, tokens);
                    break;
                case "Remove":
                    RemovePlayer(teams, tokens);
                    break;
                case "Rating":
                    PrintRating(teams, tokens);
                    break;
            }
        }

        private void AddTeam(List<Team> teams, string[] tokens)
        {
            teams.Add(new Team(tokens[1]));
        }

        private void AddPlayer(List<Team> teams, string[] tokens)
        {
            if (!teams.Any(t => t.Name == tokens[1]))
            {
                throw new ArgumentException($"Team {tokens[1]} does not exist.");
            }
            else
            {
                var currentTeam = teams.First(t => t.Name == tokens[1]);
                currentTeam
                    .AddPlayer(new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7])));
            }
        }

        private void RemovePlayer(List<Team> teams, string[] tokens)
        {
            var teamToRemove = teams.First(t => t.Name == tokens[1]);
            teamToRemove.RemovePlayer(tokens[2]);
        }

        private void PrintRating(List<Team> teams, string[] tokens)
        {
            if (!teams.Any(t => t.Name == tokens[1]))
            {
                throw new ArgumentException($"Team {tokens[1]} does not exist.");
            }
            else
            {
                Console.WriteLine(teams.First(t => t.Name == tokens[1]).ToString());
            }
        }
    }
}

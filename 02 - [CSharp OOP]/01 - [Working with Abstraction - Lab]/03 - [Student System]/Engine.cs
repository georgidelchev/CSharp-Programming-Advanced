using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData
{
    public class Engine
    {
        private StudentData studentData;
        private IInputOutputProvider inputOutputProvider;

        public Engine(StudentData studentData, IInputOutputProvider inputOutputProvider)
        {
            this.studentData = new StudentData();
            this.inputOutputProvider = inputOutputProvider;
        }

        /// <summary>
        /// Processing commands.
        /// </summary>
        public void ProcessCommand()
        {
            bool isEnd = false;

            while (!isEnd)
            {
                var line = this.inputOutputProvider.GetInput();

                isEnd = ExecuteCommand(line);
            }
        }

        /// <summary>
        /// Executing commands.
        /// </summary>
        /// <param name="line">The input line</param>
        /// <returns></returns>
        private bool ExecuteCommand(string line)
        {
            var command = Command.Parse(line);
            var arguments = command.CommandArgs;

            switch (command.CommandType)
            {
                case "Create":
                    var name = arguments[0];
                    var age = int.Parse(arguments[1]);
                    var grade = double.Parse(arguments[2]);

                    this.studentData.AddStudent(name, age, grade);
                    break;
                case "Show":
                    name = command.CommandArgs[0];
                    var output = this.studentData.GetStudentDetails(name);

                    this.inputOutputProvider.ShowOutput(output);
                    break;
                case "Exit":
                    return true;
            }

            return false;
        }
    }
}

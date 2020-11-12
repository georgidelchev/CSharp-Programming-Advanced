using System;

namespace P01._HelloWorld_After
{
    public class HelloWorld
    {
        private DateTime timeOfGreeting;

        public HelloWorld(DateTime timeOfGreeting)
        {
            this.timeOfGreeting = timeOfGreeting;
        }

        public string Greeting(string name)
        {
            if (this.timeOfGreeting.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (this.timeOfGreeting.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}

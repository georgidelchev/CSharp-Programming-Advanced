using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            this.InitializeRooms();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public void InitializeRooms()
        {
            for (byte i = 1; i <= 20; i++)
            {
                this.Rooms.Add(new Room(i));
            }
        }

        public Room GetFirstFreeRoom()
        {
            return this.Rooms
                .First(rooms => rooms.Count < 3);
        }
    }
}

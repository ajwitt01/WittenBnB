using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WittenBnb.Models
{
    public class Room
    {
        public Room()
        { 
        }

        public Room(int id, string roomname, int numberofbeds, bool smoking, bool petsallowed, string description)
        { 
            Id = id;
            RoomName = roomname;
            NumberOfBeds = numberofbeds;
            Smoking = smoking;
            PetsAllowed = petsallowed;
            Description = description;
        }

        public int Id { get; set; }
        public string RoomName {get; set;}
        public int NumberOfBeds {get; set;}
        public bool Smoking { get; set; }
        public bool PetsAllowed { get; set; }
        public string Description { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateOnly Date { get;set; }
        public long SoftwareHouseId { get; set; }

        public Videogame(string name, string overview, string date, long softwareHouseId)
        {
            Name = name;
            Overview = overview;
            Date =DateOnly.ParseExact(date,"d");
            SoftwareHouseId = softwareHouseId;
        }
    }
}

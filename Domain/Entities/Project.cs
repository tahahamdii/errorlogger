﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Error> Errors { get; set; }
        public Team Team { get; set; }
    }
}

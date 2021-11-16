﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
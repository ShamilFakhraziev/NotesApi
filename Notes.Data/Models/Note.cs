﻿using System;

namespace Notes.Data.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public string Content { get; set;}
        public bool IsImportant { get; set; }
    }
}

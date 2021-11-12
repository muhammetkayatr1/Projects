﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemBasvuru.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Egitim { get; set; }
        public DateTime BasvuruTarihi { get; set; }
        public bool IsAnswer { get; set; }
    }
}

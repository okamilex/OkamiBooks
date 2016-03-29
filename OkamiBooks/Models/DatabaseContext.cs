﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OkamiBooks.Models.Entities;
using OkamiBooks.Models.Entities.Medals;

namespace OkamiBooks.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<UserBookInfo> UserBookInfos { get; set; }
        public DbSet<MedalCommentator> MedalsCommentator { get; set; }
        public DbSet<MedalCritic> MedalsCritic { get; set; }
        public DbSet<MedalLiker> MedalsLiker { get; set; }
        public DbSet<MedalReader> MedalsReader { get; set; }
        public DbSet<MedalWriter> MedalsWriter { get; set; }
        public DbSet<ServiceRibbon> ServiceRibbons { get; set; }
    }
}
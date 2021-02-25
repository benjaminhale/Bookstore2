﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data
{
    public class MvcNotesContext : DbContext
    {
        public MvcNotesContext(DbContextOptions<MvcNotesContext> options)
            : base(options)
        {
        }

        public DbSet<NotesModel> Movie { get; set; }
    }
}

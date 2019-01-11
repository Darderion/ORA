using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORA
{
    class TMapContext : DbContext
    {
        public TMapContext() : base("DbConnection") { }
        public DbSet<MapsDB.MapRepresentation> Maps { get; set; }
        public DbSet<MapsDB.Subtitle> Subtitles { get; set; }
    }
}

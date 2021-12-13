using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TraCuuKienThucDemo2.Models
{
    public partial class KnowledgeDB : DbContext
    {
        public KnowledgeDB()
            : base("name=KnowledgeDB")
        {
        }

        public virtual DbSet<DataAI> DataAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

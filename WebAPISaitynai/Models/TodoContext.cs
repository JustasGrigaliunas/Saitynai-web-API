using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISaitynai.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<ClientItem> ClientItems { get; set; }
        public DbSet<GoodsItem> GoodsItems { get; set; }
    }
}

using BlazorWASMPhoneBook.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASMPhoneBook.Shared.Data;

public class ContactsDbContext : DbContext
    {
    //public ContactsDbContext ( DbContextOptions<ContactsDbContext> options ) : base(options)
    //    {

    //    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneBookDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<ContactModel> Contacts { get; set; }
    }
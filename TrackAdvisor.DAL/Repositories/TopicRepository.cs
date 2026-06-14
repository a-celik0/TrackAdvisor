using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;


namespace TrackAdvisor.DAL.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _context;

        public TopicRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Topic> FindAll()
        {
            return _context.Topics.FromSqlRaw("SELECT * FROM Topics").ToList();
        }

        // {0} yerine id geliyor
        public Topic FindByID(int id)
        {
            return _context.Topics.FromSqlRaw("SELECT * FROM Topics WHERE TopicID = {0}", id).FirstOrDefault();
        }

    public void InitializeTopics()
        {
            // Create Topics table if it does not exist
            _context.Database.ExecuteSqlRaw(@"
        CREATE TABLE IF NOT EXISTS Topics (
            TopicID INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Description TEXT NOT NULL,
            CreatedAt TEXT NOT NULL,
            IsDeleted INTEGER NOT NULL,
            DeletedAt TEXT NULL
        );
    ");

            // Insert default topics if they do not exist
            _context.Database.ExecuteSqlRaw(@"
        INSERT INTO Topics (Name, Description, CreatedAt, IsDeleted)
        SELECT 'Software Development', 'Software development track', datetime('now'), 0
        WHERE NOT EXISTS (SELECT 1 FROM Topics WHERE Name = 'Software Development');

        INSERT INTO Topics (Name, Description, CreatedAt, IsDeleted)
        SELECT 'Cyber Security', 'Cyber security track', datetime('now'), 0
        WHERE NOT EXISTS (SELECT 1 FROM Topics WHERE Name = 'Cyber Security');

        INSERT INTO Topics (Name, Description, CreatedAt, IsDeleted)
        SELECT 'Business IT', 'Business IT track', datetime('now'), 0
        WHERE NOT EXISTS (SELECT 1 FROM Topics WHERE Name = 'Business IT');

        INSERT INTO Topics (Name, Description, CreatedAt, IsDeleted)
        SELECT 'Applied Generative AI', 'In this semester you tackle real-world AI projects—building autonomous agents, designing new interaction patterns, architecting production systems.', datetime('now'), 0
        WHERE NOT EXISTS (SELECT 1 FROM Topics WHERE Name = 'Applied Generative AI');


    ");
        }
        public void Update(int id, string name, string description)
        {
            // Update topic name and description using raw SQL
            _context.Database.ExecuteSqlRaw(
                "UPDATE Topics SET Name = {0}, Description = {1} WHERE TopicID = {2}",
                name, description, id
            );
        }

        public void SoftDelete(int id)
        {
            // Set IsDeleted to 1 and save the deletion time
            _context.Database.ExecuteSqlRaw(
                "UPDATE Topics SET IsDeleted = 1, DeletedAt = datetime('now') WHERE TopicID = {0}",
                id
            );
        }
        public void Add(string name, string description)
        {
            // Insert a new topic using raw SQL
            _context.Database.ExecuteSqlRaw(
                "INSERT INTO Topics (Name, Description, CreatedAt, IsDeleted) VALUES ({0}, {1}, datetime('now'), 0)",
                name, description
            );
        }
    }
}

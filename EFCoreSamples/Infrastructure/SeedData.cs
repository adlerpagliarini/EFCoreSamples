using EFCoreSamples.Domain;
using EFCoreSamples.Domain.Enums;
using EFCoreSamples.Domain.ValueObjects;
using System;
using System.Linq;

namespace EFCoreSamples.Infrastructure
{
    public static class SeedData
    {
        public static void SeedDatabase(DatabaseContext context)
        {
            try
            {
                if (context.Developer.Any()) return;

                var skill_backend_1 = new Skill("C#", 0);
                var skill_backend_2 = new Skill("Database", 0);
                var skill_frontend_1 = new Skill("Html", 0);

                var code1 = new DevCode("123");
                var code2 = new DevCode("321");
                var code3 = new DevCode("999");

                var frontendTask = new TaskToDo("Dev HTML page", DateTime.Now, DateTime.Now.AddDays(15), false, null);
                frontendTask.SetSkill(skill_frontend_1);

                var backendTask = new TaskToDo("Dev CSharp code", DateTime.Now, DateTime.Now.AddDays(15), false, null);
                backendTask.SetSkill(skill_backend_1);
                backendTask.SetSkill(skill_backend_2);

                var frontend = new Developer(code1, "Adler Pagliarini", DevType.FrontEnd);
                frontend.AddItemToDo(frontendTask);

                var backend = new Developer(code2, "Pagliarini Nascimento", DevType.BackEnd);
                backend.AddItemToDo(backendTask);

                var fullstack = new Developer(code3, "Adler Nascimento", DevType.Fullstack);
                fullstack.AddItemToDo(frontendTask);
                fullstack.AddItemToDo(backendTask);

                context.Developer.AddRange(frontend, backend, fullstack);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        }

    }
}

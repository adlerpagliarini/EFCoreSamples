using EFCoreSamples.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreSamples.Dtos
{
    public class TaskToDoDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Status { get; set; }
        public string DevCode { get; set; }
        public List<SkillDto> Skills { get; set; }

        public TaskToDoDto()
        {

        }

        public TaskToDoDto(long id, string title, DateTime start, DateTime deadLine, bool status, string devCode, List<SkillDto> skills)
        {
            Id = id;
            Title = title;
            Start = start;
            DeadLine = deadLine;
            Status = status;
            DevCode = devCode;
            Skills = skills;
        }

        public static TaskToDoDto Map(TaskToDo domain) =>
            domain is null ? default : new TaskToDoDto(domain.Id, domain.Title, domain.Start, domain.DeadLine, domain.Status, domain.DeveloperId, domain.Skills.Select(e => SkillDto.Map(e)).ToList());
    }
}

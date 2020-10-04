using EFCoreSamples.Domain;
using EFCoreSamples.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreSamples.Dtos
{
    public class DeveloperDto
    {
        public string DevCode { get; set; }
        public string Name { get; set; }
        public DevType DevType { get; set; }
        public List<TaskToDoDto> TasksToDo { get; set; }

        public DeveloperDto()
        {
            TasksToDo = new List<TaskToDoDto>();
        }

        public DeveloperDto(string devCode, string name, DevType devType,List<TaskToDoDto> tasksToDo)
        {
            DevCode = devCode;
            Name = name;
            DevType = devType;
            TasksToDo = tasksToDo;
        }

        public static Func<Developer, DeveloperDto> MapDomainToDto = (developer) => Map(developer);

        public static DeveloperDto Map(Developer domain) => domain is null ? default :
            new DeveloperDto(domain.Id, domain.Name, domain.DevType, domain.TasksToDo.Select(e => TaskToDoDto.Map(e)).ToList());

    }
}

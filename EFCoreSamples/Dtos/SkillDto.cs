namespace EFCoreSamples.Domain
{
    public class SkillDto
    {
        public SkillDto(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public static SkillDto Map(Skill domain) => domain is null ? default :
            new SkillDto(domain.Title);
    }
}

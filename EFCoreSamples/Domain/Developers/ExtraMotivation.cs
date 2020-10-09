using EFCoreSamples.Domain.Entity;

namespace EFCoreSamples.Domain
{
    public class ExtraMotivation
    {
        public ExtraMotivation(string extraFactor)
        {
            ExtraFactor = extraFactor;
        }

        protected ExtraMotivation()
        {
        }

        public string ExtraFactor { get; protected set; }
    }
}

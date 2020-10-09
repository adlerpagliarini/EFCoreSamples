using EFCoreSamples.Domain.Entity;
using EFCoreSamples.Domain.ValueObjects;

namespace EFCoreSamples.Domain
{
    public class Motivation : Identity<Motivation, long>
    {
        public Motivation(string factor, DevCode developerId)
        {
            Factor = factor;
            DeveloperId = developerId;
        }

        protected Motivation()
        {

        }

        public string Factor { get; protected set; }
        public DevCode DeveloperId { get; protected set; }
    }
}

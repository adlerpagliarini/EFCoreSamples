using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreSamples.Infrastructure.Interceptors
{
    // https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/whatsnew#rc1
    public class ContextChangesInterceptor : SaveChangesInterceptor, ISaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            Console.WriteLine($"*** \n *** Interceptor Saving changes for {eventData.Context.Database.GetConnectionString()}");

            return result;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine($"*** \n *** Interceptor Saving changes asynchronously for {eventData.Context.Database.GetConnectionString()}");

            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}

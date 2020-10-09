using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreSamples.Infrastructure.Interceptors
{
    public class CommandInterceptor : DbCommandInterceptor, IDbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
          DbCommand command,
          CommandEventData eventData,
          InterceptionResult<DbDataReader> result)
        {
            // command.CommandText += " OPTION (OPTIMIZE FOR UNKNOWN)";
            return result;
        }

        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"*** \n *** Interceptor Reader ExecutionTime {eventData.Duration.TotalMilliseconds} ms. | {eventData.Duration.TotalSeconds} seconds.");            
            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

    }
}

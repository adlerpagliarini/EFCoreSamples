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
            Console.WriteLine($"Interceptor Reader Command Execution");
            // command.CommandText += " OPTION (OPTIMIZE FOR UNKNOWN)";
            return result;
        }    
    }
}

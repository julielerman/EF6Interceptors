using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using NLog;

//NOTE: this sample code was copied from Arthur Vickers blog
//http://blog.oneunicorn.com/2013/05/14/ef6-sql-logging-part-3-interception-building-blocks/
//Arthur is a member of Microsoft's EF team
public class NLogEfCommandInterceptor : IDbCommandInterceptor
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public void NonQueryExecuting(
    DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    {
        LogTrace(command, interceptionContext, CommandType.NonQueryExecuting);
        LogIfNonAsync(command, interceptionContext);
    }

    public void NonQueryExecuted(
    DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    {
        LogTrace(command, interceptionContext, CommandType.NonQueryExecuted);
        LogIfError(command, interceptionContext);
    }

    public void ReaderExecuting(
    DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {
        LogTrace(command, interceptionContext,CommandType.ReaderExecuting);
        LogIfNonAsync(command, interceptionContext);
    }

    public void ReaderExecuted(
    DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {
        LogTrace(command, interceptionContext, CommandType.ReaderExecuted);
        LogIfError(command, interceptionContext);
    }

    public void ScalarExecuting(
    DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    {
        LogTrace(command, interceptionContext, CommandType.ScalarExecuting);
        LogIfNonAsync(command, interceptionContext);
    }

    public void ScalarExecuted(
    DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    {
        LogTrace(command, interceptionContext, CommandType.ScalarExecuted);
        LogIfError(command, interceptionContext);
    }

    private void LogIfNonAsync<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
    {
        if (!interceptionContext.IsAsync)
        {
            Logger.Warn("Non-async command used: {0}", command.CommandText);
        }
    }

    private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
    {
        if (interceptionContext.Exception != null)
        {
            Logger.Error("Command {0} failed with exception {1}",
            command.CommandText, interceptionContext.Exception);
        }
    }
    private void LogTrace<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext, CommandType commandType)
    {
        var initFlags = new string[]
        {
            "EdmMetadata", 
            "__MigrationHistory",
            "sys.databases",
            "serverproperty",
            "create database",
            "CREATE SCHEMA",
            "CREATE INDEX"
,
"ALTER TABLE",
"CREATE TABLE"
        };

        if (initFlags.Any(x => command.CommandText.Contains(x)))
        {
            Logger.Info(command.CommandText + " " + commandType.ToString());

        }
        else
        {
            Logger.Trace(command.CommandText + " " + commandType.ToString());
        }
    }

    private enum CommandType
    {
        NonQueryExecuting=1,
        NonQueryExecuted=2,
        ReaderExecuting=3,
        ReaderExecuted=4,
        ScalarExecuting=5,
        ScalarExecuted=6

    }
}
using System;

namespace JSONCovidDash.Models
{
    public interface ILogEntryFormatMessage
    {
        string RetornaMensagemSimples();

        string RetornaMensagemCompleta();
    }

    public interface ILogEntry : ILogEntryFormatMessage
    {
        LogEntryCategory Category { get; }

        DateTime DateTime { get; }

        string Message { get; }

        string FullMessage { get; }
    }
}

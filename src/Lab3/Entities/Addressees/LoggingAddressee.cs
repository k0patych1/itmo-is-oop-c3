using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Serilog;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class LoggingAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public LoggingAddressee(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Information($"Received message: {message}");
        _addressee.ReceiveMessage(message);
    }
}
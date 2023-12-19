using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public interface IMessenger
{
    public void SendMessage(Message message);
}
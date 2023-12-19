using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public interface IAddressee
{
    public void ReceiveMessage(Message message);
}
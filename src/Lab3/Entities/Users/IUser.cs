using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public interface IUser
{
    public void GetMessage(Message message);

    public bool IsReadMessage(int indexOfMessage);

    public void ReadMessage(int indexOfMessage);
}
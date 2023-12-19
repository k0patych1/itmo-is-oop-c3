using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class UserViewMessage : Message
{
    public UserViewMessage(Message message)
        : base(message)
    {
        IsRead = false;
    }

    public bool IsRead { get; private set; }

    public void Read()
    {
        if (IsRead) throw new ReadMessageException(GetType().Name);

        IsRead = true;
    }
}
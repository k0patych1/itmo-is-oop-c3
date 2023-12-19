namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Vkontakte;

public interface IVkontakte
{
    public void ReceiveMessage(string text, string login, string password, bool isMessageHidden);
}
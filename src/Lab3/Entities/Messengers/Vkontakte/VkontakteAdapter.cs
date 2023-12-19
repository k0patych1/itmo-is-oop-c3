using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Vkontakte;

public class VkontakteAdapter : IMessenger
{
    private readonly IVkontakte _vkontakte;
    private readonly string _login;
    private readonly string _password;
    private readonly bool _isMessageHidden;

    public VkontakteAdapter(IVkontakte vkontakte, string login, string password, bool isMessageHidden)
    {
        _vkontakte = vkontakte;
        _login = login;
        _password = password;
        _isMessageHidden = isMessageHidden;
    }

    public void SendMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _vkontakte.ReceiveMessage(message.Body, _login, _password, _isMessageHidden);
    }
}
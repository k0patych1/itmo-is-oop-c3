using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Vkontakte;

public class Vkontakte : IVkontakte
{
    public void ReceiveMessage(string text, string login, string password, bool isMessageHidden)
    {
        Console.WriteLine("[Vkontakte] " + text);
    }
}
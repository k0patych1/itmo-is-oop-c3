namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Telegram;

public interface ITelegram
{
    public void SendMessage(string message, int sleepTime);
}
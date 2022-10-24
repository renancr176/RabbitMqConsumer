using System.Text;
using RabbitMQ.Client.Events;
using RabbitMqClient;

namespace RabbitMqConsumer;

public class TesteRabbitMq : ITesteRabbitMq
{
    private readonly IRabbitMqConsumer _rabbitMqConsumer;

    public TesteRabbitMq(IRabbitMqConsumer rabbitMqConsumer)
    {
        _rabbitMqConsumer = rabbitMqConsumer;
    }

    public async Task Run()
    {
        var queueName = "TestQueue";

        _rabbitMqConsumer.BasicConsume(queueName, ConsumerEventHandler, true);
    }

    private void ConsumerEventHandler(object? sender, BasicDeliverEventArgs ea)
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        var foregroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Message RECEIVED at: {DateTime.Now.ToString("G")} \nMessage: {message}");
        Console.ForegroundColor = foregroundColor;
    }
}
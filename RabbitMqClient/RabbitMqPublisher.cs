using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace RabbitMqClient;

public class RabbitMqPublisher : IRabbitMqPublisher
{
    private readonly ILogger<RabbitMqPublisher> _logger;
    private readonly IRabbitMq _rabbitMq;

    public RabbitMqPublisher(ILogger<RabbitMqPublisher> logger, IRabbitMq rabbitMq)
    {
        _logger = logger;
        _rabbitMq = rabbitMq;
    }

    private void BasicPublish(IConnection connection, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null)
    {
        if (exchange == null) throw new ArgumentNullException(nameof(exchange));
        if (routingKey == null) throw new ArgumentNullException(nameof(routingKey));
        
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue,
            durable,
            exclusive,
            autoDelete,
            arguments);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange,
            routingKey,
            basicProperties,
            body);
    }

    #region Basic Params
    
    public void BasicPublish(string queue, string message)
    {
        BasicPublish(queue, message, "", queue);
    }

    public void BasicPublish(string clientProvidedName, string queue, string message)
    {
        BasicPublish(clientProvidedName, queue, message, "", queue);
    }

    public void BasicPublish(IList<string> hostnames, string queue, string message)
    {
        BasicPublish(hostnames, queue, message, "", queue);
    }

    public void BasicPublish(IList<string> hostnames, string clientProvidedName, string queue, string message)
    {
        BasicPublish(hostnames, clientProvidedName, queue, message, "", queue);
    }

    public void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string queue, string message)
    {
        BasicPublish(endpoints, queue, message, "", queue);
    }

    public void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string clientProvidedName, string queue, string message)
    {
        BasicPublish(endpoints, clientProvidedName, queue, message, "", queue);
    }

    public void BasicPublish(IEndpointResolver endpointResolver, string clientProvidedName, string queue, string message)
    {
        BasicPublish(endpointResolver, clientProvidedName, queue, message, "", queue);
    }

    #endregion

    #region Full Params

    public void BasicPublish(string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection();
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }

    public void BasicPublish(string clientProvidedName, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection(clientProvidedName);
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }
    
    public void BasicPublish(IList<string> hostname, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection(hostname);
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }

    public void BasicPublish(IList<string> hostnames, string clientProvidedName, string queue, string message, string exchange,
        string routingKey, IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false,
        bool autoDelete = false, IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection(hostnames, clientProvidedName);
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }

    public void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection(endpoints);
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }

    public void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string clientProvidedName, string queue, string message, string exchange,
        string routingKey, IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false,
        bool autoDelete = false, IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection(endpoints, clientProvidedName);
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }

    public void BasicPublish(IEndpointResolver endpointResolver, string clientProvidedName, string queue, string message,
        string exchange, string routingKey, IBasicProperties basicProperties = null, bool durable = false,
        bool exclusive = false, bool autoDelete = false, IDictionary<string, object> arguments = null)
    {
        try
        {
            using var connection = _rabbitMq.CreateConnection(endpointResolver, clientProvidedName);
            BasicPublish(connection, queue, message, exchange, routingKey, basicProperties, durable, exclusive,
                autoDelete, arguments);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.StackTrace);
            throw;
        }
    }

    #endregion
}
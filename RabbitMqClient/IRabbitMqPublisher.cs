using RabbitMQ.Client;

namespace RabbitMqClient;

public interface IRabbitMqPublisher
{
    #region Basic Params
    
    void BasicPublish(string queue, string message);
    void BasicPublish(string clientProvidedName, string queue, string message);
    void BasicPublish(IList<string> hostnames, string queue, string message);
    void BasicPublish(IList<string> hostnames, string clientProvidedName, string queue, string message);
    void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string queue, string message);
    void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string clientProvidedName, string queue, string message);
    void BasicPublish(IEndpointResolver endpointResolver, string clientProvidedName, string queue, string message);

    #endregion

    #region Full Params

    void BasicPublish(string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);
    void BasicPublish(string clientProvidedName, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);
    
    void BasicPublish(IList<string> hostname, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);
    void BasicPublish(IList<string> hostnames, string clientProvidedName, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);
    void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);
    void BasicPublish(IList<AmqpTcpEndpoint> endpoints, string clientProvidedName, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);
    void BasicPublish(IEndpointResolver endpointResolver, string clientProvidedName, string queue, string message, string exchange, string routingKey,
        IBasicProperties basicProperties = null, bool durable = false, bool exclusive = false, bool autoDelete = false,
        IDictionary<string, object> arguments = null);

    #endregion
}
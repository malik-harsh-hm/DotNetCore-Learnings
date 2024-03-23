using Azure.Messaging.ServiceBus;

namespace ASB_topic
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "<your_connection_string>";
            string topicName = "<your_topic_name>";
            string subscriptionName = "<your_subscription_name>";

            // Send message to topic
            await SendMessageToTopic(connectionString, topicName);

            // Receive message from subscription
            await ReceiveMessageFromSubscription(connectionString, topicName, subscriptionName);
        }

        static async Task SendMessageToTopic(string connectionString, string topicName)
        {
            // Create a ServiceBusClient to communicate with the Service Bus namespace
            await using var client = new ServiceBusClient(connectionString);

            // Create a sender to send messages to the topic
            ServiceBusSender sender = client.CreateSender(topicName);

            // Create a message
            ServiceBusMessage message = new ServiceBusMessage("Hello, Service Bus!");

            // Send the message to the topic
            await sender.SendMessageAsync(message);
            Console.WriteLine("Message sent to the topic.");
        }

        static async Task ReceiveMessageFromSubscription(string connectionString, string topicName, string subscriptionName)
        {
            // Create a ServiceBusClient to communicate with the Service Bus namespace
            await using var client = new ServiceBusClient(connectionString);

            // Create a receiver to receive messages from the subscription
            ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

            // Receive messages from the subscription
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            if (receivedMessage != null)
            {
                string messageBody = receivedMessage.Body.ToString();
                Console.WriteLine($"Received message from subscription: {messageBody}");

                // Complete the message to remove it from the subscription
                await receiver.CompleteMessageAsync(receivedMessage);
                Console.WriteLine("Message completed.");
            }
            else
            {
                Console.WriteLine("No messages available in the subscription.");
            }
        }
    }
}

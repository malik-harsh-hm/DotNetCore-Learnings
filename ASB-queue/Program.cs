using Azure.Messaging.ServiceBus;

namespace ASB_queue
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Connection string for your Azure Service Bus namespace
            string connectionString = "<your_connection_string>";

            // Name of the queue you want to work with
            string queueName = "<your_queue_name>";

            // Create a connection
            await using (var client = new ServiceBusClient(connectionString))
            {
                await SendMessageToQueue(queueName, client);

                // Create processor
                await using (var processor = client.CreateProcessor(queueName))
                {
                    // Configure message handler
                    processor.ProcessMessageAsync += MessageHandler;

                    // Configure error handler
                    processor.ProcessErrorAsync += ErrorHandler;

                    // Start processing
                    await processor.StartProcessingAsync();

                    Console.WriteLine("Press any key to stop receiving messages...");
                    Console.ReadKey();

                    // Stop processing
                    await processor.StopProcessingAsync();
                }
            }

            static async Task SendMessageToQueue(string queueName, ServiceBusClient client)
            {
                // Create sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // Send message
                await sender.SendMessageAsync(new ServiceBusMessage("Hello, Service Bus!"));

                Console.WriteLine("Message sent to the queue.");
            }

            static async Task MessageHandler(ProcessMessageEventArgs args)
            {
                string body = args.Message.Body.ToString();
                Console.WriteLine($"Received message: {body}");

                // Process the message here...

                // Complete the message to remove it from the queue
                await args.CompleteMessageAsync(args.Message);
            }

            static Task ErrorHandler(ProcessErrorEventArgs args)
            {
                Console.WriteLine($"Error occurred: {args.Exception.Message}");
                return Task.CompletedTask;
            }

            static async Task ReceiveAndCompleteMessage(string queueName, ServiceBusClient client)
            {
                // Create receiver
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // Receive message
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                if (receivedMessage != null)
                {
                    string messageBody = receivedMessage.Body.ToString();
                    Console.WriteLine($"Received message: {messageBody}");

                    // Complete the message to remove it from the queue
                    await receiver.CompleteMessageAsync(receivedMessage);
                }
                else
                {
                    Console.WriteLine("No messages available in the queue.");
                }
            }
            static async Task PeekMessage(string queueName, ServiceBusClient client)
            {
                // Create receiver
                ServiceBusReceiver receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions {
                    ReceiveMode = ServiceBusReceiveMode.PeekLock
                });

                // Peek message
                ServiceBusReceivedMessage receivedMessage = await receiver.PeekMessageAsync();
                if (receivedMessage != null)
                {
                    string messageBody = receivedMessage.Body.ToString();
                    Console.WriteLine($"Peeked message: {messageBody}");
                }
                else
                {
                    Console.WriteLine("No messages available in the queue.");
                }
            }
        }
    }
}

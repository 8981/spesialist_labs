﻿using System.Net;
using System.Net.Sockets;
using System.Text;

const int MAX_CONNECTION_IN_QUEUE = 10;
const int PORT = 1111;
const int MAX_THREADS = 30;

ThreadPool.SetMaxThreads(MAX_THREADS, MAX_THREADS);

IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, PORT);
using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(ipPoint);
socket.Listen(MAX_CONNECTION_IN_QUEUE);
int req = 0;
var sync = new Object();
while (true)
{
     Socket client = socket.Accept();

    Task task = Task.Run(() =>
    {
        Console.Write($"Remote client: {client.RemoteEndPoint} ");
        using var stream = new NetworkStream(client);
        using var r = new StreamReader(stream, Encoding.UTF8);
        using var w = new StreamWriter(stream, Encoding.UTF8);
        string result = r.ReadLine();
        lock (sync) req++;
        Console.WriteLine($"Received: {result}, Requests: {req}");
        Thread.Sleep(100);
        w.WriteLine(result.ToUpper());
        w.Flush();
        client.Dispose();
    });

}


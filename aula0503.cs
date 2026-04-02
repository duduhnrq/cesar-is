using System;
using System.Threading;
using System.Collections.Generic;

void Tarefa(int id)
{
    Console.WriteLine($"Thread {id} executando");
}

const int NUM_THREADS = 100;
List<Thread> threads = new List<Thread>();

// Cria e inicia 100 threads
for (int i = 0; i < NUM_THREADS; i++)
{
    int id = i; // Captura local para evitar closure bug
    Thread t = new Thread(() => Tarefa(id));
    threads.Add(t);
    t.Start();
}

// Aguarda todas as threads finalizarem
foreach (Thread t in threads)
{
    t.Join();
}

Console.WriteLine("Todas as threads finalizaram!");
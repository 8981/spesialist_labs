
Thread t0 = new Thread(PrintA) { Name = "A"};
Thread t1 = new Thread(PrintB) { Name = "B"};
t0.Start();
t1.Start(t0);


static void PrintA()
{
    for (int i = 1; i <= 100; i++)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {i}");
    }
}

static void PrintB(object? p)
{
    if (p is Thread t)
    {
        //момент взял уже из решения предложенное препоодавателем
        if (t.ThreadState == ThreadState.Unstarted)
            return;
        Console.WriteLine($"Thread state: {t.ThreadState}");
        t.Join();
    }
        
    for (int i = 1; i <= 100; i++)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {i}");
    }
}




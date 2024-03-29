﻿Sync s = new Sync();

new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        lock (s)
        {
            while (!s.phase)
                Monitor.Wait(s);
            s.x = Math.Cos(s.x);
            Console.Write($"{s.x} ");
            s.phase = !s.phase;
            Monitor.Pulse(s);
        }
    }

}).Start();

new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        lock (s)
        {
            while (s.phase)
                Monitor.Wait(s);
            s.x = Math.Acos(s.x);
            Console.WriteLine($"{s.x}");
            s.phase = !s.phase;
            Monitor.Pulse(s);
        }
    }

}).Start();

class Sync
{
    public double x = 1;
    public bool phase = true;
}


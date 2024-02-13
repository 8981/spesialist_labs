
Thread t0 = new Thread(new MyThread { Name = "A", Start = 2, End = 8 }.PrintFromTo);
Thread t1 = new Thread(new MyThread { Name = "B", Start = 1, End = 10 }.PrintFromTo);
Thread t2 = new Thread(new MyThread { Name = "C", Start = 3, End = 9 }.PrintFromTo);
Thread t3 = new Thread(new MyThread { Name = "D", Start = 6, End = 11 }.PrintFromTo);

t0.Start();
t1.Start();
t2.Start();
t3.Start();

public class MyThread
{
    public string Name { get; set; }
    public int Start {  get; set; }
    public int End { get; set; }

    public void PrintFromTo()
    {
        Thread.CurrentThread.Name = Name;
        for (int i = Start; i <= End; i++)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {i}");
        }
    }
}











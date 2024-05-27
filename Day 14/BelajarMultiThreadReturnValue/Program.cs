using System.Threading;


class Program{
    static void Main(){
        // BlueArchiveUI();
        // BlueArchiveUpdate();


        Thread thread1 = new(BlueArchiveWelcome);
        Thread thread2 = new(BlueArchiveMenu);
        Thread thread3 = new(BlueArchiveUpdater);
        Maths maths = new Maths();
        Thread thread4 = new Thread(() => BlueArchiveID(maths));


        thread3.IsBackground =  true;
        // thread1.Priority = ThreadPriority.Highest; //forbidden technique
        // thread3.Priority = ThreadPriority.Lowest; //forbidden technique
       
        // thread1.Name = "BA-Welcome"; //Thread name
        thread1.Start();
        // thread2.Name = "BA-Menu"; //Thread name
        thread2.Start();
        // thread3.Name = "BA-Update"; //Thread name
        thread3.Start();
        thread3.Join(); //TO NEGATE IS BACKGROUND TRUE! to wait background to finish actually


        thread4.Start();
    }


    public static void BlueArchiveWelcome(){
        // Console.WriteLine("Your PID:" + Thread.CurrentThread.ManagedThreadId); //Thread ID
        // Console.WriteLine("Enter name: ");
        // string name = Console.ReadLine();
        // Console.WriteLine($"Welcome, {name}Sensei!\n");
        Console.WriteLine($"Welcome, Sensei!\n");
    }


    public static void BlueArchiveMenu(){
        // Console.WriteLine("Your PID:" + Thread.CurrentThread.ManagedThreadId); //Thread ID
        Console.WriteLine("Welcome to the menu!\n");
    }




    public static void BlueArchiveUpdater(){
        // Console.WriteLine("Your PID:" + Thread.CurrentThread.ManagedThreadId); //Thread ID
        string[] loadingFrames = {"|", "/", "-", "\\"};
        int currentFrame = 0;


        for (int i = 0; i < 50; i++)
        {
            System.Console.Write($"\rUpdating: Loading{loadingFrames[currentFrame]}");
            currentFrame = (currentFrame + 1) % loadingFrames.Length;
            Thread.Sleep(100);
        }
        System.Console.WriteLine("\nUpdate done!");


        // //Primitive
        // System.Console.WriteLine("Updating:");
        // for (int i = 1; i <= 10; i++)
        // {
        //     System.Console.Write(i.ToString() + " ");
        //     Thread.Sleep(100);
        // }
        // System.Console.WriteLine("Done!");
    }


    public static void BlueArchiveID(Maths maths){
        System.Console.WriteLine("\nInput ID: ");
        int input = Int32.Parse(Console.ReadLine());
        int result = maths.Login(input);
        System.Console.WriteLine($"\nYour ID: {result}-UID");
    }


}


class Maths(){
    public int Login(int x){
        return x;
    }
}

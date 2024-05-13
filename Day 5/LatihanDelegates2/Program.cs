public delegate float MyDelegate(int a, int b);
class Program 
{
	static void Main()
	{
		Subscriber subscriber = new();
		MyDelegate del = subscriber.Add; // kasih tau alamatnya
		// MyDelegate del = subscriber.Add(); // manggil si Add
		System.Console.WriteLine(del?.Invoke(2,78));
        //kenapa  pakai tanda tanya? karena kalau sebelumnya dell = null akan error
	}
}
class Subscriber
{
	public float Add(int a, int b)
	{
		return (a*b);
	}
}
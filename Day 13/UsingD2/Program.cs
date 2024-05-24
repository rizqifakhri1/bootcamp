class Program {
    static void Main(string[] args) {
        string fileName = "pintarfile.text";

        FileManager fm = new();
        fm.Write(fileName, "Aku Ingin Hidup");
        // System.Console.WriteLine(fm.ReadLine(fileName));
    }
}

class FileManager {
    public void Write(string path, string message){
        using(StreamWriter stream = new(path)){
            stream.WriteLine(message);
        }
    }

    public string ReadLine(string path){
        string result;
        using (StreamReader stream = new(path)){
            result = stream.ReadLine();
        }
        return result;
    }
}
public delegate void MyDelegate();

public class Email
{
    public void EmailNotify()
    {
        System.Console.WriteLine("Email got notified");
    }
}

public class SMS
{
    public void SMSNotify()
    {
        System.Console.WriteLine("SMS got notified");
    }
}

class Program
{
    static void Main()
    {
        Email email = new();
        SMS sms = new();

        //cara manual untuk pemanggilan email
        //email.EmailNotify();

        MyDelegate delegates = email.EmailNotify;
        delegates += sms.SMSNotify;

        delegates();


    }
}
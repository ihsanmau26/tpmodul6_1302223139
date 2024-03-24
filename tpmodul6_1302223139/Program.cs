using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        this.id = GenerateRandomId();
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int countToAdd)
    {
        playCount += countToAdd;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video Details:");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }

    private int GenerateRandomId()
    {
        Random rand = new Random();
        return rand.Next(10000, 99999);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string namaPraktikan = "Ihsan Maulana";
        SayaTubeVideo video = new SayaTubeVideo($"Tutorial Design By Contract – {namaPraktikan}");

        video.PrintVideoDetails();
    }
}
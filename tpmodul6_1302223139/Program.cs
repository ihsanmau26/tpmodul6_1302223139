using System;
using System.Diagnostics.Contracts;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul video harus memiliki " +
                "panjang maksimal 100 karakter dan tidak boleh null.");
        }

        this.id = GenerateRandomId();
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int countToAdd)
    {
        Contract.Requires<ArgumentOutOfRangeException>(countToAdd >= 0 && countToAdd 
            <= 10_000_000, "Input penambahan play count harus antara 0 dan 10.000.000.");

        try
        {
            checked
            {
                playCount += countToAdd;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow terdeteksi. " +
                "Jumlah penambahan play count melebihi batas maksimum.");
        }
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

        video.IncreasePlayCount(10);

        video.PrintVideoDetails();

        for (int i = 0; i < 5; i++)
        {
            video.IncreasePlayCount(1000);
        }

        video.PrintVideoDetails();
    }
}
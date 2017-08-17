namespace RecyclingStation
{
    public interface IGarbageManager
    {
        string ProcessGarbage(string name, double weight, double volumePerKg, string type);

        string Status();
    }
}
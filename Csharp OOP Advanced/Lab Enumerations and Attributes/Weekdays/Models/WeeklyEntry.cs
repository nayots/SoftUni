using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string weekday, string notes)
    {
        this.Weekday = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Notes = notes;
    }

    public WeekDay Weekday { get; private set; }
    public string Notes { get; private set; }

    public int CompareTo(WeeklyEntry other)
    {
        int result = this.Weekday.CompareTo(other.Weekday);

        if (result == 0)
        {
            result = this.Notes.CompareTo(other.Notes);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Weekday} - {this.Notes}";
    }
}
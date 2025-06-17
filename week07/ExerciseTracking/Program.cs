using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date
    {
        get { return _date; }
    }

    public int Minutes
    {
        get { return _minutes; }
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        // Determine units based on type
        string unit = (this is Swimming) ? "km" : "miles";
        string speedUnit = (this is Swimming) ? "kph" : "mph";
        string paceUnit = (this is Swimming) ? "min per km" : "min per mile";

        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - Distance: {GetDistance():F1} {unit}, Speed: {GetSpeed():F1} {speedUnit}, Pace: {GetPace():F2} {paceUnit}";
    }
}

class Running : Activity
{
    private double _distance; // miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / (Minutes / 60.0);
    }

    public override double GetPace()
    {
        return Minutes / _distance;
    }
}

class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (Minutes / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

class Swimming : Activity
{
    private int _laps; // laps in pool
    private const double LapLengthMeters = 50;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Convert laps x 50m to kilometers
        return (_laps * LapLengthMeters) / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Minutes / 60.0);
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),      // 3 miles in 30 minutes
            new Cycling(new DateTime(2022, 11, 4), 30, 12.0),     // 12 mph in 30 minutes
            new Swimming(new DateTime(2022, 11, 5), 30, 20)       // 20 laps in 30 minutes
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}


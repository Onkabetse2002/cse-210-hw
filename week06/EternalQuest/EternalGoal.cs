using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            return GetPoints();
        }

        public override string DisplayGoal()
        {
            return $"[ ] {GetName()} ({GetDescription()})";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
        }
    }
}

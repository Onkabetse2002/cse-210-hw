using System;

namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int points) : base(name, description, -points)
        {
        }

        public override int RecordEvent()
        {
            return GetPoints(); // Negative points
        }

        public override string DisplayGoal()
        {
            return $"[ ] {GetName()} ({GetDescription()}) - Deducts {Math.Abs(GetPoints())} points";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{GetName()},{GetDescription()},{GetPoints()}";
        }
    }
}

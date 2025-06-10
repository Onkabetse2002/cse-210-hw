using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            if (!IsComplete())
            {
                SetComplete();
                return GetPoints();
            }
            else
            {
                return 0; // Already completed
            }
        }

        public override string DisplayGoal()
        {
            return $"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{IsComplete()}";
        }
    }
}

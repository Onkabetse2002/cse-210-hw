using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesToComplete;
        private int _bonusPoints;
        private int _timesCompleted;

        public ChecklistGoal(string name, string description, int points, int timesToComplete, int bonusPoints) : base(name, description, points)
        {
            _timesToComplete = timesToComplete;
            _bonusPoints = bonusPoints;
            _timesCompleted = 0;
        }

        public override int RecordEvent()
        {
            _timesCompleted++;

            if (_timesCompleted == _timesToComplete)
            {
                SetComplete();
                return GetPoints() + _bonusPoints;
            }
            else if (_timesCompleted < _timesToComplete)
            {
                return GetPoints();
            }
            else
            {
                return 0; //Completed more times than required
            }
        }

        public override string DisplayGoal()
        {
            return $"[{(IsComplete() ? "X" : " ")}] {GetName()} ({GetDescription()}) -- Completed: {_timesCompleted}/{_timesToComplete}";
        }

        public override string GetChecklistProgress()
        {
            return $"Completed: {_timesCompleted}/{_timesToComplete}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_timesToComplete},{_bonusPoints},{_timesCompleted}";
        }
    }
}

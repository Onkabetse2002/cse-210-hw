using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;
        private bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPoints()
        {
            return _points;
        }

        public bool IsComplete()
        {
            return _isComplete;
        }

        public void SetComplete()
        {
            _isComplete = true;
        }

        public abstract int RecordEvent();

        public abstract string DisplayGoal();

        public virtual string GetChecklistProgress()
        {
            return ""; // Default implementation for non-checklist goals
        }

        public abstract string GetStringRepresentation();
    }
}

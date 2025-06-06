// WritingAssignment.cs
public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic) // Call the base class constructor
    {
        _title = title;
    }

    // Method to return the writing information
    public string GetWritingInformation()
    {
        // Accessing the student's name using a method from the base class
        return $"{_title} by {GetStudentName()}";
    }
}

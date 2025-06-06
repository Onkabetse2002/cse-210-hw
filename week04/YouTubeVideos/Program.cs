using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    // Display comment details
    public void DisplayComment()
    {
        Console.WriteLine($"{CommenterName}: {CommentText}");
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Display video details along with comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
    }
}

// Program execution
class Program
{
    static void Main()
    {
        // Creating video objects
        Video video1 = new Video("C# Basics", "John Doe", 300);
        Video video2 = new Video("Machine Learning Intro", "Jane Smith", 450);
        Video video3 = new Video("Cybersecurity Essentials", "Alice Brown", 600);

        // Adding comments
        video1.AddComment(new Comment("Mike", "Great explanation!"));
        video1.AddComment(new Comment("Lisa", "I love the examples."));
        video1.AddComment(new Comment("Tom", "Can you make a tutorial on OOP?"));

        video2.AddComment(new Comment("Sarah", "AI is fascinating!"));
        video2.AddComment(new Comment("David", "Very informative."));
        video2.AddComment(new Comment("Emma", "Thanks for sharing!"));

        video3.AddComment(new Comment("Chris", "Cybersecurity is so important nowadays."));
        video3.AddComment(new Comment("Sophia", "Can you recommend more resources?"));
        video3.AddComment(new Comment("Mark", "Great insights!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying details for each video
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}

namespace EventDemo;

class Program
{
    static void Main(string[] args)
    {
        CollageClassModel history = new CollageClassModel("History 101", 3);
        CollageClassModel math = new CollageClassModel("Calculus 201", 2);

        history.EnrollmentFull += CollageClass_EnrollmentFull;

        history.SignUpStudent("Tim Corey").PrintToConsole();
        history.SignUpStudent("Sue Storm").PrintToConsole();
        history.SignUpStudent("Joe Smith").PrintToConsole();
        history.SignUpStudent("Mary Jones").PrintToConsole();
        history.SignUpStudent("Sandy Patty").PrintToConsole();

        math.EnrollmentFull += CollageClass_EnrollmentFull;
        
        math.SignUpStudent("Tim Corey").PrintToConsole();
        math.SignUpStudent("Sue Storm").PrintToConsole();
        math.SignUpStudent("Joe Smith").PrintToConsole();
        
        Console.ReadLine();
    }

    private static void CollageClass_EnrollmentFull(object? sender, string e)
    {
        CollageClassModel model = (CollageClassModel)sender;
        
        Console.WriteLine();
        Console.WriteLine($"{model.CourseTitle}: Full");
        Console.WriteLine();
    }
}

public static class ConsoleHelpers
{
    public static void PrintToConsole(this string message)
    {
        Console.WriteLine(message);
    }
}

public class CollageClassModel
{
    public event EventHandler<string> EnrollmentFull;
    
    private List<string> enrolledStudents = new List<string>();
    private List<string> waitingList = new List<string>();

    public string CourseTitle { get; private set; }
    public int MaximumStudents { get; private set; }

    public CollageClassModel(string title, int maximumStudents)
    {
        CourseTitle = title;
        MaximumStudents = maximumStudents;
    }

    public string SignUpStudent(string studentName)
    {
        string output = "";
        if (enrolledStudents.Count < MaximumStudents)
        {
            enrolledStudents.Add(studentName);
            output = $"{studentName} was enrolled in {CourseTitle}";

            if (enrolledStudents.Count == MaximumStudents)
            {
                EnrollmentFull?.Invoke(this, $"{CourseTitle} enrollment is now full.");
            }
        }
        else
        {
            waitingList.Add(studentName);
            output = $"{studentName} was added to the wait list in {CourseTitle}";
        }

        return output;
    }
}
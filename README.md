# Events_csharp
This project is a simple C# console application that simulates a student enrollment system for college courses. The primary goal of this project is to demonstrate the practical use of Events in object-oriented programming.

Key Features
Encapsulation: The CollageClassModel class protects its internal state using private fields and properties with restricted accessors (private set).

Events: Implements EventHandler<string> to notify subscribers whenever a course reaches its maximum capacity.

Extension Methods: Includes a custom .PrintToConsole() helper method for strings to streamline console output and improve code readability.

Logic-based Enrollment: Automatically handles the logic of placing students into the main enrollment list or a waiting list based on the defined MaximumStudents limit.

How It Works
The application creates instances of different courses and subscribes to the EnrollmentFull event. As students are signed up, the model tracks the count. When the limit is reached, the event is triggered. The subscriber then uses the sender object and type casting to identify which specific course is full and displays a formatted notification to the user.

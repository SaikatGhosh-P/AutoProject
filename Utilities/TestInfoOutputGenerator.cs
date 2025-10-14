using System;

public class TestOutputGenerator
{
    // Define the column header names
    private static readonly string[] Headers = new string[]
    {
        "Loan Value", "Tenure Year", "Tenure Month", "Tenure Days",
        "Exp Maturity Amt", "Exp ROI", "Exp IPM / Q", "Exp AIA Amt"
    };

    // Define the required column widths for alignment (must match the header string)
    // Adjust these values to fine-tune alignment
    private static readonly int[] Widths = new int[]
    {
        14, 13, 13, 13, 18, 9, 9, 13
    };

    public static void GenerateTestOutput(
        string testName,
        string testDescription,
        object[] dataValues)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        Console.WriteLine($"[Test] {testName}");
        Console.WriteLine($"[Description] {testDescription}");
        Console.WriteLine("[Data] Test Data as Follows");

        // --- Separator Line ---
        int totalWidth = 0;
        foreach (int w in Widths)
        {
            totalWidth += w;
        }
        
        int separatorLength = totalWidth + (Headers.Length + 1);
        string separatorLine = new string('-', separatorLength);

        Console.WriteLine(separatorLine);

        Console.ForegroundColor = ConsoleColor.Red;
        // 2. Output Headers
        string headerOutput = "|";
        for (int i = 0; i < Headers.Length; i++)
        {
           
            headerOutput += String.Format(" {0,-" + Widths[i] + "} |", Headers[i]);
        }
        Console.WriteLine(headerOutput);

        // --- Separator Line ---
        Console.WriteLine(separatorLine);

        // 3. Output Data Row (Values)
        string dataOutput = "|";
        
        for (int i = 0; i < dataValues.Length; i++)
        {
            // Apply the same width used for the headers
            dataOutput += String.Format(" {0,-" + Widths[i] + "} |", dataValues[i]);
        }
        
        for (int i = dataValues.Length; i < Headers.Length; i++)
        {
            dataOutput += String.Format(" {0,-" + Widths[i] + "} |", "");
        }
        Console.WriteLine(dataOutput);
    }
}


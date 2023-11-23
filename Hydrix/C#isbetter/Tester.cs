using System;
using System.Collections.Generic;
using Ratings; // Be sure to include the appropriate namespace for your ProblemSet class

public class TestProblemSet
{
    private List<double> numbers1 = new List<double> { 1.0, 1.0, 1.0, 4.0, 8.0, 6.0, 10.0, 12.0, 2.0, 5.0 };
    private List<double> numbers2 = new List<double> { -5.0, 5.0 };
    private List<double> numbers3 = new List<double>();
    private List<double> numbers5 = new List<double> { 0.0 };
    private List<double> numbers4 = new List<double> { 5.0 };

    private Dictionary<string, int> map1 = new Dictionary<string, int>
    {
        { "CSE", 100 },
        { "MTH", 90 },
        { "MGT", 10 }
    };

    private Dictionary<string, int> map2 = new Dictionary<string, int>
    {
        { "cat", 5 },
        { "dog", 5 },
        { "fox", 4 }
    };

    private Dictionary<string, int> map3 = new Dictionary<string, int>();

    private Dictionary<string, int> map6 = new Dictionary<string, int>
    {
        { "cat", -5 },
        { "dog", 5 },
        { "fox", 4 }
    };

    private Dictionary<string, int> map4 = new Dictionary<string, int>
    {
        { "cat", -5 },
        { "dogd", -1 },
        { "fox", -4 }
    };

    
    public void TestSumOfDigits()
    {
        if (ProblemSet.SumOfDigits(123) != 6)
            throw new Exception("Test failed for input 123");

        if (ProblemSet.SumOfDigits(23) != 5)
            throw new Exception("Test failed for input 23");

        if (ProblemSet.SumOfDigits(98) != 17)
            throw new Exception("Test failed for input 98");
    }

    
    public void TestLargeSumOfDigits()
    {
        if (ProblemSet.SumOfDigits(222222) != 12)
            throw new Exception("Test failed for input 222222");

        if (ProblemSet.SumOfDigits(22223369) != 29)
            throw new Exception("Test failed for input 22223369");

        if (ProblemSet.SumOfDigits(123455564) != 35)
            throw new Exception("Test failed for input 123455564");
    }

    
    public void TestAverage()
    {
        double average1 = ProblemSet.Average(numbers1);
        double average2 = ProblemSet.Average(numbers2);
        double average3 = ProblemSet.Average(numbers3);
        double average5 = ProblemSet.Average(numbers5);
        double average4 = ProblemSet.Average(numbers4);

        if (Math.Abs(average1 - 5.0) >= 0.001)
            throw new Exception($"Test failed for numbers1: Expected 5.0, but got {average1}");

        if (Math.Abs(average2 - 0.0) >= 0.001)
            throw new Exception($"Test failed for numbers2: Expected 0.0, but got {average2}");

        if (Math.Abs(average3 - 0.0) >= 0.001)
            throw new Exception($"Test failed for numbers3: Expected 0.0, but got {average3}");

        if (Math.Abs(average5 - 0.0) >= 0.001)
            throw new Exception($"Test failed for numbers5: Expected 0.0, but got {average5}");

        if (Math.Abs(average4 - 5.0) >= 0.001)
            throw new Exception($"Test failed for numbers4: Expected 5.0, but got {average4}");
    }

    
    public void TestBestKey()
    {
        string result1 = ProblemSet.BestKey(map1);
        string result2 = ProblemSet.BestKey(map2);
        string result3 = ProblemSet.BestKey(map3);
        string result4 = ProblemSet.BestKey(map6);
        string result5 = ProblemSet.BestKey(map4);

        if (result1 != "CSE")
            throw new Exception($"Test failed for map1: Expected 'CSE', but got '{result1}'");

        if (result2 != "cat" && result2 != "dog")
            throw new Exception($"Test failed for map2: Expected 'cat' or 'dog', but got '{result2}'");

        if (result3 != "")
            throw new Exception($"Test failed for map3: Expected '', but got '{result3}'");

        if (result4 != "dog")
            throw new Exception($"Test failed for map6: Expected 'dog', but got '{result4}'");

        if (result5 != "dogd")
            throw new Exception($"Test failed for map4: Expected 'dogd', but got '{result5}'");
    }
}

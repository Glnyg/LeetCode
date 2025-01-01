namespace LeetCode.简单;

public class P3280
{
    public static TheoryData<string, string> GetCase()
    {
        var data = new TheoryData<string, string>()
        {
            { "2080-02-29", "100000100000-10-11101" },
            { "1900-01-01", "11101101100-1-1" },
        };
        return data;
    }

    [Theory]
    [MemberData(nameof(GetCase))]
    public void LeetCodeTest(string date, string expected)
    {
        Assert.Equal(ConvertDateToBinary(date), expected);
    }

    private string ConvertDateToBinary(string date)
    {
        var year = int.Parse(date[..4]);
        var month = int.Parse(date[5..7]);
        var day = int.Parse(date[8..10]);

        return $"{ConvertIntToBinary(year)}-{ConvertIntToBinary(month)}-{ConvertIntToBinary(day)}";

        string ConvertIntToBinary(int num) => num == 0 ? "0" : Convert.ToString(num, 2).TrimStart('0');
    }
}
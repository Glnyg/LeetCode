namespace LeetCode.中等;

public class P3403
{
    public static TheoryData<string, int, string> GetCase()
    {
        var data = new TheoryData<string, int, string>
        {
            { "dbca", 2, "dbc" },
            { "gggg", 4, "g" },
            { "gh", 1, "gh" },
            { "aann", 2, "nn" },
            { "nbjnc", 2, "nc" },
            { "jqjaqpq", 3, "qpq" },
        };
        return data;
    }

    [Theory]
    [MemberData(nameof(GetCase))]
    public void LeetCodeTest(string word, int numFriends, string expected)
    {
        Assert.Equal(AnswerString(word, numFriends), expected);
    }
    
    private string AnswerString(string word, int numFriends)
    {
        if (numFriends == 1) return word;
        
        var maxChat = word.ToHashSet().Max();
        
        if (word.Length == numFriends) return maxChat.ToString();
        
        var maxChatIndexArray = word
            .Select((ch, index) => (ch, index))
            .Where(x => x.ch == maxChat)
            .Select(x => (x.index, x.index + 1))
            .ToArray();
        
        while (true)
        {
            var temp = maxChatIndexArray.Where(x => x.Item2 < word.Length).ToArray();
            
            if (temp.Length <= 1) break;
            
            maxChat = temp.Select(x => word[x.Item2]).ToHashSet().Max();

            maxChatIndexArray = temp.Where(x => word[x.Item2] == maxChat).Select(x => x with { Item2 = x.Item2 + 1 }).ToArray();
        }
        
        return word.Substring(maxChatIndexArray.First().Item1, int.Min(word.Length - numFriends + 1, word.Length - maxChatIndexArray.First().Item1));
    }
}
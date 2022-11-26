using System;
using System.Collections.Generic;

namespace Word_Break_II
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var answer = s.WordBreak("pineapplepenapple", new List<string> { "apple", "pen", "applepen", "pine", "pineapple" });
      foreach (var str in answer) Console.WriteLine(str);
    }
  }

  public class Solution
  {
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
      return DFS(s, wordDict, new Dictionary<string, List<string>>());
    }

    List<string> DFS(string s, IList<string> wordDict, Dictionary<string, List<string>> hash)
    {
      if (hash.ContainsKey(s))
        return hash[s];

      List<string> res = new List<string>();
      if (string.IsNullOrWhiteSpace(s))
      {
        res.Add("");
        return res;
      }

      foreach (string word in wordDict)
      {
        if (s.StartsWith(word))
        {
          string right = s.Substring(word.Length);
          var results = DFS(right, wordDict, hash);
          foreach (string result in results)
          {
            string str = string.IsNullOrWhiteSpace(result) ? "" : " " + result;
            res.Add(word + str);
          }
        }
      }

      hash.Add(s, res);
      return res;
    }
  }
}

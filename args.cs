//
// Usage: /path/to/args.exe 1 -x -y 2 3 -z
//
using System;
using System.Collections.Generic;
using System.Linq;

public class Args
{
  static public void Main ()
  {
    var opts = ParseOptions(Environment.GetCommandLineArgs());
    Console.WriteLine("opts = {" + String.Join(", ", from v in opts select v.Key + "=>" + v.Value) + "}");
  }

  static public Dictionary<string, string> ParseOptions(string[] args) {
    var opts = new Dictionary<string, string>();

    for (int i = 0; i < args.Length; i++) {
      var arg = args[i];
      if (arg.Substring(0, 1) == "-") {
        var key = arg.Substring(1, arg.Length - 1);
        if (i + 1 < args.Length) {
          var next = args[i + 1];
          if (next.Substring(0, 1) == "-") {
            opts.Add(key, "");
          } else {
            opts.Add(key, next);
            i++;
          }
        } else {
          opts.Add(key, "");
        }
      }
    }

    return opts;
  }
}

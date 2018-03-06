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
    var args = new List<string>();
    var opts = new Dictionary<string, string>();

    var orig = System.Environment.GetCommandLineArgs();
    for (int i = 0; i < orig.Length; i++) {
      var arg = orig[i];
      if (arg.Substring(0, 1) == "-") {
        var key = arg.Substring(1, arg.Length - 1);
        if (i + 1 < orig.Length) {
          var next = orig[i + 1];
          if (next.Substring(0, 1) == "-") {
            opts.Add(key, "");
          } else {
            opts.Add(key, next);
            i++;
          }
        } else {
          opts.Add(key, "");
        }
      } else {
        args.Add(arg);
      }
    }

    Console.WriteLine("args = [" + String.Join(", ", from v in args select v) + "]");
    Console.WriteLine("opts = {" + String.Join(", ", from v in opts select v.Key + "=>" + v.Value) + "}");
  }
}

using System.Collections;

namespace SampleAPI
{
  public static class ArrayListExtension
  {
    public static void AddKvo(this ArrayList list, string? key, string? value)
    {
      if (string.IsNullOrEmpty(key)) { return; };
      if (string.IsNullOrEmpty(value)) { return; };
      list.Add($"{key}={value}");
    }

    public static string Join(this ArrayList list, char separator)
    {
      return string.Join(separator, list.ToArray());
    }
  }
}
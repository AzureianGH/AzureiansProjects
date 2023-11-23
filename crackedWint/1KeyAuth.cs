// Decompiled with JetBrains decompiler
// Type: KeyAuth.encryption
// Assembly: keyauth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8DC670F4-051F-46A9-8348-44431FE85723
// Assembly location: E:\Downloads\winrta\winterz spoof\keyauth.dll

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;


#nullable enable
namespace KeyAuth
{
  public static class encryption
  {
    public static string HashHMAC(string enckey, string resp) => encryption.byte_arr_to_str(new HMACSHA256(Encoding.ASCII.GetBytes(enckey)).ComputeHash(Encoding.ASCII.GetBytes(resp)));

    public static string byte_arr_to_str(byte[] ba)
    {
      StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
      foreach (byte num in ba)
        stringBuilder.AppendFormat("{0:x2}", (object) num);
      return stringBuilder.ToString();
    }

    public static byte[] str_to_byte_arr(string hex)
    {
      try
      {
        int length = hex.Length;
        byte[] byteArr = new byte[length / 2];
        for (int startIndex = 0; startIndex < length; startIndex += 2)
          byteArr[startIndex / 2] = Convert.ToByte(hex.Substring(startIndex, 2), 16);
        return byteArr;
      }
      catch
      {
        api.error("The session has ended, open program again.");
        Environment.Exit(0);
        return (byte[]) null;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static bool CheckStringsFixedTime(string str1, string str2)
    {
      if (str1.Length != str2.Length)
        return false;
      int num = 0;
      for (int index = 0; index < str1.Length; ++index)
        num |= (int) str1[index] ^ (int) str2[index];
      return num == 0;
    }

    public static string iv_key() => Guid.NewGuid().ToString().Substring(0, 16);
  }
}

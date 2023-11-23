// Decompiled with JetBrains decompiler
// Type: KeyAuth.json_wrapper
// Assembly: keyauth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8DC670F4-051F-46A9-8348-44431FE85723
// Assembly location: E:\Downloads\winrta\winterz spoof\keyauth.dll

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;


#nullable enable
namespace KeyAuth
{
  public class json_wrapper
  {
    private DataContractJsonSerializer serializer;
    private object current_object;

    public static bool is_serializable(Type to_check) => to_check.IsSerializable || to_check.IsDefined(typeof (DataContractAttribute), true);

    public json_wrapper(object obj_to_work_with)
    {
      this.current_object = obj_to_work_with;
      Type type = this.current_object.GetType();
      this.serializer = new DataContractJsonSerializer(type);
      if (!json_wrapper.is_serializable(type))
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
        interpolatedStringHandler.AppendLiteral("the object ");
        interpolatedStringHandler.AppendFormatted<object>(this.current_object);
        interpolatedStringHandler.AppendLiteral(" isn't a serializable");
        throw new Exception(interpolatedStringHandler.ToStringAndClear());
      }
    }

    public object string_to_object(string json)
    {
      using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
        return this.serializer.ReadObject((Stream) memoryStream);
    }

    public T string_to_generic<T>(string json) => (T) this.string_to_object(json);
  }
}

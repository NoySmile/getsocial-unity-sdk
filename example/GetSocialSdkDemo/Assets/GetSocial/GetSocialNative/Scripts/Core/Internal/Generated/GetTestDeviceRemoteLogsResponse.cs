#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
/**
 * Autogenerated by Thrift Compiler ()
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace GetSocialSdk.Core 
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class GetTestDeviceRemoteLogsResponse : TBase
  {
    private List<TestDeviceRemoteLog> _logs;

    public List<TestDeviceRemoteLog> Logs
    {
      get
      {
        return _logs;
      }
      set
      {
        __isset.logs = true;
        this._logs = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool logs;
    }

    public GetTestDeviceRemoteLogsResponse() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.List) {
                {
                  Logs = new List<TestDeviceRemoteLog>();
                  TList _list8 = iprot.ReadListBegin();
                  for( int _i9 = 0; _i9 < _list8.Count; ++_i9)
                  {
                    TestDeviceRemoteLog _elem10;
                    _elem10 = new TestDeviceRemoteLog();
                    _elem10.Read(iprot);
                    Logs.Add(_elem10);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("GetTestDeviceRemoteLogsResponse");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Logs != null && __isset.logs) {
          field.Name = "logs";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Logs.Count));
            foreach (TestDeviceRemoteLog _iter11 in Logs)
            {
              _iter11.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("GetTestDeviceRemoteLogsResponse(");
      bool __first = true;
      if (Logs != null && __isset.logs) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Logs: ");
        __sb.Append(Logs.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif

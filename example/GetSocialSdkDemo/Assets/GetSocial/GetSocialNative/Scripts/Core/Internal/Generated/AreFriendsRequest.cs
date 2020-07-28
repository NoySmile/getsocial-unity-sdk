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

  /// <summary>
  /// #sdk7
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class AreFriendsRequest : TBase
  {
    private string _sessionId;
    private THashSet<string> _userIds;

    public string SessionId
    {
      get
      {
        return _sessionId;
      }
      set
      {
        __isset.sessionId = true;
        this._sessionId = value;
      }
    }

    public THashSet<string> UserIds
    {
      get
      {
        return _userIds;
      }
      set
      {
        __isset.userIds = true;
        this._userIds = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool sessionId;
      public bool userIds;
    }

    public AreFriendsRequest() {
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
              if (field.Type == TType.String) {
                SessionId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.Set) {
                {
                  UserIds = new THashSet<string>();
                  TSet _set68 = iprot.ReadSetBegin();
                  for( int _i69 = 0; _i69 < _set68.Count; ++_i69)
                  {
                    string _elem70;
                    _elem70 = iprot.ReadString();
                    UserIds.Add(_elem70);
                  }
                  iprot.ReadSetEnd();
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
        TStruct struc = new TStruct("AreFriendsRequest");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (SessionId != null && __isset.sessionId) {
          field.Name = "sessionId";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(SessionId);
          oprot.WriteFieldEnd();
        }
        if (UserIds != null && __isset.userIds) {
          field.Name = "userIds";
          field.Type = TType.Set;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteSetBegin(new TSet(TType.String, UserIds.Count));
            foreach (string _iter71 in UserIds)
            {
              oprot.WriteString(_iter71);
            }
            oprot.WriteSetEnd();
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
      StringBuilder __sb = new StringBuilder("AreFriendsRequest(");
      bool __first = true;
      if (SessionId != null && __isset.sessionId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SessionId: ");
        __sb.Append(SessionId);
      }
      if (UserIds != null && __isset.userIds) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UserIds: ");
        __sb.Append(UserIds);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
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


#if !SILVERLIGHT
[Serializable]
#endif
public partial class THSdkAuthRequest : TBase
{
  private string _appId;
  private string _userId;
  private string _password;
  private THSuperProperties _sessionProperties;
  private string _appSignatureFingerprint;

  public string AppId
  {
    get
    {
      return _appId;
    }
    set
    {
      __isset.appId = true;
      this._appId = value;
    }
  }

  public string UserId
  {
    get
    {
      return _userId;
    }
    set
    {
      __isset.userId = true;
      this._userId = value;
    }
  }

  public string Password
  {
    get
    {
      return _password;
    }
    set
    {
      __isset.password = true;
      this._password = value;
    }
  }

  public THSuperProperties SessionProperties
  {
    get
    {
      return _sessionProperties;
    }
    set
    {
      __isset.sessionProperties = true;
      this._sessionProperties = value;
    }
  }

  /// <summary>
  /// On iOS: SHA256(Apple TeamID), eg: 1936b257b85ca35813a9d7c2a21b81a3ece3da9ac9D84de984c59fef92df2cdD
  /// </summary>
  public string AppSignatureFingerprint
  {
    get
    {
      return _appSignatureFingerprint;
    }
    set
    {
      __isset.appSignatureFingerprint = true;
      this._appSignatureFingerprint = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool appId;
    public bool userId;
    public bool password;
    public bool sessionProperties;
    public bool appSignatureFingerprint;
  }

  public THSdkAuthRequest() {
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
              AppId = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              UserId = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              Password = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              SessionProperties = new THSuperProperties();
              SessionProperties.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              AppSignatureFingerprint = iprot.ReadString();
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
      TStruct struc = new TStruct("THSdkAuthRequest");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (AppId != null && __isset.appId) {
        field.Name = "appId";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(AppId);
        oprot.WriteFieldEnd();
      }
      if (UserId != null && __isset.userId) {
        field.Name = "userId";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(UserId);
        oprot.WriteFieldEnd();
      }
      if (Password != null && __isset.password) {
        field.Name = "password";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Password);
        oprot.WriteFieldEnd();
      }
      if (SessionProperties != null && __isset.sessionProperties) {
        field.Name = "sessionProperties";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        SessionProperties.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (AppSignatureFingerprint != null && __isset.appSignatureFingerprint) {
        field.Name = "appSignatureFingerprint";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(AppSignatureFingerprint);
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
    StringBuilder __sb = new StringBuilder("THSdkAuthRequest(");
    bool __first = true;
    if (AppId != null && __isset.appId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("AppId: ");
      __sb.Append(AppId);
    }
    if (UserId != null && __isset.userId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("UserId: ");
      __sb.Append(UserId);
    }
    if (Password != null && __isset.password) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Password: ");
      __sb.Append(Password);
    }
    if (SessionProperties != null && __isset.sessionProperties) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("SessionProperties: ");
      __sb.Append(SessionProperties== null ? "<null>" : SessionProperties.ToString());
    }
    if (AppSignatureFingerprint != null && __isset.appSignatureFingerprint) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("AppSignatureFingerprint: ");
      __sb.Append(AppSignatureFingerprint);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}
#endif

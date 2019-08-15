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
public partial class THFingerprint : TBase
{
  private string _screenWidth;
  private string _screenHeight;
  private string _devicePixelRatio;
  private string _osName;
  private string _osVersion;
  private string _userAgent;
  private string _deviceBrand;
  private string _deviceModel;
  private string _ip;

  public string ScreenWidth
  {
    get
    {
      return _screenWidth;
    }
    set
    {
      __isset.screenWidth = true;
      this._screenWidth = value;
    }
  }

  public string ScreenHeight
  {
    get
    {
      return _screenHeight;
    }
    set
    {
      __isset.screenHeight = true;
      this._screenHeight = value;
    }
  }

  public string DevicePixelRatio
  {
    get
    {
      return _devicePixelRatio;
    }
    set
    {
      __isset.devicePixelRatio = true;
      this._devicePixelRatio = value;
    }
  }

  public string OsName
  {
    get
    {
      return _osName;
    }
    set
    {
      __isset.osName = true;
      this._osName = value;
    }
  }

  /// <summary>
  /// only set by Hades, using super properties
  /// </summary>
  public string OsVersion
  {
    get
    {
      return _osVersion;
    }
    set
    {
      __isset.osVersion = true;
      this._osVersion = value;
    }
  }

  /// <summary>
  /// only set by Hades, using super properties
  /// </summary>
  public string UserAgent
  {
    get
    {
      return _userAgent;
    }
    set
    {
      __isset.userAgent = true;
      this._userAgent = value;
    }
  }

  /// <summary>
  /// only set by the landing page
  /// </summary>
  public string DeviceBrand
  {
    get
    {
      return _deviceBrand;
    }
    set
    {
      __isset.deviceBrand = true;
      this._deviceBrand = value;
    }
  }

  public string DeviceModel
  {
    get
    {
      return _deviceModel;
    }
    set
    {
      __isset.deviceModel = true;
      this._deviceModel = value;
    }
  }

  public string Ip
  {
    get
    {
      return _ip;
    }
    set
    {
      __isset.ip = true;
      this._ip = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool screenWidth;
    public bool screenHeight;
    public bool devicePixelRatio;
    public bool osName;
    public bool osVersion;
    public bool userAgent;
    public bool deviceBrand;
    public bool deviceModel;
    public bool ip;
  }

  public THFingerprint() {
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
              ScreenWidth = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              ScreenHeight = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              DevicePixelRatio = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              OsName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              OsVersion = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              UserAgent = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.String) {
              DeviceBrand = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.String) {
              DeviceModel = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.String) {
              Ip = iprot.ReadString();
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
      TStruct struc = new TStruct("THFingerprint");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ScreenWidth != null && __isset.screenWidth) {
        field.Name = "screenWidth";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ScreenWidth);
        oprot.WriteFieldEnd();
      }
      if (ScreenHeight != null && __isset.screenHeight) {
        field.Name = "screenHeight";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ScreenHeight);
        oprot.WriteFieldEnd();
      }
      if (DevicePixelRatio != null && __isset.devicePixelRatio) {
        field.Name = "devicePixelRatio";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DevicePixelRatio);
        oprot.WriteFieldEnd();
      }
      if (OsName != null && __isset.osName) {
        field.Name = "osName";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(OsName);
        oprot.WriteFieldEnd();
      }
      if (OsVersion != null && __isset.osVersion) {
        field.Name = "osVersion";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(OsVersion);
        oprot.WriteFieldEnd();
      }
      if (UserAgent != null && __isset.userAgent) {
        field.Name = "userAgent";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(UserAgent);
        oprot.WriteFieldEnd();
      }
      if (DeviceBrand != null && __isset.deviceBrand) {
        field.Name = "deviceBrand";
        field.Type = TType.String;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DeviceBrand);
        oprot.WriteFieldEnd();
      }
      if (DeviceModel != null && __isset.deviceModel) {
        field.Name = "deviceModel";
        field.Type = TType.String;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DeviceModel);
        oprot.WriteFieldEnd();
      }
      if (Ip != null && __isset.ip) {
        field.Name = "ip";
        field.Type = TType.String;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Ip);
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
    StringBuilder __sb = new StringBuilder("THFingerprint(");
    bool __first = true;
    if (ScreenWidth != null && __isset.screenWidth) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ScreenWidth: ");
      __sb.Append(ScreenWidth);
    }
    if (ScreenHeight != null && __isset.screenHeight) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ScreenHeight: ");
      __sb.Append(ScreenHeight);
    }
    if (DevicePixelRatio != null && __isset.devicePixelRatio) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("DevicePixelRatio: ");
      __sb.Append(DevicePixelRatio);
    }
    if (OsName != null && __isset.osName) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("OsName: ");
      __sb.Append(OsName);
    }
    if (OsVersion != null && __isset.osVersion) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("OsVersion: ");
      __sb.Append(OsVersion);
    }
    if (UserAgent != null && __isset.userAgent) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("UserAgent: ");
      __sb.Append(UserAgent);
    }
    if (DeviceBrand != null && __isset.deviceBrand) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("DeviceBrand: ");
      __sb.Append(DeviceBrand);
    }
    if (DeviceModel != null && __isset.deviceModel) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("DeviceModel: ");
      __sb.Append(DeviceModel);
    }
    if (Ip != null && __isset.ip) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Ip: ");
      __sb.Append(Ip);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}
#endif

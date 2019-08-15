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
public partial class THButton : TBase
{
  private string _buttonAction;
  private string _buttonTitle;
  private THAction _action;

  public string ButtonAction
  {
    get
    {
      return _buttonAction;
    }
    set
    {
      __isset.buttonAction = true;
      this._buttonAction = value;
    }
  }

  public string ButtonTitle
  {
    get
    {
      return _buttonTitle;
    }
    set
    {
      __isset.buttonTitle = true;
      this._buttonTitle = value;
    }
  }

  public THAction Action
  {
    get
    {
      return _action;
    }
    set
    {
      __isset.action = true;
      this._action = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool buttonAction;
    public bool buttonTitle;
    public bool action;
  }

  public THButton() {
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
              ButtonAction = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              ButtonTitle = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Action = new THAction();
              Action.Read(iprot);
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
      TStruct struc = new TStruct("THButton");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ButtonAction != null && __isset.buttonAction) {
        field.Name = "buttonAction";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ButtonAction);
        oprot.WriteFieldEnd();
      }
      if (ButtonTitle != null && __isset.buttonTitle) {
        field.Name = "buttonTitle";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ButtonTitle);
        oprot.WriteFieldEnd();
      }
      if (Action != null && __isset.action) {
        field.Name = "action";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        Action.Write(oprot);
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
    StringBuilder __sb = new StringBuilder("THButton(");
    bool __first = true;
    if (ButtonAction != null && __isset.buttonAction) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ButtonAction: ");
      __sb.Append(ButtonAction);
    }
    if (ButtonTitle != null && __isset.buttonTitle) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ButtonTitle: ");
      __sb.Append(ButtonTitle);
    }
    if (Action != null && __isset.action) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Action: ");
      __sb.Append(Action== null ? "<null>" : Action.ToString());
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}
#endif

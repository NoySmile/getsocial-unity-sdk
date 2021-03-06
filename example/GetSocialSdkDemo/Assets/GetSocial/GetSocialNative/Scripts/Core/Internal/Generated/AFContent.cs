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
  public partial class AFContent : TBase
  {
    private string _text;
    private List<AFAttachment> _attachments;
    private AFButton _button;

    public string Text
    {
      get
      {
        return _text;
      }
      set
      {
        __isset.text = true;
        this._text = value;
      }
    }

    public List<AFAttachment> Attachments
    {
      get
      {
        return _attachments;
      }
      set
      {
        __isset.attachments = true;
        this._attachments = value;
      }
    }

    public AFButton Button
    {
      get
      {
        return _button;
      }
      set
      {
        __isset.button = true;
        this._button = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool text;
      public bool attachments;
      public bool button;
    }

    public AFContent() {
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
                Text = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  Attachments = new List<AFAttachment>();
                  TList _list0 = iprot.ReadListBegin();
                  for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                  {
                    AFAttachment _elem2;
                    _elem2 = new AFAttachment();
                    _elem2.Read(iprot);
                    Attachments.Add(_elem2);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.Struct) {
                Button = new AFButton();
                Button.Read(iprot);
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
        TStruct struc = new TStruct("AFContent");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Text != null && __isset.text) {
          field.Name = "text";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Text);
          oprot.WriteFieldEnd();
        }
        if (Attachments != null && __isset.attachments) {
          field.Name = "attachments";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Attachments.Count));
            foreach (AFAttachment _iter3 in Attachments)
            {
              _iter3.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Button != null && __isset.button) {
          field.Name = "button";
          field.Type = TType.Struct;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          Button.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("AFContent(");
      bool __first = true;
      if (Text != null && __isset.text) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Text: ");
        __sb.Append(Text);
      }
      if (Attachments != null && __isset.attachments) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Attachments: ");
        __sb.Append(Attachments.ToDebugString());
      }
      if (Button != null && __isset.button) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Button: ");
        __sb.Append(Button== null ? "<null>" : Button.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif

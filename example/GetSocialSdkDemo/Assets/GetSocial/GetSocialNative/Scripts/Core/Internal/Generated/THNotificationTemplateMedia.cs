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
public partial class THNotificationTemplateMedia : TBase
{
  private string _image;
  private string _video;
  private string _backgroundImage;
  private string _titleColor;
  private string _textColor;
  private string _sound;

  public string Image
  {
    get
    {
      return _image;
    }
    set
    {
      __isset.image = true;
      this._image = value;
    }
  }

  public string Video
  {
    get
    {
      return _video;
    }
    set
    {
      __isset.video = true;
      this._video = value;
    }
  }

  public string BackgroundImage
  {
    get
    {
      return _backgroundImage;
    }
    set
    {
      __isset.backgroundImage = true;
      this._backgroundImage = value;
    }
  }

  public string TitleColor
  {
    get
    {
      return _titleColor;
    }
    set
    {
      __isset.titleColor = true;
      this._titleColor = value;
    }
  }

  public string TextColor
  {
    get
    {
      return _textColor;
    }
    set
    {
      __isset.textColor = true;
      this._textColor = value;
    }
  }

  public string Sound
  {
    get
    {
      return _sound;
    }
    set
    {
      __isset.sound = true;
      this._sound = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool image;
    public bool video;
    public bool backgroundImage;
    public bool titleColor;
    public bool textColor;
    public bool sound;
  }

  public THNotificationTemplateMedia() {
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
              Image = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Video = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              BackgroundImage = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              TitleColor = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              TextColor = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              Sound = iprot.ReadString();
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
      TStruct struc = new TStruct("THNotificationTemplateMedia");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Image != null && __isset.image) {
        field.Name = "image";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Image);
        oprot.WriteFieldEnd();
      }
      if (Video != null && __isset.video) {
        field.Name = "video";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Video);
        oprot.WriteFieldEnd();
      }
      if (BackgroundImage != null && __isset.backgroundImage) {
        field.Name = "backgroundImage";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(BackgroundImage);
        oprot.WriteFieldEnd();
      }
      if (TitleColor != null && __isset.titleColor) {
        field.Name = "titleColor";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(TitleColor);
        oprot.WriteFieldEnd();
      }
      if (TextColor != null && __isset.textColor) {
        field.Name = "textColor";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(TextColor);
        oprot.WriteFieldEnd();
      }
      if (Sound != null && __isset.sound) {
        field.Name = "sound";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Sound);
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
    StringBuilder __sb = new StringBuilder("THNotificationTemplateMedia(");
    bool __first = true;
    if (Image != null && __isset.image) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Image: ");
      __sb.Append(Image);
    }
    if (Video != null && __isset.video) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Video: ");
      __sb.Append(Video);
    }
    if (BackgroundImage != null && __isset.backgroundImage) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("BackgroundImage: ");
      __sb.Append(BackgroundImage);
    }
    if (TitleColor != null && __isset.titleColor) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("TitleColor: ");
      __sb.Append(TitleColor);
    }
    if (TextColor != null && __isset.textColor) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("TextColor: ");
      __sb.Append(TextColor);
    }
    if (Sound != null && __isset.sound) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Sound: ");
      __sb.Append(Sound);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}
#endif
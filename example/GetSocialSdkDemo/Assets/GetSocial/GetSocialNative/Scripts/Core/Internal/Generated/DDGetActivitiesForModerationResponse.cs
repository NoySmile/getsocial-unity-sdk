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
  /// options: [-]reports, [-]entity
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class DDGetActivitiesForModerationResponse : TBase
  {
    private List<AFActivityForModeration> _data;
    private List<AFEntityReference> _entityDetails;
    private Dictionary<string, THPublicUser> _authors;
    private string _nextCursor;

    public List<AFActivityForModeration> Data
    {
      get
      {
        return _data;
      }
      set
      {
        __isset.data = true;
        this._data = value;
      }
    }

    public List<AFEntityReference> EntityDetails
    {
      get
      {
        return _entityDetails;
      }
      set
      {
        __isset.entityDetails = true;
        this._entityDetails = value;
      }
    }

    /// <summary>
    /// if SGEntityType is Activity, it is not included this map
    /// </summary>
    public Dictionary<string, THPublicUser> Authors
    {
      get
      {
        return _authors;
      }
      set
      {
        __isset.authors = true;
        this._authors = value;
      }
    }

    public string NextCursor
    {
      get
      {
        return _nextCursor;
      }
      set
      {
        __isset.nextCursor = true;
        this._nextCursor = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool data;
      public bool entityDetails;
      public bool authors;
      public bool nextCursor;
    }

    public DDGetActivitiesForModerationResponse() {
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
                  Data = new List<AFActivityForModeration>();
                  TList _list234 = iprot.ReadListBegin();
                  for( int _i235 = 0; _i235 < _list234.Count; ++_i235)
                  {
                    AFActivityForModeration _elem236;
                    _elem236 = new AFActivityForModeration();
                    _elem236.Read(iprot);
                    Data.Add(_elem236);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  EntityDetails = new List<AFEntityReference>();
                  TList _list237 = iprot.ReadListBegin();
                  for( int _i238 = 0; _i238 < _list237.Count; ++_i238)
                  {
                    AFEntityReference _elem239;
                    _elem239 = new AFEntityReference();
                    _elem239.Read(iprot);
                    EntityDetails.Add(_elem239);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.Map) {
                {
                  Authors = new Dictionary<string, THPublicUser>();
                  TMap _map240 = iprot.ReadMapBegin();
                  for( int _i241 = 0; _i241 < _map240.Count; ++_i241)
                  {
                    string _key242;
                    THPublicUser _val243;
                    _key242 = iprot.ReadString();
                    _val243 = new THPublicUser();
                    _val243.Read(iprot);
                    Authors[_key242] = _val243;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                NextCursor = iprot.ReadString();
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
        TStruct struc = new TStruct("DDGetActivitiesForModerationResponse");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Data != null && __isset.data) {
          field.Name = "data";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Data.Count));
            foreach (AFActivityForModeration _iter244 in Data)
            {
              _iter244.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (EntityDetails != null && __isset.entityDetails) {
          field.Name = "entityDetails";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, EntityDetails.Count));
            foreach (AFEntityReference _iter245 in EntityDetails)
            {
              _iter245.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Authors != null && __isset.authors) {
          field.Name = "authors";
          field.Type = TType.Map;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.Struct, Authors.Count));
            foreach (string _iter246 in Authors.Keys)
            {
              oprot.WriteString(_iter246);
              Authors[_iter246].Write(oprot);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (NextCursor != null && __isset.nextCursor) {
          field.Name = "nextCursor";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(NextCursor);
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
      StringBuilder __sb = new StringBuilder("DDGetActivitiesForModerationResponse(");
      bool __first = true;
      if (Data != null && __isset.data) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Data: ");
        __sb.Append(Data.ToDebugString());
      }
      if (EntityDetails != null && __isset.entityDetails) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("EntityDetails: ");
        __sb.Append(EntityDetails.ToDebugString());
      }
      if (Authors != null && __isset.authors) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Authors: ");
        __sb.Append(Authors.ToDebugString());
      }
      if (NextCursor != null && __isset.nextCursor) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NextCursor: ");
        __sb.Append(NextCursor);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
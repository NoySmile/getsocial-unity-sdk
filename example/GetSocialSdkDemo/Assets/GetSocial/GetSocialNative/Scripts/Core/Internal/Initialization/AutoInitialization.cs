﻿#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
using UnityEngine;

namespace GetSocialSdk.Core
{
    internal static class AutoInitialization
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            if (Dependencies.GetMetaDataReader().GetBool(MetaDataKeys.AutoInit, defaultValue: true))
            {
                GetSocial.Init();
            }
        }
    }
}
#endif

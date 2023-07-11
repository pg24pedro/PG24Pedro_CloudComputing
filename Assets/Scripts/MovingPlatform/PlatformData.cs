using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace VFSCloud
{
    [System.Serializable]
    public class PlatformData
    {
        public List<PlatformInfo> PlatformList;
        [SerializeField] public float Speed;

        public PlatformData()
        {
            PlatformList = new List<PlatformInfo>();  
        }

    }

    [System.Serializable]
    public class PlatformInfo
    {
        public float Speed;
        public float EasingDistance;
        public List<Vector3> Points;

        public PlatformInfo() 
        {
            Speed = 1.0f;
            EasingDistance = 0.5f;
            Points = new List<Vector3>();
        }

    }

}

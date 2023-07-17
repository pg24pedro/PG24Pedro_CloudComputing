using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCloud 
{
    public class TelemetryData : MonoBehaviour
    {
        public string level;
        public Vector3 Position;

        public float DeltaTime;

        public TelemetryData() {
            level = "level-one";
            Position = Vector3.zero;
            DeltaTime = 0.0f;
        }

        public Dictionary<string, object> AsDict() 
        {
            var dict = new Dictionary<string, object>() {
                { "levelName", level},
                { "Position", JsonUtility.ToJson(Position) },
                { "DeltaTime", DeltaTime }
            };

            return dict;
        }
    }

}

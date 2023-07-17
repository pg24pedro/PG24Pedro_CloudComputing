//Copyright (c) 2023 Pedro E. Perez, All Rights Reserved
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using UnityEditor.MemoryProfiler;
using Unity.Services.Core;
using UnityEngine.SceneManagement;

namespace VFSCloud
{
    public class CloudTelemetry:MonoBehaviour
    {
        public TelemetryEvent Telemetry = TelemetryEvent.Service;

        public void RecordEvent(string eventName) 
        {
            Telemetry.Data.level = SceneManager.GetActiveScene().name;
            Telemetry.Data.Position = GameObject.FindGameObjectWithTag("Player").transform.position;
            Telemetry.Data.DeltaTime = Time.timeSinceLevelLoad;

            Telemetry.Record(eventName);
            #if UNITY_EDITOR
                Debug.Log($"CloudTelemetry recorded: {eventName}");
            #endif

        }
    }
}

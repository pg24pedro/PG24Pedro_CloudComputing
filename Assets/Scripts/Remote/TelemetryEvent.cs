using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Services.Analytics;
using UnityEngine;
using Unity.Services.Core;

namespace VFSCloud
{
    public class TelemetryEvent
    {
        private static TelemetryEvent _instance;

        private static TelemetryData _data;
        public TelemetryData Data => _data;

        public static TelemetryEvent Service 
        {
            get
            {
                if (_instance == null)
                { 
                    _instance = new TelemetryEvent();
                    return _instance;
                }

                return _instance;
            }    
        }

        private TelemetryEvent() 
        {
            if (_data == null) 
            {
                _data = new TelemetryData();
                //Debug.Log(_data.ToString());
            }
        }

        public void Record(string eventName) 
        {
            if(eventName == null || Data == null) 
            {
                return; 
            }

            var dataDict = Data.AsDict();
            AnalyticsService.Instance.CustomData(eventName, dataDict);

        }
    }
}

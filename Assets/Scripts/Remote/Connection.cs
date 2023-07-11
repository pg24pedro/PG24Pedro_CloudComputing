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
using FMOD.Studio;
using UnityEngine.Analytics;

namespace VFSCloud
{
    public class Connection : MonoBehaviour
    {

        private static Connection _instance = null;
        private Dictionary<string, string> _environmentList;

        #if UNITY_EDITOR
        private static string _currentEnvironment = "development";

        #else
        private static string _currentEnvironment = "production";
        #endif

        public static Connection Service 
        {
            get
            {
                if (_instance == null)
                { 
                    _instance = new Connection();
                }

                return _instance;
            }
        
        }

        public string RemoteId => _environmentList[_currentEnvironment];

        private Connection() { 

            _environmentList = new Dictionary<string, string> {
                {"demo","e7f1aa70-7fde-470c-888f-116b0ec61284"},
                {"development", "57c7d9f9-7992-4713-a723-48be3f0c253d" },
                {"production", "391c496f-3fae-4137-b695-804bf737355a" }
            };
        
        }

        public async Task Authenticate(string environment = "development")
        {
            var options = new InitializationOptions().SetOption("com.unity.services.core.environment-name", environment);

            _currentEnvironment = environment;
            await UnityServices.InitializeAsync(options);

            if(!AuthenticationService.Instance.IsSignedIn) 
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            Debug.Log($"Player ID: {AuthenticationService.Instance.PlayerId}");
        }
    }
}

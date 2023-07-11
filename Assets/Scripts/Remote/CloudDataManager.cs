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
using System.Data;
using System.Linq;

namespace VFSCloud
{
    public class CloudDataManager : MonoBehaviour
    {
        [HideInInspector]
        public CloudDataManager Instance;

        private RemoteConfigService Remote => RemoteConfigService.Instance;

        private void Awake()
        {
            //initializing serivces
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

        }

        public async Task Start()
        {
            await Connection.Service.Authenticate();

            FetchConfigData();
        }

        public void FetchConfigData()
        {

            //fetch settings for main character
            RemoteConfigService.Instance.SetEnvironmentID(Connection.Service.RemoteId);
            //turn those into a class

            Remote.FetchConfigs(new userAttributes(), new appAttributes());

            if (this == null)
            {
                return;
            }

            ApplyremoteConfigs(Remote.appConfig);

            //Find all instances that implement my IRemoteCharacter interface
            //Tell each one to Update() with new data


        }

        private void ApplyremoteConfigs(RuntimeConfig appConfig) 
        {
            var playerData = appConfig.GetJson("Player");
            PlayerData data = JsonUtility.FromJson<PlayerData>(playerData);

            List<IRemotePlayerData> playerList = FindRemoteObjects<IRemotePlayerData>();
            foreach(IRemotePlayerData item in playerList) 
            {
                item.LoadConfigs(data);
                Debug.Log(item);
            }

            var platformData = appConfig.GetJson("Platforms");
            PlatformData platformsData = JsonUtility.FromJson<PlatformData>(platformData);

            List<IRemotePlatformData> platformList = FindRemoteObjects<IRemotePlatformData>();
            foreach (IRemotePlatformData platformItem in platformList)
            {
                platformItem.LoadPlatformData(platformsData);
                Debug.Log(platformItem);
            }
        }

        private List<T> FindRemoteObjects<T>()
        {
            IEnumerable<T> list; 
            list = FindObjectsOfType<MonoBehaviour>().OfType<T>();

            return new List<T>(list);
        }

        public struct userAttributes { }

        public struct appAttributes  { }

    }
}

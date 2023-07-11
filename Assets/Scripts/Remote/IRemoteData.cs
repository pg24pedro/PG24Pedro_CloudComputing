using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCloud 
{
    public interface IRemotePlayerData 
    {
        void LoadConfigs(PlayerData theDat);
    }

    public interface IRemotePlatformData 
    {
        void LoadPlatformData(PlatformData platformData);
    }
}




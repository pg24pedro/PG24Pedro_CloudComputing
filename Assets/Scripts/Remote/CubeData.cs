using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCloud 
{
    [System.Serializable]
    public class CubeData 
    {
        [SerializeField] public int CubeYPosition;

        public CubeData() 
        {
            CubeYPosition = 1;
        }
    }
}



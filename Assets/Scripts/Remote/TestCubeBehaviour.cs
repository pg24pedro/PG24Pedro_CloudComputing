using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCloud { 
    public class TestCubeBehaviour : MonoBehaviour, IRemoteCubeData
    {
        [SerializeField] private Transform cubeTransform;
        public void LoadCubeData(CubeData cubeData)
        {
            this.transform.position = new Vector3(0,0,0);

            Debug.Log("Should Be Assigning");
            this.transform.position = new Vector3(this.transform.position.x,cubeData.CubeYPosition, this.transform.position.z);
            
        }
    }
}

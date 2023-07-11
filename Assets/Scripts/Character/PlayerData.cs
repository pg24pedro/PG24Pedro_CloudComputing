using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VFSCloud 
{
    [System.Serializable]
    public class PlayerData
    {
        [SerializeField] public float Speed;
        [SerializeField] public float JumpHeight;
        [SerializeField] public float TurnSpeed;

        public PlayerData() 
        {
            Speed = 1.0f;
            JumpHeight = 1.0f;
            TurnSpeed = 1.0f;
        }

    }

}

using CharacterMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using VFSCloud;
public class CharacterMovementGame : CharacterMovement3D, IRemotePlayerData
{

    public void Awake()
    {
        base.Awake();
    }

    public void LoadConfigs(PlayerData theDat)
    {
        //Speed = theDat.Speed;
        _speed = theDat.Speed;
        _jumpHeight = theDat.JumpHeight;
        _turnSpeed = theDat.TurnSpeed;
    }
}


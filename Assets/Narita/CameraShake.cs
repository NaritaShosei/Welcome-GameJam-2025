using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource _source;

    public void Shake(float power)
    {
        _source.m_DefaultVelocity = Vector3.one * power;
        _source.GenerateImpulse();
    }
}

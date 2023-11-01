using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamShake : MonoBehaviour
{
    CinemachineVirtualCamera _cvc;
    public static CamShake CamShakeCall { get; private set; }
    float _shakeTimer;
    void Awake()
    {
        CamShakeCall = this;
        _cvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin _cbmcp =
            _cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = intensity;
        _shakeTimer = time;
    }

    void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin _cbmcp =
                    _cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _cbmcp.m_AmplitudeGain = 0f;
            }            
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;


[CreateAssetMenu(menuName = "CameraSmoothing/SecondDegreeSmoother")]
public class SecondDegreeSmoother : CameraSmoother
{
    private CameraConfiguration _lastPos;
    private CameraConfiguration _speed;
    [SerializeField] private float _f, _z, _r; 
    private float _k1, _k2, _k3;

    public override CameraConfiguration Smooth(CameraConfiguration current, CameraConfiguration target) {
        _k1 = _z / (PI * _f);
        _k2 = 1 / ((2 * PI * _f) * (2 * PI * _f));
        _k3 = _r * _z / (2 * PI * _f);
        
        Debug.Log(target.Yaw);
        
        CameraConfiguration lastSpeed = (target - _lastPos) / Time.deltaTime;
        _lastPos = target;
        
        current += Time.deltaTime * _speed;
        _speed += Time.deltaTime * (target + _k3 * lastSpeed - current - _k1 * _speed) / _k2;
        
        return current;
    }
}

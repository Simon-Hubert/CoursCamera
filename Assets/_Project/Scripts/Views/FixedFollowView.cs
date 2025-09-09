using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class FixedFollowView : AView
{
    [SerializeField] private float _roll;
    [SerializeField] private float _fov;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _central;
    [SerializeField] private float _yawOffsetMax;
    [SerializeField] private float _pitchOffsetMax;
    
    public override CameraConfiguration GetConfiguration() {
        Vector3 dir = _target.position - transform.position;
        Vector3 centralDir = _central.position - transform.position;
        dir.Normalize();
        centralDir.Normalize();

        float yaw = Atan2(dir.x, dir.z) * Rad2Deg;
        float centralYaw = Atan2(centralDir.x, centralDir.z) * Rad2Deg;

        float pitch = -Asin(dir.y) * Rad2Deg;
        float centralPitch = -Asin(centralDir.y) * Rad2Deg;
        
        float clampedYaw = centralYaw + Clamp(DeltaAngle(centralYaw, yaw ), -_yawOffsetMax, _yawOffsetMax);
        float clampedPitch = centralPitch + Clamp(DeltaAngle(centralPitch, pitch ), -_pitchOffsetMax, _pitchOffsetMax);
        
        return new CameraConfiguration
        {
            Yaw = clampedYaw,
            Pitch = clampedPitch,
            Roll = _roll,
            Fov = _fov,
            Pivot = transform.position,
            Distance = 0
        };
    }
}

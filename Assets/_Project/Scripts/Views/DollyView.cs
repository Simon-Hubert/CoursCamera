using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class DollyView : AView
{
    [SerializeField] private float _roll;
    [SerializeField] private float _distance;
    [SerializeField] private float _fov;
    [SerializeField] private Transform _target;
    [SerializeField] private Rail _rail;
    [SerializeField] private float _distanceOnRail;
    [SerializeField] private float _speed;
    
    private float _yaw;
    
    public override CameraConfiguration GetConfiguration() {
        Vector3 dir = _target.position - _rail.GetPosition(_distanceOnRail);
        dir.Normalize();

        _yaw += DeltaAngle(_yaw, Atan2(dir.x, dir.z) * Rad2Deg);
        
        
        return new CameraConfiguration
        {
            Yaw = _yaw,
            Pitch = -Asin(dir.y) * Rad2Deg,
            Roll = _roll,
            Fov = _fov,
            Pivot = _rail.GetPosition(_distanceOnRail),
            Distance = _distance
        };
    }
}

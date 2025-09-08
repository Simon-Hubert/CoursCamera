using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "CameraSmoothing/DampingSpeed")]
public class DampingSpeedSmoother : CameraSmoother
{
    [SerializeField] private float _dampingCoefficient = 0.1f;
    
    public override CameraConfiguration Smooth(CameraConfiguration current, CameraConfiguration target) {
        current.Pitch += _dampingCoefficient * (target.Pitch - current.Pitch);
        current.Yaw += _dampingCoefficient * (target.Yaw - current.Yaw);
        current.Roll += _dampingCoefficient * (target.Roll - current.Roll);
        current.Pivot += _dampingCoefficient * (target.Pivot - current.Pivot);
        current.Distance += _dampingCoefficient * (target.Distance - current.Distance);
        current.Fov += _dampingCoefficient * (target.Fov - current.Fov);
        return current;
    }
}

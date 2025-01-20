using Data;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarData _data;
    [SerializeField] private Wheel[] _rearWheels;
    [SerializeField] private Wheel[] _frontWheels;
    [SerializeField] private TrailRenderer[] _trailsRearWheel;
    [SerializeField] private ParticleSystem[] _smokeRearWheel;
    
    public int ID => _data.ID;
    public Wheel[] RearWheels => _rearWheels;
    public Wheel[] FrontWheels => _frontWheels;
    public TrailRenderer[] TrailsRearWheel => _trailsRearWheel;
    public ParticleSystem[] SmokeRearWheel => _smokeRearWheel;
}
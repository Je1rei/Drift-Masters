using Data;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarData _data;

    public int ID => _data.ID;
}
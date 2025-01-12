using UnityEngine;
using Zenject;

public class BootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Boot Scene is Loaded");
    }
}

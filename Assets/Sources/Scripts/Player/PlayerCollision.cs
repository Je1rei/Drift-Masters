using System;
using Spawn;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Collider))]
public class PlayerCollision : MonoBehaviour
{
    private Player _player;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.TryGetComponent(out Barrier barrier))
        {
            _player.ResetPosition();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Item item))
        {
            _player.SetScore(item.Score);
            item.ResetPool();
        }
    }
}
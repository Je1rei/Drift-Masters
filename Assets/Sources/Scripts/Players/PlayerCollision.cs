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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Item item))
        {
            _player.Increase(item.Score, item.IsRequiredCompleteLevel);
            _player.Win();
            item.gameObject.SetActive(false);
        }
        
        if (collider.TryGetComponent(out Barrier barrier))
        {
            _player.Lose();
        }
    }
}
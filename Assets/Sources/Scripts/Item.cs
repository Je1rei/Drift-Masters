using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _score;
    
    public int Score => _score;

    public void ResetPool()
    {
        gameObject.SetActive(false); // Тут бы записать логику возврата в пул 
    }
}

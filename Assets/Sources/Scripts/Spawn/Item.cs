using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private int _score;
        [SerializeField] private bool _isRequiredCompleteLevel;
        
        public int Score => _score;
        public bool IsRequiredCompleteLevel => _isRequiredCompleteLevel;

        public void Collect()
        {
           gameObject.SetActive(false);
        }
    }
}
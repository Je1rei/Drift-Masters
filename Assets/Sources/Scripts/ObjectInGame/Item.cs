using UnityEngine;

namespace ObjectInGame
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
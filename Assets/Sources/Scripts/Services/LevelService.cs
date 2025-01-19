using Data;
using UnityEngine;
using YG;

namespace Services
{
    public class LevelService : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levels;

        private LevelData _current;
        private int _id;

        public int ID => _id;
        public LevelData Current => _current;

        public LevelData Load(int index)
        {
            if (index < 0 || index >= _levels.Length)
            {
                return null;
            }

            _current = _levels[index];
            _id = index;

            return _current;
        }

        public void Complete()
        {
            Debug.Log($"Complete 0 - {_id}");
            
            if (_id < _levels.GetLength(0) - 1)
            {
                Debug.Log($"Complete before ++ - {_id}");
                _id++;
                Debug.Log($"Complete after ++ - {_id}");
                
                if (_id <= _levels.GetLength(0))
                {
                    Debug.Log($"открылся уровень - {_levels[_id].ID}");
                    YG2.saves.OpenedLevels.Add(_levels[_id].ID); 
                    YG2.SaveProgress();
                }
            }
        }
    }
}
using UnityEngine;

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
        if (_id < _levels.GetLength(0) - 1)
        {
            _id++;

            if (_id <= _levels.GetLength(0))
            {
                // YG2.saves.OpenedLevels.Add(_levels[_id].ID); // сохранения пройденного уровня
                // YG2.SaveProgress(); 
            }
        }
    }
}

// namespace YG // сохранения пройденных уровней
// {
//     public partial class SavesYG
//     {
//         public List<int> OpenedLevels = new List<int>();
//
//         public void Init()
//         {
//             OpenedLevels.Add(1);
//         }
//     }
// }
using System;
using UnityEngine;
using Zenject;

public class Wallet : MonoBehaviour
{
    private int _score;

    public event Action<int> Changed;

    public int Score => _score;
    
    [Inject]
    public void Construct()
    {
        // _score = YG2.saves.Score; // подгрузка очков из YG2 сейвов
        Changed?.Invoke(_score);
    }

    public void Increase(int value)
    {
        _score += value;
        Changed?.Invoke(_score);
        // YG2.saves.Score = _score; // сохранение

        // YG2.SetLeaderboard(nameLB: "Score", score : YG2.saves.Score); // добавление в ЛБ
        // YG2.SaveProgress();  // сохранение
    }
}

// namespace YG // сохранения собранных очков
// {
//     public partial class SavesYG
//     {
//         public int Score = 0;
//     }
// }
using System;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Wallet // переделать чтоб дубляжа впоследствии не было
    {
        private int _value;

        public event Action<int> Changed;

        public int Value => _value;
        
        public void Construct()
        {
            // _score = YG2.saves.Score; // подгрузка очков из YG2 сейвов
            Debug.Log("0");
            Changed?.Invoke(_value);
        }

        public void Increase(int value)
        {
            _value += value;
            Changed?.Invoke(_value);
            // YG2.saves.Score = _score; // сохранение

            // YG2.SetLeaderboard(nameLB: "Score", score : YG2.saves.Score); // добавление в ЛБ
            // YG2.SaveProgress();  // сохранение
        }

        public bool TrySpend(int value)
        {
            if (_value >= value)
            {
                _value -= value;
                Changed?.Invoke(_value);
                // YG2.SaveProgress();  // сохранение

                return true;
            }

            return false;
        }
    }
}

// namespace YG // сохранения собранных очков
// {
//     public partial class SavesYG
//     {
//         public int Score = 0;
//     }
// }
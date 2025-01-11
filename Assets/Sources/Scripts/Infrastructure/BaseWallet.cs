using System;
using YG;

namespace Infrastructure
{
    public abstract class BaseWallet
    {
        private readonly int _decreaseValue = 1;
        private int _value;
        
        public event Action<int> Changed;
        
        public int Value => _value;

        public void Construct(int value)
        {
            _value = value;
            Changed?.Invoke(_value);
        }
        
        public virtual void Increase(int amount)
        {
            _value += amount;
            Changed?.Invoke(_value);
        }
        
        public virtual bool TrySpend(int value)
        {
            if (_value >= value)
            {
                _value -= value;
                Changed?.Invoke(_value);
                YG2.SaveProgress();  // сохранение

                return true;
            }

            return false;
        }
    }
}
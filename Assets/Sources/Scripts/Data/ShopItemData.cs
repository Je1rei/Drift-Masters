using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item",  order = 4)]
    public class ShopItemData : ScriptableObject
    {
        public string Name;
        public int Price;
        public Sprite Model; // -> model
    }
}
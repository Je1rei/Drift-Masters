using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/Shop/Item",  order = 4)]
    public class ShopItemData : ScriptableObject
    {
        public int ID;
        public string Name;
        public int Price;
        public Sprite Model; 
    }
}
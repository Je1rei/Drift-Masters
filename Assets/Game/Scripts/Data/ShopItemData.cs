using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/Shop/Item", order = 1)]
    public class ShopItemData : ScriptableObject
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public Sprite Model { get; private set; }
    }
}
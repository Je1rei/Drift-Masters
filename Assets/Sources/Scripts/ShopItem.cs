using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item",  order = 4)]
public class ShopItem : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite Model; // -> model
}
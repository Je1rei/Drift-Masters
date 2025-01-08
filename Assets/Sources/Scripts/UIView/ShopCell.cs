using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIView
{
    public class ShopCell : MonoBehaviour
    {
        [SerializeField] private ShopItemData itemData;
        [SerializeField] private Image _imageModel; // -> model
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _priceText;
        
        private string _name;
        private int _price;
        private string _description;
        private Sprite _model; // -> model

        [Inject]
        private void Construct()
        {
            _name = itemData.Name;
            _price = itemData.Price;
            _model = itemData.Model;
            
            SetTexts();
        }

        private void SetTexts()
        {
            _imageModel.sprite = _model;
            _nameText.text = _name;
            _priceText.text = _price.ToString();
        }
    }
}
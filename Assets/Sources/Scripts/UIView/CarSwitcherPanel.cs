using System;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UIView
{
    public class CarSwitcherPanel : UIPanel
    {
        [SerializeField] private Transform _carsHolder;
        [SerializeField] private Button _previousPageButton;
        [SerializeField] private Button _nextPageButton;

        private AudioService _audioService;

        private List<Car> _carsView;

        private int _currentPageIndex;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _previousPageButton, OnClickBackCar);
            AddButtonListener(_audioService, _nextPageButton, OnClickNextCar);
        }

        private void OnDisable()
        {
            _previousPageButton.onClick.RemoveAllListeners();
            _nextPageButton.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
            InitializeCarsView();

            _currentPageIndex = Mathf.Clamp(YG2.saves.ChoisedCarID, 0, _carsView.Count - 1);
            UpdateCarVisibility();
        }

        public void ToggleView()
        {
            _carsHolder.gameObject.SetActive(!_carsHolder.gameObject.activeSelf);
        }        

        private void OnClickNextCar()
        {
            if (_currentPageIndex < _carsView.Count - 1)
            {
                _currentPageIndex++;
                YG2.saves.ChoisedCarID = _currentPageIndex;
                UpdateCarVisibility();
                YG2.SaveProgress();
            }
            
            _nextPageButton.interactable = _currentPageIndex < _carsView.Count - 1;
            _previousPageButton.interactable = _currentPageIndex > 0;
        }

        private void OnClickBackCar()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                YG2.saves.ChoisedCarID = _currentPageIndex;
                UpdateCarVisibility();
                YG2.SaveProgress();
            }
            
            _previousPageButton.interactable = _currentPageIndex > 0;
            _nextPageButton.interactable = _currentPageIndex < _carsView.Count - 1;
        }
        
        private void UpdateCarVisibility()
        {
            for (int i = 0; i < _carsView.Count; i++)
            {
                _carsView[i].gameObject.SetActive(i == _currentPageIndex);
            }
        }

        private void InitializeCarsView()
        {
            _carsView = new();
            
            foreach (Transform child in _carsHolder)
            {
                Car car = child.GetComponent<Car>();
                
                if (car != null)
                {
                    _carsView.Add(car);
                }
            }
        }
    }
}
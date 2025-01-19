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

        private CarService _carService;
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
            _carService.Added -= AddNewCar;
        }

        public void Construct(AudioService audioService, CarService carService)
        {
            _carService = carService;
            _audioService = audioService;
            InitializeCarsView();

            _currentPageIndex = _carsView.FindIndex(car => car.ID == YG2.saves.ChoisedCarID);
            if (_currentPageIndex == -1) _currentPageIndex = 0;
            
            UpdateCarVisibility();
            UpdateButtonInteractive();
            
            _carService.Added += AddNewCar;
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
                YG2.saves.ChoisedCarID = _carsView[_currentPageIndex].ID;
                UpdateCarVisibility();
                YG2.SaveProgress();
            }

            UpdateButtonInteractive();
        }

        private void OnClickBackCar()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                YG2.saves.ChoisedCarID = _carsView[_currentPageIndex].ID;
                UpdateCarVisibility();
                YG2.SaveProgress();
            }

            UpdateButtonInteractive();
        }
        
        private void UpdateCarVisibility()
        {
            for (int i = 0; i < _carsView.Count; i++)
            {
                _carsView[i].gameObject.SetActive(i == _currentPageIndex);
            }
        }
        
        private void UpdateButtonInteractive()
        {
            _previousPageButton.interactable = _currentPageIndex > 0;
            _nextPageButton.interactable = _currentPageIndex < _carsView.Count - 1;
        }

        private void AddNewCar(Car car)
        {
            if (_carsView.Contains(car) == false)
            {
                _carsView.Add(car);
                car.gameObject.SetActive(false);
            }

            UpdateButtonInteractive();
            UpdateCarVisibility();
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
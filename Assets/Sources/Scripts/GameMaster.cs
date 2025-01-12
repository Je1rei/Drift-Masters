using System;
using System.Collections;
using System.Collections.Generic;
using LayerLab;
using Spawn;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private RectTransform _panel;
    [Space(20)]
    [SerializeField] private List<ItemSpawner> _itemSpawns;
    [SerializeField] private List<BarriersSpawner> _barrierSpawns;
    [Space(10)]
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(Restert);

        foreach (var _itemSpawn in _itemSpawns)
        {
            _itemSpawn.ItemsEnded += OnEnded;
        }

        _player.PlayerDestroyed += OnEnded;
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(Restert);
    }

    private void Awake()
    {
        _panel.gameObject.SetActive(false);
    }

    private void Restert()
    {
        foreach (var _item in _itemSpawns)
        {
            _item.RestartGame();
        }

        foreach (var _barrierSpawn in _barrierSpawns)
        {
            _barrierSpawn.RestartGame();
        }
        
        _panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnEnded()
    {
        _panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

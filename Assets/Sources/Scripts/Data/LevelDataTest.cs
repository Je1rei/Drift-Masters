using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelDataTest", order = 1)]
    public class LevelDataTest : ScriptableObject
    {
        public int ID;
        
        [Space(10)]
        [Header("Точка начала уровня")]
        public StartPoint StartPoint;
        
        [Space(10)] 
        [Header("Настройки для кеонструктора")]
        public LevelBase LevelBase;
        public LevelSidewalk LevelSidewalk;
        public LevelFence LevelFence;
        
        [Space(10)] 
        [Header("Карты итомов")]
        public LevelItemMapRequiredToWin LevelItemMapRequiredToWin;
        public LevelItemMap LevelItem3PointsMap;
        public LevelItemMap LevelItem5PointsMap;
        
        [Space(10)] 
        [Header("Карты барьеров")]
        public LevelBarriersMap LevelBarriersMap;
    }
}
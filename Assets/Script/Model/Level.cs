using System;
using UnityEngine;

namespace Assets.Script.Model
{
    [System.Serializable]
    public class Level
    {
        [SerializeField] private int countStar;
        [field: SerializeField] public int ID { get; set; }
        
        public int CountStar
        {
            get => countStar;
            set => countStar = Math.Clamp(value, 0, 2);
        }
    }
}

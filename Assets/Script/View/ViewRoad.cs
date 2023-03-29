using System;
using System.Collections.Generic;
using Assets.Script.Model;
using UnityEngine;

namespace Assets.Script.View
{
    [RequireComponent(typeof(RectTransform))]
    public class ViewRoad : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> positionsLevels;
        [SerializeField] private ViewLevel prefabViewLevel;
        [SerializeField] private GameObject cloud;
        public RectTransform RectTransform;
        public int CountPosition => positionsLevels.Count;
        public Vector2 Size => RectTransform.sizeDelta;

        private void OnValidate()
        {
            RectTransform ??= GetComponent<RectTransform>();
        }

        public void ShowLevels(List<Level> levels)
        {
            if (levels.Count != CountPosition)
            {
                throw new ArgumentException("levels not equals positions.");
            }
            for (int i = 0; i < levels.Count; i++)
            {
                ViewLevel level = Instantiate(prefabViewLevel, positionsLevels[i]);
                level.SetLevel(levels[i]);
            }
        }
        public void ThisLast()
        {
            cloud.SetActive(true);
        }
    }
}

using Assets.Script.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.View
{
    public class ViewLevel : MonoBehaviour
    {
        [SerializeField] private Image[] stars = new Image[3];
        [SerializeField] private Sprite fillStar, emptyStar;
        [SerializeField] private TMP_Text number;
        [SerializeField] private Level level;

        private void Start()
        {
            SetLevel(level);
        }

        private void OnValidate()
        {
            gameObject.name = "Level " + level.ID;
        }

        public void SetLevel(Level level)
        {
            int i = 0;
            for (; i < level.CountStar; i++)
            {
                stars[i].sprite = fillStar;
            }
            for (; i < stars.Length - 1; i++)
            {
                stars[i].sprite = emptyStar;
            }
            number.text = level.ID.ToString();
        }
    }
}

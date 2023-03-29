using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.UIAnimation
{
    public class StarCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text current, need;
        [SerializeField] private float timeTransition;
        [SerializeField] private int needStars;
        private int countStar;
        public int CountStar
        {
            get => countStar;
            set
            {
                countStar = value;
                current.text = value.ToString();
                OnStateLock?.Invoke(value < needStars);
            }
        }
        public UnityEvent<bool> OnStateLock;


        private void Awake()
        {
            need.text = needStars.ToString();
        }

        public void SetCountStar(int count)
        {
            CountStar = 0;
            DOTween.To(() => CountStar, x=> CountStar = x, count, timeTransition);
        }
    }
}

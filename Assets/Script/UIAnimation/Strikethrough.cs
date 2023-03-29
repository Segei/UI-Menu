using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UIAnimation
{
    public class Strikethrough : MonoBehaviour
    {
        [SerializeField] private Image strikethroughLine;
        [SerializeField] private float timeTransition = 0.5f;

        private bool fill;

        public void SwitchState()
        {
            SetValue(!fill);
        }

        public void SetValue(bool value)
        {
            fill = value;
            if (fill)
            {
                Fill();
            }
            else
            {
                Empty();
            }
        }

        private void Fill()
        {
            _ = DOTween.To(() => strikethroughLine.fillAmount, x => strikethroughLine.fillAmount = x, 1, timeTransition);
        }

        private void Empty()
        {
            _ = DOTween.To(() => strikethroughLine.fillAmount, x => strikethroughLine.fillAmount = x, 0, timeTransition);
        }
    }
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Script.UIAnimation
{
    public class Strikethrough : MonoBehaviour
    {
        [SerializeField] private Image strikethroughLine;
        [SerializeField] private float timeTransition = 0.5f;
        private bool fill = true;

        public UnityEvent<bool> OnChangeState;


        public void SwitchState()
        {
            SetValue(!fill);
        }

        public void SetValue(bool value)
        {
            fill = value;
            if (!value)
            {
                Fill();
            }
            else
            {
                Empty();
            }
            OnChangeState?.Invoke(value);
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

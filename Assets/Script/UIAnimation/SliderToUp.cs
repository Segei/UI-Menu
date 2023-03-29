using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.UIAnimation
{
    [RequireComponent(typeof(RectTransform))]
    public class SliderToUp : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private float timeTransition;
        public UnityEvent<SliderToUp, TweenerCore<Vector3, Vector3, VectorOptions>> OnCallMe;
        public UnityEvent<SliderToUp> OnClose;


        private void OnValidate()
        {
            rectTransform ??= GetComponent<RectTransform>();
        }


        public void CallSlider()
        {
            OnCallMe.Invoke(this, rectTransform.DOAnchorPos3DY(-rectTransform.sizeDelta.y / 2, timeTransition));
        }

        public TweenerCore<Vector3, Vector3, VectorOptions> SequenceCloseSlider()
        {
            return rectTransform.DOAnchorPos3DY(+rectTransform.sizeDelta.y / 2, timeTransition);
        }

        public void CloseSlider()
        {
            OnClose?.Invoke(this);
        }
    }
}

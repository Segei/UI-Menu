using System.Collections.Generic;
using Assets.Script.UIAnimation;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Script.Controllers
{
    public class SliderController : MonoBehaviour
    {
        [SerializeField] private List<SliderToUp> sliders;
        Sequence sequence;

        private void Start()
        {
            foreach (var slider in sliders)
            {
                slider.OnCallMe.AddListener(ActiveSlider);
                slider.OnClose.AddListener(CloseSlider);
            }
        }

        private void ActiveSlider(SliderToUp slider, TweenerCore<Vector3, Vector3, VectorOptions> tweener)
        {
            sequence.Kill();
            sequence = DOTween.Sequence();            
            sequence.AppendCallback(() => slider.gameObject.SetActive(true));
            sequence.Append(tweener);
        }
        private void CloseSlider(SliderToUp slider)
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(slider.SequenceCloseSlider());
            sequence.AppendCallback(() => slider.gameObject.SetActive(false));
        }
    }
}

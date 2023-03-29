using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Controllers
{
    public class OnOffSound : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> audioSources;
        [SerializeField, Range(0, 1)] private float onValue;

        public void SetState(bool value)
        {
            foreach (AudioSource source in audioSources)
            {
                source.volume = value ? onValue : 0;
            }
        }
    }
}

using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Tools
{
    public class LinkSoundClickButton : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
#if UNITY_EDITOR
        [Button]
        private void Link()
        {
            foreach (GameObject game in gameObject.scene.GetRootGameObjects())
            {
                foreach (Button button in game.GetComponentsInChildren<Button>(true))
                {
                    if (button.onClick.GetPersistentEventCount() == 0)
                    {
                        UnityEditor.Events.UnityEventTools.AddPersistentListener(button.onClick, source.Play);
                    }
                    else
                    {
                        UnityEditor.Events.UnityEventTools.RegisterPersistentListener(button.onClick, 0, source.Play);
                    }
                }
            }
        }
#endif
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.View
{
    public class ViewLockLevels : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite spriteLock, spriteUnlock;
        public bool IsLocked = true;

        private void Start()
        {
            SetStateLock(IsLocked);
        }

        public void SetStateLock(bool state)
        {
            IsLocked = state;
            image.sprite = state ? spriteLock : spriteUnlock;
        }
    }
}

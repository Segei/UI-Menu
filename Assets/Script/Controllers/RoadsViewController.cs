using System.Collections.Generic;
using System.Linq;
using Assets.Script.Model;
using Assets.Script.View;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Script.Controllers
{
    public class RoadsViewController : MonoBehaviour
    {
        [SerializeField] private Button nextPage, prevPage;
        [SerializeField] private RectTransform parentViewRoad;
        [SerializeField] private List<Level> levels;
        [SerializeField] private ViewRoad prefabViewRoad;
        [SerializeField] private float timeTransition = 0.5f;
        private List<ViewRoad> roads = new();
        private int currentPosition = 0;

        [HideInInspector] public List<Level> CurrentLevels;
        public UnityEvent<int> OnChangeStarCountInLevels;


        private void Start()
        {
            for (int i = 0; i < levels.Count / prefabViewRoad.CountPosition; i++)
            {
                ViewRoad road = Instantiate(prefabViewRoad, parentViewRoad);
                road.ShowLevels(levels.GetRange(i * prefabViewRoad.CountPosition, prefabViewRoad.CountPosition));
                roads.Add(road);
            }
            roads.Last().ThisLast();
            ChangePosition(currentPosition);
            MoveViewRoad(currentPosition, 0);
            nextPage.onClick.AddListener(() =>
            {
                currentPosition++;
                ChangePosition(currentPosition);
                MoveViewRoad(currentPosition, timeTransition);
            });
            prevPage.onClick.AddListener(() =>
            {
                currentPosition--;
                ChangePosition(currentPosition);
                MoveViewRoad(currentPosition, timeTransition);
            });
        }


        private void ChangePosition(int position)
        {
            nextPage.gameObject.SetActive(currentPosition < roads.Count -1);
            prevPage.gameObject.SetActive(currentPosition > 0);
            CurrentLevels = levels.GetRange(position * prefabViewRoad.CountPosition, prefabViewRoad.CountPosition);
            int countStarsInLevel = 0;
            foreach (Level level in CurrentLevels)
            {
                countStarsInLevel += level.CountStar;
            }
            OnChangeStarCountInLevels.Invoke(countStarsInLevel);
        }

        private void MoveViewRoad(int position, float time)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                _ = roads[i].RectTransform.DOAnchorPos3DY(((i - position) * prefabViewRoad.Size.y) + (prefabViewRoad.Size.y / 2), time);
            }
        }
    }
}

using System.Collections.Generic;
using AxGrid.Base;
using AxGrid.Path;
using TASK_Realisation.Model;
using TMPro;
using UnityEngine;

namespace TASK_Realisation.View
{
    public class BankAccountView : MonoBehaviourExt
    {
        [SerializeField] private TextMeshProUGUI deltaText;
        [SerializeField] private float deltaTextAnimDuration;
        [SerializeField] private AnimationCurve deltaTextFade;
        [SerializeField] private Vector2 deltaTextOffset;
        [SerializeField] private Color positiveDeltaColor;
        [SerializeField] private Color negativeDeltaColor;

        private List<(TextMeshProUGUI item, CPath path)> _deltaTextPool = new ();
        private int _poolPointer;
        
        [OnStart]
        private void Init()
        {
            Model.EventManager.AddAction<int, int>(Const.PlayerScoreChangedCallback, OnScoreChanged);
            for (int i = 0; i < 4; i++)
            {
                var instance = Instantiate(deltaText, deltaText.transform.parent);
                instance.transform.SetAsFirstSibling();
                _deltaTextPool.Add((instance, new CPath()));
            }
        }

        private void OnScoreChanged(int value, int old)
        {
            if(value == old) return;

            ShowDeltaText(value - old);
        }

        private void ShowDeltaText(int delta)
        {
            (TextMeshProUGUI item, CPath path) = _deltaTextPool[_poolPointer++];
            item.gameObject.SetActive(true);
            _poolPointer %= _deltaTextPool.Count;
            Vector2 initialPosition = deltaText.rectTransform.anchoredPosition;
            Vector2 targetPosition = initialPosition + deltaTextOffset;
            Color itemColor = delta > 0 ? positiveDeltaColor : negativeDeltaColor;
            item.text = (delta > 0 ? "+" : "-") + delta;
            path.EasingQuadEaseOut(deltaTextAnimDuration, 0, 1, t =>
            {
                item.rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);
                item.color = new Color(itemColor.r, itemColor.g, itemColor.b, deltaTextFade.Evaluate(t));
            }).Action(() =>
            {
                item.gameObject.SetActive(false);
                item.rectTransform.anchoredPosition = initialPosition;
            });
        }

        [OnUpdate]
        private void UpdatePaths()
        {
            foreach ((TextMeshProUGUI item, CPath path) in _deltaTextPool)
            {
                if (item.gameObject.activeSelf) path.Update(Time.deltaTime);
            }
        }
    }
}

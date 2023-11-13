using System;
using AxGrid.Tools.Binders;
using TASK_Realisation.Model;
using UnityEngine;
#if UNITY_EDITOR
namespace TASK_Realisation.Utilities
{
    [RequireComponent(typeof(UIButtonDataBind))]
    public class UiButtonForWorkerStateContract : MonoBehaviour
    {
        [SerializeField] private WorkerStateEnum kindOfState;
        private void OnValidate()
        {
            var btn = GetComponent<UIButtonDataBind>();
            btn.buttonName = kindOfState.ToString();
            btn.enableField = string.Empty;
        }
    }
}
#endif
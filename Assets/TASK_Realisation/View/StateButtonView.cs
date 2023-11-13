using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Tools.Binders;
using TASK_Realisation.Model;
using UnityEngine;

namespace TASK_Realisation.View
{
    [RequireComponent(typeof(UIButtonDataBind))]
    public class StateButtonView : MonoBehaviourExtBind
    {
        private UIButtonDataBind _buttonDataBind;

        [OnAwake]
        private void Init()
        {
            _buttonDataBind = GetComponent<UIButtonDataBind>();
            Model.EventManager.AddAction<WorkerStateEnum>(Const.CurrentStateCallback, OnWorkerStateChanged);
        }

        [OnDestroy]
        private void Dispose()
        {
            Model.EventManager.RemoveAction<WorkerStateEnum>(Const.CurrentStateCallback, OnWorkerStateChanged);
        }
        
        private void OnWorkerStateChanged(WorkerStateEnum kindOfState)
        {
            Model.Set(_buttonDataBind.enableField, kindOfState.ToString() != _buttonDataBind.buttonName);
        }

        [Bind(Const.TransitionBeginEvent)]
        private void OnTransitionBegin()
        {
            Model.Set(_buttonDataBind.enableField, false);
        }
        
    }
}

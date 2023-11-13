using AxGrid;
using AxGrid.FSM;
using TASK_Realisation.Utilities;

namespace TASK_Realisation.Model.WorkerFSM
{
    [State(nameof(TransitionState))]
    public class TransitionState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Settings.Model.EventManager.Invoke(Const.TransitionBeginEvent);
            HandleTimer();
        }

        private async void HandleTimer()
        {
            WorkerStateEnum currentState = Settings.Model.Get<WorkerStateEnum>(Const.CurrentStateVariable);
            WorkerStateEnum nextState = Settings.Model.Get<WorkerStateEnum>(Const.NextStateVariable);
            float speed = Settings.Model.GetInt(Const.TransitionSpeedSettings);
            float distance = Settings.Model.Get<Ruler>(Const.RulerObjectVariable).GetDistanceBetween(currentState, nextState);
            float duration = distance / speed;
            await AsyncAwaitExt.WaitForSeconds(duration);
            Parent.Change(string.Format(Const.StateNamingFormat, nextState));
        }
        
        [Exit]
        private void OnExit()
        {
            Settings.Model.EventManager.Invoke(Const.TransitionEndEvent);
        }
    }
}
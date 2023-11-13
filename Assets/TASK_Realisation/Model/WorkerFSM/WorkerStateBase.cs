using System.Threading.Tasks;
using AxGrid.FSM;

namespace TASK_Realisation.Model.WorkerFSM
{
    public abstract class WorkerStateBase : FSMState
    {
        protected abstract WorkerStateEnum KindOfState { get; }


        [Enter]
        private void OnEnter()
        {
            Model.Set(Const.CurrentStateVariable, KindOfState);
            Model.EventManager.AddAction<WorkerStateEnum>(Const.WantedStateCallback, ChangeState);
        }

        [Exit]
        private void OnExit()
        {
            Model.EventManager.RemoveAction<WorkerStateEnum>(Const.WantedStateCallback, ChangeState);
        }

        private async void ChangeState(WorkerStateEnum kindOfState)
        {
            await Task.Yield(); // crutch to prevent Collection was modified exception
            Model.Set(Const.NextStateVariable, kindOfState);
            Parent.Change(nameof(TransitionState));
        }
    }
}
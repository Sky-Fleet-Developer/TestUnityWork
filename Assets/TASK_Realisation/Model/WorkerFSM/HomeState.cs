using AxGrid.FSM;

namespace TASK_Realisation.Model.WorkerFSM
{
    [State(nameof(HomeState))]
    public class HomeState : WorkerStateBase
    {
        private const WorkerStateEnum _kindOfState = WorkerStateEnum.Home;
        protected override WorkerStateEnum KindOfState => _kindOfState;
    }
}
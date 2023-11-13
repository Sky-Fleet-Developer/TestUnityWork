using System.Linq;
using AxGrid.Base;
using TASK_Realisation.Model;
using UnityEngine;

namespace TASK_Realisation.View
{
    public class Navigation : MonoBehaviourExt
    {
        private WorkerStateView[] _stateViews;

        [OnAwake]
        private void Init()
        {
            _stateViews = GetComponentsInChildren<WorkerStateView>();
        }

        public Vector3 GetStateAnchorPosition(WorkerStateEnum state)
        {
            return _stateViews.First(x => x.KindOfState == state).GetAnchorPosition();
        }
    }
}

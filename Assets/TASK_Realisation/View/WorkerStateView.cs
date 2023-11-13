using AxGrid.Base;
using TASK_Realisation.Model;
using UnityEngine;

namespace TASK_Realisation.View
{
    public class WorkerStateView : MonoBehaviourExt
    {
        [SerializeField] private WorkerStateEnum kindOfState;
        [SerializeField] private Transform anchor;
        public WorkerStateEnum KindOfState => kindOfState;
        public Vector3 GetAnchorPosition() => anchor.position;
    }
}
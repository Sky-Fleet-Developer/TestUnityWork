using System;
using System.Collections.Generic;
using System.Linq;
using TASK_Realisation.View;
using UnityEngine;

namespace TASK_Realisation.Model
{
    public class Ruler : MonoBehaviour
    {
        private Dictionary<WorkerStateEnum, WorkerStateView> _views;

        private void Awake()
        {
            _views = GetComponentsInChildren<WorkerStateView>().ToDictionary(x => x.KindOfState);
        }

        public float GetDistanceBetween(WorkerStateEnum a, WorkerStateEnum b)
        {
            return (_views[a].GetAnchorPosition() - _views[b].GetAnchorPosition()).magnitude;
        }
    }
}

using System;
using System.Collections.Generic;
using AxGrid.Model;
using TASK_Realisation.Model;

namespace TASK_Realisation.Controllers
{
    public class WantedStateButtonsController
    {
        private DynamicModel _model;
        private List<Action> _cache = new List<Action>();
        public WantedStateButtonsController(DynamicModel model)
        {
            _model = model;
            foreach (WorkerStateEnum value in Enum.GetValues(typeof(WorkerStateEnum)))
            {
                WorkerStateEnum closure = value;
                _cache.Add(() =>
                {
                    _model.Set(Const.WantedStateVariable, closure);
                });
                model.EventManager.AddAction($"On{value.ToString()}Click", _cache[^1]);
            }
        }

        ~WantedStateButtonsController()
        {
            if (_model != null)
            {
                int i = 0;
                foreach (WorkerStateEnum value in Enum.GetValues(typeof(WorkerStateEnum)))
                {
                    _model.EventManager.RemoveAction($"On{value.ToString()}Click", _cache[i++]);
                }
            }

            _cache = null;
        }
    }
}
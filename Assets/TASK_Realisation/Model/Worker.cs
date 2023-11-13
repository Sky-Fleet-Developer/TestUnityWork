using System;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using TASK_Realisation.Model.WorkerFSM;
using UnityEngine;
using Zenject;

namespace TASK_Realisation.Model
{
    public class Worker : MonoBehaviourExtBind
    {
        [SerializeField] private WorkerStateEnum initialState;
        private BankAccount _bankAccount;
        
        [OnStart]
        private void Init()
        {
            _bankAccount = new BankAccount(Model);
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new HomeState(), new JobState(_bankAccount), new ShopState(_bankAccount), new TransitionState());
            Settings.Fsm.Start(string.Format(Const.StateNamingFormat, initialState));
        }

        [OnUpdate]
        private void Loop()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}
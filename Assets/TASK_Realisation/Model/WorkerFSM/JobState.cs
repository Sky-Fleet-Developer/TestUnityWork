using AxGrid.Base;
using AxGrid.FSM;
using UnityEngine;

namespace TASK_Realisation.Model.WorkerFSM
{
    [State(nameof(JobState))]
    public class JobState : WorkerStateBase
    {
        private BankAccount _workerBankAccount;
        private float _lastPaymentTime;
        private float _salaryInterval;
        private int _salaryAmount;
        public JobState(BankAccount workerBankAccount)
        {
            _workerBankAccount = workerBankAccount;
            _salaryInterval = Model.GetFloat(Const.JobSalaryIntervalSettings);
            _salaryAmount = Model.GetInt(Const.JobSalaryAmountSettings);
        }
        
        [Enter]
        private void OnEnter()
        {
            _lastPaymentTime = Time.time;
        }

        [Loop(0.015f)]
        private void Loop()
        {
            if (Time.time > _lastPaymentTime + _salaryInterval)
            {
                _lastPaymentTime += _salaryInterval;
                _workerBankAccount.AddScore(_salaryAmount);
            }
        }
        
        private const WorkerStateEnum _kindOfState = WorkerStateEnum.Job;
        protected override WorkerStateEnum KindOfState => _kindOfState;
    }
}

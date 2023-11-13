using AxGrid.Base;
using AxGrid.FSM;
using UnityEngine;

namespace TASK_Realisation.Model.WorkerFSM
{
    [State(nameof(ShopState))]
    public class ShopState : WorkerStateBase
    {
        private BankAccount _workerBankAccount;
        private float _lastPaymentTime;
        private float _purchaseInterval;
        private int _purchaseCost;
        
        public ShopState(BankAccount workerBankAccount)
        {
            _workerBankAccount = workerBankAccount;
            _purchaseInterval = Model.GetFloat(Const.ShopPurchaseIntervalSettings);
            _purchaseCost = Model.GetInt(Const.ShopCostSettings);
        }

        [Enter]
        private void OnEnter()
        {
            _lastPaymentTime = Time.time;
        }
        
        [Loop(0.15f)]
        private void Loop()
        {
            if (Time.time > _lastPaymentTime + _purchaseInterval)
            {
                _lastPaymentTime += _purchaseInterval;
                _workerBankAccount.Purchase(_purchaseCost);
            }
        }
        
        private const WorkerStateEnum _kindOfState = WorkerStateEnum.Shop;
        protected override WorkerStateEnum KindOfState => _kindOfState;
    }
}

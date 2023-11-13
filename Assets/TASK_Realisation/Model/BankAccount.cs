using System;
using AxGrid.Model;

namespace TASK_Realisation.Model
{
    public class BankAccount
    {
        private int _score;

        public int Score => _score;
        private DynamicModel _model;

        public BankAccount(DynamicModel model)
        {
            _model = model;
            _model.Set(Const.PlayerScoreVariable, _score);
        }
        
        public void AddScore(int amount)
        {
            if (amount < 0) throw new Exception("Amount to add can't be less then zero");
            _score += amount;
            _model.Set(Const.PlayerScoreVariable, _score);
        }

        public bool Purchase(int cost)
        {
            if (_score < cost)
            {
                _model.EventManager.Invoke(Const.PlayerLowScoreCallback);
                return false;
            }
            _score -= cost;
            _model.Set(Const.PlayerScoreVariable, _score);
            return true;
        }
    }
}

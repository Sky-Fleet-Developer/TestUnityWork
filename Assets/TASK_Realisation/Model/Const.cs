namespace TASK_Realisation.Model
{
    public static class Const
    {
        private static string _wantedStateVariable;
        public const string TransitionBeginEvent = "BEGIN_TRANSITION";
        public const string TransitionEndEvent = "END_TRANSITION";
        
        public const string TransitionSpeedSettings = "TRANSITION_SPEED";
        public const string JobSalaryAmountSettings = "SALARY";
        public const string ShopCostSettings = "PRICE";
        public const string JobSalaryIntervalSettings = "SALARY_INTERVAL";
        public const string ShopPurchaseIntervalSettings = "PAY_INTERVAL";
        
        public const string StateNamingFormat = "{0}State";
        public const string NextStateVariable = "NEXT_STATE";
        public const string CurrentStateVariable = "CURRENT_STATE";
        public const string CurrentStateCallback = "OnCURRENT_STATEChanged";
        public const string WantedStateVariable = "WANTED_STATE";
        public const string WantedStateCallback = "OnWANTED_STATEChanged";
        public const string RulerObjectVariable = "RULER";
        
        public const string PlayerScoreChangedCallback = "OnPLAYER_SCOREChanged";
        public const string PlayerScoreVariable = "PLAYER_SCORE";
        public const string PlayerLowScoreCallback = "PLAYER_LOW_SCORE";
    }
}
using System;
using System.Reflection;
using AxGrid.Model;
using UnityEngine;

namespace TASK_Realisation.Model
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        [SerializeField, BindForNameAttribute(Const.TransitionSpeedSettings)]
        private float transitionSpeed = 1;
        [SerializeField, BindForNameAttribute(Const.JobSalaryAmountSettings)]
        private int jobSalaryAmount = 1;
        [SerializeField, BindForNameAttribute(Const.JobSalaryIntervalSettings)]
        private float jobSalaryInterval = 1.5f;
        [SerializeField, BindForNameAttribute(Const.ShopCostSettings)]
        private int shopCost = 1;
        [SerializeField, BindForNameAttribute(Const.ShopPurchaseIntervalSettings)]
        private float shopPurchaseInterval = 0.7f;

        public void InjectSettings(DynamicModel model)
        {
            var type = typeof(GameSettings);
            var members = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var member in members)
            {
                BindForNameAttribute attr = member.GetCustomAttribute<BindForNameAttribute>();
                if (attr != null)
                {
                    model.Set(attr.Binding, member.GetValue(this));
                }
            }
        }
        
        [AttributeUsage(AttributeTargets.Field)]
        private class BindForNameAttribute : Attribute
        {
            public string Binding { get; }
            public BindForNameAttribute(string binding)
            {
                Binding = binding;
            }
        }
    }
}

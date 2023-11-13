using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using TASK_Realisation.Model;
using UnityEngine;
using Zenject;

namespace TASK_Realisation.View
{
    public class WorkerView : MonoBehaviourExtBind
    {
        [SerializeField] private Transform character;
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem dustParticle;
        [Inject] private Navigation _navigation;
        private static readonly int Up = Animator.StringToHash("Up");
        private static readonly int Right = Animator.StringToHash("Right");

        [OnStart]
        private void Init()
        {
            SetPosition(_navigation.GetStateAnchorPosition(Model.Get<WorkerStateEnum>(Const.CurrentStateVariable)));
        }

        [Bind(Const.CurrentStateCallback)]
        private void OnCurrentStateChanged(WorkerStateEnum newState)
        {
            SetPosition(_navigation.GetStateAnchorPosition(newState));
        }
        
        [Bind(Const.TransitionBeginEvent)]
        private void OnTransitionBegins()
        {
            WorkerStateEnum currentState = Model.Get<WorkerStateEnum>(Const.CurrentStateVariable);
            WorkerStateEnum nextState = Model.Get<WorkerStateEnum>(Const.NextStateVariable);
            float speed = Model.GetInt(Const.TransitionSpeedSettings);
            float distance = Model.Get<Ruler>(Const.RulerObjectVariable).GetDistanceBetween(currentState, nextState);
            float duration = distance / speed;
            Vector3 initialPos = GetPosition();
            Vector3 nextStatePoint = _navigation.GetStateAnchorPosition(nextState);
            dustParticle.Play();
            Path.EasingLinear(duration, 0, 1, v =>
            {
                MoveTo(Vector3.Lerp(initialPos, nextStatePoint, v));
            }).Action(() =>
            {
                dustParticle.Stop();
                _animator.SetFloat(Up, 0);
                _animator.SetFloat(Right, 0);
            });
        }

        private void MoveTo(Vector3 value)
        {
            Vector3 direction = (value - GetPosition()).normalized * 1.5f;
            _animator.SetFloat(Up, Mathf.Round(direction.y));
            _animator.SetFloat(Right, Mathf.Round(direction.x));
            SetPosition(value);
        }

        private void SetPosition(Vector3 value)
        {
            character.position = value;
        }

        private Vector3 GetPosition()
        {
            return character.position;
        }
    }
}

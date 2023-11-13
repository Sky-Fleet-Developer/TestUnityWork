using UnityEngine;

namespace TASK_Realisation.Model
{
    [RequireComponent(typeof(Canvas))]
    public class AssignCameraToCanvas : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
}

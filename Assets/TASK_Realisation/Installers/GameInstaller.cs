using AxGrid;
using TASK_Realisation.Controllers;
using TASK_Realisation.Model;
using TASK_Realisation.View;
using UnityEngine;
using Zenject;

namespace TASK_Realisation.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject worldPrefab;
        [SerializeField] private Canvas navigationCanvas;
        [SerializeField] private Worker workerPrefab;
        [SerializeField] private WorkerView workerView;
        [SerializeField] private BankAccountView bankAccountView;
        [SerializeField] private GameSettings settings;
        public override void InstallBindings()
        {
            var worldInstance = Instantiate(worldPrefab);
            settings.InjectSettings(Settings.Model);
            Container.BindInstance(worldInstance).WithId("WorldInstance");
            var ruler = worldInstance.GetComponent<Ruler>();
            Container.BindInstance(ruler);
            Settings.Model.Set(Const.RulerObjectVariable, ruler);
            var workerInstance = Instantiate(workerPrefab);
            Container.BindInstance(workerInstance);
            Container.BindInstance(worldInstance.AddComponent<Navigation>());
            var workerViewInstance = Instantiate(workerView);
            Container.BindInstance(workerViewInstance);
            Container.BindInstance(new WantedStateButtonsController(Settings.Model));
            var bankAccountViewInstance = Instantiate(bankAccountView);
            Container.BindInstance(bankAccountViewInstance);
            var navigationCanvasInstance = Instantiate(navigationCanvas);
            Container.InjectGameObject(worldInstance.gameObject);
            Container.InjectGameObject(workerInstance.gameObject);
            Container.InjectGameObject(workerViewInstance.gameObject);
            Container.InjectGameObject(bankAccountViewInstance.gameObject);
        }
    }
}

using System.Threading;
using Cysharp.Threading.Tasks;
using Galaga.Game.Commands;
using Galaga.Game.Model;
using Galaga.MainMenu.Commands;
using Game.Services;
using Zenject;


namespace Actions
{
    public class ActionController
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public UnitsModel UnitsModel { get; set; }
        [Inject] public TickService TickService { get; set; }
        
        private IActionData[] _actions;
        private int _actionIndex = 0;
        private bool _isPlaying = false;

        private CancellationTokenSource _cts;

        public ActionController(IActionData[] actions)
        {
            _actions = actions;
            _cts = new CancellationTokenSource();
        }

        public void Play(int stepId)
        {
            _actionIndex = stepId;
            _isPlaying = true;
            DoAction(_actions[_actionIndex]);
        }

        public void Stop()
        {
            _cts.Cancel();
            _isPlaying = false;
        }

        private void NextAction()
        {
            if (_isPlaying)
            {
                _actionIndex++;
                if (_actionIndex >= _actions.Length)
                {
                    Stop();
                    SignalBus.Fire<LevelFinishedSignal>();
                }
                else
                {
                    DoAction(_actions[_actionIndex]);    
                }
            }
        }

        public void DoActionId(string actionId)
        {
            var index = -1;
            for (var i = 0; i < _actions.Length; i++)
            {
                var action = _actions[i];
                if (action.ID == actionId)
                {
                    index = i;
                    break;
                }
            }

            _actionIndex = index;
            _isPlaying = true;
            DoAction(_actions[_actionIndex]);
        }

        private void DoAction(IActionData actionData)
        {
            switch (actionData.Type)
            {
                case ActionType.NONE:
                    NextAction();
                    break;
                case ActionType.WAIT:
                    Wait((WaitActionData)actionData,_cts.Token);
                    break;
                case ActionType.WAIT_TEAM_DESTROYED:
                    WaitEnemiesDestroyed((WaitTeamDestroyedActionData)actionData,_cts.Token);
                    break;
                case ActionType.STOP:
                    Stop();
                    break;
                case ActionType.SPAWN_UNIT:
                    SpawnUnit((SpawnUnitActionData)actionData);
                    break;
            }
        }

        private async UniTask Wait(WaitActionData data,CancellationToken cancellationToken)
        {
            await UniTask.Delay((int)(data.time * 1000),cancellationToken:cancellationToken);
            NextAction();
        }

        private async UniTask WaitEnemiesDestroyed(WaitTeamDestroyedActionData data,CancellationToken cancellationToken)
        {
            
            var team = UnitsModel.Teams.Find(x => x.Id == data.teamId);
            await UniTask.WaitUntil(() => team.Units.Count <= 0,cancellationToken:cancellationToken);
            NextAction();
        }

        private async void SpawnUnit(SpawnUnitActionData data)
        {
            SignalBus.Fire(new SpawnUnitSignal { Data = data.Data });
            NextAction();
        }
    }
}
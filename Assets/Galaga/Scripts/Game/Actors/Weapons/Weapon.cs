using System.Threading;
using Cysharp.Threading.Tasks;
using Galaga.Common.Utils.Data;
using Galaga.Game.Actors.Weapons.Components;
using Galaga.Game.Commands;
using UnityEngine;
using Zenject;

namespace Galaga.Game.Actors.Weapons
{
    public class Weapon
    {
        [Inject] public SignalBus SignalBus { get; set; }
        
        public IPositionContainer PositionContainer { get; set; }
        public Quaternion Rotation { get; set; }
        public IShotDirection ShotDir { get; set; }
        
        public string TeamId { get; set; }
        
        private WeaponConfig _config;
        public WeaponConfig Config
        {
            get => _config;
            set => _config = value;
        }

        private ActiveData<bool> _isFirePressed = new ();
        public ActiveData<bool> IsFirePressed => _isFirePressed;
        
        private ActiveData<bool> _isCooldowned = new ();
        private CancellationTokenSource _cooldownCTS;

        public void Init()
        {
            _isCooldowned.UpdateEvent += OnIsCooldowned;
            _isFirePressed.UpdateEvent += OnIsFirePressed;
            if (!_isCooldowned.Value)
            {
                StartCooldown();
            }
        }

        public void DeInit()
        {
            _cooldownCTS.Cancel();
            _isCooldowned.UpdateEvent -= OnIsCooldowned;
            _isFirePressed.UpdateEvent -= OnIsFirePressed;
        }

        private void OnIsFirePressed(bool isVal)
        {
            TryToAttack();
        }
        
        private void OnIsCooldowned(bool isVal)
        {
            //fire direction
            //bullet type
            TryToAttack();
            if (!isVal)
            {
                StartCooldown();
            }
        }

        private void TryToAttack()
        {
            if (_isFirePressed.Value && _isCooldowned.Value)
            {
                Shot();
            }
        }
        
        private void Shot()
        {
            for (var i = 0; i < Config.Pellets; i++)
            {
                var pos = PositionContainer.Pos;
                var dir = Rotation * ShotDir.GetDir(); 

                ShotDir.Shot();
                SignalBus.Fire(new ShotSignal{Pos = pos, Dir= dir, TeamId = TeamId,BulletSpeed=_config.BulletSpeed});    
            }

            _isCooldowned.Value = false;
        }

        #region Cooldown
        private void StartCooldown()
        {
            if (_cooldownCTS == null || _cooldownCTS.IsCancellationRequested)
            {
                _cooldownCTS?.Dispose();
                _cooldownCTS = null;
                _cooldownCTS = new CancellationTokenSource(); 
            }
            
            Cooldowning(_cooldownCTS.Token);
        }

        private async UniTask Cooldowning(CancellationToken cancellationToken)
        {
            await UniTask.Delay((int)(Config.CooldownTime*1000),cancellationToken:cancellationToken);
            EndCooldown();
        }
        
        private void EndCooldown()
        {
            _isCooldowned.Value = true;
        }
        #endregion
    }
}
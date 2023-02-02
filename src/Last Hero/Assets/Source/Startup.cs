using AffenCode;
using LastHero.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine;
using System;
using LastHero.Systems;

namespace LastHero
{
    public class Startup : EcsStartup
    {
        [Space]

        [SerializeField] private Configuration _configuration;

        private EcsSystems _coreSystems;



        private void Start()
        {
            if (_configuration is null)
            {
                throw new NullReferenceException("config not seted");
            }

            else if (_configuration.StartScene is null)
            {
                throw new NullReferenceException("start scene on config not seted");
            }

            if (InitializeOnStart)
            {
                Initialize();

                AddCoreSystems();

                AddOneFrameSystems();

                InjectSystems();

                StartSystems();
            }

        }

        private void AddOneFrameSystems()
        {

        }

        private void AddCoreSystems()
        {

            _coreSystems = new EcsSystems(WorldProvider.World);

            _coreSystems
                .Add(new StartGameSystem());
        }

        private void InjectSystems()
        {
            LeoEcsLiteInjector.AddInjection(_configuration);

            _coreSystems.Inject();
        }

        private void StartSystems()
        {
            _coreSystems.Init();
        }

        protected override void AddFixedUpdateSystems(EcsSystems ecsSystems)
        {
        }

        protected override void AddLateUpdateSystems(EcsSystems ecsSystems)
        {

        }

        protected override void AddUpdateSystems(EcsSystems ecsSystems)
        {

            ecsSystems
                .Add(new InputPlayerSystem())
                .Add(new InputZombieSystem());
        }

        private new void OnDestroy()
        {
            base.OnDestroy();

            _coreSystems?.Destroy();

            _coreSystems = null;


        }
    }

}

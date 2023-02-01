using AffenCode;
using LastHero.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine;
using System;
using LastHero.Assets.Source.Systems;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEditor;
using LastHero.ScriptableObjects.Interfaces;

namespace LastHero
{
    public class Startup : EcsStartup
    {
        [Space]

        [SerializeField] private Configuration _configuration;

        private EcsSystems _coreSystems;

        private void Start()
        {
            if (!_configuration)
            {
                throw new NullReferenceException("config not seted");
            }

            else if (_configuration.StartScene is null)
            {
                throw new NullReferenceException("start scene on config not seted");
            }

            if (InitializeOnStart)
            {
                LeoEcsLiteInjector.AddInjection(_configuration);

                _coreSystems = new EcsSystems(WorldProvider.World);

                Initialize();

                _coreSystems
                    .Add(new StartGameSystem())
                    .Inject()
                    .Init();
            }

            }

        

        protected override void AddFixedUpdateSystems(EcsSystems ecsSystems)
        {
        }

        protected override void AddLateUpdateSystems(EcsSystems ecsSystems)
        {
        }

        protected override void AddUpdateSystems(EcsSystems ecsSystems)
        {
        }
    }

}

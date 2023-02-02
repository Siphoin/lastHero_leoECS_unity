using LastHero.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine.SceneManagement;

namespace LastHero.Systems
{
    internal class StartGameSystem : IEcsInitSystem
    {
        private Configuration _configuration;

        public void Init(IEcsSystems systems) 
            => SceneManager.LoadScene(_configuration.StartScene.name, LoadSceneMode.Additive);
    }
}

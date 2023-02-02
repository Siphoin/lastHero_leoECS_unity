using LastHero.Components;
using LastHero.Tags;
using Leopotam.EcsLite;

namespace LastHero.Systems
{
    public class InputPlayerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;

        public void Run(IEcsSystems systems)
        {
            var filter = _world.Filter<PlayerComponent>().Inc<LocalPlayerTag>().Inc<InputComponent>().End();


        }
    }
}

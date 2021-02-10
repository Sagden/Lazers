using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class PlayerInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly ObjectsContainer objectsContainer = null;

        EcsFilter<PlayerComponent, RayComponent> player;
        
        public void Init () 
        {
            var newPlayer = _world.NewEntity();
            newPlayer.Replace(new PlayerComponent());
            newPlayer.Replace(new DirectionComponent { direction = Quaternion.Euler(0, 0, 0) });
            newPlayer.Replace(new RayComponent());


            player.Get2(0).lineRenderer = objectsContainer.player.AddComponent<LineRenderer>();
            player.Get2(0).lineRenderer.positionCount = 1;
            player.Get2(0).lineRenderer.startWidth = 0.1f;
            player.Get2(0).lineRenderer.endWidth = 0.1f;
            player.Get2(0).lineRenderer.numCornerVertices = 5;
            player.Get2(0).lineRenderer.material = objectsContainer.rayMaterial;
            player.Get2(0).lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
        }
    }
}
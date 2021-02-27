using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class PlayerInputSystem : IEcsRunSystem 
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<PlayerComponent, DirectionComponent> players;

        private float oldMousePosition;

        void IEcsRunSystem.Run () 
        {
            if (!Input.GetMouseButton(0))  return;

            if (Input.GetMouseButtonDown(0)) 
                oldMousePosition = Input.mousePosition.x;

            float deltaX = Input.mousePosition.x - oldMousePosition;

            foreach (var player in players)
            {
                players.Get2(player).direction *= Quaternion.Euler(0, -deltaX / 10, 0);
            }

            oldMousePosition = Input.mousePosition.x;
        }
    }
}
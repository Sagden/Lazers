using Leopotam.Ecs;
using DG.Tweening;

namespace Client {
    sealed class RotateBehaviourSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly ObjectsContainer objectsContainer = null;

        EcsFilter<PlayerComponent, DirectionComponent> player;
        
        void IEcsRunSystem.Run () 
        {
            objectsContainer.player.transform.DOLocalRotateQuaternion(player.Get2(0).direction, 1);
        }
    }
}
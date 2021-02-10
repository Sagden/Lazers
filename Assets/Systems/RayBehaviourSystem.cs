using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviourSystem : IEcsRunSystem
{
    readonly EcsWorld _world = null;
    readonly ObjectsContainer objectsContainer = null;

    EcsFilter<PlayerComponent, DirectionComponent, RayComponent> player;

    void IEcsRunSystem.Run()
    {

        Vector3 playerPos = objectsContainer.player.transform.position;
        Vector3 playerDir = objectsContainer.player.transform.forward;
        AddRayPoint(playerPos, playerDir, 1);

    }

    private void AddRayPoint(Vector3 outside, Vector3 direction, int pointIndex)
    {
        if (pointIndex > 100) return;

        RaycastHit hit;
        if (Physics.Raycast(outside, direction, out hit, 20f))
        {

            player.Get3(0).lineRenderer.positionCount = pointIndex + 1;
            player.Get3(0).lineRenderer.SetPosition(pointIndex, hit.point);

            Vector3 firstVector = outside - hit.point;
            float angle = Vector3.Angle(Quaternion.AngleAxis(-90, Vector3.up) * hit.normal, firstVector);

            AddRayPoint(hit.point, (Quaternion.AngleAxis(90 - angle, Vector3.up) * hit.normal), pointIndex + 1);

        }
        else
        {
            player.Get3(0).lineRenderer.positionCount = pointIndex + 1;
            player.Get3(0).lineRenderer.SetPosition(pointIndex, outside + direction * 20);
        }
    }
}

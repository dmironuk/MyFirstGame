using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CollectableBehaviorSystem : SystemBase
{
    protected override void OnUpdate()
    {

        Entities.ForEach((ref Rotation rotation, ref CollectedComponent collectable) =>
        {
            collectable.rotationAngle = 0.5f;
            float3 targetDirection = new float3((float)math.sin(collectable.rotationAngle), 0, (float)math.cos(collectable.rotationAngle));
            rotation.Value = quaternion.LookRotationSafe(targetDirection, Vector3.up);
        }).Schedule();

    }


}
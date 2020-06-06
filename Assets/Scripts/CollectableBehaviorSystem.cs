using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System.Collections.Specialized;

public class CollectableBehaviorSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float elapsed = (float)Time.ElapsedTime;
        Entities.ForEach((ref Rotation rotation, ref CollectedComponent collectable) =>
        {
            collectable.rotationAngle = collectable.rotationAngle + 0.005f;
            quaternion targetDirection = math.mul(rotation.Value, quaternion.RotateY(collectable.rotationAngle + elapsed));
            rotation.Value = targetDirection;

        }).Schedule();

    }


}
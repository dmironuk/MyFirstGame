using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System;

public class PlayerBehaviourSystem : SystemBase
{
    protected override void OnUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Entities.ForEach((ref PlayerComponent player, ref Translation transition, ref Rotation rotation) =>
        {
            player.rotationAngle += moveHorizontal * player.moveSpeed;
            float3 targetDirection = new float3((float)Math.Sin(player.rotationAngle), 0, (float)Math.Cos(player.rotationAngle));

            rotation.Value = quaternion.LookRotationSafe(targetDirection, Vector3.up);
            transition.Value += targetDirection * player.moveSpeed * moveVertical;
            

            }).Schedule();

    }
}

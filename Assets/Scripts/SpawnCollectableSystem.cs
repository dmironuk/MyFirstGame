using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class SpawnCollectableSystem : SystemBase
{  
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var randomArray = World.GetExistingSystem<RandomSystem>().RandomArray;
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();


        Entities
            .WithNativeDisableParallelForRestriction(randomArray)
            .ForEach((Entity entity, int nativeThreadIndex, int entityInQueryIndex, in SpawnCollectableComponent collectables) =>
            {
                for (int i = 1; i <= collectables.numberCollectables; i++)
                {
                    var random = randomArray[nativeThreadIndex];

                    Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, collectables.collectablePrefab);

                    float xPosition = random.NextFloat(-10f, 10f);
                    float zPosition = random.NextFloat(-10f, 10f);

                    float3 position = new float3(xPosition, 1f, zPosition);

                    commandBuffer.AddComponent(entityInQueryIndex, entityInstance, new Translation { Value = position });
                    commandBuffer.AddComponent(entityInQueryIndex, entityInstance, new CollectedComponent { isCollected = false, rotationAngle = 0f });
                    randomArray[nativeThreadIndex] = random;
                }

                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).ScheduleParallel(); ;

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerComponent : IComponentData
{
    public float moveSpeed;
    public float rotationAngle;
}


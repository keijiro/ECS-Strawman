using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class DancerAuthoring : MonoBehaviour
{
    class Baker : Baker<DancerAuthoring>
    {
        public override void Bake(DancerAuthoring src)
          => AddComponent(GetEntity(TransformUsageFlags.Dynamic), new Dancer());
    }
}

public struct Dancer : IComponentData
{
    public float2 Velocity;
}

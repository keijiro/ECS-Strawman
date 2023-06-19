using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class DancerAuthoring : MonoBehaviour
{
    public float _speed = 1;

    class Baker : Baker<DancerAuthoring>
    {
        public override void Bake(DancerAuthoring src)
          => AddComponent(GetEntity(TransformUsageFlags.Dynamic),
                          new Dancer(){ Speed = src._speed });
    }
}

public struct Dancer : IComponentData
{
    public float Speed;
}

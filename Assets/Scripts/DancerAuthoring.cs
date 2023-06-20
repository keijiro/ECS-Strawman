using Unity.Entities;
using UnityEngine;

public struct Dancer : IComponentData
{
    public float Speed;
}

public class DancerAuthoring : MonoBehaviour
{
    public float _speed = 1;

    class Baker : Baker<DancerAuthoring>
    {
        public override void Bake(DancerAuthoring src)
        {
            var data = new Dancer(){ Speed = src._speed };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}

using Unity.Entities;
using UnityEngine;

public struct Walker : IComponentData
{
    public float ForwardSpeed;
    public float AngularSpeed;
}

public class WalkerAuthoring : MonoBehaviour
{
    public float _forwardSpeed = 1;
    public float _angularSpeed = 1;

    class Baker : Baker<WalkerAuthoring>
    {
        public override void Bake(WalkerAuthoring src)
        {
            var data = new Walker()
            {
                ForwardSpeed = src._forwardSpeed,
                AngularSpeed = src._angularSpeed
            };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}

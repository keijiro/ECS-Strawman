using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct DancerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var t = (float)SystemAPI.Time.ElapsedTime * 3;

        foreach (var (dancer, xform) in
                 SystemAPI.Query<RefRO<Dancer>,
                                 RefRW<LocalTransform>>())
        {
            xform.ValueRW.Position.y = math.abs(math.sin(t)) * 0.1f;
            xform.ValueRW.Rotation = quaternion.EulerXZY(math.float3(0, math.sin(t * 0.37f), math.cos(t) * 0.5f));
        }
    }
}

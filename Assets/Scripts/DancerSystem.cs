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
        var elapsed = (float)SystemAPI.Time.ElapsedTime;

        foreach (var (dancer, xform) in
                 SystemAPI.Query<RefRO<Dancer>,
                                 RefRW<LocalTransform>>())
        {
            var t = dancer.ValueRO.Speed * elapsed;

            var py = math.abs(math.sin(t)) * 0.1f;
            var ry = math.sin(0.6f * t);
            var rz = math.cos(0.8f * t) * 0.5f;

            xform.ValueRW.Position.y = py;
            xform.ValueRW.Rotation = quaternion.EulerXZY(math.float3(0, ry, rz));
        }
    }
}

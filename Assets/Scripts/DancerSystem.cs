using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct DancerSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var elapsed = (float)SystemAPI.Time.ElapsedTime;

        foreach (var (dancer, xform) in
                 SystemAPI.Query<RefRO<Dancer>,
                                 RefRW<LocalTransform>>())
        {
            var t = dancer.ValueRO.Speed * elapsed;
            var y = math.abs(math.sin(t)) * 0.1f;
            var bank = math.cos(t) * 0.5f;

            var fwd = xform.ValueRO.Forward();
            var rot = quaternion.AxisAngle(fwd, bank);
            var up = math.mul(rot, math.float3(0, 1, 0));

            xform.ValueRW.Position.y = y;
            xform.ValueRW.Rotation = quaternion.LookRotation(fwd, up);
        }
    }
}

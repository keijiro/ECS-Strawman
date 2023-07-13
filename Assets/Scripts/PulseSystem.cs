using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct PulseSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var elapsed = (float)SystemAPI.Time.ElapsedTime;

        foreach (var (dancer, walker, xform) in
                 SystemAPI.Query<RefRO<Dancer>,
                                 RefRO<Walker>,
                                 RefRW<LocalTransform>>())
        {
            var t = dancer.ValueRO.Speed * elapsed;
            xform.ValueRW.Scale = 1.1f - 0.3f * math.abs(math.cos(t));
        }
    }
}

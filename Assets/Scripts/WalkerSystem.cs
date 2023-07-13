using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct WalkerSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var dt = SystemAPI.Time.DeltaTime;

        foreach (var (walker, xform) in
                 SystemAPI.Query<RefRO<Walker>,
                                 RefRW<LocalTransform>>())
        {
            var rot = quaternion.RotateY(walker.ValueRO.AngularSpeed * dt);
            var fwd = math.mul(rot, xform.ValueRO.Forward());
            xform.ValueRW.Position += fwd * walker.ValueRO.ForwardSpeed * dt;
            xform.ValueRW.Rotation = quaternion.LookRotation(fwd, xform.ValueRO.Up());
        }
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A sphere-shaped 3D particle collision shape affecting <see cref="Godot.GpuParticles3D"/> nodes.</para>
/// <para>Particle collision shapes work in real-time and can be moved, rotated and scaled during gameplay. Unlike attractors, non-uniform scaling of collision shapes is <i>not</i> supported.</para>
/// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> must be <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/> or <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.HideOnContact"/> on the <see cref="Godot.GpuParticles3D"/>'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="Godot.GpuParticles3D"/>, not <see cref="Godot.CpuParticles3D"/>.</para>
/// </summary>
[GodotClassName("GPUParticlesCollisionSphere3D")]
public partial class GpuParticlesCollisionSphere3D : GpuParticlesCollision3D
{
    /// <summary>
    /// <para>The collision sphere's radius in 3D units.</para>
    /// </summary>
    public float Radius
    {
        get
        {
            return GetRadius();
        }
        set
        {
            SetRadius(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GpuParticlesCollisionSphere3D);

    private static readonly StringName NativeName = "GPUParticlesCollisionSphere3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GpuParticlesCollisionSphere3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollisionSphere3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollisionSphere3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Invokes the method with the given name, using the given arguments.
    /// This method is used by Godot to invoke methods from the engine side.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to invoke.</param>
    /// <param name="args">Arguments to use with the invoked method.</param>
    /// <param name="ret">Value returned by the invoked method.</param>
#pragma warning disable CS0618 // Member is obsolete
    protected internal override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
#pragma warning restore CS0618

    /// <summary>
    /// Check if the type contains a method with the given name.
    /// This method is used by Godot to check if a method exists before invoking it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to check for.</param>

    protected internal override bool HasGodotClassMethod(in godot_string_name method)
    {
        return base.HasGodotClassMethod(method);
    }

    /// <summary>
    /// Check if the type contains a signal with the given name.
    /// This method is used by Godot to check if a signal exists before raising it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="signal">Name of the signal to check for.</param>

    protected internal override bool HasGodotClassSignal(in godot_string_name signal)
    {
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GpuParticlesCollision3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GpuParticlesCollision3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GpuParticlesCollision3D.SignalName
    {
    }
}

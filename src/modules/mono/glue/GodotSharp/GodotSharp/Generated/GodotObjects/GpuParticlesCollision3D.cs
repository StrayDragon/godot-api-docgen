namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Particle collision shapes can be used to make particles stop or bounce against them.</para>
/// <para>Particle collision shapes work in real-time and can be moved, rotated and scaled during gameplay. Unlike attractors, non-uniform scaling of collision shapes is <i>not</i> supported.</para>
/// <para>Particle collision shapes can be temporarily disabled by hiding them.</para>
/// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> must be <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/> or <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.HideOnContact"/> on the <see cref="Godot.GpuParticles3D"/>'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="Godot.GpuParticles3D"/>, not <see cref="Godot.CpuParticles3D"/>.</para>
/// <para><b>Note:</b> Particles pushed by a collider that is being moved will not be interpolated, which can result in visible stuttering. This can be alleviated by setting <see cref="Godot.GpuParticles3D.FixedFps"/> to <c>0</c> or a value that matches or exceeds the target framerate.</para>
/// </summary>
[GodotClassName("GPUParticlesCollision3D")]
public partial class GpuParticlesCollision3D : VisualInstance3D
{
    /// <summary>
    /// <para>The particle rendering layers (<see cref="Godot.VisualInstance3D.Layers"/>) that will be affected by the collision shape. By default, all particles that have <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> set to <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/> or <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.HideOnContact"/> will be affected by a collision shape.</para>
    /// <para>After configuring particle nodes accordingly, specific layers can be unchecked to prevent certain particles from being affected by colliders. For example, this can be used if you're using a collider as part of a spell effect but don't want the collider to affect unrelated weather particles at the same position.</para>
    /// <para>Particle collision can also be disabled on a per-process material basis by setting <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> on the <see cref="Godot.GpuParticles3D"/> node.</para>
    /// </summary>
    public uint CullMask
    {
        get
        {
            return GetCullMask();
        }
        set
        {
            SetCullMask(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GpuParticlesCollision3D);

    private static readonly StringName NativeName = "GPUParticlesCollision3D";

    internal GpuParticlesCollision3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollision3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollision3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind0, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCullMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'cull_mask' property.
        /// </summary>
        public static readonly StringName CullMask = "cull_mask";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_cull_mask' method.
        /// </summary>
        public static readonly StringName SetCullMask = "set_cull_mask";
        /// <summary>
        /// Cached name for the 'get_cull_mask' method.
        /// </summary>
        public static readonly StringName GetCullMask = "get_cull_mask";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}

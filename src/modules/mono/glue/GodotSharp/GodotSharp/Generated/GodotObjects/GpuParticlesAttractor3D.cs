namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Particle attractors can be used to attract particles towards the attractor's origin, or to push them away from the attractor's origin.</para>
/// <para>Particle attractors work in real-time and can be moved, rotated and scaled during gameplay. Unlike collision shapes, non-uniform scaling of attractors is also supported.</para>
/// <para>Attractors can be temporarily disabled by hiding them, or by setting their <see cref="Godot.GpuParticlesAttractor3D.Strength"/> to <c>0.0</c>.</para>
/// <para><b>Note:</b> Particle attractors only affect <see cref="Godot.GpuParticles3D"/>, not <see cref="Godot.CpuParticles3D"/>.</para>
/// </summary>
[GodotClassName("GPUParticlesAttractor3D")]
public partial class GpuParticlesAttractor3D : VisualInstance3D
{
    /// <summary>
    /// <para>Adjusts the strength of the attractor. If <see cref="Godot.GpuParticlesAttractor3D.Strength"/> is negative, particles will be pushed in the opposite direction. Particles will be pushed <i>away</i> from the attractor's origin if <see cref="Godot.GpuParticlesAttractor3D.Directionality"/> is <c>0.0</c>, or towards local +Z if <see cref="Godot.GpuParticlesAttractor3D.Directionality"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    public float Strength
    {
        get
        {
            return GetStrength();
        }
        set
        {
            SetStrength(value);
        }
    }

    /// <summary>
    /// <para>The particle attractor's attenuation. Higher values result in more gradual pushing of particles as they come closer to the attractor's origin. Zero or negative values will cause particles to be pushed very fast as soon as the touch the attractor's edges.</para>
    /// </summary>
    public float Attenuation
    {
        get
        {
            return GetAttenuation();
        }
        set
        {
            SetAttenuation(value);
        }
    }

    /// <summary>
    /// <para>Adjusts how directional the attractor is. At <c>0.0</c>, the attractor is not directional at all: it will attract particles towards its center. At <c>1.0</c>, the attractor is fully directional: particles will always be pushed towards local -Z (or +Z if <see cref="Godot.GpuParticlesAttractor3D.Strength"/> is negative).</para>
    /// <para><b>Note:</b> If <see cref="Godot.GpuParticlesAttractor3D.Directionality"/> is greater than <c>0.0</c>, the direction in which particles are pushed can be changed by rotating the <see cref="Godot.GpuParticlesAttractor3D"/> node.</para>
    /// </summary>
    public float Directionality
    {
        get
        {
            return GetDirectionality();
        }
        set
        {
            SetDirectionality(value);
        }
    }

    /// <summary>
    /// <para>The particle rendering layers (<see cref="Godot.VisualInstance3D.Layers"/>) that will be affected by the attractor. By default, all particles are affected by an attractor.</para>
    /// <para>After configuring particle nodes accordingly, specific layers can be unchecked to prevent certain particles from being affected by attractors. For example, this can be used if you're using an attractor as part of a spell effect but don't want the attractor to affect unrelated weather particles at the same position.</para>
    /// <para>Particle attraction can also be disabled on a per-process material basis by setting <see cref="Godot.ParticleProcessMaterial.AttractorInteractionEnabled"/> on the <see cref="Godot.GpuParticles3D"/> node.</para>
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

    private static readonly System.Type CachedType = typeof(GpuParticlesAttractor3D);

    private static readonly StringName NativeName = "GPUParticlesAttractor3D";

    internal GpuParticlesAttractor3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesAttractor3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesAttractor3D(bool memoryOwn) : base(memoryOwn) { }

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

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttenuation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttenuation(float attenuation)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), attenuation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttenuation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAttenuation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDirectionality, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDirectionality(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirectionality, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDirectionality()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
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
        /// Cached name for the 'strength' property.
        /// </summary>
        public static readonly StringName Strength = "strength";
        /// <summary>
        /// Cached name for the 'attenuation' property.
        /// </summary>
        public static readonly StringName Attenuation = "attenuation";
        /// <summary>
        /// Cached name for the 'directionality' property.
        /// </summary>
        public static readonly StringName Directionality = "directionality";
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
        /// <summary>
        /// Cached name for the 'set_strength' method.
        /// </summary>
        public static readonly StringName SetStrength = "set_strength";
        /// <summary>
        /// Cached name for the 'get_strength' method.
        /// </summary>
        public static readonly StringName GetStrength = "get_strength";
        /// <summary>
        /// Cached name for the 'set_attenuation' method.
        /// </summary>
        public static readonly StringName SetAttenuation = "set_attenuation";
        /// <summary>
        /// Cached name for the 'get_attenuation' method.
        /// </summary>
        public static readonly StringName GetAttenuation = "get_attenuation";
        /// <summary>
        /// Cached name for the 'set_directionality' method.
        /// </summary>
        public static readonly StringName SetDirectionality = "set_directionality";
        /// <summary>
        /// Cached name for the 'get_directionality' method.
        /// </summary>
        public static readonly StringName GetDirectionality = "get_directionality";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}

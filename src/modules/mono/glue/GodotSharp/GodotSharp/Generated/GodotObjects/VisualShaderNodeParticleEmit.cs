namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node internally calls <c>emit_subparticle</c> shader method. It will emit a particle from the configured sub-emitter and also allows to customize how its emitted. Requires a sub-emitter assigned to the particles node with this shader.</para>
/// </summary>
public partial class VisualShaderNodeParticleEmit : VisualShaderNode
{
    public enum EmitFlags : long
    {
        /// <summary>
        /// <para>If enabled, the particle starts with the position defined by this node.</para>
        /// </summary>
        Position = 1,
        /// <summary>
        /// <para>If enabled, the particle starts with the rotation and scale defined by this node.</para>
        /// </summary>
        RotScale = 2,
        /// <summary>
        /// <para>If enabled,the particle starts with the velocity defined by this node.</para>
        /// </summary>
        Velocity = 4,
        /// <summary>
        /// <para>If enabled, the particle starts with the color defined by this node.</para>
        /// </summary>
        Color = 8,
        /// <summary>
        /// <para>If enabled, the particle starts with the <c>CUSTOM</c> data defined by this node.</para>
        /// </summary>
        Custom = 16
    }

    /// <summary>
    /// <para>Flags used to override the properties defined in the sub-emitter's process material.</para>
    /// </summary>
    public VisualShaderNodeParticleEmit.EmitFlags Flags
    {
        get
        {
            return GetFlags();
        }
        set
        {
            SetFlags(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeParticleEmit);

    private static readonly StringName NativeName = "VisualShaderNodeParticleEmit";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeParticleEmit() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParticleEmit(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParticleEmit(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlags, 3960756792ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlags(VisualShaderNodeParticleEmit.EmitFlags flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlags, 171277835ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeParticleEmit.EmitFlags GetFlags()
    {
        return (VisualShaderNodeParticleEmit.EmitFlags)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'flags' property.
        /// </summary>
        public static readonly StringName Flags = "flags";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_flags' method.
        /// </summary>
        public static readonly StringName SetFlags = "set_flags";
        /// <summary>
        /// Cached name for the 'get_flags' method.
        /// </summary>
        public static readonly StringName GetFlags = "get_flags";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}

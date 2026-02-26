namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Particle accelerator can be used in "process" step of particle shader. It will accelerate the particles. Connect it to the Velocity output port.</para>
/// </summary>
public partial class VisualShaderNodeParticleAccelerator : VisualShaderNode
{
    public enum ModeEnum : long
    {
        /// <summary>
        /// <para>The particles will be accelerated based on their velocity.</para>
        /// </summary>
        Linear = 0,
        /// <summary>
        /// <para>The particles will be accelerated towards or away from the center.</para>
        /// </summary>
        Radial = 1,
        /// <summary>
        /// <para>The particles will be accelerated tangentially to the radius vector from center to their position.</para>
        /// </summary>
        Tangential = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeParticleAccelerator.ModeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Defines in what manner the particles will be accelerated.</para>
    /// </summary>
    public VisualShaderNodeParticleAccelerator.ModeEnum Mode
    {
        get
        {
            return GetMode();
        }
        set
        {
            SetMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeParticleAccelerator);

    private static readonly StringName NativeName = "VisualShaderNodeParticleAccelerator";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeParticleAccelerator() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParticleAccelerator(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParticleAccelerator(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMode, 3457585749ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMode(VisualShaderNodeParticleAccelerator.ModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMode, 2660365633ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeParticleAccelerator.ModeEnum GetMode()
    {
        return (VisualShaderNodeParticleAccelerator.ModeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'mode' property.
        /// </summary>
        public static readonly StringName Mode = "mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mode' method.
        /// </summary>
        public static readonly StringName SetMode = "set_mode";
        /// <summary>
        /// Cached name for the 'get_mode' method.
        /// </summary>
        public static readonly StringName GetMode = "get_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}

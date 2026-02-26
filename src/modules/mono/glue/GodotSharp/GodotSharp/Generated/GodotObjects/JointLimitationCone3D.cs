namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A cone shape limitation that interacts with <see cref="Godot.ChainIK3D"/>.</para>
/// </summary>
public partial class JointLimitationCone3D : JointLimitation3D
{
    /// <summary>
    /// <para>The radius range of the hole made by the cone.</para>
    /// <para><c>0</c> degrees makes a sphere without hole, <c>180</c> degrees makes a hemisphere, and <c>360</c> degrees become empty (no limitation).</para>
    /// </summary>
    public float Angle
    {
        get
        {
            return GetAngle();
        }
        set
        {
            SetAngle(value);
        }
    }

    private static readonly System.Type CachedType = typeof(JointLimitationCone3D);

    private static readonly StringName NativeName = "JointLimitationCone3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public JointLimitationCone3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal JointLimitationCone3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal JointLimitationCone3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngle()
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
    public new class PropertyName : JointLimitation3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'angle' property.
        /// </summary>
        public static readonly StringName Angle = "angle";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : JointLimitation3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_angle' method.
        /// </summary>
        public static readonly StringName SetAngle = "set_angle";
        /// <summary>
        /// Cached name for the 'get_angle' method.
        /// </summary>
        public static readonly StringName GetAngle = "get_angle";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : JointLimitation3D.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A physics joint that connects two 3D physics bodies in a way that simulates a ball-and-socket joint. The twist axis is initiated as the X axis of the <see cref="Godot.ConeTwistJoint3D"/>. Once the physics bodies swing, the twist axis is calculated as the middle of the X axes of the joint in the local space of the two physics bodies. Useful for limbs like shoulders and hips, lamps hanging off a ceiling, etc.</para>
/// </summary>
public partial class ConeTwistJoint3D : Joint3D
{
    public enum Param : long
    {
        /// <summary>
        /// <para>Swing is rotation from side to side, around the axis perpendicular to the twist axis.</para>
        /// <para>The swing span defines, how much rotation will not get corrected along the swing axis.</para>
        /// <para>Could be defined as looseness in the <see cref="Godot.ConeTwistJoint3D"/>.</para>
        /// <para>If below 0.05, this behavior is locked.</para>
        /// </summary>
        SwingSpan = 0,
        /// <summary>
        /// <para>Twist is the rotation around the twist axis, this value defined how far the joint can twist.</para>
        /// <para>Twist is locked if below 0.05.</para>
        /// </summary>
        TwistSpan = 1,
        /// <summary>
        /// <para>The speed with which the swing or twist will take place.</para>
        /// <para>The higher, the faster.</para>
        /// </summary>
        Bias = 2,
        /// <summary>
        /// <para>The ease with which the joint starts to twist. If it's too low, it takes more force to start twisting the joint.</para>
        /// </summary>
        Softness = 3,
        /// <summary>
        /// <para>Defines, how fast the swing- and twist-speed-difference on both sides gets synced.</para>
        /// </summary>
        Relaxation = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.ConeTwistJoint3D.Param"/> enum.</para>
        /// </summary>
        Max = 5
    }

    /// <summary>
    /// <para>Swing is rotation from side to side, around the axis perpendicular to the twist axis.</para>
    /// <para>The swing span defines, how much rotation will not get corrected along the swing axis.</para>
    /// <para>Could be defined as looseness in the <see cref="Godot.ConeTwistJoint3D"/>.</para>
    /// <para>If below 0.05, this behavior is locked.</para>
    /// </summary>
    public float SwingSpan
    {
        get
        {
            return GetParam((ConeTwistJoint3D.Param)(0));
        }
        set
        {
            SetParam((ConeTwistJoint3D.Param)(0), value);
        }
    }

    /// <summary>
    /// <para>Twist is the rotation around the twist axis, this value defined how far the joint can twist.</para>
    /// <para>Twist is locked if below 0.05.</para>
    /// </summary>
    public float TwistSpan
    {
        get
        {
            return GetParam((ConeTwistJoint3D.Param)(1));
        }
        set
        {
            SetParam((ConeTwistJoint3D.Param)(1), value);
        }
    }

    /// <summary>
    /// <para>The speed with which the swing or twist will take place.</para>
    /// <para>The higher, the faster.</para>
    /// </summary>
    public float Bias
    {
        get
        {
            return GetParam((ConeTwistJoint3D.Param)(2));
        }
        set
        {
            SetParam((ConeTwistJoint3D.Param)(2), value);
        }
    }

    /// <summary>
    /// <para>The ease with which the joint starts to twist. If it's too low, it takes more force to start twisting the joint.</para>
    /// </summary>
    public float Softness
    {
        get
        {
            return GetParam((ConeTwistJoint3D.Param)(3));
        }
        set
        {
            SetParam((ConeTwistJoint3D.Param)(3), value);
        }
    }

    /// <summary>
    /// <para>Defines, how fast the swing- and twist-speed-difference on both sides gets synced.</para>
    /// </summary>
    public float Relaxation
    {
        get
        {
            return GetParam((ConeTwistJoint3D.Param)(4));
        }
        set
        {
            SetParam((ConeTwistJoint3D.Param)(4), value);
        }
    }

    private static readonly System.Type CachedType = typeof(ConeTwistJoint3D);

    private static readonly StringName NativeName = "ConeTwistJoint3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConeTwistJoint3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ConeTwistJoint3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ConeTwistJoint3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParam, 1062470226ul);

    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParam(ConeTwistJoint3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind0, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParam, 2928790850ul);

    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParam(ConeTwistJoint3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind1, GodotObject.GetPtr(this), (int)param);
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
    public new class PropertyName : Joint3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'swing_span' property.
        /// </summary>
        public static readonly StringName SwingSpan = "swing_span";
        /// <summary>
        /// Cached name for the 'twist_span' property.
        /// </summary>
        public static readonly StringName TwistSpan = "twist_span";
        /// <summary>
        /// Cached name for the 'bias' property.
        /// </summary>
        public static readonly StringName Bias = "bias";
        /// <summary>
        /// Cached name for the 'softness' property.
        /// </summary>
        public static readonly StringName Softness = "softness";
        /// <summary>
        /// Cached name for the 'relaxation' property.
        /// </summary>
        public static readonly StringName Relaxation = "relaxation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Joint3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_param' method.
        /// </summary>
        public static readonly StringName SetParam = "set_param";
        /// <summary>
        /// Cached name for the 'get_param' method.
        /// </summary>
        public static readonly StringName GetParam = "get_param";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint3D.SignalName
    {
    }
}

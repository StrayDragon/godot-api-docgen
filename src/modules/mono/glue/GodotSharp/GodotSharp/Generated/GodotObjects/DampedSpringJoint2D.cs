namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A physics joint that connects two 2D physics bodies with a spring-like force. This behaves like a spring that always wants to stretch to a given length.</para>
/// </summary>
public partial class DampedSpringJoint2D : Joint2D
{
    /// <summary>
    /// <para>The spring joint's maximum length. The two attached bodies cannot stretch it past this value.</para>
    /// </summary>
    public float Length
    {
        get
        {
            return GetLength();
        }
        set
        {
            SetLength(value);
        }
    }

    /// <summary>
    /// <para>When the bodies attached to the spring joint move they stretch or squash it. The joint always tries to resize towards this length.</para>
    /// </summary>
    public float RestLength
    {
        get
        {
            return GetRestLength();
        }
        set
        {
            SetRestLength(value);
        }
    }

    /// <summary>
    /// <para>The higher the value, the less the bodies attached to the joint will deform it. The joint applies an opposing force to the bodies, the product of the stiffness multiplied by the size difference from its resting length.</para>
    /// </summary>
    public float Stiffness
    {
        get
        {
            return GetStiffness();
        }
        set
        {
            SetStiffness(value);
        }
    }

    /// <summary>
    /// <para>The spring joint's damping ratio. A value between <c>0</c> and <c>1</c>. When the two bodies move into different directions the system tries to align them to the spring axis again. A high <see cref="Godot.DampedSpringJoint2D.Damping"/> value forces the attached bodies to align faster.</para>
    /// </summary>
    public float Damping
    {
        get
        {
            return GetDamping();
        }
        set
        {
            SetDamping(value);
        }
    }

    private static readonly System.Type CachedType = typeof(DampedSpringJoint2D);

    private static readonly StringName NativeName = "DampedSpringJoint2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public DampedSpringJoint2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal DampedSpringJoint2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal DampedSpringJoint2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRestLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRestLength(float restLength)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), restLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRestLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRestLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStiffness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStiffness(float stiffness)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStiffness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStiffness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDamping, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDamping(float damping)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), damping);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDamping, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDamping()
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
    public new class PropertyName : Joint2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'length' property.
        /// </summary>
        public static readonly StringName Length = "length";
        /// <summary>
        /// Cached name for the 'rest_length' property.
        /// </summary>
        public static readonly StringName RestLength = "rest_length";
        /// <summary>
        /// Cached name for the 'stiffness' property.
        /// </summary>
        public static readonly StringName Stiffness = "stiffness";
        /// <summary>
        /// Cached name for the 'damping' property.
        /// </summary>
        public static readonly StringName Damping = "damping";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Joint2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_length' method.
        /// </summary>
        public static readonly StringName SetLength = "set_length";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'set_rest_length' method.
        /// </summary>
        public static readonly StringName SetRestLength = "set_rest_length";
        /// <summary>
        /// Cached name for the 'get_rest_length' method.
        /// </summary>
        public static readonly StringName GetRestLength = "get_rest_length";
        /// <summary>
        /// Cached name for the 'set_stiffness' method.
        /// </summary>
        public static readonly StringName SetStiffness = "set_stiffness";
        /// <summary>
        /// Cached name for the 'get_stiffness' method.
        /// </summary>
        public static readonly StringName GetStiffness = "get_stiffness";
        /// <summary>
        /// Cached name for the 'set_damping' method.
        /// </summary>
        public static readonly StringName SetDamping = "set_damping";
        /// <summary>
        /// Cached name for the 'get_damping' method.
        /// </summary>
        public static readonly StringName GetDamping = "get_damping";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint2D.SignalName
    {
    }
}

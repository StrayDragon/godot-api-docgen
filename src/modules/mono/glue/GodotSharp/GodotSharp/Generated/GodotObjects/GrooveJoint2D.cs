namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A physics joint that restricts the movement of two 2D physics bodies to a fixed axis. For example, a <see cref="Godot.StaticBody2D"/> representing a piston base can be attached to a <see cref="Godot.RigidBody2D"/> representing the piston head, moving up and down.</para>
/// </summary>
public partial class GrooveJoint2D : Joint2D
{
    /// <summary>
    /// <para>The groove's length. The groove is from the joint's origin towards <see cref="Godot.GrooveJoint2D.Length"/> along the joint's local Y axis.</para>
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
    /// <para>The body B's initial anchor position defined by the joint's origin and a local offset <see cref="Godot.GrooveJoint2D.InitialOffset"/> along the joint's Y axis (along the groove).</para>
    /// </summary>
    public float InitialOffset
    {
        get
        {
            return GetInitialOffset();
        }
        set
        {
            SetInitialOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GrooveJoint2D);

    private static readonly StringName NativeName = "GrooveJoint2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GrooveJoint2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GrooveJoint2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GrooveJoint2D(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInitialOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInitialOffset(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInitialOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInitialOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'initial_offset' property.
        /// </summary>
        public static readonly StringName InitialOffset = "initial_offset";
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
        /// Cached name for the 'set_initial_offset' method.
        /// </summary>
        public static readonly StringName SetInitialOffset = "set_initial_offset";
        /// <summary>
        /// Cached name for the 'get_initial_offset' method.
        /// </summary>
        public static readonly StringName GetInitialOffset = "get_initial_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint2D.SignalName
    {
    }
}

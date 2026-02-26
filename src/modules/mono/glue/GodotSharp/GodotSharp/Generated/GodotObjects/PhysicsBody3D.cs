namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.PhysicsBody3D"/> is an abstract base class for 3D game objects affected by physics. All 3D physics bodies inherit from it.</para>
/// <para><b>Warning:</b> With a non-uniform scale, this node will likely not behave as expected. It is advised to keep its scale the same on all axes and adjust its collision shape(s) instead.</para>
/// </summary>
public partial class PhysicsBody3D : CollisionObject3D
{
    /// <summary>
    /// <para>Lock the body's linear movement in the X axis.</para>
    /// </summary>
    public bool AxisLockLinearX
    {
        get
        {
            return GetAxisLock((PhysicsServer3D.BodyAxis)(1));
        }
        set
        {
            SetAxisLock((PhysicsServer3D.BodyAxis)(1), value);
        }
    }

    /// <summary>
    /// <para>Lock the body's linear movement in the Y axis.</para>
    /// </summary>
    public bool AxisLockLinearY
    {
        get
        {
            return GetAxisLock((PhysicsServer3D.BodyAxis)(2));
        }
        set
        {
            SetAxisLock((PhysicsServer3D.BodyAxis)(2), value);
        }
    }

    /// <summary>
    /// <para>Lock the body's linear movement in the Z axis.</para>
    /// </summary>
    public bool AxisLockLinearZ
    {
        get
        {
            return GetAxisLock((PhysicsServer3D.BodyAxis)(4));
        }
        set
        {
            SetAxisLock((PhysicsServer3D.BodyAxis)(4), value);
        }
    }

    /// <summary>
    /// <para>Lock the body's rotation in the X axis.</para>
    /// </summary>
    public bool AxisLockAngularX
    {
        get
        {
            return GetAxisLock((PhysicsServer3D.BodyAxis)(8));
        }
        set
        {
            SetAxisLock((PhysicsServer3D.BodyAxis)(8), value);
        }
    }

    /// <summary>
    /// <para>Lock the body's rotation in the Y axis.</para>
    /// </summary>
    public bool AxisLockAngularY
    {
        get
        {
            return GetAxisLock((PhysicsServer3D.BodyAxis)(16));
        }
        set
        {
            SetAxisLock((PhysicsServer3D.BodyAxis)(16), value);
        }
    }

    /// <summary>
    /// <para>Lock the body's rotation in the Z axis.</para>
    /// </summary>
    public bool AxisLockAngularZ
    {
        get
        {
            return GetAxisLock((PhysicsServer3D.BodyAxis)(32));
        }
        set
        {
            SetAxisLock((PhysicsServer3D.BodyAxis)(32), value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicsBody3D);

    private static readonly StringName NativeName = "PhysicsBody3D";

    internal PhysicsBody3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsBody3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsBody3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveAndCollide, 3208792678ul);

    /// <summary>
    /// <para>Moves the body along the vector <paramref name="motion"/>. In order to be frame rate independent in <see cref="Godot.Node._PhysicsProcess(double)"/> or <see cref="Godot.Node._Process(double)"/>, <paramref name="motion"/> should be computed using <c>delta</c>.</para>
    /// <para>The body will stop if it collides. Returns a <see cref="Godot.KinematicCollision3D"/>, which contains information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para>If <paramref name="testOnly"/> is <see langword="true"/>, the body does not move but the would-be collision information is given.</para>
    /// <para><paramref name="safeMargin"/> is the extra margin used for collision recovery (see <see cref="Godot.CharacterBody3D.SafeMargin"/> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision"/> is <see langword="true"/>, any depenetration from the recovery phase is also reported as a collision; this is used e.g. by <see cref="Godot.CharacterBody3D"/> for improving floor detection during floor snapping.</para>
    /// <para><paramref name="maxCollisions"/> allows to retrieve more than one collision result.</para>
    /// </summary>
    public unsafe KinematicCollision3D MoveAndCollide(Vector3 motion, bool testOnly = false, float safeMargin = 0.001f, bool recoveryAsCollision = false, int maxCollisions = 1)
    {
        return (KinematicCollision3D)NativeCalls.godot_icall_5_980(MethodBind0, GodotObject.GetPtr(this), &motion, testOnly.ToGodotBool(), safeMargin, recoveryAsCollision.ToGodotBool(), maxCollisions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TestMove, 2481691619ul);

    /// <summary>
    /// <para>Checks for collisions without moving the body. In order to be frame rate independent in <see cref="Godot.Node._PhysicsProcess(double)"/> or <see cref="Godot.Node._Process(double)"/>, <paramref name="motion"/> should be computed using <c>delta</c>.</para>
    /// <para>Virtually sets the node's position, scale and rotation to that of the given <see cref="Godot.Transform3D"/>, then tries to move the body along the vector <paramref name="motion"/>. Returns <see langword="true"/> if a collision would stop the body from moving along the whole path.</para>
    /// <para><paramref name="collision"/> is an optional object of type <see cref="Godot.KinematicCollision3D"/>, which contains additional information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para><paramref name="safeMargin"/> is the extra margin used for collision recovery (see <see cref="Godot.CharacterBody3D.SafeMargin"/> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision"/> is <see langword="true"/>, any depenetration from the recovery phase is also reported as a collision; this is useful for checking whether the body would <i>touch</i> any other bodies.</para>
    /// <para><paramref name="maxCollisions"/> allows to retrieve more than one collision result.</para>
    /// </summary>
    public unsafe bool TestMove(Transform3D from, Vector3 motion, KinematicCollision3D collision = default, float safeMargin = 0.001f, bool recoveryAsCollision = false, int maxCollisions = 1)
    {
        return NativeCalls.godot_icall_6_981(MethodBind1, GodotObject.GetPtr(this), &from, &motion, GodotObject.GetPtr(collision), safeMargin, recoveryAsCollision.ToGodotBool(), maxCollisions).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 3360562783ul);

    /// <summary>
    /// <para>Returns the gravity vector computed from all sources that can affect the body, including all gravity overrides from <see cref="Godot.Area3D"/> nodes and the global world gravity.</para>
    /// </summary>
    public Vector3 GetGravity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisLock, 1787895195ul);

    /// <summary>
    /// <para>Locks or unlocks the specified linear or rotational <paramref name="axis"/> depending on the value of <paramref name="lock"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAxisLock(PhysicsServer3D.BodyAxis axis, bool @lock)
    {
        NativeCalls.godot_icall_2_61(MethodBind3, GodotObject.GetPtr(this), (int)axis, @lock.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAxisLock, 2264617709ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified linear or rotational <paramref name="axis"/> is locked.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAxisLock(PhysicsServer3D.BodyAxis axis)
    {
        return NativeCalls.godot_icall_1_62(MethodBind4, GodotObject.GetPtr(this), (int)axis).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionExceptions, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    public Godot.Collections.Array<PhysicsBody3D> GetCollisionExceptions()
    {
        return new Godot.Collections.Array<PhysicsBody3D>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCollisionExceptionWith, 1078189570ul);

    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void AddCollisionExceptionWith(Node body)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(body));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCollisionExceptionWith, 1078189570ul);

    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void RemoveCollisionExceptionWith(Node body)
    {
        NativeCalls.godot_icall_1_56(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(body));
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
    public new class PropertyName : CollisionObject3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'axis_lock_linear_x' property.
        /// </summary>
        public static readonly StringName AxisLockLinearX = "axis_lock_linear_x";
        /// <summary>
        /// Cached name for the 'axis_lock_linear_y' property.
        /// </summary>
        public static readonly StringName AxisLockLinearY = "axis_lock_linear_y";
        /// <summary>
        /// Cached name for the 'axis_lock_linear_z' property.
        /// </summary>
        public static readonly StringName AxisLockLinearZ = "axis_lock_linear_z";
        /// <summary>
        /// Cached name for the 'axis_lock_angular_x' property.
        /// </summary>
        public static readonly StringName AxisLockAngularX = "axis_lock_angular_x";
        /// <summary>
        /// Cached name for the 'axis_lock_angular_y' property.
        /// </summary>
        public static readonly StringName AxisLockAngularY = "axis_lock_angular_y";
        /// <summary>
        /// Cached name for the 'axis_lock_angular_z' property.
        /// </summary>
        public static readonly StringName AxisLockAngularZ = "axis_lock_angular_z";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CollisionObject3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'move_and_collide' method.
        /// </summary>
        public static readonly StringName MoveAndCollide = "move_and_collide";
        /// <summary>
        /// Cached name for the 'test_move' method.
        /// </summary>
        public static readonly StringName TestMove = "test_move";
        /// <summary>
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'set_axis_lock' method.
        /// </summary>
        public static readonly StringName SetAxisLock = "set_axis_lock";
        /// <summary>
        /// Cached name for the 'get_axis_lock' method.
        /// </summary>
        public static readonly StringName GetAxisLock = "get_axis_lock";
        /// <summary>
        /// Cached name for the 'get_collision_exceptions' method.
        /// </summary>
        public static readonly StringName GetCollisionExceptions = "get_collision_exceptions";
        /// <summary>
        /// Cached name for the 'add_collision_exception_with' method.
        /// </summary>
        public static readonly StringName AddCollisionExceptionWith = "add_collision_exception_with";
        /// <summary>
        /// Cached name for the 'remove_collision_exception_with' method.
        /// </summary>
        public static readonly StringName RemoveCollisionExceptionWith = "remove_collision_exception_with";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CollisionObject3D.SignalName
    {
    }
}

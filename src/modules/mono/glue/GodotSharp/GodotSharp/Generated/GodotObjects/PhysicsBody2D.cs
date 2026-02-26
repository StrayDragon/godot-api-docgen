namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.PhysicsBody2D"/> is an abstract base class for 2D game objects affected by physics. All 2D physics bodies inherit from it.</para>
/// </summary>
public partial class PhysicsBody2D : CollisionObject2D
{
    private static readonly System.Type CachedType = typeof(PhysicsBody2D);

    private static readonly StringName NativeName = "PhysicsBody2D";

    internal PhysicsBody2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsBody2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsBody2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveAndCollide, 3681923724ul);

    /// <summary>
    /// <para>Moves the body along the vector <paramref name="motion"/>. In order to be frame rate independent in <see cref="Godot.Node._PhysicsProcess(double)"/> or <see cref="Godot.Node._Process(double)"/>, <paramref name="motion"/> should be computed using <c>delta</c>.</para>
    /// <para>Returns a <see cref="Godot.KinematicCollision2D"/>, which contains information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para>If <paramref name="testOnly"/> is <see langword="true"/>, the body does not move but the would-be collision information is given.</para>
    /// <para><paramref name="safeMargin"/> is the extra margin used for collision recovery (see <see cref="Godot.CharacterBody2D.SafeMargin"/> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision"/> is <see langword="true"/>, any depenetration from the recovery phase is also reported as a collision; this is used e.g. by <see cref="Godot.CharacterBody2D"/> for improving floor detection during floor snapping.</para>
    /// </summary>
    public unsafe KinematicCollision2D MoveAndCollide(Vector2 motion, bool testOnly = false, float safeMargin = 0.08f, bool recoveryAsCollision = false)
    {
        return (KinematicCollision2D)NativeCalls.godot_icall_4_978(MethodBind0, GodotObject.GetPtr(this), &motion, testOnly.ToGodotBool(), safeMargin, recoveryAsCollision.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TestMove, 3324464701ul);

    /// <summary>
    /// <para>Checks for collisions without moving the body. In order to be frame rate independent in <see cref="Godot.Node._PhysicsProcess(double)"/> or <see cref="Godot.Node._Process(double)"/>, <paramref name="motion"/> should be computed using <c>delta</c>.</para>
    /// <para>Virtually sets the node's position, scale and rotation to that of the given <see cref="Godot.Transform2D"/>, then tries to move the body along the vector <paramref name="motion"/>. Returns <see langword="true"/> if a collision would stop the body from moving along the whole path.</para>
    /// <para><paramref name="collision"/> is an optional object of type <see cref="Godot.KinematicCollision2D"/>, which contains additional information about the collision when stopped, or when touching another body along the motion.</para>
    /// <para><paramref name="safeMargin"/> is the extra margin used for collision recovery (see <see cref="Godot.CharacterBody2D.SafeMargin"/> for more details).</para>
    /// <para>If <paramref name="recoveryAsCollision"/> is <see langword="true"/>, any depenetration from the recovery phase is also reported as a collision; this is useful for checking whether the body would <i>touch</i> any other bodies.</para>
    /// </summary>
    public unsafe bool TestMove(Transform2D from, Vector2 motion, KinematicCollision2D collision = default, float safeMargin = 0.08f, bool recoveryAsCollision = false)
    {
        return NativeCalls.godot_icall_5_979(MethodBind1, GodotObject.GetPtr(this), &from, &motion, GodotObject.GetPtr(collision), safeMargin, recoveryAsCollision.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 3341600327ul);

    /// <summary>
    /// <para>Returns the gravity vector computed from all sources that can affect the body, including all gravity overrides from <see cref="Godot.Area2D"/> nodes and the global world gravity.</para>
    /// </summary>
    public Vector2 GetGravity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionExceptions, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    public Godot.Collections.Array<PhysicsBody2D> GetCollisionExceptions()
    {
        return new Godot.Collections.Array<PhysicsBody2D>(NativeCalls.godot_icall_0_120(MethodBind3, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCollisionExceptionWith, 1078189570ul);

    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void AddCollisionExceptionWith(Node body)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(body));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCollisionExceptionWith, 1078189570ul);

    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void RemoveCollisionExceptionWith(Node body)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(body));
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
    public new class PropertyName : CollisionObject2D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CollisionObject2D.MethodName
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
    public new class SignalName : CollisionObject2D.SignalName
    {
    }
}

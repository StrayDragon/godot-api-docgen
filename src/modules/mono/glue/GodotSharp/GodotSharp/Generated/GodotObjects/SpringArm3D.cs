namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.SpringArm3D"/> casts a ray or a shape along its Z axis and moves all its direct children to the collision point, with an optional margin. This is useful for 3rd person cameras that move closer to the player when inside a tight space (you may need to exclude the player's collider from the <see cref="Godot.SpringArm3D"/>'s collision check).</para>
/// </summary>
public partial class SpringArm3D : Node3D
{
    /// <summary>
    /// <para>The layers against which the collision check will be done. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask
    {
        get
        {
            return GetCollisionMask();
        }
        set
        {
            SetCollisionMask(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Shape3D"/> to use for the SpringArm3D.</para>
    /// <para>When the shape is set, the SpringArm3D will cast the <see cref="Godot.Shape3D"/> on its z axis instead of performing a ray cast.</para>
    /// </summary>
    public Shape3D Shape
    {
        get
        {
            return GetShape();
        }
        set
        {
            SetShape(value);
        }
    }

    /// <summary>
    /// <para>The maximum extent of the SpringArm3D. This is used as a length for both the ray and the shape cast used internally to calculate the desired position of the SpringArm3D's child nodes.</para>
    /// <para>To know more about how to perform a shape cast or a ray cast, please consult the <see cref="Godot.PhysicsDirectSpaceState3D"/> documentation.</para>
    /// </summary>
    public float SpringLength
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
    /// <para>When the collision check is made, a candidate length for the SpringArm3D is given.</para>
    /// <para>The margin is then subtracted to this length and the translation is applied to the child objects of the SpringArm3D.</para>
    /// <para>This margin is useful for when the SpringArm3D has a <see cref="Godot.Camera3D"/> as a child node: without the margin, the <see cref="Godot.Camera3D"/> would be placed on the exact point of collision, while with the margin the <see cref="Godot.Camera3D"/> would be placed close to the point of collision.</para>
    /// </summary>
    public float Margin
    {
        get
        {
            return GetMargin();
        }
        set
        {
            SetMargin(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SpringArm3D);

    private static readonly StringName NativeName = "SpringArm3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SpringArm3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpringArm3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpringArm3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHitLength, 191475506ul);

    /// <summary>
    /// <para>Returns the spring arm's current length.</para>
    /// </summary>
    public float GetHitLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind1, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShape, 1549710052ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShape(Shape3D shape)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 3214262478ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shape3D GetShape()
    {
        return (Shape3D)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddExcludedObject, 2722037293ul);

    /// <summary>
    /// <para>Adds the <see cref="Godot.PhysicsBody3D"/> object with the given <see cref="Godot.Rid"/> to the list of <see cref="Godot.PhysicsBody3D"/> objects excluded from the collision check.</para>
    /// </summary>
    public void AddExcludedObject(Rid rID)
    {
        NativeCalls.godot_icall_1_286(MethodBind5, GodotObject.GetPtr(this), rID);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveExcludedObject, 3521089500ul);

    /// <summary>
    /// <para>Removes the given <see cref="Godot.Rid"/> from the list of <see cref="Godot.PhysicsBody3D"/> objects excluded from the collision check.</para>
    /// </summary>
    public bool RemoveExcludedObject(Rid rID)
    {
        return NativeCalls.godot_icall_1_421(MethodBind6, GodotObject.GetPtr(this), rID).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearExcludedObjects, 3218959716ul);

    /// <summary>
    /// <para>Clears the list of <see cref="Godot.PhysicsBody3D"/> objects excluded from the collision check.</para>
    /// </summary>
    public void ClearExcludedObjects()
    {
        NativeCalls.godot_icall_0_3(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind8, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargin, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'shape' property.
        /// </summary>
        public static readonly StringName Shape = "shape";
        /// <summary>
        /// Cached name for the 'spring_length' property.
        /// </summary>
        public static readonly StringName SpringLength = "spring_length";
        /// <summary>
        /// Cached name for the 'margin' property.
        /// </summary>
        public static readonly StringName Margin = "margin";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_hit_length' method.
        /// </summary>
        public static readonly StringName GetHitLength = "get_hit_length";
        /// <summary>
        /// Cached name for the 'set_length' method.
        /// </summary>
        public static readonly StringName SetLength = "set_length";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'set_shape' method.
        /// </summary>
        public static readonly StringName SetShape = "set_shape";
        /// <summary>
        /// Cached name for the 'get_shape' method.
        /// </summary>
        public static readonly StringName GetShape = "get_shape";
        /// <summary>
        /// Cached name for the 'add_excluded_object' method.
        /// </summary>
        public static readonly StringName AddExcludedObject = "add_excluded_object";
        /// <summary>
        /// Cached name for the 'remove_excluded_object' method.
        /// </summary>
        public static readonly StringName RemoveExcludedObject = "remove_excluded_object";
        /// <summary>
        /// Cached name for the 'clear_excluded_objects' method.
        /// </summary>
        public static readonly StringName ClearExcludedObjects = "clear_excluded_objects";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_margin' method.
        /// </summary>
        public static readonly StringName SetMargin = "set_margin";
        /// <summary>
        /// Cached name for the 'get_margin' method.
        /// </summary>
        public static readonly StringName GetMargin = "get_margin";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}

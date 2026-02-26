namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node that provides a <see cref="Godot.Shape2D"/> to a <see cref="Godot.CollisionObject2D"/> parent and allows it to be edited. This can give a detection shape to an <see cref="Godot.Area2D"/> or turn a <see cref="Godot.PhysicsBody2D"/> into a solid object.</para>
/// </summary>
public partial class CollisionShape2D : Node2D
{
    /// <summary>
    /// <para>The actual shape owned by this collision shape.</para>
    /// </summary>
    public Shape2D Shape
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
    /// <para>A disabled collision shape has no effect in the world. This property should be changed with <see cref="Godot.GodotObject.SetDeferred(StringName, Variant)"/>.</para>
    /// </summary>
    public bool Disabled
    {
        get
        {
            return IsDisabled();
        }
        set
        {
            SetDisabled(value);
        }
    }

    /// <summary>
    /// <para>Sets whether this collision shape should only detect collision on one side (top or bottom).</para>
    /// <para><b>Note:</b> This property has no effect if this <see cref="Godot.CollisionShape2D"/> is a child of an <see cref="Godot.Area2D"/> node.</para>
    /// </summary>
    public bool OneWayCollision
    {
        get
        {
            return IsOneWayCollisionEnabled();
        }
        set
        {
            SetOneWayCollision(value);
        }
    }

    /// <summary>
    /// <para>The margin used for one-way collision (in pixels). Higher values will make the shape thicker, and work better for colliders that enter the shape at a high velocity.</para>
    /// </summary>
    public float OneWayCollisionMargin
    {
        get
        {
            return GetOneWayCollisionMargin();
        }
        set
        {
            SetOneWayCollisionMargin(value);
        }
    }

    /// <summary>
    /// <para>The collision shape color that is displayed in the editor, or in the running project if <b>Debug &gt; Visible Collision Shapes</b> is checked at the top of the editor.</para>
    /// <para><b>Note:</b> The default value is <c>ProjectSettings.debug/shapes/collision/shape_color</c>. The <c>Color(0, 0, 0, 0)</c> value documented here is a placeholder, and not the actual default debug color.</para>
    /// </summary>
    public Color DebugColor
    {
        get
        {
            return GetDebugColor();
        }
        set
        {
            SetDebugColor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CollisionShape2D);

    private static readonly StringName NativeName = "CollisionShape2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CollisionShape2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionShape2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionShape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShape, 771364740ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShape(Shape2D shape)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 522005891ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shape2D GetShape()
    {
        return (Shape2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisabled(bool disabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneWayCollision, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneWayCollision(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOneWayCollisionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOneWayCollisionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneWayCollisionMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneWayCollisionMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOneWayCollisionMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOneWayCollisionMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDebugColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetDebugColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'shape' property.
        /// </summary>
        public static readonly StringName Shape = "shape";
        /// <summary>
        /// Cached name for the 'disabled' property.
        /// </summary>
        public static readonly StringName Disabled = "disabled";
        /// <summary>
        /// Cached name for the 'one_way_collision' property.
        /// </summary>
        public static readonly StringName OneWayCollision = "one_way_collision";
        /// <summary>
        /// Cached name for the 'one_way_collision_margin' property.
        /// </summary>
        public static readonly StringName OneWayCollisionMargin = "one_way_collision_margin";
        /// <summary>
        /// Cached name for the 'debug_color' property.
        /// </summary>
        public static readonly StringName DebugColor = "debug_color";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_shape' method.
        /// </summary>
        public static readonly StringName SetShape = "set_shape";
        /// <summary>
        /// Cached name for the 'get_shape' method.
        /// </summary>
        public static readonly StringName GetShape = "get_shape";
        /// <summary>
        /// Cached name for the 'set_disabled' method.
        /// </summary>
        public static readonly StringName SetDisabled = "set_disabled";
        /// <summary>
        /// Cached name for the 'is_disabled' method.
        /// </summary>
        public static readonly StringName IsDisabled = "is_disabled";
        /// <summary>
        /// Cached name for the 'set_one_way_collision' method.
        /// </summary>
        public static readonly StringName SetOneWayCollision = "set_one_way_collision";
        /// <summary>
        /// Cached name for the 'is_one_way_collision_enabled' method.
        /// </summary>
        public static readonly StringName IsOneWayCollisionEnabled = "is_one_way_collision_enabled";
        /// <summary>
        /// Cached name for the 'set_one_way_collision_margin' method.
        /// </summary>
        public static readonly StringName SetOneWayCollisionMargin = "set_one_way_collision_margin";
        /// <summary>
        /// Cached name for the 'get_one_way_collision_margin' method.
        /// </summary>
        public static readonly StringName GetOneWayCollisionMargin = "get_one_way_collision_margin";
        /// <summary>
        /// Cached name for the 'set_debug_color' method.
        /// </summary>
        public static readonly StringName SetDebugColor = "set_debug_color";
        /// <summary>
        /// Cached name for the 'get_debug_color' method.
        /// </summary>
        public static readonly StringName GetDebugColor = "get_debug_color";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}

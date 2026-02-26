namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node that provides a <see cref="Godot.Shape3D"/> to a <see cref="Godot.CollisionObject3D"/> parent and allows it to be edited. This can give a detection shape to an <see cref="Godot.Area3D"/> or turn a <see cref="Godot.PhysicsBody3D"/> into a solid object.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="Godot.CollisionShape3D"/> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its <see cref="Godot.CollisionShape3D.Shape"/> resource instead.</para>
/// </summary>
public partial class CollisionShape3D : Node3D
{
    /// <summary>
    /// <para>The actual shape owned by this collision shape.</para>
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

    /// <summary>
    /// <para>If <see langword="true"/>, when the shape is displayed, it will show a solid fill color in addition to its wireframe.</para>
    /// </summary>
    public bool DebugFill
    {
        get
        {
            return GetEnableDebugFill();
        }
        set
        {
            SetEnableDebugFill(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CollisionShape3D);

    private static readonly StringName NativeName = "CollisionShape3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CollisionShape3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionShape3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionShape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResourceChanged, 968641751ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("Use 'Godot.Resource.Changed' instead.")]
    public void ResourceChanged(Resource resource)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(resource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShape, 1549710052ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShape(Shape3D shape)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 3214262478ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shape3D GetShape()
    {
        return (Shape3D)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeConvexFromSiblings, 3218959716ul);

    /// <summary>
    /// <para>Sets the collision shape's shape to the addition of all its convexed <see cref="Godot.MeshInstance3D"/> siblings geometry.</para>
    /// </summary>
    public void MakeConvexFromSiblings()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDebugColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind6, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetDebugColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDebugFill, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDebugFill(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableDebugFill, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableDebugFill()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'shape' property.
        /// </summary>
        public static readonly StringName Shape = "shape";
        /// <summary>
        /// Cached name for the 'disabled' property.
        /// </summary>
        public static readonly StringName Disabled = "disabled";
        /// <summary>
        /// Cached name for the 'debug_color' property.
        /// </summary>
        public static readonly StringName DebugColor = "debug_color";
        /// <summary>
        /// Cached name for the 'debug_fill' property.
        /// </summary>
        public static readonly StringName DebugFill = "debug_fill";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'resource_changed' method.
        /// </summary>
        public static readonly StringName ResourceChanged = "resource_changed";
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
        /// Cached name for the 'make_convex_from_siblings' method.
        /// </summary>
        public static readonly StringName MakeConvexFromSiblings = "make_convex_from_siblings";
        /// <summary>
        /// Cached name for the 'set_debug_color' method.
        /// </summary>
        public static readonly StringName SetDebugColor = "set_debug_color";
        /// <summary>
        /// Cached name for the 'get_debug_color' method.
        /// </summary>
        public static readonly StringName GetDebugColor = "get_debug_color";
        /// <summary>
        /// Cached name for the 'set_enable_debug_fill' method.
        /// </summary>
        public static readonly StringName SetEnableDebugFill = "set_enable_debug_fill";
        /// <summary>
        /// Cached name for the 'get_enable_debug_fill' method.
        /// </summary>
        public static readonly StringName GetEnableDebugFill = "get_enable_debug_fill";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}

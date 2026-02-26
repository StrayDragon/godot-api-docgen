namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for all 2D shapes, intended for use in physics.</para>
/// <para><b>Performance:</b> Primitive shapes, especially <see cref="Godot.CircleShape2D"/>, are fast to check collisions against. <see cref="Godot.ConvexPolygonShape2D"/> is slower, and <see cref="Godot.ConcavePolygonShape2D"/> is the slowest.</para>
/// </summary>
public partial class Shape2D : Resource
{
    /// <summary>
    /// <para>The shape's custom solver bias. Defines how much bodies react to enforce contact separation when this shape is involved.</para>
    /// <para>When set to <c>0</c>, the default value from <c>ProjectSettings.physics/2d/solver/default_contact_bias</c> is used.</para>
    /// </summary>
    public float CustomSolverBias
    {
        get
        {
            return GetCustomSolverBias();
        }
        set
        {
            SetCustomSolverBias(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Shape2D);

    private static readonly StringName NativeName = "Shape2D";

    internal Shape2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shape2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomSolverBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomSolverBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomSolverBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCustomSolverBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Collide, 3709843132ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this shape is colliding with another.</para>
    /// <para>This method needs the transformation matrix for this shape (<paramref name="localXform"/>), the shape to check collisions with (<paramref name="withShape"/>), and the transformation matrix of that shape (<paramref name="shapeXform"/>).</para>
    /// </summary>
    public unsafe bool Collide(Transform2D localXform, Shape2D withShape, Transform2D shapeXform)
    {
        return NativeCalls.godot_icall_3_1264(MethodBind2, GodotObject.GetPtr(this), &localXform, GodotObject.GetPtr(withShape), &shapeXform).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CollideWithMotion, 2869556801ul);

    /// <summary>
    /// <para>Returns whether this shape would collide with another, if a given movement was applied.</para>
    /// <para>This method needs the transformation matrix for this shape (<paramref name="localXform"/>), the movement to test on this shape (<paramref name="localMotion"/>), the shape to check collisions with (<paramref name="withShape"/>), the transformation matrix of that shape (<paramref name="shapeXform"/>), and the movement to test onto the other object (<paramref name="shapeMotion"/>).</para>
    /// </summary>
    public unsafe bool CollideWithMotion(Transform2D localXform, Vector2 localMotion, Shape2D withShape, Transform2D shapeXform, Vector2 shapeMotion)
    {
        return NativeCalls.godot_icall_5_1265(MethodBind3, GodotObject.GetPtr(this), &localXform, &localMotion, GodotObject.GetPtr(withShape), &shapeXform, &shapeMotion).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CollideAndGetContacts, 3056932662ul);

    /// <summary>
    /// <para>Returns a list of contact point pairs where this shape touches another.</para>
    /// <para>If there are no collisions, the returned list is empty. Otherwise, the returned list contains contact points arranged in pairs, with entries alternating between points on the boundary of this shape and points on the boundary of <paramref name="withShape"/>.</para>
    /// <para>A collision pair A, B can be used to calculate the collision normal with <c>(B - A).normalized()</c>, and the collision depth with <c>(B - A).length()</c>. This information is typically used to separate shapes, particularly in collision solvers.</para>
    /// <para>This method needs the transformation matrix for this shape (<paramref name="localXform"/>), the shape to check collisions with (<paramref name="withShape"/>), and the transformation matrix of that shape (<paramref name="shapeXform"/>).</para>
    /// </summary>
    public unsafe Vector2[] CollideAndGetContacts(Transform2D localXform, Shape2D withShape, Transform2D shapeXform)
    {
        return NativeCalls.godot_icall_3_1266(MethodBind4, GodotObject.GetPtr(this), &localXform, GodotObject.GetPtr(withShape), &shapeXform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CollideWithMotionAndGetContacts, 3620351573ul);

    /// <summary>
    /// <para>Returns a list of contact point pairs where this shape would touch another, if a given movement was applied.</para>
    /// <para>If there would be no collisions, the returned list is empty. Otherwise, the returned list contains contact points arranged in pairs, with entries alternating between points on the boundary of this shape and points on the boundary of <paramref name="withShape"/>.</para>
    /// <para>A collision pair A, B can be used to calculate the collision normal with <c>(B - A).normalized()</c>, and the collision depth with <c>(B - A).length()</c>. This information is typically used to separate shapes, particularly in collision solvers.</para>
    /// <para>This method needs the transformation matrix for this shape (<paramref name="localXform"/>), the movement to test on this shape (<paramref name="localMotion"/>), the shape to check collisions with (<paramref name="withShape"/>), the transformation matrix of that shape (<paramref name="shapeXform"/>), and the movement to test onto the other object (<paramref name="shapeMotion"/>).</para>
    /// </summary>
    public unsafe Vector2[] CollideWithMotionAndGetContacts(Transform2D localXform, Vector2 localMotion, Shape2D withShape, Transform2D shapeXform, Vector2 shapeMotion)
    {
        return NativeCalls.godot_icall_5_1267(MethodBind5, GodotObject.GetPtr(this), &localXform, &localMotion, GodotObject.GetPtr(withShape), &shapeXform, &shapeMotion);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Draw, 2948539648ul);

    /// <summary>
    /// <para>Draws a solid shape onto a <see cref="Godot.CanvasItem"/> with the <see cref="Godot.RenderingServer"/> API filled with the specified <paramref name="color"/>. The exact drawing method is specific for each shape and cannot be configured.</para>
    /// </summary>
    public unsafe void Draw(Rid canvasItem, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind6, GodotObject.GetPtr(this), canvasItem, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRect, 1639390495ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Rect2"/> representing the shapes boundary.</para>
    /// </summary>
    public Rect2 GetRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'custom_solver_bias' property.
        /// </summary>
        public static readonly StringName CustomSolverBias = "custom_solver_bias";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_custom_solver_bias' method.
        /// </summary>
        public static readonly StringName SetCustomSolverBias = "set_custom_solver_bias";
        /// <summary>
        /// Cached name for the 'get_custom_solver_bias' method.
        /// </summary>
        public static readonly StringName GetCustomSolverBias = "get_custom_solver_bias";
        /// <summary>
        /// Cached name for the 'collide' method.
        /// </summary>
        public static readonly StringName Collide = "collide";
        /// <summary>
        /// Cached name for the 'collide_with_motion' method.
        /// </summary>
        public static readonly StringName CollideWithMotion = "collide_with_motion";
        /// <summary>
        /// Cached name for the 'collide_and_get_contacts' method.
        /// </summary>
        public static readonly StringName CollideAndGetContacts = "collide_and_get_contacts";
        /// <summary>
        /// Cached name for the 'collide_with_motion_and_get_contacts' method.
        /// </summary>
        public static readonly StringName CollideWithMotionAndGetContacts = "collide_with_motion_and_get_contacts";
        /// <summary>
        /// Cached name for the 'draw' method.
        /// </summary>
        public static readonly StringName Draw = "draw";
        /// <summary>
        /// Cached name for the 'get_rect' method.
        /// </summary>
        public static readonly StringName GetRect = "get_rect";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

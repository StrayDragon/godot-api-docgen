namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D polyline shape, intended for use in physics. Used internally in <see cref="Godot.CollisionPolygon2D"/> when it's in <see cref="Godot.CollisionPolygon2D.BuildModeEnum.Segments"/> mode.</para>
/// <para>Being just a collection of interconnected line segments, <see cref="Godot.ConcavePolygonShape2D"/> is the most freely configurable single 2D shape. It can be used to form polygons of any nature, or even shapes that don't enclose an area. However, <see cref="Godot.ConcavePolygonShape2D"/> is <i>hollow</i> even if the interconnected line segments do enclose an area, which often makes it unsuitable for physics or detection.</para>
/// <para><b>Note:</b> When used for collision, <see cref="Godot.ConcavePolygonShape2D"/> is intended to work with static <see cref="Godot.CollisionShape2D"/> nodes like <see cref="Godot.StaticBody2D"/> and will likely not behave well for <see cref="Godot.CharacterBody2D"/>s or <see cref="Godot.RigidBody2D"/>s in a mode other than Static.</para>
/// <para><b>Warning:</b> Physics bodies that are small have a chance to clip through this shape when moving fast. This happens because on one frame, the physics body may be on the "outside" of the shape, and on the next frame it may be "inside" it. <see cref="Godot.ConcavePolygonShape2D"/> is hollow, so it won't detect a collision.</para>
/// <para><b>Performance:</b> Due to its complexity, <see cref="Godot.ConcavePolygonShape2D"/> is the slowest 2D collision shape to check collisions against. Its use should generally be limited to level geometry. If the polyline is closed, <see cref="Godot.CollisionPolygon2D"/>'s <see cref="Godot.CollisionPolygon2D.BuildModeEnum.Solids"/> mode can be used, which decomposes the polygon into convex ones; see <see cref="Godot.ConvexPolygonShape2D"/>'s documentation for instructions.</para>
/// </summary>
public partial class ConcavePolygonShape2D : Shape2D
{
    /// <summary>
    /// <para>The array of points that make up the <see cref="Godot.ConcavePolygonShape2D"/>'s line segments. The array (of length divisible by two) is naturally divided into pairs (one pair for each segment); each pair consists of the starting point of a segment and the endpoint of a segment.</para>
    /// </summary>
    public Vector2[] Segments
    {
        get
        {
            return GetSegments();
        }
        set
        {
            SetSegments(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ConcavePolygonShape2D);

    private static readonly StringName NativeName = "ConcavePolygonShape2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConcavePolygonShape2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConcavePolygonShape2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConcavePolygonShape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSegments, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSegments(Vector2[] segments)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), segments);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSegments(ReadOnlySpan<Vector2> segments)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), segments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSegments, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetSegments()
    {
        return NativeCalls.godot_icall_0_225(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Shape2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'segments' property.
        /// </summary>
        public static readonly StringName Segments = "segments";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_segments' method.
        /// </summary>
        public static readonly StringName SetSegments = "set_segments";
        /// <summary>
        /// Cached name for the 'get_segments' method.
        /// </summary>
        public static readonly StringName GetSegments = "get_segments";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape2D.SignalName
    {
    }
}

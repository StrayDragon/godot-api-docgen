namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D world boundary shape, intended for use in physics. <see cref="Godot.WorldBoundaryShape2D"/> works like an infinite straight line that forces all physics bodies to stay above it. The line's normal determines which direction is considered as "above" and in the editor, the smaller line over it represents this direction. It can for example be used for endless flat floors.</para>
/// </summary>
public partial class WorldBoundaryShape2D : Shape2D
{
    /// <summary>
    /// <para>The line's normal, typically a unit vector. Its direction indicates the non-colliding half-plane. Can be of any length but zero. Defaults to <c>Vector2.UP</c>.</para>
    /// </summary>
    public Vector2 Normal
    {
        get
        {
            return GetNormal();
        }
        set
        {
            SetNormal(value);
        }
    }

    /// <summary>
    /// <para>The distance from the origin to the line, expressed in terms of <see cref="Godot.WorldBoundaryShape2D.Normal"/> (according to its direction and magnitude). Actual absolute distance from the origin to the line can be calculated as <c>abs(distance) / normal.length()</c>.</para>
    /// <para>In the scalar equation of the line <c>ax + by = d</c>, this is <c>d</c>, while the <c>(a, b)</c> coordinates are represented by the <see cref="Godot.WorldBoundaryShape2D.Normal"/> property.</para>
    /// </summary>
    public float Distance
    {
        get
        {
            return GetDistance();
        }
        set
        {
            SetDistance(value);
        }
    }

    private static readonly System.Type CachedType = typeof(WorldBoundaryShape2D);

    private static readonly StringName NativeName = "WorldBoundaryShape2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WorldBoundaryShape2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WorldBoundaryShape2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WorldBoundaryShape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormal, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetNormal(Vector2 normal)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &normal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormal, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetNormal()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDistance()
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
    public new class PropertyName : Shape2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'normal' property.
        /// </summary>
        public static readonly StringName Normal = "normal";
        /// <summary>
        /// Cached name for the 'distance' property.
        /// </summary>
        public static readonly StringName Distance = "distance";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_normal' method.
        /// </summary>
        public static readonly StringName SetNormal = "set_normal";
        /// <summary>
        /// Cached name for the 'get_normal' method.
        /// </summary>
        public static readonly StringName GetNormal = "get_normal";
        /// <summary>
        /// Cached name for the 'set_distance' method.
        /// </summary>
        public static readonly StringName SetDistance = "set_distance";
        /// <summary>
        /// Cached name for the 'get_distance' method.
        /// </summary>
        public static readonly StringName GetDistance = "get_distance";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape2D.SignalName
    {
    }
}

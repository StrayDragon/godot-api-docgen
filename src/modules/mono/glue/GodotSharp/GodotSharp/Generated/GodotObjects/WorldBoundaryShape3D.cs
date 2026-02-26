namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 3D world boundary shape, intended for use in physics. <see cref="Godot.WorldBoundaryShape3D"/> works like an infinite plane that forces all physics bodies to stay above it. The <see cref="Godot.WorldBoundaryShape3D.Plane"/>'s normal determines which direction is considered as "above" and in the editor, the line over the plane represents this direction. It can for example be used for endless flat floors.</para>
/// <para><b>Note:</b> When the physics engine is set to <b>Jolt Physics</b> in the project settings (<c>ProjectSettings.physics/3d/physics_engine</c>), <see cref="Godot.WorldBoundaryShape3D"/> has a finite size (centered at the shape's origin). It can be adjusted by changing <c>ProjectSettings.physics/jolt_physics_3d/limits/world_boundary_shape_size</c>.</para>
/// </summary>
public partial class WorldBoundaryShape3D : Shape3D
{
    /// <summary>
    /// <para>The <see cref="Godot.Plane"/> used by the <see cref="Godot.WorldBoundaryShape3D"/> for collision.</para>
    /// </summary>
    public Plane Plane
    {
        get
        {
            return GetPlane();
        }
        set
        {
            SetPlane(value);
        }
    }

    private static readonly System.Type CachedType = typeof(WorldBoundaryShape3D);

    private static readonly StringName NativeName = "WorldBoundaryShape3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WorldBoundaryShape3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WorldBoundaryShape3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WorldBoundaryShape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlane, 3505987427ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPlane(Plane plane)
    {
        NativeCalls.godot_icall_1_741(MethodBind0, GodotObject.GetPtr(this), &plane);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlane, 2753500971ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Plane GetPlane()
    {
        return NativeCalls.godot_icall_0_1508(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Shape3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'plane' property.
        /// </summary>
        public static readonly StringName Plane = "plane";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_plane' method.
        /// </summary>
        public static readonly StringName SetPlane = "set_plane";
        /// <summary>
        /// Cached name for the 'get_plane' method.
        /// </summary>
        public static readonly StringName GetPlane = "get_plane";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape3D.SignalName
    {
    }
}

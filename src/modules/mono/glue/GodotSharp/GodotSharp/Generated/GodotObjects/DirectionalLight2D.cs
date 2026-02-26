namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A directional light is a type of <see cref="Godot.Light2D"/> node that models an infinite number of parallel rays covering the entire scene. It is used for lights with strong intensity that are located far away from the scene (for example: to model sunlight or moonlight).</para>
/// <para>Light is emitted in the +Y direction of the node's global basis. For an unrotated light, this means that the light is emitted downwards. The position of the node is ignored; only the basis is used to determine light direction.</para>
/// <para><b>Note:</b> <see cref="Godot.DirectionalLight2D"/> does not support light cull masks (but it supports shadow cull masks). It will always light up 2D nodes, regardless of the 2D node's <see cref="Godot.CanvasItem.LightMask"/>.</para>
/// </summary>
public partial class DirectionalLight2D : Light2D
{
    /// <summary>
    /// <para>The height of the light. Used with 2D normal mapping. Ranges from 0 (parallel to the plane) to 1 (perpendicular to the plane).</para>
    /// </summary>
    public float Height
    {
        get
        {
            return GetHeight();
        }
        set
        {
            SetHeight(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance from the camera center objects can be before their shadows are culled (in pixels). Decreasing this value can prevent objects located outside the camera from casting shadows (while also improving performance). <see cref="Godot.Camera2D.Zoom"/> is not taken into account by <see cref="Godot.DirectionalLight2D.MaxDistance"/>, which means that at higher zoom values, shadows will appear to fade out sooner when zooming onto a given point.</para>
    /// </summary>
    public float MaxDistance
    {
        get
        {
            return GetMaxDistance();
        }
        set
        {
            SetMaxDistance(value);
        }
    }

    private static readonly System.Type CachedType = typeof(DirectionalLight2D);

    private static readonly StringName NativeName = "DirectionalLight2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public DirectionalLight2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal DirectionalLight2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal DirectionalLight2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxDistance(float pixels)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), pixels);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Light2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'height' property.
        /// </summary>
        public static readonly StringName Height = "height";
        /// <summary>
        /// Cached name for the 'max_distance' property.
        /// </summary>
        public static readonly StringName MaxDistance = "max_distance";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Light2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_max_distance' method.
        /// </summary>
        public static readonly StringName SetMaxDistance = "set_max_distance";
        /// <summary>
        /// Cached name for the 'get_max_distance' method.
        /// </summary>
        public static readonly StringName GetMaxDistance = "get_max_distance";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Light2D.SignalName
    {
    }
}

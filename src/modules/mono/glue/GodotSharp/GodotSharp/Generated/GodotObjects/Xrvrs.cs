namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is used by various XR interfaces to generate VRS textures that can be used to speed up rendering.</para>
/// </summary>
[GodotClassName("XRVRS")]
public partial class Xrvrs : GodotObject
{
    /// <summary>
    /// <para>The minimum radius around the focal point where full quality is guaranteed if VRS is used as a percentage of screen size.</para>
    /// </summary>
    public float VrsMinRadius
    {
        get
        {
            return GetVrsMinRadius();
        }
        set
        {
            SetVrsMinRadius(value);
        }
    }

    /// <summary>
    /// <para>The strength used to calculate the VRS density map. The greater this value, the more noticeable VRS is.</para>
    /// </summary>
    public float VrsStrength
    {
        get
        {
            return GetVrsStrength();
        }
        set
        {
            SetVrsStrength(value);
        }
    }

    /// <summary>
    /// <para>The render region that the VRS texture will be scaled to when generated.</para>
    /// </summary>
    public Rect2I VrsRenderRegion
    {
        get
        {
            return GetVrsRenderRegion();
        }
        set
        {
            SetVrsRenderRegion(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Xrvrs);

    private static readonly StringName NativeName = "XRVRS";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Xrvrs() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Xrvrs(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Xrvrs(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsMinRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVrsMinRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsMinRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsMinRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind1, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVrsStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsRenderRegion, 410525958ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2I GetVrsRenderRegion()
    {
        return NativeCalls.godot_icall_0_33(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsRenderRegion, 1763793166ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVrsRenderRegion(Rect2I renderRegion)
    {
        NativeCalls.godot_icall_1_32(MethodBind5, GodotObject.GetPtr(this), &renderRegion);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeVrsTexture, 3647044786ul);

    /// <summary>
    /// <para>Generates the VRS texture based on a render <paramref name="targetSize"/> adjusted by our VRS tile size. For each eyes focal point passed in <paramref name="eyeFoci"/> a layer is created. Focal point should be in NDC.</para>
    /// <para>The result will be cached, requesting a VRS texture with unchanged parameters and settings will return the cached RID.</para>
    /// </summary>
    public unsafe Rid MakeVrsTexture(Vector2 targetSize, Vector2[] eyeFoci)
    {
        return NativeCalls.godot_icall_2_1516(MethodBind6, GodotObject.GetPtr(this), &targetSize, eyeFoci);
    }

    /// <summary>
    /// <para>Generates the VRS texture based on a render <paramref name="targetSize"/> adjusted by our VRS tile size. For each eyes focal point passed in <paramref name="eyeFoci"/> a layer is created. Focal point should be in NDC.</para>
    /// <para>The result will be cached, requesting a VRS texture with unchanged parameters and settings will return the cached RID.</para>
    /// </summary>
    public unsafe Rid MakeVrsTexture(Vector2 targetSize, ReadOnlySpan<Vector2> eyeFoci)
    {
        return NativeCalls.godot_icall_2_1516(MethodBind6, GodotObject.GetPtr(this), &targetSize, eyeFoci);
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
    public new class PropertyName : GodotObject.PropertyName
    {
        /// <summary>
        /// Cached name for the 'vrs_min_radius' property.
        /// </summary>
        public static readonly StringName VrsMinRadius = "vrs_min_radius";
        /// <summary>
        /// Cached name for the 'vrs_strength' property.
        /// </summary>
        public static readonly StringName VrsStrength = "vrs_strength";
        /// <summary>
        /// Cached name for the 'vrs_render_region' property.
        /// </summary>
        public static readonly StringName VrsRenderRegion = "vrs_render_region";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_vrs_min_radius' method.
        /// </summary>
        public static readonly StringName GetVrsMinRadius = "get_vrs_min_radius";
        /// <summary>
        /// Cached name for the 'set_vrs_min_radius' method.
        /// </summary>
        public static readonly StringName SetVrsMinRadius = "set_vrs_min_radius";
        /// <summary>
        /// Cached name for the 'get_vrs_strength' method.
        /// </summary>
        public static readonly StringName GetVrsStrength = "get_vrs_strength";
        /// <summary>
        /// Cached name for the 'set_vrs_strength' method.
        /// </summary>
        public static readonly StringName SetVrsStrength = "set_vrs_strength";
        /// <summary>
        /// Cached name for the 'get_vrs_render_region' method.
        /// </summary>
        public static readonly StringName GetVrsRenderRegion = "get_vrs_render_region";
        /// <summary>
        /// Cached name for the 'set_vrs_render_region' method.
        /// </summary>
        public static readonly StringName SetVrsRenderRegion = "set_vrs_render_region";
        /// <summary>
        /// Cached name for the 'make_vrs_texture' method.
        /// </summary>
        public static readonly StringName MakeVrsTexture = "make_vrs_texture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An automatically scalable <see cref="Godot.Texture2D"/> based on an SVG image. <see cref="Godot.DpiTexture"/>s are used to automatically re-rasterize icons and other texture based UI theme elements to match viewport scale and font oversampling. See also <c>ProjectSettings.display/window/stretch/mode</c> ("canvas_items" mode) and <see cref="Godot.Viewport.OversamplingOverride"/>.</para>
/// </summary>
[GodotClassName("DPITexture")]
public partial class DpiTexture : Texture2D
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public string _Source
    {
        get
        {
            return GetSource();
        }
        set
        {
            SetSource(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Texture scale. <c>1.0</c> is the original SVG size. Higher values result in a larger image.</para>
    /// </summary>
    public float BaseScale
    {
        get
        {
            return GetBaseScale();
        }
        set
        {
            SetBaseScale(value);
        }
    }

    /// <summary>
    /// <para>Overrides texture saturation.</para>
    /// </summary>
    public float Saturation
    {
        get
        {
            return GetSaturation();
        }
        set
        {
            SetSaturation(value);
        }
    }

    /// <summary>
    /// <para>If set, remaps texture colors according to <see cref="Godot.Color"/>-<see cref="Godot.Color"/> map.</para>
    /// </summary>
    public Godot.Collections.Dictionary ColorMap
    {
        get
        {
            return GetColorMap();
        }
        set
        {
            SetColorMap(value);
        }
    }

    private static readonly System.Type CachedType = typeof(DpiTexture);

    private static readonly StringName NativeName = "DPITexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public DpiTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal DpiTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal DpiTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromString, 755140520ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.DpiTexture"/> and initializes it by allocating and setting the SVG data to <paramref name="source"/>.</para>
    /// </summary>
    public static DpiTexture CreateFromString(string source, float scale = 1.0f, float saturation = 1.0f, Godot.Collections.Dictionary colorMap = null)
    {
        return (DpiTexture)NativeCalls.godot_icall_4_370(MethodBind0, source, scale, saturation, (godot_dictionary)(colorMap ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSource, 83702148ul);

    /// <summary>
    /// <para>Sets this SVG texture's source code.</para>
    /// </summary>
    public void SetSource(string source)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSource, 201670096ul);

    /// <summary>
    /// <para>Returns this SVG texture's source code.</para>
    /// </summary>
    public string GetSource()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBaseScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBaseScale(float baseScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), baseScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBaseScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSaturation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSaturation(float saturation)
    {
        NativeCalls.godot_icall_1_67(MethodBind5, GodotObject.GetPtr(this), saturation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSaturation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSaturation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorMap, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorMap(Godot.Collections.Dictionary colorMap)
    {
        NativeCalls.godot_icall_1_121(MethodBind7, GodotObject.GetPtr(this), (godot_dictionary)(colorMap ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorMap, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetColorMap()
    {
        return NativeCalls.godot_icall_0_122(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSizeOverride, 1130785943ul);

    /// <summary>
    /// <para>Resizes the texture to the specified dimensions.</para>
    /// </summary>
    public unsafe void SetSizeOverride(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind9, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaledRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the texture rasterized to match the oversampling of the currently drawn canvas item.</para>
    /// </summary>
    public Rid GetScaledRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind10, GodotObject.GetPtr(this));
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the '_source' property.
        /// </summary>
        public static readonly StringName _Source = "_source";
        /// <summary>
        /// Cached name for the 'base_scale' property.
        /// </summary>
        public static readonly StringName BaseScale = "base_scale";
        /// <summary>
        /// Cached name for the 'saturation' property.
        /// </summary>
        public static readonly StringName Saturation = "saturation";
        /// <summary>
        /// Cached name for the 'color_map' property.
        /// </summary>
        public static readonly StringName ColorMap = "color_map";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_from_string' method.
        /// </summary>
        public static readonly StringName CreateFromString = "create_from_string";
        /// <summary>
        /// Cached name for the 'set_source' method.
        /// </summary>
        public static readonly StringName SetSource = "set_source";
        /// <summary>
        /// Cached name for the 'get_source' method.
        /// </summary>
        public static readonly StringName GetSource = "get_source";
        /// <summary>
        /// Cached name for the 'set_base_scale' method.
        /// </summary>
        public static readonly StringName SetBaseScale = "set_base_scale";
        /// <summary>
        /// Cached name for the 'get_base_scale' method.
        /// </summary>
        public static readonly StringName GetBaseScale = "get_base_scale";
        /// <summary>
        /// Cached name for the 'set_saturation' method.
        /// </summary>
        public static readonly StringName SetSaturation = "set_saturation";
        /// <summary>
        /// Cached name for the 'get_saturation' method.
        /// </summary>
        public static readonly StringName GetSaturation = "get_saturation";
        /// <summary>
        /// Cached name for the 'set_color_map' method.
        /// </summary>
        public static readonly StringName SetColorMap = "set_color_map";
        /// <summary>
        /// Cached name for the 'get_color_map' method.
        /// </summary>
        public static readonly StringName GetColorMap = "get_color_map";
        /// <summary>
        /// Cached name for the 'set_size_override' method.
        /// </summary>
        public static readonly StringName SetSizeOverride = "set_size_override";
        /// <summary>
        /// Cached name for the 'get_scaled_rid' method.
        /// </summary>
        public static readonly StringName GetScaledRid = "get_scaled_rid";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}

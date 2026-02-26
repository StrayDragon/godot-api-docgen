namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Texture2D"/> resource that draws only part of its <see cref="Godot.AtlasTexture.Atlas"/> texture, as defined by the <see cref="Godot.AtlasTexture.Region"/>. An additional <see cref="Godot.AtlasTexture.Margin"/> can also be set, which is useful for small adjustments.</para>
/// <para>Multiple <see cref="Godot.AtlasTexture"/> resources can be cropped from the same <see cref="Godot.AtlasTexture.Atlas"/>. Packing many smaller textures into a singular large texture helps to optimize video memory costs and render calls.</para>
/// <para><b>Note:</b> <see cref="Godot.AtlasTexture"/> cannot be used in an <see cref="Godot.AnimatedTexture"/>, and will not tile properly in nodes such as <see cref="Godot.TextureRect"/> or <see cref="Godot.Sprite2D"/>. To tile an <see cref="Godot.AtlasTexture"/>, modify its <see cref="Godot.AtlasTexture.Region"/> instead.</para>
/// </summary>
public partial class AtlasTexture : Texture2D
{
    /// <summary>
    /// <para>The texture that contains the atlas. Can be any type inheriting from <see cref="Godot.Texture2D"/>, including another <see cref="Godot.AtlasTexture"/>.</para>
    /// </summary>
    public Texture2D Atlas
    {
        get
        {
            return GetAtlas();
        }
        set
        {
            SetAtlas(value);
        }
    }

    /// <summary>
    /// <para>The region used to draw the <see cref="Godot.AtlasTexture.Atlas"/>. If either dimension of the region's size is <c>0</c>, the value from <see cref="Godot.AtlasTexture.Atlas"/> size will be used for that axis instead.</para>
    /// <para><b>Note:</b> The image size is always an integer, so the actual region size is rounded down.</para>
    /// </summary>
    public Rect2 Region
    {
        get
        {
            return GetRegion();
        }
        set
        {
            SetRegion(value);
        }
    }

    /// <summary>
    /// <para>The margin around the <see cref="Godot.AtlasTexture.Region"/>. Useful for small adjustments. If the <c>Rect2.size</c> of this property ("w" and "h" in the editor) is set, the drawn texture is resized to fit within the margin.</para>
    /// </summary>
    public Rect2 Margin
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

    /// <summary>
    /// <para>If <see langword="true"/>, the area outside of the <see cref="Godot.AtlasTexture.Region"/> is clipped to avoid bleeding of the surrounding texture pixels.</para>
    /// </summary>
    public bool FilterClip
    {
        get
        {
            return HasFilterClip();
        }
        set
        {
            SetFilterClip(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AtlasTexture);

    private static readonly StringName NativeName = "AtlasTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AtlasTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AtlasTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AtlasTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAtlas, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAtlas(Texture2D atlas)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(atlas));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAtlas, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetAtlas()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRegion, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRegion(Rect2 region)
    {
        NativeCalls.godot_icall_1_188(MethodBind2, GodotObject.GetPtr(this), &region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegion, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetRegion()
    {
        return NativeCalls.godot_icall_0_189(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMargin, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMargin(Rect2 margin)
    {
        NativeCalls.godot_icall_1_188(MethodBind4, GodotObject.GetPtr(this), &margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargin, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetMargin()
    {
        return NativeCalls.godot_icall_0_189(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterClip, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFilterClip(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFilterClip, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasFilterClip()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'atlas' property.
        /// </summary>
        public static readonly StringName Atlas = "atlas";
        /// <summary>
        /// Cached name for the 'region' property.
        /// </summary>
        public static readonly StringName Region = "region";
        /// <summary>
        /// Cached name for the 'margin' property.
        /// </summary>
        public static readonly StringName Margin = "margin";
        /// <summary>
        /// Cached name for the 'filter_clip' property.
        /// </summary>
        public static readonly StringName FilterClip = "filter_clip";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_atlas' method.
        /// </summary>
        public static readonly StringName SetAtlas = "set_atlas";
        /// <summary>
        /// Cached name for the 'get_atlas' method.
        /// </summary>
        public static readonly StringName GetAtlas = "get_atlas";
        /// <summary>
        /// Cached name for the 'set_region' method.
        /// </summary>
        public static readonly StringName SetRegion = "set_region";
        /// <summary>
        /// Cached name for the 'get_region' method.
        /// </summary>
        public static readonly StringName GetRegion = "get_region";
        /// <summary>
        /// Cached name for the 'set_margin' method.
        /// </summary>
        public static readonly StringName SetMargin = "set_margin";
        /// <summary>
        /// Cached name for the 'get_margin' method.
        /// </summary>
        public static readonly StringName GetMargin = "get_margin";
        /// <summary>
        /// Cached name for the 'set_filter_clip' method.
        /// </summary>
        public static readonly StringName SetFilterClip = "set_filter_clip";
        /// <summary>
        /// Cached name for the 'has_filter_clip' method.
        /// </summary>
        public static readonly StringName HasFilterClip = "has_filter_clip";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Child <see cref="Godot.CanvasItem"/> nodes of a <see cref="Godot.CanvasGroup"/> are drawn as a single object. It allows to e.g. draw overlapping translucent 2D nodes without causing the overlapping sections to be more opaque than intended (set the <see cref="Godot.CanvasItem.SelfModulate"/> property on the <see cref="Godot.CanvasGroup"/> to achieve this effect).</para>
/// <para><b>Note:</b> The <see cref="Godot.CanvasGroup"/> uses a custom shader to read from the backbuffer to draw its children. Assigning a <see cref="Godot.Material"/> to the <see cref="Godot.CanvasGroup"/> overrides the built-in shader. To duplicate the behavior of the built-in shader in a custom <see cref="Godot.Shader"/>, use the following:</para>
/// <para><code>
/// shader_type canvas_item;
/// render_mode unshaded;
/// 
/// uniform sampler2D screen_texture : hint_screen_texture, repeat_disable, filter_nearest;
/// 
/// void fragment() {
/// 	vec4 c = textureLod(screen_texture, SCREEN_UV, 0.0);
/// 
/// 	if (c.a &gt; 0.0001) {
/// 		c.rgb /= c.a;
/// 	}
/// 
/// 	COLOR *= c;
/// }
/// </code></para>
/// <para><b>Note:</b> Since <see cref="Godot.CanvasGroup"/> and <see cref="Godot.CanvasItem.ClipChildren"/> both utilize the backbuffer, children of a <see cref="Godot.CanvasGroup"/> who have their <see cref="Godot.CanvasItem.ClipChildren"/> set to anything other than <see cref="Godot.CanvasItem.ClipChildrenMode.Disabled"/> will not function correctly.</para>
/// </summary>
public partial class CanvasGroup : Node2D
{
    /// <summary>
    /// <para>Sets the size of a margin used to expand the drawable rect of this <see cref="Godot.CanvasGroup"/>. The size of the <see cref="Godot.CanvasGroup"/> is determined by fitting a rect around its children then expanding that rect by <see cref="Godot.CanvasGroup.FitMargin"/>. This increases both the backbuffer area used and the area covered by the <see cref="Godot.CanvasGroup"/> both of which can reduce performance. This should be kept as small as possible and should only be expanded when an increased size is needed (e.g. for custom shader effects).</para>
    /// </summary>
    public float FitMargin
    {
        get
        {
            return GetFitMargin();
        }
        set
        {
            SetFitMargin(value);
        }
    }

    /// <summary>
    /// <para>Sets the size of the margin used to expand the clearing rect of this <see cref="Godot.CanvasGroup"/>. This expands the area of the backbuffer that will be used by the <see cref="Godot.CanvasGroup"/>. A smaller margin will reduce the area of the backbuffer used which can increase performance, however if <see cref="Godot.CanvasGroup.UseMipmaps"/> is enabled, a small margin may result in mipmap errors at the edge of the <see cref="Godot.CanvasGroup"/>. Accordingly, this should be left as small as possible, but should be increased if artifacts appear along the edges of the canvas group.</para>
    /// </summary>
    public float ClearMargin
    {
        get
        {
            return GetClearMargin();
        }
        set
        {
            SetClearMargin(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, calculates mipmaps for the backbuffer before drawing the <see cref="Godot.CanvasGroup"/> so that mipmaps can be used in a custom <see cref="Godot.ShaderMaterial"/> attached to the <see cref="Godot.CanvasGroup"/>. Generating mipmaps has a performance cost so this should not be enabled unless required.</para>
    /// </summary>
    public bool UseMipmaps
    {
        get
        {
            return IsUsingMipmaps();
        }
        set
        {
            SetUseMipmaps(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CanvasGroup);

    private static readonly StringName NativeName = "CanvasGroup";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CanvasGroup() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CanvasGroup(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CanvasGroup(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFitMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFitMargin(float fitMargin)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), fitMargin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFitMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFitMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClearMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClearMargin(float clearMargin)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), clearMargin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClearMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetClearMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseMipmaps, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseMipmaps(bool useMipmaps)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), useMipmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingMipmaps, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingMipmaps()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'fit_margin' property.
        /// </summary>
        public static readonly StringName FitMargin = "fit_margin";
        /// <summary>
        /// Cached name for the 'clear_margin' property.
        /// </summary>
        public static readonly StringName ClearMargin = "clear_margin";
        /// <summary>
        /// Cached name for the 'use_mipmaps' property.
        /// </summary>
        public static readonly StringName UseMipmaps = "use_mipmaps";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_fit_margin' method.
        /// </summary>
        public static readonly StringName SetFitMargin = "set_fit_margin";
        /// <summary>
        /// Cached name for the 'get_fit_margin' method.
        /// </summary>
        public static readonly StringName GetFitMargin = "get_fit_margin";
        /// <summary>
        /// Cached name for the 'set_clear_margin' method.
        /// </summary>
        public static readonly StringName SetClearMargin = "set_clear_margin";
        /// <summary>
        /// Cached name for the 'get_clear_margin' method.
        /// </summary>
        public static readonly StringName GetClearMargin = "get_clear_margin";
        /// <summary>
        /// Cached name for the 'set_use_mipmaps' method.
        /// </summary>
        public static readonly StringName SetUseMipmaps = "set_use_mipmaps";
        /// <summary>
        /// Cached name for the 'is_using_mipmaps' method.
        /// </summary>
        public static readonly StringName IsUsingMipmaps = "is_using_mipmaps";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}

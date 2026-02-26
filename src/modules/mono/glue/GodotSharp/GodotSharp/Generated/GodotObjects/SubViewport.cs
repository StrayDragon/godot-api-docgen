namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.SubViewport"/> Isolates a rectangular region of a scene to be displayed independently. This can be used, for example, to display UI in 3D space.</para>
/// <para><b>Note:</b> <see cref="Godot.SubViewport"/> is a <see cref="Godot.Viewport"/> that isn't a <see cref="Godot.Window"/>, i.e. it doesn't draw anything by itself. To display anything, <see cref="Godot.SubViewport"/> must have a non-zero size and be either put inside a <see cref="Godot.SubViewportContainer"/> or assigned to a <see cref="Godot.ViewportTexture"/>.</para>
/// <para><b>Note:</b> <see cref="Godot.InputEvent"/>s are not passed to a standalone <see cref="Godot.SubViewport"/> by default. To ensure <see cref="Godot.InputEvent"/> propagation, a <see cref="Godot.SubViewport"/> can be placed inside of a <see cref="Godot.SubViewportContainer"/>.</para>
/// </summary>
public partial class SubViewport : Viewport
{
    public enum ClearMode : long
    {
        /// <summary>
        /// <para>Always clear the render target before drawing.</para>
        /// </summary>
        Always = 0,
        /// <summary>
        /// <para>Never clear the render target.</para>
        /// </summary>
        Never = 1,
        /// <summary>
        /// <para>Clear the render target on the next frame, then switch to <see cref="Godot.SubViewport.ClearMode.Never"/>.</para>
        /// </summary>
        Once = 2
    }

    public enum UpdateMode : long
    {
        /// <summary>
        /// <para>Do not update the render target.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Update the render target once, then switch to <see cref="Godot.SubViewport.UpdateMode.Disabled"/>.</para>
        /// </summary>
        Once = 1,
        /// <summary>
        /// <para>Update the render target only when it is visible. This is the default value.</para>
        /// </summary>
        WhenVisible = 2,
        /// <summary>
        /// <para>Update the render target only when its parent is visible.</para>
        /// </summary>
        WhenParentVisible = 3,
        /// <summary>
        /// <para>Always update the render target.</para>
        /// </summary>
        Always = 4
    }

    /// <summary>
    /// <para>The width and height of the sub-viewport. Must be set to a value greater than or equal to 2 pixels on both dimensions. Otherwise, nothing will be displayed.</para>
    /// <para><b>Note:</b> If the parent node is a <see cref="Godot.SubViewportContainer"/> and its <see cref="Godot.SubViewportContainer.Stretch"/> is <see langword="true"/>, the viewport size cannot be changed manually.</para>
    /// </summary>
    public Vector2I Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>The 2D size override of the sub-viewport. If either the width or height is <c>0</c>, the override is disabled.</para>
    /// </summary>
    public Vector2I Size2DOverride
    {
        get
        {
            return GetSize2DOverride();
        }
        set
        {
            SetSize2DOverride(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the 2D size override affects stretch as well.</para>
    /// </summary>
    public bool Size2DOverrideStretch
    {
        get
        {
            return IsSize2DOverrideStretchEnabled();
        }
        set
        {
            SetSize2DOverrideStretch(value);
        }
    }

    /// <summary>
    /// <para>The clear mode when the sub-viewport is used as a render target.</para>
    /// <para><b>Note:</b> This property is intended for 2D usage.</para>
    /// </summary>
    public SubViewport.ClearMode RenderTargetClearMode
    {
        get
        {
            return GetClearMode();
        }
        set
        {
            SetClearMode(value);
        }
    }

    /// <summary>
    /// <para>The update mode when the sub-viewport is used as a render target.</para>
    /// </summary>
    public SubViewport.UpdateMode RenderTargetUpdateMode
    {
        get
        {
            return GetUpdateMode();
        }
        set
        {
            SetUpdateMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SubViewport);

    private static readonly StringName NativeName = "SubViewport";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SubViewport() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SubViewport(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SubViewport(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize2DOverride, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize2DOverride(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind2, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize2DOverride, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetSize2DOverride()
    {
        return NativeCalls.godot_icall_0_35(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize2DOverrideStretch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSize2DOverrideStretch(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSize2DOverrideStretchEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSize2DOverrideStretchEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpdateMode, 1295690030ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpdateMode(SubViewport.UpdateMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpdateMode, 2980171553ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SubViewport.UpdateMode GetUpdateMode()
    {
        return (SubViewport.UpdateMode)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClearMode, 2834454712ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClearMode(SubViewport.ClearMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClearMode, 331324495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SubViewport.ClearMode GetClearMode()
    {
        return (SubViewport.ClearMode)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Viewport.PropertyName
    {
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'size_2d_override' property.
        /// </summary>
        public static readonly StringName Size2DOverride = "size_2d_override";
        /// <summary>
        /// Cached name for the 'size_2d_override_stretch' property.
        /// </summary>
        public static readonly StringName Size2DOverrideStretch = "size_2d_override_stretch";
        /// <summary>
        /// Cached name for the 'render_target_clear_mode' property.
        /// </summary>
        public static readonly StringName RenderTargetClearMode = "render_target_clear_mode";
        /// <summary>
        /// Cached name for the 'render_target_update_mode' property.
        /// </summary>
        public static readonly StringName RenderTargetUpdateMode = "render_target_update_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Viewport.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_size_2d_override' method.
        /// </summary>
        public static readonly StringName SetSize2DOverride = "set_size_2d_override";
        /// <summary>
        /// Cached name for the 'get_size_2d_override' method.
        /// </summary>
        public static readonly StringName GetSize2DOverride = "get_size_2d_override";
        /// <summary>
        /// Cached name for the 'set_size_2d_override_stretch' method.
        /// </summary>
        public static readonly StringName SetSize2DOverrideStretch = "set_size_2d_override_stretch";
        /// <summary>
        /// Cached name for the 'is_size_2d_override_stretch_enabled' method.
        /// </summary>
        public static readonly StringName IsSize2DOverrideStretchEnabled = "is_size_2d_override_stretch_enabled";
        /// <summary>
        /// Cached name for the 'set_update_mode' method.
        /// </summary>
        public static readonly StringName SetUpdateMode = "set_update_mode";
        /// <summary>
        /// Cached name for the 'get_update_mode' method.
        /// </summary>
        public static readonly StringName GetUpdateMode = "get_update_mode";
        /// <summary>
        /// Cached name for the 'set_clear_mode' method.
        /// </summary>
        public static readonly StringName SetClearMode = "set_clear_mode";
        /// <summary>
        /// Cached name for the 'get_clear_mode' method.
        /// </summary>
        public static readonly StringName GetClearMode = "get_clear_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Viewport.SignalName
    {
    }
}

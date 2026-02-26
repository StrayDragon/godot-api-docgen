namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container type that arranges its child controls in a way that preserves their proportions automatically when the container is resized. Useful when a container has a dynamic size and the child nodes must adjust their sizes accordingly without losing their aspect ratios.</para>
/// </summary>
public partial class AspectRatioContainer : Container
{
    public enum StretchModeEnum : long
    {
        /// <summary>
        /// <para>The height of child controls is automatically adjusted based on the width of the container.</para>
        /// </summary>
        WidthControlsHeight = 0,
        /// <summary>
        /// <para>The width of child controls is automatically adjusted based on the height of the container.</para>
        /// </summary>
        HeightControlsWidth = 1,
        /// <summary>
        /// <para>The bounding rectangle of child controls is automatically adjusted to fit inside the container while keeping the aspect ratio.</para>
        /// </summary>
        Fit = 2,
        /// <summary>
        /// <para>The width and height of child controls is automatically adjusted to make their bounding rectangle cover the entire area of the container while keeping the aspect ratio.</para>
        /// <para>When the bounding rectangle of child controls exceed the container's size and <see cref="Godot.Control.ClipContents"/> is enabled, this allows to show only the container's area restricted by its own bounding rectangle.</para>
        /// </summary>
        Cover = 3
    }

    public enum AlignmentMode : long
    {
        /// <summary>
        /// <para>Aligns child controls with the beginning (left or top) of the container.</para>
        /// </summary>
        Begin = 0,
        /// <summary>
        /// <para>Aligns child controls with the center of the container.</para>
        /// </summary>
        Center = 1,
        /// <summary>
        /// <para>Aligns child controls with the end (right or bottom) of the container.</para>
        /// </summary>
        End = 2
    }

    /// <summary>
    /// <para>The aspect ratio to enforce on child controls. This is the width divided by the height. The ratio depends on the <see cref="Godot.AspectRatioContainer.StretchMode"/>.</para>
    /// </summary>
    public float Ratio
    {
        get
        {
            return GetRatio();
        }
        set
        {
            SetRatio(value);
        }
    }

    /// <summary>
    /// <para>The stretch mode used to align child controls.</para>
    /// </summary>
    public AspectRatioContainer.StretchModeEnum StretchMode
    {
        get
        {
            return GetStretchMode();
        }
        set
        {
            SetStretchMode(value);
        }
    }

    /// <summary>
    /// <para>Specifies the horizontal relative position of child controls.</para>
    /// </summary>
    public AspectRatioContainer.AlignmentMode AlignmentHorizontal
    {
        get
        {
            return GetAlignmentHorizontal();
        }
        set
        {
            SetAlignmentHorizontal(value);
        }
    }

    /// <summary>
    /// <para>Specifies the vertical relative position of child controls.</para>
    /// </summary>
    public AspectRatioContainer.AlignmentMode AlignmentVertical
    {
        get
        {
            return GetAlignmentVertical();
        }
        set
        {
            SetAlignmentVertical(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AspectRatioContainer);

    private static readonly StringName NativeName = "AspectRatioContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AspectRatioContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AspectRatioContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AspectRatioContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchMode, 1876743467ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchMode(AspectRatioContainer.StretchModeEnum stretchMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)stretchMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchMode, 3416449033ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AspectRatioContainer.StretchModeEnum GetStretchMode()
    {
        return (AspectRatioContainer.StretchModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlignmentHorizontal, 2147829016ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlignmentHorizontal(AspectRatioContainer.AlignmentMode alignmentHorizontal)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)alignmentHorizontal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlignmentHorizontal, 3838875429ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AspectRatioContainer.AlignmentMode GetAlignmentHorizontal()
    {
        return (AspectRatioContainer.AlignmentMode)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlignmentVertical, 2147829016ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlignmentVertical(AspectRatioContainer.AlignmentMode alignmentVertical)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)alignmentVertical);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlignmentVertical, 3838875429ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AspectRatioContainer.AlignmentMode GetAlignmentVertical()
    {
        return (AspectRatioContainer.AlignmentMode)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'ratio' property.
        /// </summary>
        public static readonly StringName Ratio = "ratio";
        /// <summary>
        /// Cached name for the 'stretch_mode' property.
        /// </summary>
        public static readonly StringName StretchMode = "stretch_mode";
        /// <summary>
        /// Cached name for the 'alignment_horizontal' property.
        /// </summary>
        public static readonly StringName AlignmentHorizontal = "alignment_horizontal";
        /// <summary>
        /// Cached name for the 'alignment_vertical' property.
        /// </summary>
        public static readonly StringName AlignmentVertical = "alignment_vertical";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_ratio' method.
        /// </summary>
        public static readonly StringName SetRatio = "set_ratio";
        /// <summary>
        /// Cached name for the 'get_ratio' method.
        /// </summary>
        public static readonly StringName GetRatio = "get_ratio";
        /// <summary>
        /// Cached name for the 'set_stretch_mode' method.
        /// </summary>
        public static readonly StringName SetStretchMode = "set_stretch_mode";
        /// <summary>
        /// Cached name for the 'get_stretch_mode' method.
        /// </summary>
        public static readonly StringName GetStretchMode = "get_stretch_mode";
        /// <summary>
        /// Cached name for the 'set_alignment_horizontal' method.
        /// </summary>
        public static readonly StringName SetAlignmentHorizontal = "set_alignment_horizontal";
        /// <summary>
        /// Cached name for the 'get_alignment_horizontal' method.
        /// </summary>
        public static readonly StringName GetAlignmentHorizontal = "get_alignment_horizontal";
        /// <summary>
        /// Cached name for the 'set_alignment_vertical' method.
        /// </summary>
        public static readonly StringName SetAlignmentVertical = "set_alignment_vertical";
        /// <summary>
        /// Cached name for the 'get_alignment_vertical' method.
        /// </summary>
        public static readonly StringName GetAlignmentVertical = "get_alignment_vertical";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
    }
}

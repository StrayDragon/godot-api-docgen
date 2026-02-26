namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.ColorPalette"/> resource is designed to store and manage a collection of colors. This resource is useful in scenarios where a predefined set of colors is required, such as for creating themes, designing user interfaces, or managing game assets. The built-in <see cref="Godot.ColorPicker"/> control can also make use of <see cref="Godot.ColorPalette"/> without additional code.</para>
/// </summary>
public partial class ColorPalette : Resource
{
    /// <summary>
    /// <para>A <see cref="Godot.Color"/>[] containing the colors in the palette.</para>
    /// </summary>
    public Color[] Colors
    {
        get
        {
            return GetColors();
        }
        set
        {
            SetColors(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ColorPalette);

    private static readonly StringName NativeName = "ColorPalette";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ColorPalette() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ColorPalette(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ColorPalette(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColors, 3546319833ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColors(Color[] colors)
    {
        NativeCalls.godot_icall_1_226(MethodBind0, GodotObject.GetPtr(this), colors);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColors(ReadOnlySpan<Color> colors)
    {
        NativeCalls.godot_icall_1_226(MethodBind0, GodotObject.GetPtr(this), colors);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColors, 1392750486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color[] GetColors()
    {
        return NativeCalls.godot_icall_0_227(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'colors' property.
        /// </summary>
        public static readonly StringName Colors = "colors";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_colors' method.
        /// </summary>
        public static readonly StringName SetColors = "set_colors";
        /// <summary>
        /// Cached name for the 'get_colors' method.
        /// </summary>
        public static readonly StringName GetColors = "get_colors";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

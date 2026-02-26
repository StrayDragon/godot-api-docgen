namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Node for back-buffering the currently-displayed screen. The region defined in the <see cref="Godot.BackBufferCopy"/> node is buffered with the content of the screen it covers, or the entire screen according to the <see cref="Godot.BackBufferCopy.CopyMode"/>. It can be accessed in shader scripts using the screen texture (i.e. a uniform sampler with <c>hint_screen_texture</c>).</para>
/// <para><b>Note:</b> Since this node inherits from <see cref="Godot.Node2D"/> (and not <see cref="Godot.Control"/>), anchors and margins won't apply to child <see cref="Godot.Control"/>-derived nodes. This can be problematic when resizing the window. To avoid this, add <see cref="Godot.Control"/>-derived nodes as <i>siblings</i> to the <see cref="Godot.BackBufferCopy"/> node instead of adding them as children.</para>
/// </summary>
public partial class BackBufferCopy : Node2D
{
    public enum CopyModeEnum : long
    {
        /// <summary>
        /// <para>Disables the buffering mode. This means the <see cref="Godot.BackBufferCopy"/> node will directly use the portion of screen it covers.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para><see cref="Godot.BackBufferCopy"/> buffers a rectangular region.</para>
        /// </summary>
        Rect = 1,
        /// <summary>
        /// <para><see cref="Godot.BackBufferCopy"/> buffers the entire screen.</para>
        /// </summary>
        Viewport = 2
    }

    /// <summary>
    /// <para>Buffer mode.</para>
    /// </summary>
    public BackBufferCopy.CopyModeEnum CopyMode
    {
        get
        {
            return GetCopyMode();
        }
        set
        {
            SetCopyMode(value);
        }
    }

    /// <summary>
    /// <para>The area covered by the <see cref="Godot.BackBufferCopy"/>. Only used if <see cref="Godot.BackBufferCopy.CopyMode"/> is <see cref="Godot.BackBufferCopy.CopyModeEnum.Rect"/>.</para>
    /// </summary>
    public Rect2 Rect
    {
        get
        {
            return GetRect();
        }
        set
        {
            SetRect(value);
        }
    }

    private static readonly System.Type CachedType = typeof(BackBufferCopy);

    private static readonly StringName NativeName = "BackBufferCopy";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BackBufferCopy() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal BackBufferCopy(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal BackBufferCopy(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRect(Rect2 rect)
    {
        NativeCalls.godot_icall_1_188(MethodBind0, GodotObject.GetPtr(this), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCopyMode, 1713538590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCopyMode(BackBufferCopy.CopyModeEnum copyMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)copyMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCopyMode, 3271169440ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BackBufferCopy.CopyModeEnum GetCopyMode()
    {
        return (BackBufferCopy.CopyModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'copy_mode' property.
        /// </summary>
        public static readonly StringName CopyMode = "copy_mode";
        /// <summary>
        /// Cached name for the 'rect' property.
        /// </summary>
        public static readonly StringName Rect = "rect";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_rect' method.
        /// </summary>
        public static readonly StringName SetRect = "set_rect";
        /// <summary>
        /// Cached name for the 'get_rect' method.
        /// </summary>
        public static readonly StringName GetRect = "get_rect";
        /// <summary>
        /// Cached name for the 'set_copy_mode' method.
        /// </summary>
        public static readonly StringName SetCopyMode = "set_copy_mode";
        /// <summary>
        /// Cached name for the 'get_copy_mode' method.
        /// </summary>
        public static readonly StringName GetCopyMode = "get_copy_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}

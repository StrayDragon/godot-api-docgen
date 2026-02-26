namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D rectangle shape, intended for use in physics. Usually used to provide a shape for a <see cref="Godot.CollisionShape2D"/>.</para>
/// <para><b>Performance:</b> <see cref="Godot.RectangleShape2D"/> is fast to check collisions against. It is faster than <see cref="Godot.CapsuleShape2D"/>, but slower than <see cref="Godot.CircleShape2D"/>.</para>
/// </summary>
public partial class RectangleShape2D : Shape2D
{
    /// <summary>
    /// <para>The rectangle's width and height.</para>
    /// </summary>
    public Vector2 Size
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

    private static readonly System.Type CachedType = typeof(RectangleShape2D);

    private static readonly StringName NativeName = "RectangleShape2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RectangleShape2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RectangleShape2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RectangleShape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Shape2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape2D.SignalName
    {
    }
}

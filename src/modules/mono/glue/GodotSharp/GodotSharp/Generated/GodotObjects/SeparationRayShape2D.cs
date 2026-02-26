namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D ray shape, intended for use in physics. Usually used to provide a shape for a <see cref="Godot.CollisionShape2D"/>. When a <see cref="Godot.SeparationRayShape2D"/> collides with an object, it tries to separate itself from it by moving its endpoint to the collision point. For example, a <see cref="Godot.SeparationRayShape2D"/> next to a character can allow it to instantly move up when touching stairs.</para>
/// </summary>
public partial class SeparationRayShape2D : Shape2D
{
    /// <summary>
    /// <para>The ray's length.</para>
    /// </summary>
    public float Length
    {
        get
        {
            return GetLength();
        }
        set
        {
            SetLength(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/> (default), the shape always separates and returns a normal along its own direction.</para>
    /// <para>If <see langword="true"/>, the shape can return the correct normal and separate in any direction, allowing sliding motion on slopes.</para>
    /// </summary>
    public bool SlideOnSlope
    {
        get
        {
            return GetSlideOnSlope();
        }
        set
        {
            SetSlideOnSlope(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SeparationRayShape2D);

    private static readonly StringName NativeName = "SeparationRayShape2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SeparationRayShape2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SeparationRayShape2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SeparationRayShape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlideOnSlope, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSlideOnSlope(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlideOnSlope, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSlideOnSlope()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'length' property.
        /// </summary>
        public static readonly StringName Length = "length";
        /// <summary>
        /// Cached name for the 'slide_on_slope' property.
        /// </summary>
        public static readonly StringName SlideOnSlope = "slide_on_slope";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_length' method.
        /// </summary>
        public static readonly StringName SetLength = "set_length";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'set_slide_on_slope' method.
        /// </summary>
        public static readonly StringName SetSlideOnSlope = "set_slide_on_slope";
        /// <summary>
        /// Cached name for the 'get_slide_on_slope' method.
        /// </summary>
        public static readonly StringName GetSlideOnSlope = "get_slide_on_slope";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape2D.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for all 3D shapes, intended for use in physics.</para>
/// <para><b>Performance:</b> Primitive shapes, especially <see cref="Godot.SphereShape3D"/>, are fast to check collisions against. <see cref="Godot.ConvexPolygonShape3D"/> and <see cref="Godot.HeightMapShape3D"/> are slower, and <see cref="Godot.ConcavePolygonShape3D"/> is the slowest.</para>
/// </summary>
public partial class Shape3D : Resource
{
    /// <summary>
    /// <para>The shape's custom solver bias. Defines how much bodies react to enforce contact separation when this shape is involved.</para>
    /// <para>When set to <c>0</c>, the default value from <c>ProjectSettings.physics/3d/solver/default_contact_bias</c> is used.</para>
    /// </summary>
    public float CustomSolverBias
    {
        get
        {
            return GetCustomSolverBias();
        }
        set
        {
            SetCustomSolverBias(value);
        }
    }

    /// <summary>
    /// <para>The collision margin for the shape. This is not used in Godot Physics.</para>
    /// <para>Collision margins allow collision detection to be more efficient by adding an extra shell around shapes. Collision algorithms are more expensive when objects overlap by more than their margin, so a higher value for margins is better for performance, at the cost of accuracy around edges as it makes them less sharp.</para>
    /// </summary>
    public float Margin
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

    private static readonly System.Type CachedType = typeof(Shape3D);

    private static readonly StringName NativeName = "Shape3D";

    internal Shape3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shape3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomSolverBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomSolverBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomSolverBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCustomSolverBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugMesh, 1605880883ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.ArrayMesh"/> used to draw the debug collision for this <see cref="Godot.Shape3D"/>.</para>
    /// </summary>
    public ArrayMesh GetDebugMesh()
    {
        return (ArrayMesh)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
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
        /// Cached name for the 'custom_solver_bias' property.
        /// </summary>
        public static readonly StringName CustomSolverBias = "custom_solver_bias";
        /// <summary>
        /// Cached name for the 'margin' property.
        /// </summary>
        public static readonly StringName Margin = "margin";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_custom_solver_bias' method.
        /// </summary>
        public static readonly StringName SetCustomSolverBias = "set_custom_solver_bias";
        /// <summary>
        /// Cached name for the 'get_custom_solver_bias' method.
        /// </summary>
        public static readonly StringName GetCustomSolverBias = "get_custom_solver_bias";
        /// <summary>
        /// Cached name for the 'set_margin' method.
        /// </summary>
        public static readonly StringName SetMargin = "set_margin";
        /// <summary>
        /// Cached name for the 'get_margin' method.
        /// </summary>
        public static readonly StringName GetMargin = "get_margin";
        /// <summary>
        /// Cached name for the 'get_debug_mesh' method.
        /// </summary>
        public static readonly StringName GetDebugMesh = "get_debug_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An OpenXR composition layer that allows rendering a <see cref="Godot.SubViewport"/> on an internal slice of a sphere.</para>
/// </summary>
public partial class OpenXRCompositionLayerEquirect : OpenXRCompositionLayer
{
    /// <summary>
    /// <para>The radius of the sphere.</para>
    /// </summary>
    public float Radius
    {
        get
        {
            return GetRadius();
        }
        set
        {
            SetRadius(value);
        }
    }

    /// <summary>
    /// <para>The central horizontal angle of the sphere. Used to set the width.</para>
    /// </summary>
    public float CentralHorizontalAngle
    {
        get
        {
            return GetCentralHorizontalAngle();
        }
        set
        {
            SetCentralHorizontalAngle(value);
        }
    }

    /// <summary>
    /// <para>The upper vertical angle of the sphere. Used (together with <see cref="Godot.OpenXRCompositionLayerEquirect.LowerVerticalAngle"/>) to set the height.</para>
    /// </summary>
    public float UpperVerticalAngle
    {
        get
        {
            return GetUpperVerticalAngle();
        }
        set
        {
            SetUpperVerticalAngle(value);
        }
    }

    /// <summary>
    /// <para>The lower vertical angle of the sphere. Used (together with <see cref="Godot.OpenXRCompositionLayerEquirect.UpperVerticalAngle"/>) to set the height.</para>
    /// </summary>
    public float LowerVerticalAngle
    {
        get
        {
            return GetLowerVerticalAngle();
        }
        set
        {
            SetLowerVerticalAngle(value);
        }
    }

    /// <summary>
    /// <para>The number of segments to use in the fallback mesh.</para>
    /// </summary>
    public uint FallbackSegments
    {
        get
        {
            return GetFallbackSegments();
        }
        set
        {
            SetFallbackSegments(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRCompositionLayerEquirect);

    private static readonly StringName NativeName = "OpenXRCompositionLayerEquirect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRCompositionLayerEquirect() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRCompositionLayerEquirect(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRCompositionLayerEquirect(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCentralHorizontalAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCentralHorizontalAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCentralHorizontalAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCentralHorizontalAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpperVerticalAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpperVerticalAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpperVerticalAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetUpperVerticalAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLowerVerticalAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLowerVerticalAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLowerVerticalAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLowerVerticalAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackSegments(uint segments)
    {
        NativeCalls.godot_icall_1_208(MethodBind8, GodotObject.GetPtr(this), segments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetFallbackSegments()
    {
        return NativeCalls.godot_icall_0_209(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : OpenXRCompositionLayer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
        /// <summary>
        /// Cached name for the 'central_horizontal_angle' property.
        /// </summary>
        public static readonly StringName CentralHorizontalAngle = "central_horizontal_angle";
        /// <summary>
        /// Cached name for the 'upper_vertical_angle' property.
        /// </summary>
        public static readonly StringName UpperVerticalAngle = "upper_vertical_angle";
        /// <summary>
        /// Cached name for the 'lower_vertical_angle' property.
        /// </summary>
        public static readonly StringName LowerVerticalAngle = "lower_vertical_angle";
        /// <summary>
        /// Cached name for the 'fallback_segments' property.
        /// </summary>
        public static readonly StringName FallbackSegments = "fallback_segments";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRCompositionLayer.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_central_horizontal_angle' method.
        /// </summary>
        public static readonly StringName SetCentralHorizontalAngle = "set_central_horizontal_angle";
        /// <summary>
        /// Cached name for the 'get_central_horizontal_angle' method.
        /// </summary>
        public static readonly StringName GetCentralHorizontalAngle = "get_central_horizontal_angle";
        /// <summary>
        /// Cached name for the 'set_upper_vertical_angle' method.
        /// </summary>
        public static readonly StringName SetUpperVerticalAngle = "set_upper_vertical_angle";
        /// <summary>
        /// Cached name for the 'get_upper_vertical_angle' method.
        /// </summary>
        public static readonly StringName GetUpperVerticalAngle = "get_upper_vertical_angle";
        /// <summary>
        /// Cached name for the 'set_lower_vertical_angle' method.
        /// </summary>
        public static readonly StringName SetLowerVerticalAngle = "set_lower_vertical_angle";
        /// <summary>
        /// Cached name for the 'get_lower_vertical_angle' method.
        /// </summary>
        public static readonly StringName GetLowerVerticalAngle = "get_lower_vertical_angle";
        /// <summary>
        /// Cached name for the 'set_fallback_segments' method.
        /// </summary>
        public static readonly StringName SetFallbackSegments = "set_fallback_segments";
        /// <summary>
        /// Cached name for the 'get_fallback_segments' method.
        /// </summary>
        public static readonly StringName GetFallbackSegments = "get_fallback_segments";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRCompositionLayer.SignalName
    {
    }
}

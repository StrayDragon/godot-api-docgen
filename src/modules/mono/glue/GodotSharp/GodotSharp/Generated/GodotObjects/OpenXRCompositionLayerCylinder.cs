namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An OpenXR composition layer that allows rendering a <see cref="Godot.SubViewport"/> on an internal slice of a cylinder.</para>
/// </summary>
public partial class OpenXRCompositionLayerCylinder : OpenXRCompositionLayer
{
    /// <summary>
    /// <para>The radius of the cylinder.</para>
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
    /// <para>The aspect ratio of the slice. Used to set the height relative to the width.</para>
    /// </summary>
    public float AspectRatio
    {
        get
        {
            return GetAspectRatio();
        }
        set
        {
            SetAspectRatio(value);
        }
    }

    /// <summary>
    /// <para>The central angle of the cylinder. Used to set the width.</para>
    /// </summary>
    public float CentralAngle
    {
        get
        {
            return GetCentralAngle();
        }
        set
        {
            SetCentralAngle(value);
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

    private static readonly System.Type CachedType = typeof(OpenXRCompositionLayerCylinder);

    private static readonly StringName NativeName = "OpenXRCompositionLayerCylinder";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRCompositionLayerCylinder() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRCompositionLayerCylinder(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRCompositionLayerCylinder(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAspectRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAspectRatio(float aspectRatio)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), aspectRatio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAspectRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAspectRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCentralAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCentralAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCentralAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCentralAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackSegments(uint segments)
    {
        NativeCalls.godot_icall_1_208(MethodBind6, GodotObject.GetPtr(this), segments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetFallbackSegments()
    {
        return NativeCalls.godot_icall_0_209(MethodBind7, GodotObject.GetPtr(this));
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
        /// Cached name for the 'aspect_ratio' property.
        /// </summary>
        public static readonly StringName AspectRatio = "aspect_ratio";
        /// <summary>
        /// Cached name for the 'central_angle' property.
        /// </summary>
        public static readonly StringName CentralAngle = "central_angle";
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
        /// Cached name for the 'set_aspect_ratio' method.
        /// </summary>
        public static readonly StringName SetAspectRatio = "set_aspect_ratio";
        /// <summary>
        /// Cached name for the 'get_aspect_ratio' method.
        /// </summary>
        public static readonly StringName GetAspectRatio = "get_aspect_ratio";
        /// <summary>
        /// Cached name for the 'set_central_angle' method.
        /// </summary>
        public static readonly StringName SetCentralAngle = "set_central_angle";
        /// <summary>
        /// Cached name for the 'get_central_angle' method.
        /// </summary>
        public static readonly StringName GetCentralAngle = "get_central_angle";
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

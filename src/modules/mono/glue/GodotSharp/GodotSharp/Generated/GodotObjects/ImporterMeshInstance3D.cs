namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class ImporterMeshInstance3D : Node3D
{
    public ImporterMesh Mesh
    {
        get
        {
            return GetMesh();
        }
        set
        {
            SetMesh(value);
        }
    }

    public Skin Skin
    {
        get
        {
            return GetSkin();
        }
        set
        {
            SetSkin(value);
        }
    }

    public NodePath SkeletonPath
    {
        get
        {
            return GetSkeletonPath();
        }
        set
        {
            SetSkeletonPath(value);
        }
    }

    public uint LayerMask
    {
        get
        {
            return GetLayerMask();
        }
        set
        {
            SetLayerMask(value);
        }
    }

    public GeometryInstance3D.ShadowCastingSetting CastShadow
    {
        get
        {
            return GetCastShadowsSetting();
        }
        set
        {
            SetCastShadowsSetting(value);
        }
    }

    public float VisibilityRangeBegin
    {
        get
        {
            return GetVisibilityRangeBegin();
        }
        set
        {
            SetVisibilityRangeBegin(value);
        }
    }

    public float VisibilityRangeBeginMargin
    {
        get
        {
            return GetVisibilityRangeBeginMargin();
        }
        set
        {
            SetVisibilityRangeBeginMargin(value);
        }
    }

    public float VisibilityRangeEnd
    {
        get
        {
            return GetVisibilityRangeEnd();
        }
        set
        {
            SetVisibilityRangeEnd(value);
        }
    }

    public float VisibilityRangeEndMargin
    {
        get
        {
            return GetVisibilityRangeEndMargin();
        }
        set
        {
            SetVisibilityRangeEndMargin(value);
        }
    }

    public GeometryInstance3D.VisibilityRangeFadeModeEnum VisibilityRangeFadeMode
    {
        get
        {
            return GetVisibilityRangeFadeMode();
        }
        set
        {
            SetVisibilityRangeFadeMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ImporterMeshInstance3D);

    private static readonly StringName NativeName = "ImporterMeshInstance3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ImporterMeshInstance3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ImporterMeshInstance3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ImporterMeshInstance3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 2255166972ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(ImporterMesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 3161779525ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImporterMesh GetMesh()
    {
        return (ImporterMesh)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkin, 3971435618ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkin(Skin skin)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(skin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkin, 2074563878ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Skin GetSkin()
    {
        return (Skin)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeletonPath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkeletonPath(NodePath skeletonPath)
    {
        NativeCalls.godot_icall_1_123(MethodBind4, GodotObject.GetPtr(this), (godot_node_path)(skeletonPath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeletonPath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetSkeletonPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayerMask(uint layerMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind6, GodotObject.GetPtr(this), layerMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetLayerMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCastShadowsSetting, 856677339ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCastShadowsSetting(GeometryInstance3D.ShadowCastingSetting shadowCastingSetting)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)shadowCastingSetting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCastShadowsSetting, 3383019359ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GeometryInstance3D.ShadowCastingSetting GetCastShadowsSetting()
    {
        return (GeometryInstance3D.ShadowCastingSetting)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeEndMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeEndMargin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeEndMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeEndMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeEnd, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeEnd(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeEnd, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeEnd()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeBeginMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeBeginMargin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeBeginMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeBeginMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeBegin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeBegin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeBegin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeBegin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeFadeMode, 1440117808ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeFadeMode(GeometryInstance3D.VisibilityRangeFadeModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeFadeMode, 2067221882ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GeometryInstance3D.VisibilityRangeFadeModeEnum GetVisibilityRangeFadeMode()
    {
        return (GeometryInstance3D.VisibilityRangeFadeModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'skin' property.
        /// </summary>
        public static readonly StringName Skin = "skin";
        /// <summary>
        /// Cached name for the 'skeleton_path' property.
        /// </summary>
        public static readonly StringName SkeletonPath = "skeleton_path";
        /// <summary>
        /// Cached name for the 'layer_mask' property.
        /// </summary>
        public static readonly StringName LayerMask = "layer_mask";
        /// <summary>
        /// Cached name for the 'cast_shadow' property.
        /// </summary>
        public static readonly StringName CastShadow = "cast_shadow";
        /// <summary>
        /// Cached name for the 'visibility_range_begin' property.
        /// </summary>
        public static readonly StringName VisibilityRangeBegin = "visibility_range_begin";
        /// <summary>
        /// Cached name for the 'visibility_range_begin_margin' property.
        /// </summary>
        public static readonly StringName VisibilityRangeBeginMargin = "visibility_range_begin_margin";
        /// <summary>
        /// Cached name for the 'visibility_range_end' property.
        /// </summary>
        public static readonly StringName VisibilityRangeEnd = "visibility_range_end";
        /// <summary>
        /// Cached name for the 'visibility_range_end_margin' property.
        /// </summary>
        public static readonly StringName VisibilityRangeEndMargin = "visibility_range_end_margin";
        /// <summary>
        /// Cached name for the 'visibility_range_fade_mode' property.
        /// </summary>
        public static readonly StringName VisibilityRangeFadeMode = "visibility_range_fade_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_skin' method.
        /// </summary>
        public static readonly StringName SetSkin = "set_skin";
        /// <summary>
        /// Cached name for the 'get_skin' method.
        /// </summary>
        public static readonly StringName GetSkin = "get_skin";
        /// <summary>
        /// Cached name for the 'set_skeleton_path' method.
        /// </summary>
        public static readonly StringName SetSkeletonPath = "set_skeleton_path";
        /// <summary>
        /// Cached name for the 'get_skeleton_path' method.
        /// </summary>
        public static readonly StringName GetSkeletonPath = "get_skeleton_path";
        /// <summary>
        /// Cached name for the 'set_layer_mask' method.
        /// </summary>
        public static readonly StringName SetLayerMask = "set_layer_mask";
        /// <summary>
        /// Cached name for the 'get_layer_mask' method.
        /// </summary>
        public static readonly StringName GetLayerMask = "get_layer_mask";
        /// <summary>
        /// Cached name for the 'set_cast_shadows_setting' method.
        /// </summary>
        public static readonly StringName SetCastShadowsSetting = "set_cast_shadows_setting";
        /// <summary>
        /// Cached name for the 'get_cast_shadows_setting' method.
        /// </summary>
        public static readonly StringName GetCastShadowsSetting = "get_cast_shadows_setting";
        /// <summary>
        /// Cached name for the 'set_visibility_range_end_margin' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeEndMargin = "set_visibility_range_end_margin";
        /// <summary>
        /// Cached name for the 'get_visibility_range_end_margin' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeEndMargin = "get_visibility_range_end_margin";
        /// <summary>
        /// Cached name for the 'set_visibility_range_end' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeEnd = "set_visibility_range_end";
        /// <summary>
        /// Cached name for the 'get_visibility_range_end' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeEnd = "get_visibility_range_end";
        /// <summary>
        /// Cached name for the 'set_visibility_range_begin_margin' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeBeginMargin = "set_visibility_range_begin_margin";
        /// <summary>
        /// Cached name for the 'get_visibility_range_begin_margin' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeBeginMargin = "get_visibility_range_begin_margin";
        /// <summary>
        /// Cached name for the 'set_visibility_range_begin' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeBegin = "set_visibility_range_begin";
        /// <summary>
        /// Cached name for the 'get_visibility_range_begin' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeBegin = "get_visibility_range_begin";
        /// <summary>
        /// Cached name for the 'set_visibility_range_fade_mode' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeFadeMode = "set_visibility_range_fade_mode";
        /// <summary>
        /// Cached name for the 'get_visibility_range_fade_mode' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeFadeMode = "get_visibility_range_fade_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}

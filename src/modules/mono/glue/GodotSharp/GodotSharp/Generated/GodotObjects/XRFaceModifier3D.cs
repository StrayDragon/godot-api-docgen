namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node applies weights from an <see cref="Godot.XRFaceTracker"/> to a mesh with supporting face blend shapes.</para>
/// <para>The <a href="https://docs.vrcft.io/docs/tutorial-avatars/tutorial-avatars-extras/unified-blendshapes">Unified Expressions</a> blend shapes are supported, as well as ARKit and SRanipal blend shapes.</para>
/// <para>The node attempts to identify blend shapes based on name matching. Blend shapes should match the names listed in the <a href="https://docs.vrcft.io/docs/tutorial-avatars/tutorial-avatars-extras/compatibility/overview">Unified Expressions Compatibility</a> chart.</para>
/// </summary>
public partial class XRFaceModifier3D : Node3D
{
    /// <summary>
    /// <para>The <see cref="Godot.XRFaceTracker"/> path.</para>
    /// </summary>
    public StringName FaceTracker
    {
        get
        {
            return GetFaceTracker();
        }
        set
        {
            SetFaceTracker(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.NodePath"/> of the face <see cref="Godot.MeshInstance3D"/>.</para>
    /// </summary>
    public NodePath Target
    {
        get
        {
            return GetTarget();
        }
        set
        {
            SetTarget(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRFaceModifier3D);

    private static readonly StringName NativeName = "XRFaceModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRFaceModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRFaceModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRFaceModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFaceTracker, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFaceTracker(StringName trackerName)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(trackerName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceTracker, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetFaceTracker()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTarget, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTarget(NodePath target)
    {
        NativeCalls.godot_icall_1_123(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(target?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTarget, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTarget()
    {
        return NativeCalls.godot_icall_0_124(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'face_tracker' property.
        /// </summary>
        public static readonly StringName FaceTracker = "face_tracker";
        /// <summary>
        /// Cached name for the 'target' property.
        /// </summary>
        public static readonly StringName Target = "target";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_face_tracker' method.
        /// </summary>
        public static readonly StringName SetFaceTracker = "set_face_tracker";
        /// <summary>
        /// Cached name for the 'get_face_tracker' method.
        /// </summary>
        public static readonly StringName GetFaceTracker = "get_face_tracker";
        /// <summary>
        /// Cached name for the 'set_target' method.
        /// </summary>
        public static readonly StringName SetTarget = "set_target";
        /// <summary>
        /// Cached name for the 'get_target' method.
        /// </summary>
        public static readonly StringName GetTarget = "get_target";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}

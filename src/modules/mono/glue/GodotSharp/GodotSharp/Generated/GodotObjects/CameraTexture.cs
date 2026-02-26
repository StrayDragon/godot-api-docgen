namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This texture gives access to the camera texture provided by a <see cref="Godot.CameraFeed"/>.</para>
/// <para><b>Note:</b> Many cameras supply YCbCr images which need to be converted in a shader.</para>
/// </summary>
public partial class CameraTexture : Texture2D
{
    /// <summary>
    /// <para>The ID of the <see cref="Godot.CameraFeed"/> for which we want to display the image.</para>
    /// </summary>
    public int CameraFeedId
    {
        get
        {
            return GetCameraFeedId();
        }
        set
        {
            SetCameraFeedId(value);
        }
    }

    /// <summary>
    /// <para>Which image within the <see cref="Godot.CameraFeed"/> we want access to, important if the camera image is split in a Y and CbCr component.</para>
    /// </summary>
    public CameraServer.FeedImage WhichFeed
    {
        get
        {
            return GetWhichFeed();
        }
        set
        {
            SetWhichFeed(value);
        }
    }

    /// <summary>
    /// <para>Convenience property that gives access to the active property of the <see cref="Godot.CameraFeed"/>.</para>
    /// </summary>
    public bool CameraIsActive
    {
        get
        {
            return GetCameraActive();
        }
        set
        {
            SetCameraActive(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CameraTexture);

    private static readonly StringName NativeName = "CameraTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CameraTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraFeedId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraFeedId(int feedId)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), feedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraFeedId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCameraFeedId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWhichFeed, 1595299230ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWhichFeed(CameraServer.FeedImage whichFeed)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)whichFeed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWhichFeed, 91039457ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CameraServer.FeedImage GetWhichFeed()
    {
        return (CameraServer.FeedImage)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraActive, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraActive, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCameraActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'camera_feed_id' property.
        /// </summary>
        public static readonly StringName CameraFeedId = "camera_feed_id";
        /// <summary>
        /// Cached name for the 'which_feed' property.
        /// </summary>
        public static readonly StringName WhichFeed = "which_feed";
        /// <summary>
        /// Cached name for the 'camera_is_active' property.
        /// </summary>
        public static readonly StringName CameraIsActive = "camera_is_active";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_camera_feed_id' method.
        /// </summary>
        public static readonly StringName SetCameraFeedId = "set_camera_feed_id";
        /// <summary>
        /// Cached name for the 'get_camera_feed_id' method.
        /// </summary>
        public static readonly StringName GetCameraFeedId = "get_camera_feed_id";
        /// <summary>
        /// Cached name for the 'set_which_feed' method.
        /// </summary>
        public static readonly StringName SetWhichFeed = "set_which_feed";
        /// <summary>
        /// Cached name for the 'get_which_feed' method.
        /// </summary>
        public static readonly StringName GetWhichFeed = "get_which_feed";
        /// <summary>
        /// Cached name for the 'set_camera_active' method.
        /// </summary>
        public static readonly StringName SetCameraActive = "set_camera_active";
        /// <summary>
        /// Cached name for the 'get_camera_active' method.
        /// </summary>
        public static readonly StringName GetCameraActive = "get_camera_active";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}

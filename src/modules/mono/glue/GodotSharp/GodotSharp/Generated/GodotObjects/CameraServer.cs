namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.CameraServer"/> keeps track of different cameras accessible in Godot. These are external cameras such as webcams or the cameras on your phone.</para>
/// <para>It is notably used to provide AR modules with a video feed from the camera.</para>
/// <para><b>Note:</b> This class is currently only implemented on Linux, Android, macOS, and iOS. On other platforms no <see cref="Godot.CameraFeed"/>s will be available. To get a <see cref="Godot.CameraFeed"/> on iOS, the camera plugin from <a href="https://github.com/godotengine/godot-ios-plugins">godot-ios-plugins</a> is required.</para>
/// </summary>
public static partial class CameraServer
{
    public enum FeedImage : long
    {
        /// <summary>
        /// <para>The RGBA camera image.</para>
        /// </summary>
        RgbaImage = 0,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/YCbCr">YCbCr</a> camera image.</para>
        /// </summary>
        YcbcrImage = 0,
        /// <summary>
        /// <para>The Y component camera image.</para>
        /// </summary>
        YImage = 0,
        /// <summary>
        /// <para>The CbCr component camera image.</para>
        /// </summary>
        CbcrImage = 1
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the server is actively monitoring available camera feeds.</para>
    /// <para>This has a performance cost, so only set it to <see langword="true"/> when you're actively accessing the camera.</para>
    /// <para><b>Note:</b> After setting it to <see langword="true"/>, you can receive updated camera feeds through the <see cref="Godot.CameraServer.CameraFeedsUpdated"/> signal.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	CameraServer.CameraFeedsUpdated += OnCameraFeedsUpdated;
    /// 	CameraServer.MonitoringFeeds = true;
    /// }
    /// 
    /// void OnCameraFeedsUpdated()
    /// {
    /// 	var feeds = CameraServer.Feeds();
    /// }
    /// </code></para>
    /// </summary>
    public static bool MonitoringFeeds
    {
        get
        {
            return IsMonitoringFeeds();
        }
        set
        {
            SetMonitoringFeeds(value);
        }
    }

    private static readonly StringName NativeName = "CameraServer";

    private static CameraServerInstance singleton;

    public static CameraServerInstance Singleton =>
        singleton ??= (CameraServerInstance)InteropUtils.EngineGetSingleton("CameraServer");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMonitoringFeeds, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetMonitoringFeeds(bool isMonitoringFeeds)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(Singleton), isMonitoringFeeds.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMonitoringFeeds, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsMonitoringFeeds()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeed, 361927068ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.CameraFeed"/> corresponding to the camera with the given <paramref name="index"/>.</para>
    /// </summary>
    public static CameraFeed GetFeed(int index)
    {
        return (CameraFeed)NativeCalls.godot_icall_1_71(MethodBind2, GodotObject.GetPtr(Singleton), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeedCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of <see cref="Godot.CameraFeed"/>s registered.</para>
    /// </summary>
    public static int GetFeedCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Feeds, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.CameraFeed"/>s.</para>
    /// </summary>
    public static Godot.Collections.Array<CameraFeed> Feeds()
    {
        return new Godot.Collections.Array<CameraFeed>(NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddFeed, 3204782488ul);

    /// <summary>
    /// <para>Adds the camera <paramref name="feed"/> to the camera server.</para>
    /// </summary>
    public static void AddFeed(CameraFeed feed)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(feed));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveFeed, 3204782488ul);

    /// <summary>
    /// <para>Removes the specified camera <paramref name="feed"/>.</para>
    /// </summary>
    public static void RemoveFeed(CameraFeed feed)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(feed));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CameraServer.CameraFeedAdded"/> event of a <see cref="Godot.CameraServer"/> class.
    /// </summary>
    public delegate void CameraFeedAddedEventHandler(long id);

    private static void CameraFeedAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CameraFeedAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a <see cref="Godot.CameraFeed"/> is added (e.g. a webcam is plugged in).</para>
    /// </summary>
    public static unsafe event CameraFeedAddedEventHandler CameraFeedAdded
    {
        add => Singleton.Connect(SignalName.CameraFeedAdded, Callable.CreateWithUnsafeTrampoline(value, &CameraFeedAddedTrampoline));
        remove => Singleton.Disconnect(SignalName.CameraFeedAdded, Callable.CreateWithUnsafeTrampoline(value, &CameraFeedAddedTrampoline));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CameraServer.CameraFeedRemoved"/> event of a <see cref="Godot.CameraServer"/> class.
    /// </summary>
    public delegate void CameraFeedRemovedEventHandler(long id);

    private static void CameraFeedRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CameraFeedRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a <see cref="Godot.CameraFeed"/> is removed (e.g. a webcam is unplugged).</para>
    /// </summary>
    public static unsafe event CameraFeedRemovedEventHandler CameraFeedRemoved
    {
        add => Singleton.Connect(SignalName.CameraFeedRemoved, Callable.CreateWithUnsafeTrampoline(value, &CameraFeedRemovedTrampoline));
        remove => Singleton.Disconnect(SignalName.CameraFeedRemoved, Callable.CreateWithUnsafeTrampoline(value, &CameraFeedRemovedTrampoline));
    }

    /// <summary>
    /// <para>Emitted when camera feeds are updated.</para>
    /// </summary>
    public static event Action CameraFeedsUpdated
    {
        add => Singleton.Connect(SignalName.CameraFeedsUpdated, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.CameraFeedsUpdated, Callable.From(value));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'monitoring_feeds' property.
        /// </summary>
        public static readonly StringName MonitoringFeeds = "monitoring_feeds";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'set_monitoring_feeds' method.
        /// </summary>
        public static readonly StringName SetMonitoringFeeds = "set_monitoring_feeds";
        /// <summary>
        /// Cached name for the 'is_monitoring_feeds' method.
        /// </summary>
        public static readonly StringName IsMonitoringFeeds = "is_monitoring_feeds";
        /// <summary>
        /// Cached name for the 'get_feed' method.
        /// </summary>
        public static readonly StringName GetFeed = "get_feed";
        /// <summary>
        /// Cached name for the 'get_feed_count' method.
        /// </summary>
        public static readonly StringName GetFeedCount = "get_feed_count";
        /// <summary>
        /// Cached name for the 'feeds' method.
        /// </summary>
        public static readonly StringName Feeds = "feeds";
        /// <summary>
        /// Cached name for the 'add_feed' method.
        /// </summary>
        public static readonly StringName AddFeed = "add_feed";
        /// <summary>
        /// Cached name for the 'remove_feed' method.
        /// </summary>
        public static readonly StringName RemoveFeed = "remove_feed";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'camera_feed_added' signal.
        /// </summary>
        public static readonly StringName CameraFeedAdded = "camera_feed_added";
        /// <summary>
        /// Cached name for the 'camera_feed_removed' signal.
        /// </summary>
        public static readonly StringName CameraFeedRemoved = "camera_feed_removed";
        /// <summary>
        /// Cached name for the 'camera_feeds_updated' signal.
        /// </summary>
        public static readonly StringName CameraFeedsUpdated = "camera_feeds_updated";
    }
}

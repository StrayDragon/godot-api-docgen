namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A camera feed gives you access to a single physical camera attached to your device. When enabled, Godot will start capturing frames from the camera which can then be used. See also <see cref="Godot.CameraServer"/>.</para>
/// <para><b>Note:</b> Many cameras will return YCbCr images which are split into two textures and need to be combined in a shader. Godot does this automatically for you if you set the environment to show the camera image in the background.</para>
/// <para><b>Note:</b> This class is currently only implemented on Linux, Android, macOS, and iOS. On other platforms no <see cref="Godot.CameraFeed"/>s will be available. To get a <see cref="Godot.CameraFeed"/> on iOS, the camera plugin from <a href="https://github.com/godotengine/godot-ios-plugins">godot-ios-plugins</a> is required.</para>
/// </summary>
public partial class CameraFeed : RefCounted
{
    public enum FeedDataType : long
    {
        /// <summary>
        /// <para>No image set for the feed.</para>
        /// </summary>
        Noimage = 0,
        /// <summary>
        /// <para>Feed supplies RGB images.</para>
        /// </summary>
        Rgb = 1,
        /// <summary>
        /// <para>Feed supplies YCbCr images that need to be converted to RGB.</para>
        /// </summary>
        Ycbcr = 2,
        /// <summary>
        /// <para>Feed supplies separate Y and CbCr images that need to be combined and converted to RGB.</para>
        /// </summary>
        YcbcrSep = 3,
        /// <summary>
        /// <para>Feed supplies external image.</para>
        /// </summary>
        External = 4
    }

    public enum FeedPosition : long
    {
        /// <summary>
        /// <para>Unspecified position.</para>
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// <para>Camera is mounted at the front of the device.</para>
        /// </summary>
        Front = 1,
        /// <summary>
        /// <para>Camera is mounted at the back of the device.</para>
        /// </summary>
        Back = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the feed is active.</para>
    /// </summary>
    public bool FeedIsActive
    {
        get
        {
            return IsActive();
        }
        set
        {
            SetActive(value);
        }
    }

    /// <summary>
    /// <para>The transform applied to the camera's image.</para>
    /// </summary>
    public Transform2D FeedTransform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    /// <summary>
    /// <para>Formats supported by the feed. Each entry is a <see cref="Godot.Collections.Dictionary"/> describing format parameters.</para>
    /// </summary>
    public Godot.Collections.Array Formats
    {
        get
        {
            return GetFormats();
        }
    }

    private static readonly System.Type CachedType = typeof(CameraFeed);

    private static readonly StringName NativeName = "CameraFeed";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CameraFeed() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraFeed(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraFeed(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the camera feed is activated.</para>
    /// </summary>
    public virtual bool _ActivateFeed()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the camera feed is deactivated.</para>
    /// </summary>
    public virtual void _DeactivateFeed()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetId, 3905245786ul);

    /// <summary>
    /// <para>Returns the unique ID for this feed.</para>
    /// </summary>
    public int GetId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActive, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActive, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 201670096ul);

    /// <summary>
    /// <para>Returns the camera's name.</para>
    /// </summary>
    public string GetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetName, 83702148ul);

    /// <summary>
    /// <para>Sets the camera's name.</para>
    /// </summary>
    public void SetName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 2711679033ul);

    /// <summary>
    /// <para>Returns the position of camera on the device.</para>
    /// </summary>
    public CameraFeed.FeedPosition GetPosition()
    {
        return (CameraFeed.FeedPosition)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 611162623ul);

    /// <summary>
    /// <para>Sets the position of this camera.</para>
    /// </summary>
    public void SetPosition(CameraFeed.FeedPosition position)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform2D transform)
    {
        NativeCalls.godot_icall_1_218(MethodBind8, GodotObject.GetPtr(this), &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRgbImage, 532598488ul);

    /// <summary>
    /// <para>Sets RGB image for this feed.</para>
    /// </summary>
    public void SetRgbImage(Image rgbImage)
    {
        NativeCalls.godot_icall_1_56(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(rgbImage));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetYcbcrImage, 532598488ul);

    /// <summary>
    /// <para>Sets YCbCr image for this feed.</para>
    /// </summary>
    public void SetYcbcrImage(Image ycbcrImage)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(ycbcrImage));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetYcbcrImages, 1986484629ul);

    /// <summary>
    /// <para>Sets Y and CbCr images for this feed.</para>
    /// </summary>
    public void SetYcbcrImages(Image yImage, Image cbcrImage)
    {
        NativeCalls.godot_icall_2_239(MethodBind11, GodotObject.GetPtr(this), GodotObject.GetPtr(yImage), GodotObject.GetPtr(cbcrImage));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExternal, 3937882851ul);

    /// <summary>
    /// <para>Sets the feed as external feed provided by another library.</para>
    /// </summary>
    public void SetExternal(int width, int height)
    {
        NativeCalls.godot_icall_2_59(MethodBind12, GodotObject.GetPtr(this), width, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureTexId, 1135699418ul);

    /// <summary>
    /// <para>Returns the texture backend ID (usable by some external libraries that need a handle to a texture to write data).</para>
    /// </summary>
    public ulong GetTextureTexId(CameraServer.FeedImage feedImageType)
    {
        return NativeCalls.godot_icall_1_240(MethodBind13, GodotObject.GetPtr(this), (int)feedImageType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDatatype, 1477782850ul);

    /// <summary>
    /// <para>Returns feed image data type.</para>
    /// </summary>
    public CameraFeed.FeedDataType GetDatatype()
    {
        return (CameraFeed.FeedDataType)NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormats, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetFormats()
    {
        return NativeCalls.godot_icall_0_120(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFormat, 31872775ul);

    /// <summary>
    /// <para>Sets the feed format parameters for the given <paramref name="index"/> in the <see cref="Godot.CameraFeed.Formats"/> array. Returns <see langword="true"/> on success. By default, the YUYV encoded stream is transformed to <see cref="Godot.CameraFeed.FeedDataType.Rgb"/>. The YUYV encoded stream output format can be changed by setting <paramref name="parameters"/>'s <c>output</c> entry to one of the following:</para>
    /// <para>- <c>"separate"</c> will result in <see cref="Godot.CameraFeed.FeedDataType.YcbcrSep"/>;</para>
    /// <para>- <c>"grayscale"</c> will result in desaturated <see cref="Godot.CameraFeed.FeedDataType.Rgb"/>;</para>
    /// <para>- <c>"copy"</c> will result in <see cref="Godot.CameraFeed.FeedDataType.Ycbcr"/>.</para>
    /// </summary>
    public bool SetFormat(int index, Godot.Collections.Dictionary parameters)
    {
        return NativeCalls.godot_icall_2_241(MethodBind16, GodotObject.GetPtr(this), index, (godot_dictionary)(parameters ?? new()).NativeValue).ToBool();
    }

    /// <summary>
    /// <para>Emitted when a new frame is available.</para>
    /// </summary>
    public event Action FrameChanged
    {
        add => Connect(SignalName.FrameChanged, Callable.From(value));
        remove => Disconnect(SignalName.FrameChanged, Callable.From(value));
    }

    protected void EmitSignalFrameChanged()
    {
        EmitSignal(SignalName.FrameChanged);
    }

    /// <summary>
    /// <para>Emitted when the format has changed.</para>
    /// </summary>
    public event Action FormatChanged
    {
        add => Connect(SignalName.FormatChanged, Callable.From(value));
        remove => Disconnect(SignalName.FormatChanged, Callable.From(value));
    }

    protected void EmitSignalFormatChanged()
    {
        EmitSignal(SignalName.FormatChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__activate_feed = "_ActivateFeed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__deactivate_feed = "_DeactivateFeed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_frame_changed = "FrameChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_format_changed = "FormatChanged";

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
        if ((method == MethodProxyName__activate_feed || method == MethodName._ActivateFeed) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__activate_feed.NativeValue))
        {
            var callRet = _ActivateFeed();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__deactivate_feed || method == MethodName._DeactivateFeed) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__deactivate_feed.NativeValue))
        {
            _DeactivateFeed();
            ret = default;
            return true;
        }
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
        if (method == MethodName._ActivateFeed)
        {
            if (HasGodotClassMethod(MethodProxyName__activate_feed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DeactivateFeed)
        {
            if (HasGodotClassMethod(MethodProxyName__deactivate_feed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.FrameChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_frame_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FormatChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_format_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'feed_is_active' property.
        /// </summary>
        public static readonly StringName FeedIsActive = "feed_is_active";
        /// <summary>
        /// Cached name for the 'feed_transform' property.
        /// </summary>
        public static readonly StringName FeedTransform = "feed_transform";
        /// <summary>
        /// Cached name for the 'formats' property.
        /// </summary>
        public static readonly StringName Formats = "formats";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_activate_feed' method.
        /// </summary>
        public static readonly StringName _ActivateFeed = "_activate_feed";
        /// <summary>
        /// Cached name for the '_deactivate_feed' method.
        /// </summary>
        public static readonly StringName _DeactivateFeed = "_deactivate_feed";
        /// <summary>
        /// Cached name for the 'get_id' method.
        /// </summary>
        public static readonly StringName GetId = "get_id";
        /// <summary>
        /// Cached name for the 'is_active' method.
        /// </summary>
        public static readonly StringName IsActive = "is_active";
        /// <summary>
        /// Cached name for the 'set_active' method.
        /// </summary>
        public static readonly StringName SetActive = "set_active";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'set_name' method.
        /// </summary>
        public static readonly StringName SetName = "set_name";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'set_rgb_image' method.
        /// </summary>
        public static readonly StringName SetRgbImage = "set_rgb_image";
        /// <summary>
        /// Cached name for the 'set_ycbcr_image' method.
        /// </summary>
        public static readonly StringName SetYcbcrImage = "set_ycbcr_image";
        /// <summary>
        /// Cached name for the 'set_ycbcr_images' method.
        /// </summary>
        public static readonly StringName SetYcbcrImages = "set_ycbcr_images";
        /// <summary>
        /// Cached name for the 'set_external' method.
        /// </summary>
        public static readonly StringName SetExternal = "set_external";
        /// <summary>
        /// Cached name for the 'get_texture_tex_id' method.
        /// </summary>
        public static readonly StringName GetTextureTexId = "get_texture_tex_id";
        /// <summary>
        /// Cached name for the 'get_datatype' method.
        /// </summary>
        public static readonly StringName GetDatatype = "get_datatype";
        /// <summary>
        /// Cached name for the 'get_formats' method.
        /// </summary>
        public static readonly StringName GetFormats = "get_formats";
        /// <summary>
        /// Cached name for the 'set_format' method.
        /// </summary>
        public static readonly StringName SetFormat = "set_format";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'frame_changed' signal.
        /// </summary>
        public static readonly StringName FrameChanged = "frame_changed";
        /// <summary>
        /// Cached name for the 'format_changed' signal.
        /// </summary>
        public static readonly StringName FormatChanged = "format_changed";
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The AR/VR server is the heart of our Advanced and Virtual Reality solution and handles all the processing.</para>
/// </summary>
public static partial class XRServer
{
    public enum TrackerType : long
    {
        /// <summary>
        /// <para>The tracker tracks the location of the player's head. This is usually a location centered between the player's eyes. Note that for handheld AR devices this can be the current location of the device.</para>
        /// </summary>
        Head = 1,
        /// <summary>
        /// <para>The tracker tracks the location of a controller.</para>
        /// </summary>
        Controller = 2,
        /// <summary>
        /// <para>The tracker tracks the location of a base station.</para>
        /// </summary>
        Basestation = 4,
        /// <summary>
        /// <para>The tracker tracks the location and size of an AR anchor.</para>
        /// </summary>
        Anchor = 8,
        /// <summary>
        /// <para>The tracker tracks the location and joints of a hand.</para>
        /// </summary>
        Hand = 16,
        /// <summary>
        /// <para>The tracker tracks the location and joints of a body.</para>
        /// </summary>
        Body = 32,
        /// <summary>
        /// <para>The tracker tracks the expressions of a face.</para>
        /// </summary>
        Face = 64,
        /// <summary>
        /// <para>Used internally to filter trackers of any known type.</para>
        /// </summary>
        AnyKnown = 127,
        /// <summary>
        /// <para>Used internally if we haven't set the tracker type yet.</para>
        /// </summary>
        Unknown = 128,
        /// <summary>
        /// <para>Used internally to select all trackers.</para>
        /// </summary>
        Any = 255
    }

    public enum RotationMode : long
    {
        /// <summary>
        /// <para>Fully reset the orientation of the HMD. Regardless of what direction the user is looking to in the real world. The user will look dead ahead in the virtual world.</para>
        /// </summary>
        ResetFullRotation = 0,
        /// <summary>
        /// <para>Resets the orientation but keeps the tilt of the device. So if we're looking down, we keep looking down but heading will be reset.</para>
        /// </summary>
        ResetButKeepTilt = 1,
        /// <summary>
        /// <para>Does not reset the orientation of the HMD, only the position of the player gets centered.</para>
        /// </summary>
        DontResetRotation = 2
    }

    /// <summary>
    /// <para>The scale of the game world compared to the real world. By default, most AR/VR platforms assume that 1 game unit corresponds to 1 real world meter.</para>
    /// </summary>
    public static double WorldScale
    {
        get
        {
            return GetWorldScale();
        }
        set
        {
            SetWorldScale(value);
        }
    }

    /// <summary>
    /// <para>The current origin of our tracking space in the virtual world. This is used by the renderer to properly position the camera with new tracking data.</para>
    /// <para><b>Note:</b> This property is managed by the current <see cref="Godot.XROrigin3D"/> node. It is exposed for access from GDExtensions.</para>
    /// </summary>
    public static Transform3D WorldOrigin
    {
        get
        {
            return GetWorldOrigin();
        }
        set
        {
            SetWorldOrigin(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, the scene will be rendered as if the camera is locked to the <see cref="Godot.XROrigin3D"/>.</para>
    /// <para><b>Note:</b> This doesn't provide a very comfortable experience for users. This setting exists for doing benchmarking or automated testing, where you want to control what is rendered via code.</para>
    /// </summary>
    public static bool CameraLockedToOrigin
    {
        get
        {
            return IsCameraLockedToOrigin();
        }
        set
        {
            SetCameraLockedToOrigin(value);
        }
    }

    /// <summary>
    /// <para>The primary <see cref="Godot.XRInterface"/> currently bound to the <see cref="Godot.XRServer"/>.</para>
    /// </summary>
    public static XRInterface PrimaryInterface
    {
        get
        {
            return GetPrimaryInterface();
        }
        set
        {
            SetPrimaryInterface(value);
        }
    }

    private static readonly StringName NativeName = "XRServer";

    private static XRServerInstance singleton;

    public static XRServerInstance Singleton =>
        singleton ??= (XRServerInstance)InteropUtils.EngineGetSingleton("XRServer");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorldScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static double GetWorldScale()
    {
        return NativeCalls.godot_icall_0_144(MethodBind0, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorldScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetWorldScale(double scale)
    {
        NativeCalls.godot_icall_1_127(MethodBind1, GodotObject.GetPtr(Singleton), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorldOrigin, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Transform3D GetWorldOrigin()
    {
        return NativeCalls.godot_icall_0_192(MethodBind2, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorldOrigin, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static unsafe void SetWorldOrigin(Transform3D worldOrigin)
    {
        NativeCalls.godot_icall_1_648(MethodBind3, GodotObject.GetPtr(Singleton), &worldOrigin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceFrame, 3229777777ul);

    /// <summary>
    /// <para>Returns the reference frame transform. Mostly used internally and exposed for GDExtension build interfaces.</para>
    /// </summary>
    public static Transform3D GetReferenceFrame()
    {
        return NativeCalls.godot_icall_0_192(MethodBind4, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearReferenceFrame, 3218959716ul);

    /// <summary>
    /// <para>Clears the reference frame that was set by previous calls to <see cref="Godot.XRServer.CenterOnHmd(XRServer.RotationMode, bool)"/>.</para>
    /// </summary>
    public static void ClearReferenceFrame()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CenterOnHmd, 1450904707ul);

    /// <summary>
    /// <para>This is an important function to understand correctly. AR and VR platforms all handle positioning slightly differently.</para>
    /// <para>For platforms that do not offer spatial tracking, our origin point <c>(0, 0, 0)</c> is the location of our HMD, but you have little control over the direction the player is facing in the real world.</para>
    /// <para>For platforms that do offer spatial tracking, our origin point depends very much on the system. For OpenVR, our origin point is usually the center of the tracking space, on the ground. For other platforms, it's often the location of the tracking camera.</para>
    /// <para>This method allows you to center your tracker on the location of the HMD. It will take the current location of the HMD and use that to adjust all your tracking data; in essence, realigning the real world to your player's current position in the game world.</para>
    /// <para>For this method to produce usable results, tracking information must be available. This often takes a few frames after starting your game.</para>
    /// <para>You should call this method after a few seconds have passed. For example, when the user requests a realignment of the display holding a designated button on a controller for a short period of time, or when implementing a teleport mechanism.</para>
    /// </summary>
    public static void CenterOnHmd(XRServer.RotationMode rotationMode, bool keepHeight)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(Singleton), (int)rotationMode, keepHeight.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHmdTransform, 4183770049ul);

    /// <summary>
    /// <para>Returns the primary interface's transformation.</para>
    /// </summary>
    public static Transform3D GetHmdTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraLockedToOrigin, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetCameraLockedToOrigin(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCameraLockedToOrigin, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsCameraLockedToOrigin()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInterface, 1898711491ul);

    /// <summary>
    /// <para>Registers an <see cref="Godot.XRInterface"/> object.</para>
    /// </summary>
    public static void AddInterface(XRInterface @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of interfaces currently registered with the AR/VR server. If your project supports multiple AR/VR platforms, you can look through the available interface, and either present the user with a selection or simply try to initialize each interface and use the first one that returns <see langword="true"/>.</para>
    /// </summary>
    public static int GetInterfaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInterface, 1898711491ul);

    /// <summary>
    /// <para>Removes this <paramref name="interface"/>.</para>
    /// </summary>
    public static void RemoveInterface(XRInterface @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterface, 4237347919ul);

    /// <summary>
    /// <para>Returns the interface registered at the given <paramref name="idx"/> index in the list of interfaces.</para>
    /// </summary>
    public static XRInterface GetInterface(int idx)
    {
        return (XRInterface)NativeCalls.godot_icall_1_71(MethodBind13, GodotObject.GetPtr(Singleton), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaces, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of available interfaces the ID and name of each interface.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> GetInterfaces()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind14, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindInterface, 1395192955ul);

    /// <summary>
    /// <para>Finds an interface by its <paramref name="name"/>. For example, if your project uses capabilities of an AR/VR platform, you can find the interface for that platform by name and initialize it.</para>
    /// </summary>
    public static XRInterface FindInterface(string name)
    {
        return (XRInterface)NativeCalls.godot_icall_1_533(MethodBind15, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTracker, 684804553ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.XRTracker"/> that tracks a physical object.</para>
    /// </summary>
    public static void AddTracker(XRTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(tracker));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTracker, 684804553ul);

    /// <summary>
    /// <para>Removes this <paramref name="tracker"/>.</para>
    /// </summary>
    public static void RemoveTracker(XRTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind17, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(tracker));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackers, 3554694381ul);

    /// <summary>
    /// <para>Returns a dictionary of trackers for <paramref name="trackerTypes"/>.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetTrackers(int trackerTypes)
    {
        return NativeCalls.godot_icall_1_307(MethodBind18, GodotObject.GetPtr(Singleton), trackerTypes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTracker, 147382240ul);

    /// <summary>
    /// <para>Returns the positional tracker with the given <paramref name="trackerName"/>.</para>
    /// </summary>
    public static XRTracker GetTracker(StringName trackerName)
    {
        return (XRTracker)NativeCalls.godot_icall_1_119(MethodBind19, GodotObject.GetPtr(Singleton), (godot_string_name)(trackerName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryInterface, 2143545064ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static XRInterface GetPrimaryInterface()
    {
        return (XRInterface)NativeCalls.godot_icall_0_63(MethodBind20, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryInterface, 1898711491ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPrimaryInterface(XRInterface @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind21, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTracker, 2692800323ul);

    /// <summary>
    /// <para>Removes this <paramref name="tracker"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void RemoveTracker(XRPositionalTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind22, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(tracker));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTracker, 2692800323ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.XRTracker"/> that tracks a physical object.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void AddTracker(XRPositionalTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind23, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(tracker));
    }

    /// <summary>
    /// <para>Emitted when the reference frame transform changes.</para>
    /// </summary>
    public static event Action ReferenceFrameChanged
    {
        add => Singleton.Connect(SignalName.ReferenceFrameChanged, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.ReferenceFrameChanged, Callable.From(value));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServer.InterfaceAdded"/> event of a <see cref="Godot.XRServer"/> class.
    /// </summary>
    public delegate void InterfaceAddedEventHandler(StringName interfaceName);

    private static void InterfaceAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((InterfaceAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a new interface has been added.</para>
    /// </summary>
    public static unsafe event InterfaceAddedEventHandler InterfaceAdded
    {
        add => Singleton.Connect(SignalName.InterfaceAdded, Callable.CreateWithUnsafeTrampoline(value, &InterfaceAddedTrampoline));
        remove => Singleton.Disconnect(SignalName.InterfaceAdded, Callable.CreateWithUnsafeTrampoline(value, &InterfaceAddedTrampoline));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServer.InterfaceRemoved"/> event of a <see cref="Godot.XRServer"/> class.
    /// </summary>
    public delegate void InterfaceRemovedEventHandler(StringName interfaceName);

    private static void InterfaceRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((InterfaceRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an interface is removed.</para>
    /// </summary>
    public static unsafe event InterfaceRemovedEventHandler InterfaceRemoved
    {
        add => Singleton.Connect(SignalName.InterfaceRemoved, Callable.CreateWithUnsafeTrampoline(value, &InterfaceRemovedTrampoline));
        remove => Singleton.Disconnect(SignalName.InterfaceRemoved, Callable.CreateWithUnsafeTrampoline(value, &InterfaceRemovedTrampoline));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServer.TrackerAdded"/> event of a <see cref="Godot.XRServer"/> class.
    /// </summary>
    public delegate void TrackerAddedEventHandler(StringName trackerName, long type);

    private static void TrackerAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((TrackerAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a new tracker has been added. If you don't use a fixed number of controllers or if you're using <see cref="Godot.XRAnchor3D"/>s for an AR solution, it is important to react to this signal to add the appropriate <see cref="Godot.XRController3D"/> or <see cref="Godot.XRAnchor3D"/> nodes related to this new tracker.</para>
    /// </summary>
    public static unsafe event TrackerAddedEventHandler TrackerAdded
    {
        add => Singleton.Connect(SignalName.TrackerAdded, Callable.CreateWithUnsafeTrampoline(value, &TrackerAddedTrampoline));
        remove => Singleton.Disconnect(SignalName.TrackerAdded, Callable.CreateWithUnsafeTrampoline(value, &TrackerAddedTrampoline));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServer.TrackerUpdated"/> event of a <see cref="Godot.XRServer"/> class.
    /// </summary>
    public delegate void TrackerUpdatedEventHandler(StringName trackerName, long type);

    private static void TrackerUpdatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((TrackerUpdatedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an existing tracker has been updated. This can happen if the user switches controllers.</para>
    /// </summary>
    public static unsafe event TrackerUpdatedEventHandler TrackerUpdated
    {
        add => Singleton.Connect(SignalName.TrackerUpdated, Callable.CreateWithUnsafeTrampoline(value, &TrackerUpdatedTrampoline));
        remove => Singleton.Disconnect(SignalName.TrackerUpdated, Callable.CreateWithUnsafeTrampoline(value, &TrackerUpdatedTrampoline));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServer.TrackerRemoved"/> event of a <see cref="Godot.XRServer"/> class.
    /// </summary>
    public delegate void TrackerRemovedEventHandler(StringName trackerName, long type);

    private static void TrackerRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((TrackerRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tracker is removed. You should remove any <see cref="Godot.XRController3D"/> or <see cref="Godot.XRAnchor3D"/> points if applicable. This is not mandatory, the nodes simply become inactive and will be made active again when a new tracker becomes available (i.e. a new controller is switched on that takes the place of the previous one).</para>
    /// </summary>
    public static unsafe event TrackerRemovedEventHandler TrackerRemoved
    {
        add => Singleton.Connect(SignalName.TrackerRemoved, Callable.CreateWithUnsafeTrampoline(value, &TrackerRemovedTrampoline));
        remove => Singleton.Disconnect(SignalName.TrackerRemoved, Callable.CreateWithUnsafeTrampoline(value, &TrackerRemovedTrampoline));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'world_scale' property.
        /// </summary>
        public static readonly StringName WorldScale = "world_scale";
        /// <summary>
        /// Cached name for the 'world_origin' property.
        /// </summary>
        public static readonly StringName WorldOrigin = "world_origin";
        /// <summary>
        /// Cached name for the 'camera_locked_to_origin' property.
        /// </summary>
        public static readonly StringName CameraLockedToOrigin = "camera_locked_to_origin";
        /// <summary>
        /// Cached name for the 'primary_interface' property.
        /// </summary>
        public static readonly StringName PrimaryInterface = "primary_interface";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'get_world_scale' method.
        /// </summary>
        public static readonly StringName GetWorldScale = "get_world_scale";
        /// <summary>
        /// Cached name for the 'set_world_scale' method.
        /// </summary>
        public static readonly StringName SetWorldScale = "set_world_scale";
        /// <summary>
        /// Cached name for the 'get_world_origin' method.
        /// </summary>
        public static readonly StringName GetWorldOrigin = "get_world_origin";
        /// <summary>
        /// Cached name for the 'set_world_origin' method.
        /// </summary>
        public static readonly StringName SetWorldOrigin = "set_world_origin";
        /// <summary>
        /// Cached name for the 'get_reference_frame' method.
        /// </summary>
        public static readonly StringName GetReferenceFrame = "get_reference_frame";
        /// <summary>
        /// Cached name for the 'clear_reference_frame' method.
        /// </summary>
        public static readonly StringName ClearReferenceFrame = "clear_reference_frame";
        /// <summary>
        /// Cached name for the 'center_on_hmd' method.
        /// </summary>
        public static readonly StringName CenterOnHmd = "center_on_hmd";
        /// <summary>
        /// Cached name for the 'get_hmd_transform' method.
        /// </summary>
        public static readonly StringName GetHmdTransform = "get_hmd_transform";
        /// <summary>
        /// Cached name for the 'set_camera_locked_to_origin' method.
        /// </summary>
        public static readonly StringName SetCameraLockedToOrigin = "set_camera_locked_to_origin";
        /// <summary>
        /// Cached name for the 'is_camera_locked_to_origin' method.
        /// </summary>
        public static readonly StringName IsCameraLockedToOrigin = "is_camera_locked_to_origin";
        /// <summary>
        /// Cached name for the 'add_interface' method.
        /// </summary>
        public static readonly StringName AddInterface = "add_interface";
        /// <summary>
        /// Cached name for the 'get_interface_count' method.
        /// </summary>
        public static readonly StringName GetInterfaceCount = "get_interface_count";
        /// <summary>
        /// Cached name for the 'remove_interface' method.
        /// </summary>
        public static readonly StringName RemoveInterface = "remove_interface";
        /// <summary>
        /// Cached name for the 'get_interface' method.
        /// </summary>
        public static readonly StringName GetInterface = "get_interface";
        /// <summary>
        /// Cached name for the 'get_interfaces' method.
        /// </summary>
        public static readonly StringName GetInterfaces = "get_interfaces";
        /// <summary>
        /// Cached name for the 'find_interface' method.
        /// </summary>
        public static readonly StringName FindInterface = "find_interface";
        /// <summary>
        /// Cached name for the 'add_tracker' method.
        /// </summary>
        public static readonly StringName AddTracker = "add_tracker";
        /// <summary>
        /// Cached name for the 'remove_tracker' method.
        /// </summary>
        public static readonly StringName RemoveTracker = "remove_tracker";
        /// <summary>
        /// Cached name for the 'get_trackers' method.
        /// </summary>
        public static readonly StringName GetTrackers = "get_trackers";
        /// <summary>
        /// Cached name for the 'get_tracker' method.
        /// </summary>
        public static readonly StringName GetTracker = "get_tracker";
        /// <summary>
        /// Cached name for the 'get_primary_interface' method.
        /// </summary>
        public static readonly StringName GetPrimaryInterface = "get_primary_interface";
        /// <summary>
        /// Cached name for the 'set_primary_interface' method.
        /// </summary>
        public static readonly StringName SetPrimaryInterface = "set_primary_interface";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'reference_frame_changed' signal.
        /// </summary>
        public static readonly StringName ReferenceFrameChanged = "reference_frame_changed";
        /// <summary>
        /// Cached name for the 'interface_added' signal.
        /// </summary>
        public static readonly StringName InterfaceAdded = "interface_added";
        /// <summary>
        /// Cached name for the 'interface_removed' signal.
        /// </summary>
        public static readonly StringName InterfaceRemoved = "interface_removed";
        /// <summary>
        /// Cached name for the 'tracker_added' signal.
        /// </summary>
        public static readonly StringName TrackerAdded = "tracker_added";
        /// <summary>
        /// Cached name for the 'tracker_updated' signal.
        /// </summary>
        public static readonly StringName TrackerUpdated = "tracker_updated";
        /// <summary>
        /// Cached name for the 'tracker_removed' signal.
        /// </summary>
        public static readonly StringName TrackerRemoved = "tracker_removed";
    }
}

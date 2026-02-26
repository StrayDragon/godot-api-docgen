namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The AR/VR server is the heart of our Advanced and Virtual Reality solution and handles all the processing.</para>
/// </summary>
[GodotClassName("XRServer")]
public partial class XRServerInstance : GodotObject
{
    /// <summary>
    /// <para>The scale of the game world compared to the real world. By default, most AR/VR platforms assume that 1 game unit corresponds to 1 real world meter.</para>
    /// </summary>
    public double WorldScale
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
    public Transform3D WorldOrigin
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
    public bool CameraLockedToOrigin
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
    public XRInterface PrimaryInterface
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

    private static readonly System.Type CachedType = typeof(XRServerInstance);

    private static readonly StringName NativeName = "XRServer";

    internal XRServerInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRServerInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRServerInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorldScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetWorldScale()
    {
        return NativeCalls.godot_icall_0_144(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorldScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWorldScale(double scale)
    {
        NativeCalls.godot_icall_1_127(MethodBind1, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorldOrigin, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetWorldOrigin()
    {
        return NativeCalls.godot_icall_0_192(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorldOrigin, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetWorldOrigin(Transform3D worldOrigin)
    {
        NativeCalls.godot_icall_1_648(MethodBind3, GodotObject.GetPtr(this), &worldOrigin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceFrame, 3229777777ul);

    /// <summary>
    /// <para>Returns the reference frame transform. Mostly used internally and exposed for GDExtension build interfaces.</para>
    /// </summary>
    public Transform3D GetReferenceFrame()
    {
        return NativeCalls.godot_icall_0_192(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearReferenceFrame, 3218959716ul);

    /// <summary>
    /// <para>Clears the reference frame that was set by previous calls to <see cref="Godot.XRServerInstance.CenterOnHmd(XRServer.RotationMode, bool)"/>.</para>
    /// </summary>
    public void ClearReferenceFrame()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CenterOnHmd, 1450904707ul);

    /// <summary>
    /// <para>This is an important function to understand correctly. AR and VR platforms all handle positioning slightly differently.</para>
    /// <para>For platforms that do not offer spatial tracking, our origin point <c>(0, 0, 0)</c> is the location of our HMD, but you have little control over the direction the player is facing in the real world.</para>
    /// <para>For platforms that do offer spatial tracking, our origin point depends very much on the system. For OpenVR, our origin point is usually the center of the tracking space, on the ground. For other platforms, it's often the location of the tracking camera.</para>
    /// <para>This method allows you to center your tracker on the location of the HMD. It will take the current location of the HMD and use that to adjust all your tracking data; in essence, realigning the real world to your player's current position in the game world.</para>
    /// <para>For this method to produce usable results, tracking information must be available. This often takes a few frames after starting your game.</para>
    /// <para>You should call this method after a few seconds have passed. For example, when the user requests a realignment of the display holding a designated button on a controller for a short period of time, or when implementing a teleport mechanism.</para>
    /// </summary>
    public void CenterOnHmd(XRServer.RotationMode rotationMode, bool keepHeight)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), (int)rotationMode, keepHeight.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHmdTransform, 4183770049ul);

    /// <summary>
    /// <para>Returns the primary interface's transformation.</para>
    /// </summary>
    public Transform3D GetHmdTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraLockedToOrigin, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraLockedToOrigin(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCameraLockedToOrigin, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCameraLockedToOrigin()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInterface, 1898711491ul);

    /// <summary>
    /// <para>Registers an <see cref="Godot.XRInterface"/> object.</para>
    /// </summary>
    public void AddInterface(XRInterface @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of interfaces currently registered with the AR/VR server. If your project supports multiple AR/VR platforms, you can look through the available interface, and either present the user with a selection or simply try to initialize each interface and use the first one that returns <see langword="true"/>.</para>
    /// </summary>
    public int GetInterfaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInterface, 1898711491ul);

    /// <summary>
    /// <para>Removes this <paramref name="interface"/>.</para>
    /// </summary>
    public void RemoveInterface(XRInterface @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterface, 4237347919ul);

    /// <summary>
    /// <para>Returns the interface registered at the given <paramref name="idx"/> index in the list of interfaces.</para>
    /// </summary>
    public XRInterface GetInterface(int idx)
    {
        return (XRInterface)NativeCalls.godot_icall_1_71(MethodBind13, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaces, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of available interfaces the ID and name of each interface.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetInterfaces()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind14, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindInterface, 1395192955ul);

    /// <summary>
    /// <para>Finds an interface by its <paramref name="name"/>. For example, if your project uses capabilities of an AR/VR platform, you can find the interface for that platform by name and initialize it.</para>
    /// </summary>
    public XRInterface FindInterface(string name)
    {
        return (XRInterface)NativeCalls.godot_icall_1_533(MethodBind15, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTracker, 684804553ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.XRTracker"/> that tracks a physical object.</para>
    /// </summary>
    public void AddTracker(XRTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(tracker));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTracker, 684804553ul);

    /// <summary>
    /// <para>Removes this <paramref name="tracker"/>.</para>
    /// </summary>
    public void RemoveTracker(XRTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind17, GodotObject.GetPtr(this), GodotObject.GetPtr(tracker));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackers, 3554694381ul);

    /// <summary>
    /// <para>Returns a dictionary of trackers for <paramref name="trackerTypes"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetTrackers(int trackerTypes)
    {
        return NativeCalls.godot_icall_1_307(MethodBind18, GodotObject.GetPtr(this), trackerTypes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTracker, 147382240ul);

    /// <summary>
    /// <para>Returns the positional tracker with the given <paramref name="trackerName"/>.</para>
    /// </summary>
    public XRTracker GetTracker(StringName trackerName)
    {
        return (XRTracker)NativeCalls.godot_icall_1_119(MethodBind19, GodotObject.GetPtr(this), (godot_string_name)(trackerName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryInterface, 2143545064ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRInterface GetPrimaryInterface()
    {
        return (XRInterface)NativeCalls.godot_icall_0_63(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryInterface, 1898711491ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryInterface(XRInterface @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind21, GodotObject.GetPtr(this), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTracker, 2692800323ul);

    /// <summary>
    /// <para>Removes this <paramref name="tracker"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void RemoveTracker(XRPositionalTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind22, GodotObject.GetPtr(this), GodotObject.GetPtr(tracker));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTracker, 2692800323ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.XRTracker"/> that tracks a physical object.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddTracker(XRPositionalTracker tracker)
    {
        NativeCalls.godot_icall_1_56(MethodBind23, GodotObject.GetPtr(this), GodotObject.GetPtr(tracker));
    }

    /// <summary>
    /// <para>Emitted when the reference frame transform changes.</para>
    /// </summary>
    public event Action ReferenceFrameChanged
    {
        add => Connect(SignalName.ReferenceFrameChanged, Callable.From(value));
        remove => Disconnect(SignalName.ReferenceFrameChanged, Callable.From(value));
    }

    protected void EmitSignalReferenceFrameChanged()
    {
        EmitSignal(SignalName.ReferenceFrameChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServerInstance.InterfaceAdded"/> event of a <see cref="Godot.XRServerInstance"/> class.
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
    public unsafe event InterfaceAddedEventHandler InterfaceAdded
    {
        add => Connect(SignalName.InterfaceAdded, Callable.CreateWithUnsafeTrampoline(value, &InterfaceAddedTrampoline));
        remove => Disconnect(SignalName.InterfaceAdded, Callable.CreateWithUnsafeTrampoline(value, &InterfaceAddedTrampoline));
    }

    protected void EmitSignalInterfaceAdded(StringName interfaceName)
    {
        EmitSignal(SignalName.InterfaceAdded, interfaceName);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServerInstance.InterfaceRemoved"/> event of a <see cref="Godot.XRServerInstance"/> class.
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
    public unsafe event InterfaceRemovedEventHandler InterfaceRemoved
    {
        add => Connect(SignalName.InterfaceRemoved, Callable.CreateWithUnsafeTrampoline(value, &InterfaceRemovedTrampoline));
        remove => Disconnect(SignalName.InterfaceRemoved, Callable.CreateWithUnsafeTrampoline(value, &InterfaceRemovedTrampoline));
    }

    protected void EmitSignalInterfaceRemoved(StringName interfaceName)
    {
        EmitSignal(SignalName.InterfaceRemoved, interfaceName);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServerInstance.TrackerAdded"/> event of a <see cref="Godot.XRServerInstance"/> class.
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
    public unsafe event TrackerAddedEventHandler TrackerAdded
    {
        add => Connect(SignalName.TrackerAdded, Callable.CreateWithUnsafeTrampoline(value, &TrackerAddedTrampoline));
        remove => Disconnect(SignalName.TrackerAdded, Callable.CreateWithUnsafeTrampoline(value, &TrackerAddedTrampoline));
    }

    protected void EmitSignalTrackerAdded(StringName trackerName, long type)
    {
        EmitSignal(SignalName.TrackerAdded, trackerName, type);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServerInstance.TrackerUpdated"/> event of a <see cref="Godot.XRServerInstance"/> class.
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
    public unsafe event TrackerUpdatedEventHandler TrackerUpdated
    {
        add => Connect(SignalName.TrackerUpdated, Callable.CreateWithUnsafeTrampoline(value, &TrackerUpdatedTrampoline));
        remove => Disconnect(SignalName.TrackerUpdated, Callable.CreateWithUnsafeTrampoline(value, &TrackerUpdatedTrampoline));
    }

    protected void EmitSignalTrackerUpdated(StringName trackerName, long type)
    {
        EmitSignal(SignalName.TrackerUpdated, trackerName, type);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRServerInstance.TrackerRemoved"/> event of a <see cref="Godot.XRServerInstance"/> class.
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
    public unsafe event TrackerRemovedEventHandler TrackerRemoved
    {
        add => Connect(SignalName.TrackerRemoved, Callable.CreateWithUnsafeTrampoline(value, &TrackerRemovedTrampoline));
        remove => Disconnect(SignalName.TrackerRemoved, Callable.CreateWithUnsafeTrampoline(value, &TrackerRemovedTrampoline));
    }

    protected void EmitSignalTrackerRemoved(StringName trackerName, long type)
    {
        EmitSignal(SignalName.TrackerRemoved, trackerName, type);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_reference_frame_changed = "ReferenceFrameChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_interface_added = "InterfaceAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_interface_removed = "InterfaceRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tracker_added = "TrackerAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tracker_updated = "TrackerUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tracker_removed = "TrackerRemoved";

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
        if (signal == SignalName.ReferenceFrameChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_reference_frame_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.InterfaceAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_interface_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.InterfaceRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_interface_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TrackerAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_tracker_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TrackerUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_tracker_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TrackerRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_tracker_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GodotObject.PropertyName
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
    public new class MethodName : GodotObject.MethodName
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
    public new class SignalName : GodotObject.SignalName
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

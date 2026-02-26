namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object is the base of all XR trackers.</para>
/// </summary>
public partial class XRTracker : RefCounted
{
    /// <summary>
    /// <para>The type of tracker.</para>
    /// </summary>
    public XRServer.TrackerType Type
    {
        get
        {
            return GetTrackerType();
        }
        set
        {
            SetTrackerType(value);
        }
    }

    /// <summary>
    /// <para>The unique name of this tracker. The trackers that are available differ between various XR runtimes and can often be configured by the user. Godot maintains a number of reserved names that it expects the <see cref="Godot.XRInterface"/> to implement if applicable:</para>
    /// <para>- <c>"head"</c> identifies the <see cref="Godot.XRPositionalTracker"/> of the player's head</para>
    /// <para>- <c>"left_hand"</c> identifies the <see cref="Godot.XRControllerTracker"/> in the player's left hand</para>
    /// <para>- <c>"right_hand"</c> identifies the <see cref="Godot.XRControllerTracker"/> in the player's right hand</para>
    /// <para>- <c>"/user/hand_tracker/left"</c> identifies the <see cref="Godot.XRHandTracker"/> for the player's left hand</para>
    /// <para>- <c>"/user/hand_tracker/right"</c> identifies the <see cref="Godot.XRHandTracker"/> for the player's right hand</para>
    /// <para>- <c>"/user/body_tracker"</c> identifies the <see cref="Godot.XRBodyTracker"/> for the player's body</para>
    /// <para>- <c>"/user/face_tracker"</c> identifies the <see cref="Godot.XRFaceTracker"/> for the player's face</para>
    /// </summary>
    public StringName Name
    {
        get
        {
            return GetTrackerName();
        }
        set
        {
            SetTrackerName(value);
        }
    }

    /// <summary>
    /// <para>The description of this tracker.</para>
    /// </summary>
    public string Description
    {
        get
        {
            return GetTrackerDesc();
        }
        set
        {
            SetTrackerDesc(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRTracker);

    private static readonly StringName NativeName = "XRTracker";

    internal XRTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackerType, 2784508102ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRServer.TrackerType GetTrackerType()
    {
        return (XRServer.TrackerType)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrackerType, 3055763575ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrackerType(XRServer.TrackerType type)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackerName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetTrackerName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrackerName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrackerName(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackerDesc, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTrackerDesc()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrackerDesc, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrackerDesc(string description)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), description);
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'type' property.
        /// </summary>
        public static readonly StringName Type = "type";
        /// <summary>
        /// Cached name for the 'name' property.
        /// </summary>
        public static readonly StringName Name = "name";
        /// <summary>
        /// Cached name for the 'description' property.
        /// </summary>
        public static readonly StringName Description = "description";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_tracker_type' method.
        /// </summary>
        public static readonly StringName GetTrackerType = "get_tracker_type";
        /// <summary>
        /// Cached name for the 'set_tracker_type' method.
        /// </summary>
        public static readonly StringName SetTrackerType = "set_tracker_type";
        /// <summary>
        /// Cached name for the 'get_tracker_name' method.
        /// </summary>
        public static readonly StringName GetTrackerName = "get_tracker_name";
        /// <summary>
        /// Cached name for the 'set_tracker_name' method.
        /// </summary>
        public static readonly StringName SetTrackerName = "set_tracker_name";
        /// <summary>
        /// Cached name for the 'get_tracker_desc' method.
        /// </summary>
        public static readonly StringName GetTrackerDesc = "get_tracker_desc";
        /// <summary>
        /// Cached name for the 'set_tracker_desc' method.
        /// </summary>
        public static readonly StringName SetTrackerDesc = "set_tracker_desc";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Positional tracker for our OpenXR spatial entity anchor extension, it tracks a user defined location in real space and maps it to our virtual space.</para>
/// </summary>
public partial class OpenXRAnchorTracker : OpenXRSpatialEntityTracker
{
    /// <summary>
    /// <para>The UUID provided for persistent anchors.</para>
    /// </summary>
    public string Uuid
    {
        get
        {
            return GetUuid();
        }
        set
        {
            SetUuid(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRAnchorTracker);

    private static readonly StringName NativeName = "OpenXRAnchorTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRAnchorTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRAnchorTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRAnchorTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasUuid, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a non-zero UUID is set.</para>
    /// </summary>
    public bool HasUuid()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUuid, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUuid(string uuid)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), uuid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUuid, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetUuid()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the UUID for this anchor was changed.</para>
    /// </summary>
    public event Action UuidChanged
    {
        add => Connect(SignalName.UuidChanged, Callable.From(value));
        remove => Disconnect(SignalName.UuidChanged, Callable.From(value));
    }

    protected void EmitSignalUuidChanged()
    {
        EmitSignal(SignalName.UuidChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_uuid_changed = "UuidChanged";

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
        if (signal == SignalName.UuidChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_uuid_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : OpenXRSpatialEntityTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'uuid' property.
        /// </summary>
        public static readonly StringName Uuid = "uuid";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialEntityTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'has_uuid' method.
        /// </summary>
        public static readonly StringName HasUuid = "has_uuid";
        /// <summary>
        /// Cached name for the 'set_uuid' method.
        /// </summary>
        public static readonly StringName SetUuid = "set_uuid";
        /// <summary>
        /// Cached name for the 'get_uuid' method.
        /// </summary>
        public static readonly StringName GetUuid = "get_uuid";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialEntityTracker.SignalName
    {
        /// <summary>
        /// Cached name for the 'uuid_changed' signal.
        /// </summary>
        public static readonly StringName UuidChanged = "uuid_changed";
    }
}

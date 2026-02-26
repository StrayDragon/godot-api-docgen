namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Utility class which holds a reference to the internal identifier of an <see cref="Godot.GodotObject"/> instance, as given by <see cref="Godot.GodotObject.GetInstanceId()"/>. This ID can then be used to retrieve the object instance with <c>@GlobalScope.instance_from_id</c>.</para>
/// <para>This class is used internally by the editor inspector and script debugger, but can also be used in plugins to pass and display objects as their IDs.</para>
/// </summary>
[GodotClassName("EncodedObjectAsID")]
public partial class EncodedObjectAsId : RefCounted
{
    /// <summary>
    /// <para>The <see cref="Godot.GodotObject"/> identifier stored in this <see cref="Godot.EncodedObjectAsId"/> instance. The object instance can be retrieved with <c>@GlobalScope.instance_from_id</c>.</para>
    /// </summary>
    public ulong ObjectId
    {
        get
        {
            return GetObjectId();
        }
        set
        {
            SetObjectId(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EncodedObjectAsId);

    private static readonly StringName NativeName = "EncodedObjectAsID";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EncodedObjectAsId() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EncodedObjectAsId(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EncodedObjectAsId(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetObjectId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetObjectId(ulong id)
    {
        NativeCalls.godot_icall_1_544(MethodBind0, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetObjectId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ulong GetObjectId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'object_id' property.
        /// </summary>
        public static readonly StringName ObjectId = "object_id";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_object_id' method.
        /// </summary>
        public static readonly StringName SetObjectId = "set_object_id";
        /// <summary>
        /// Cached name for the 'get_object_id' method.
        /// </summary>
        public static readonly StringName GetObjectId = "get_object_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

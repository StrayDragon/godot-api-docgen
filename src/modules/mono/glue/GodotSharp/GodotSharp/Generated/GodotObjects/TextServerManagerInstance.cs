namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.TextServerManager"/> is the API backend for loading, enumerating, and switching <see cref="Godot.TextServer"/>s.</para>
/// <para><b>Note:</b> Switching text server at runtime is possible, but will invalidate all fonts and text buffers. Make sure to unload all controls, fonts, and themes before doing so.</para>
/// </summary>
[GodotClassName("TextServerManager")]
public partial class TextServerManagerInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(TextServerManagerInstance);

    private static readonly StringName NativeName = "TextServerManager";

    internal TextServerManagerInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextServerManagerInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextServerManagerInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInterface, 1799689403ul);

    /// <summary>
    /// <para>Registers a <see cref="Godot.TextServer"/> interface.</para>
    /// </summary>
    public void AddInterface(TextServer @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of interfaces currently registered.</para>
    /// </summary>
    public int GetInterfaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInterface, 1799689403ul);

    /// <summary>
    /// <para>Removes an interface. All fonts and shaped text caches should be freed before removing an interface.</para>
    /// </summary>
    public void RemoveInterface(TextServer @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterface, 1672475555ul);

    /// <summary>
    /// <para>Returns the interface registered at a given index.</para>
    /// </summary>
    public TextServer GetInterface(int idx)
    {
        return (TextServer)NativeCalls.godot_icall_1_71(MethodBind3, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaces, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of available interfaces, with the index and name of each interface.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetInterfaces()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindInterface, 2240905781ul);

    /// <summary>
    /// <para>Finds an interface by its <paramref name="name"/>.</para>
    /// </summary>
    public TextServer FindInterface(string name)
    {
        return (TextServer)NativeCalls.godot_icall_1_533(MethodBind5, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryInterface, 1799689403ul);

    /// <summary>
    /// <para>Sets the primary <see cref="Godot.TextServer"/> interface.</para>
    /// </summary>
    public void SetPrimaryInterface(TextServer index)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(index));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryInterface, 905850878ul);

    /// <summary>
    /// <para>Returns the primary <see cref="Godot.TextServer"/> interface currently in use.</para>
    /// </summary>
    public TextServer GetPrimaryInterface()
    {
        return (TextServer)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TextServerManagerInstance.InterfaceAdded"/> event of a <see cref="Godot.TextServerManagerInstance"/> class.
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
    /// Represents the method that handles the <see cref="Godot.TextServerManagerInstance.InterfaceRemoved"/> event of a <see cref="Godot.TextServerManagerInstance"/> class.
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

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_interface_added = "InterfaceAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_interface_removed = "InterfaceRemoved";

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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
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
        /// Cached name for the 'set_primary_interface' method.
        /// </summary>
        public static readonly StringName SetPrimaryInterface = "set_primary_interface";
        /// <summary>
        /// Cached name for the 'get_primary_interface' method.
        /// </summary>
        public static readonly StringName GetPrimaryInterface = "get_primary_interface";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'interface_added' signal.
        /// </summary>
        public static readonly StringName InterfaceAdded = "interface_added";
        /// <summary>
        /// Cached name for the 'interface_removed' signal.
        /// </summary>
        public static readonly StringName InterfaceRemoved = "interface_removed";
    }
}

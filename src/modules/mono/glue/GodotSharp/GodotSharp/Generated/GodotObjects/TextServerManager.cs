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
public static partial class TextServerManager
{
    private static readonly StringName NativeName = "TextServerManager";

    private static TextServerManagerInstance singleton;

    public static TextServerManagerInstance Singleton =>
        singleton ??= (TextServerManagerInstance)InteropUtils.EngineGetSingleton("TextServerManager");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInterface, 1799689403ul);

    /// <summary>
    /// <para>Registers a <see cref="Godot.TextServer"/> interface.</para>
    /// </summary>
    public static void AddInterface(TextServer @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of interfaces currently registered.</para>
    /// </summary>
    public static int GetInterfaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInterface, 1799689403ul);

    /// <summary>
    /// <para>Removes an interface. All fonts and shaped text caches should be freed before removing an interface.</para>
    /// </summary>
    public static void RemoveInterface(TextServer @interface)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@interface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterface, 1672475555ul);

    /// <summary>
    /// <para>Returns the interface registered at a given index.</para>
    /// </summary>
    public static TextServer GetInterface(int idx)
    {
        return (TextServer)NativeCalls.godot_icall_1_71(MethodBind3, GodotObject.GetPtr(Singleton), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterfaces, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of available interfaces, with the index and name of each interface.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> GetInterfaces()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindInterface, 2240905781ul);

    /// <summary>
    /// <para>Finds an interface by its <paramref name="name"/>.</para>
    /// </summary>
    public static TextServer FindInterface(string name)
    {
        return (TextServer)NativeCalls.godot_icall_1_533(MethodBind5, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryInterface, 1799689403ul);

    /// <summary>
    /// <para>Sets the primary <see cref="Godot.TextServer"/> interface.</para>
    /// </summary>
    public static void SetPrimaryInterface(TextServer index)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(index));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryInterface, 905850878ul);

    /// <summary>
    /// <para>Returns the primary <see cref="Godot.TextServer"/> interface currently in use.</para>
    /// </summary>
    public static TextServer GetPrimaryInterface()
    {
        return (TextServer)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TextServerManager.InterfaceAdded"/> event of a <see cref="Godot.TextServerManager"/> class.
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
    /// Represents the method that handles the <see cref="Godot.TextServerManager.InterfaceRemoved"/> event of a <see cref="Godot.TextServerManager"/> class.
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
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
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
    public class SignalName
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

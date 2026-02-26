namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.GDExtension"/> resource type represents a <a href="https://en.wikipedia.org/wiki/Shared_library">shared library</a> which can expand the functionality of the engine. The <see cref="Godot.GDExtensionManager"/> singleton is responsible for loading, reloading, and unloading <see cref="Godot.GDExtension"/> resources.</para>
/// <para><b>Note:</b> GDExtension itself is not a scripting language and has no relation to <see cref="Godot.GDScript"/> resources.</para>
/// </summary>
public partial class GDExtension : Resource
{
    public enum InitializationLevel : long
    {
        /// <summary>
        /// <para>The library is initialized at the same time as the core features of the engine.</para>
        /// </summary>
        Core = 0,
        /// <summary>
        /// <para>The library is initialized at the same time as the engine's servers (such as <see cref="Godot.RenderingServer"/> or <see cref="Godot.PhysicsServer3D"/>).</para>
        /// </summary>
        Servers = 1,
        /// <summary>
        /// <para>The library is initialized at the same time as the engine's scene-related classes.</para>
        /// </summary>
        Scene = 2,
        /// <summary>
        /// <para>The library is initialized at the same time as the engine's editor classes. Only happens when loading the GDExtension in the editor.</para>
        /// </summary>
        Editor = 3
    }

    private static readonly System.Type CachedType = typeof(GDExtension);

    private static readonly StringName NativeName = "GDExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GDExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GDExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GDExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLibraryOpen, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this extension's library has been opened.</para>
    /// </summary>
    public bool IsLibraryOpen()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimumLibraryInitializationLevel, 964858755ul);

    /// <summary>
    /// <para>Returns the lowest level required for this extension to be properly initialized (see the <see cref="Godot.GDExtension.InitializationLevel"/> enum).</para>
    /// </summary>
    public GDExtension.InitializationLevel GetMinimumLibraryInitializationLevel()
    {
        return (GDExtension.InitializationLevel)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InitializeLibrary, 3409922941ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void InitializeLibrary(GDExtension.InitializationLevel level)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)level);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CloseLibrary, 3218959716ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void CloseLibrary()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenLibrary, 852856452ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Error OpenLibrary(string path, string entrySymbol)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind4, GodotObject.GetPtr(this), path, entrySymbol);
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
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_library_open' method.
        /// </summary>
        public static readonly StringName IsLibraryOpen = "is_library_open";
        /// <summary>
        /// Cached name for the 'get_minimum_library_initialization_level' method.
        /// </summary>
        public static readonly StringName GetMinimumLibraryInitializationLevel = "get_minimum_library_initialization_level";
        /// <summary>
        /// Cached name for the 'initialize_library' method.
        /// </summary>
        public static readonly StringName InitializeLibrary = "initialize_library";
        /// <summary>
        /// Cached name for the 'close_library' method.
        /// </summary>
        public static readonly StringName CloseLibrary = "close_library";
        /// <summary>
        /// Cached name for the 'open_library' method.
        /// </summary>
        public static readonly StringName OpenLibrary = "open_library";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

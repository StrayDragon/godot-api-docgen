namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.NavigationServer2DManager"/> is the API for registering <see cref="Godot.NavigationServer2D"/> implementations and setting the default implementation.</para>
/// <para><b>Note:</b> It is not possible to switch servers at runtime. This class is only used on startup at the server initialization level.</para>
/// </summary>
[GodotClassName("NavigationServer2DManager")]
public partial class NavigationServer2DManagerInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(NavigationServer2DManagerInstance);

    private static readonly StringName NativeName = "NavigationServer2DManager";

    internal NavigationServer2DManagerInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationServer2DManagerInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationServer2DManagerInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterServer, 2137474292ul);

    /// <summary>
    /// <para>Registers a <see cref="Godot.NavigationServer2D"/> implementation by passing a <paramref name="name"/> and a <see cref="Godot.Callable"/> that returns a <see cref="Godot.NavigationServer2D"/> object.</para>
    /// </summary>
    public void RegisterServer(string name, Callable createCallback)
    {
        NativeCalls.godot_icall_2_519(MethodBind0, GodotObject.GetPtr(this), name, createCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultServer, 2956805083ul);

    /// <summary>
    /// <para>Sets the default <see cref="Godot.NavigationServer2D"/> implementation to the one identified by <paramref name="name"/>, if <paramref name="priority"/> is greater than the priority of the current default implementation.</para>
    /// </summary>
    public void SetDefaultServer(string name, int priority)
    {
        NativeCalls.godot_icall_2_400(MethodBind1, GodotObject.GetPtr(this), name, priority);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'register_server' method.
        /// </summary>
        public static readonly StringName RegisterServer = "register_server";
        /// <summary>
        /// Cached name for the 'set_default_server' method.
        /// </summary>
        public static readonly StringName SetDefaultServer = "set_default_server";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}

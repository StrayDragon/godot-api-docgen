namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Similar to how a <see cref="Godot.WorldEnvironment"/> node can be used to override the environment while a specific scene is loaded, <see cref="Godot.ShaderGlobalsOverride"/> can be used to override global shader parameters temporarily. Once the node is removed, the project-wide values for the global shader parameters are restored. See the <see cref="Godot.RenderingServer"/> <c>global_shader_parameter_*</c> methods for more information.</para>
/// <para><b>Note:</b> Only one <see cref="Godot.ShaderGlobalsOverride"/> can be used per scene. If there is more than one <see cref="Godot.ShaderGlobalsOverride"/> node in the scene tree, only the first node (in tree order) will be taken into account.</para>
/// <para><b>Note:</b> All <see cref="Godot.ShaderGlobalsOverride"/> nodes are made part of a <c>"shader_overrides_group"</c> group when they are added to the scene tree. The currently active <see cref="Godot.ShaderGlobalsOverride"/> node also has a <c>"shader_overrides_group_active"</c> group added to it. You can use this to check which <see cref="Godot.ShaderGlobalsOverride"/> node is currently active.</para>
/// </summary>
public partial class ShaderGlobalsOverride : Node
{
    private static readonly System.Type CachedType = typeof(ShaderGlobalsOverride);

    private static readonly StringName NativeName = "ShaderGlobalsOverride";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ShaderGlobalsOverride() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ShaderGlobalsOverride(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ShaderGlobalsOverride(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : Node.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
    }
}

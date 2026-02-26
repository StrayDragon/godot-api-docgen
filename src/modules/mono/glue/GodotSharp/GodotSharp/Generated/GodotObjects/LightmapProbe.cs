namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.LightmapProbe"/> represents the position of a single manually placed probe for dynamic object lighting with <see cref="Godot.LightmapGI"/>. Lightmap probes affect the lighting of <see cref="Godot.GeometryInstance3D"/>-derived nodes that have their <see cref="Godot.GeometryInstance3D.GIMode"/> set to <see cref="Godot.GeometryInstance3D.GIModeEnum.Dynamic"/>.</para>
/// <para>Typically, <see cref="Godot.LightmapGI"/> probes are placed automatically by setting <see cref="Godot.LightmapGI.GenerateProbesSubdiv"/> to a value other than <see cref="Godot.LightmapGI.GenerateProbes.Disabled"/>. By creating <see cref="Godot.LightmapProbe"/> nodes before baking lightmaps, you can add more probes in specific areas for greater detail, or disable automatic generation and rely only on manually placed probes instead.</para>
/// <para><b>Note:</b> <see cref="Godot.LightmapProbe"/> nodes that are placed after baking lightmaps are ignored by dynamic objects. You must bake lightmaps again after creating or modifying <see cref="Godot.LightmapProbe"/>s for the probes to be effective.</para>
/// </summary>
public partial class LightmapProbe : Node3D
{
    private static readonly System.Type CachedType = typeof(LightmapProbe);

    private static readonly StringName NativeName = "LightmapProbe";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LightmapProbe() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal LightmapProbe(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal LightmapProbe(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : Node3D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}

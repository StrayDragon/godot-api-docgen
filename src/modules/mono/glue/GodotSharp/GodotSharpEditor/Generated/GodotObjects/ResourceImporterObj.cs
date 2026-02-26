namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Unlike <see cref="Godot.ResourceImporterScene"/>, <see cref="Godot.ResourceImporterObj"/> will import a single <see cref="Godot.Mesh"/> resource by default instead of importing a <see cref="Godot.PackedScene"/>. This makes it easier to use the <see cref="Godot.Mesh"/> resource in nodes that expect direct <see cref="Godot.Mesh"/> resources, such as <see cref="Godot.GridMap"/>, <see cref="Godot.GpuParticles3D"/> or <see cref="Godot.CpuParticles3D"/>. Note that it is still possible to save mesh resources from 3D scenes using the <b>Advanced Import Settings</b> dialog, regardless of the source format.</para>
/// <para>See also <see cref="Godot.ResourceImporterScene"/>, which is used for more advanced 3D formats such as glTF.</para>
/// </summary>
[GodotClassName("ResourceImporterOBJ")]
public partial class ResourceImporterObj : ResourceImporter
{
    private static readonly System.Type CachedType = typeof(ResourceImporterObj);

    private static readonly StringName NativeName = "ResourceImporterOBJ";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ResourceImporterObj() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporterObj(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporterObj(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : ResourceImporter.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ResourceImporter.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ResourceImporter.SignalName
    {
    }
}

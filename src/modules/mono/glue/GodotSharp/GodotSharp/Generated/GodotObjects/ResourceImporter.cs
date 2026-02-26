namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is the base class for Godot's resource importers. To implement your own resource importers using editor plugins, see <c>EditorImportPlugin</c>.</para>
/// </summary>
public partial class ResourceImporter : RefCounted
{
    public enum ImportOrder : long
    {
        /// <summary>
        /// <para>The default import order.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>The import order for scenes, which ensures scenes are imported <i>after</i> all other core resources such as textures. Custom importers should generally have an import order lower than <c>100</c> to avoid issues when importing scenes that rely on custom resources.</para>
        /// </summary>
        Scene = 100
    }

    private static readonly System.Type CachedType = typeof(ResourceImporter);

    private static readonly StringName NativeName = "ResourceImporter";

    internal ResourceImporter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporter(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the engine compilation profile editor wants to check what build options an imported resource needs. For example, <c>ResourceImporterDynamicFont</c> has a property called <c>ResourceImporterDynamicFont.multichannel_signed_distance_field</c>, that depends on the engine to be build with the "msdfgen" module. If that resource happened to be a custom one, it would be handled like this:</para>
    /// <para><code>
    /// func _get_build_dependencies(path):
    /// 	var resource = load(path)
    /// 	var dependencies = PackedStringArray()
    /// 
    /// 	if resource.multichannel_signed_distance_field:
    /// 		dependencies.push_back("module_msdfgen_enabled")
    /// 
    /// 	return dependencies
    /// </code></para>
    /// </summary>
    public virtual string[] _GetBuildDependencies(string path)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_build_dependencies = "_GetBuildDependencies";

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
        if ((method == MethodProxyName__get_build_dependencies || method == MethodName._GetBuildDependencies) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_build_dependencies.NativeValue))
        {
            var callRet = _GetBuildDependencies(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
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
        if (method == MethodName._GetBuildDependencies)
        {
            if (HasGodotClassMethod(MethodProxyName__get_build_dependencies.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_build_dependencies' method.
        /// </summary>
        public static readonly StringName _GetBuildDependencies = "_get_build_dependencies";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

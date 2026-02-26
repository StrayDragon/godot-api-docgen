namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorResourceConversionPlugin"/> is invoked when the context menu is brought up for a resource in the editor inspector. Relevant conversion plugins will appear as menu options to convert the given resource to a target type.</para>
/// <para>Below shows an example of a basic plugin that will convert an <see cref="Godot.ImageTexture"/> to a <see cref="Godot.PortableCompressedTexture2D"/>.</para>
/// <para></para>
/// <para>To use an <see cref="Godot.EditorResourceConversionPlugin"/>, register it using the <see cref="Godot.EditorPlugin.AddResourceConversionPlugin(EditorResourceConversionPlugin)"/> method first.</para>
/// </summary>
public partial class EditorResourceConversionPlugin : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorResourceConversionPlugin);

    private static readonly StringName NativeName = "EditorResourceConversionPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorResourceConversionPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorResourceConversionPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorResourceConversionPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Takes an input <see cref="Godot.Resource"/> and converts it to the type given in <see cref="Godot.EditorResourceConversionPlugin._ConvertsTo()"/>. The returned <see cref="Godot.Resource"/> is the result of the conversion, and the input <see cref="Godot.Resource"/> remains unchanged.</para>
    /// </summary>
    public virtual Resource _Convert(Resource resource)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the class name of the target type of <see cref="Godot.Resource"/> that this plugin converts source resources to.</para>
    /// </summary>
    public virtual string _ConvertsTo()
    {
        return default;
    }

    /// <summary>
    /// <para>Called to determine whether a particular <see cref="Godot.Resource"/> can be converted to the target resource type by this plugin.</para>
    /// </summary>
    public virtual bool _Handles(Resource resource)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__convert = "_Convert";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__converts_to = "_ConvertsTo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handles = "_Handles";

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
        if ((method == MethodProxyName__convert || method == MethodName._Convert) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__convert.NativeValue))
        {
            var callRet = _Convert(VariantUtils.ConvertTo<Resource>(args[0]));
            ret = VariantUtils.CreateFrom<Resource>(callRet);
            return true;
        }
        if ((method == MethodProxyName__converts_to || method == MethodName._ConvertsTo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__converts_to.NativeValue))
        {
            var callRet = _ConvertsTo();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__handles || method == MethodName._Handles) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handles.NativeValue))
        {
            var callRet = _Handles(VariantUtils.ConvertTo<Resource>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._Convert)
        {
            if (HasGodotClassMethod(MethodProxyName__convert.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ConvertsTo)
        {
            if (HasGodotClassMethod(MethodProxyName__converts_to.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Handles)
        {
            if (HasGodotClassMethod(MethodProxyName__handles.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_convert' method.
        /// </summary>
        public static readonly StringName _Convert = "_convert";
        /// <summary>
        /// Cached name for the '_converts_to' method.
        /// </summary>
        public static readonly StringName _ConvertsTo = "_converts_to";
        /// <summary>
        /// Cached name for the '_handles' method.
        /// </summary>
        public static readonly StringName _Handles = "_handles";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

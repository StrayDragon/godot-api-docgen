namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class allows for a RenderSceneBuffer implementation to be made in GDExtension.</para>
/// </summary>
public partial class RenderSceneBuffersExtension : RenderSceneBuffers
{
    private static readonly System.Type CachedType = typeof(RenderSceneBuffersExtension);

    private static readonly StringName NativeName = "RenderSceneBuffersExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RenderSceneBuffersExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RenderSceneBuffersExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RenderSceneBuffersExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Implement this in GDExtension to handle the (re)sizing of a viewport.</para>
    /// </summary>
    public virtual void _Configure(RenderSceneBuffersConfiguration config)
    {
    }

    /// <summary>
    /// <para>Implement this in GDExtension to change the anisotropic filtering level.</para>
    /// </summary>
    public virtual void _SetAnisotropicFilteringLevel(int anisotropicFilteringLevel)
    {
    }

    /// <summary>
    /// <para>Implement this in GDExtension to record a new FSR sharpness value.</para>
    /// </summary>
    public virtual void _SetFsrSharpness(float fsrSharpness)
    {
    }

    /// <summary>
    /// <para>Implement this in GDExtension to change the texture mipmap bias.</para>
    /// </summary>
    public virtual void _SetTextureMipmapBias(float textureMipmapBias)
    {
    }

    /// <summary>
    /// <para>Implement this in GDExtension to react to the debanding flag changing.</para>
    /// </summary>
    public virtual void _SetUseDebanding(bool useDebanding)
    {
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__configure = "_Configure";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_anisotropic_filtering_level = "_SetAnisotropicFilteringLevel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_fsr_sharpness = "_SetFsrSharpness";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_texture_mipmap_bias = "_SetTextureMipmapBias";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_use_debanding = "_SetUseDebanding";

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
        if ((method == MethodProxyName__configure || method == MethodName._Configure) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__configure.NativeValue))
        {
            _Configure(VariantUtils.ConvertTo<RenderSceneBuffersConfiguration>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_anisotropic_filtering_level || method == MethodName._SetAnisotropicFilteringLevel) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_anisotropic_filtering_level.NativeValue))
        {
            _SetAnisotropicFilteringLevel(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_fsr_sharpness || method == MethodName._SetFsrSharpness) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_fsr_sharpness.NativeValue))
        {
            _SetFsrSharpness(VariantUtils.ConvertTo<float>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_texture_mipmap_bias || method == MethodName._SetTextureMipmapBias) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_texture_mipmap_bias.NativeValue))
        {
            _SetTextureMipmapBias(VariantUtils.ConvertTo<float>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_use_debanding || method == MethodName._SetUseDebanding) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_use_debanding.NativeValue))
        {
            _SetUseDebanding(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
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
        if (method == MethodName._Configure)
        {
            if (HasGodotClassMethod(MethodProxyName__configure.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetAnisotropicFilteringLevel)
        {
            if (HasGodotClassMethod(MethodProxyName__set_anisotropic_filtering_level.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetFsrSharpness)
        {
            if (HasGodotClassMethod(MethodProxyName__set_fsr_sharpness.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetTextureMipmapBias)
        {
            if (HasGodotClassMethod(MethodProxyName__set_texture_mipmap_bias.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetUseDebanding)
        {
            if (HasGodotClassMethod(MethodProxyName__set_use_debanding.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : RenderSceneBuffers.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RenderSceneBuffers.MethodName
    {
        /// <summary>
        /// Cached name for the '_configure' method.
        /// </summary>
        public static readonly StringName _Configure = "_configure";
        /// <summary>
        /// Cached name for the '_set_anisotropic_filtering_level' method.
        /// </summary>
        public static readonly StringName _SetAnisotropicFilteringLevel = "_set_anisotropic_filtering_level";
        /// <summary>
        /// Cached name for the '_set_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName _SetFsrSharpness = "_set_fsr_sharpness";
        /// <summary>
        /// Cached name for the '_set_texture_mipmap_bias' method.
        /// </summary>
        public static readonly StringName _SetTextureMipmapBias = "_set_texture_mipmap_bias";
        /// <summary>
        /// Cached name for the '_set_use_debanding' method.
        /// </summary>
        public static readonly StringName _SetUseDebanding = "_set_use_debanding";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RenderSceneBuffers.SignalName
    {
    }
}

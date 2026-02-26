namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Binding modifier base class. Subclasses implement various modifiers that alter how an OpenXR runtime processes inputs.</para>
/// </summary>
public partial class OpenXRBindingModifier : Resource
{
    private static readonly System.Type CachedType = typeof(OpenXRBindingModifier);

    private static readonly StringName NativeName = "OpenXRBindingModifier";

    internal OpenXRBindingModifier() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRBindingModifier(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRBindingModifier(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return the description of this class that is used for the title bar of the binding modifier editor.</para>
    /// </summary>
    public virtual string _GetDescription()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the data that is sent to OpenXR when submitting the suggested interacting bindings this modifier is a part of.</para>
    /// <para><b>Note:</b> This must be data compatible with an <c>XrBindingModificationBaseHeaderKHR</c> structure.</para>
    /// </summary>
    public virtual byte[] _GetIPModification()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_description = "_GetDescription";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_ip_modification = "_GetIPModification";

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
        if ((method == MethodProxyName__get_description || method == MethodName._GetDescription) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_description.NativeValue))
        {
            var callRet = _GetDescription();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_ip_modification || method == MethodName._GetIPModification) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_ip_modification.NativeValue))
        {
            var callRet = _GetIPModification();
            ret = VariantUtils.CreateFrom<byte[]>(callRet);
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
        if (method == MethodName._GetDescription)
        {
            if (HasGodotClassMethod(MethodProxyName__get_description.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetIPModification)
        {
            if (HasGodotClassMethod(MethodProxyName__get_ip_modification.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_description' method.
        /// </summary>
        public static readonly StringName _GetDescription = "_get_description";
        /// <summary>
        /// Cached name for the '_get_ip_modification' method.
        /// </summary>
        public static readonly StringName _GetIPModification = "_get_ip_modification";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

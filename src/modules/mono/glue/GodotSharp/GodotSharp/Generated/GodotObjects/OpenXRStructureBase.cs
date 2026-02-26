namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Object for storing OpenXR structure data that is passed when calling into OpenXR APIs.</para>
/// </summary>
public partial class OpenXRStructureBase : RefCounted
{
    /// <summary>
    /// <para>Setting another structure object here chains these structures together to extend the API functionality. Consult the OpenXR documentation for which structures can be used with a given API call.</para>
    /// </summary>
    public OpenXRStructureBase Next
    {
        get
        {
            return GetNext();
        }
        set
        {
            SetNext(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRStructureBase);

    private static readonly StringName NativeName = "OpenXRStructureBase";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRStructureBase() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRStructureBase(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRStructureBase(bool memoryOwn) : base(memoryOwn) { }

    public virtual ulong _GetHeader(ulong next)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructureType, 2455072627ul);

    /// <summary>
    /// <para>Returns the structure type (OpenXR <c>XrStructureType</c>) used for this structure.</para>
    /// </summary>
    public ulong GetStructureType()
    {
        return NativeCalls.godot_icall_0_137(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNext, 334698771ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNext(OpenXRStructureBase entity)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(entity));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNext, 2798796760ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRStructureBase GetNext()
    {
        return (OpenXRStructureBase)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_header = "_GetHeader";

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
        if ((method == MethodProxyName__get_header || method == MethodName._GetHeader) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_header.NativeValue))
        {
            var callRet = _GetHeader(VariantUtils.ConvertTo<ulong>(args[0]));
            ret = VariantUtils.CreateFrom<ulong>(callRet);
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
        if (method == MethodName._GetHeader)
        {
            if (HasGodotClassMethod(MethodProxyName__get_header.NativeValue.DangerousSelfRef))
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
        /// <summary>
        /// Cached name for the 'next' property.
        /// </summary>
        public static readonly StringName Next = "next";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_header' method.
        /// </summary>
        public static readonly StringName _GetHeader = "_get_header";
        /// <summary>
        /// Cached name for the 'get_structure_type' method.
        /// </summary>
        public static readonly StringName GetStructureType = "get_structure_type";
        /// <summary>
        /// Cached name for the 'set_next' method.
        /// </summary>
        public static readonly StringName SetNext = "set_next";
        /// <summary>
        /// Cached name for the 'get_next' method.
        /// </summary>
        public static readonly StringName GetNext = "get_next";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

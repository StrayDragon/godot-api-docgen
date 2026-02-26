namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is an internal editor class intended for keeping data of resources of unknown type (most likely this type was supplied by an extension that is no longer loaded). It can't be manually instantiated or placed in a scene.</para>
/// <para><b>Warning:</b> Ignore missing resources unless you know what you are doing. Existing properties on a missing resource can be freely modified in code, regardless of the type they are intended to be.</para>
/// </summary>
public partial class MissingResource : Resource
{
    /// <summary>
    /// <para>The name of the class this resource was supposed to be (see <see cref="Godot.GodotObject.GetClass()"/>).</para>
    /// </summary>
    public string OriginalClass
    {
        get
        {
            return GetOriginalClass();
        }
        set
        {
            SetOriginalClass(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, allows new properties to be added on top of the existing ones with <see cref="Godot.GodotObject.Set(StringName, Variant)"/>.</para>
    /// </summary>
    public bool RecordingProperties
    {
        get
        {
            return IsRecordingProperties();
        }
        set
        {
            SetRecordingProperties(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MissingResource);

    private static readonly StringName NativeName = "MissingResource";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MissingResource() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MissingResource(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MissingResource(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginalClass, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginalClass(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginalClass, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetOriginalClass()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRecordingProperties, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRecordingProperties(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRecordingProperties, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRecordingProperties()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
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
        /// <summary>
        /// Cached name for the 'original_class' property.
        /// </summary>
        public static readonly StringName OriginalClass = "original_class";
        /// <summary>
        /// Cached name for the 'recording_properties' property.
        /// </summary>
        public static readonly StringName RecordingProperties = "recording_properties";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_original_class' method.
        /// </summary>
        public static readonly StringName SetOriginalClass = "set_original_class";
        /// <summary>
        /// Cached name for the 'get_original_class' method.
        /// </summary>
        public static readonly StringName GetOriginalClass = "get_original_class";
        /// <summary>
        /// Cached name for the 'set_recording_properties' method.
        /// </summary>
        public static readonly StringName SetRecordingProperties = "set_recording_properties";
        /// <summary>
        /// Cached name for the 'is_recording_properties' method.
        /// </summary>
        public static readonly StringName IsRecordingProperties = "is_recording_properties";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

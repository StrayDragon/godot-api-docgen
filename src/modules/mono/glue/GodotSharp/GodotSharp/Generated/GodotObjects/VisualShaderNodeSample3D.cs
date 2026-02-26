namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A virtual class, use the descendants instead.</para>
/// </summary>
public partial class VisualShaderNodeSample3D : VisualShaderNode
{
    public enum SourceEnum : long
    {
        /// <summary>
        /// <para>Creates internal uniform and provides a way to assign it within node.</para>
        /// </summary>
        Texture = 0,
        /// <summary>
        /// <para>Use the uniform texture from sampler port.</para>
        /// </summary>
        Port = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeSample3D.SourceEnum"/> enum.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>An input source type.</para>
    /// </summary>
    public VisualShaderNodeSample3D.SourceEnum Source
    {
        get
        {
            return GetSource();
        }
        set
        {
            SetSource(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeSample3D);

    private static readonly StringName NativeName = "VisualShaderNodeSample3D";

    internal VisualShaderNodeSample3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeSample3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeSample3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSource, 3315130991ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSource(VisualShaderNodeSample3D.SourceEnum value)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSource, 1079494121ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeSample3D.SourceEnum GetSource()
    {
        return (VisualShaderNodeSample3D.SourceEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'source' property.
        /// </summary>
        public static readonly StringName Source = "source";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_source' method.
        /// </summary>
        public static readonly StringName SetSource = "set_source";
        /// <summary>
        /// Cached name for the 'get_source' method.
        /// </summary>
        public static readonly StringName GetSource = "get_source";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}

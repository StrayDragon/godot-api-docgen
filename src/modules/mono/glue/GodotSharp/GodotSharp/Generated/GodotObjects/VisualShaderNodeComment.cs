namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node was replaced by <see cref="Godot.VisualShaderNodeFrame"/> and only exists to preserve compatibility. In the <see cref="Godot.VisualShader"/> editor it behaves exactly like <see cref="Godot.VisualShaderNodeFrame"/>.</para>
/// </summary>
[Obsolete("This class has no function anymore and only exists for compatibility.")]
public partial class VisualShaderNodeComment : VisualShaderNodeFrame
{
    /// <summary>
    /// <para>This property only exists to preserve data authored in earlier versions of Godot. It has currently no function.</para>
    /// </summary>
    public string Description
    {
        get
        {
            return GetDescription();
        }
        set
        {
            SetDescription(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeComment);

    private static readonly StringName NativeName = "VisualShaderNodeComment";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeComment() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeComment(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeComment(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDescription, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDescription(string description)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDescription, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetDescription()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeFrame.PropertyName
    {
        /// <summary>
        /// Cached name for the 'description' property.
        /// </summary>
        public static readonly StringName Description = "description";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeFrame.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_description' method.
        /// </summary>
        public static readonly StringName SetDescription = "set_description";
        /// <summary>
        /// Cached name for the 'get_description' method.
        /// </summary>
        public static readonly StringName GetDescription = "get_description";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeFrame.SignalName
    {
    }
}

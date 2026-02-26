namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Translated to <c>uniform sampler2DArray</c> in the shader language.</para>
/// </summary>
public partial class VisualShaderNodeTexture2DArray : VisualShaderNodeSample3D
{
    /// <summary>
    /// <para>A source texture array. Used if <see cref="Godot.VisualShaderNodeSample3D.Source"/> is set to <see cref="Godot.VisualShaderNodeSample3D.SourceEnum.Texture"/>.</para>
    /// </summary>
    public TextureLayered TextureArray
    {
        get
        {
            return GetTextureArray();
        }
        set
        {
            SetTextureArray(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeTexture2DArray);

    private static readonly StringName NativeName = "VisualShaderNodeTexture2DArray";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeTexture2DArray() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTexture2DArray(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTexture2DArray(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureArray, 1278366092ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureArray(TextureLayered value)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(value));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureArray, 3984243839ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextureLayered GetTextureArray()
    {
        return (TextureLayered)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureArray, 2206200446ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureArray(Texture2DArray value)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(value));
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
    public new class PropertyName : VisualShaderNodeSample3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture_array' property.
        /// </summary>
        public static readonly StringName TextureArray = "texture_array";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeSample3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture_array' method.
        /// </summary>
        public static readonly StringName SetTextureArray = "set_texture_array";
        /// <summary>
        /// Cached name for the 'get_texture_array' method.
        /// </summary>
        public static readonly StringName GetTextureArray = "get_texture_array";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeSample3D.SignalName
    {
    }
}

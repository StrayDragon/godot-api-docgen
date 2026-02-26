namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for <see cref="Godot.CompressedTexture2DArray"/> and <see cref="Godot.CompressedTexture3D"/>. Cannot be used directly, but contains all the functions necessary for accessing the derived resource types. See also <see cref="Godot.TextureLayered"/>.</para>
/// </summary>
public partial class CompressedTextureLayered : TextureLayered
{
    /// <summary>
    /// <para>The path the texture should be loaded from.</para>
    /// </summary>
    public string LoadPath
    {
        get
        {
            return GetLoadPath();
        }
        set
        {
            Load(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CompressedTextureLayered);

    private static readonly StringName NativeName = "CompressedTextureLayered";

    internal CompressedTextureLayered() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CompressedTextureLayered(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CompressedTextureLayered(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 166001499ul);

    /// <summary>
    /// <para>Loads the texture at <paramref name="path"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Error Load(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoadPath, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLoadPath()
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
    public new class PropertyName : TextureLayered.PropertyName
    {
        /// <summary>
        /// Cached name for the 'load_path' property.
        /// </summary>
        public static readonly StringName LoadPath = "load_path";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TextureLayered.MethodName
    {
        /// <summary>
        /// Cached name for the 'load' method.
        /// </summary>
        public static readonly StringName Load = "load";
        /// <summary>
        /// Cached name for the 'get_load_path' method.
        /// </summary>
        public static readonly StringName GetLoadPath = "get_load_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TextureLayered.SignalName
    {
    }
}

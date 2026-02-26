namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.VisualShaderNodeParticleEmitter"/> that makes the particles emitted in a shape of the assigned <see cref="Godot.VisualShaderNodeParticleMeshEmitter.Mesh"/>. It will emit from the mesh's surfaces, either all or only the specified one.</para>
/// </summary>
public partial class VisualShaderNodeParticleMeshEmitter : VisualShaderNodeParticleEmitter
{
    /// <summary>
    /// <para>The <see cref="Godot.Mesh"/> that defines emission shape.</para>
    /// </summary>
    public Mesh Mesh
    {
        get
        {
            return GetMesh();
        }
        set
        {
            SetMesh(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the particles will emit from all surfaces of the mesh.</para>
    /// </summary>
    public bool UseAllSurfaces
    {
        get
        {
            return IsUseAllSurfaces();
        }
        set
        {
            SetUseAllSurfaces(value);
        }
    }

    /// <summary>
    /// <para>Index of the surface that emits particles. <see cref="Godot.VisualShaderNodeParticleMeshEmitter.UseAllSurfaces"/> must be <see langword="false"/> for this to take effect.</para>
    /// </summary>
    public int SurfaceIndex
    {
        get
        {
            return GetSurfaceIndex();
        }
        set
        {
            SetSurfaceIndex(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeParticleMeshEmitter);

    private static readonly StringName NativeName = "VisualShaderNodeParticleMeshEmitter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeParticleMeshEmitter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParticleMeshEmitter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParticleMeshEmitter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 194775623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(Mesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 1808005922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Mesh GetMesh()
    {
        return (Mesh)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseAllSurfaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseAllSurfaces(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUseAllSurfaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUseAllSurfaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSurfaceIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSurfaceIndex(int surfaceIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), surfaceIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSurfaceIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeParticleEmitter.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'use_all_surfaces' property.
        /// </summary>
        public static readonly StringName UseAllSurfaces = "use_all_surfaces";
        /// <summary>
        /// Cached name for the 'surface_index' property.
        /// </summary>
        public static readonly StringName SurfaceIndex = "surface_index";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeParticleEmitter.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_use_all_surfaces' method.
        /// </summary>
        public static readonly StringName SetUseAllSurfaces = "set_use_all_surfaces";
        /// <summary>
        /// Cached name for the 'is_use_all_surfaces' method.
        /// </summary>
        public static readonly StringName IsUseAllSurfaces = "is_use_all_surfaces";
        /// <summary>
        /// Cached name for the 'set_surface_index' method.
        /// </summary>
        public static readonly StringName SetSurfaceIndex = "set_surface_index";
        /// <summary>
        /// Cached name for the 'get_surface_index' method.
        /// </summary>
        public static readonly StringName GetSurfaceIndex = "get_surface_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeParticleEmitter.SignalName
    {
    }
}

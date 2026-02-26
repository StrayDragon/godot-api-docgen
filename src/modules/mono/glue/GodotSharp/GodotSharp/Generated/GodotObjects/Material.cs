namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Material"/> is a base resource used for coloring and shading geometry. All materials inherit from it and almost all <see cref="Godot.VisualInstance3D"/> derived nodes carry a <see cref="Godot.Material"/>. A few flags and parameters are shared between all material types and are configured here.</para>
/// <para>Importantly, you can inherit from <see cref="Godot.Material"/> to create your own custom material type in script or in GDExtension.</para>
/// </summary>
public partial class Material : Resource
{
    /// <summary>
    /// <para>Maximum value for the <see cref="Godot.Material.RenderPriority"/> parameter.</para>
    /// </summary>
    public const long RenderPriorityMax = 127;
    /// <summary>
    /// <para>Minimum value for the <see cref="Godot.Material.RenderPriority"/> parameter.</para>
    /// </summary>
    public const long RenderPriorityMin = -128;

    /// <summary>
    /// <para>Sets the render priority for objects in 3D scenes. Higher priority objects will be sorted in front of lower priority objects. In other words, all objects with <see cref="Godot.Material.RenderPriority"/> <c>1</c> will render on top of all objects with <see cref="Godot.Material.RenderPriority"/> <c>0</c>.</para>
    /// <para><b>Note:</b> This only applies to <see cref="Godot.StandardMaterial3D"/>s and <see cref="Godot.ShaderMaterial"/>s with type "Spatial".</para>
    /// <para><b>Note:</b> This will not impact how transparent objects are sorted relative to opaque objects or how dynamic meshes will be sorted relative to other opaque meshes. This is because all transparent objects are drawn after all opaque objects and all dynamic opaque meshes are drawn before other opaque meshes.</para>
    /// </summary>
    public int RenderPriority
    {
        get
        {
            return GetRenderPriority();
        }
        set
        {
            SetRenderPriority(value);
        }
    }

    /// <summary>
    /// <para>Sets the <see cref="Godot.Material"/> to be used for the next pass. This renders the object again using a different material.</para>
    /// <para><b>Note:</b> <see cref="Godot.Material.NextPass"/> materials are not necessarily drawn immediately after the source <see cref="Godot.Material"/>. Draw order is determined by material properties, <see cref="Godot.Material.RenderPriority"/>, and distance to camera.</para>
    /// <para><b>Note:</b> This only applies to <see cref="Godot.StandardMaterial3D"/>s and <see cref="Godot.ShaderMaterial"/>s with type "Spatial".</para>
    /// </summary>
    public Material NextPass
    {
        get
        {
            return GetNextPass();
        }
        set
        {
            SetNextPass(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Material);

    private static readonly StringName NativeName = "Material";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Material() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Material(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Material(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Only exposed for the purpose of overriding. You cannot call this function directly. Used internally to determine if <see cref="Godot.Material.NextPass"/> should be shown in the editor or not.</para>
    /// </summary>
    public virtual bool _CanDoNextPass()
    {
        return default;
    }

    /// <summary>
    /// <para>Only exposed for the purpose of overriding. You cannot call this function directly. Used internally to determine if <see cref="Godot.Material.RenderPriority"/> should be shown in the editor or not.</para>
    /// </summary>
    public virtual bool _CanUseRenderPriority()
    {
        return default;
    }

    /// <summary>
    /// <para>Only exposed for the purpose of overriding. You cannot call this function directly. Used internally by various editor tools.</para>
    /// </summary>
    public virtual Shader.Mode _GetShaderMode()
    {
        return default;
    }

    /// <summary>
    /// <para>Only exposed for the purpose of overriding. You cannot call this function directly. Used internally by various editor tools. Used to access the RID of the <see cref="Godot.Material"/>'s <see cref="Godot.Shader"/>.</para>
    /// </summary>
    public virtual Rid _GetShaderRid()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNextPass, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNextPass(Material nextPass)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(nextPass));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextPass, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetNextPass()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRenderPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InspectNativeShaderCode, 3218959716ul);

    /// <summary>
    /// <para>Only available when running in the editor. Opens a popup that visualizes the generated shader code, including all variants and internal shader code. See also <see cref="Godot.Shader.InspectNativeShaderCode()"/>.</para>
    /// </summary>
    public void InspectNativeShaderCode()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreatePlaceholder, 121922552ul);

    /// <summary>
    /// <para>Creates a placeholder version of this resource (<see cref="Godot.PlaceholderMaterial"/>).</para>
    /// </summary>
    public Resource CreatePlaceholder()
    {
        return (Resource)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_do_next_pass = "_CanDoNextPass";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_use_render_priority = "_CanUseRenderPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_shader_mode = "_GetShaderMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_shader_rid = "_GetShaderRid";

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
        if ((method == MethodProxyName__can_do_next_pass || method == MethodName._CanDoNextPass) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_do_next_pass.NativeValue))
        {
            var callRet = _CanDoNextPass();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__can_use_render_priority || method == MethodName._CanUseRenderPriority) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_use_render_priority.NativeValue))
        {
            var callRet = _CanUseRenderPriority();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_shader_mode || method == MethodName._GetShaderMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_shader_mode.NativeValue))
        {
            var callRet = _GetShaderMode();
            ret = VariantUtils.CreateFrom<Shader.Mode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_shader_rid || method == MethodName._GetShaderRid) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_shader_rid.NativeValue))
        {
            var callRet = _GetShaderRid();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
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
        if (method == MethodName._CanDoNextPass)
        {
            if (HasGodotClassMethod(MethodProxyName__can_do_next_pass.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CanUseRenderPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__can_use_render_priority.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetShaderMode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_shader_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetShaderRid)
        {
            if (HasGodotClassMethod(MethodProxyName__get_shader_rid.NativeValue.DangerousSelfRef))
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
        /// <summary>
        /// Cached name for the 'render_priority' property.
        /// </summary>
        public static readonly StringName RenderPriority = "render_priority";
        /// <summary>
        /// Cached name for the 'next_pass' property.
        /// </summary>
        public static readonly StringName NextPass = "next_pass";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_can_do_next_pass' method.
        /// </summary>
        public static readonly StringName _CanDoNextPass = "_can_do_next_pass";
        /// <summary>
        /// Cached name for the '_can_use_render_priority' method.
        /// </summary>
        public static readonly StringName _CanUseRenderPriority = "_can_use_render_priority";
        /// <summary>
        /// Cached name for the '_get_shader_mode' method.
        /// </summary>
        public static readonly StringName _GetShaderMode = "_get_shader_mode";
        /// <summary>
        /// Cached name for the '_get_shader_rid' method.
        /// </summary>
        public static readonly StringName _GetShaderRid = "_get_shader_rid";
        /// <summary>
        /// Cached name for the 'set_next_pass' method.
        /// </summary>
        public static readonly StringName SetNextPass = "set_next_pass";
        /// <summary>
        /// Cached name for the 'get_next_pass' method.
        /// </summary>
        public static readonly StringName GetNextPass = "get_next_pass";
        /// <summary>
        /// Cached name for the 'set_render_priority' method.
        /// </summary>
        public static readonly StringName SetRenderPriority = "set_render_priority";
        /// <summary>
        /// Cached name for the 'get_render_priority' method.
        /// </summary>
        public static readonly StringName GetRenderPriority = "get_render_priority";
        /// <summary>
        /// Cached name for the 'inspect_native_shader_code' method.
        /// </summary>
        public static readonly StringName InspectNativeShaderCode = "inspect_native_shader_code";
        /// <summary>
        /// Cached name for the 'create_placeholder' method.
        /// </summary>
        public static readonly StringName CreatePlaceholder = "create_placeholder";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Class that has everything pertaining to a world: A physics space, a visual scenario, and a sound space. 3D nodes register their resources into the current 3D world.</para>
/// </summary>
public partial class World3D : Resource
{
    /// <summary>
    /// <para>The World3D's <see cref="Godot.Environment"/>.</para>
    /// </summary>
    public Environment Environment
    {
        get
        {
            return GetEnvironment();
        }
        set
        {
            SetEnvironment(value);
        }
    }

    /// <summary>
    /// <para>The World3D's fallback environment will be used if <see cref="Godot.World3D.Environment"/> fails or is missing.</para>
    /// </summary>
    public Environment FallbackEnvironment
    {
        get
        {
            return GetFallbackEnvironment();
        }
        set
        {
            SetFallbackEnvironment(value);
        }
    }

    /// <summary>
    /// <para>The default <see cref="Godot.CameraAttributes"/> resource to use if none set on the <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public CameraAttributes CameraAttributes
    {
        get
        {
            return GetCameraAttributes();
        }
        set
        {
            SetCameraAttributes(value);
        }
    }

    /// <summary>
    /// <para>The World3D's physics space.</para>
    /// </summary>
    public Rid Space
    {
        get
        {
            return GetSpace();
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Rid"/> of this world's navigation map. Used by the <see cref="Godot.NavigationServer3D"/>.</para>
    /// </summary>
    public Rid NavigationMap
    {
        get
        {
            return GetNavigationMap();
        }
    }

    /// <summary>
    /// <para>The World3D's visual scenario.</para>
    /// </summary>
    public Rid Scenario
    {
        get
        {
            return GetScenario();
        }
    }

    /// <summary>
    /// <para>Direct access to the world's physics 3D space state. Used for querying current and potential collisions. When using multi-threaded physics, access is limited to <see cref="Godot.Node._PhysicsProcess(double)"/> in the main thread.</para>
    /// </summary>
    public PhysicsDirectSpaceState3D DirectSpaceState
    {
        get
        {
            return GetDirectSpaceState();
        }
    }

    private static readonly System.Type CachedType = typeof(World3D);

    private static readonly StringName NativeName = "World3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public World3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal World3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal World3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpace, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetSpace()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetNavigationMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScenario, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetScenario()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironment, 4143518816ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironment(Environment env)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(env));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironment, 3082064660ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment GetEnvironment()
    {
        return (Environment)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackEnvironment, 4143518816ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackEnvironment(Environment env)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(env));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackEnvironment, 3082064660ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment GetFallbackEnvironment()
    {
        return (Environment)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraAttributes, 2817810567ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraAttributes(CameraAttributes attributes)
    {
        NativeCalls.godot_icall_1_56(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(attributes));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraAttributes, 3921283215ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CameraAttributes GetCameraAttributes()
    {
        return (CameraAttributes)NativeCalls.godot_icall_0_63(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirectSpaceState, 2069328350ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicsDirectSpaceState3D GetDirectSpaceState()
    {
        return (PhysicsDirectSpaceState3D)NativeCalls.godot_icall_0_53(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'environment' property.
        /// </summary>
        public static readonly StringName Environment = "environment";
        /// <summary>
        /// Cached name for the 'fallback_environment' property.
        /// </summary>
        public static readonly StringName FallbackEnvironment = "fallback_environment";
        /// <summary>
        /// Cached name for the 'camera_attributes' property.
        /// </summary>
        public static readonly StringName CameraAttributes = "camera_attributes";
        /// <summary>
        /// Cached name for the 'space' property.
        /// </summary>
        public static readonly StringName Space = "space";
        /// <summary>
        /// Cached name for the 'navigation_map' property.
        /// </summary>
        public static readonly StringName NavigationMap = "navigation_map";
        /// <summary>
        /// Cached name for the 'scenario' property.
        /// </summary>
        public static readonly StringName Scenario = "scenario";
        /// <summary>
        /// Cached name for the 'direct_space_state' property.
        /// </summary>
        public static readonly StringName DirectSpaceState = "direct_space_state";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_space' method.
        /// </summary>
        public static readonly StringName GetSpace = "get_space";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'get_scenario' method.
        /// </summary>
        public static readonly StringName GetScenario = "get_scenario";
        /// <summary>
        /// Cached name for the 'set_environment' method.
        /// </summary>
        public static readonly StringName SetEnvironment = "set_environment";
        /// <summary>
        /// Cached name for the 'get_environment' method.
        /// </summary>
        public static readonly StringName GetEnvironment = "get_environment";
        /// <summary>
        /// Cached name for the 'set_fallback_environment' method.
        /// </summary>
        public static readonly StringName SetFallbackEnvironment = "set_fallback_environment";
        /// <summary>
        /// Cached name for the 'get_fallback_environment' method.
        /// </summary>
        public static readonly StringName GetFallbackEnvironment = "get_fallback_environment";
        /// <summary>
        /// Cached name for the 'set_camera_attributes' method.
        /// </summary>
        public static readonly StringName SetCameraAttributes = "set_camera_attributes";
        /// <summary>
        /// Cached name for the 'get_camera_attributes' method.
        /// </summary>
        public static readonly StringName GetCameraAttributes = "get_camera_attributes";
        /// <summary>
        /// Cached name for the 'get_direct_space_state' method.
        /// </summary>
        public static readonly StringName GetDirectSpaceState = "get_direct_space_state";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

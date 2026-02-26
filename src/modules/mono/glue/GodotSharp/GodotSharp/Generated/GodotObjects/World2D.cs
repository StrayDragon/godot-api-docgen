namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Class that has everything pertaining to a 2D world: A physics space, a canvas, and a sound space. 2D nodes register their resources into the current 2D world.</para>
/// </summary>
public partial class World2D : Resource
{
    /// <summary>
    /// <para>The <see cref="Godot.Rid"/> of this world's canvas resource. Used by the <see cref="Godot.RenderingServer"/> for 2D drawing.</para>
    /// </summary>
    public Rid Canvas
    {
        get
        {
            return GetCanvas();
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Rid"/> of this world's navigation map. Used by the <see cref="Godot.NavigationServer2D"/>.</para>
    /// </summary>
    public Rid NavigationMap
    {
        get
        {
            return GetNavigationMap();
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Rid"/> of this world's physics space resource. Used by the <see cref="Godot.PhysicsServer2D"/> for 2D physics, treating it as both a space and an area.</para>
    /// </summary>
    public Rid Space
    {
        get
        {
            return GetSpace();
        }
    }

    /// <summary>
    /// <para>Direct access to the world's physics 2D space state. Used for querying current and potential collisions. When using multi-threaded physics, access is limited to <see cref="Godot.Node._PhysicsProcess(double)"/> in the main thread.</para>
    /// </summary>
    public PhysicsDirectSpaceState2D DirectSpaceState
    {
        get
        {
            return GetDirectSpaceState();
        }
    }

    private static readonly System.Type CachedType = typeof(World2D);

    private static readonly StringName NativeName = "World2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public World2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal World2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal World2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvas, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetCanvas()
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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpace, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetSpace()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirectSpaceState, 2506717822ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicsDirectSpaceState2D GetDirectSpaceState()
    {
        return (PhysicsDirectSpaceState2D)NativeCalls.godot_icall_0_53(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'canvas' property.
        /// </summary>
        public static readonly StringName Canvas = "canvas";
        /// <summary>
        /// Cached name for the 'navigation_map' property.
        /// </summary>
        public static readonly StringName NavigationMap = "navigation_map";
        /// <summary>
        /// Cached name for the 'space' property.
        /// </summary>
        public static readonly StringName Space = "space";
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
        /// Cached name for the 'get_canvas' method.
        /// </summary>
        public static readonly StringName GetCanvas = "get_canvas";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'get_space' method.
        /// </summary>
        public static readonly StringName GetSpace = "get_space";
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

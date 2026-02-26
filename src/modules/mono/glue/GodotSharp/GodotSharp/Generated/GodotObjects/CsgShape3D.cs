namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is the CSG base class that provides CSG operation support to the various CSG nodes in Godot.</para>
/// <para><b>Performance:</b> CSG nodes are only intended for prototyping as they have a significant CPU performance cost. Consider baking final CSG operation results into static geometry that replaces the CSG nodes.</para>
/// <para>Individual CSG root node results can be baked to nodes with static resources with the editor menu that appears when a CSG root node is selected.</para>
/// <para>Individual CSG root nodes can also be baked to static resources with scripts by calling <see cref="Godot.CsgShape3D.BakeStaticMesh()"/> for the visual mesh or <see cref="Godot.CsgShape3D.BakeCollisionShape()"/> for the physics collision.</para>
/// <para>Entire scenes of CSG nodes can be baked to static geometry and exported with the editor glTF scene exporter: <b>Scene &gt; Export As... &gt; glTF 2.0 Scene...</b></para>
/// </summary>
[GodotClassName("CSGShape3D")]
public partial class CsgShape3D : GeometryInstance3D
{
    public enum OperationEnum : long
    {
        /// <summary>
        /// <para>Geometry of both primitives is merged, intersecting geometry is removed.</para>
        /// </summary>
        Union = 0,
        /// <summary>
        /// <para>Only intersecting geometry remains, the rest is removed.</para>
        /// </summary>
        Intersection = 1,
        /// <summary>
        /// <para>The second shape is subtracted from the first, leaving a dent with its shape.</para>
        /// </summary>
        Subtraction = 2
    }

    /// <summary>
    /// <para>The operation that is performed on this shape. This is ignored for the first CSG child node as the operation is between this node and the previous child of this nodes parent.</para>
    /// </summary>
    public CsgShape3D.OperationEnum Operation
    {
        get
        {
            return GetOperation();
        }
        set
        {
            SetOperation(value);
        }
    }

    /// <summary>
    /// <para>This property does nothing.</para>
    /// </summary>
    [Obsolete("The CSG library no longer uses snapping.")]
    public float Snap
    {
        get
        {
            return GetSnap();
        }
        set
        {
            SetSnap(value);
        }
    }

    /// <summary>
    /// <para>Calculate tangents for the CSG shape which allows the use of normal and height maps. This is only applied on the root shape, this setting is ignored on any child. Setting this to <see langword="false"/> can speed up shape generation slightly.</para>
    /// </summary>
    public bool CalculateTangents
    {
        get
        {
            return IsCalculatingTangents();
        }
        set
        {
            SetCalculateTangents(value);
        }
    }

    /// <summary>
    /// <para>Adds a collision shape to the physics engine for our CSG shape. This will always act like a static body. Note that the collision shape is still active even if the CSG shape itself is hidden. See also <see cref="Godot.CsgShape3D.CollisionMask"/> and <see cref="Godot.CsgShape3D.CollisionPriority"/>.</para>
    /// </summary>
    public bool UseCollision
    {
        get
        {
            return IsUsingCollision();
        }
        set
        {
            SetUseCollision(value);
        }
    }

    /// <summary>
    /// <para>The physics layers this area is in.</para>
    /// <para>Collidable objects can exist in any of 32 different layers. These layers work like a tagging system, and are not visual. A collidable can use these layers to select with which objects it can collide, using the collision_mask property.</para>
    /// <para>A contact is detected if object A is in any of the layers that object B scans, or object B is in any layer scanned by object A. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionLayer
    {
        get
        {
            return GetCollisionLayer();
        }
        set
        {
            SetCollisionLayer(value);
        }
    }

    /// <summary>
    /// <para>The physics layers this CSG shape scans for collisions. Only effective if <see cref="Godot.CsgShape3D.UseCollision"/> is <see langword="true"/>. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask
    {
        get
        {
            return GetCollisionMask();
        }
        set
        {
            SetCollisionMask(value);
        }
    }

    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. Only effective if <see cref="Godot.CsgShape3D.UseCollision"/> is <see langword="true"/>. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    public float CollisionPriority
    {
        get
        {
            return GetCollisionPriority();
        }
        set
        {
            SetCollisionPriority(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CsgShape3D);

    private static readonly StringName NativeName = "CSGShape3D";

    internal CsgShape3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgShape3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgShape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRootShape, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this is a root shape and is thus the object that is rendered.</para>
    /// </summary>
    public bool IsRootShape()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOperation, 811425055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOperation(CsgShape3D.OperationEnum operation)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)operation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOperation, 2662425879ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CsgShape3D.OperationEnum GetOperation()
    {
        return (CsgShape3D.OperationEnum)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnap, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnap(float snap)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), snap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSnap, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSnap()
    {
        return NativeCalls.godot_icall_0_68(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseCollision, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseCollision(bool operation)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), operation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingCollision, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingCollision()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionLayer(uint layer)
    {
        NativeCalls.godot_icall_1_208(MethodBind7, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind9, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.CsgShape3D.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind11, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.CsgShape3D.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind12, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.CsgShape3D.CollisionLayer"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind13, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.CsgShape3D.CollisionLayer"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind14, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPriority, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionPriority(float priority)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPriority, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionPriority()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeCollisionShape, 36102322ul);

    /// <summary>
    /// <para>Returns a baked physics <see cref="Godot.ConcavePolygonShape3D"/> of this node's CSG operation result. Returns an empty shape if the node is not a CSG root node or has no valid geometry.</para>
    /// <para><b>Performance:</b> If the CSG operation results in a very detailed geometry with many faces physics performance will be very slow. Concave shapes should in general only be used for static level geometry and not with dynamic objects that are moving.</para>
    /// <para><b>Note:</b> CSG mesh data updates are deferred, which means they are updated with a delay of one rendered frame. To avoid getting an empty shape or outdated mesh data, make sure to call <c>await get_tree().process_frame</c> before using <see cref="Godot.CsgShape3D.BakeCollisionShape()"/> in <see cref="Godot.Node._Ready()"/> or after changing properties on the <see cref="Godot.CsgShape3D"/>.</para>
    /// </summary>
    public ConcavePolygonShape3D BakeCollisionShape()
    {
        return (ConcavePolygonShape3D)NativeCalls.godot_icall_0_63(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCalculateTangents, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCalculateTangents(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCalculatingTangents, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCalculatingTangents()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshes, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> with two elements, the first is the <see cref="Godot.Transform3D"/> of this node and the second is the root <see cref="Godot.Mesh"/> of this node. Only works when this node is the root shape.</para>
    /// <para><b>Note:</b> CSG mesh data updates are deferred, which means they are updated with a delay of one rendered frame. To avoid getting an empty shape or outdated mesh data, make sure to call <c>await get_tree().process_frame</c> before using <see cref="Godot.CsgShape3D.GetMeshes()"/> in <see cref="Godot.Node._Ready()"/> or after changing properties on the <see cref="Godot.CsgShape3D"/>.</para>
    /// </summary>
    public Godot.Collections.Array GetMeshes()
    {
        return NativeCalls.godot_icall_0_120(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeStaticMesh, 1605880883ul);

    /// <summary>
    /// <para>Returns a baked static <see cref="Godot.ArrayMesh"/> of this node's CSG operation result. Materials from involved CSG nodes are added as extra mesh surfaces. Returns an empty mesh if the node is not a CSG root node or has no valid geometry.</para>
    /// <para><b>Note:</b> CSG mesh data updates are deferred, which means they are updated with a delay of one rendered frame. To avoid getting an empty mesh or outdated mesh data, make sure to call <c>await get_tree().process_frame</c> before using <see cref="Godot.CsgShape3D.BakeStaticMesh()"/> in <see cref="Godot.Node._Ready()"/> or after changing properties on the <see cref="Godot.CsgShape3D"/>.</para>
    /// </summary>
    public ArrayMesh BakeStaticMesh()
    {
        return (ArrayMesh)NativeCalls.godot_icall_0_63(MethodBind21, GodotObject.GetPtr(this));
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
    public new class PropertyName : GeometryInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'operation' property.
        /// </summary>
        public static readonly StringName Operation = "operation";
        /// <summary>
        /// Cached name for the 'snap' property.
        /// </summary>
        public static readonly StringName Snap = "snap";
        /// <summary>
        /// Cached name for the 'calculate_tangents' property.
        /// </summary>
        public static readonly StringName CalculateTangents = "calculate_tangents";
        /// <summary>
        /// Cached name for the 'use_collision' property.
        /// </summary>
        public static readonly StringName UseCollision = "use_collision";
        /// <summary>
        /// Cached name for the 'collision_layer' property.
        /// </summary>
        public static readonly StringName CollisionLayer = "collision_layer";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'collision_priority' property.
        /// </summary>
        public static readonly StringName CollisionPriority = "collision_priority";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GeometryInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_root_shape' method.
        /// </summary>
        public static readonly StringName IsRootShape = "is_root_shape";
        /// <summary>
        /// Cached name for the 'set_operation' method.
        /// </summary>
        public static readonly StringName SetOperation = "set_operation";
        /// <summary>
        /// Cached name for the 'get_operation' method.
        /// </summary>
        public static readonly StringName GetOperation = "get_operation";
        /// <summary>
        /// Cached name for the 'set_snap' method.
        /// </summary>
        public static readonly StringName SetSnap = "set_snap";
        /// <summary>
        /// Cached name for the 'get_snap' method.
        /// </summary>
        public static readonly StringName GetSnap = "get_snap";
        /// <summary>
        /// Cached name for the 'set_use_collision' method.
        /// </summary>
        public static readonly StringName SetUseCollision = "set_use_collision";
        /// <summary>
        /// Cached name for the 'is_using_collision' method.
        /// </summary>
        public static readonly StringName IsUsingCollision = "is_using_collision";
        /// <summary>
        /// Cached name for the 'set_collision_layer' method.
        /// </summary>
        public static readonly StringName SetCollisionLayer = "set_collision_layer";
        /// <summary>
        /// Cached name for the 'get_collision_layer' method.
        /// </summary>
        public static readonly StringName GetCollisionLayer = "get_collision_layer";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetCollisionMaskValue = "set_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetCollisionMaskValue = "get_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_collision_layer_value' method.
        /// </summary>
        public static readonly StringName SetCollisionLayerValue = "set_collision_layer_value";
        /// <summary>
        /// Cached name for the 'get_collision_layer_value' method.
        /// </summary>
        public static readonly StringName GetCollisionLayerValue = "get_collision_layer_value";
        /// <summary>
        /// Cached name for the 'set_collision_priority' method.
        /// </summary>
        public static readonly StringName SetCollisionPriority = "set_collision_priority";
        /// <summary>
        /// Cached name for the 'get_collision_priority' method.
        /// </summary>
        public static readonly StringName GetCollisionPriority = "get_collision_priority";
        /// <summary>
        /// Cached name for the 'bake_collision_shape' method.
        /// </summary>
        public static readonly StringName BakeCollisionShape = "bake_collision_shape";
        /// <summary>
        /// Cached name for the 'set_calculate_tangents' method.
        /// </summary>
        public static readonly StringName SetCalculateTangents = "set_calculate_tangents";
        /// <summary>
        /// Cached name for the 'is_calculating_tangents' method.
        /// </summary>
        public static readonly StringName IsCalculatingTangents = "is_calculating_tangents";
        /// <summary>
        /// Cached name for the 'get_meshes' method.
        /// </summary>
        public static readonly StringName GetMeshes = "get_meshes";
        /// <summary>
        /// Cached name for the 'bake_static_mesh' method.
        /// </summary>
        public static readonly StringName BakeStaticMesh = "bake_static_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GeometryInstance3D.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for 2D physics objects. <see cref="Godot.CollisionObject2D"/> can hold any number of <see cref="Godot.Shape2D"/>s for collision. Each shape must be assigned to a <i>shape owner</i>. Shape owners are not nodes and do not appear in the editor, but are accessible through code using the <c>shape_owner_*</c> methods.</para>
/// <para><b>Note:</b> Only collisions between objects within the same canvas (<see cref="Godot.Viewport"/> canvas or <see cref="Godot.CanvasLayer"/>) are supported. The behavior of collisions between objects in different canvases is undefined.</para>
/// </summary>
public partial class CollisionObject2D : Node2D
{
    public enum DisableModeEnum : long
    {
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, remove from the physics simulation to stop all physics interactions with this <see cref="Godot.CollisionObject2D"/>.</para>
        /// <para>Automatically re-added to the physics simulation when the <see cref="Godot.Node"/> is processed again.</para>
        /// </summary>
        Remove = 0,
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, make the body static. Doesn't affect <see cref="Godot.Area2D"/>. <see cref="Godot.PhysicsBody2D"/> can't be affected by forces or other bodies while static.</para>
        /// <para>Automatically set <see cref="Godot.PhysicsBody2D"/> back to its original mode when the <see cref="Godot.Node"/> is processed again.</para>
        /// </summary>
        MakeStatic = 1,
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, do not affect the physics simulation.</para>
        /// </summary>
        KeepActive = 2
    }

    /// <summary>
    /// <para>Defines the behavior in physics when <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
    /// </summary>
    public CollisionObject2D.DisableModeEnum DisableMode
    {
        get
        {
            return GetDisableMode();
        }
        set
        {
            SetDisableMode(value);
        }
    }

    /// <summary>
    /// <para>The physics layers this CollisionObject2D is in. Collision objects can exist in one or more of 32 different layers. See also <see cref="Godot.CollisionObject2D.CollisionMask"/>.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
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
    /// <para>The physics layers this CollisionObject2D scans. Collision objects can scan one or more of 32 different layers. See also <see cref="Godot.CollisionObject2D.CollisionLayer"/>.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
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
    /// <para>The priority used to solve colliding when occurring penetration. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
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

    /// <summary>
    /// <para>If <see langword="true"/>, this object is pickable. A pickable object can detect the mouse pointer entering/leaving, and if the mouse is inside it, report input events. Requires at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set.</para>
    /// </summary>
    public bool InputPickable
    {
        get
        {
            return IsPickable();
        }
        set
        {
            SetPickable(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CollisionObject2D);

    private static readonly StringName NativeName = "CollisionObject2D";

    internal CollisionObject2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionObject2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionObject2D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Accepts unhandled <see cref="Godot.InputEvent"/>s. <paramref name="shapeIdx"/> is the child index of the clicked <see cref="Godot.Shape2D"/>. Connect to <see cref="Godot.CollisionObject2D.InputEvent"/> to easily pick up these events.</para>
    /// <para><b>Note:</b> <see cref="Godot.CollisionObject2D._InputEvent(Viewport, InputEvent, int)"/> requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set.</para>
    /// </summary>
    public virtual void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
    }

    /// <summary>
    /// <para>Called when the mouse pointer enters any of this object's shapes. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set. Note that moving between different shapes within a single <see cref="Godot.CollisionObject2D"/> won't cause this function to be called.</para>
    /// </summary>
    public virtual void _MouseEnter()
    {
    }

    /// <summary>
    /// <para>Called when the mouse pointer exits all this object's shapes. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set. Note that moving between different shapes within a single <see cref="Godot.CollisionObject2D"/> won't cause this function to be called.</para>
    /// </summary>
    public virtual void _MouseExit()
    {
    }

    /// <summary>
    /// <para>Called when the mouse pointer enters any of this object's shapes or moves from one shape to another. <paramref name="shapeIdx"/> is the child index of the newly entered <see cref="Godot.Shape2D"/>. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be called.</para>
    /// </summary>
    public virtual void _MouseShapeEnter(int shapeIdx)
    {
    }

    /// <summary>
    /// <para>Called when the mouse pointer exits any of this object's shapes. <paramref name="shapeIdx"/> is the child index of the exited <see cref="Godot.Shape2D"/>. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be called.</para>
    /// </summary>
    public virtual void _MouseShapeExit(int shapeIdx)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the object's <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionLayer(uint layer)
    {
        NativeCalls.godot_icall_1_208(MethodBind1, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind3, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.CollisionObject2D.CollisionLayer"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind5, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.CollisionObject2D.CollisionLayer"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind6, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.CollisionObject2D.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind7, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.CollisionObject2D.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPriority, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionPriority(float priority)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPriority, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionPriority()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableMode, 1919204045ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableMode(CollisionObject2D.DisableModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisableMode, 3172846349ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CollisionObject2D.DisableModeEnum GetDisableMode()
    {
        return (CollisionObject2D.DisableModeEnum)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPickable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPickable(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPickable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPickable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateShapeOwner, 3429307534ul);

    /// <summary>
    /// <para>Creates a new shape owner for the given object. Returns <c>owner_id</c> of the new owner for future reference.</para>
    /// </summary>
    public uint CreateShapeOwner(GodotObject owner)
    {
        return NativeCalls.godot_icall_1_311(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(owner));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveShapeOwner, 1286410249ul);

    /// <summary>
    /// <para>Removes the given shape owner.</para>
    /// </summary>
    public void RemoveShapeOwner(uint ownerId)
    {
        NativeCalls.godot_icall_1_208(MethodBind16, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShapeOwners, 969006518ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <c>owner_id</c> identifiers. You can use these ids in other methods that take <c>owner_id</c> as an argument.</para>
    /// </summary>
    public int[] GetShapeOwners()
    {
        return NativeCalls.godot_icall_0_151(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerSetTransform, 30160968ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform2D"/> of the given shape owner.</para>
    /// </summary>
    public unsafe void ShapeOwnerSetTransform(uint ownerId, Transform2D transform)
    {
        NativeCalls.godot_icall_2_312(MethodBind18, GodotObject.GetPtr(this), ownerId, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetTransform, 3836996910ul);

    /// <summary>
    /// <para>Returns the shape owner's <see cref="Godot.Transform2D"/>.</para>
    /// </summary>
    public Transform2D ShapeOwnerGetTransform(uint ownerId)
    {
        return NativeCalls.godot_icall_1_313(MethodBind19, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetOwner, 3332903315ul);

    /// <summary>
    /// <para>Returns the parent object of the given shape owner.</para>
    /// </summary>
    public GodotObject ShapeOwnerGetOwner(uint ownerId)
    {
        return (GodotObject)NativeCalls.godot_icall_1_314(MethodBind20, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerSetDisabled, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, disables the given shape owner.</para>
    /// </summary>
    public void ShapeOwnerSetDisabled(uint ownerId, bool disabled)
    {
        NativeCalls.godot_icall_2_269(MethodBind21, GodotObject.GetPtr(this), ownerId, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShapeOwnerDisabled, 1116898809ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the shape owner and its shapes are disabled.</para>
    /// </summary>
    public bool IsShapeOwnerDisabled(uint ownerId)
    {
        return NativeCalls.godot_icall_1_270(MethodBind22, GodotObject.GetPtr(this), ownerId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerSetOneWayCollision, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enable"/> is <see langword="true"/>, collisions for the shape owner originating from this <see cref="Godot.CollisionObject2D"/> will not be reported to collided with <see cref="Godot.CollisionObject2D"/>s.</para>
    /// </summary>
    public void ShapeOwnerSetOneWayCollision(uint ownerId, bool enable)
    {
        NativeCalls.godot_icall_2_269(MethodBind23, GodotObject.GetPtr(this), ownerId, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShapeOwnerOneWayCollisionEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if collisions for the shape owner originating from this <see cref="Godot.CollisionObject2D"/> will not be reported to collided with <see cref="Godot.CollisionObject2D"/>s.</para>
    /// </summary>
    public bool IsShapeOwnerOneWayCollisionEnabled(uint ownerId)
    {
        return NativeCalls.godot_icall_1_270(MethodBind24, GodotObject.GetPtr(this), ownerId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerSetOneWayCollisionMargin, 1602489585ul);

    /// <summary>
    /// <para>Sets the <c>one_way_collision_margin</c> of the shape owner identified by given <paramref name="ownerId"/> to <paramref name="margin"/> pixels.</para>
    /// </summary>
    public void ShapeOwnerSetOneWayCollisionMargin(uint ownerId, float margin)
    {
        NativeCalls.godot_icall_2_315(MethodBind25, GodotObject.GetPtr(this), ownerId, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShapeOwnerOneWayCollisionMargin, 2339986948ul);

    /// <summary>
    /// <para>Returns the <c>one_way_collision_margin</c> of the shape owner identified by given <paramref name="ownerId"/>.</para>
    /// </summary>
    public float GetShapeOwnerOneWayCollisionMargin(uint ownerId)
    {
        return NativeCalls.godot_icall_1_316(MethodBind26, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerAddShape, 2077425081ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Shape2D"/> to the shape owner.</para>
    /// </summary>
    public void ShapeOwnerAddShape(uint ownerId, Shape2D shape)
    {
        NativeCalls.godot_icall_2_317(MethodBind27, GodotObject.GetPtr(this), ownerId, GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetShapeCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of shapes the given shape owner contains.</para>
    /// </summary>
    public int ShapeOwnerGetShapeCount(uint ownerId)
    {
        return NativeCalls.godot_icall_1_318(MethodBind28, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetShape, 3106725749ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Shape2D"/> with the given ID from the given shape owner.</para>
    /// </summary>
    public Shape2D ShapeOwnerGetShape(uint ownerId, int shapeId)
    {
        return (Shape2D)NativeCalls.godot_icall_2_319(MethodBind29, GodotObject.GetPtr(this), ownerId, shapeId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetShapeIndex, 3175239445ul);

    /// <summary>
    /// <para>Returns the child index of the <see cref="Godot.Shape2D"/> with the given ID from the given shape owner.</para>
    /// </summary>
    public int ShapeOwnerGetShapeIndex(uint ownerId, int shapeId)
    {
        return NativeCalls.godot_icall_2_320(MethodBind30, GodotObject.GetPtr(this), ownerId, shapeId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerRemoveShape, 3937882851ul);

    /// <summary>
    /// <para>Removes a shape from the given shape owner.</para>
    /// </summary>
    public void ShapeOwnerRemoveShape(uint ownerId, int shapeId)
    {
        NativeCalls.godot_icall_2_321(MethodBind31, GodotObject.GetPtr(this), ownerId, shapeId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerClearShapes, 1286410249ul);

    /// <summary>
    /// <para>Removes all shapes from the shape owner.</para>
    /// </summary>
    public void ShapeOwnerClearShapes(uint ownerId)
    {
        NativeCalls.godot_icall_1_208(MethodBind32, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeFindOwner, 923996154ul);

    /// <summary>
    /// <para>Returns the <c>owner_id</c> of the given shape.</para>
    /// </summary>
    public uint ShapeFindOwner(int shapeIndex)
    {
        return NativeCalls.godot_icall_1_322(MethodBind33, GodotObject.GetPtr(this), shapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CollisionObject2D.InputEvent"/> event of a <see cref="Godot.CollisionObject2D"/> class.
    /// </summary>
    public delegate void InputEventEventHandler(Node viewport, InputEvent @event, long shapeIdx);

    private static void InputEventTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((InputEventEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]), VariantUtils.ConvertTo<InputEvent>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an input event occurs. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set. See <see cref="Godot.CollisionObject2D._InputEvent(Viewport, InputEvent, int)"/> for details.</para>
    /// </summary>
    public unsafe event InputEventEventHandler InputEvent
    {
        add => Connect(SignalName.InputEvent, Callable.CreateWithUnsafeTrampoline(value, &InputEventTrampoline));
        remove => Disconnect(SignalName.InputEvent, Callable.CreateWithUnsafeTrampoline(value, &InputEventTrampoline));
    }

    protected void EmitSignalInputEvent(Node viewport, InputEvent @event, long shapeIdx)
    {
        EmitSignal(SignalName.InputEvent, viewport, @event, shapeIdx);
    }

    /// <summary>
    /// <para>Emitted when the mouse pointer enters any of this object's shapes. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set. Note that moving between different shapes within a single <see cref="Godot.CollisionObject2D"/> won't cause this signal to be emitted.</para>
    /// <para><b>Note:</b> Due to the lack of continuous collision detection, this signal may not be emitted in the expected order if the mouse moves fast enough and the <see cref="Godot.CollisionObject2D"/>'s area is small. This signal may also not be emitted if another <see cref="Godot.CollisionObject2D"/> is overlapping the <see cref="Godot.CollisionObject2D"/> in question.</para>
    /// </summary>
    public event Action MouseEntered
    {
        add => Connect(SignalName.MouseEntered, Callable.From(value));
        remove => Disconnect(SignalName.MouseEntered, Callable.From(value));
    }

    protected void EmitSignalMouseEntered()
    {
        EmitSignal(SignalName.MouseEntered);
    }

    /// <summary>
    /// <para>Emitted when the mouse pointer exits all this object's shapes. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set. Note that moving between different shapes within a single <see cref="Godot.CollisionObject2D"/> won't cause this signal to be emitted.</para>
    /// <para><b>Note:</b> Due to the lack of continuous collision detection, this signal may not be emitted in the expected order if the mouse moves fast enough and the <see cref="Godot.CollisionObject2D"/>'s area is small. This signal may also not be emitted if another <see cref="Godot.CollisionObject2D"/> is overlapping the <see cref="Godot.CollisionObject2D"/> in question.</para>
    /// </summary>
    public event Action MouseExited
    {
        add => Connect(SignalName.MouseExited, Callable.From(value));
        remove => Disconnect(SignalName.MouseExited, Callable.From(value));
    }

    protected void EmitSignalMouseExited()
    {
        EmitSignal(SignalName.MouseExited);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CollisionObject2D.MouseShapeEntered"/> event of a <see cref="Godot.CollisionObject2D"/> class.
    /// </summary>
    public delegate void MouseShapeEnteredEventHandler(long shapeIdx);

    private static void MouseShapeEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MouseShapeEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the mouse pointer enters any of this object's shapes or moves from one shape to another. <c>shapeIdx</c> is the child index of the newly entered <see cref="Godot.Shape2D"/>. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set.</para>
    /// </summary>
    public unsafe event MouseShapeEnteredEventHandler MouseShapeEntered
    {
        add => Connect(SignalName.MouseShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &MouseShapeEnteredTrampoline));
        remove => Disconnect(SignalName.MouseShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &MouseShapeEnteredTrampoline));
    }

    protected void EmitSignalMouseShapeEntered(long shapeIdx)
    {
        EmitSignal(SignalName.MouseShapeEntered, shapeIdx);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CollisionObject2D.MouseShapeExited"/> event of a <see cref="Godot.CollisionObject2D"/> class.
    /// </summary>
    public delegate void MouseShapeExitedEventHandler(long shapeIdx);

    private static void MouseShapeExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MouseShapeExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the mouse pointer exits any of this object's shapes. <c>shapeIdx</c> is the child index of the exited <see cref="Godot.Shape2D"/>. Requires <see cref="Godot.CollisionObject2D.InputPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject2D.CollisionLayer"/> bit to be set.</para>
    /// </summary>
    public unsafe event MouseShapeExitedEventHandler MouseShapeExited
    {
        add => Connect(SignalName.MouseShapeExited, Callable.CreateWithUnsafeTrampoline(value, &MouseShapeExitedTrampoline));
        remove => Disconnect(SignalName.MouseShapeExited, Callable.CreateWithUnsafeTrampoline(value, &MouseShapeExitedTrampoline));
    }

    protected void EmitSignalMouseShapeExited(long shapeIdx)
    {
        EmitSignal(SignalName.MouseShapeExited, shapeIdx);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__input_event = "_InputEvent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__mouse_enter = "_MouseEnter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__mouse_exit = "_MouseExit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__mouse_shape_enter = "_MouseShapeEnter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__mouse_shape_exit = "_MouseShapeExit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_input_event = "InputEvent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_entered = "MouseEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_exited = "MouseExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_shape_entered = "MouseShapeEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_shape_exited = "MouseShapeExited";

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
        if ((method == MethodProxyName__input_event || method == MethodName._InputEvent) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__input_event.NativeValue))
        {
            _InputEvent(VariantUtils.ConvertTo<Viewport>(args[0]), VariantUtils.ConvertTo<InputEvent>(args[1]), VariantUtils.ConvertTo<int>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__mouse_enter || method == MethodName._MouseEnter) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__mouse_enter.NativeValue))
        {
            _MouseEnter();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__mouse_exit || method == MethodName._MouseExit) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__mouse_exit.NativeValue))
        {
            _MouseExit();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__mouse_shape_enter || method == MethodName._MouseShapeEnter) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__mouse_shape_enter.NativeValue))
        {
            _MouseShapeEnter(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__mouse_shape_exit || method == MethodName._MouseShapeExit) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__mouse_shape_exit.NativeValue))
        {
            _MouseShapeExit(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
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
        if (method == MethodName._InputEvent)
        {
            if (HasGodotClassMethod(MethodProxyName__input_event.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MouseEnter)
        {
            if (HasGodotClassMethod(MethodProxyName__mouse_enter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MouseExit)
        {
            if (HasGodotClassMethod(MethodProxyName__mouse_exit.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MouseShapeEnter)
        {
            if (HasGodotClassMethod(MethodProxyName__mouse_shape_enter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MouseShapeExit)
        {
            if (HasGodotClassMethod(MethodProxyName__mouse_shape_exit.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.InputEvent)
        {
            if (HasGodotClassSignal(SignalProxyName_input_event.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MouseEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_mouse_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MouseExited)
        {
            if (HasGodotClassSignal(SignalProxyName_mouse_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MouseShapeEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_mouse_shape_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MouseShapeExited)
        {
            if (HasGodotClassSignal(SignalProxyName_mouse_shape_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'disable_mode' property.
        /// </summary>
        public static readonly StringName DisableMode = "disable_mode";
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
        /// <summary>
        /// Cached name for the 'input_pickable' property.
        /// </summary>
        public static readonly StringName InputPickable = "input_pickable";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the '_input_event' method.
        /// </summary>
        public static readonly StringName _InputEvent = "_input_event";
        /// <summary>
        /// Cached name for the '_mouse_enter' method.
        /// </summary>
        public static readonly StringName _MouseEnter = "_mouse_enter";
        /// <summary>
        /// Cached name for the '_mouse_exit' method.
        /// </summary>
        public static readonly StringName _MouseExit = "_mouse_exit";
        /// <summary>
        /// Cached name for the '_mouse_shape_enter' method.
        /// </summary>
        public static readonly StringName _MouseShapeEnter = "_mouse_shape_enter";
        /// <summary>
        /// Cached name for the '_mouse_shape_exit' method.
        /// </summary>
        public static readonly StringName _MouseShapeExit = "_mouse_shape_exit";
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
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
        /// Cached name for the 'set_collision_layer_value' method.
        /// </summary>
        public static readonly StringName SetCollisionLayerValue = "set_collision_layer_value";
        /// <summary>
        /// Cached name for the 'get_collision_layer_value' method.
        /// </summary>
        public static readonly StringName GetCollisionLayerValue = "get_collision_layer_value";
        /// <summary>
        /// Cached name for the 'set_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetCollisionMaskValue = "set_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetCollisionMaskValue = "get_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_collision_priority' method.
        /// </summary>
        public static readonly StringName SetCollisionPriority = "set_collision_priority";
        /// <summary>
        /// Cached name for the 'get_collision_priority' method.
        /// </summary>
        public static readonly StringName GetCollisionPriority = "get_collision_priority";
        /// <summary>
        /// Cached name for the 'set_disable_mode' method.
        /// </summary>
        public static readonly StringName SetDisableMode = "set_disable_mode";
        /// <summary>
        /// Cached name for the 'get_disable_mode' method.
        /// </summary>
        public static readonly StringName GetDisableMode = "get_disable_mode";
        /// <summary>
        /// Cached name for the 'set_pickable' method.
        /// </summary>
        public static readonly StringName SetPickable = "set_pickable";
        /// <summary>
        /// Cached name for the 'is_pickable' method.
        /// </summary>
        public static readonly StringName IsPickable = "is_pickable";
        /// <summary>
        /// Cached name for the 'create_shape_owner' method.
        /// </summary>
        public static readonly StringName CreateShapeOwner = "create_shape_owner";
        /// <summary>
        /// Cached name for the 'remove_shape_owner' method.
        /// </summary>
        public static readonly StringName RemoveShapeOwner = "remove_shape_owner";
        /// <summary>
        /// Cached name for the 'get_shape_owners' method.
        /// </summary>
        public static readonly StringName GetShapeOwners = "get_shape_owners";
        /// <summary>
        /// Cached name for the 'shape_owner_set_transform' method.
        /// </summary>
        public static readonly StringName ShapeOwnerSetTransform = "shape_owner_set_transform";
        /// <summary>
        /// Cached name for the 'shape_owner_get_transform' method.
        /// </summary>
        public static readonly StringName ShapeOwnerGetTransform = "shape_owner_get_transform";
        /// <summary>
        /// Cached name for the 'shape_owner_get_owner' method.
        /// </summary>
        public static readonly StringName ShapeOwnerGetOwner = "shape_owner_get_owner";
        /// <summary>
        /// Cached name for the 'shape_owner_set_disabled' method.
        /// </summary>
        public static readonly StringName ShapeOwnerSetDisabled = "shape_owner_set_disabled";
        /// <summary>
        /// Cached name for the 'is_shape_owner_disabled' method.
        /// </summary>
        public static readonly StringName IsShapeOwnerDisabled = "is_shape_owner_disabled";
        /// <summary>
        /// Cached name for the 'shape_owner_set_one_way_collision' method.
        /// </summary>
        public static readonly StringName ShapeOwnerSetOneWayCollision = "shape_owner_set_one_way_collision";
        /// <summary>
        /// Cached name for the 'is_shape_owner_one_way_collision_enabled' method.
        /// </summary>
        public static readonly StringName IsShapeOwnerOneWayCollisionEnabled = "is_shape_owner_one_way_collision_enabled";
        /// <summary>
        /// Cached name for the 'shape_owner_set_one_way_collision_margin' method.
        /// </summary>
        public static readonly StringName ShapeOwnerSetOneWayCollisionMargin = "shape_owner_set_one_way_collision_margin";
        /// <summary>
        /// Cached name for the 'get_shape_owner_one_way_collision_margin' method.
        /// </summary>
        public static readonly StringName GetShapeOwnerOneWayCollisionMargin = "get_shape_owner_one_way_collision_margin";
        /// <summary>
        /// Cached name for the 'shape_owner_add_shape' method.
        /// </summary>
        public static readonly StringName ShapeOwnerAddShape = "shape_owner_add_shape";
        /// <summary>
        /// Cached name for the 'shape_owner_get_shape_count' method.
        /// </summary>
        public static readonly StringName ShapeOwnerGetShapeCount = "shape_owner_get_shape_count";
        /// <summary>
        /// Cached name for the 'shape_owner_get_shape' method.
        /// </summary>
        public static readonly StringName ShapeOwnerGetShape = "shape_owner_get_shape";
        /// <summary>
        /// Cached name for the 'shape_owner_get_shape_index' method.
        /// </summary>
        public static readonly StringName ShapeOwnerGetShapeIndex = "shape_owner_get_shape_index";
        /// <summary>
        /// Cached name for the 'shape_owner_remove_shape' method.
        /// </summary>
        public static readonly StringName ShapeOwnerRemoveShape = "shape_owner_remove_shape";
        /// <summary>
        /// Cached name for the 'shape_owner_clear_shapes' method.
        /// </summary>
        public static readonly StringName ShapeOwnerClearShapes = "shape_owner_clear_shapes";
        /// <summary>
        /// Cached name for the 'shape_find_owner' method.
        /// </summary>
        public static readonly StringName ShapeFindOwner = "shape_find_owner";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'input_event' signal.
        /// </summary>
        public static readonly StringName InputEvent = "input_event";
        /// <summary>
        /// Cached name for the 'mouse_entered' signal.
        /// </summary>
        public static readonly StringName MouseEntered = "mouse_entered";
        /// <summary>
        /// Cached name for the 'mouse_exited' signal.
        /// </summary>
        public static readonly StringName MouseExited = "mouse_exited";
        /// <summary>
        /// Cached name for the 'mouse_shape_entered' signal.
        /// </summary>
        public static readonly StringName MouseShapeEntered = "mouse_shape_entered";
        /// <summary>
        /// Cached name for the 'mouse_shape_exited' signal.
        /// </summary>
        public static readonly StringName MouseShapeExited = "mouse_shape_exited";
    }
}

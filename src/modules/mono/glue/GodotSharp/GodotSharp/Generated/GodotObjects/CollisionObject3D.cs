namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for 3D physics objects. <see cref="Godot.CollisionObject3D"/> can hold any number of <see cref="Godot.Shape3D"/>s for collision. Each shape must be assigned to a <i>shape owner</i>. Shape owners are not nodes and do not appear in the editor, but are accessible through code using the <c>shape_owner_*</c> methods.</para>
/// <para><b>Warning:</b> With a non-uniform scale, this node will likely not behave as expected. It is advised to keep its scale the same on all axes and adjust its collision shape(s) instead.</para>
/// </summary>
public partial class CollisionObject3D : Node3D
{
    public enum DisableModeEnum : long
    {
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, remove from the physics simulation to stop all physics interactions with this <see cref="Godot.CollisionObject3D"/>.</para>
        /// <para>Automatically re-added to the physics simulation when the <see cref="Godot.Node"/> is processed again.</para>
        /// </summary>
        Remove = 0,
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, make the body static. Doesn't affect <see cref="Godot.Area3D"/>. <see cref="Godot.PhysicsBody3D"/> can't be affected by forces or other bodies while static.</para>
        /// <para>Automatically set <see cref="Godot.PhysicsBody3D"/> back to its original mode when the <see cref="Godot.Node"/> is processed again.</para>
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
    public CollisionObject3D.DisableModeEnum DisableMode
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
    /// <para>The physics layers this CollisionObject3D <b>is in</b>. Collision objects can exist in one or more of 32 different layers. See also <see cref="Godot.CollisionObject3D.CollisionMask"/>.</para>
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
    /// <para>The physics layers this CollisionObject3D <b>scans</b>. Collision objects can scan one or more of 32 different layers. See also <see cref="Godot.CollisionObject3D.CollisionLayer"/>.</para>
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
    /// <para>If <see langword="true"/>, this object is pickable. A pickable object can detect the mouse pointer entering/leaving, and if the mouse is inside it, report input events. Requires at least one <see cref="Godot.CollisionObject3D.CollisionLayer"/> bit to be set.</para>
    /// </summary>
    public bool InputRayPickable
    {
        get
        {
            return IsRayPickable();
        }
        set
        {
            SetRayPickable(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.CollisionObject3D"/> will continue to receive input events as the mouse is dragged across its shapes.</para>
    /// </summary>
    public bool InputCaptureOnDrag
    {
        get
        {
            return GetCaptureInputOnDrag();
        }
        set
        {
            SetCaptureInputOnDrag(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CollisionObject3D);

    private static readonly StringName NativeName = "CollisionObject3D";

    internal CollisionObject3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionObject3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionObject3D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Receives unhandled <see cref="Godot.InputEvent"/>s. <paramref name="eventPosition"/> is the location in world space of the mouse pointer on the surface of the shape with index <paramref name="shapeIdx"/> and <paramref name="normal"/> is the normal vector of the surface at that point. Connect to the <see cref="Godot.CollisionObject3D.InputEvent"/> signal to easily pick up these events.</para>
    /// <para><b>Note:</b> <see cref="Godot.CollisionObject3D._InputEvent(Camera3D, InputEvent, Vector3, Vector3, int)"/> requires <see cref="Godot.CollisionObject3D.InputRayPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject3D.CollisionLayer"/> bit to be set.</para>
    /// </summary>
    public virtual unsafe void _InputEvent(Camera3D camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, int shapeIdx)
    {
    }

    /// <summary>
    /// <para>Called when the mouse pointer enters any of this object's shapes. Requires <see cref="Godot.CollisionObject3D.InputRayPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject3D.CollisionLayer"/> bit to be set. Note that moving between different shapes within a single <see cref="Godot.CollisionObject3D"/> won't cause this function to be called.</para>
    /// </summary>
    public virtual void _MouseEnter()
    {
    }

    /// <summary>
    /// <para>Called when the mouse pointer exits all this object's shapes. Requires <see cref="Godot.CollisionObject3D.InputRayPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject3D.CollisionLayer"/> bit to be set. Note that moving between different shapes within a single <see cref="Godot.CollisionObject3D"/> won't cause this function to be called.</para>
    /// </summary>
    public virtual void _MouseExit()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionLayer(uint layer)
    {
        NativeCalls.godot_icall_1_208(MethodBind0, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind2, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.CollisionObject3D.CollisionLayer"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind4, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.CollisionObject3D.CollisionLayer"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind5, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.CollisionObject3D.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.CollisionObject3D.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPriority, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionPriority(float priority)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPriority, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionPriority()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableMode, 1623620376ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableMode(CollisionObject3D.DisableModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisableMode, 410164780ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CollisionObject3D.DisableModeEnum GetDisableMode()
    {
        return (CollisionObject3D.DisableModeEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRayPickable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRayPickable(bool rayPickable)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), rayPickable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRayPickable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRayPickable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaptureInputOnDrag, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaptureInputOnDrag(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaptureInputOnDrag, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCaptureInputOnDrag()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the object's <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateShapeOwner, 3429307534ul);

    /// <summary>
    /// <para>Creates a new shape owner for the given object. Returns <c>owner_id</c> of the new owner for future reference.</para>
    /// </summary>
    public uint CreateShapeOwner(GodotObject owner)
    {
        return NativeCalls.godot_icall_1_311(MethodBind17, GodotObject.GetPtr(this), GodotObject.GetPtr(owner));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveShapeOwner, 1286410249ul);

    /// <summary>
    /// <para>Removes the given shape owner.</para>
    /// </summary>
    public void RemoveShapeOwner(uint ownerId)
    {
        NativeCalls.godot_icall_1_208(MethodBind18, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShapeOwners, 969006518ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <c>owner_id</c> identifiers. You can use these ids in other methods that take <c>owner_id</c> as an argument.</para>
    /// </summary>
    public int[] GetShapeOwners()
    {
        return NativeCalls.godot_icall_0_151(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerSetTransform, 3616898986ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> of the given shape owner.</para>
    /// </summary>
    public unsafe void ShapeOwnerSetTransform(uint ownerId, Transform3D transform)
    {
        NativeCalls.godot_icall_2_323(MethodBind20, GodotObject.GetPtr(this), ownerId, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetTransform, 1965739696ul);

    /// <summary>
    /// <para>Returns the shape owner's <see cref="Godot.Transform3D"/>.</para>
    /// </summary>
    public Transform3D ShapeOwnerGetTransform(uint ownerId)
    {
        return NativeCalls.godot_icall_1_324(MethodBind21, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetOwner, 3332903315ul);

    /// <summary>
    /// <para>Returns the parent object of the given shape owner.</para>
    /// </summary>
    public GodotObject ShapeOwnerGetOwner(uint ownerId)
    {
        return (GodotObject)NativeCalls.godot_icall_1_314(MethodBind22, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerSetDisabled, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, disables the given shape owner.</para>
    /// </summary>
    public void ShapeOwnerSetDisabled(uint ownerId, bool disabled)
    {
        NativeCalls.godot_icall_2_269(MethodBind23, GodotObject.GetPtr(this), ownerId, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShapeOwnerDisabled, 1116898809ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the shape owner and its shapes are disabled.</para>
    /// </summary>
    public bool IsShapeOwnerDisabled(uint ownerId)
    {
        return NativeCalls.godot_icall_1_270(MethodBind24, GodotObject.GetPtr(this), ownerId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerAddShape, 2566676345ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Shape3D"/> to the shape owner.</para>
    /// </summary>
    public void ShapeOwnerAddShape(uint ownerId, Shape3D shape)
    {
        NativeCalls.godot_icall_2_317(MethodBind25, GodotObject.GetPtr(this), ownerId, GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetShapeCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of shapes the given shape owner contains.</para>
    /// </summary>
    public int ShapeOwnerGetShapeCount(uint ownerId)
    {
        return NativeCalls.godot_icall_1_318(MethodBind26, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetShape, 4015519174ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Shape3D"/> with the given ID from the given shape owner.</para>
    /// </summary>
    public Shape3D ShapeOwnerGetShape(uint ownerId, int shapeId)
    {
        return (Shape3D)NativeCalls.godot_icall_2_319(MethodBind27, GodotObject.GetPtr(this), ownerId, shapeId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerGetShapeIndex, 3175239445ul);

    /// <summary>
    /// <para>Returns the child index of the <see cref="Godot.Shape3D"/> with the given ID from the given shape owner.</para>
    /// </summary>
    public int ShapeOwnerGetShapeIndex(uint ownerId, int shapeId)
    {
        return NativeCalls.godot_icall_2_320(MethodBind28, GodotObject.GetPtr(this), ownerId, shapeId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerRemoveShape, 3937882851ul);

    /// <summary>
    /// <para>Removes a shape from the given shape owner.</para>
    /// </summary>
    public void ShapeOwnerRemoveShape(uint ownerId, int shapeId)
    {
        NativeCalls.godot_icall_2_321(MethodBind29, GodotObject.GetPtr(this), ownerId, shapeId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeOwnerClearShapes, 1286410249ul);

    /// <summary>
    /// <para>Removes all shapes from the shape owner.</para>
    /// </summary>
    public void ShapeOwnerClearShapes(uint ownerId)
    {
        NativeCalls.godot_icall_1_208(MethodBind30, GodotObject.GetPtr(this), ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeFindOwner, 923996154ul);

    /// <summary>
    /// <para>Returns the <c>owner_id</c> of the given shape.</para>
    /// </summary>
    public uint ShapeFindOwner(int shapeIndex)
    {
        return NativeCalls.godot_icall_1_322(MethodBind31, GodotObject.GetPtr(this), shapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CollisionObject3D.InputEvent"/> event of a <see cref="Godot.CollisionObject3D"/> class.
    /// </summary>
    public delegate void InputEventEventHandler(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx);

    private static void InputEventTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 5);
        ((InputEventEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]), VariantUtils.ConvertTo<InputEvent>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]), VariantUtils.ConvertTo<Vector3>(args[3]), VariantUtils.ConvertTo<long>(args[4]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the object receives an unhandled <see cref="Godot.InputEvent"/>. <c>eventPosition</c> is the location in world space of the mouse pointer on the surface of the shape with index <c>shapeIdx</c> and <c>normal</c> is the normal vector of the surface at that point.</para>
    /// </summary>
    public unsafe event InputEventEventHandler InputEvent
    {
        add => Connect(SignalName.InputEvent, Callable.CreateWithUnsafeTrampoline(value, &InputEventTrampoline));
        remove => Disconnect(SignalName.InputEvent, Callable.CreateWithUnsafeTrampoline(value, &InputEventTrampoline));
    }

    protected void EmitSignalInputEvent(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx)
    {
        EmitSignal(SignalName.InputEvent, camera, @event, eventPosition, normal, shapeIdx);
    }

    /// <summary>
    /// <para>Emitted when the mouse pointer enters any of this object's shapes. Requires <see cref="Godot.CollisionObject3D.InputRayPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject3D.CollisionLayer"/> bit to be set.</para>
    /// <para><b>Note:</b> Due to the lack of continuous collision detection, this signal may not be emitted in the expected order if the mouse moves fast enough and the <see cref="Godot.CollisionObject3D"/>'s area is small. This signal may also not be emitted if another <see cref="Godot.CollisionObject3D"/> is overlapping the <see cref="Godot.CollisionObject3D"/> in question.</para>
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
    /// <para>Emitted when the mouse pointer exits all this object's shapes. Requires <see cref="Godot.CollisionObject3D.InputRayPickable"/> to be <see langword="true"/> and at least one <see cref="Godot.CollisionObject3D.CollisionLayer"/> bit to be set.</para>
    /// <para><b>Note:</b> Due to the lack of continuous collision detection, this signal may not be emitted in the expected order if the mouse moves fast enough and the <see cref="Godot.CollisionObject3D"/>'s area is small. This signal may also not be emitted if another <see cref="Godot.CollisionObject3D"/> is overlapping the <see cref="Godot.CollisionObject3D"/> in question.</para>
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
    private static readonly StringName SignalProxyName_input_event = "InputEvent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_entered = "MouseEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_exited = "MouseExited";

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
        if ((method == MethodProxyName__input_event || method == MethodName._InputEvent) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__input_event.NativeValue))
        {
            _InputEvent(VariantUtils.ConvertTo<Camera3D>(args[0]), VariantUtils.ConvertTo<InputEvent>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]), VariantUtils.ConvertTo<Vector3>(args[3]), VariantUtils.ConvertTo<int>(args[4]));
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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
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
        /// Cached name for the 'input_ray_pickable' property.
        /// </summary>
        public static readonly StringName InputRayPickable = "input_ray_pickable";
        /// <summary>
        /// Cached name for the 'input_capture_on_drag' property.
        /// </summary>
        public static readonly StringName InputCaptureOnDrag = "input_capture_on_drag";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
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
        /// Cached name for the 'set_ray_pickable' method.
        /// </summary>
        public static readonly StringName SetRayPickable = "set_ray_pickable";
        /// <summary>
        /// Cached name for the 'is_ray_pickable' method.
        /// </summary>
        public static readonly StringName IsRayPickable = "is_ray_pickable";
        /// <summary>
        /// Cached name for the 'set_capture_input_on_drag' method.
        /// </summary>
        public static readonly StringName SetCaptureInputOnDrag = "set_capture_input_on_drag";
        /// <summary>
        /// Cached name for the 'get_capture_input_on_drag' method.
        /// </summary>
        public static readonly StringName GetCaptureInputOnDrag = "get_capture_input_on_drag";
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
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
    public new class SignalName : Node3D.SignalName
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
    }
}

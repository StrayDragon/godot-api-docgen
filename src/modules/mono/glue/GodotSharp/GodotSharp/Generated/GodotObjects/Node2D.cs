namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D game object, with a transform (position, rotation, and scale). All 2D nodes, including physics objects and sprites, inherit from Node2D. Use Node2D as a parent node to move, scale and rotate children in a 2D project. Also gives control of the node's render order.</para>
/// <para><b>Note:</b> Since both <see cref="Godot.Node2D"/> and <see cref="Godot.Control"/> inherit from <see cref="Godot.CanvasItem"/>, they share several concepts from the class such as the <see cref="Godot.CanvasItem.ZIndex"/> and <see cref="Godot.CanvasItem.Visible"/> properties.</para>
/// </summary>
public partial class Node2D : CanvasItem
{
    /// <summary>
    /// <para>Position, relative to the node's parent. See also <see cref="Godot.Node2D.GlobalPosition"/>.</para>
    /// </summary>
    public Vector2 Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            SetPosition(value);
        }
    }

    /// <summary>
    /// <para>Rotation in radians, relative to the node's parent. See also <see cref="Godot.Node2D.GlobalRotation"/>.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Godot.Node2D.RotationDegrees"/>.</para>
    /// </summary>
    public float Rotation
    {
        get
        {
            return GetRotation();
        }
        set
        {
            SetRotation(value);
        }
    }

    /// <summary>
    /// <para>Helper property to access <see cref="Godot.Node2D.Rotation"/> in degrees instead of radians. See also <see cref="Godot.Node2D.GlobalRotationDegrees"/>.</para>
    /// </summary>
    public float RotationDegrees
    {
        get
        {
            return GetRotationDegrees();
        }
        set
        {
            SetRotationDegrees(value);
        }
    }

    /// <summary>
    /// <para>The node's scale, relative to the node's parent. Unscaled value: <c>(1, 1)</c>. See also <see cref="Godot.Node2D.GlobalScale"/>.</para>
    /// <para><b>Note:</b> Negative X scales in 2D are not decomposable from the transformation matrix. Due to the way scale is represented with transformation matrices in Godot, negative scales on the X axis will be changed to negative scales on the Y axis and a rotation of 180 degrees when decomposed.</para>
    /// </summary>
    public Vector2 Scale
    {
        get
        {
            return GetScale();
        }
        set
        {
            SetScale(value);
        }
    }

    /// <summary>
    /// <para>If set to a non-zero value, slants the node in one direction or another. This can be used for pseudo-3D effects. See also <see cref="Godot.Node2D.GlobalSkew"/>.</para>
    /// <para><b>Note:</b> Skew is performed on the X axis only, and <i>between</i> rotation and scaling.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <c>skew = deg_to_rad(value_in_degrees)</c>.</para>
    /// </summary>
    public float Skew
    {
        get
        {
            return GetSkew();
        }
        set
        {
            SetSkew(value);
        }
    }

    /// <summary>
    /// <para>The node's <see cref="Godot.Transform2D"/>, relative to the node's parent. See also <see cref="Godot.Node2D.GlobalTransform"/>.</para>
    /// </summary>
    public Transform2D Transform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    /// <summary>
    /// <para>Global position. See also <see cref="Godot.Node2D.Position"/>.</para>
    /// </summary>
    public Vector2 GlobalPosition
    {
        get
        {
            return GetGlobalPosition();
        }
        set
        {
            SetGlobalPosition(value);
        }
    }

    /// <summary>
    /// <para>Global rotation in radians. See also <see cref="Godot.Node2D.Rotation"/>.</para>
    /// </summary>
    public float GlobalRotation
    {
        get
        {
            return GetGlobalRotation();
        }
        set
        {
            SetGlobalRotation(value);
        }
    }

    /// <summary>
    /// <para>Helper property to access <see cref="Godot.Node2D.GlobalRotation"/> in degrees instead of radians. See also <see cref="Godot.Node2D.RotationDegrees"/>.</para>
    /// </summary>
    public float GlobalRotationDegrees
    {
        get
        {
            return GetGlobalRotationDegrees();
        }
        set
        {
            SetGlobalRotationDegrees(value);
        }
    }

    /// <summary>
    /// <para>Global scale. See also <see cref="Godot.Node2D.Scale"/>.</para>
    /// </summary>
    public Vector2 GlobalScale
    {
        get
        {
            return GetGlobalScale();
        }
        set
        {
            SetGlobalScale(value);
        }
    }

    /// <summary>
    /// <para>Global skew in radians. See also <see cref="Godot.Node2D.Skew"/>.</para>
    /// </summary>
    public float GlobalSkew
    {
        get
        {
            return GetGlobalSkew();
        }
        set
        {
            SetGlobalSkew(value);
        }
    }

    /// <summary>
    /// <para>Global <see cref="Godot.Transform2D"/>. See also <see cref="Godot.Node2D.Transform"/>.</para>
    /// </summary>
    public Transform2D GlobalTransform
    {
        get
        {
            return GetGlobalTransform();
        }
        set
        {
            SetGlobalTransform(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Node2D);

    private static readonly StringName NativeName = "Node2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Node2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Node2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Node2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotation(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind1, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationDegrees, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationDegrees(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkew, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkew(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind4, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationDegrees, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRotationDegrees()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkew, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSkew()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rotate, 373806689ul);

    /// <summary>
    /// <para>Applies a rotation to the node, in radians, starting from its current rotation. This is equivalent to <c>rotation += radians</c>.</para>
    /// </summary>
    public void Rotate(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveLocalX, 2087892650ul);

    /// <summary>
    /// <para>Applies a local translation on the node's X axis with the amount specified in <paramref name="delta"/>. If <paramref name="scaled"/> is <see langword="false"/>, normalizes the movement to occur independently of the node's <see cref="Godot.Node2D.Scale"/>.</para>
    /// </summary>
    public void MoveLocalX(float delta, bool scaled = false)
    {
        NativeCalls.godot_icall_2_894(MethodBind11, GodotObject.GetPtr(this), delta, scaled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveLocalY, 2087892650ul);

    /// <summary>
    /// <para>Applies a local translation on the node's Y axis with the amount specified in <paramref name="delta"/>. If <paramref name="scaled"/> is <see langword="false"/>, normalizes the movement to occur independently of the node's <see cref="Godot.Node2D.Scale"/>.</para>
    /// </summary>
    public void MoveLocalY(float delta, bool scaled = false)
    {
        NativeCalls.godot_icall_2_894(MethodBind12, GodotObject.GetPtr(this), delta, scaled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Translate, 743155724ul);

    /// <summary>
    /// <para>Translates the node by the given <paramref name="offset"/> in local coordinates. This is equivalent to <c>position += offset</c>.</para>
    /// </summary>
    public unsafe void Translate(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind13, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalTranslate, 743155724ul);

    /// <summary>
    /// <para>Adds the <paramref name="offset"/> vector to the node's global position.</para>
    /// </summary>
    public unsafe void GlobalTranslate(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind14, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyScale, 743155724ul);

    /// <summary>
    /// <para>Multiplies the current scale by the <paramref name="ratio"/> vector.</para>
    /// </summary>
    public unsafe void ApplyScale(Vector2 ratio)
    {
        NativeCalls.godot_icall_1_36(MethodBind15, GodotObject.GetPtr(this), &ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind16, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGlobalPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalRotation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlobalRotation(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalRotationDegrees, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlobalRotationDegrees(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalRotation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlobalRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalRotationDegrees, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlobalRotationDegrees()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalSkew, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlobalSkew(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalSkew, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlobalSkew()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind24, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGlobalScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform2D xform)
    {
        NativeCalls.godot_icall_1_218(MethodBind26, GodotObject.GetPtr(this), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalTransform(Transform2D xform)
    {
        NativeCalls.godot_icall_1_218(MethodBind27, GodotObject.GetPtr(this), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LookAt, 743155724ul);

    /// <summary>
    /// <para>Rotates the node so that its local +X axis points towards the <paramref name="point"/>, which is expected to use global coordinates. This method is a combination of both <see cref="Godot.Node2D.Rotate(float)"/> and <see cref="Godot.Node2D.GetAngleTo(Vector2)"/>.</para>
    /// <para><paramref name="point"/> should not be the same as the node's position, otherwise the node always looks to the right.</para>
    /// </summary>
    public unsafe void LookAt(Vector2 point)
    {
        NativeCalls.godot_icall_1_36(MethodBind28, GodotObject.GetPtr(this), &point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngleTo, 2276447920ul);

    /// <summary>
    /// <para>Returns the angle between the node and the <paramref name="point"/> in radians. See also <see cref="Godot.Node2D.LookAt(Vector2)"/>.</para>
    /// <para><a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/node2d_get_angle_to.png">Illustration of the returned angle.</a></para>
    /// </summary>
    public unsafe float GetAngleTo(Vector2 point)
    {
        return NativeCalls.godot_icall_1_287(MethodBind29, GodotObject.GetPtr(this), &point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToLocal, 2656412154ul);

    /// <summary>
    /// <para>Transforms the provided global position into a position in local coordinate space. The output will be local relative to the <see cref="Godot.Node2D"/> it is called on. e.g. It is appropriate for determining the positions of child nodes, but it is not appropriate for determining its own position relative to its parent.</para>
    /// </summary>
    public unsafe Vector2 ToLocal(Vector2 globalPoint)
    {
        return NativeCalls.godot_icall_1_20(MethodBind30, GodotObject.GetPtr(this), &globalPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToGlobal, 2656412154ul);

    /// <summary>
    /// <para>Transforms the provided local position into a position in global coordinate space. The input is expected to be local relative to the <see cref="Godot.Node2D"/> it is called on. e.g. Applying this method to the positions of child nodes will correctly transform their positions into the global coordinate space, but applying it to a node's own position will give an incorrect result, as it will incorporate the node's own transformation into its global position.</para>
    /// </summary>
    public unsafe Vector2 ToGlobal(Vector2 localPoint)
    {
        return NativeCalls.godot_icall_1_20(MethodBind31, GodotObject.GetPtr(this), &localPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRelativeTransformToParent, 904556875ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform2D"/> relative to this node's parent.</para>
    /// </summary>
    public Transform2D GetRelativeTransformToParent(Node parent)
    {
        return NativeCalls.godot_icall_1_895(MethodBind32, GodotObject.GetPtr(this), GodotObject.GetPtr(parent));
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
    public new class PropertyName : CanvasItem.PropertyName
    {
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'rotation' property.
        /// </summary>
        public static readonly StringName Rotation = "rotation";
        /// <summary>
        /// Cached name for the 'rotation_degrees' property.
        /// </summary>
        public static readonly StringName RotationDegrees = "rotation_degrees";
        /// <summary>
        /// Cached name for the 'scale' property.
        /// </summary>
        public static readonly StringName Scale = "scale";
        /// <summary>
        /// Cached name for the 'skew' property.
        /// </summary>
        public static readonly StringName Skew = "skew";
        /// <summary>
        /// Cached name for the 'transform' property.
        /// </summary>
        public static readonly StringName Transform = "transform";
        /// <summary>
        /// Cached name for the 'global_position' property.
        /// </summary>
        public static readonly StringName GlobalPosition = "global_position";
        /// <summary>
        /// Cached name for the 'global_rotation' property.
        /// </summary>
        public static readonly StringName GlobalRotation = "global_rotation";
        /// <summary>
        /// Cached name for the 'global_rotation_degrees' property.
        /// </summary>
        public static readonly StringName GlobalRotationDegrees = "global_rotation_degrees";
        /// <summary>
        /// Cached name for the 'global_scale' property.
        /// </summary>
        public static readonly StringName GlobalScale = "global_scale";
        /// <summary>
        /// Cached name for the 'global_skew' property.
        /// </summary>
        public static readonly StringName GlobalSkew = "global_skew";
        /// <summary>
        /// Cached name for the 'global_transform' property.
        /// </summary>
        public static readonly StringName GlobalTransform = "global_transform";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CanvasItem.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'set_rotation' method.
        /// </summary>
        public static readonly StringName SetRotation = "set_rotation";
        /// <summary>
        /// Cached name for the 'set_rotation_degrees' method.
        /// </summary>
        public static readonly StringName SetRotationDegrees = "set_rotation_degrees";
        /// <summary>
        /// Cached name for the 'set_skew' method.
        /// </summary>
        public static readonly StringName SetSkew = "set_skew";
        /// <summary>
        /// Cached name for the 'set_scale' method.
        /// </summary>
        public static readonly StringName SetScale = "set_scale";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'get_rotation' method.
        /// </summary>
        public static readonly StringName GetRotation = "get_rotation";
        /// <summary>
        /// Cached name for the 'get_rotation_degrees' method.
        /// </summary>
        public static readonly StringName GetRotationDegrees = "get_rotation_degrees";
        /// <summary>
        /// Cached name for the 'get_skew' method.
        /// </summary>
        public static readonly StringName GetSkew = "get_skew";
        /// <summary>
        /// Cached name for the 'get_scale' method.
        /// </summary>
        public static readonly StringName GetScale = "get_scale";
        /// <summary>
        /// Cached name for the 'rotate' method.
        /// </summary>
        public static readonly StringName Rotate = "rotate";
        /// <summary>
        /// Cached name for the 'move_local_x' method.
        /// </summary>
        public static readonly StringName MoveLocalX = "move_local_x";
        /// <summary>
        /// Cached name for the 'move_local_y' method.
        /// </summary>
        public static readonly StringName MoveLocalY = "move_local_y";
        /// <summary>
        /// Cached name for the 'translate' method.
        /// </summary>
        public static readonly StringName Translate = "translate";
        /// <summary>
        /// Cached name for the 'global_translate' method.
        /// </summary>
        public static readonly StringName GlobalTranslate = "global_translate";
        /// <summary>
        /// Cached name for the 'apply_scale' method.
        /// </summary>
        public static readonly StringName ApplyScale = "apply_scale";
        /// <summary>
        /// Cached name for the 'set_global_position' method.
        /// </summary>
        public static readonly StringName SetGlobalPosition = "set_global_position";
        /// <summary>
        /// Cached name for the 'get_global_position' method.
        /// </summary>
        public static readonly StringName GetGlobalPosition = "get_global_position";
        /// <summary>
        /// Cached name for the 'set_global_rotation' method.
        /// </summary>
        public static readonly StringName SetGlobalRotation = "set_global_rotation";
        /// <summary>
        /// Cached name for the 'set_global_rotation_degrees' method.
        /// </summary>
        public static readonly StringName SetGlobalRotationDegrees = "set_global_rotation_degrees";
        /// <summary>
        /// Cached name for the 'get_global_rotation' method.
        /// </summary>
        public static readonly StringName GetGlobalRotation = "get_global_rotation";
        /// <summary>
        /// Cached name for the 'get_global_rotation_degrees' method.
        /// </summary>
        public static readonly StringName GetGlobalRotationDegrees = "get_global_rotation_degrees";
        /// <summary>
        /// Cached name for the 'set_global_skew' method.
        /// </summary>
        public static readonly StringName SetGlobalSkew = "set_global_skew";
        /// <summary>
        /// Cached name for the 'get_global_skew' method.
        /// </summary>
        public static readonly StringName GetGlobalSkew = "get_global_skew";
        /// <summary>
        /// Cached name for the 'set_global_scale' method.
        /// </summary>
        public static readonly StringName SetGlobalScale = "set_global_scale";
        /// <summary>
        /// Cached name for the 'get_global_scale' method.
        /// </summary>
        public static readonly StringName GetGlobalScale = "get_global_scale";
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'set_global_transform' method.
        /// </summary>
        public static readonly StringName SetGlobalTransform = "set_global_transform";
        /// <summary>
        /// Cached name for the 'look_at' method.
        /// </summary>
        public static readonly StringName LookAt = "look_at";
        /// <summary>
        /// Cached name for the 'get_angle_to' method.
        /// </summary>
        public static readonly StringName GetAngleTo = "get_angle_to";
        /// <summary>
        /// Cached name for the 'to_local' method.
        /// </summary>
        public static readonly StringName ToLocal = "to_local";
        /// <summary>
        /// Cached name for the 'to_global' method.
        /// </summary>
        public static readonly StringName ToGlobal = "to_global";
        /// <summary>
        /// Cached name for the 'get_relative_transform_to_parent' method.
        /// </summary>
        public static readonly StringName GetRelativeTransformToParent = "get_relative_transform_to_parent";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CanvasItem.SignalName
    {
    }
}

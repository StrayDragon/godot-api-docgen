namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node draws a 2D polyline, i.e. a shape consisting of several points connected by segments. <see cref="Godot.Line2D"/> is not a mathematical polyline, i.e. the segments are not infinitely thin. It is intended for rendering and it can be colored and optionally textured.</para>
/// <para><b>Warning:</b> Certain configurations may be impossible to draw nicely, such as very sharp angles. In these situations, the node uses fallback drawing logic to look decent.</para>
/// <para><b>Note:</b> <see cref="Godot.Line2D"/> is drawn using a 2D mesh.</para>
/// </summary>
public partial class Line2D : Node2D
{
    public enum LineJointMode : long
    {
        /// <summary>
        /// <para>Makes the polyline's joints pointy, connecting the sides of the two segments by extending them until they intersect. If the rotation of a joint is too big (based on <see cref="Godot.Line2D.SharpLimit"/>), the joint falls back to <see cref="Godot.Line2D.LineJointMode.Bevel"/> to prevent very long miters.</para>
        /// </summary>
        Sharp = 0,
        /// <summary>
        /// <para>Makes the polyline's joints bevelled/chamfered, connecting the sides of the two segments with a simple line.</para>
        /// </summary>
        Bevel = 1,
        /// <summary>
        /// <para>Makes the polyline's joints rounded, connecting the sides of the two segments with an arc. The detail of this arc depends on <see cref="Godot.Line2D.RoundPrecision"/>.</para>
        /// </summary>
        Round = 2
    }

    public enum LineCapMode : long
    {
        /// <summary>
        /// <para>Draws no line cap.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Draws the line cap as a box, slightly extending the first/last segment.</para>
        /// </summary>
        Box = 1,
        /// <summary>
        /// <para>Draws the line cap as a semicircle attached to the first/last segment.</para>
        /// </summary>
        Round = 2
    }

    public enum LineTextureMode : long
    {
        /// <summary>
        /// <para>Takes the left pixels of the texture and renders them over the whole polyline.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Tiles the texture over the polyline. <see cref="Godot.CanvasItem.TextureRepeat"/> of the <see cref="Godot.Line2D"/> node must be <see cref="Godot.CanvasItem.TextureRepeatEnum.Enabled"/> or <see cref="Godot.CanvasItem.TextureRepeatEnum.Mirror"/> for it to work properly.</para>
        /// </summary>
        Tile = 1,
        /// <summary>
        /// <para>Stretches the texture across the polyline. <see cref="Godot.CanvasItem.TextureRepeat"/> of the <see cref="Godot.Line2D"/> node must be <see cref="Godot.CanvasItem.TextureRepeatEnum.Disabled"/> for best results.</para>
        /// </summary>
        Stretch = 2
    }

    /// <summary>
    /// <para>The points of the polyline, interpreted in local 2D coordinates. Segments are drawn between the adjacent points in this array.</para>
    /// </summary>
    public Vector2[] Points
    {
        get
        {
            return GetPoints();
        }
        set
        {
            SetPoints(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> and the polyline has more than 2 points, the last point and the first one will be connected by a segment.</para>
    /// <para><b>Note:</b> The shape of the closing segment is not guaranteed to be seamless if a <see cref="Godot.Line2D.WidthCurve"/> is provided.</para>
    /// <para><b>Note:</b> The joint between the closing segment and the first segment is drawn first and it samples the <see cref="Godot.Line2D.Gradient"/> and the <see cref="Godot.Line2D.WidthCurve"/> at the beginning. This is an implementation detail that might change in a future version.</para>
    /// </summary>
    public bool Closed
    {
        get
        {
            return IsClosed();
        }
        set
        {
            SetClosed(value);
        }
    }

    /// <summary>
    /// <para>The polyline's width.</para>
    /// </summary>
    public float Width
    {
        get
        {
            return GetWidth();
        }
        set
        {
            SetWidth(value);
        }
    }

    /// <summary>
    /// <para>The polyline's width curve. The width of the polyline over its length will be equivalent to the value of the width curve over its domain. The width curve should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve WidthCurve
    {
        get
        {
            return GetCurve();
        }
        set
        {
            SetCurve(value);
        }
    }

    /// <summary>
    /// <para>The color of the polyline. Will not be used if a gradient is set.</para>
    /// </summary>
    public Color DefaultColor
    {
        get
        {
            return GetDefaultColor();
        }
        set
        {
            SetDefaultColor(value);
        }
    }

    /// <summary>
    /// <para>The gradient is drawn through the whole line from start to finish. The <see cref="Godot.Line2D.DefaultColor"/> will not be used if this property is set.</para>
    /// </summary>
    public Gradient Gradient
    {
        get
        {
            return GetGradient();
        }
        set
        {
            SetGradient(value);
        }
    }

    /// <summary>
    /// <para>The texture used for the polyline. Uses <see cref="Godot.Line2D.TextureMode"/> for drawing style.</para>
    /// </summary>
    public Texture2D Texture
    {
        get
        {
            return GetTexture();
        }
        set
        {
            SetTexture(value);
        }
    }

    /// <summary>
    /// <para>The style to render the <see cref="Godot.Line2D.Texture"/> of the polyline.</para>
    /// </summary>
    public Line2D.LineTextureMode TextureMode
    {
        get
        {
            return GetTextureMode();
        }
        set
        {
            SetTextureMode(value);
        }
    }

    /// <summary>
    /// <para>The style of the connections between segments of the polyline.</para>
    /// </summary>
    public Line2D.LineJointMode JointMode
    {
        get
        {
            return GetJointMode();
        }
        set
        {
            SetJointMode(value);
        }
    }

    /// <summary>
    /// <para>The style of the beginning of the polyline, if <see cref="Godot.Line2D.Closed"/> is <see langword="false"/>.</para>
    /// </summary>
    public Line2D.LineCapMode BeginCapMode
    {
        get
        {
            return GetBeginCapMode();
        }
        set
        {
            SetBeginCapMode(value);
        }
    }

    /// <summary>
    /// <para>The style of the end of the polyline, if <see cref="Godot.Line2D.Closed"/> is <see langword="false"/>.</para>
    /// </summary>
    public Line2D.LineCapMode EndCapMode
    {
        get
        {
            return GetEndCapMode();
        }
        set
        {
            SetEndCapMode(value);
        }
    }

    /// <summary>
    /// <para>Determines the miter limit of the polyline. Normally, when <see cref="Godot.Line2D.JointMode"/> is set to <see cref="Godot.Line2D.LineJointMode.Sharp"/>, sharp angles fall back to using the logic of <see cref="Godot.Line2D.LineJointMode.Bevel"/> joints to prevent very long miters. Higher values of this property mean that the fallback to a bevel joint will happen at sharper angles.</para>
    /// </summary>
    public float SharpLimit
    {
        get
        {
            return GetSharpLimit();
        }
        set
        {
            SetSharpLimit(value);
        }
    }

    /// <summary>
    /// <para>The smoothness used for rounded joints and caps. Higher values result in smoother corners, but are more demanding to render and update.</para>
    /// </summary>
    public int RoundPrecision
    {
        get
        {
            return GetRoundPrecision();
        }
        set
        {
            SetRoundPrecision(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the polyline's border will be anti-aliased.</para>
    /// <para><b>Note:</b> <see cref="Godot.Line2D"/> is not accelerated by batching when being anti-aliased.</para>
    /// </summary>
    public bool Antialiased
    {
        get
        {
            return GetAntialiased();
        }
        set
        {
            SetAntialiased(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Line2D);

    private static readonly StringName NativeName = "Line2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Line2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Line2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Line2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoints, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoints(Vector2[] points)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), points);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoints(ReadOnlySpan<Vector2> points)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), points);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoints, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPoints()
    {
        return NativeCalls.godot_icall_0_225(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointPosition, 163021252ul);

    /// <summary>
    /// <para>Overwrites the position of the point at the given <paramref name="index"/> with the supplied <paramref name="position"/>.</para>
    /// </summary>
    public unsafe void SetPointPosition(int index, Vector2 position)
    {
        NativeCalls.godot_icall_2_147(MethodBind2, GodotObject.GetPtr(this), index, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the position of the point at index <paramref name="index"/>.</para>
    /// </summary>
    public Vector2 GetPointPosition(int index)
    {
        return NativeCalls.godot_icall_1_148(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of points in the polyline.</para>
    /// </summary>
    public int GetPointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPoint, 2654014372ul);

    /// <summary>
    /// <para>Adds a point with the specified <paramref name="position"/> relative to the polyline's own position. If no <paramref name="index"/> is provided, the new point will be added to the end of the points array.</para>
    /// <para>If <paramref name="index"/> is given, the new point is inserted before the existing point identified by index <paramref name="index"/>. The indices of the points after the new point get increased by 1. The provided <paramref name="index"/> must not exceed the number of existing points in the polyline. See <see cref="Godot.Line2D.GetPointCount()"/>.</para>
    /// </summary>
    public unsafe void AddPoint(Vector2 position, int index = -1)
    {
        NativeCalls.godot_icall_2_786(MethodBind5, GodotObject.GetPtr(this), &position, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePoint, 1286410249ul);

    /// <summary>
    /// <para>Removes the point at index <paramref name="index"/> from the polyline.</para>
    /// </summary>
    public void RemovePoint(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearPoints, 3218959716ul);

    /// <summary>
    /// <para>Removes all points from the polyline, making it empty.</para>
    /// </summary>
    public void ClearPoints()
    {
        NativeCalls.godot_icall_0_3(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClosed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClosed(bool closed)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), closed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClosed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClosed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(float width)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDefaultColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind14, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetDefaultColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGradient, 2756054477ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGradient(Gradient color)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(color));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGradient, 132272999ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Gradient GetGradient()
    {
        return (Gradient)NativeCalls.godot_icall_0_63(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind18, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureMode, 1952559516ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureMode(Line2D.LineTextureMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureMode, 2341040722ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Line2D.LineTextureMode GetTextureMode()
    {
        return (Line2D.LineTextureMode)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointMode, 604292979ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJointMode(Line2D.LineJointMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointMode, 2546544037ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Line2D.LineJointMode GetJointMode()
    {
        return (Line2D.LineJointMode)NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBeginCapMode, 1669024546ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBeginCapMode(Line2D.LineCapMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBeginCapMode, 1107511441ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Line2D.LineCapMode GetBeginCapMode()
    {
        return (Line2D.LineCapMode)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndCapMode, 1669024546ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEndCapMode(Line2D.LineCapMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndCapMode, 1107511441ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Line2D.LineCapMode GetEndCapMode()
    {
        return (Line2D.LineCapMode)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSharpLimit, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSharpLimit(float limit)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), limit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSharpLimit, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSharpLimit()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRoundPrecision, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRoundPrecision(int precision)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), precision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoundPrecision, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRoundPrecision()
    {
        return NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAntialiased, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAntialiased(bool antialiased)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAntialiased, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAntialiased()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'points' property.
        /// </summary>
        public static readonly StringName Points = "points";
        /// <summary>
        /// Cached name for the 'closed' property.
        /// </summary>
        public static readonly StringName Closed = "closed";
        /// <summary>
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'width_curve' property.
        /// </summary>
        public static readonly StringName WidthCurve = "width_curve";
        /// <summary>
        /// Cached name for the 'default_color' property.
        /// </summary>
        public static readonly StringName DefaultColor = "default_color";
        /// <summary>
        /// Cached name for the 'gradient' property.
        /// </summary>
        public static readonly StringName Gradient = "gradient";
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'texture_mode' property.
        /// </summary>
        public static readonly StringName TextureMode = "texture_mode";
        /// <summary>
        /// Cached name for the 'joint_mode' property.
        /// </summary>
        public static readonly StringName JointMode = "joint_mode";
        /// <summary>
        /// Cached name for the 'begin_cap_mode' property.
        /// </summary>
        public static readonly StringName BeginCapMode = "begin_cap_mode";
        /// <summary>
        /// Cached name for the 'end_cap_mode' property.
        /// </summary>
        public static readonly StringName EndCapMode = "end_cap_mode";
        /// <summary>
        /// Cached name for the 'sharp_limit' property.
        /// </summary>
        public static readonly StringName SharpLimit = "sharp_limit";
        /// <summary>
        /// Cached name for the 'round_precision' property.
        /// </summary>
        public static readonly StringName RoundPrecision = "round_precision";
        /// <summary>
        /// Cached name for the 'antialiased' property.
        /// </summary>
        public static readonly StringName Antialiased = "antialiased";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_points' method.
        /// </summary>
        public static readonly StringName SetPoints = "set_points";
        /// <summary>
        /// Cached name for the 'get_points' method.
        /// </summary>
        public static readonly StringName GetPoints = "get_points";
        /// <summary>
        /// Cached name for the 'set_point_position' method.
        /// </summary>
        public static readonly StringName SetPointPosition = "set_point_position";
        /// <summary>
        /// Cached name for the 'get_point_position' method.
        /// </summary>
        public static readonly StringName GetPointPosition = "get_point_position";
        /// <summary>
        /// Cached name for the 'get_point_count' method.
        /// </summary>
        public static readonly StringName GetPointCount = "get_point_count";
        /// <summary>
        /// Cached name for the 'add_point' method.
        /// </summary>
        public static readonly StringName AddPoint = "add_point";
        /// <summary>
        /// Cached name for the 'remove_point' method.
        /// </summary>
        public static readonly StringName RemovePoint = "remove_point";
        /// <summary>
        /// Cached name for the 'clear_points' method.
        /// </summary>
        public static readonly StringName ClearPoints = "clear_points";
        /// <summary>
        /// Cached name for the 'set_closed' method.
        /// </summary>
        public static readonly StringName SetClosed = "set_closed";
        /// <summary>
        /// Cached name for the 'is_closed' method.
        /// </summary>
        public static readonly StringName IsClosed = "is_closed";
        /// <summary>
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'set_curve' method.
        /// </summary>
        public static readonly StringName SetCurve = "set_curve";
        /// <summary>
        /// Cached name for the 'get_curve' method.
        /// </summary>
        public static readonly StringName GetCurve = "get_curve";
        /// <summary>
        /// Cached name for the 'set_default_color' method.
        /// </summary>
        public static readonly StringName SetDefaultColor = "set_default_color";
        /// <summary>
        /// Cached name for the 'get_default_color' method.
        /// </summary>
        public static readonly StringName GetDefaultColor = "get_default_color";
        /// <summary>
        /// Cached name for the 'set_gradient' method.
        /// </summary>
        public static readonly StringName SetGradient = "set_gradient";
        /// <summary>
        /// Cached name for the 'get_gradient' method.
        /// </summary>
        public static readonly StringName GetGradient = "get_gradient";
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_texture_mode' method.
        /// </summary>
        public static readonly StringName SetTextureMode = "set_texture_mode";
        /// <summary>
        /// Cached name for the 'get_texture_mode' method.
        /// </summary>
        public static readonly StringName GetTextureMode = "get_texture_mode";
        /// <summary>
        /// Cached name for the 'set_joint_mode' method.
        /// </summary>
        public static readonly StringName SetJointMode = "set_joint_mode";
        /// <summary>
        /// Cached name for the 'get_joint_mode' method.
        /// </summary>
        public static readonly StringName GetJointMode = "get_joint_mode";
        /// <summary>
        /// Cached name for the 'set_begin_cap_mode' method.
        /// </summary>
        public static readonly StringName SetBeginCapMode = "set_begin_cap_mode";
        /// <summary>
        /// Cached name for the 'get_begin_cap_mode' method.
        /// </summary>
        public static readonly StringName GetBeginCapMode = "get_begin_cap_mode";
        /// <summary>
        /// Cached name for the 'set_end_cap_mode' method.
        /// </summary>
        public static readonly StringName SetEndCapMode = "set_end_cap_mode";
        /// <summary>
        /// Cached name for the 'get_end_cap_mode' method.
        /// </summary>
        public static readonly StringName GetEndCapMode = "get_end_cap_mode";
        /// <summary>
        /// Cached name for the 'set_sharp_limit' method.
        /// </summary>
        public static readonly StringName SetSharpLimit = "set_sharp_limit";
        /// <summary>
        /// Cached name for the 'get_sharp_limit' method.
        /// </summary>
        public static readonly StringName GetSharpLimit = "get_sharp_limit";
        /// <summary>
        /// Cached name for the 'set_round_precision' method.
        /// </summary>
        public static readonly StringName SetRoundPrecision = "set_round_precision";
        /// <summary>
        /// Cached name for the 'get_round_precision' method.
        /// </summary>
        public static readonly StringName GetRoundPrecision = "get_round_precision";
        /// <summary>
        /// Cached name for the 'set_antialiased' method.
        /// </summary>
        public static readonly StringName SetAntialiased = "set_antialiased";
        /// <summary>
        /// Cached name for the 'get_antialiased' method.
        /// </summary>
        public static readonly StringName GetAntialiased = "get_antialiased";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}

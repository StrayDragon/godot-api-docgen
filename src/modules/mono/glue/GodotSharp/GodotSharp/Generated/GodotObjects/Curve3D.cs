namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class describes a Bézier curve in 3D space. It is mainly used to give a shape to a <see cref="Godot.Path3D"/>, but can be manually sampled for other purposes.</para>
/// <para>It keeps a cache of precalculated points along the curve, to speed up further calculations.</para>
/// </summary>
public partial class Curve3D : Resource
{
    /// <summary>
    /// <para>If <see langword="true"/>, and the curve has more than 2 control points, the last point and the first one will be connected in a loop.</para>
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
    /// <para>The distance in meters between two adjacent cached points. Changing it forces the cache to be recomputed the next time the <see cref="Godot.Curve3D.GetBakedPoints()"/> or <see cref="Godot.Curve3D.GetBakedLength()"/> function is called. The smaller the distance, the more points in the cache and the more memory it will consume, so use with care.</para>
    /// </summary>
    public float BakeInterval
    {
        get
        {
            return GetBakeInterval();
        }
        set
        {
            SetBakeInterval(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The number of points describing the curve.</para>
    /// </summary>
    public int PointCount
    {
        get
        {
            return GetPointCount();
        }
        set
        {
            SetPointCount(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the curve will bake up vectors used for orientation. This is used when <see cref="Godot.PathFollow3D.RotationMode"/> is set to <see cref="Godot.PathFollow3D.RotationModeEnum.Oriented"/>. Changing it forces the cache to be recomputed.</para>
    /// </summary>
    public bool UpVectorEnabled
    {
        get
        {
            return IsUpVectorEnabled();
        }
        set
        {
            SetUpVectorEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Curve3D);

    private static readonly StringName NativeName = "Curve3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Curve3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Curve3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Curve3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPointCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPoint, 2931053748ul);

    /// <summary>
    /// <para>Adds a point with the specified <paramref name="position"/> relative to the curve's own position, with control points <paramref name="in"/> and <paramref name="out"/>. Appends the new point at the end of the point list.</para>
    /// <para>If <paramref name="index"/> is given, the new point is inserted before the existing point identified by index <paramref name="index"/>. Every existing point starting from <paramref name="index"/> is shifted further down the list of points. The index must be greater than or equal to <c>0</c> and must not exceed the number of existing points in the line. See <see cref="Godot.Curve3D.PointCount"/>.</para>
    /// </summary>
    /// <param name="in">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    /// <param name="out">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void AddPoint(Vector3 position, Nullable<Vector3> @in = null, Nullable<Vector3> @out = null, int index = -1)
    {
        Vector3 @inOrDefVal = @in.HasValue ? @in.Value : new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 @outOrDefVal = @out.HasValue ? @out.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_4_361(MethodBind2, GodotObject.GetPtr(this), &position, &@inOrDefVal, &@outOrDefVal, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointPosition, 1530502735ul);

    /// <summary>
    /// <para>Sets the position for the vertex <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console.</para>
    /// </summary>
    public unsafe void SetPointPosition(int idx, Vector3 position)
    {
        NativeCalls.godot_icall_2_362(MethodBind3, GodotObject.GetPtr(this), idx, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPosition, 711720468ul);

    /// <summary>
    /// <para>Returns the position of the vertex <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console, and returns <c>(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetPointPosition(int idx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind4, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointTilt, 1602489585ul);

    /// <summary>
    /// <para>Sets the tilt angle in radians for the point <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console.</para>
    /// <para>The tilt controls the rotation along the look-at axis an object traveling the path would have. In the case of a curve controlling a <see cref="Godot.PathFollow3D"/>, this tilt is an offset over the natural tilt the <see cref="Godot.PathFollow3D"/> calculates.</para>
    /// </summary>
    public void SetPointTilt(int idx, float tilt)
    {
        NativeCalls.godot_icall_2_69(MethodBind5, GodotObject.GetPtr(this), idx, tilt);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointTilt, 2339986948ul);

    /// <summary>
    /// <para>Returns the tilt angle in radians for the point <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console, and returns <c>0</c>.</para>
    /// </summary>
    public float GetPointTilt(int idx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind6, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointIn, 1530502735ul);

    /// <summary>
    /// <para>Sets the position of the control point leading to the vertex <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console. The position is relative to the vertex.</para>
    /// </summary>
    public unsafe void SetPointIn(int idx, Vector3 position)
    {
        NativeCalls.godot_icall_2_362(MethodBind7, GodotObject.GetPtr(this), idx, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointIn, 711720468ul);

    /// <summary>
    /// <para>Returns the position of the control point leading to the vertex <paramref name="idx"/>. The returned position is relative to the vertex <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console, and returns <c>(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetPointIn(int idx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind8, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointOut, 1530502735ul);

    /// <summary>
    /// <para>Sets the position of the control point leading out of the vertex <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console. The position is relative to the vertex.</para>
    /// </summary>
    public unsafe void SetPointOut(int idx, Vector3 position)
    {
        NativeCalls.godot_icall_2_362(MethodBind9, GodotObject.GetPtr(this), idx, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointOut, 711720468ul);

    /// <summary>
    /// <para>Returns the position of the control point leading out of the vertex <paramref name="idx"/>. The returned position is relative to the vertex <paramref name="idx"/>. If the index is out of bounds, the function sends an error to the console, and returns <c>(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetPointOut(int idx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind10, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePoint, 1286410249ul);

    /// <summary>
    /// <para>Deletes the point <paramref name="idx"/> from the curve. Sends an error to the console if <paramref name="idx"/> is out of bounds.</para>
    /// </summary>
    public void RemovePoint(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearPoints, 3218959716ul);

    /// <summary>
    /// <para>Removes all points from the curve.</para>
    /// </summary>
    public void ClearPoints()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Sample, 3285246857ul);

    /// <summary>
    /// <para>Returns the position between the vertex <paramref name="idx"/> and the vertex <c>idx + 1</c>, where <paramref name="t"/> controls if the point is the first vertex (<c>t = 0.0</c>), the last vertex (<c>t = 1.0</c>), or in between. Values of <paramref name="t"/> outside the range (<c>0.0 &gt;= t &lt;=1</c>) give strange, but predictable results.</para>
    /// <para>If <paramref name="idx"/> is out of bounds it is truncated to the first or last vertex, and <paramref name="t"/> is ignored. If the curve has no points, the function sends an error to the console, and returns <c>(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 Sample(int idx, float t)
    {
        return NativeCalls.godot_icall_2_364(MethodBind13, GodotObject.GetPtr(this), idx, t);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Samplef, 2553580215ul);

    /// <summary>
    /// <para>Returns the position at the vertex <paramref name="fofs"/>. It calls <see cref="Godot.Curve3D.Sample(int, float)"/> using the integer part of <paramref name="fofs"/> as <c>idx</c>, and its fractional part as <c>t</c>.</para>
    /// </summary>
    public Vector3 Samplef(float fofs)
    {
        return NativeCalls.godot_icall_1_365(MethodBind14, GodotObject.GetPtr(this), fofs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClosed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClosed(bool closed)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), closed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClosed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClosed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeInterval(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind17, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBakeInterval()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpVectorEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpVectorEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUpVectorEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUpVectorEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakedLength, 1740695150ul);

    /// <summary>
    /// <para>Returns the total length of the curve, based on the cached points. Given enough density (see <see cref="Godot.Curve3D.BakeInterval"/>), it should be approximate enough.</para>
    /// </summary>
    public float GetBakedLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SampleBaked, 1350085894ul);

    /// <summary>
    /// <para>Returns a point within the curve at position <paramref name="offset"/>, where <paramref name="offset"/> is measured as a distance in 3D units along the curve. To do that, it finds the two cached points where the <paramref name="offset"/> lies between, then interpolates the values. This interpolation is cubic if <paramref name="cubic"/> is set to <see langword="true"/>, or linear if set to <see langword="false"/>.</para>
    /// <para>Cubic interpolation tends to follow the curves better, but linear is faster (and often, precise enough).</para>
    /// </summary>
    public Vector3 SampleBaked(float offset = 0.0f, bool cubic = false)
    {
        return NativeCalls.godot_icall_2_366(MethodBind22, GodotObject.GetPtr(this), offset, cubic.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SampleBakedWithRotation, 1939359131ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Transform3D"/> with <c>origin</c> as point position, <c>basis.x</c> as sideway vector, <c>basis.y</c> as up vector, <c>basis.z</c> as forward vector. When the curve length is 0, there is no reasonable way to calculate the rotation, all vectors aligned with global space axes. See also <see cref="Godot.Curve3D.SampleBaked(float, bool)"/>.</para>
    /// </summary>
    public Transform3D SampleBakedWithRotation(float offset = 0.0f, bool cubic = false, bool applyTilt = false)
    {
        return NativeCalls.godot_icall_3_367(MethodBind23, GodotObject.GetPtr(this), offset, cubic.ToGodotBool(), applyTilt.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SampleBakedUpVector, 1362627031ul);

    /// <summary>
    /// <para>Returns an up vector within the curve at position <paramref name="offset"/>, where <paramref name="offset"/> is measured as a distance in 3D units along the curve. To do that, it finds the two cached up vectors where the <paramref name="offset"/> lies between, then interpolates the values. If <paramref name="applyTilt"/> is <see langword="true"/>, an interpolated tilt is applied to the interpolated up vector.</para>
    /// <para>If the curve has no up vectors, the function sends an error to the console, and returns <c>(0, 1, 0)</c>.</para>
    /// </summary>
    public Vector3 SampleBakedUpVector(float offset, bool applyTilt = false)
    {
        return NativeCalls.godot_icall_2_366(MethodBind24, GodotObject.GetPtr(this), offset, applyTilt.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakedPoints, 497664490ul);

    /// <summary>
    /// <para>Returns the cache of points as a <see cref="Godot.Vector3"/>[].</para>
    /// </summary>
    public Vector3[] GetBakedPoints()
    {
        return NativeCalls.godot_icall_0_228(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakedTilts, 675695659ul);

    /// <summary>
    /// <para>Returns the cache of tilts as a <see cref="float"/>[].</para>
    /// </summary>
    public float[] GetBakedTilts()
    {
        return NativeCalls.godot_icall_0_368(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakedUpVectors, 497664490ul);

    /// <summary>
    /// <para>Returns the cache of up vectors as a <see cref="Godot.Vector3"/>[].</para>
    /// <para>If <see cref="Godot.Curve3D.UpVectorEnabled"/> is <see langword="false"/>, the cache will be empty.</para>
    /// </summary>
    public Vector3[] GetBakedUpVectors()
    {
        return NativeCalls.godot_icall_0_228(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPoint, 192990374ul);

    /// <summary>
    /// <para>Returns the closest point on baked segments (in curve's local space) to <paramref name="toPoint"/>.</para>
    /// <para><paramref name="toPoint"/> must be in this curve's local space.</para>
    /// </summary>
    public unsafe Vector3 GetClosestPoint(Vector3 toPoint)
    {
        return NativeCalls.godot_icall_1_29(MethodBind28, GodotObject.GetPtr(this), &toPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestOffset, 1109078154ul);

    /// <summary>
    /// <para>Returns the closest offset to <paramref name="toPoint"/>. This offset is meant to be used in <see cref="Godot.Curve3D.SampleBaked(float, bool)"/> or <see cref="Godot.Curve3D.SampleBakedUpVector(float, bool)"/>.</para>
    /// <para><paramref name="toPoint"/> must be in this curve's local space.</para>
    /// </summary>
    public unsafe float GetClosestOffset(Vector3 toPoint)
    {
        return NativeCalls.godot_icall_1_288(MethodBind29, GodotObject.GetPtr(this), &toPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Tessellate, 1519759391ul);

    /// <summary>
    /// <para>Returns a list of points along the curve, with a curvature controlled point density. That is, the curvier parts will have more points than the straighter parts.</para>
    /// <para>This approximation makes straight segments between each point, then subdivides those segments until the resulting shape is similar enough.</para>
    /// <para><paramref name="maxStages"/> controls how many subdivisions a curve segment may face before it is considered approximate enough. Each subdivision splits the segment in half, so the default 5 stages may mean up to 32 subdivisions per curve segment. Increase with care!</para>
    /// <para><paramref name="toleranceDegrees"/> controls how many degrees the midpoint of a segment may deviate from the real curve, before the segment has to be subdivided.</para>
    /// </summary>
    public Vector3[] Tessellate(int maxStages = 5, float toleranceDegrees = (float)(4))
    {
        return NativeCalls.godot_icall_2_369(MethodBind30, GodotObject.GetPtr(this), maxStages, toleranceDegrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TessellateEvenLength, 133237049ul);

    /// <summary>
    /// <para>Returns a list of points along the curve, with almost uniform density. <paramref name="maxStages"/> controls how many subdivisions a curve segment may face before it is considered approximate enough. Each subdivision splits the segment in half, so the default 5 stages may mean up to 32 subdivisions per curve segment. Increase with care!</para>
    /// <para><paramref name="toleranceLength"/> controls the maximal distance between two neighboring points, before the segment has to be subdivided.</para>
    /// </summary>
    public Vector3[] TessellateEvenLength(int maxStages = 5, float toleranceLength = 0.2f)
    {
        return NativeCalls.godot_icall_2_369(MethodBind31, GodotObject.GetPtr(this), maxStages, toleranceLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind33, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
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
        /// Cached name for the 'closed' property.
        /// </summary>
        public static readonly StringName Closed = "closed";
        /// <summary>
        /// Cached name for the 'bake_interval' property.
        /// </summary>
        public static readonly StringName BakeInterval = "bake_interval";
        /// <summary>
        /// Cached name for the '_data' property.
        /// </summary>
        public static readonly StringName _Data = "_data";
        /// <summary>
        /// Cached name for the 'point_count' property.
        /// </summary>
        public static readonly StringName PointCount = "point_count";
        /// <summary>
        /// Cached name for the 'up_vector_enabled' property.
        /// </summary>
        public static readonly StringName UpVectorEnabled = "up_vector_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_point_count' method.
        /// </summary>
        public static readonly StringName GetPointCount = "get_point_count";
        /// <summary>
        /// Cached name for the 'set_point_count' method.
        /// </summary>
        public static readonly StringName SetPointCount = "set_point_count";
        /// <summary>
        /// Cached name for the 'add_point' method.
        /// </summary>
        public static readonly StringName AddPoint = "add_point";
        /// <summary>
        /// Cached name for the 'set_point_position' method.
        /// </summary>
        public static readonly StringName SetPointPosition = "set_point_position";
        /// <summary>
        /// Cached name for the 'get_point_position' method.
        /// </summary>
        public static readonly StringName GetPointPosition = "get_point_position";
        /// <summary>
        /// Cached name for the 'set_point_tilt' method.
        /// </summary>
        public static readonly StringName SetPointTilt = "set_point_tilt";
        /// <summary>
        /// Cached name for the 'get_point_tilt' method.
        /// </summary>
        public static readonly StringName GetPointTilt = "get_point_tilt";
        /// <summary>
        /// Cached name for the 'set_point_in' method.
        /// </summary>
        public static readonly StringName SetPointIn = "set_point_in";
        /// <summary>
        /// Cached name for the 'get_point_in' method.
        /// </summary>
        public static readonly StringName GetPointIn = "get_point_in";
        /// <summary>
        /// Cached name for the 'set_point_out' method.
        /// </summary>
        public static readonly StringName SetPointOut = "set_point_out";
        /// <summary>
        /// Cached name for the 'get_point_out' method.
        /// </summary>
        public static readonly StringName GetPointOut = "get_point_out";
        /// <summary>
        /// Cached name for the 'remove_point' method.
        /// </summary>
        public static readonly StringName RemovePoint = "remove_point";
        /// <summary>
        /// Cached name for the 'clear_points' method.
        /// </summary>
        public static readonly StringName ClearPoints = "clear_points";
        /// <summary>
        /// Cached name for the 'sample' method.
        /// </summary>
        public static readonly StringName Sample = "sample";
        /// <summary>
        /// Cached name for the 'samplef' method.
        /// </summary>
        public static readonly StringName Samplef = "samplef";
        /// <summary>
        /// Cached name for the 'set_closed' method.
        /// </summary>
        public static readonly StringName SetClosed = "set_closed";
        /// <summary>
        /// Cached name for the 'is_closed' method.
        /// </summary>
        public static readonly StringName IsClosed = "is_closed";
        /// <summary>
        /// Cached name for the 'set_bake_interval' method.
        /// </summary>
        public static readonly StringName SetBakeInterval = "set_bake_interval";
        /// <summary>
        /// Cached name for the 'get_bake_interval' method.
        /// </summary>
        public static readonly StringName GetBakeInterval = "get_bake_interval";
        /// <summary>
        /// Cached name for the 'set_up_vector_enabled' method.
        /// </summary>
        public static readonly StringName SetUpVectorEnabled = "set_up_vector_enabled";
        /// <summary>
        /// Cached name for the 'is_up_vector_enabled' method.
        /// </summary>
        public static readonly StringName IsUpVectorEnabled = "is_up_vector_enabled";
        /// <summary>
        /// Cached name for the 'get_baked_length' method.
        /// </summary>
        public static readonly StringName GetBakedLength = "get_baked_length";
        /// <summary>
        /// Cached name for the 'sample_baked' method.
        /// </summary>
        public static readonly StringName SampleBaked = "sample_baked";
        /// <summary>
        /// Cached name for the 'sample_baked_with_rotation' method.
        /// </summary>
        public static readonly StringName SampleBakedWithRotation = "sample_baked_with_rotation";
        /// <summary>
        /// Cached name for the 'sample_baked_up_vector' method.
        /// </summary>
        public static readonly StringName SampleBakedUpVector = "sample_baked_up_vector";
        /// <summary>
        /// Cached name for the 'get_baked_points' method.
        /// </summary>
        public static readonly StringName GetBakedPoints = "get_baked_points";
        /// <summary>
        /// Cached name for the 'get_baked_tilts' method.
        /// </summary>
        public static readonly StringName GetBakedTilts = "get_baked_tilts";
        /// <summary>
        /// Cached name for the 'get_baked_up_vectors' method.
        /// </summary>
        public static readonly StringName GetBakedUpVectors = "get_baked_up_vectors";
        /// <summary>
        /// Cached name for the 'get_closest_point' method.
        /// </summary>
        public static readonly StringName GetClosestPoint = "get_closest_point";
        /// <summary>
        /// Cached name for the 'get_closest_offset' method.
        /// </summary>
        public static readonly StringName GetClosestOffset = "get_closest_offset";
        /// <summary>
        /// Cached name for the 'tessellate' method.
        /// </summary>
        public static readonly StringName Tessellate = "tessellate";
        /// <summary>
        /// Cached name for the 'tessellate_even_length' method.
        /// </summary>
        public static readonly StringName TessellateEvenLength = "tessellate_even_length";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}

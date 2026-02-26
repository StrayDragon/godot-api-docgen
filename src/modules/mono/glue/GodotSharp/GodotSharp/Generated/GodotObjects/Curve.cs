namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource describes a mathematical curve by defining a set of points and tangents at each point. By default, it ranges between <c>0</c> and <c>1</c> on the X and Y axes, but these ranges can be changed.</para>
/// <para>Please note that many resources and nodes assume they are given <i>unit curves</i>. A unit curve is a curve whose domain (the X axis) is between <c>0</c> and <c>1</c>. Some examples of unit curve usage are <see cref="Godot.CpuParticles2D.AngleCurve"/> and <see cref="Godot.Line2D.WidthCurve"/>.</para>
/// </summary>
public partial class Curve : Resource
{
    public enum TangentMode : long
    {
        /// <summary>
        /// <para>The tangent on this side of the point is user-defined.</para>
        /// </summary>
        Free = 0,
        /// <summary>
        /// <para>The curve calculates the tangent on this side of the point as the slope halfway towards the adjacent point.</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>The total number of available tangent modes.</para>
        /// </summary>
        ModeCount = 2
    }

    /// <summary>
    /// <para>The minimum domain (x-coordinate) that points can have.</para>
    /// </summary>
    public float MinDomain
    {
        get
        {
            return GetMinDomain();
        }
        set
        {
            SetMinDomain(value);
        }
    }

    /// <summary>
    /// <para>The maximum domain (x-coordinate) that points can have.</para>
    /// </summary>
    public float MaxDomain
    {
        get
        {
            return GetMaxDomain();
        }
        set
        {
            SetMaxDomain(value);
        }
    }

    /// <summary>
    /// <para>The minimum value (y-coordinate) that points can have. Tangents can cause lower values between points.</para>
    /// </summary>
    public float MinValue
    {
        get
        {
            return GetMinValue();
        }
        set
        {
            SetMinValue(value);
        }
    }

    /// <summary>
    /// <para>The maximum value (y-coordinate) that points can have. Tangents can cause higher values between points.</para>
    /// </summary>
    public float MaxValue
    {
        get
        {
            return GetMaxValue();
        }
        set
        {
            SetMaxValue(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array _Limits
    {
        get
        {
            return _GetLimits();
        }
        set
        {
            _SetLimits(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The number of points to include in the baked (i.e. cached) curve data.</para>
    /// </summary>
    public int BakeResolution
    {
        get
        {
            return GetBakeResolution();
        }
        set
        {
            SetBakeResolution(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array _Data
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

    private static readonly System.Type CachedType = typeof(Curve);

    private static readonly StringName NativeName = "Curve";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Curve() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Curve(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Curve(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPoint, 434072736ul);

    /// <summary>
    /// <para>Adds a point to the curve. For each side, if the <c>*_mode</c> is <see cref="Godot.Curve.TangentMode.Linear"/>, the <c>*_tangent</c> angle (in degrees) uses the slope of the curve halfway to the adjacent point. Allows custom assignments to the <c>*_tangent</c> angle if <c>*_mode</c> is set to <see cref="Godot.Curve.TangentMode.Free"/>.</para>
    /// </summary>
    public unsafe int AddPoint(Vector2 position, float leftTangent = (float)(0), float rightTangent = (float)(0), Curve.TangentMode leftMode = (Curve.TangentMode)(0), Curve.TangentMode rightMode = (Curve.TangentMode)(0))
    {
        return NativeCalls.godot_icall_5_352(MethodBind2, GodotObject.GetPtr(this), &position, leftTangent, rightTangent, (int)leftMode, (int)rightMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePoint, 1286410249ul);

    /// <summary>
    /// <para>Removes the point at <paramref name="index"/> from the curve.</para>
    /// </summary>
    public void RemovePoint(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearPoints, 3218959716ul);

    /// <summary>
    /// <para>Removes all points from the curve.</para>
    /// </summary>
    public void ClearPoints()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the curve coordinates for the point at <paramref name="index"/>.</para>
    /// </summary>
    public Vector2 GetPointPosition(int index)
    {
        return NativeCalls.godot_icall_1_148(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointValue, 1602489585ul);

    /// <summary>
    /// <para>Assigns the vertical position <paramref name="y"/> to the point at <paramref name="index"/>.</para>
    /// </summary>
    public void SetPointValue(int index, float y)
    {
        NativeCalls.godot_icall_2_69(MethodBind6, GodotObject.GetPtr(this), index, y);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointOffset, 3780573764ul);

    /// <summary>
    /// <para>Sets the offset from <c>0.5</c>.</para>
    /// </summary>
    public int SetPointOffset(int index, float offset)
    {
        return NativeCalls.godot_icall_2_353(MethodBind7, GodotObject.GetPtr(this), index, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Sample, 3919130443ul);

    /// <summary>
    /// <para>Returns the Y value for the point that would exist at the X position <paramref name="offset"/> along the curve.</para>
    /// </summary>
    public float Sample(float offset)
    {
        return NativeCalls.godot_icall_1_354(MethodBind8, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SampleBaked, 3919130443ul);

    /// <summary>
    /// <para>Returns the Y value for the point that would exist at the X position <paramref name="offset"/> along the curve using the baked cache. Bakes the curve's points if not already baked.</para>
    /// </summary>
    public float SampleBaked(float offset)
    {
        return NativeCalls.godot_icall_1_354(MethodBind9, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointLeftTangent, 2339986948ul);

    /// <summary>
    /// <para>Returns the left tangent angle (in degrees) for the point at <paramref name="index"/>.</para>
    /// </summary>
    public float GetPointLeftTangent(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind10, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointRightTangent, 2339986948ul);

    /// <summary>
    /// <para>Returns the right tangent angle (in degrees) for the point at <paramref name="index"/>.</para>
    /// </summary>
    public float GetPointRightTangent(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind11, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointLeftMode, 426950354ul);

    /// <summary>
    /// <para>Returns the left <see cref="Godot.Curve.TangentMode"/> for the point at <paramref name="index"/>.</para>
    /// </summary>
    public Curve.TangentMode GetPointLeftMode(int index)
    {
        return (Curve.TangentMode)NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointRightMode, 426950354ul);

    /// <summary>
    /// <para>Returns the right <see cref="Godot.Curve.TangentMode"/> for the point at <paramref name="index"/>.</para>
    /// </summary>
    public Curve.TangentMode GetPointRightMode(int index)
    {
        return (Curve.TangentMode)NativeCalls.godot_icall_1_60(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointLeftTangent, 1602489585ul);

    /// <summary>
    /// <para>Sets the left tangent angle for the point at <paramref name="index"/> to <paramref name="tangent"/>.</para>
    /// </summary>
    public void SetPointLeftTangent(int index, float tangent)
    {
        NativeCalls.godot_icall_2_69(MethodBind14, GodotObject.GetPtr(this), index, tangent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointRightTangent, 1602489585ul);

    /// <summary>
    /// <para>Sets the right tangent angle for the point at <paramref name="index"/> to <paramref name="tangent"/>.</para>
    /// </summary>
    public void SetPointRightTangent(int index, float tangent)
    {
        NativeCalls.godot_icall_2_69(MethodBind15, GodotObject.GetPtr(this), index, tangent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointLeftMode, 1217242874ul);

    /// <summary>
    /// <para>Sets the left <see cref="Godot.Curve.TangentMode"/> for the point at <paramref name="index"/> to <paramref name="mode"/>.</para>
    /// </summary>
    public void SetPointLeftMode(int index, Curve.TangentMode mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind16, GodotObject.GetPtr(this), index, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointRightMode, 1217242874ul);

    /// <summary>
    /// <para>Sets the right <see cref="Godot.Curve.TangentMode"/> for the point at <paramref name="index"/> to <paramref name="mode"/>.</para>
    /// </summary>
    public void SetPointRightMode(int index, Curve.TangentMode mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind17, GodotObject.GetPtr(this), index, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinValue()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinValue(float min)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), min);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxValue()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxValue(float max)
    {
        NativeCalls.godot_icall_1_67(MethodBind21, GodotObject.GetPtr(this), max);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetValueRange, 1740695150ul);

    /// <summary>
    /// <para>Returns the difference between <see cref="Godot.Curve.MinValue"/> and <see cref="Godot.Curve.MaxValue"/>.</para>
    /// </summary>
    public float GetValueRange()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinDomain, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinDomain()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinDomain, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinDomain(float min)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), min);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxDomain, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxDomain()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxDomain, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxDomain(float max)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), max);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDomainRange, 1740695150ul);

    /// <summary>
    /// <para>Returns the difference between <see cref="Godot.Curve.MinDomain"/> and <see cref="Godot.Curve.MaxDomain"/>.</para>
    /// </summary>
    public float GetDomainRange()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetLimits, 3995934104ul);

    internal Godot.Collections.Array _GetLimits()
    {
        return NativeCalls.godot_icall_0_120(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetLimits, 381264803ul);

    internal void _SetLimits(Godot.Collections.Array data)
    {
        NativeCalls.godot_icall_1_138(MethodBind29, GodotObject.GetPtr(this), (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CleanDupes, 3218959716ul);

    /// <summary>
    /// <para>Removes duplicate points, i.e. points that are less than 0.00001 units (engine epsilon value) away from their neighbor on the curve.</para>
    /// </summary>
    public void CleanDupes()
    {
        NativeCalls.godot_icall_0_3(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Bake, 3218959716ul);

    /// <summary>
    /// <para>Recomputes the baked cache of points for the curve.</para>
    /// </summary>
    public void Bake()
    {
        NativeCalls.godot_icall_0_3(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeResolution, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBakeResolution()
    {
        return NativeCalls.godot_icall_0_39(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeResolution, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeResolution(int resolution)
    {
        NativeCalls.godot_icall_1_38(MethodBind33, GodotObject.GetPtr(this), resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3995934104ul);

    internal Godot.Collections.Array _GetData()
    {
        return NativeCalls.godot_icall_0_120(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 381264803ul);

    internal void _SetData(Godot.Collections.Array data)
    {
        NativeCalls.godot_icall_1_138(MethodBind35, GodotObject.GetPtr(this), (godot_array)(data ?? new()).NativeValue);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.Curve.MaxValue"/> or <see cref="Godot.Curve.MinValue"/> is changed.</para>
    /// </summary>
    public event Action RangeChanged
    {
        add => Connect(SignalName.RangeChanged, Callable.From(value));
        remove => Disconnect(SignalName.RangeChanged, Callable.From(value));
    }

    protected void EmitSignalRangeChanged()
    {
        EmitSignal(SignalName.RangeChanged);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.Curve.MaxDomain"/> or <see cref="Godot.Curve.MinDomain"/> is changed.</para>
    /// </summary>
    public event Action DomainChanged
    {
        add => Connect(SignalName.DomainChanged, Callable.From(value));
        remove => Disconnect(SignalName.DomainChanged, Callable.From(value));
    }

    protected void EmitSignalDomainChanged()
    {
        EmitSignal(SignalName.DomainChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_range_changed = "RangeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_domain_changed = "DomainChanged";

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
        if (signal == SignalName.RangeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_range_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DomainChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_domain_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'min_domain' property.
        /// </summary>
        public static readonly StringName MinDomain = "min_domain";
        /// <summary>
        /// Cached name for the 'max_domain' property.
        /// </summary>
        public static readonly StringName MaxDomain = "max_domain";
        /// <summary>
        /// Cached name for the 'min_value' property.
        /// </summary>
        public static readonly StringName MinValue = "min_value";
        /// <summary>
        /// Cached name for the 'max_value' property.
        /// </summary>
        public static readonly StringName MaxValue = "max_value";
        /// <summary>
        /// Cached name for the '_limits' property.
        /// </summary>
        public static readonly StringName _Limits = "_limits";
        /// <summary>
        /// Cached name for the 'bake_resolution' property.
        /// </summary>
        public static readonly StringName BakeResolution = "bake_resolution";
        /// <summary>
        /// Cached name for the '_data' property.
        /// </summary>
        public static readonly StringName _Data = "_data";
        /// <summary>
        /// Cached name for the 'point_count' property.
        /// </summary>
        public static readonly StringName PointCount = "point_count";
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
        /// Cached name for the 'remove_point' method.
        /// </summary>
        public static readonly StringName RemovePoint = "remove_point";
        /// <summary>
        /// Cached name for the 'clear_points' method.
        /// </summary>
        public static readonly StringName ClearPoints = "clear_points";
        /// <summary>
        /// Cached name for the 'get_point_position' method.
        /// </summary>
        public static readonly StringName GetPointPosition = "get_point_position";
        /// <summary>
        /// Cached name for the 'set_point_value' method.
        /// </summary>
        public static readonly StringName SetPointValue = "set_point_value";
        /// <summary>
        /// Cached name for the 'set_point_offset' method.
        /// </summary>
        public static readonly StringName SetPointOffset = "set_point_offset";
        /// <summary>
        /// Cached name for the 'sample' method.
        /// </summary>
        public static readonly StringName Sample = "sample";
        /// <summary>
        /// Cached name for the 'sample_baked' method.
        /// </summary>
        public static readonly StringName SampleBaked = "sample_baked";
        /// <summary>
        /// Cached name for the 'get_point_left_tangent' method.
        /// </summary>
        public static readonly StringName GetPointLeftTangent = "get_point_left_tangent";
        /// <summary>
        /// Cached name for the 'get_point_right_tangent' method.
        /// </summary>
        public static readonly StringName GetPointRightTangent = "get_point_right_tangent";
        /// <summary>
        /// Cached name for the 'get_point_left_mode' method.
        /// </summary>
        public static readonly StringName GetPointLeftMode = "get_point_left_mode";
        /// <summary>
        /// Cached name for the 'get_point_right_mode' method.
        /// </summary>
        public static readonly StringName GetPointRightMode = "get_point_right_mode";
        /// <summary>
        /// Cached name for the 'set_point_left_tangent' method.
        /// </summary>
        public static readonly StringName SetPointLeftTangent = "set_point_left_tangent";
        /// <summary>
        /// Cached name for the 'set_point_right_tangent' method.
        /// </summary>
        public static readonly StringName SetPointRightTangent = "set_point_right_tangent";
        /// <summary>
        /// Cached name for the 'set_point_left_mode' method.
        /// </summary>
        public static readonly StringName SetPointLeftMode = "set_point_left_mode";
        /// <summary>
        /// Cached name for the 'set_point_right_mode' method.
        /// </summary>
        public static readonly StringName SetPointRightMode = "set_point_right_mode";
        /// <summary>
        /// Cached name for the 'get_min_value' method.
        /// </summary>
        public static readonly StringName GetMinValue = "get_min_value";
        /// <summary>
        /// Cached name for the 'set_min_value' method.
        /// </summary>
        public static readonly StringName SetMinValue = "set_min_value";
        /// <summary>
        /// Cached name for the 'get_max_value' method.
        /// </summary>
        public static readonly StringName GetMaxValue = "get_max_value";
        /// <summary>
        /// Cached name for the 'set_max_value' method.
        /// </summary>
        public static readonly StringName SetMaxValue = "set_max_value";
        /// <summary>
        /// Cached name for the 'get_value_range' method.
        /// </summary>
        public static readonly StringName GetValueRange = "get_value_range";
        /// <summary>
        /// Cached name for the 'get_min_domain' method.
        /// </summary>
        public static readonly StringName GetMinDomain = "get_min_domain";
        /// <summary>
        /// Cached name for the 'set_min_domain' method.
        /// </summary>
        public static readonly StringName SetMinDomain = "set_min_domain";
        /// <summary>
        /// Cached name for the 'get_max_domain' method.
        /// </summary>
        public static readonly StringName GetMaxDomain = "get_max_domain";
        /// <summary>
        /// Cached name for the 'set_max_domain' method.
        /// </summary>
        public static readonly StringName SetMaxDomain = "set_max_domain";
        /// <summary>
        /// Cached name for the 'get_domain_range' method.
        /// </summary>
        public static readonly StringName GetDomainRange = "get_domain_range";
        /// <summary>
        /// Cached name for the '_get_limits' method.
        /// </summary>
        public static readonly StringName _GetLimits = "_get_limits";
        /// <summary>
        /// Cached name for the '_set_limits' method.
        /// </summary>
        public static readonly StringName _SetLimits = "_set_limits";
        /// <summary>
        /// Cached name for the 'clean_dupes' method.
        /// </summary>
        public static readonly StringName CleanDupes = "clean_dupes";
        /// <summary>
        /// Cached name for the 'bake' method.
        /// </summary>
        public static readonly StringName Bake = "bake";
        /// <summary>
        /// Cached name for the 'get_bake_resolution' method.
        /// </summary>
        public static readonly StringName GetBakeResolution = "get_bake_resolution";
        /// <summary>
        /// Cached name for the 'set_bake_resolution' method.
        /// </summary>
        public static readonly StringName SetBakeResolution = "set_bake_resolution";
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
        /// <summary>
        /// Cached name for the 'range_changed' signal.
        /// </summary>
        public static readonly StringName RangeChanged = "range_changed";
        /// <summary>
        /// Cached name for the 'domain_changed' signal.
        /// </summary>
        public static readonly StringName DomainChanged = "domain_changed";
    }
}

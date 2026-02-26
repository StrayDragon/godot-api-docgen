namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.RDPipelineDepthStencilState"/> controls the way depth and stencil comparisons are performed when sampling those values using <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDPipelineDepthStencilState : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, enables depth testing which allows objects to be automatically occluded by other objects based on their depth. This also allows objects to be partially occluded by other objects. If <see langword="false"/>, objects will appear in the order they were drawn (like in Godot's 2D renderer).</para>
    /// </summary>
    public bool EnableDepthTest
    {
        get
        {
            return GetEnableDepthTest();
        }
        set
        {
            SetEnableDepthTest(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, writes to the depth buffer whenever the depth test returns <see langword="true"/>. Only works when enable_depth_test is also <see langword="true"/>.</para>
    /// </summary>
    public bool EnableDepthWrite
    {
        get
        {
            return GetEnableDepthWrite();
        }
        set
        {
            SetEnableDepthWrite(value);
        }
    }

    /// <summary>
    /// <para>The method used for comparing the previous and current depth values.</para>
    /// </summary>
    public RenderingDevice.CompareOperator DepthCompareOperator
    {
        get
        {
            return GetDepthCompareOperator();
        }
        set
        {
            SetDepthCompareOperator(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, each depth value will be tested to see if it is between <see cref="Godot.RDPipelineDepthStencilState.DepthRangeMin"/> and <see cref="Godot.RDPipelineDepthStencilState.DepthRangeMax"/>. If it is outside of these values, it is discarded.</para>
    /// </summary>
    public bool EnableDepthRange
    {
        get
        {
            return GetEnableDepthRange();
        }
        set
        {
            SetEnableDepthRange(value);
        }
    }

    /// <summary>
    /// <para>The minimum depth that returns <see langword="true"/> for <see cref="Godot.RDPipelineDepthStencilState.EnableDepthRange"/>.</para>
    /// </summary>
    public float DepthRangeMin
    {
        get
        {
            return GetDepthRangeMin();
        }
        set
        {
            SetDepthRangeMin(value);
        }
    }

    /// <summary>
    /// <para>The maximum depth that returns <see langword="true"/> for <see cref="Godot.RDPipelineDepthStencilState.EnableDepthRange"/>.</para>
    /// </summary>
    public float DepthRangeMax
    {
        get
        {
            return GetDepthRangeMax();
        }
        set
        {
            SetDepthRangeMax(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables stencil testing. There are separate stencil buffers for front-facing triangles and back-facing triangles. See properties that begin with "front_op" and properties with "back_op" for each.</para>
    /// </summary>
    public bool EnableStencil
    {
        get
        {
            return GetEnableStencil();
        }
        set
        {
            SetEnableStencil(value);
        }
    }

    /// <summary>
    /// <para>The operation to perform on the stencil buffer for front pixels that fail the stencil test.</para>
    /// </summary>
    public RenderingDevice.StencilOperation FrontOpFail
    {
        get
        {
            return GetFrontOpFail();
        }
        set
        {
            SetFrontOpFail(value);
        }
    }

    /// <summary>
    /// <para>The operation to perform on the stencil buffer for front pixels that pass the stencil test.</para>
    /// </summary>
    public RenderingDevice.StencilOperation FrontOpPass
    {
        get
        {
            return GetFrontOpPass();
        }
        set
        {
            SetFrontOpPass(value);
        }
    }

    /// <summary>
    /// <para>The operation to perform on the stencil buffer for front pixels that pass the stencil test but fail the depth test.</para>
    /// </summary>
    public RenderingDevice.StencilOperation FrontOpDepthFail
    {
        get
        {
            return GetFrontOpDepthFail();
        }
        set
        {
            SetFrontOpDepthFail(value);
        }
    }

    /// <summary>
    /// <para>The method used for comparing the previous front stencil value and <see cref="Godot.RDPipelineDepthStencilState.FrontOpReference"/>.</para>
    /// </summary>
    public RenderingDevice.CompareOperator FrontOpCompare
    {
        get
        {
            return GetFrontOpCompare();
        }
        set
        {
            SetFrontOpCompare(value);
        }
    }

    /// <summary>
    /// <para>Selects which bits from the front stencil value will be compared.</para>
    /// </summary>
    public uint FrontOpCompareMask
    {
        get
        {
            return GetFrontOpCompareMask();
        }
        set
        {
            SetFrontOpCompareMask(value);
        }
    }

    /// <summary>
    /// <para>Selects which bits from the front stencil value will be changed.</para>
    /// </summary>
    public uint FrontOpWriteMask
    {
        get
        {
            return GetFrontOpWriteMask();
        }
        set
        {
            SetFrontOpWriteMask(value);
        }
    }

    /// <summary>
    /// <para>The value the previous front stencil value will be compared to.</para>
    /// </summary>
    public uint FrontOpReference
    {
        get
        {
            return GetFrontOpReference();
        }
        set
        {
            SetFrontOpReference(value);
        }
    }

    /// <summary>
    /// <para>The operation to perform on the stencil buffer for back pixels that fail the stencil test.</para>
    /// </summary>
    public RenderingDevice.StencilOperation BackOpFail
    {
        get
        {
            return GetBackOpFail();
        }
        set
        {
            SetBackOpFail(value);
        }
    }

    /// <summary>
    /// <para>The operation to perform on the stencil buffer for back pixels that pass the stencil test.</para>
    /// </summary>
    public RenderingDevice.StencilOperation BackOpPass
    {
        get
        {
            return GetBackOpPass();
        }
        set
        {
            SetBackOpPass(value);
        }
    }

    /// <summary>
    /// <para>The operation to perform on the stencil buffer for back pixels that pass the stencil test but fail the depth test.</para>
    /// </summary>
    public RenderingDevice.StencilOperation BackOpDepthFail
    {
        get
        {
            return GetBackOpDepthFail();
        }
        set
        {
            SetBackOpDepthFail(value);
        }
    }

    /// <summary>
    /// <para>The method used for comparing the previous back stencil value and <see cref="Godot.RDPipelineDepthStencilState.BackOpReference"/>.</para>
    /// </summary>
    public RenderingDevice.CompareOperator BackOpCompare
    {
        get
        {
            return GetBackOpCompare();
        }
        set
        {
            SetBackOpCompare(value);
        }
    }

    /// <summary>
    /// <para>Selects which bits from the back stencil value will be compared.</para>
    /// </summary>
    public uint BackOpCompareMask
    {
        get
        {
            return GetBackOpCompareMask();
        }
        set
        {
            SetBackOpCompareMask(value);
        }
    }

    /// <summary>
    /// <para>Selects which bits from the back stencil value will be changed.</para>
    /// </summary>
    public uint BackOpWriteMask
    {
        get
        {
            return GetBackOpWriteMask();
        }
        set
        {
            SetBackOpWriteMask(value);
        }
    }

    /// <summary>
    /// <para>The value the previous back stencil value will be compared to.</para>
    /// </summary>
    public uint BackOpReference
    {
        get
        {
            return GetBackOpReference();
        }
        set
        {
            SetBackOpReference(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDPipelineDepthStencilState);

    private static readonly StringName NativeName = "RDPipelineDepthStencilState";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDPipelineDepthStencilState() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineDepthStencilState(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineDepthStencilState(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDepthTest, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDepthTest(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableDepthTest, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableDepthTest()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDepthWrite, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDepthWrite(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableDepthWrite, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableDepthWrite()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthCompareOperator, 2573711505ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthCompareOperator(RenderingDevice.CompareOperator pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthCompareOperator, 269730778ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.CompareOperator GetDepthCompareOperator()
    {
        return (RenderingDevice.CompareOperator)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDepthRange, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDepthRange(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableDepthRange, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableDepthRange()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthRangeMin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthRangeMin(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthRangeMin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthRangeMin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthRangeMax, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthRangeMax(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthRangeMax, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthRangeMax()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableStencil, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableStencil(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableStencil, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableStencil()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpFail, 2092799566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpFail(RenderingDevice.StencilOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpFail, 1714732389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.StencilOperation GetFrontOpFail()
    {
        return (RenderingDevice.StencilOperation)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpPass, 2092799566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpPass(RenderingDevice.StencilOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpPass, 1714732389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.StencilOperation GetFrontOpPass()
    {
        return (RenderingDevice.StencilOperation)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpDepthFail, 2092799566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpDepthFail(RenderingDevice.StencilOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpDepthFail, 1714732389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.StencilOperation GetFrontOpDepthFail()
    {
        return (RenderingDevice.StencilOperation)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpCompare, 2573711505ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpCompare(RenderingDevice.CompareOperator pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpCompare, 269730778ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.CompareOperator GetFrontOpCompare()
    {
        return (RenderingDevice.CompareOperator)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpCompareMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpCompareMask(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind22, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpCompareMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetFrontOpCompareMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpWriteMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpWriteMask(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind24, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpWriteMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetFrontOpWriteMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontOpReference, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontOpReference(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind26, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontOpReference, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetFrontOpReference()
    {
        return NativeCalls.godot_icall_0_209(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpFail, 2092799566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpFail(RenderingDevice.StencilOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpFail, 1714732389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.StencilOperation GetBackOpFail()
    {
        return (RenderingDevice.StencilOperation)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpPass, 2092799566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpPass(RenderingDevice.StencilOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpPass, 1714732389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.StencilOperation GetBackOpPass()
    {
        return (RenderingDevice.StencilOperation)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpDepthFail, 2092799566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpDepthFail(RenderingDevice.StencilOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind32, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpDepthFail, 1714732389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.StencilOperation GetBackOpDepthFail()
    {
        return (RenderingDevice.StencilOperation)NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpCompare, 2573711505ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpCompare(RenderingDevice.CompareOperator pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind34, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpCompare, 269730778ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.CompareOperator GetBackOpCompare()
    {
        return (RenderingDevice.CompareOperator)NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpCompareMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpCompareMask(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind36, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpCompareMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetBackOpCompareMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpWriteMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpWriteMask(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind38, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpWriteMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetBackOpWriteMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackOpReference, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackOpReference(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind40, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackOpReference, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetBackOpReference()
    {
        return NativeCalls.godot_icall_0_209(MethodBind41, GodotObject.GetPtr(this));
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'enable_depth_test' property.
        /// </summary>
        public static readonly StringName EnableDepthTest = "enable_depth_test";
        /// <summary>
        /// Cached name for the 'enable_depth_write' property.
        /// </summary>
        public static readonly StringName EnableDepthWrite = "enable_depth_write";
        /// <summary>
        /// Cached name for the 'depth_compare_operator' property.
        /// </summary>
        public static readonly StringName DepthCompareOperator = "depth_compare_operator";
        /// <summary>
        /// Cached name for the 'enable_depth_range' property.
        /// </summary>
        public static readonly StringName EnableDepthRange = "enable_depth_range";
        /// <summary>
        /// Cached name for the 'depth_range_min' property.
        /// </summary>
        public static readonly StringName DepthRangeMin = "depth_range_min";
        /// <summary>
        /// Cached name for the 'depth_range_max' property.
        /// </summary>
        public static readonly StringName DepthRangeMax = "depth_range_max";
        /// <summary>
        /// Cached name for the 'enable_stencil' property.
        /// </summary>
        public static readonly StringName EnableStencil = "enable_stencil";
        /// <summary>
        /// Cached name for the 'front_op_fail' property.
        /// </summary>
        public static readonly StringName FrontOpFail = "front_op_fail";
        /// <summary>
        /// Cached name for the 'front_op_pass' property.
        /// </summary>
        public static readonly StringName FrontOpPass = "front_op_pass";
        /// <summary>
        /// Cached name for the 'front_op_depth_fail' property.
        /// </summary>
        public static readonly StringName FrontOpDepthFail = "front_op_depth_fail";
        /// <summary>
        /// Cached name for the 'front_op_compare' property.
        /// </summary>
        public static readonly StringName FrontOpCompare = "front_op_compare";
        /// <summary>
        /// Cached name for the 'front_op_compare_mask' property.
        /// </summary>
        public static readonly StringName FrontOpCompareMask = "front_op_compare_mask";
        /// <summary>
        /// Cached name for the 'front_op_write_mask' property.
        /// </summary>
        public static readonly StringName FrontOpWriteMask = "front_op_write_mask";
        /// <summary>
        /// Cached name for the 'front_op_reference' property.
        /// </summary>
        public static readonly StringName FrontOpReference = "front_op_reference";
        /// <summary>
        /// Cached name for the 'back_op_fail' property.
        /// </summary>
        public static readonly StringName BackOpFail = "back_op_fail";
        /// <summary>
        /// Cached name for the 'back_op_pass' property.
        /// </summary>
        public static readonly StringName BackOpPass = "back_op_pass";
        /// <summary>
        /// Cached name for the 'back_op_depth_fail' property.
        /// </summary>
        public static readonly StringName BackOpDepthFail = "back_op_depth_fail";
        /// <summary>
        /// Cached name for the 'back_op_compare' property.
        /// </summary>
        public static readonly StringName BackOpCompare = "back_op_compare";
        /// <summary>
        /// Cached name for the 'back_op_compare_mask' property.
        /// </summary>
        public static readonly StringName BackOpCompareMask = "back_op_compare_mask";
        /// <summary>
        /// Cached name for the 'back_op_write_mask' property.
        /// </summary>
        public static readonly StringName BackOpWriteMask = "back_op_write_mask";
        /// <summary>
        /// Cached name for the 'back_op_reference' property.
        /// </summary>
        public static readonly StringName BackOpReference = "back_op_reference";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_enable_depth_test' method.
        /// </summary>
        public static readonly StringName SetEnableDepthTest = "set_enable_depth_test";
        /// <summary>
        /// Cached name for the 'get_enable_depth_test' method.
        /// </summary>
        public static readonly StringName GetEnableDepthTest = "get_enable_depth_test";
        /// <summary>
        /// Cached name for the 'set_enable_depth_write' method.
        /// </summary>
        public static readonly StringName SetEnableDepthWrite = "set_enable_depth_write";
        /// <summary>
        /// Cached name for the 'get_enable_depth_write' method.
        /// </summary>
        public static readonly StringName GetEnableDepthWrite = "get_enable_depth_write";
        /// <summary>
        /// Cached name for the 'set_depth_compare_operator' method.
        /// </summary>
        public static readonly StringName SetDepthCompareOperator = "set_depth_compare_operator";
        /// <summary>
        /// Cached name for the 'get_depth_compare_operator' method.
        /// </summary>
        public static readonly StringName GetDepthCompareOperator = "get_depth_compare_operator";
        /// <summary>
        /// Cached name for the 'set_enable_depth_range' method.
        /// </summary>
        public static readonly StringName SetEnableDepthRange = "set_enable_depth_range";
        /// <summary>
        /// Cached name for the 'get_enable_depth_range' method.
        /// </summary>
        public static readonly StringName GetEnableDepthRange = "get_enable_depth_range";
        /// <summary>
        /// Cached name for the 'set_depth_range_min' method.
        /// </summary>
        public static readonly StringName SetDepthRangeMin = "set_depth_range_min";
        /// <summary>
        /// Cached name for the 'get_depth_range_min' method.
        /// </summary>
        public static readonly StringName GetDepthRangeMin = "get_depth_range_min";
        /// <summary>
        /// Cached name for the 'set_depth_range_max' method.
        /// </summary>
        public static readonly StringName SetDepthRangeMax = "set_depth_range_max";
        /// <summary>
        /// Cached name for the 'get_depth_range_max' method.
        /// </summary>
        public static readonly StringName GetDepthRangeMax = "get_depth_range_max";
        /// <summary>
        /// Cached name for the 'set_enable_stencil' method.
        /// </summary>
        public static readonly StringName SetEnableStencil = "set_enable_stencil";
        /// <summary>
        /// Cached name for the 'get_enable_stencil' method.
        /// </summary>
        public static readonly StringName GetEnableStencil = "get_enable_stencil";
        /// <summary>
        /// Cached name for the 'set_front_op_fail' method.
        /// </summary>
        public static readonly StringName SetFrontOpFail = "set_front_op_fail";
        /// <summary>
        /// Cached name for the 'get_front_op_fail' method.
        /// </summary>
        public static readonly StringName GetFrontOpFail = "get_front_op_fail";
        /// <summary>
        /// Cached name for the 'set_front_op_pass' method.
        /// </summary>
        public static readonly StringName SetFrontOpPass = "set_front_op_pass";
        /// <summary>
        /// Cached name for the 'get_front_op_pass' method.
        /// </summary>
        public static readonly StringName GetFrontOpPass = "get_front_op_pass";
        /// <summary>
        /// Cached name for the 'set_front_op_depth_fail' method.
        /// </summary>
        public static readonly StringName SetFrontOpDepthFail = "set_front_op_depth_fail";
        /// <summary>
        /// Cached name for the 'get_front_op_depth_fail' method.
        /// </summary>
        public static readonly StringName GetFrontOpDepthFail = "get_front_op_depth_fail";
        /// <summary>
        /// Cached name for the 'set_front_op_compare' method.
        /// </summary>
        public static readonly StringName SetFrontOpCompare = "set_front_op_compare";
        /// <summary>
        /// Cached name for the 'get_front_op_compare' method.
        /// </summary>
        public static readonly StringName GetFrontOpCompare = "get_front_op_compare";
        /// <summary>
        /// Cached name for the 'set_front_op_compare_mask' method.
        /// </summary>
        public static readonly StringName SetFrontOpCompareMask = "set_front_op_compare_mask";
        /// <summary>
        /// Cached name for the 'get_front_op_compare_mask' method.
        /// </summary>
        public static readonly StringName GetFrontOpCompareMask = "get_front_op_compare_mask";
        /// <summary>
        /// Cached name for the 'set_front_op_write_mask' method.
        /// </summary>
        public static readonly StringName SetFrontOpWriteMask = "set_front_op_write_mask";
        /// <summary>
        /// Cached name for the 'get_front_op_write_mask' method.
        /// </summary>
        public static readonly StringName GetFrontOpWriteMask = "get_front_op_write_mask";
        /// <summary>
        /// Cached name for the 'set_front_op_reference' method.
        /// </summary>
        public static readonly StringName SetFrontOpReference = "set_front_op_reference";
        /// <summary>
        /// Cached name for the 'get_front_op_reference' method.
        /// </summary>
        public static readonly StringName GetFrontOpReference = "get_front_op_reference";
        /// <summary>
        /// Cached name for the 'set_back_op_fail' method.
        /// </summary>
        public static readonly StringName SetBackOpFail = "set_back_op_fail";
        /// <summary>
        /// Cached name for the 'get_back_op_fail' method.
        /// </summary>
        public static readonly StringName GetBackOpFail = "get_back_op_fail";
        /// <summary>
        /// Cached name for the 'set_back_op_pass' method.
        /// </summary>
        public static readonly StringName SetBackOpPass = "set_back_op_pass";
        /// <summary>
        /// Cached name for the 'get_back_op_pass' method.
        /// </summary>
        public static readonly StringName GetBackOpPass = "get_back_op_pass";
        /// <summary>
        /// Cached name for the 'set_back_op_depth_fail' method.
        /// </summary>
        public static readonly StringName SetBackOpDepthFail = "set_back_op_depth_fail";
        /// <summary>
        /// Cached name for the 'get_back_op_depth_fail' method.
        /// </summary>
        public static readonly StringName GetBackOpDepthFail = "get_back_op_depth_fail";
        /// <summary>
        /// Cached name for the 'set_back_op_compare' method.
        /// </summary>
        public static readonly StringName SetBackOpCompare = "set_back_op_compare";
        /// <summary>
        /// Cached name for the 'get_back_op_compare' method.
        /// </summary>
        public static readonly StringName GetBackOpCompare = "get_back_op_compare";
        /// <summary>
        /// Cached name for the 'set_back_op_compare_mask' method.
        /// </summary>
        public static readonly StringName SetBackOpCompareMask = "set_back_op_compare_mask";
        /// <summary>
        /// Cached name for the 'get_back_op_compare_mask' method.
        /// </summary>
        public static readonly StringName GetBackOpCompareMask = "get_back_op_compare_mask";
        /// <summary>
        /// Cached name for the 'set_back_op_write_mask' method.
        /// </summary>
        public static readonly StringName SetBackOpWriteMask = "set_back_op_write_mask";
        /// <summary>
        /// Cached name for the 'get_back_op_write_mask' method.
        /// </summary>
        public static readonly StringName GetBackOpWriteMask = "get_back_op_write_mask";
        /// <summary>
        /// Cached name for the 'set_back_op_reference' method.
        /// </summary>
        public static readonly StringName SetBackOpReference = "set_back_op_reference";
        /// <summary>
        /// Cached name for the 'get_back_op_reference' method.
        /// </summary>
        public static readonly StringName GetBackOpReference = "get_back_op_reference";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Translated to <c>uniform float</c> in the shader language.</para>
/// </summary>
public partial class VisualShaderNodeFloatParameter : VisualShaderNodeParameter
{
    public enum HintEnum : long
    {
        /// <summary>
        /// <para>No hint used.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>A range hint for scalar value, which limits possible input values between <see cref="Godot.VisualShaderNodeFloatParameter.Min"/> and <see cref="Godot.VisualShaderNodeFloatParameter.Max"/>. Translated to <c>hint_range(min, max)</c> in shader code.</para>
        /// </summary>
        Range = 1,
        /// <summary>
        /// <para>A range hint for scalar value with step, which limits possible input values between <see cref="Godot.VisualShaderNodeFloatParameter.Min"/> and <see cref="Godot.VisualShaderNodeFloatParameter.Max"/>, with a step (increment) of <see cref="Godot.VisualShaderNodeFloatParameter.Step"/>). Translated to <c>hint_range(min, max, step)</c> in shader code.</para>
        /// </summary>
        RangeStep = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeFloatParameter.HintEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>A hint applied to the uniform, which controls the values it can take when set through the Inspector.</para>
    /// </summary>
    public VisualShaderNodeFloatParameter.HintEnum Hint
    {
        get
        {
            return GetHint();
        }
        set
        {
            SetHint(value);
        }
    }

    /// <summary>
    /// <para>Maximum value for range hints. Used if <see cref="Godot.VisualShaderNodeFloatParameter.Hint"/> is set to <see cref="Godot.VisualShaderNodeFloatParameter.HintEnum.Range"/> or <see cref="Godot.VisualShaderNodeFloatParameter.HintEnum.RangeStep"/>.</para>
    /// </summary>
    public float Min
    {
        get
        {
            return GetMin();
        }
        set
        {
            SetMin(value);
        }
    }

    /// <summary>
    /// <para>Minimum value for range hints. Used if <see cref="Godot.VisualShaderNodeFloatParameter.Hint"/> is set to <see cref="Godot.VisualShaderNodeFloatParameter.HintEnum.Range"/> or <see cref="Godot.VisualShaderNodeFloatParameter.HintEnum.RangeStep"/>.</para>
    /// </summary>
    public float Max
    {
        get
        {
            return GetMax();
        }
        set
        {
            SetMax(value);
        }
    }

    /// <summary>
    /// <para>Step (increment) value for the range hint with step. Used if <see cref="Godot.VisualShaderNodeFloatParameter.Hint"/> is set to <see cref="Godot.VisualShaderNodeFloatParameter.HintEnum.RangeStep"/>.</para>
    /// </summary>
    public float Step
    {
        get
        {
            return GetStep();
        }
        set
        {
            SetStep(value);
        }
    }

    /// <summary>
    /// <para>Enables usage of the <see cref="Godot.VisualShaderNodeFloatParameter.DefaultValue"/>.</para>
    /// </summary>
    public bool DefaultValueEnabled
    {
        get
        {
            return IsDefaultValueEnabled();
        }
        set
        {
            SetDefaultValueEnabled(value);
        }
    }

    /// <summary>
    /// <para>A default value to be assigned within the shader.</para>
    /// </summary>
    public float DefaultValue
    {
        get
        {
            return GetDefaultValue();
        }
        set
        {
            SetDefaultValue(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeFloatParameter);

    private static readonly StringName NativeName = "VisualShaderNodeFloatParameter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeFloatParameter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFloatParameter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFloatParameter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHint, 3712586466ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHint(VisualShaderNodeFloatParameter.HintEnum hint)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)hint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHint, 3042240429ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeFloatParameter.HintEnum GetHint()
    {
        return (VisualShaderNodeFloatParameter.HintEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMin(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMax, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMax(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMax, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMax()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStep(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultValueEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultValueEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDefaultValueEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDefaultValueEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultValue(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDefaultValue()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeParameter.PropertyName
    {
        /// <summary>
        /// Cached name for the 'hint' property.
        /// </summary>
        public static readonly StringName Hint = "hint";
        /// <summary>
        /// Cached name for the 'min' property.
        /// </summary>
        public static readonly StringName Min = "min";
        /// <summary>
        /// Cached name for the 'max' property.
        /// </summary>
        public static readonly StringName Max = "max";
        /// <summary>
        /// Cached name for the 'step' property.
        /// </summary>
        public static readonly StringName Step = "step";
        /// <summary>
        /// Cached name for the 'default_value_enabled' property.
        /// </summary>
        public static readonly StringName DefaultValueEnabled = "default_value_enabled";
        /// <summary>
        /// Cached name for the 'default_value' property.
        /// </summary>
        public static readonly StringName DefaultValue = "default_value";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeParameter.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_hint' method.
        /// </summary>
        public static readonly StringName SetHint = "set_hint";
        /// <summary>
        /// Cached name for the 'get_hint' method.
        /// </summary>
        public static readonly StringName GetHint = "get_hint";
        /// <summary>
        /// Cached name for the 'set_min' method.
        /// </summary>
        public static readonly StringName SetMin = "set_min";
        /// <summary>
        /// Cached name for the 'get_min' method.
        /// </summary>
        public static readonly StringName GetMin = "get_min";
        /// <summary>
        /// Cached name for the 'set_max' method.
        /// </summary>
        public static readonly StringName SetMax = "set_max";
        /// <summary>
        /// Cached name for the 'get_max' method.
        /// </summary>
        public static readonly StringName GetMax = "get_max";
        /// <summary>
        /// Cached name for the 'set_step' method.
        /// </summary>
        public static readonly StringName SetStep = "set_step";
        /// <summary>
        /// Cached name for the 'get_step' method.
        /// </summary>
        public static readonly StringName GetStep = "get_step";
        /// <summary>
        /// Cached name for the 'set_default_value_enabled' method.
        /// </summary>
        public static readonly StringName SetDefaultValueEnabled = "set_default_value_enabled";
        /// <summary>
        /// Cached name for the 'is_default_value_enabled' method.
        /// </summary>
        public static readonly StringName IsDefaultValueEnabled = "is_default_value_enabled";
        /// <summary>
        /// Cached name for the 'set_default_value' method.
        /// </summary>
        public static readonly StringName SetDefaultValue = "set_default_value";
        /// <summary>
        /// Cached name for the 'get_default_value' method.
        /// </summary>
        public static readonly StringName GetDefaultValue = "get_default_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeParameter.SignalName
    {
    }
}

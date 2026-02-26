namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.VisualShaderNodeParameter"/> of type <see cref="int"/>. Offers additional customization for range of accepted values.</para>
/// </summary>
public partial class VisualShaderNodeIntParameter : VisualShaderNodeParameter
{
    public enum HintEnum : long
    {
        /// <summary>
        /// <para>The parameter will not constrain its value.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The parameter's value must be within the specified <see cref="Godot.VisualShaderNodeIntParameter.Min"/>/<see cref="Godot.VisualShaderNodeIntParameter.Max"/> range.</para>
        /// </summary>
        Range = 1,
        /// <summary>
        /// <para>The parameter's value must be within the specified range, with the given <see cref="Godot.VisualShaderNodeIntParameter.Step"/> between values.</para>
        /// </summary>
        RangeStep = 2,
        /// <summary>
        /// <para>The parameter uses an enum to associate preset values to names in the editor.</para>
        /// </summary>
        Enum = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeIntParameter.HintEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>Range hint of this node. Use it to customize valid parameter range.</para>
    /// </summary>
    public VisualShaderNodeIntParameter.HintEnum Hint
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
    /// <para>The minimum value this parameter can take. <see cref="Godot.VisualShaderNodeIntParameter.Hint"/> must be either <see cref="Godot.VisualShaderNodeIntParameter.HintEnum.Range"/> or <see cref="Godot.VisualShaderNodeIntParameter.HintEnum.RangeStep"/> for this to take effect.</para>
    /// </summary>
    public int Min
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
    /// <para>The maximum value this parameter can take. <see cref="Godot.VisualShaderNodeIntParameter.Hint"/> must be either <see cref="Godot.VisualShaderNodeIntParameter.HintEnum.Range"/> or <see cref="Godot.VisualShaderNodeIntParameter.HintEnum.RangeStep"/> for this to take effect.</para>
    /// </summary>
    public int Max
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
    /// <para>The step between parameter's values. Forces the parameter to be a multiple of the given value. <see cref="Godot.VisualShaderNodeIntParameter.Hint"/> must be <see cref="Godot.VisualShaderNodeIntParameter.HintEnum.RangeStep"/> for this to take effect.</para>
    /// </summary>
    public int Step
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
    /// <para>The names used for the enum select in the editor. <see cref="Godot.VisualShaderNodeIntParameter.Hint"/> must be <see cref="Godot.VisualShaderNodeIntParameter.HintEnum.Enum"/> for this to take effect.</para>
    /// </summary>
    public string[] EnumNames
    {
        get
        {
            return GetEnumNames();
        }
        set
        {
            SetEnumNames(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the node will have a custom default value.</para>
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
    /// <para>Default value of this parameter, which will be used if not set externally. <see cref="Godot.VisualShaderNodeIntParameter.DefaultValueEnabled"/> must be enabled; defaults to <c>0</c> otherwise.</para>
    /// </summary>
    public int DefaultValue
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeIntParameter);

    private static readonly StringName NativeName = "VisualShaderNodeIntParameter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeIntParameter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeIntParameter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeIntParameter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHint, 2540512075ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHint(VisualShaderNodeIntParameter.HintEnum hint)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)hint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHint, 4250814924ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeIntParameter.HintEnum GetHint()
    {
        return (VisualShaderNodeIntParameter.HintEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMin(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMax, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMax(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMax, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMax()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStep, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStep(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStep, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStep()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnumNames, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnumNames(string[] names)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), names);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnumNames(ReadOnlySpan<string> names)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), names);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnumNames, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetEnumNames()
    {
        return NativeCalls.godot_icall_0_108(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultValueEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultValueEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDefaultValueEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDefaultValueEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultValue, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultValue(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultValue, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDefaultValue()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
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
        /// Cached name for the 'enum_names' property.
        /// </summary>
        public static readonly StringName EnumNames = "enum_names";
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
        /// Cached name for the 'set_enum_names' method.
        /// </summary>
        public static readonly StringName SetEnumNames = "set_enum_names";
        /// <summary>
        /// Cached name for the 'get_enum_names' method.
        /// </summary>
        public static readonly StringName GetEnumNames = "get_enum_names";
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

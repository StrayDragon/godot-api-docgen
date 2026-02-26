namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Range is an abstract base class for controls that represent a number within a range, using a configured <see cref="Godot.Range.Step"/> and <see cref="Godot.Range.Page"/> size. See e.g. <see cref="Godot.ScrollBar"/> and <see cref="Godot.Slider"/> for examples of higher-level nodes using Range.</para>
/// </summary>
public partial class Range : Control
{
    /// <summary>
    /// <para>Minimum value. Range is clamped if <see cref="Godot.Range.Value"/> is less than <see cref="Godot.Range.MinValue"/>.</para>
    /// </summary>
    public double MinValue
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
    /// <para>Maximum value. Range is clamped if <see cref="Godot.Range.Value"/> is greater than <see cref="Godot.Range.MaxValue"/>.</para>
    /// </summary>
    public double MaxValue
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
    /// <para>If greater than <c>0.0</c>, <see cref="Godot.Range.Value"/> will always be rounded to a multiple of this property's value above <see cref="Godot.Range.MinValue"/>. For example, if <see cref="Godot.Range.MinValue"/> is <c>0.1</c> and step is <c>0.2</c>, then <see cref="Godot.Range.Value"/> is limited to <c>0.1</c>, <c>0.3</c>, <c>0.5</c>, and so on. If <see cref="Godot.Range.Rounded"/> is also <see langword="true"/>, <see cref="Godot.Range.Value"/> will first be rounded to a multiple of this property's value, then rounded to the nearest integer.</para>
    /// </summary>
    public double Step
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
    /// <para>Page size. Used mainly for <see cref="Godot.ScrollBar"/>. A <see cref="Godot.ScrollBar"/>'s grabber length is the <see cref="Godot.ScrollBar"/>'s size multiplied by <see cref="Godot.Range.Page"/> over the difference between <see cref="Godot.Range.MinValue"/> and <see cref="Godot.Range.MaxValue"/>.</para>
    /// </summary>
    public double Page
    {
        get
        {
            return GetPage();
        }
        set
        {
            SetPage(value);
        }
    }

    /// <summary>
    /// <para>Range's current value. Changing this property (even via code) will trigger <see cref="Godot.Range.ValueChanged"/> signal. Use <see cref="Godot.Range.SetValueNoSignal(double)"/> if you want to avoid it.</para>
    /// </summary>
    public double Value
    {
        get
        {
            return GetValue();
        }
        set
        {
            SetValue(value);
        }
    }

    /// <summary>
    /// <para>The value mapped between 0 and 1.</para>
    /// </summary>
    public double Ratio
    {
        get
        {
            return GetAsRatio();
        }
        set
        {
            SetAsRatio(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, and <see cref="Godot.Range.MinValue"/> is greater or equal to <c>0</c>, <see cref="Godot.Range.Value"/> will be represented exponentially rather than linearly.</para>
    /// </summary>
    public bool ExpEdit
    {
        get
        {
            return IsRatioExp();
        }
        set
        {
            SetExpRatio(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.Range.Value"/> will always be rounded to the nearest integer.</para>
    /// </summary>
    public bool Rounded
    {
        get
        {
            return IsUsingRoundedValues();
        }
        set
        {
            SetUseRoundedValues(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.Range.Value"/> may be greater than <see cref="Godot.Range.MaxValue"/>.</para>
    /// </summary>
    public bool AllowGreater
    {
        get
        {
            return IsGreaterAllowed();
        }
        set
        {
            SetAllowGreater(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.Range.Value"/> may be less than <see cref="Godot.Range.MinValue"/>.</para>
    /// </summary>
    public bool AllowLesser
    {
        get
        {
            return IsLesserAllowed();
        }
        set
        {
            SetAllowLesser(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Range);

    private static readonly StringName NativeName = "Range";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Range() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Range(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Range(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the <see cref="Godot.Range"/>'s value is changed (following the same conditions as <see cref="Godot.Range.ValueChanged"/>).</para>
    /// </summary>
    public virtual void _ValueChanged(double newValue)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetValue()
    {
        return NativeCalls.godot_icall_0_144(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetMin()
    {
        return NativeCalls.godot_icall_0_144(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMax, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetMax()
    {
        return NativeCalls.godot_icall_0_144(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetStep()
    {
        return NativeCalls.godot_icall_0_144(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPage, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetPage()
    {
        return NativeCalls.godot_icall_0_144(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAsRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetAsRatio()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetValue(double value)
    {
        NativeCalls.godot_icall_1_127(MethodBind6, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetValueNoSignal, 373806689ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Range"/>'s current value to the specified <paramref name="value"/>, without emitting the <see cref="Godot.Range.ValueChanged"/> signal.</para>
    /// </summary>
    public void SetValueNoSignal(double value)
    {
        NativeCalls.godot_icall_1_127(MethodBind7, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMin(double minimum)
    {
        NativeCalls.godot_icall_1_127(MethodBind8, GodotObject.GetPtr(this), minimum);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMax, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMax(double maximum)
    {
        NativeCalls.godot_icall_1_127(MethodBind9, GodotObject.GetPtr(this), maximum);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStep(double step)
    {
        NativeCalls.godot_icall_1_127(MethodBind10, GodotObject.GetPtr(this), step);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPage, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPage(double pagesize)
    {
        NativeCalls.godot_icall_1_127(MethodBind11, GodotObject.GetPtr(this), pagesize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsRatio(double value)
    {
        NativeCalls.godot_icall_1_127(MethodBind12, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseRoundedValues, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseRoundedValues(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingRoundedValues, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingRoundedValues()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpRatio, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpRatio(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRatioExp, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRatioExp()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowGreater, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowGreater(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGreaterAllowed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsGreaterAllowed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowLesser, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowLesser(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLesserAllowed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLesserAllowed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Share, 1078189570ul);

    /// <summary>
    /// <para>Binds two <see cref="Godot.Range"/>s together along with any ranges previously grouped with either of them. When any of range's member variables change, it will share the new value with all other ranges in its group.</para>
    /// </summary>
    public void Share(Node with)
    {
        NativeCalls.godot_icall_1_56(MethodBind21, GodotObject.GetPtr(this), GodotObject.GetPtr(with));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Unshare, 3218959716ul);

    /// <summary>
    /// <para>Stops the <see cref="Godot.Range"/> from sharing its member variables with any other.</para>
    /// </summary>
    public void Unshare()
    {
        NativeCalls.godot_icall_0_3(MethodBind22, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Range.ValueChanged"/> event of a <see cref="Godot.Range"/> class.
    /// </summary>
    public delegate void ValueChangedEventHandler(double value);

    private static void ValueChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ValueChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<double>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.Range.Value"/> changes. When used on a <see cref="Godot.Slider"/>, this is called continuously while dragging (potentially every frame). If you are performing an expensive operation in a function connected to <see cref="Godot.Range.ValueChanged"/>, consider using a <i>debouncing</i> <see cref="Godot.Timer"/> to call the function less often.</para>
    /// <para><b>Note:</b> Unlike signals such as <see cref="Godot.LineEdit.TextChanged"/>, <see cref="Godot.Range.ValueChanged"/> is also emitted when <c>value</c> is set directly via code.</para>
    /// </summary>
    public unsafe event ValueChangedEventHandler ValueChanged
    {
        add => Connect(SignalName.ValueChanged, Callable.CreateWithUnsafeTrampoline(value, &ValueChangedTrampoline));
        remove => Disconnect(SignalName.ValueChanged, Callable.CreateWithUnsafeTrampoline(value, &ValueChangedTrampoline));
    }

    protected void EmitSignalValueChanged(double value)
    {
        EmitSignal(SignalName.ValueChanged, value);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.Range.MinValue"/>, <see cref="Godot.Range.MaxValue"/>, <see cref="Godot.Range.Page"/>, or <see cref="Godot.Range.Step"/> change.</para>
    /// </summary>
    public event Action Changed
    {
        add => Connect(SignalName.Changed, Callable.From(value));
        remove => Disconnect(SignalName.Changed, Callable.From(value));
    }

    protected void EmitSignalChanged()
    {
        EmitSignal(SignalName.Changed);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__value_changed = "_ValueChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_value_changed = "ValueChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_changed = "Changed";

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
        if ((method == MethodProxyName__value_changed || method == MethodName._ValueChanged) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__value_changed.NativeValue))
        {
            _ValueChanged(VariantUtils.ConvertTo<double>(args[0]));
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
        if (method == MethodName._ValueChanged)
        {
            if (HasGodotClassMethod(MethodProxyName__value_changed.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.ValueChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_value_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Changed)
        {
            if (HasGodotClassSignal(SignalProxyName_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'min_value' property.
        /// </summary>
        public static readonly StringName MinValue = "min_value";
        /// <summary>
        /// Cached name for the 'max_value' property.
        /// </summary>
        public static readonly StringName MaxValue = "max_value";
        /// <summary>
        /// Cached name for the 'step' property.
        /// </summary>
        public static readonly StringName Step = "step";
        /// <summary>
        /// Cached name for the 'page' property.
        /// </summary>
        public static readonly StringName Page = "page";
        /// <summary>
        /// Cached name for the 'value' property.
        /// </summary>
        public static readonly StringName Value = "value";
        /// <summary>
        /// Cached name for the 'ratio' property.
        /// </summary>
        public static readonly StringName Ratio = "ratio";
        /// <summary>
        /// Cached name for the 'exp_edit' property.
        /// </summary>
        public static readonly StringName ExpEdit = "exp_edit";
        /// <summary>
        /// Cached name for the 'rounded' property.
        /// </summary>
        public static readonly StringName Rounded = "rounded";
        /// <summary>
        /// Cached name for the 'allow_greater' property.
        /// </summary>
        public static readonly StringName AllowGreater = "allow_greater";
        /// <summary>
        /// Cached name for the 'allow_lesser' property.
        /// </summary>
        public static readonly StringName AllowLesser = "allow_lesser";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the '_value_changed' method.
        /// </summary>
        public static readonly StringName _ValueChanged = "_value_changed";
        /// <summary>
        /// Cached name for the 'get_value' method.
        /// </summary>
        public static readonly StringName GetValue = "get_value";
        /// <summary>
        /// Cached name for the 'get_min' method.
        /// </summary>
        public static readonly StringName GetMin = "get_min";
        /// <summary>
        /// Cached name for the 'get_max' method.
        /// </summary>
        public static readonly StringName GetMax = "get_max";
        /// <summary>
        /// Cached name for the 'get_step' method.
        /// </summary>
        public static readonly StringName GetStep = "get_step";
        /// <summary>
        /// Cached name for the 'get_page' method.
        /// </summary>
        public static readonly StringName GetPage = "get_page";
        /// <summary>
        /// Cached name for the 'get_as_ratio' method.
        /// </summary>
        public static readonly StringName GetAsRatio = "get_as_ratio";
        /// <summary>
        /// Cached name for the 'set_value' method.
        /// </summary>
        public static readonly StringName SetValue = "set_value";
        /// <summary>
        /// Cached name for the 'set_value_no_signal' method.
        /// </summary>
        public static readonly StringName SetValueNoSignal = "set_value_no_signal";
        /// <summary>
        /// Cached name for the 'set_min' method.
        /// </summary>
        public static readonly StringName SetMin = "set_min";
        /// <summary>
        /// Cached name for the 'set_max' method.
        /// </summary>
        public static readonly StringName SetMax = "set_max";
        /// <summary>
        /// Cached name for the 'set_step' method.
        /// </summary>
        public static readonly StringName SetStep = "set_step";
        /// <summary>
        /// Cached name for the 'set_page' method.
        /// </summary>
        public static readonly StringName SetPage = "set_page";
        /// <summary>
        /// Cached name for the 'set_as_ratio' method.
        /// </summary>
        public static readonly StringName SetAsRatio = "set_as_ratio";
        /// <summary>
        /// Cached name for the 'set_use_rounded_values' method.
        /// </summary>
        public static readonly StringName SetUseRoundedValues = "set_use_rounded_values";
        /// <summary>
        /// Cached name for the 'is_using_rounded_values' method.
        /// </summary>
        public static readonly StringName IsUsingRoundedValues = "is_using_rounded_values";
        /// <summary>
        /// Cached name for the 'set_exp_ratio' method.
        /// </summary>
        public static readonly StringName SetExpRatio = "set_exp_ratio";
        /// <summary>
        /// Cached name for the 'is_ratio_exp' method.
        /// </summary>
        public static readonly StringName IsRatioExp = "is_ratio_exp";
        /// <summary>
        /// Cached name for the 'set_allow_greater' method.
        /// </summary>
        public static readonly StringName SetAllowGreater = "set_allow_greater";
        /// <summary>
        /// Cached name for the 'is_greater_allowed' method.
        /// </summary>
        public static readonly StringName IsGreaterAllowed = "is_greater_allowed";
        /// <summary>
        /// Cached name for the 'set_allow_lesser' method.
        /// </summary>
        public static readonly StringName SetAllowLesser = "set_allow_lesser";
        /// <summary>
        /// Cached name for the 'is_lesser_allowed' method.
        /// </summary>
        public static readonly StringName IsLesserAllowed = "is_lesser_allowed";
        /// <summary>
        /// Cached name for the 'share' method.
        /// </summary>
        public static readonly StringName Share = "share";
        /// <summary>
        /// Cached name for the 'unshare' method.
        /// </summary>
        public static readonly StringName Unshare = "unshare";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'value_changed' signal.
        /// </summary>
        public static readonly StringName ValueChanged = "value_changed";
        /// <summary>
        /// Cached name for the 'changed' signal.
        /// </summary>
        public static readonly StringName Changed = "changed";
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides access to metadata stored for every available engine class.</para>
/// <para><b>Note:</b> Script-defined classes with <c>class_name</c> are not part of <see cref="Godot.ClassDB"/>, so they will not return reflection data such as a method or property list. However, <see cref="Godot.GDExtension"/>-defined classes <i>are</i> part of <see cref="Godot.ClassDB"/>, so they will return reflection data.</para>
/// </summary>
[GodotClassName("ClassDB")]
public partial class ClassDBInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(ClassDBInstance);

    private static readonly StringName NativeName = "ClassDB";

    internal ClassDBInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ClassDBInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ClassDBInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClassList, 1139954409ul);

    /// <summary>
    /// <para>Returns the names of all engine classes available.</para>
    /// <para><b>Note:</b> Script-defined classes with <c>class_name</c> are not included in this list. Use <see cref="Godot.ProjectSettings.GetGlobalClassList()"/> to get a list of script-defined classes instead.</para>
    /// </summary>
    public string[] GetClassList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInheritersFromClass, 1761182771ul);

    /// <summary>
    /// <para>Returns the names of all engine classes that directly or indirectly inherit from <paramref name="class"/>.</para>
    /// </summary>
    public string[] GetInheritersFromClass(StringName @class)
    {
        return NativeCalls.godot_icall_1_289(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentClass, 1965194235ul);

    /// <summary>
    /// <para>Returns the parent class of <paramref name="class"/>.</para>
    /// </summary>
    public StringName GetParentClass(StringName @class)
    {
        return NativeCalls.godot_icall_1_164(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassExists, 2619796661ul);

    /// <summary>
    /// <para>Returns whether the specified <paramref name="class"/> is available or not.</para>
    /// </summary>
    public bool ClassExists(StringName @class)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsParentClass, 471820014ul);

    /// <summary>
    /// <para>Returns whether <paramref name="inherits"/> is an ancestor of <paramref name="class"/> or not.</para>
    /// </summary>
    public bool IsParentClass(StringName @class, StringName inherits)
    {
        return NativeCalls.godot_icall_2_160(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(inherits?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanInstantiate, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if objects can be instantiated from the specified <paramref name="class"/>, otherwise returns <see langword="false"/>.</para>
    /// </summary>
    public bool CanInstantiate(StringName @class)
    {
        return NativeCalls.godot_icall_1_105(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Instantiate, 2760726917ul);

    /// <summary>
    /// <para>Creates an instance of <paramref name="class"/>.</para>
    /// </summary>
    public Variant Instantiate(StringName @class)
    {
        return NativeCalls.godot_icall_1_143(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetApiType, 2475317043ul);

    /// <summary>
    /// <para>Returns the API type of the specified <paramref name="class"/>.</para>
    /// </summary>
    public ClassDB.ApiType ClassGetApiType(StringName @class)
    {
        return (ClassDB.ApiType)NativeCalls.godot_icall_1_193(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassHasSignal, 471820014ul);

    /// <summary>
    /// <para>Returns whether <paramref name="class"/> or its ancestry has a signal called <paramref name="signal"/> or not.</para>
    /// </summary>
    public bool ClassHasSignal(StringName @class, StringName signal)
    {
        return NativeCalls.godot_icall_2_160(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(signal?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetSignal, 3061114238ul);

    /// <summary>
    /// <para>Returns the <paramref name="signal"/> data of <paramref name="class"/> or its ancestry. The returned value is a <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>args</c>, <c>default_args</c>, <c>flags</c>, <c>id</c>, <c>name</c>, <c>return: (class_name, hint, hint_string, name, type, usage)</c>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ClassGetSignal(StringName @class, StringName signal)
    {
        return NativeCalls.godot_icall_2_290(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(signal?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetSignalList, 3504980660ul);

    /// <summary>
    /// <para>Returns an array with all the signals of <paramref name="class"/> or its ancestry if <paramref name="noInheritance"/> is <see langword="false"/>. Every element of the array is a <see cref="Godot.Collections.Dictionary"/> as described in <see cref="Godot.ClassDBInstance.ClassGetSignal(StringName, StringName)"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> ClassGetSignalList(StringName @class, bool noInheritance = false)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_2_291(MethodBind10, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), noInheritance.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetPropertyList, 3504980660ul);

    /// <summary>
    /// <para>Returns an array with all the properties of <paramref name="class"/> or its ancestry if <paramref name="noInheritance"/> is <see langword="false"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> ClassGetPropertyList(StringName @class, bool noInheritance = false)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_2_291(MethodBind11, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), noInheritance.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetPropertyGetter, 3770832642ul);

    /// <summary>
    /// <para>Returns the getter method name of <paramref name="property"/> of <paramref name="class"/>.</para>
    /// </summary>
    public StringName ClassGetPropertyGetter(StringName @class, StringName property)
    {
        return NativeCalls.godot_icall_2_292(MethodBind12, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetPropertySetter, 3770832642ul);

    /// <summary>
    /// <para>Returns the setter method name of <paramref name="property"/> of <paramref name="class"/>.</para>
    /// </summary>
    public StringName ClassGetPropertySetter(StringName @class, StringName property)
    {
        return NativeCalls.godot_icall_2_292(MethodBind13, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetProperty, 2498641674ul);

    /// <summary>
    /// <para>Returns the value of <paramref name="property"/> of <paramref name="object"/> or its ancestry.</para>
    /// </summary>
    public Variant ClassGetProperty(GodotObject @object, StringName property)
    {
        return NativeCalls.godot_icall_2_293(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassSetProperty, 1690314931ul);

    /// <summary>
    /// <para>Sets <paramref name="property"/> value of <paramref name="object"/> to <paramref name="value"/>.</para>
    /// </summary>
    public Error ClassSetProperty(GodotObject @object, StringName property, Variant value)
    {
        return (Error)NativeCalls.godot_icall_3_294(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetPropertyDefaultValue, 2718203076ul);

    /// <summary>
    /// <para>Returns the default value of <paramref name="property"/> of <paramref name="class"/> or its ancestor classes.</para>
    /// </summary>
    public Variant ClassGetPropertyDefaultValue(StringName @class, StringName property)
    {
        return NativeCalls.godot_icall_2_295(MethodBind16, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassHasMethod, 3860701026ul);

    /// <summary>
    /// <para>Returns whether <paramref name="class"/> (or its ancestry if <paramref name="noInheritance"/> is <see langword="false"/>) has a method called <paramref name="method"/> or not.</para>
    /// </summary>
    public bool ClassHasMethod(StringName @class, StringName method, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_3_296(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), noInheritance.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetMethodArgumentCount, 3885694822ul);

    /// <summary>
    /// <para>Returns the number of arguments of the method <paramref name="method"/> of <paramref name="class"/> or its ancestry if <paramref name="noInheritance"/> is <see langword="false"/>.</para>
    /// </summary>
    public int ClassGetMethodArgumentCount(StringName @class, StringName method, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_3_297(MethodBind18, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), noInheritance.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetMethodList, 3504980660ul);

    /// <summary>
    /// <para>Returns an array with all the methods of <paramref name="class"/> or its ancestry if <paramref name="noInheritance"/> is <see langword="false"/>. Every element of the array is a <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>args</c>, <c>default_args</c>, <c>flags</c>, <c>id</c>, <c>name</c>, <c>return: (class_name, hint, hint_string, name, type, usage)</c>.</para>
    /// <para><b>Note:</b> In exported release builds the debug info is not available, so the returned dictionaries will contain only method names.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> ClassGetMethodList(StringName @class, bool noInheritance = false)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_2_291(MethodBind19, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), noInheritance.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassCallStatic, 3344196419ul);

    /// <summary>
    /// <para>Calls a static method on a class.</para>
    /// </summary>
    public Variant ClassCallStatic(StringName @class, StringName method, params Variant[] @args)
    {
        return NativeCalls.godot_icall_3_298(MethodBind20, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.ClassCallStatic.NativeValue);
    }

    /// <summary>
    /// <para>Calls a static method on a class.</para>
    /// </summary>
    public Variant ClassCallStatic(StringName @class, StringName method, ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_3_298(MethodBind20, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.ClassCallStatic.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetIntegerConstantList, 3031669221ul);

    /// <summary>
    /// <para>Returns an array with the names all the integer constants of <paramref name="class"/> or its ancestry.</para>
    /// </summary>
    public string[] ClassGetIntegerConstantList(StringName @class, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_2_299(MethodBind21, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), noInheritance.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassHasIntegerConstant, 471820014ul);

    /// <summary>
    /// <para>Returns whether <paramref name="class"/> or its ancestry has an integer constant called <paramref name="name"/> or not.</para>
    /// </summary>
    public bool ClassHasIntegerConstant(StringName @class, StringName name)
    {
        return NativeCalls.godot_icall_2_160(MethodBind22, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetIntegerConstant, 2419549490ul);

    /// <summary>
    /// <para>Returns the value of the integer constant <paramref name="name"/> of <paramref name="class"/> or its ancestry. Always returns 0 when the constant could not be found.</para>
    /// </summary>
    public long ClassGetIntegerConstant(StringName @class, StringName name)
    {
        return NativeCalls.godot_icall_2_300(MethodBind23, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassHasEnum, 3860701026ul);

    /// <summary>
    /// <para>Returns whether <paramref name="class"/> or its ancestry has an enum called <paramref name="name"/> or not.</para>
    /// </summary>
    public bool ClassHasEnum(StringName @class, StringName name, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_3_296(MethodBind24, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), noInheritance.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetEnumList, 3031669221ul);

    /// <summary>
    /// <para>Returns an array with all the enums of <paramref name="class"/> or its ancestry.</para>
    /// </summary>
    public string[] ClassGetEnumList(StringName @class, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_2_299(MethodBind25, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), noInheritance.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetEnumConstants, 661528303ul);

    /// <summary>
    /// <para>Returns an array with all the keys in <paramref name="enum"/> of <paramref name="class"/> or its ancestry.</para>
    /// </summary>
    public string[] ClassGetEnumConstants(StringName @class, StringName @enum, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_3_301(MethodBind26, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(@enum?.NativeValue ?? default), noInheritance.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClassGetIntegerConstantEnum, 2457504236ul);

    /// <summary>
    /// <para>Returns which enum the integer constant <paramref name="name"/> of <paramref name="class"/> or its ancestry belongs to.</para>
    /// </summary>
    public StringName ClassGetIntegerConstantEnum(StringName @class, StringName name, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_3_302(MethodBind27, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), noInheritance.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClassEnumBitfield, 3860701026ul);

    /// <summary>
    /// <para>Returns whether <paramref name="class"/> (or its ancestor classes if <paramref name="noInheritance"/> is <see langword="false"/>) has an enum called <paramref name="enum"/> that is a bitfield.</para>
    /// </summary>
    public bool IsClassEnumBitfield(StringName @class, StringName @enum, bool noInheritance = false)
    {
        return NativeCalls.godot_icall_3_296(MethodBind28, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default), (godot_string_name)(@enum?.NativeValue ?? default), noInheritance.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClassEnabled, 2619796661ul);

    /// <summary>
    /// <para>Returns whether this <paramref name="class"/> is enabled or not.</para>
    /// </summary>
    public bool IsClassEnabled(StringName @class)
    {
        return NativeCalls.godot_icall_1_105(MethodBind29, GodotObject.GetPtr(this), (godot_string_name)(@class?.NativeValue ?? default)).ToBool();
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_class_list' method.
        /// </summary>
        public static readonly StringName GetClassList = "get_class_list";
        /// <summary>
        /// Cached name for the 'get_inheriters_from_class' method.
        /// </summary>
        public static readonly StringName GetInheritersFromClass = "get_inheriters_from_class";
        /// <summary>
        /// Cached name for the 'get_parent_class' method.
        /// </summary>
        public static readonly StringName GetParentClass = "get_parent_class";
        /// <summary>
        /// Cached name for the 'class_exists' method.
        /// </summary>
        public static readonly StringName ClassExists = "class_exists";
        /// <summary>
        /// Cached name for the 'is_parent_class' method.
        /// </summary>
        public static readonly StringName IsParentClass = "is_parent_class";
        /// <summary>
        /// Cached name for the 'can_instantiate' method.
        /// </summary>
        public static readonly StringName CanInstantiate = "can_instantiate";
        /// <summary>
        /// Cached name for the 'instantiate' method.
        /// </summary>
        public static readonly StringName Instantiate = "instantiate";
        /// <summary>
        /// Cached name for the 'class_get_api_type' method.
        /// </summary>
        public static readonly StringName ClassGetApiType = "class_get_api_type";
        /// <summary>
        /// Cached name for the 'class_has_signal' method.
        /// </summary>
        public static readonly StringName ClassHasSignal = "class_has_signal";
        /// <summary>
        /// Cached name for the 'class_get_signal' method.
        /// </summary>
        public static readonly StringName ClassGetSignal = "class_get_signal";
        /// <summary>
        /// Cached name for the 'class_get_signal_list' method.
        /// </summary>
        public static readonly StringName ClassGetSignalList = "class_get_signal_list";
        /// <summary>
        /// Cached name for the 'class_get_property_list' method.
        /// </summary>
        public static readonly StringName ClassGetPropertyList = "class_get_property_list";
        /// <summary>
        /// Cached name for the 'class_get_property_getter' method.
        /// </summary>
        public static readonly StringName ClassGetPropertyGetter = "class_get_property_getter";
        /// <summary>
        /// Cached name for the 'class_get_property_setter' method.
        /// </summary>
        public static readonly StringName ClassGetPropertySetter = "class_get_property_setter";
        /// <summary>
        /// Cached name for the 'class_get_property' method.
        /// </summary>
        public static readonly StringName ClassGetProperty = "class_get_property";
        /// <summary>
        /// Cached name for the 'class_set_property' method.
        /// </summary>
        public static readonly StringName ClassSetProperty = "class_set_property";
        /// <summary>
        /// Cached name for the 'class_get_property_default_value' method.
        /// </summary>
        public static readonly StringName ClassGetPropertyDefaultValue = "class_get_property_default_value";
        /// <summary>
        /// Cached name for the 'class_has_method' method.
        /// </summary>
        public static readonly StringName ClassHasMethod = "class_has_method";
        /// <summary>
        /// Cached name for the 'class_get_method_argument_count' method.
        /// </summary>
        public static readonly StringName ClassGetMethodArgumentCount = "class_get_method_argument_count";
        /// <summary>
        /// Cached name for the 'class_get_method_list' method.
        /// </summary>
        public static readonly StringName ClassGetMethodList = "class_get_method_list";
        /// <summary>
        /// Cached name for the 'class_call_static' method.
        /// </summary>
        public static readonly StringName ClassCallStatic = "class_call_static";
        /// <summary>
        /// Cached name for the 'class_get_integer_constant_list' method.
        /// </summary>
        public static readonly StringName ClassGetIntegerConstantList = "class_get_integer_constant_list";
        /// <summary>
        /// Cached name for the 'class_has_integer_constant' method.
        /// </summary>
        public static readonly StringName ClassHasIntegerConstant = "class_has_integer_constant";
        /// <summary>
        /// Cached name for the 'class_get_integer_constant' method.
        /// </summary>
        public static readonly StringName ClassGetIntegerConstant = "class_get_integer_constant";
        /// <summary>
        /// Cached name for the 'class_has_enum' method.
        /// </summary>
        public static readonly StringName ClassHasEnum = "class_has_enum";
        /// <summary>
        /// Cached name for the 'class_get_enum_list' method.
        /// </summary>
        public static readonly StringName ClassGetEnumList = "class_get_enum_list";
        /// <summary>
        /// Cached name for the 'class_get_enum_constants' method.
        /// </summary>
        public static readonly StringName ClassGetEnumConstants = "class_get_enum_constants";
        /// <summary>
        /// Cached name for the 'class_get_integer_constant_enum' method.
        /// </summary>
        public static readonly StringName ClassGetIntegerConstantEnum = "class_get_integer_constant_enum";
        /// <summary>
        /// Cached name for the 'is_class_enum_bitfield' method.
        /// </summary>
        public static readonly StringName IsClassEnumBitfield = "is_class_enum_bitfield";
        /// <summary>
        /// Cached name for the 'is_class_enabled' method.
        /// </summary>
        public static readonly StringName IsClassEnabled = "is_class_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}

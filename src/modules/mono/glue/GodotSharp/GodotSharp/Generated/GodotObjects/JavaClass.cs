namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a class from the Java Native Interface. It is returned from <see cref="Godot.JavaClassWrapper.Wrap(string)"/>.</para>
/// <para><b>Note:</b> This class only works on Android. On any other platform, this class does nothing.</para>
/// <para><b>Note:</b> This class is not to be confused with <see cref="Godot.JavaScriptObject"/>.</para>
/// </summary>
public partial class JavaClass : RefCounted
{
    private static readonly System.Type CachedType = typeof(JavaClass);

    private static readonly StringName NativeName = "JavaClass";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public JavaClass() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal JavaClass(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal JavaClass(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJavaClassName, 201670096ul);

    /// <summary>
    /// <para>Returns the Java class name.</para>
    /// </summary>
    public string GetJavaClassName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJavaMethodList, 3995934104ul);

    /// <summary>
    /// <para>Returns the object's Java methods and their signatures as an <see cref="Godot.Collections.Array"/> of dictionaries, in the same format as <see cref="Godot.GodotObject.GetMethodList()"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetJavaMethodList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJavaParentClass, 541536347ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.JavaClass"/> representing the Java parent class of this class.</para>
    /// </summary>
    public JavaClass GetJavaParentClass()
    {
        return (JavaClass)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasJavaMethod, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="method"/> name exists in the object's Java methods.</para>
    /// </summary>
    public bool HasJavaMethod(StringName method)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default)).ToBool();
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_java_class_name' method.
        /// </summary>
        public static readonly StringName GetJavaClassName = "get_java_class_name";
        /// <summary>
        /// Cached name for the 'get_java_method_list' method.
        /// </summary>
        public static readonly StringName GetJavaMethodList = "get_java_method_list";
        /// <summary>
        /// Cached name for the 'get_java_parent_class' method.
        /// </summary>
        public static readonly StringName GetJavaParentClass = "get_java_parent_class";
        /// <summary>
        /// Cached name for the 'has_java_method' method.
        /// </summary>
        public static readonly StringName HasJavaMethod = "has_java_method";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

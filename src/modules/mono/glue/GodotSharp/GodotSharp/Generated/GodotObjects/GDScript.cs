namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A script implemented in the GDScript programming language, saved with the <c>.gd</c> extension. The script extends the functionality of all objects that instantiate it.</para>
/// <para>Calling <see cref="Godot.GDScript.New(Variant[])"/> creates a new instance of the script. <see cref="Godot.GodotObject.SetScript(Variant)"/> extends an existing object, if that object's class matches one of the script's base classes.</para>
/// <para>If you are looking for GDScript's built-in functions, see <c>@GDScript</c> instead.</para>
/// </summary>
public partial class GDScript : Script
{
    private static readonly System.Type CachedType = typeof(GDScript);

    private static readonly StringName NativeName = "GDScript";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GDScript() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GDScript(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GDScript(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.New, 1545262638ul);

    /// <summary>
    /// <para>Returns a new instance of the script.</para>
    /// <para><code>
    /// var MyClass = load("myclass.gd")
    /// var instance = MyClass.new()
    /// print(instance.get_script() == MyClass) # Prints true
    /// </code></para>
    /// </summary>
    public Variant New(params Variant[] @args)
    {
        return NativeCalls.godot_icall_1_229(MethodBind0, GodotObject.GetPtr(this), @args, (godot_string_name)MethodName.New.NativeValue);
    }

    /// <summary>
    /// <para>Returns a new instance of the script.</para>
    /// <para><code>
    /// var MyClass = load("myclass.gd")
    /// var instance = MyClass.new()
    /// print(instance.get_script() == MyClass) # Prints true
    /// </code></para>
    /// </summary>
    public Variant New(ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_1_229(MethodBind0, GodotObject.GetPtr(this), @args, (godot_string_name)MethodName.New.NativeValue);
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
    public new class PropertyName : Script.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Script.MethodName
    {
        /// <summary>
        /// Cached name for the 'new' method.
        /// </summary>
        public static readonly StringName New = "new";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Script.SignalName
    {
    }
}

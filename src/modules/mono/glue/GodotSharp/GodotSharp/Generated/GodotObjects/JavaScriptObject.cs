namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>JavaScriptObject is used to interact with JavaScript objects retrieved or created via <see cref="Godot.JavaScriptBridge.GetInterface(string)"/>, <see cref="Godot.JavaScriptBridge.CreateObject(string, Variant[])"/>, or <see cref="Godot.JavaScriptBridge.CreateCallback(Callable)"/>.</para>
/// <para><code>
/// extends Node
/// 
/// var _my_js_callback = JavaScriptBridge.create_callback(myCallback) # This reference must be kept
/// var console = JavaScriptBridge.get_interface("console")
/// 
/// func _init():
/// 	var buf = JavaScriptBridge.create_object("ArrayBuffer", 10) # new ArrayBuffer(10)
/// 	print(buf) # Prints [JavaScriptObject:OBJECT_ID]
/// 	var uint8arr = JavaScriptBridge.create_object("Uint8Array", buf) # new Uint8Array(buf)
/// 	uint8arr[1] = 255
/// 	prints(uint8arr[1], uint8arr.byteLength) # Prints "255 10"
/// 
/// 	# Prints "Uint8Array(10) [ 0, 255, 0, 0, 0, 0, 0, 0, 0, 0 ]" in the browser's console.
/// 	console.log(uint8arr)
/// 
/// 	# Equivalent of JavaScriptBridge: Array.from(uint8arr).forEach(myCallback)
/// 	JavaScriptBridge.get_interface("Array").from(uint8arr).forEach(_my_js_callback)
/// 
/// func myCallback(args):
/// 	# Will be called with the parameters passed to the "forEach" callback
/// 	# [0, 0, [JavaScriptObject:1173]]
/// 	# [255, 1, [JavaScriptObject:1173]]
/// 	# ...
/// 	# [0, 9, [JavaScriptObject:1180]]
/// 	print(args)
/// </code></para>
/// <para><b>Note:</b> Only available in the Web platform.</para>
/// </summary>
public partial class JavaScriptObject : RefCounted
{
    private static readonly System.Type CachedType = typeof(JavaScriptObject);

    private static readonly StringName NativeName = "JavaScriptObject";

    internal JavaScriptObject() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal JavaScriptObject(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal JavaScriptObject(bool memoryOwn) : base(memoryOwn) { }

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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}

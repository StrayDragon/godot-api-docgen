namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An advanced <see cref="Godot.Variant"/> type. All classes in the engine inherit from Object. Each class may define new properties, methods or signals, which are available to all inheriting classes. For example, a <see cref="Godot.Sprite2D"/> instance is able to call <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/> because it inherits from <see cref="Godot.Node"/>.</para>
/// <para>You can create new instances, using <c>Object.new()</c> in GDScript, or <c>new GodotObject</c> in C#.</para>
/// <para>To delete an Object instance, call <see cref="Godot.GodotObject.Free()"/>. This is necessary for most classes inheriting Object, because they do not manage memory on their own, and will otherwise cause memory leaks when no longer in use. There are a few classes that perform memory management. For example, <see cref="Godot.RefCounted"/> (and by extension <see cref="Godot.Resource"/>) deletes itself when no longer referenced, and <see cref="Godot.Node"/> deletes its children when freed.</para>
/// <para>Objects can have a <see cref="Godot.Script"/> attached to them. Once the <see cref="Godot.Script"/> is instantiated, it effectively acts as an extension to the base class, allowing it to define and inherit new properties, methods and signals.</para>
/// <para>Inside a <see cref="Godot.Script"/>, <see cref="Godot.GodotObject._GetPropertyList()"/> may be overridden to customize properties in several ways. This allows them to be available to the editor, display as lists of options, sub-divide into groups, save on disk, etc. Scripting languages offer easier ways to customize properties, such as with the [annotation @GDScript.@export] annotation.</para>
/// <para>Godot is very dynamic. An object's script, and therefore its properties, methods and signals, can be changed at run-time. Because of this, there can be occasions where, for example, a property required by a method may not exist. To prevent run-time errors, see methods such as <see cref="Godot.GodotObject.Set(StringName, Variant)"/>, <see cref="Godot.GodotObject.Get(StringName)"/>, <see cref="Godot.GodotObject.Call(StringName, Variant[])"/>, <see cref="Godot.GodotObject.HasMethod(StringName)"/>, <see cref="Godot.GodotObject.HasSignal(StringName)"/>, etc. Note that these methods are <b>much</b> slower than direct references.</para>
/// <para>In GDScript, you can also check if a given property, method, or signal name exists in an object with the <c>in</c> operator:</para>
/// <para><code>
/// var node = Node.new()
/// print("name" in node)         # Prints true
/// print("get_parent" in node)   # Prints true
/// print("tree_entered" in node) # Prints true
/// print("unknown" in node)      # Prints false
/// </code></para>
/// <para>Notifications are <see cref="int"/> constants commonly sent and received by objects. For example, on every rendered frame, the <see cref="Godot.SceneTree"/> notifies nodes inside the tree with a <see cref="Godot.Node.NotificationProcess"/>. The nodes receive it and may call <see cref="Godot.Node._Process(double)"/> to update. To make use of notifications, see <see cref="Godot.GodotObject.Notification(int, bool)"/> and <see cref="Godot.GodotObject._Notification(int)"/>.</para>
/// <para>Lastly, every object can also contain metadata (data about data). <see cref="Godot.GodotObject.SetMeta(StringName, Variant)"/> can be useful to store information that the object itself does not depend on. To keep your code clean, making excessive use of metadata is discouraged.</para>
/// <para><b>Note:</b> Unlike references to a <see cref="Godot.RefCounted"/>, references to an object stored in a variable can become invalid without being set to <see langword="null"/>. To check if an object has been deleted, do <i>not</i> compare it against <see langword="null"/>. Instead, use <c>@GlobalScope.is_instance_valid</c>. It's also recommended to inherit from <see cref="Godot.RefCounted"/> for classes storing data instead of <see cref="Godot.GodotObject"/>.</para>
/// <para><b>Note:</b> The <c>script</c> is not exposed like most properties. To set or get an object's <see cref="Godot.Script"/> in code, use <see cref="Godot.GodotObject.SetScript(Variant)"/> and <see cref="Godot.GodotObject.GetScript()"/>, respectively.</para>
/// <para><b>Note:</b> In a boolean context, an <see cref="Godot.GodotObject"/> will evaluate to <see langword="false"/> if it is equal to <see langword="null"/> or it has been freed. Otherwise, an <see cref="Godot.GodotObject"/> will always evaluate to <see langword="true"/>. See also <c>@GlobalScope.is_instance_valid</c>.</para>
/// </summary>
[GodotClassName("Object")]
public partial class GodotObject
{
    /// <summary>
    /// <para>Notification received when the object is initialized, before its script is attached. Used internally.</para>
    /// </summary>
    public const long NotificationPostinitialize = 0;
    /// <summary>
    /// <para>Notification received when the object is about to be deleted. Can be used like destructors in object-oriented programming languages.</para>
    /// <para>This notification is sent in reversed order.</para>
    /// </summary>
    public const long NotificationPredelete = 1;
    /// <summary>
    /// <para>Notification received when the object finishes hot reloading. This notification is only sent for extensions classes and derived.</para>
    /// </summary>
    public const long NotificationExtensionReloaded = 2;

    public enum ConnectFlags : long
    {
        /// <summary>
        /// <para>Deferred connections trigger their <see cref="Godot.Callable"/>s on idle time (at the end of the frame), rather than instantly.</para>
        /// </summary>
        Deferred = 1,
        /// <summary>
        /// <para>Persisting connections are stored when the object is serialized (such as when using <see cref="Godot.PackedScene.Pack(Node)"/>). In the editor, connections created through the Signals dock are always persisting.</para>
        /// <para><b>Note:</b> Connections to lambda functions (that is, when the function code is embedded in the <see cref="Godot.GodotObject.Connect(StringName, Callable, uint)"/> call) cannot be made persistent.</para>
        /// </summary>
        Persist = 2,
        /// <summary>
        /// <para>One-shot connections disconnect themselves after emission.</para>
        /// </summary>
        OneShot = 4,
        /// <summary>
        /// <para>Reference-counted connections can be assigned to the same <see cref="Godot.Callable"/> multiple times. Each disconnection decreases the internal counter. The signal fully disconnects only when the counter reaches 0.</para>
        /// </summary>
        ReferenceCounted = 8,
        /// <summary>
        /// <para>On signal emission, the source object is automatically appended after the original arguments of the signal, regardless of the connected <see cref="Godot.Callable"/>'s unbinds which affect only the original arguments of the signal (see <c>Callable.unbind</c>, <c>Callable.get_unbound_arguments_count</c>).</para>
        /// <para><code>
        /// extends Object
        /// 
        /// signal test_signal
        /// 
        /// func test():
        /// 	print(self) # Prints e.g. &lt;Object#35332818393&gt;
        /// 	test_signal.connect(prints.unbind(1), CONNECT_APPEND_SOURCE_OBJECT)
        /// 	test_signal.emit("emit_arg_1", "emit_arg_2") # Prints emit_arg_1 &lt;Object#35332818393&gt;
        /// </code></para>
        /// </summary>
        AppendSourceObject = 16
    }

    private static readonly StringName NativeName = "Object";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    /// <summary>
    /// <para>Override this method to customize the behavior of <see cref="Godot.GodotObject.Get(StringName)"/>. Should return the given <paramref name="property"/>'s value, or <see langword="null"/> if the <paramref name="property"/> should be handled normally.</para>
    /// <para>Combined with <see cref="Godot.GodotObject._Set(StringName, Variant)"/> and <see cref="Godot.GodotObject._GetPropertyList()"/>, this method allows defining custom properties, which is particularly useful for editor plugins.</para>
    /// <para><b>Note:</b> This method is not called when getting built-in properties of an object, including properties defined with [annotation @GDScript.@export].</para>
    /// <para><code>
    /// public override Variant _Get(StringName property)
    /// {
    /// 	if (property == "FakeProperty")
    /// 	{
    /// 		GD.Print("Getting my property!");
    /// 		return 4;
    /// 	}
    /// 	return default;
    /// }
    /// 
    /// public override Godot.Collections.Array&lt;Godot.Collections.Dictionary&gt; _GetPropertyList()
    /// {
    /// 	return
    /// 	[
    /// 		new Godot.Collections.Dictionary()
    /// 		{
    /// 			{ "name", "FakeProperty" },
    /// 			{ "type", (int)Variant.Type.Int },
    /// 		},
    /// 	];
    /// }
    /// </code></para>
    /// <para><b>Note:</b> Unlike other virtual methods, this method is called automatically for every script that overrides it. This means that the base implementation should not be called via <c>super</c> in GDScript or its equivalents in other languages. The bottom-most sub-class will be called first, with subsequent calls ascending the class hierarchy. The call chain will stop on the first class that returns a non-<see langword="null"/> value.</para>
    /// </summary>
    public virtual Variant _Get(StringName property)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to provide a custom list of additional properties to handle by the engine.</para>
    /// <para>Should return a property list, as an <see cref="Godot.Collections.Array"/> of dictionaries. The result is added to the array of <see cref="Godot.GodotObject.GetPropertyList()"/>, and should be formatted in the same way. Each <see cref="Godot.Collections.Dictionary"/> must at least contain the <c>name</c> and <c>type</c> entries.</para>
    /// <para>You can use <see cref="Godot.GodotObject._PropertyCanRevert(StringName)"/> and <see cref="Godot.GodotObject._PropertyGetRevert(StringName)"/> to customize the default values of the properties added by this method.</para>
    /// <para>The example below displays a list of numbers shown as words going from <c>ZERO</c> to <c>FIVE</c>, with <c>number_count</c> controlling the size of the list:</para>
    /// <para><code>
    /// [Tool]
    /// public partial class MyNode : Node
    /// {
    /// 	private int _numberCount;
    /// 
    /// 	[Export]
    /// 	public int NumberCount
    /// 	{
    /// 		get =&gt; _numberCount;
    /// 		set
    /// 		{
    /// 			_numberCount = value;
    /// 			_numbers.Resize(_numberCount);
    /// 			NotifyPropertyListChanged();
    /// 		}
    /// 	}
    /// 
    /// 	private Godot.Collections.Array&lt;int&gt; _numbers = [];
    /// 
    /// 	public override Godot.Collections.Array&lt;Godot.Collections.Dictionary&gt; _GetPropertyList()
    /// 	{
    /// 		Godot.Collections.Array&lt;Godot.Collections.Dictionary&gt; properties = [];
    /// 
    /// 		for (int i = 0; i &lt; _numberCount; i++)
    /// 		{
    /// 			properties.Add(new Godot.Collections.Dictionary()
    /// 			{
    /// 				{ "name", $"number_{i}" },
    /// 				{ "type", (int)Variant.Type.Int },
    /// 				{ "hint", (int)PropertyHint.Enum },
    /// 				{ "hint_string", "Zero,One,Two,Three,Four,Five" },
    /// 			});
    /// 		}
    /// 
    /// 		return properties;
    /// 	}
    /// 
    /// 	public override Variant _Get(StringName property)
    /// 	{
    /// 		string propertyName = property.ToString();
    /// 		if (propertyName.StartsWith("number_"))
    /// 		{
    /// 			int index = int.Parse(propertyName.Substring("number_".Length));
    /// 			return _numbers[index];
    /// 		}
    /// 		return default;
    /// 	}
    /// 
    /// 	public override bool _Set(StringName property, Variant value)
    /// 	{
    /// 		string propertyName = property.ToString();
    /// 		if (propertyName.StartsWith("number_"))
    /// 		{
    /// 			int index = int.Parse(propertyName.Substring("number_".Length));
    /// 			_numbers[index] = value.As&lt;int&gt;();
    /// 			return true;
    /// 		}
    /// 		return false;
    /// 	}
    /// }
    /// </code></para>
    /// <para><b>Note:</b> This method is intended for advanced purposes. For most common use cases, the scripting languages offer easier ways to handle properties. See [annotation @GDScript.@export], [annotation @GDScript.@export_enum], [annotation @GDScript.@export_group], etc. If you want to customize exported properties, use <see cref="Godot.GodotObject._ValidateProperty(Godot.Collections.Dictionary)"/>.</para>
    /// <para><b>Note:</b> If the object's script is not [annotation @GDScript.@tool], this method will not be called in the editor.</para>
    /// <para><b>Note:</b> Unlike other virtual methods, this method is called automatically for every script that overrides it. This means that the base implementation should not be called via <c>super</c> in GDScript or its equivalents in other languages. The bottom-most sub-class will be called first, with subsequent calls ascending the class hierarchy.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetPropertyList()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the current iterable value. <paramref name="iter"/> stores the iteration state, but unlike <see cref="Godot.GodotObject._IterInit(Godot.Collections.Array)"/> and <see cref="Godot.GodotObject._IterNext(Godot.Collections.Array)"/> the state is supposed to be read-only, so there is no <see cref="Godot.Collections.Array"/> wrapper.</para>
    /// <para><b>Tip:</b> In GDScript, you can use a subtype of <see cref="Godot.Variant"/> as the return type for <see cref="Godot.GodotObject._IterGet(Variant)"/>. The specified type will be used to set the type of the iterator variable in <c>for</c> loops, enhancing type safety.</para>
    /// </summary>
    public virtual Variant _IterGet(Variant iter)
    {
        return default;
    }

    /// <summary>
    /// <para>Initializes the iterator. <paramref name="iter"/> stores the iteration state. Since GDScript does not support passing arguments by reference, a single-element array is used as a wrapper. Returns <see langword="true"/> so long as the iterator has not reached the end.</para>
    /// <para><code>
    /// class MyRange:
    /// 	var _from
    /// 	var _to
    /// 
    /// 	func _init(from, to):
    /// 		assert(from &lt;= to)
    /// 		_from = from
    /// 		_to = to
    /// 
    /// 	func _iter_init(iter):
    /// 		iter[0] = _from
    /// 		return iter[0] &lt; _to
    /// 
    /// 	func _iter_next(iter):
    /// 		iter[0] += 1
    /// 		return iter[0] &lt; _to
    /// 
    /// 	func _iter_get(iter):
    /// 		return iter
    /// 
    /// func _ready():
    /// 	var my_range = MyRange.new(2, 5)
    /// 	for x in my_range:
    /// 		print(x) # Prints 2, 3, 4.
    /// </code></para>
    /// <para><b>Note:</b> Alternatively, you can ignore <paramref name="iter"/> and use the object's state instead, see <a href="$DOCS_URL/tutorials/scripting/gdscript/gdscript_advanced.html#custom-iterators">online docs</a> for an example. Note that in this case you will not be able to reuse the same iterator instance in nested loops. Also, make sure you reset the iterator state in this method if you want to reuse the same instance multiple times.</para>
    /// </summary>
    public virtual bool _IterInit(Godot.Collections.Array iter)
    {
        return default;
    }

    /// <summary>
    /// <para>Moves the iterator to the next iteration. <paramref name="iter"/> stores the iteration state. Since GDScript does not support passing arguments by reference, a single-element array is used as a wrapper. Returns <see langword="true"/> so long as the iterator has not reached the end.</para>
    /// </summary>
    public virtual bool _IterNext(Godot.Collections.Array iter)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the object receives a notification, which can be identified in <paramref name="what"/> by comparing it with a constant. See also <see cref="Godot.GodotObject.Notification(int, bool)"/>.</para>
    /// <para><code>
    /// public override void _Notification(int what)
    /// {
    /// 	if (what == NotificationPredelete)
    /// 	{
    /// 		GD.Print("Goodbye!");
    /// 	}
    /// }
    /// </code></para>
    /// <para><b>Note:</b> The base <see cref="Godot.GodotObject"/> defines a few notifications (<see cref="Godot.GodotObject.NotificationPostinitialize"/> and <see cref="Godot.GodotObject.NotificationPredelete"/>). Inheriting classes such as <see cref="Godot.Node"/> define a lot more notifications, which are also received by this method.</para>
    /// <para><b>Note:</b> Unlike other virtual methods, this method is called automatically for every script that overrides it. This means that the base implementation should not be called via <c>super</c> in GDScript or its equivalents in other languages. Call order depends on the <c>reversed</c> argument of <see cref="Godot.GodotObject.Notification(int, bool)"/> and varies between different notifications. Most notifications are sent in the forward order (i.e. Object class first, most derived class last).</para>
    /// </summary>
    public virtual void _Notification(int what)
    {
    }

    /// <summary>
    /// <para>Override this method to customize the given <paramref name="property"/>'s revert behavior. Should return <see langword="true"/> if the <paramref name="property"/> has a custom default value and is revertible in the Inspector dock. Use <see cref="Godot.GodotObject._PropertyGetRevert(StringName)"/> to specify the <paramref name="property"/>'s default value.</para>
    /// <para><b>Note:</b> This method must return consistently, regardless of the current value of the <paramref name="property"/>.</para>
    /// <para><b>Note:</b> Unlike other virtual methods, this method is called automatically for every script that overrides it. This means that the base implementation should not be called via <c>super</c> in GDScript or its equivalents in other languages. The bottom-most sub-class will be called first, with subsequent calls ascending the class hierarchy. The call chain will stop on the first class that returns <see langword="true"/>.</para>
    /// </summary>
    public virtual bool _PropertyCanRevert(StringName property)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the given <paramref name="property"/>'s revert behavior. Should return the default value for the <paramref name="property"/>. If the default value differs from the <paramref name="property"/>'s current value, a revert icon is displayed in the Inspector dock.</para>
    /// <para><b>Note:</b> <see cref="Godot.GodotObject._PropertyCanRevert(StringName)"/> must also be overridden for this method to be called.</para>
    /// <para><b>Note:</b> Unlike other virtual methods, this method is called automatically for every script that overrides it. This means that the base implementation should not be called via <c>super</c> in GDScript or its equivalents in other languages. The bottom-most sub-class will be called first, with subsequent calls ascending the class hierarchy. The call chain will stop on the first class that returns a non-<see langword="null"/> value.</para>
    /// </summary>
    public virtual Variant _PropertyGetRevert(StringName property)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the behavior of <see cref="Godot.GodotObject.Set(StringName, Variant)"/>. Should set the <paramref name="property"/> to <paramref name="value"/> and return <see langword="true"/>, or <see langword="false"/> if the <paramref name="property"/> should be handled normally. The <i>exact</i> way to set the <paramref name="property"/> is up to this method's implementation.</para>
    /// <para>Combined with <see cref="Godot.GodotObject._Get(StringName)"/> and <see cref="Godot.GodotObject._GetPropertyList()"/>, this method allows defining custom properties, which is particularly useful for editor plugins.</para>
    /// <para><b>Note:</b> This method is not called when setting built-in properties of an object, including properties defined with [annotation @GDScript.@export].</para>
    /// <para><code>
    /// private Godot.Collections.Dictionary _internalData = new Godot.Collections.Dictionary();
    /// 
    /// public override bool _Set(StringName property, Variant value)
    /// {
    /// 	if (property == "FakeProperty")
    /// 	{
    /// 		// Storing the value in the fake property.
    /// 		_internalData["FakeProperty"] = value;
    /// 		return true;
    /// 	}
    /// 
    /// 	return false;
    /// }
    /// 
    /// public override Godot.Collections.Array&lt;Godot.Collections.Dictionary&gt; _GetPropertyList()
    /// {
    /// 	return
    /// 	[
    /// 		new Godot.Collections.Dictionary()
    /// 		{
    /// 			{ "name", "FakeProperty" },
    /// 			{ "type", (int)Variant.Type.Int },
    /// 		},
    /// 	];
    /// }
    /// </code></para>
    /// <para><b>Note:</b> Unlike other virtual methods, this method is called automatically for every script that overrides it. This means that the base implementation should not be called via <c>super</c> in GDScript or its equivalents in other languages. The bottom-most sub-class will be called first, with subsequent calls ascending the class hierarchy. The call chain will stop on the first class that returns <see langword="true"/>.</para>
    /// </summary>
    public virtual bool _Set(StringName property, Variant value)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize existing properties. Every property info goes through this method, except properties added with <see cref="Godot.GodotObject._GetPropertyList()"/>. The dictionary contents is the same as in <see cref="Godot.GodotObject._GetPropertyList()"/>.</para>
    /// <para><code>
    /// [Tool]
    /// public partial class MyNode : Node
    /// {
    /// 	private bool _isNumberEditable;
    /// 
    /// 	[Export]
    /// 	public bool IsNumberEditable
    /// 	{
    /// 		get =&gt; _isNumberEditable;
    /// 		set
    /// 		{
    /// 			_isNumberEditable = value;
    /// 			NotifyPropertyListChanged();
    /// 		}
    /// 	}
    /// 
    /// 	[Export]
    /// 	public int Number { get; set; }
    /// 
    /// 	public override void _ValidateProperty(Godot.Collections.Dictionary property)
    /// 	{
    /// 		if (property["name"].AsStringName() == PropertyName.Number &amp;&amp; !IsNumberEditable)
    /// 		{
    /// 			var usage = property["usage"].As&lt;PropertyUsageFlags&gt;() | PropertyUsageFlags.ReadOnly;
    /// 			property["usage"] = (int)usage;
    /// 		}
    /// 	}
    /// }
    /// </code></para>
    /// </summary>
    public virtual void _ValidateProperty(Godot.Collections.Dictionary property)
    {
    }

    /// <summary>
    /// <para>Deletes the object from memory. Pre-existing references to the object become invalid, and any attempt to access them will result in a runtime error. Checking the references with <c>@GlobalScope.is_instance_valid</c> will return <see langword="false"/>. This is equivalent to the <c>memdelete</c> function in GDExtension C++.</para>
    /// </summary>
    public void Free()
    {
        Call(MethodName.Free);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClass, 201670096ul);

    /// <summary>
    /// <para>Returns the object's built-in class name, as a <see cref="string"/>. See also <see cref="Godot.GodotObject.IsClass(string)"/>.</para>
    /// <para><b>Note:</b> This method ignores <c>class_name</c> declarations. If this object's script has defined a <c>class_name</c>, the base, built-in class name is returned instead.</para>
    /// </summary>
    public string GetClass()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClass, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the object inherits from the given <paramref name="class"/>. See also <see cref="Godot.GodotObject.GetClass()"/>.</para>
    /// <para><code>
    /// var sprite2D = new Sprite2D();
    /// sprite2D.IsClass("Sprite2D"); // Returns true
    /// sprite2D.IsClass("Node");     // Returns true
    /// sprite2D.IsClass("Node3D");   // Returns false
    /// </code></para>
    /// <para><b>Note:</b> This method ignores <c>class_name</c> declarations in the object's script.</para>
    /// </summary>
    public bool IsClass(string @class)
    {
        return NativeCalls.godot_icall_1_131(MethodBind1, GodotObject.GetPtr(this), @class).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Set, 3776071444ul);

    /// <summary>
    /// <para>Assigns <paramref name="value"/> to the given <paramref name="property"/>. If the property does not exist or the given <paramref name="value"/>'s type doesn't match, nothing happens.</para>
    /// <para><code>
    /// var node = new Node2D();
    /// node.Set(Node2D.PropertyName.GlobalScale, new Vector2(8, 2.5f));
    /// GD.Print(node.GlobalScale); // Prints (8, 2.5)
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="property"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void Set(StringName property, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get, 2760726917ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Variant"/> value of the given <paramref name="property"/>. If the <paramref name="property"/> does not exist, this method returns <see langword="null"/>.</para>
    /// <para><code>
    /// var node = new Node2D();
    /// node.Rotation = 1.5f;
    /// var a = node.Get(Node2D.PropertyName.Rotation); // a is 1.5
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="property"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public Variant Get(StringName property)
    {
        return NativeCalls.godot_icall_1_143(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndexed, 3500910842ul);

    /// <summary>
    /// <para>Assigns a new <paramref name="value"/> to the property identified by the <paramref name="propertyPath"/>. The path should be a <see cref="Godot.NodePath"/> relative to this object, and can use the colon character (<c>:</c>) to access nested properties.</para>
    /// <para><code>
    /// var node = new Node2D();
    /// node.SetIndexed("position", new Vector2(42, 0));
    /// node.SetIndexed("position:y", -10);
    /// GD.Print(node.Position); // Prints (42, -10)
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="propertyPath"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void SetIndexed(NodePath propertyPath, Variant value)
    {
        NativeCalls.godot_icall_2_916(MethodBind4, GodotObject.GetPtr(this), (godot_node_path)(propertyPath?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndexed, 4006125091ul);

    /// <summary>
    /// <para>Gets the object's property indexed by the given <paramref name="propertyPath"/>. The path should be a <see cref="Godot.NodePath"/> relative to the current object and can use the colon character (<c>:</c>) to access nested properties.</para>
    /// <para><b>Examples:</b> <c>"position:x"</c> or <c>"material:next_pass:blend_mode"</c>.</para>
    /// <para><code>
    /// var node = new Node2D();
    /// node.Position = new Vector2(5, -10);
    /// var a = node.GetIndexed("position");   // a is Vector2(5, -10)
    /// var b = node.GetIndexed("position:y"); // b is -10
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="propertyPath"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// <para><b>Note:</b> This method does not support actual paths to nodes in the <see cref="Godot.SceneTree"/>, only sub-property paths. In the context of nodes, use <see cref="Godot.Node.GetNodeAndResource(NodePath)"/> instead.</para>
    /// </summary>
    public Variant GetIndexed(NodePath propertyPath)
    {
        return NativeCalls.godot_icall_1_917(MethodBind5, GodotObject.GetPtr(this), (godot_node_path)(propertyPath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPropertyList, 3995934104ul);

    /// <summary>
    /// <para>Returns the object's property list as an <see cref="Godot.Collections.Array"/> of dictionaries. Each <see cref="Godot.Collections.Dictionary"/> contains the following entries:</para>
    /// <para>- <c>name</c> is the property's name, as a <see cref="string"/>;</para>
    /// <para>- <c>class_name</c> is an empty <see cref="Godot.StringName"/>, unless the property is <see cref="Godot.Variant.Type.Object"/> and it inherits from a class;</para>
    /// <para>- <c>type</c> is the property's type, as an <see cref="int"/> (see <see cref="Godot.Variant.Type"/>);</para>
    /// <para>- <c>hint</c> is <i>how</i> the property is meant to be edited (see <see cref="Godot.PropertyHint"/>);</para>
    /// <para>- <c>hint_string</c> depends on the hint (see <see cref="Godot.PropertyHint"/>);</para>
    /// <para>- <c>usage</c> is a combination of <see cref="Godot.PropertyUsageFlags"/>.</para>
    /// <para><b>Note:</b> In GDScript, all class members are treated as properties. In C# and GDExtension, it may be necessary to explicitly mark class members as Godot properties using decorators or attributes.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetPropertyList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind6, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMethodList, 3995934104ul);

    /// <summary>
    /// <para>Returns this object's methods and their signatures as an <see cref="Godot.Collections.Array"/> of dictionaries. Each <see cref="Godot.Collections.Dictionary"/> contains the following entries:</para>
    /// <para>- <c>name</c> is the name of the method, as a <see cref="string"/>;</para>
    /// <para>- <c>args</c> is an <see cref="Godot.Collections.Array"/> of dictionaries representing the arguments;</para>
    /// <para>- <c>default_args</c> is the default arguments as an <see cref="Godot.Collections.Array"/> of variants;</para>
    /// <para>- <c>flags</c> is a combination of <see cref="Godot.MethodFlags"/>;</para>
    /// <para>- <c>id</c> is the method's internal identifier <see cref="int"/>;</para>
    /// <para>- <c>return</c> is the returned value, as a <see cref="Godot.Collections.Dictionary"/>;</para>
    /// <para><b>Note:</b> The dictionaries of <c>args</c> and <c>return</c> are formatted identically to the results of <see cref="Godot.GodotObject.GetPropertyList()"/>, although not all entries are used.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetMethodList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyCanRevert, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="property"/> has a custom default value. Use <see cref="Godot.GodotObject.PropertyGetRevert(StringName)"/> to get the <paramref name="property"/>'s default value.</para>
    /// <para><b>Note:</b> This method is used by the Inspector dock to display a revert icon. The object must implement <see cref="Godot.GodotObject._PropertyCanRevert(StringName)"/> to customize the default value. If <see cref="Godot.GodotObject._PropertyCanRevert(StringName)"/> is not implemented, this method returns <see langword="false"/>.</para>
    /// </summary>
    public bool PropertyCanRevert(StringName property)
    {
        return NativeCalls.godot_icall_1_105(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyGetRevert, 2760726917ul);

    /// <summary>
    /// <para>Returns the custom default value of the given <paramref name="property"/>. Use <see cref="Godot.GodotObject.PropertyCanRevert(StringName)"/> to check if the <paramref name="property"/> has a custom default value.</para>
    /// <para><b>Note:</b> This method is used by the Inspector dock to display a revert icon. The object must implement <see cref="Godot.GodotObject._PropertyGetRevert(StringName)"/> to customize the default value. If <see cref="Godot.GodotObject._PropertyGetRevert(StringName)"/> is not implemented, this method returns <see langword="null"/>.</para>
    /// </summary>
    public Variant PropertyGetRevert(StringName property)
    {
        return NativeCalls.godot_icall_1_143(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Notification, 4023243586ul);

    /// <summary>
    /// <para>Sends the given <paramref name="what"/> notification to all classes inherited by the object, triggering calls to <see cref="Godot.GodotObject._Notification(int)"/>, starting from the highest ancestor (the <see cref="Godot.GodotObject"/> class) and going down to the object's script.</para>
    /// <para>If <paramref name="reversed"/> is <see langword="true"/>, the call order is reversed.</para>
    /// <para><code>
    /// var player = new Node2D();
    /// player.SetScript(GD.Load("res://player.gd"));
    /// 
    /// player.Notification(NotificationEnterTree);
    /// // The call order is GodotObject -&gt; Node -&gt; Node2D -&gt; player.gd.
    /// 
    /// player.Notification(NotificationEnterTree, true);
    /// // The call order is player.gd -&gt; Node2D -&gt; Node -&gt; GodotObject.
    /// </code></para>
    /// </summary>
    public void Notification(int what, bool reversed = false)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), what, reversed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceId, 3905245786ul);

    /// <summary>
    /// <para>Returns the object's unique instance ID. This ID can be saved in <see cref="Godot.EncodedObjectAsId"/>, and can be used to retrieve this object instance with <c>@GlobalScope.instance_from_id</c>.</para>
    /// <para><b>Note:</b> This ID is only useful during the current session. It won't correspond to a similar object if the ID is sent over a network, or loaded from a file at a later time.</para>
    /// </summary>
    public ulong GetInstanceId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScript, 1114965689ul);

    /// <summary>
    /// <para>Attaches <paramref name="script"/> to the object, and instantiates it. As a result, the script's <see cref="Godot.GodotObject.GodotObject()"/> is called. A <see cref="Godot.Script"/> is used to extend the object's functionality.</para>
    /// <para>If a script already exists, its instance is detached, and its property values and state are lost. Built-in property values are still kept.</para>
    /// </summary>
    public void SetScript(Variant script)
    {
        NativeCalls.godot_icall_1_773(MethodBind12, GodotObject.GetPtr(this), script);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScript, 1214101251ul);

    /// <summary>
    /// <para>Returns the object's <see cref="Godot.Script"/> instance, or <see langword="null"/> if no script is attached.</para>
    /// </summary>
    public Variant GetScript()
    {
        return NativeCalls.godot_icall_0_772(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMeta, 3776071444ul);

    /// <summary>
    /// <para>Adds or changes the entry <paramref name="name"/> inside the object's metadata. The metadata <paramref name="value"/> can be any <see cref="Godot.Variant"/>, although some types cannot be serialized correctly.</para>
    /// <para>If <paramref name="value"/> is <see langword="null"/>, the entry is removed. This is the equivalent of using <see cref="Godot.GodotObject.RemoveMeta(StringName)"/>. See also <see cref="Godot.GodotObject.HasMeta(StringName)"/> and <see cref="Godot.GodotObject.GetMeta(StringName, Variant)"/>.</para>
    /// <para><b>Note:</b> A metadata's name must be a valid identifier as per <c>StringName.is_valid_identifier</c> method.</para>
    /// <para><b>Note:</b> Metadata that has a name starting with an underscore (<c>_</c>) is considered editor-only. Editor-only metadata is not displayed in the Inspector and should not be edited, although it can still be found by this method.</para>
    /// </summary>
    public void SetMeta(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind14, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveMeta, 3304788590ul);

    /// <summary>
    /// <para>Removes the given entry <paramref name="name"/> from the object's metadata. See also <see cref="Godot.GodotObject.HasMeta(StringName)"/>, <see cref="Godot.GodotObject.GetMeta(StringName, Variant)"/> and <see cref="Godot.GodotObject.SetMeta(StringName, Variant)"/>.</para>
    /// <para><b>Note:</b> A metadata's name must be a valid identifier as per <c>StringName.is_valid_identifier</c> method.</para>
    /// <para><b>Note:</b> Metadata that has a name starting with an underscore (<c>_</c>) is considered editor-only. Editor-only metadata is not displayed in the Inspector and should not be edited, although it can still be found by this method.</para>
    /// </summary>
    public void RemoveMeta(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind15, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeta, 3990617847ul);

    /// <summary>
    /// <para>Returns the object's metadata value for the given entry <paramref name="name"/>. If the entry does not exist, returns <paramref name="default"/>. If <paramref name="default"/> is <see langword="null"/>, an error is also generated.</para>
    /// <para><b>Note:</b> A metadata's name must be a valid identifier as per <c>StringName.is_valid_identifier</c> method.</para>
    /// <para><b>Note:</b> Metadata that has a name starting with an underscore (<c>_</c>) is considered editor-only. Editor-only metadata is not displayed in the Inspector and should not be edited, although it can still be found by this method.</para>
    /// </summary>
    public Variant GetMeta(StringName name, Variant @default = default)
    {
        return NativeCalls.godot_icall_2_918(MethodBind16, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), @default);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMeta, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a metadata entry is found with the given <paramref name="name"/>. See also <see cref="Godot.GodotObject.GetMeta(StringName, Variant)"/>, <see cref="Godot.GodotObject.SetMeta(StringName, Variant)"/> and <see cref="Godot.GodotObject.RemoveMeta(StringName)"/>.</para>
    /// <para><b>Note:</b> A metadata's name must be a valid identifier as per <c>StringName.is_valid_identifier</c> method.</para>
    /// <para><b>Note:</b> Metadata that has a name starting with an underscore (<c>_</c>) is considered editor-only. Editor-only metadata is not displayed in the Inspector and should not be edited, although it can still be found by this method.</para>
    /// </summary>
    public bool HasMeta(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMetaList, 3995934104ul);

    /// <summary>
    /// <para>Returns the object's metadata entry names as an <see cref="Godot.Collections.Array"/> of <see cref="Godot.StringName"/>s.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetMetaList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind18, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddUserSignal, 85656714ul);

    /// <summary>
    /// <para>Adds a user-defined signal named <paramref name="signal"/>. Optional arguments for the signal can be added as an <see cref="Godot.Collections.Array"/> of dictionaries, each defining a <c>name</c> <see cref="string"/> and a <c>type</c> <see cref="int"/> (see <see cref="Godot.Variant.Type"/>). See also <see cref="Godot.GodotObject.HasUserSignal(StringName)"/> and <see cref="Godot.GodotObject.RemoveUserSignal(StringName)"/>.</para>
    /// <para><code>
    /// AddUserSignal("Hurt",
    /// [
    /// 	new Godot.Collections.Dictionary()
    /// 	{
    /// 		{ "name", "damage" },
    /// 		{ "type", (int)Variant.Type.Int },
    /// 	},
    /// 	new Godot.Collections.Dictionary()
    /// 	{
    /// 		{ "name", "source" },
    /// 		{ "type", (int)Variant.Type.Object },
    /// 	},
    /// ]);
    /// </code></para>
    /// </summary>
    public void AddUserSignal(string signal, Godot.Collections.Array arguments = null)
    {
        NativeCalls.godot_icall_2_469(MethodBind19, GodotObject.GetPtr(this), signal, (godot_array)(arguments ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasUserSignal, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given user-defined <paramref name="signal"/> name exists. Only signals added with <see cref="Godot.GodotObject.AddUserSignal(string, Godot.Collections.Array)"/> are included. See also <see cref="Godot.GodotObject.RemoveUserSignal(StringName)"/>.</para>
    /// </summary>
    public bool HasUserSignal(StringName signal)
    {
        return NativeCalls.godot_icall_1_105(MethodBind20, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveUserSignal, 3304788590ul);

    /// <summary>
    /// <para>Removes the given user signal <paramref name="signal"/> from the object. See also <see cref="Godot.GodotObject.AddUserSignal(string, Godot.Collections.Array)"/> and <see cref="Godot.GodotObject.HasUserSignal(StringName)"/>.</para>
    /// </summary>
    public void RemoveUserSignal(StringName signal)
    {
        NativeCalls.godot_icall_1_64(MethodBind21, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EmitSignal, 4047867050ul);

    /// <summary>
    /// <para>Emits the given <paramref name="signal"/> by name. The signal must exist, so it should be a built-in signal of this class or one of its inherited classes, or a user-defined signal (see <see cref="Godot.GodotObject.AddUserSignal(string, Godot.Collections.Array)"/>). This method supports a variable number of arguments, so parameters can be passed as a comma separated list.</para>
    /// <para>Returns <see cref="Godot.Error.Unavailable"/> if <paramref name="signal"/> does not exist or the parameters are invalid.</para>
    /// <para><code>
    /// EmitSignal(SignalName.Hit, "sword", 100);
    /// EmitSignal(SignalName.GameOver);
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="signal"/> must be in snake_case when referring to built-in Godot signals. Prefer using the names exposed in the <c>SignalName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public Error EmitSignal(StringName signal, params Variant[] @args)
    {
        return (Error)NativeCalls.godot_icall_2_891(MethodBind22, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default), @args, (godot_string_name)MethodName.EmitSignal.NativeValue);
    }

    /// <summary>
    /// <para>Emits the given <paramref name="signal"/> by name. The signal must exist, so it should be a built-in signal of this class or one of its inherited classes, or a user-defined signal (see <see cref="Godot.GodotObject.AddUserSignal(string, Godot.Collections.Array)"/>). This method supports a variable number of arguments, so parameters can be passed as a comma separated list.</para>
    /// <para>Returns <see cref="Godot.Error.Unavailable"/> if <paramref name="signal"/> does not exist or the parameters are invalid.</para>
    /// <para><code>
    /// EmitSignal(SignalName.Hit, "sword", 100);
    /// EmitSignal(SignalName.GameOver);
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="signal"/> must be in snake_case when referring to built-in Godot signals. Prefer using the names exposed in the <c>SignalName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public Error EmitSignal(StringName signal, ReadOnlySpan<Variant> @args)
    {
        return (Error)NativeCalls.godot_icall_2_891(MethodBind22, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default), @args, (godot_string_name)MethodName.EmitSignal.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Call, 3400424181ul);

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the object and returns the result. This method supports a variable number of arguments, so parameters can be passed as a comma separated list.</para>
    /// <para><code>
    /// var node = new Node3D();
    /// node.Call(Node3D.MethodName.Rotate, new Vector3(1f, 0f, 0f), 1.571f);
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public Variant Call(StringName method, params Variant[] @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind23, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.Call.NativeValue);
    }

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the object and returns the result. This method supports a variable number of arguments, so parameters can be passed as a comma separated list.</para>
    /// <para><code>
    /// var node = new Node3D();
    /// node.Call(Node3D.MethodName.Rotate, new Vector3(1f, 0f, 0f), 1.571f);
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public Variant Call(StringName method, ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind23, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.Call.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallDeferred, 3400424181ul);

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the object during idle time. Always returns <see langword="null"/>, <b>not</b> the method's result.</para>
    /// <para>Idle time happens mainly at the end of process and physics frames. In it, deferred calls will be run until there are none left, which means you can defer calls from other deferred calls and they'll still be run in the current idle time cycle. This means you should not call a method deferred from itself (or from a method called by it), as this causes infinite recursion the same way as if you had called the method directly.</para>
    /// <para>This method supports a variable number of arguments, so parameters can be passed as a comma separated list.</para>
    /// <para><code>
    /// var node = new Node3D();
    /// node.CallDeferred(Node3D.MethodName.Rotate, new Vector3(1f, 0f, 0f), 1.571f);
    /// </code></para>
    /// <para>For methods that are deferred from the same thread, the order of execution at idle time is identical to the order in which <c>call_deferred</c> was called.</para>
    /// <para>See also <c>Callable.call_deferred</c>.</para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// <para><b>Note:</b> If you're looking to delay the function call by a frame, refer to the <see cref="Godot.SceneTree.ProcessFrame"/> and <see cref="Godot.SceneTree.PhysicsFrame"/> signals.</para>
    /// <para><code>
    /// var node = Node3D.new()
    /// # Make a Callable and bind the arguments to the node's rotate() call.
    /// var callable = node.rotate.bind(Vector3(1.0, 0.0, 0.0), 1.571)
    /// # Connect the callable to the process_frame signal, so it gets called in the next process frame.
    /// # CONNECT_ONE_SHOT makes sure it only gets called once instead of every frame.
    /// get_tree().process_frame.connect(callable, CONNECT_ONE_SHOT)
    /// </code></para>
    /// </summary>
    public Variant CallDeferred(StringName method, params Variant[] @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind24, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallDeferred.NativeValue);
    }

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the object during idle time. Always returns <see langword="null"/>, <b>not</b> the method's result.</para>
    /// <para>Idle time happens mainly at the end of process and physics frames. In it, deferred calls will be run until there are none left, which means you can defer calls from other deferred calls and they'll still be run in the current idle time cycle. This means you should not call a method deferred from itself (or from a method called by it), as this causes infinite recursion the same way as if you had called the method directly.</para>
    /// <para>This method supports a variable number of arguments, so parameters can be passed as a comma separated list.</para>
    /// <para><code>
    /// var node = new Node3D();
    /// node.CallDeferred(Node3D.MethodName.Rotate, new Vector3(1f, 0f, 0f), 1.571f);
    /// </code></para>
    /// <para>For methods that are deferred from the same thread, the order of execution at idle time is identical to the order in which <c>call_deferred</c> was called.</para>
    /// <para>See also <c>Callable.call_deferred</c>.</para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// <para><b>Note:</b> If you're looking to delay the function call by a frame, refer to the <see cref="Godot.SceneTree.ProcessFrame"/> and <see cref="Godot.SceneTree.PhysicsFrame"/> signals.</para>
    /// <para><code>
    /// var node = Node3D.new()
    /// # Make a Callable and bind the arguments to the node's rotate() call.
    /// var callable = node.rotate.bind(Vector3(1.0, 0.0, 0.0), 1.571)
    /// # Connect the callable to the process_frame signal, so it gets called in the next process frame.
    /// # CONNECT_ONE_SHOT makes sure it only gets called once instead of every frame.
    /// get_tree().process_frame.connect(callable, CONNECT_ONE_SHOT)
    /// </code></para>
    /// </summary>
    public Variant CallDeferred(StringName method, ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind24, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallDeferred.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeferred, 3776071444ul);

    /// <summary>
    /// <para>Assigns <paramref name="value"/> to the given <paramref name="property"/>, at the end of the current frame. This is equivalent to calling <see cref="Godot.GodotObject.Set(StringName, Variant)"/> through <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/>.</para>
    /// <para><code>
    /// var node = new Node2D();
    /// node.Rotation = 1.5f;
    /// node.SetDeferred(Node2D.PropertyName.Rotation, 3f);
    /// GD.Print(node.Rotation); // Prints 1.5
    /// 
    /// await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    /// GD.Print(node.Rotation); // Prints 3.0
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="property"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void SetDeferred(StringName property, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind25, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Callv, 1260104456ul);

    /// <summary>
    /// <para>Calls the <paramref name="method"/> on the object and returns the result. Unlike <see cref="Godot.GodotObject.Call(StringName, Variant[])"/>, this method expects all parameters to be contained inside <paramref name="argArray"/>.</para>
    /// <para><code>
    /// var node = new Node3D();
    /// node.Callv(Node3D.MethodName.Rotate, [new Vector3(1f, 0f, 0f), 1.571f]);
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public Variant Callv(StringName method, Godot.Collections.Array argArray)
    {
        return NativeCalls.godot_icall_2_919(MethodBind26, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), (godot_array)(argArray ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMethod, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="method"/> name exists in the object.</para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public bool HasMethod(StringName method)
    {
        return NativeCalls.godot_icall_1_105(MethodBind27, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMethodArgumentCount, 2458036349ul);

    /// <summary>
    /// <para>Returns the number of arguments of the given <paramref name="method"/> by name.</para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public int GetMethodArgumentCount(StringName method)
    {
        return NativeCalls.godot_icall_1_193(MethodBind28, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSignal, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="signal"/> name exists in the object.</para>
    /// <para><b>Note:</b> In C#, <paramref name="signal"/> must be in snake_case when referring to built-in Godot signals. Prefer using the names exposed in the <c>SignalName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public bool HasSignal(StringName signal)
    {
        return NativeCalls.godot_icall_1_105(MethodBind29, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSignalList, 3995934104ul);

    /// <summary>
    /// <para>Returns the list of existing signals as an <see cref="Godot.Collections.Array"/> of dictionaries.</para>
    /// <para><b>Note:</b> Due to the implementation, each <see cref="Godot.Collections.Dictionary"/> is formatted very similarly to the returned values of <see cref="Godot.GodotObject.GetMethodList()"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetSignalList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind30, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSignalConnectionList, 3147814860ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of connections for the given <paramref name="signal"/> name. Each connection is represented as a <see cref="Godot.Collections.Dictionary"/> that contains three entries:</para>
    /// <para>- <c>signal</c> is a reference to the <see cref="Godot.Signal"/>;</para>
    /// <para>- <c>callable</c> is a reference to the connected <see cref="Godot.Callable"/>;</para>
    /// <para>- <c>flags</c> is a combination of <see cref="Godot.GodotObject.ConnectFlags"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetSignalConnectionList(StringName signal)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_696(MethodBind31, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIncomingConnections, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of signal connections received by this object. Each connection is represented as a <see cref="Godot.Collections.Dictionary"/> that contains three entries:</para>
    /// <para>- <c>signal</c> is a reference to the <see cref="Godot.Signal"/>;</para>
    /// <para>- <c>callable</c> is a reference to the <see cref="Godot.Callable"/>;</para>
    /// <para>- <c>flags</c> is a combination of <see cref="Godot.GodotObject.ConnectFlags"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetIncomingConnections()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind32, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Connect, 1518946055ul);

    /// <summary>
    /// <para>Connects a <paramref name="signal"/> by name to a <paramref name="callable"/>. Optional <paramref name="flags"/> can be also added to configure the connection's behavior (see <see cref="Godot.GodotObject.ConnectFlags"/> constants).</para>
    /// <para>A signal can only be connected once to the same <see cref="Godot.Callable"/>. If the signal is already connected, this method returns <see cref="Godot.Error.InvalidParameter"/> and generates an error, unless the signal is connected with <see cref="Godot.GodotObject.ConnectFlags.ReferenceCounted"/>. To prevent this, use <see cref="Godot.GodotObject.IsConnected(StringName, Callable)"/> first to check for existing connections.</para>
    /// <para><b>Note:</b> If the <paramref name="callable"/>'s object is freed, the connection will be lost.</para>
    /// <para><b>Note:</b> In GDScript, it is generally recommended to connect signals with <c>Signal.connect</c> instead.</para>
    /// <para><b>Note:</b> This method, and all other signal-related methods, are thread-safe.</para>
    /// </summary>
    public Error Connect(StringName signal, Callable callable, uint flags = (uint)(0))
    {
        return (Error)NativeCalls.godot_icall_3_920(MethodBind33, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default), callable, flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Disconnect, 1874754934ul);

    /// <summary>
    /// <para>Disconnects a <paramref name="signal"/> by name from a given <paramref name="callable"/>. If the connection does not exist, generates an error. Use <see cref="Godot.GodotObject.IsConnected(StringName, Callable)"/> to make sure that the connection exists.</para>
    /// </summary>
    public void Disconnect(StringName signal, Callable callable)
    {
        NativeCalls.godot_icall_2_549(MethodBind34, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsConnected, 768136979ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a connection exists between the given <paramref name="signal"/> name and <paramref name="callable"/>.</para>
    /// <para><b>Note:</b> In C#, <paramref name="signal"/> must be in snake_case when referring to built-in Godot signals. Prefer using the names exposed in the <c>SignalName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public bool IsConnected(StringName signal, Callable callable)
    {
        return NativeCalls.godot_icall_2_921(MethodBind35, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default), callable).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasConnections, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if any connection exists on the given <paramref name="signal"/> name.</para>
    /// <para><b>Note:</b> In C#, <paramref name="signal"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>SignalName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public bool HasConnections(StringName signal)
    {
        return NativeCalls.godot_icall_1_105(MethodBind36, GodotObject.GetPtr(this), (godot_string_name)(signal?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlockSignals, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, the object becomes unable to emit signals. As such, <see cref="Godot.GodotObject.EmitSignal(StringName, Variant[])"/> and signal connections will not work, until it is set to <see langword="false"/>.</para>
    /// </summary>
    public void SetBlockSignals(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBlockingSignals, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the object is blocking its signals from being emitted. See <see cref="Godot.GodotObject.SetBlockSignals(bool)"/>.</para>
    /// </summary>
    public bool IsBlockingSignals()
    {
        return NativeCalls.godot_icall_0_15(MethodBind38, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyPropertyListChanged, 3218959716ul);

    /// <summary>
    /// <para>Emits the <see cref="Godot.GodotObject.PropertyListChanged"/> signal. This is mainly used to refresh the editor, so that the Inspector and editor plugins are properly updated.</para>
    /// </summary>
    public void NotifyPropertyListChanged()
    {
        NativeCalls.godot_icall_0_3(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMessageTranslation, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, allows the object to translate messages with <see cref="Godot.GodotObject.Tr(StringName, StringName)"/> and <see cref="Godot.GodotObject.TrN(StringName, StringName, int, StringName)"/>. Enabled by default. See also <see cref="Godot.GodotObject.CanTranslateMessages()"/>.</para>
    /// </summary>
    public void SetMessageTranslation(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanTranslateMessages, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the object is allowed to translate messages with <see cref="Godot.GodotObject.Tr(StringName, StringName)"/> and <see cref="Godot.GodotObject.TrN(StringName, StringName, int, StringName)"/>. See also <see cref="Godot.GodotObject.SetMessageTranslation(bool)"/>.</para>
    /// </summary>
    public bool CanTranslateMessages()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Tr, 1195764410ul);

    /// <summary>
    /// <para>Translates a <paramref name="message"/>, using the translation catalogs configured in the Project Settings. Further <paramref name="context"/> can be specified to help with the translation. Note that most <see cref="Godot.Control"/> nodes automatically translate their strings, so this method is mostly useful for formatted strings or custom drawn text.</para>
    /// <para>If <see cref="Godot.GodotObject.CanTranslateMessages()"/> is <see langword="false"/>, or no translation is available, this method returns the <paramref name="message"/> without changes. See <see cref="Godot.GodotObject.SetMessageTranslation(bool)"/>.</para>
    /// <para>For detailed examples, see <a href="$DOCS_URL/tutorials/i18n/internationalizing_games.html">Internationalizing games</a>.</para>
    /// <para><b>Note:</b> This method can't be used without an <see cref="Godot.GodotObject"/> instance, as it requires the <see cref="Godot.GodotObject.CanTranslateMessages()"/> method. To translate strings in a static context, use <see cref="Godot.TranslationServer.Translate(StringName, StringName)"/>.</para>
    /// </summary>
    public string Tr(StringName message, StringName context = null)
    {
        return NativeCalls.godot_icall_2_922(MethodBind42, GodotObject.GetPtr(this), (godot_string_name)(message?.NativeValue ?? default), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrN, 162698058ul);

    /// <summary>
    /// <para>Translates a <paramref name="message"/> or <paramref name="pluralMessage"/>, using the translation catalogs configured in the Project Settings. Further <paramref name="context"/> can be specified to help with the translation.</para>
    /// <para>If <see cref="Godot.GodotObject.CanTranslateMessages()"/> is <see langword="false"/>, or no translation is available, this method returns <paramref name="message"/> or <paramref name="pluralMessage"/>, without changes. See <see cref="Godot.GodotObject.SetMessageTranslation(bool)"/>.</para>
    /// <para>The <paramref name="n"/> is the number, or amount, of the message's subject. It is used by the translation system to fetch the correct plural form for the current language.</para>
    /// <para>For detailed examples, see <a href="$DOCS_URL/tutorials/i18n/localization_using_gettext.html">Localization using gettext</a>.</para>
    /// <para><b>Note:</b> Negative and <see cref="float"/> numbers may not properly apply to some countable subjects. It's recommended to handle these cases with <see cref="Godot.GodotObject.Tr(StringName, StringName)"/>.</para>
    /// <para><b>Note:</b> This method can't be used without an <see cref="Godot.GodotObject"/> instance, as it requires the <see cref="Godot.GodotObject.CanTranslateMessages()"/> method. To translate strings in a static context, use <see cref="Godot.TranslationServer.TranslatePlural(StringName, StringName, int, StringName)"/>.</para>
    /// </summary>
    public string TrN(StringName message, StringName pluralMessage, int n, StringName context = null)
    {
        return NativeCalls.godot_icall_4_923(MethodBind43, GodotObject.GetPtr(this), (godot_string_name)(message?.NativeValue ?? default), (godot_string_name)(pluralMessage?.NativeValue ?? default), n, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranslationDomain, 2002593661ul);

    /// <summary>
    /// <para>Returns the name of the translation domain used by <see cref="Godot.GodotObject.Tr(StringName, StringName)"/> and <see cref="Godot.GodotObject.TrN(StringName, StringName, int, StringName)"/>. See also <see cref="Godot.TranslationServer"/>.</para>
    /// </summary>
    public StringName GetTranslationDomain()
    {
        return NativeCalls.godot_icall_0_65(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTranslationDomain, 3304788590ul);

    /// <summary>
    /// <para>Sets the name of the translation domain used by <see cref="Godot.GodotObject.Tr(StringName, StringName)"/> and <see cref="Godot.GodotObject.TrN(StringName, StringName, int, StringName)"/>. See also <see cref="Godot.TranslationServer"/>.</para>
    /// </summary>
    public void SetTranslationDomain(StringName domain)
    {
        NativeCalls.godot_icall_1_64(MethodBind45, GodotObject.GetPtr(this), (godot_string_name)(domain?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsQueuedForDeletion, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.Node.QueueFree()"/> method was called for the object.</para>
    /// </summary>
    public bool IsQueuedForDeletion()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CancelFree, 3218959716ul);

    /// <summary>
    /// <para>If this method is called during <see cref="Godot.GodotObject.NotificationPredelete"/>, this object will reject being freed and will remain allocated. This is mostly an internal function used for error handling to avoid the user from freeing objects when they are not intended to.</para>
    /// </summary>
    public void CancelFree()
    {
        NativeCalls.godot_icall_0_3(MethodBind47, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the object's script is changed.</para>
    /// <para><b>Note:</b> When this signal is emitted, the new script is not initialized yet. If you need to access the new script, defer connections to this signal with <see cref="Godot.GodotObject.ConnectFlags.Deferred"/>.</para>
    /// </summary>
    public event Action ScriptChanged
    {
        add => Connect(SignalName.ScriptChanged, Callable.From(value));
        remove => Disconnect(SignalName.ScriptChanged, Callable.From(value));
    }

    protected void EmitSignalScriptChanged()
    {
        EmitSignal(SignalName.ScriptChanged);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.GodotObject.NotifyPropertyListChanged()"/> is called.</para>
    /// </summary>
    public event Action PropertyListChanged
    {
        add => Connect(SignalName.PropertyListChanged, Callable.From(value));
        remove => Disconnect(SignalName.PropertyListChanged, Callable.From(value));
    }

    protected void EmitSignalPropertyListChanged()
    {
        EmitSignal(SignalName.PropertyListChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get = "_Get";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_property_list = "_GetPropertyList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__iter_get = "_IterGet";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__iter_init = "_IterInit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__iter_next = "_IterNext";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__notification = "_Notification";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__property_can_revert = "_PropertyCanRevert";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__property_get_revert = "_PropertyGetRevert";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set = "_Set";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__validate_property = "_ValidateProperty";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_script_changed = "ScriptChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_property_list_changed = "PropertyListChanged";

    /// <summary>
    /// Invokes the method with the given name, using the given arguments.
    /// This method is used by Godot to invoke methods from the engine side.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to invoke.</param>
    /// <param name="args">Arguments to use with the invoked method.</param>
    /// <param name="ret">Value returned by the invoked method.</param>
#pragma warning disable CS0618 // Member is obsolete
    protected internal virtual bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        if ((method == MethodProxyName__get || method == MethodName._Get) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get.NativeValue))
        {
            var callRet = _Get(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_property_list || method == MethodName._GetPropertyList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_property_list.NativeValue))
        {
            var callRet = _GetPropertyList();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__iter_get || method == MethodName._IterGet) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__iter_get.NativeValue))
        {
            var callRet = _IterGet(VariantUtils.ConvertTo<Variant>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__iter_init || method == MethodName._IterInit) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__iter_init.NativeValue))
        {
            var callRet = _IterInit(VariantUtils.ConvertTo<Godot.Collections.Array>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__iter_next || method == MethodName._IterNext) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__iter_next.NativeValue))
        {
            var callRet = _IterNext(VariantUtils.ConvertTo<Godot.Collections.Array>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__notification || method == MethodName._Notification) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__notification.NativeValue))
        {
            _Notification(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__property_can_revert || method == MethodName._PropertyCanRevert) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__property_can_revert.NativeValue))
        {
            var callRet = _PropertyCanRevert(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__property_get_revert || method == MethodName._PropertyGetRevert) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__property_get_revert.NativeValue))
        {
            var callRet = _PropertyGetRevert(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set || method == MethodName._Set) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__set.NativeValue))
        {
            var callRet = _Set(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__validate_property || method == MethodName._ValidateProperty) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__validate_property.NativeValue))
        {
            _ValidateProperty(VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[0]));
            ret = default;
            return true;
        }
        ret = default;
        return false;
    }
#pragma warning restore CS0618

    /// <summary>
    /// Check if the type contains a method with the given name.
    /// This method is used by Godot to check if a method exists before invoking it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to check for.</param>

    protected internal virtual bool HasGodotClassMethod(in godot_string_name method)
    {
        if (method == MethodName._Get)
        {
            if (HasGodotClassMethod(MethodProxyName__get.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPropertyList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_property_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IterGet)
        {
            if (HasGodotClassMethod(MethodProxyName__iter_get.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IterInit)
        {
            if (HasGodotClassMethod(MethodProxyName__iter_init.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IterNext)
        {
            if (HasGodotClassMethod(MethodProxyName__iter_next.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Notification)
        {
            if (HasGodotClassMethod(MethodProxyName__notification.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PropertyCanRevert)
        {
            if (HasGodotClassMethod(MethodProxyName__property_can_revert.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PropertyGetRevert)
        {
            if (HasGodotClassMethod(MethodProxyName__property_get_revert.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Set)
        {
            if (HasGodotClassMethod(MethodProxyName__set.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ValidateProperty)
        {
            if (HasGodotClassMethod(MethodProxyName__validate_property.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Check if the type contains a signal with the given name.
    /// This method is used by Godot to check if a signal exists before raising it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="signal">Name of the signal to check for.</param>

    protected internal virtual bool HasGodotClassSignal(in godot_string_name signal)
    {
        if (signal == SignalName.ScriptChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_script_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PropertyListChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_property_list_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the '_get' method.
        /// </summary>
        public static readonly StringName _Get = "_get";
        /// <summary>
        /// Cached name for the '_get_property_list' method.
        /// </summary>
        public static readonly StringName _GetPropertyList = "_get_property_list";
        /// <summary>
        /// Cached name for the '_iter_get' method.
        /// </summary>
        public static readonly StringName _IterGet = "_iter_get";
        /// <summary>
        /// Cached name for the '_iter_init' method.
        /// </summary>
        public static readonly StringName _IterInit = "_iter_init";
        /// <summary>
        /// Cached name for the '_iter_next' method.
        /// </summary>
        public static readonly StringName _IterNext = "_iter_next";
        /// <summary>
        /// Cached name for the '_notification' method.
        /// </summary>
        public static readonly StringName _Notification = "_notification";
        /// <summary>
        /// Cached name for the '_property_can_revert' method.
        /// </summary>
        public static readonly StringName _PropertyCanRevert = "_property_can_revert";
        /// <summary>
        /// Cached name for the '_property_get_revert' method.
        /// </summary>
        public static readonly StringName _PropertyGetRevert = "_property_get_revert";
        /// <summary>
        /// Cached name for the '_set' method.
        /// </summary>
        public static readonly StringName _Set = "_set";
        /// <summary>
        /// Cached name for the '_validate_property' method.
        /// </summary>
        public static readonly StringName _ValidateProperty = "_validate_property";
        /// <summary>
        /// Cached name for the 'free' method.
        /// </summary>
        public static readonly StringName Free = "free";
        /// <summary>
        /// Cached name for the 'get_class' method.
        /// </summary>
        public static readonly StringName GetClass = "get_class";
        /// <summary>
        /// Cached name for the 'is_class' method.
        /// </summary>
        public static readonly StringName IsClass = "is_class";
        /// <summary>
        /// Cached name for the 'set' method.
        /// </summary>
        public static readonly StringName Set = "set";
        /// <summary>
        /// Cached name for the 'get' method.
        /// </summary>
        public static readonly StringName Get = "get";
        /// <summary>
        /// Cached name for the 'set_indexed' method.
        /// </summary>
        public static readonly StringName SetIndexed = "set_indexed";
        /// <summary>
        /// Cached name for the 'get_indexed' method.
        /// </summary>
        public static readonly StringName GetIndexed = "get_indexed";
        /// <summary>
        /// Cached name for the 'get_property_list' method.
        /// </summary>
        public static readonly StringName GetPropertyList = "get_property_list";
        /// <summary>
        /// Cached name for the 'get_method_list' method.
        /// </summary>
        public static readonly StringName GetMethodList = "get_method_list";
        /// <summary>
        /// Cached name for the 'property_can_revert' method.
        /// </summary>
        public static readonly StringName PropertyCanRevert = "property_can_revert";
        /// <summary>
        /// Cached name for the 'property_get_revert' method.
        /// </summary>
        public static readonly StringName PropertyGetRevert = "property_get_revert";
        /// <summary>
        /// Cached name for the 'notification' method.
        /// </summary>
        public static readonly StringName Notification = "notification";
        /// <summary>
        /// Cached name for the 'get_instance_id' method.
        /// </summary>
        public static readonly StringName GetInstanceId = "get_instance_id";
        /// <summary>
        /// Cached name for the 'set_script' method.
        /// </summary>
        public static readonly StringName SetScript = "set_script";
        /// <summary>
        /// Cached name for the 'get_script' method.
        /// </summary>
        public static readonly StringName GetScript = "get_script";
        /// <summary>
        /// Cached name for the 'set_meta' method.
        /// </summary>
        public static readonly StringName SetMeta = "set_meta";
        /// <summary>
        /// Cached name for the 'remove_meta' method.
        /// </summary>
        public static readonly StringName RemoveMeta = "remove_meta";
        /// <summary>
        /// Cached name for the 'get_meta' method.
        /// </summary>
        public static readonly StringName GetMeta = "get_meta";
        /// <summary>
        /// Cached name for the 'has_meta' method.
        /// </summary>
        public static readonly StringName HasMeta = "has_meta";
        /// <summary>
        /// Cached name for the 'get_meta_list' method.
        /// </summary>
        public static readonly StringName GetMetaList = "get_meta_list";
        /// <summary>
        /// Cached name for the 'add_user_signal' method.
        /// </summary>
        public static readonly StringName AddUserSignal = "add_user_signal";
        /// <summary>
        /// Cached name for the 'has_user_signal' method.
        /// </summary>
        public static readonly StringName HasUserSignal = "has_user_signal";
        /// <summary>
        /// Cached name for the 'remove_user_signal' method.
        /// </summary>
        public static readonly StringName RemoveUserSignal = "remove_user_signal";
        /// <summary>
        /// Cached name for the 'emit_signal' method.
        /// </summary>
        public static readonly StringName EmitSignal = "emit_signal";
        /// <summary>
        /// Cached name for the 'call' method.
        /// </summary>
        public static readonly StringName Call = "call";
        /// <summary>
        /// Cached name for the 'call_deferred' method.
        /// </summary>
        public static readonly StringName CallDeferred = "call_deferred";
        /// <summary>
        /// Cached name for the 'set_deferred' method.
        /// </summary>
        public static readonly StringName SetDeferred = "set_deferred";
        /// <summary>
        /// Cached name for the 'callv' method.
        /// </summary>
        public static readonly StringName Callv = "callv";
        /// <summary>
        /// Cached name for the 'has_method' method.
        /// </summary>
        public static readonly StringName HasMethod = "has_method";
        /// <summary>
        /// Cached name for the 'get_method_argument_count' method.
        /// </summary>
        public static readonly StringName GetMethodArgumentCount = "get_method_argument_count";
        /// <summary>
        /// Cached name for the 'has_signal' method.
        /// </summary>
        public static readonly StringName HasSignal = "has_signal";
        /// <summary>
        /// Cached name for the 'get_signal_list' method.
        /// </summary>
        public static readonly StringName GetSignalList = "get_signal_list";
        /// <summary>
        /// Cached name for the 'get_signal_connection_list' method.
        /// </summary>
        public static readonly StringName GetSignalConnectionList = "get_signal_connection_list";
        /// <summary>
        /// Cached name for the 'get_incoming_connections' method.
        /// </summary>
        public static readonly StringName GetIncomingConnections = "get_incoming_connections";
        /// <summary>
        /// Cached name for the 'connect' method.
        /// </summary>
        public static readonly StringName Connect = "connect";
        /// <summary>
        /// Cached name for the 'disconnect' method.
        /// </summary>
        public static readonly StringName Disconnect = "disconnect";
        /// <summary>
        /// Cached name for the 'is_connected' method.
        /// </summary>
        public static readonly StringName IsConnected = "is_connected";
        /// <summary>
        /// Cached name for the 'has_connections' method.
        /// </summary>
        public static readonly StringName HasConnections = "has_connections";
        /// <summary>
        /// Cached name for the 'set_block_signals' method.
        /// </summary>
        public static readonly StringName SetBlockSignals = "set_block_signals";
        /// <summary>
        /// Cached name for the 'is_blocking_signals' method.
        /// </summary>
        public static readonly StringName IsBlockingSignals = "is_blocking_signals";
        /// <summary>
        /// Cached name for the 'notify_property_list_changed' method.
        /// </summary>
        public static readonly StringName NotifyPropertyListChanged = "notify_property_list_changed";
        /// <summary>
        /// Cached name for the 'set_message_translation' method.
        /// </summary>
        public static readonly StringName SetMessageTranslation = "set_message_translation";
        /// <summary>
        /// Cached name for the 'can_translate_messages' method.
        /// </summary>
        public static readonly StringName CanTranslateMessages = "can_translate_messages";
        /// <summary>
        /// Cached name for the 'tr' method.
        /// </summary>
        public static readonly StringName Tr = "tr";
        /// <summary>
        /// Cached name for the 'tr_n' method.
        /// </summary>
        public static readonly StringName TrN = "tr_n";
        /// <summary>
        /// Cached name for the 'get_translation_domain' method.
        /// </summary>
        public static readonly StringName GetTranslationDomain = "get_translation_domain";
        /// <summary>
        /// Cached name for the 'set_translation_domain' method.
        /// </summary>
        public static readonly StringName SetTranslationDomain = "set_translation_domain";
        /// <summary>
        /// Cached name for the 'is_queued_for_deletion' method.
        /// </summary>
        public static readonly StringName IsQueuedForDeletion = "is_queued_for_deletion";
        /// <summary>
        /// Cached name for the 'cancel_free' method.
        /// </summary>
        public static readonly StringName CancelFree = "cancel_free";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'script_changed' signal.
        /// </summary>
        public static readonly StringName ScriptChanged = "script_changed";
        /// <summary>
        /// Cached name for the 'property_list_changed' signal.
        /// </summary>
        public static readonly StringName PropertyListChanged = "property_list_changed";
    }
}

namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base resource for <see cref="Godot.AnimationTree"/> nodes. In general, it's not used directly, but you can create custom ones with custom blending formulas.</para>
/// <para>Inherit this when creating animation nodes mainly for use in <see cref="Godot.AnimationNodeBlendTree"/>, otherwise <see cref="Godot.AnimationRootNode"/> should be used instead.</para>
/// <para>You can access the time information as read-only parameter which is processed and stored in the previous frame for all nodes except <see cref="Godot.AnimationNodeOutput"/>.</para>
/// <para><b>Note:</b> If multiple inputs exist in the <see cref="Godot.AnimationNode"/>, which time information takes precedence depends on the type of <see cref="Godot.AnimationNode"/>.</para>
/// <para><code>
/// var current_length = $AnimationTree["parameters/AnimationNodeName/current_length"]
/// var current_position = $AnimationTree["parameters/AnimationNodeName/current_position"]
/// var current_delta = $AnimationTree["parameters/AnimationNodeName/current_delta"]
/// </code></para>
/// </summary>
public partial class AnimationNode : Resource
{
    public enum FilterAction : long
    {
        /// <summary>
        /// <para>Do not use filtering.</para>
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// <para>Paths matching the filter will be allowed to pass.</para>
        /// </summary>
        Pass = 1,
        /// <summary>
        /// <para>Paths matching the filter will be discarded.</para>
        /// </summary>
        Stop = 2,
        /// <summary>
        /// <para>Paths matching the filter will be blended (by the blend value).</para>
        /// </summary>
        Blend = 3
    }

    /// <summary>
    /// <para>If <see langword="true"/>, filtering is enabled.</para>
    /// </summary>
    public bool FilterEnabled
    {
        get
        {
            return IsFilterEnabled();
        }
        set
        {
            SetFilterEnabled(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array Filters
    {
        get
        {
            return _GetFilters();
        }
        set
        {
            _SetFilters(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(AnimationNode);

    private static readonly StringName NativeName = "AnimationNode";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNode() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNode(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNode(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to override the text caption for this animation node.</para>
    /// </summary>
    public virtual string _GetCaption()
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to return a child animation node by its <paramref name="name"/>.</para>
    /// </summary>
    public virtual AnimationNode _GetChildByName(StringName name)
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to return all child animation nodes in order as a <c>name: node</c> dictionary.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _GetChildNodes()
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to return the default value of a <paramref name="parameter"/>. Parameters are custom local memory used for your animation nodes, given a resource can be reused in multiple trees.</para>
    /// </summary>
    public virtual Variant _GetParameterDefaultValue(StringName parameter)
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to return a list of the properties on this animation node. Parameters are custom local memory used for your animation nodes, given a resource can be reused in multiple trees. Format is similar to <see cref="Godot.GodotObject.GetPropertyList()"/>.</para>
    /// </summary>
    public virtual Godot.Collections.Array _GetParameterList()
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to return whether the blend tree editor should display filter editing on this animation node.</para>
    /// </summary>
    public virtual bool _HasFilter()
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to return whether the <paramref name="parameter"/> is read-only. Parameters are custom local memory used for your animation nodes, given a resource can be reused in multiple trees.</para>
    /// </summary>
    public virtual bool _IsParameterReadOnly(StringName parameter)
    {
        return default;
    }

    /// <summary>
    /// <para>When inheriting from <see cref="Godot.AnimationRootNode"/>, implement this virtual method to run some code when this animation node is processed. The <paramref name="time"/> parameter is a relative delta, unless <paramref name="seek"/> is <see langword="true"/>, in which case it is absolute.</para>
    /// <para>Here, call the <see cref="Godot.AnimationNode.BlendInput(int, double, bool, bool, float, AnimationNode.FilterAction, bool, bool)"/>, <see cref="Godot.AnimationNode.BlendNode(StringName, AnimationNode, double, bool, bool, float, AnimationNode.FilterAction, bool, bool)"/> or <see cref="Godot.AnimationNode.BlendAnimation(StringName, double, double, bool, bool, float, Animation.LoopedFlag)"/> functions. You can also use <see cref="Godot.AnimationNode.GetParameter(StringName)"/> and <see cref="Godot.AnimationNode.SetParameter(StringName, Variant)"/> to modify local memory.</para>
    /// <para>This function should return the delta.</para>
    /// </summary>
    [Obsolete("Currently this is mostly useless as there is a lack of many APIs to extend AnimationNode by GDScript. It is planned that a more flexible API using structures will be provided in the future.")]
    public virtual double _Process(double time, bool seek, bool isExternalSeeking, bool testOnly)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInput, 2323990056ul);

    /// <summary>
    /// <para>Adds an input to the animation node. This is only useful for animation nodes created for use in an <see cref="Godot.AnimationNodeBlendTree"/>. If the addition fails, returns <see langword="false"/>.</para>
    /// </summary>
    public bool AddInput(string name)
    {
        return NativeCalls.godot_icall_1_131(MethodBind0, GodotObject.GetPtr(this), name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInput, 1286410249ul);

    /// <summary>
    /// <para>Removes an input, call this only when inactive.</para>
    /// </summary>
    public void RemoveInput(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputName, 215573526ul);

    /// <summary>
    /// <para>Sets the name of the input at the given <paramref name="input"/> index. If the setting fails, returns <see langword="false"/>.</para>
    /// </summary>
    public bool SetInputName(int input, string name)
    {
        return NativeCalls.godot_icall_2_132(MethodBind2, GodotObject.GetPtr(this), input, name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputName, 844755477ul);

    /// <summary>
    /// <para>Gets the name of an input by index.</para>
    /// </summary>
    public string GetInputName(int input)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), input);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputCount, 3905245786ul);

    /// <summary>
    /// <para>Amount of inputs in this animation node, only useful for animation nodes that go into <see cref="Godot.AnimationNodeBlendTree"/>.</para>
    /// </summary>
    public int GetInputCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindInput, 1321353865ul);

    /// <summary>
    /// <para>Returns the input index which corresponds to <paramref name="name"/>. If not found, returns <c>-1</c>.</para>
    /// </summary>
    public int FindInput(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind5, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterPath, 3868023870ul);

    /// <summary>
    /// <para>Adds or removes a path for the filter.</para>
    /// </summary>
    public void SetFilterPath(NodePath path, bool enable)
    {
        NativeCalls.godot_icall_2_135(MethodBind6, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPathFiltered, 861721659ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given path is filtered.</para>
    /// </summary>
    public bool IsPathFiltered(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind7, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFilterEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFilterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFilterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessingAnimationTreeInstanceId, 3905245786ul);

    /// <summary>
    /// <para>Returns the object id of the <see cref="Godot.AnimationTree"/> that owns this node.</para>
    /// <para><b>Note:</b> This method should only be called from within the <see cref="Godot.AnimationNodeExtension._ProcessAnimationNode(double[], bool)"/> method, and will return an invalid id otherwise.</para>
    /// </summary>
    public ulong GetProcessingAnimationTreeInstanceId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessTesting, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this animation node is being processed in test-only mode.</para>
    /// </summary>
    public bool IsProcessTesting()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetFilters, 381264803ul);

    internal void _SetFilters(Godot.Collections.Array filters)
    {
        NativeCalls.godot_icall_1_138(MethodBind12, GodotObject.GetPtr(this), (godot_array)(filters ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetFilters, 3995934104ul);

    internal Godot.Collections.Array _GetFilters()
    {
        return NativeCalls.godot_icall_0_120(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendAnimation, 1630801826ul);

    /// <summary>
    /// <para>Blends an animation by <paramref name="blend"/> amount (name must be valid in the linked <see cref="Godot.AnimationPlayer"/>). A <paramref name="time"/> and <paramref name="delta"/> may be passed, as well as whether <paramref name="seeked"/> happened.</para>
    /// <para>A <paramref name="loopedFlag"/> is used by internal processing immediately after the loop.</para>
    /// </summary>
    public void BlendAnimation(StringName animation, double time, double delta, bool seeked, bool isExternalSeeking, float blend, Animation.LoopedFlag loopedFlag = (Animation.LoopedFlag)(0))
    {
        NativeCalls.godot_icall_7_139(MethodBind14, GodotObject.GetPtr(this), (godot_string_name)(animation?.NativeValue ?? default), time, delta, seeked.ToGodotBool(), isExternalSeeking.ToGodotBool(), blend, (int)loopedFlag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendNode, 1746075988ul);

    /// <summary>
    /// <para>Blend another animation node (in case this animation node contains child animation nodes). This function is only useful if you inherit from <see cref="Godot.AnimationRootNode"/> instead, otherwise editors will not display your animation node for addition.</para>
    /// </summary>
    public double BlendNode(StringName name, AnimationNode node, double time, bool seek, bool isExternalSeeking, float blend, AnimationNode.FilterAction filter = (AnimationNode.FilterAction)(0), bool sync = true, bool testOnly = false)
    {
        return NativeCalls.godot_icall_9_140(MethodBind15, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(node), time, seek.ToGodotBool(), isExternalSeeking.ToGodotBool(), blend, (int)filter, sync.ToGodotBool(), testOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendInput, 1361527350ul);

    /// <summary>
    /// <para>Blends an input. This is only useful for animation nodes created for an <see cref="Godot.AnimationNodeBlendTree"/>. The <paramref name="time"/> parameter is a relative delta, unless <paramref name="seek"/> is <see langword="true"/>, in which case it is absolute. A filter mode may be optionally passed.</para>
    /// </summary>
    public double BlendInput(int inputIndex, double time, bool seek, bool isExternalSeeking, float blend, AnimationNode.FilterAction filter = (AnimationNode.FilterAction)(0), bool sync = true, bool testOnly = false)
    {
        return NativeCalls.godot_icall_8_141(MethodBind16, GodotObject.GetPtr(this), inputIndex, time, seek.ToGodotBool(), isExternalSeeking.ToGodotBool(), blend, (int)filter, sync.ToGodotBool(), testOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParameter, 3776071444ul);

    /// <summary>
    /// <para>Sets a custom parameter. These are used as local memory, because resources can be reused across the tree or scenes.</para>
    /// </summary>
    public void SetParameter(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParameter, 2760726917ul);

    /// <summary>
    /// <para>Gets the value of a parameter. Parameters are custom local memory used for your animation nodes, given a resource can be reused in multiple trees.</para>
    /// </summary>
    public Variant GetParameter(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind18, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    /// <summary>
    /// <para>Emitted by nodes that inherit from this class and that have an internal tree when one of their animation nodes changes. The animation nodes that emit this signal are <see cref="Godot.AnimationNodeBlendSpace1D"/>, <see cref="Godot.AnimationNodeBlendSpace2D"/>, <see cref="Godot.AnimationNodeStateMachine"/>, <see cref="Godot.AnimationNodeBlendTree"/> and <see cref="Godot.AnimationNodeTransition"/>.</para>
    /// </summary>
    public event Action TreeChanged
    {
        add => Connect(SignalName.TreeChanged, Callable.From(value));
        remove => Disconnect(SignalName.TreeChanged, Callable.From(value));
    }

    protected void EmitSignalTreeChanged()
    {
        EmitSignal(SignalName.TreeChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationNode.AnimationNodeRenamed"/> event of a <see cref="Godot.AnimationNode"/> class.
    /// </summary>
    public delegate void AnimationNodeRenamedEventHandler(long objectId, string oldName, string newName);

    private static void AnimationNodeRenamedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((AnimationNodeRenamedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted by nodes that inherit from this class and that have an internal tree when one of their animation node names changes. The animation nodes that emit this signal are <see cref="Godot.AnimationNodeBlendSpace1D"/>, <see cref="Godot.AnimationNodeBlendSpace2D"/>, <see cref="Godot.AnimationNodeStateMachine"/>, and <see cref="Godot.AnimationNodeBlendTree"/>.</para>
    /// </summary>
    public unsafe event AnimationNodeRenamedEventHandler AnimationNodeRenamed
    {
        add => Connect(SignalName.AnimationNodeRenamed, Callable.CreateWithUnsafeTrampoline(value, &AnimationNodeRenamedTrampoline));
        remove => Disconnect(SignalName.AnimationNodeRenamed, Callable.CreateWithUnsafeTrampoline(value, &AnimationNodeRenamedTrampoline));
    }

    protected void EmitSignalAnimationNodeRenamed(long objectId, string oldName, string newName)
    {
        EmitSignal(SignalName.AnimationNodeRenamed, objectId, oldName, newName);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationNode.AnimationNodeRemoved"/> event of a <see cref="Godot.AnimationNode"/> class.
    /// </summary>
    public delegate void AnimationNodeRemovedEventHandler(long objectId, string name);

    private static void AnimationNodeRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((AnimationNodeRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted by nodes that inherit from this class and that have an internal tree when one of their animation nodes removes. The animation nodes that emit this signal are <see cref="Godot.AnimationNodeBlendSpace1D"/>, <see cref="Godot.AnimationNodeBlendSpace2D"/>, <see cref="Godot.AnimationNodeStateMachine"/>, and <see cref="Godot.AnimationNodeBlendTree"/>.</para>
    /// </summary>
    public unsafe event AnimationNodeRemovedEventHandler AnimationNodeRemoved
    {
        add => Connect(SignalName.AnimationNodeRemoved, Callable.CreateWithUnsafeTrampoline(value, &AnimationNodeRemovedTrampoline));
        remove => Disconnect(SignalName.AnimationNodeRemoved, Callable.CreateWithUnsafeTrampoline(value, &AnimationNodeRemovedTrampoline));
    }

    protected void EmitSignalAnimationNodeRemoved(long objectId, string name)
    {
        EmitSignal(SignalName.AnimationNodeRemoved, objectId, name);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_caption = "_GetCaption";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_child_by_name = "_GetChildByName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_child_nodes = "_GetChildNodes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_parameter_default_value = "_GetParameterDefaultValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_parameter_list = "_GetParameterList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_filter = "_HasFilter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_parameter_read_only = "_IsParameterReadOnly";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__process = "_Process";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tree_changed = "TreeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_node_renamed = "AnimationNodeRenamed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_node_removed = "AnimationNodeRemoved";

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
        if ((method == MethodProxyName__get_caption || method == MethodName._GetCaption) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_caption.NativeValue))
        {
            var callRet = _GetCaption();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_child_by_name || method == MethodName._GetChildByName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_child_by_name.NativeValue))
        {
            var callRet = _GetChildByName(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<AnimationNode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_child_nodes || method == MethodName._GetChildNodes) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_child_nodes.NativeValue))
        {
            var callRet = _GetChildNodes();
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_parameter_default_value || method == MethodName._GetParameterDefaultValue) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_parameter_default_value.NativeValue))
        {
            var callRet = _GetParameterDefaultValue(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_parameter_list || method == MethodName._GetParameterList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_parameter_list.NativeValue))
        {
            var callRet = _GetParameterList();
            ret = VariantUtils.CreateFrom<Godot.Collections.Array>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_filter || method == MethodName._HasFilter) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_filter.NativeValue))
        {
            var callRet = _HasFilter();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_parameter_read_only || method == MethodName._IsParameterReadOnly) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_parameter_read_only.NativeValue))
        {
            var callRet = _IsParameterReadOnly(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__process || method == MethodName._Process) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__process.NativeValue))
        {
            var callRet = _Process(VariantUtils.ConvertTo<double>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = VariantUtils.CreateFrom<double>(callRet);
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
        if (method == MethodName._GetCaption)
        {
            if (HasGodotClassMethod(MethodProxyName__get_caption.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetChildByName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_child_by_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetChildNodes)
        {
            if (HasGodotClassMethod(MethodProxyName__get_child_nodes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetParameterDefaultValue)
        {
            if (HasGodotClassMethod(MethodProxyName__get_parameter_default_value.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetParameterList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_parameter_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasFilter)
        {
            if (HasGodotClassMethod(MethodProxyName__has_filter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsParameterReadOnly)
        {
            if (HasGodotClassMethod(MethodProxyName__is_parameter_read_only.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Process)
        {
            if (HasGodotClassMethod(MethodProxyName__process.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.TreeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_tree_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationNodeRenamed)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_node_renamed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationNodeRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_node_removed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'filter_enabled' property.
        /// </summary>
        public static readonly StringName FilterEnabled = "filter_enabled";
        /// <summary>
        /// Cached name for the 'filters' property.
        /// </summary>
        public static readonly StringName Filters = "filters";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_caption' method.
        /// </summary>
        public static readonly StringName _GetCaption = "_get_caption";
        /// <summary>
        /// Cached name for the '_get_child_by_name' method.
        /// </summary>
        public static readonly StringName _GetChildByName = "_get_child_by_name";
        /// <summary>
        /// Cached name for the '_get_child_nodes' method.
        /// </summary>
        public static readonly StringName _GetChildNodes = "_get_child_nodes";
        /// <summary>
        /// Cached name for the '_get_parameter_default_value' method.
        /// </summary>
        public static readonly StringName _GetParameterDefaultValue = "_get_parameter_default_value";
        /// <summary>
        /// Cached name for the '_get_parameter_list' method.
        /// </summary>
        public static readonly StringName _GetParameterList = "_get_parameter_list";
        /// <summary>
        /// Cached name for the '_has_filter' method.
        /// </summary>
        public static readonly StringName _HasFilter = "_has_filter";
        /// <summary>
        /// Cached name for the '_is_parameter_read_only' method.
        /// </summary>
        public static readonly StringName _IsParameterReadOnly = "_is_parameter_read_only";
        /// <summary>
        /// Cached name for the '_process' method.
        /// </summary>
        public static readonly StringName _Process = "_process";
        /// <summary>
        /// Cached name for the 'add_input' method.
        /// </summary>
        public static readonly StringName AddInput = "add_input";
        /// <summary>
        /// Cached name for the 'remove_input' method.
        /// </summary>
        public static readonly StringName RemoveInput = "remove_input";
        /// <summary>
        /// Cached name for the 'set_input_name' method.
        /// </summary>
        public static readonly StringName SetInputName = "set_input_name";
        /// <summary>
        /// Cached name for the 'get_input_name' method.
        /// </summary>
        public static readonly StringName GetInputName = "get_input_name";
        /// <summary>
        /// Cached name for the 'get_input_count' method.
        /// </summary>
        public static readonly StringName GetInputCount = "get_input_count";
        /// <summary>
        /// Cached name for the 'find_input' method.
        /// </summary>
        public static readonly StringName FindInput = "find_input";
        /// <summary>
        /// Cached name for the 'set_filter_path' method.
        /// </summary>
        public static readonly StringName SetFilterPath = "set_filter_path";
        /// <summary>
        /// Cached name for the 'is_path_filtered' method.
        /// </summary>
        public static readonly StringName IsPathFiltered = "is_path_filtered";
        /// <summary>
        /// Cached name for the 'set_filter_enabled' method.
        /// </summary>
        public static readonly StringName SetFilterEnabled = "set_filter_enabled";
        /// <summary>
        /// Cached name for the 'is_filter_enabled' method.
        /// </summary>
        public static readonly StringName IsFilterEnabled = "is_filter_enabled";
        /// <summary>
        /// Cached name for the 'get_processing_animation_tree_instance_id' method.
        /// </summary>
        public static readonly StringName GetProcessingAnimationTreeInstanceId = "get_processing_animation_tree_instance_id";
        /// <summary>
        /// Cached name for the 'is_process_testing' method.
        /// </summary>
        public static readonly StringName IsProcessTesting = "is_process_testing";
        /// <summary>
        /// Cached name for the '_set_filters' method.
        /// </summary>
        public static readonly StringName _SetFilters = "_set_filters";
        /// <summary>
        /// Cached name for the '_get_filters' method.
        /// </summary>
        public static readonly StringName _GetFilters = "_get_filters";
        /// <summary>
        /// Cached name for the 'blend_animation' method.
        /// </summary>
        public static readonly StringName BlendAnimation = "blend_animation";
        /// <summary>
        /// Cached name for the 'blend_node' method.
        /// </summary>
        public static readonly StringName BlendNode = "blend_node";
        /// <summary>
        /// Cached name for the 'blend_input' method.
        /// </summary>
        public static readonly StringName BlendInput = "blend_input";
        /// <summary>
        /// Cached name for the 'set_parameter' method.
        /// </summary>
        public static readonly StringName SetParameter = "set_parameter";
        /// <summary>
        /// Cached name for the 'get_parameter' method.
        /// </summary>
        public static readonly StringName GetParameter = "get_parameter";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'tree_changed' signal.
        /// </summary>
        public static readonly StringName TreeChanged = "tree_changed";
        /// <summary>
        /// Cached name for the 'animation_node_renamed' signal.
        /// </summary>
        public static readonly StringName AnimationNodeRenamed = "animation_node_renamed";
        /// <summary>
        /// Cached name for the 'animation_node_removed' signal.
        /// </summary>
        public static readonly StringName AnimationNodeRemoved = "animation_node_removed";
    }
}

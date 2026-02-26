namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.GraphNode"/> allows to create nodes for a <see cref="Godot.GraphEdit"/> graph with customizable content based on its child controls. <see cref="Godot.GraphNode"/> is derived from <see cref="Godot.Container"/> and it is responsible for placing its children on screen. This works similar to <see cref="Godot.VBoxContainer"/>. Children, in turn, provide <see cref="Godot.GraphNode"/> with so-called slots, each of which can have a connection port on either side.</para>
/// <para>Each <see cref="Godot.GraphNode"/> slot is defined by its index and can provide the node with up to two ports: one on the left, and one on the right. By convention the left port is also referred to as the <b>input port</b> and the right port is referred to as the <b>output port</b>. Each port can be enabled and configured individually, using different type and color. The type is an arbitrary value that you can define using your own considerations. The parent <see cref="Godot.GraphEdit"/> will receive this information on each connect and disconnect request.</para>
/// <para>Slots can be configured in the Inspector dock once you add at least one child <see cref="Godot.Control"/>. The properties are grouped by each slot's index in the "Slot" section.</para>
/// <para><b>Note:</b> While GraphNode is set up using slots and slot indices, connections are made between the ports which are enabled. Because of that <see cref="Godot.GraphEdit"/> uses the port's index and not the slot's index. You can use <see cref="Godot.GraphNode.GetInputPortSlot(int)"/> and <see cref="Godot.GraphNode.GetOutputPortSlot(int)"/> to get the slot index from the port index.</para>
/// </summary>
public partial class GraphNode : GraphElement
{
    /// <summary>
    /// <para>The text displayed in the GraphNode's title bar.</para>
    /// </summary>
    public string Title
    {
        get
        {
            return GetTitle();
        }
        set
        {
            SetTitle(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, you can connect ports with different types, even if the connection was not explicitly allowed in the parent <see cref="Godot.GraphEdit"/>.</para>
    /// </summary>
    public bool IgnoreInvalidConnectionType
    {
        get
        {
            return IsIgnoringValidConnectionType();
        }
        set
        {
            SetIgnoreInvalidConnectionType(value);
        }
    }

    /// <summary>
    /// <para>Determines how connection slots can be focused.</para>
    /// <para>- If set to <see cref="Godot.Control.FocusModeEnum.Click"/>, connections can only be made with the mouse.</para>
    /// <para>- If set to <see cref="Godot.Control.FocusModeEnum.All"/>, slots can also be focused using the <c>ProjectSettings.input/ui_up</c> and <c>ProjectSettings.input/ui_down</c> and connected using <c>ProjectSettings.input/ui_left</c> and <c>ProjectSettings.input/ui_right</c> input actions.</para>
    /// <para>- If set to <see cref="Godot.Control.FocusModeEnum.Accessibility"/>, slot input actions are only enabled when the screen reader is active.</para>
    /// </summary>
    public Control.FocusModeEnum SlotsFocusMode
    {
        get
        {
            return GetSlotsFocusMode();
        }
        set
        {
            SetSlotsFocusMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GraphNode);

    private static readonly StringName NativeName = "GraphNode";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GraphNode() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphNode(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphNode(bool memoryOwn) : base(memoryOwn) { }

    public virtual unsafe void _DrawPort(int slotIndex, Vector2I position, bool left, Color color)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitle, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitle(string title)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitle, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTitle()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitlebarHBox, 3590609951ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.HBoxContainer"/> used for the title bar, only containing a <see cref="Godot.Label"/> for displaying the title by default. This can be used to add custom controls to the title bar such as option or close buttons.</para>
    /// </summary>
    public HBoxContainer GetTitlebarHBox()
    {
        return (HBoxContainer)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlot, 2873310869ul);

    /// <summary>
    /// <para>Sets properties of the slot with the given <paramref name="slotIndex"/>.</para>
    /// <para>If <paramref name="enableLeftPort"/>/<paramref name="enableRightPort"/> is <see langword="true"/>, a port will appear and the slot will be able to be connected from this side.</para>
    /// <para>With <paramref name="typeLeft"/>/<paramref name="typeRight"/> an arbitrary type can be assigned to each port. Two ports can be connected if they share the same type, or if the connection between their types is allowed in the parent <see cref="Godot.GraphEdit"/> (see <see cref="Godot.GraphEdit.AddValidConnectionType(int, int)"/>). Keep in mind that the <see cref="Godot.GraphEdit"/> has the final say in accepting the connection. Type compatibility simply allows the <see cref="Godot.GraphEdit.ConnectionRequest"/> signal to be emitted.</para>
    /// <para>Ports can be further customized using <paramref name="colorLeft"/>/<paramref name="colorRight"/> and <paramref name="customIconLeft"/>/<paramref name="customIconRight"/>. The color parameter adds a tint to the icon. The custom icon can be used to override the default port dot.</para>
    /// <para>Additionally, <paramref name="drawStylebox"/> can be used to enable or disable drawing of the background stylebox for each slot. See <c>slot</c>.</para>
    /// <para>Individual properties can also be set using one of the <c>set_slot_*</c> methods.</para>
    /// <para><b>Note:</b> This method only sets properties of the slot. To create the slot itself, add a <see cref="Godot.Control"/>-derived child to the GraphNode.</para>
    /// </summary>
    public unsafe void SetSlot(int slotIndex, bool enableLeftPort, int typeLeft, Color colorLeft, bool enableRightPort, int typeRight, Color colorRight, Texture2D customIconLeft = null, Texture2D customIconRight = null, bool drawStylebox = true)
    {
        NativeCalls.godot_icall_10_700(MethodBind3, GodotObject.GetPtr(this), slotIndex, enableLeftPort.ToGodotBool(), typeLeft, &colorLeft, enableRightPort.ToGodotBool(), typeRight, &colorRight, GodotObject.GetPtr(customIconLeft), GodotObject.GetPtr(customIconRight), drawStylebox.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSlot, 1286410249ul);

    /// <summary>
    /// <para>Disables the slot with the given <paramref name="slotIndex"/>. This will remove the corresponding input and output port from the GraphNode.</para>
    /// </summary>
    public void ClearSlot(int slotIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearAllSlots, 3218959716ul);

    /// <summary>
    /// <para>Disables all slots of the GraphNode. This will remove all input/output ports from the GraphNode.</para>
    /// </summary>
    public void ClearAllSlots()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSlotEnabledLeft, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if left (input) side of the slot with the given <paramref name="slotIndex"/> is enabled.</para>
    /// </summary>
    public bool IsSlotEnabledLeft(int slotIndex)
    {
        return NativeCalls.godot_icall_1_62(MethodBind6, GodotObject.GetPtr(this), slotIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotEnabledLeft, 300928843ul);

    /// <summary>
    /// <para>Toggles the left (input) side of the slot with the given <paramref name="slotIndex"/>. If <paramref name="enable"/> is <see langword="true"/>, a port will appear on the left side and the slot will be able to be connected from this side.</para>
    /// </summary>
    public void SetSlotEnabledLeft(int slotIndex, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind7, GodotObject.GetPtr(this), slotIndex, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotTypeLeft, 3937882851ul);

    /// <summary>
    /// <para>Sets the left (input) type of the slot with the given <paramref name="slotIndex"/> to <paramref name="type"/>. If the value is negative, all connections will be disallowed to be created via user inputs.</para>
    /// </summary>
    public void SetSlotTypeLeft(int slotIndex, int type)
    {
        NativeCalls.godot_icall_2_59(MethodBind8, GodotObject.GetPtr(this), slotIndex, type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotTypeLeft, 923996154ul);

    /// <summary>
    /// <para>Returns the left (input) type of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public int GetSlotTypeLeft(int slotIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotColorLeft, 2878471219ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Color"/> of the left (input) side of the slot with the given <paramref name="slotIndex"/> to <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void SetSlotColorLeft(int slotIndex, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind10, GodotObject.GetPtr(this), slotIndex, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotColorLeft, 3457211756ul);

    /// <summary>
    /// <para>Returns the left (input) <see cref="Godot.Color"/> of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public Color GetSlotColorLeft(int slotIndex)
    {
        return NativeCalls.godot_icall_1_688(MethodBind11, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotCustomIconLeft, 666127730ul);

    /// <summary>
    /// <para>Sets the custom <see cref="Godot.Texture2D"/> of the left (input) side of the slot with the given <paramref name="slotIndex"/> to <paramref name="customIcon"/>.</para>
    /// </summary>
    public void SetSlotCustomIconLeft(int slotIndex, Texture2D customIcon)
    {
        NativeCalls.godot_icall_2_70(MethodBind12, GodotObject.GetPtr(this), slotIndex, GodotObject.GetPtr(customIcon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotCustomIconLeft, 3536238170ul);

    /// <summary>
    /// <para>Returns the left (input) custom <see cref="Godot.Texture2D"/> of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public Texture2D GetSlotCustomIconLeft(int slotIndex)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind13, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotMetadataLeft, 2152698145ul);

    /// <summary>
    /// <para>Sets the custom metadata for the left (input) side of the slot with the given <paramref name="slotIndex"/> to <paramref name="value"/>.</para>
    /// </summary>
    public void SetSlotMetadataLeft(int slotIndex, Variant value)
    {
        NativeCalls.godot_icall_2_701(MethodBind14, GodotObject.GetPtr(this), slotIndex, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotMetadataLeft, 4227898402ul);

    /// <summary>
    /// <para>Returns the left (input) metadata of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public Variant GetSlotMetadataLeft(int slotIndex)
    {
        return NativeCalls.godot_icall_1_702(MethodBind15, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSlotEnabledRight, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if right (output) side of the slot with the given <paramref name="slotIndex"/> is enabled.</para>
    /// </summary>
    public bool IsSlotEnabledRight(int slotIndex)
    {
        return NativeCalls.godot_icall_1_62(MethodBind16, GodotObject.GetPtr(this), slotIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotEnabledRight, 300928843ul);

    /// <summary>
    /// <para>Toggles the right (output) side of the slot with the given <paramref name="slotIndex"/>. If <paramref name="enable"/> is <see langword="true"/>, a port will appear on the right side and the slot will be able to be connected from this side.</para>
    /// </summary>
    public void SetSlotEnabledRight(int slotIndex, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind17, GodotObject.GetPtr(this), slotIndex, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotTypeRight, 3937882851ul);

    /// <summary>
    /// <para>Sets the right (output) type of the slot with the given <paramref name="slotIndex"/> to <paramref name="type"/>. If the value is negative, all connections will be disallowed to be created via user inputs.</para>
    /// </summary>
    public void SetSlotTypeRight(int slotIndex, int type)
    {
        NativeCalls.godot_icall_2_59(MethodBind18, GodotObject.GetPtr(this), slotIndex, type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotTypeRight, 923996154ul);

    /// <summary>
    /// <para>Returns the right (output) type of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public int GetSlotTypeRight(int slotIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind19, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotColorRight, 2878471219ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Color"/> of the right (output) side of the slot with the given <paramref name="slotIndex"/> to <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void SetSlotColorRight(int slotIndex, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind20, GodotObject.GetPtr(this), slotIndex, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotColorRight, 3457211756ul);

    /// <summary>
    /// <para>Returns the right (output) <see cref="Godot.Color"/> of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public Color GetSlotColorRight(int slotIndex)
    {
        return NativeCalls.godot_icall_1_688(MethodBind21, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotCustomIconRight, 666127730ul);

    /// <summary>
    /// <para>Sets the custom <see cref="Godot.Texture2D"/> of the right (output) side of the slot with the given <paramref name="slotIndex"/> to <paramref name="customIcon"/>.</para>
    /// </summary>
    public void SetSlotCustomIconRight(int slotIndex, Texture2D customIcon)
    {
        NativeCalls.godot_icall_2_70(MethodBind22, GodotObject.GetPtr(this), slotIndex, GodotObject.GetPtr(customIcon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotCustomIconRight, 3536238170ul);

    /// <summary>
    /// <para>Returns the right (output) custom <see cref="Godot.Texture2D"/> of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public Texture2D GetSlotCustomIconRight(int slotIndex)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind23, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotMetadataRight, 2152698145ul);

    /// <summary>
    /// <para>Sets the custom metadata for the right (output) side of the slot with the given <paramref name="slotIndex"/> to <paramref name="value"/>.</para>
    /// </summary>
    public void SetSlotMetadataRight(int slotIndex, Variant value)
    {
        NativeCalls.godot_icall_2_701(MethodBind24, GodotObject.GetPtr(this), slotIndex, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotMetadataRight, 4227898402ul);

    /// <summary>
    /// <para>Returns the right (output) metadata of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public Variant GetSlotMetadataRight(int slotIndex)
    {
        return NativeCalls.godot_icall_1_702(MethodBind25, GodotObject.GetPtr(this), slotIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSlotDrawStylebox, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the background <see cref="Godot.StyleBox"/> of the slot with the given <paramref name="slotIndex"/> is drawn.</para>
    /// </summary>
    public bool IsSlotDrawStylebox(int slotIndex)
    {
        return NativeCalls.godot_icall_1_62(MethodBind26, GodotObject.GetPtr(this), slotIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotDrawStylebox, 300928843ul);

    /// <summary>
    /// <para>Toggles the background <see cref="Godot.StyleBox"/> of the slot with the given <paramref name="slotIndex"/>.</para>
    /// </summary>
    public void SetSlotDrawStylebox(int slotIndex, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind27, GodotObject.GetPtr(this), slotIndex, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreInvalidConnectionType, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreInvalidConnectionType(bool ignore)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIgnoringValidConnectionType, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIgnoringValidConnectionType()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlotsFocusMode, 3232914922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSlotsFocusMode(Control.FocusModeEnum focusMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)focusMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSlotsFocusMode, 2132829277ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.FocusModeEnum GetSlotsFocusMode()
    {
        return (Control.FocusModeEnum)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of slots with an enabled input port.</para>
    /// </summary>
    public int GetInputPortCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortPosition, 3114997196ul);

    /// <summary>
    /// <para>Returns the position of the input port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public Vector2 GetInputPortPosition(int portIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind33, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortType, 3744713108ul);

    /// <summary>
    /// <para>Returns the type of the input port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public int GetInputPortType(int portIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind34, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortColor, 2624840992ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Color"/> of the input port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public Color GetInputPortColor(int portIdx)
    {
        return NativeCalls.godot_icall_1_688(MethodBind35, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortSlot, 3744713108ul);

    /// <summary>
    /// <para>Returns the corresponding slot index of the input port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public int GetInputPortSlot(int portIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind36, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of slots with an enabled output port.</para>
    /// </summary>
    public int GetOutputPortCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortPosition, 3114997196ul);

    /// <summary>
    /// <para>Returns the position of the output port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public Vector2 GetOutputPortPosition(int portIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind38, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortType, 3744713108ul);

    /// <summary>
    /// <para>Returns the type of the output port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public int GetOutputPortType(int portIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind39, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortColor, 2624840992ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Color"/> of the output port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public Color GetOutputPortColor(int portIdx)
    {
        return NativeCalls.godot_icall_1_688(MethodBind40, GodotObject.GetPtr(this), portIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortSlot, 3744713108ul);

    /// <summary>
    /// <para>Returns the corresponding slot index of the output port with the given <paramref name="portIdx"/>.</para>
    /// </summary>
    public int GetOutputPortSlot(int portIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind41, GodotObject.GetPtr(this), portIdx);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphNode.SlotUpdated"/> event of a <see cref="Godot.GraphNode"/> class.
    /// </summary>
    public delegate void SlotUpdatedEventHandler(long slotIndex);

    private static void SlotUpdatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SlotUpdatedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when any GraphNode's slot is updated.</para>
    /// </summary>
    public unsafe event SlotUpdatedEventHandler SlotUpdated
    {
        add => Connect(SignalName.SlotUpdated, Callable.CreateWithUnsafeTrampoline(value, &SlotUpdatedTrampoline));
        remove => Disconnect(SignalName.SlotUpdated, Callable.CreateWithUnsafeTrampoline(value, &SlotUpdatedTrampoline));
    }

    protected void EmitSignalSlotUpdated(long slotIndex)
    {
        EmitSignal(SignalName.SlotUpdated, slotIndex);
    }

    /// <summary>
    /// <para>Emitted when any slot's size might have changed.</para>
    /// </summary>
    public event Action SlotSizesChanged
    {
        add => Connect(SignalName.SlotSizesChanged, Callable.From(value));
        remove => Disconnect(SignalName.SlotSizesChanged, Callable.From(value));
    }

    protected void EmitSignalSlotSizesChanged()
    {
        EmitSignal(SignalName.SlotSizesChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__draw_port = "_DrawPort";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_slot_updated = "SlotUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_slot_sizes_changed = "SlotSizesChanged";

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
        if ((method == MethodProxyName__draw_port || method == MethodName._DrawPort) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__draw_port.NativeValue))
        {
            _DrawPort(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<Color>(args[3]));
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
        if (method == MethodName._DrawPort)
        {
            if (HasGodotClassMethod(MethodProxyName__draw_port.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.SlotUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_slot_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SlotSizesChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_slot_sizes_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GraphElement.PropertyName
    {
        /// <summary>
        /// Cached name for the 'title' property.
        /// </summary>
        public static readonly StringName Title = "title";
        /// <summary>
        /// Cached name for the 'ignore_invalid_connection_type' property.
        /// </summary>
        public static readonly StringName IgnoreInvalidConnectionType = "ignore_invalid_connection_type";
        /// <summary>
        /// Cached name for the 'slots_focus_mode' property.
        /// </summary>
        public static readonly StringName SlotsFocusMode = "slots_focus_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GraphElement.MethodName
    {
        /// <summary>
        /// Cached name for the '_draw_port' method.
        /// </summary>
        public static readonly StringName _DrawPort = "_draw_port";
        /// <summary>
        /// Cached name for the 'set_title' method.
        /// </summary>
        public static readonly StringName SetTitle = "set_title";
        /// <summary>
        /// Cached name for the 'get_title' method.
        /// </summary>
        public static readonly StringName GetTitle = "get_title";
        /// <summary>
        /// Cached name for the 'get_titlebar_hbox' method.
        /// </summary>
        public static readonly StringName GetTitlebarHBox = "get_titlebar_hbox";
        /// <summary>
        /// Cached name for the 'set_slot' method.
        /// </summary>
        public static readonly StringName SetSlot = "set_slot";
        /// <summary>
        /// Cached name for the 'clear_slot' method.
        /// </summary>
        public static readonly StringName ClearSlot = "clear_slot";
        /// <summary>
        /// Cached name for the 'clear_all_slots' method.
        /// </summary>
        public static readonly StringName ClearAllSlots = "clear_all_slots";
        /// <summary>
        /// Cached name for the 'is_slot_enabled_left' method.
        /// </summary>
        public static readonly StringName IsSlotEnabledLeft = "is_slot_enabled_left";
        /// <summary>
        /// Cached name for the 'set_slot_enabled_left' method.
        /// </summary>
        public static readonly StringName SetSlotEnabledLeft = "set_slot_enabled_left";
        /// <summary>
        /// Cached name for the 'set_slot_type_left' method.
        /// </summary>
        public static readonly StringName SetSlotTypeLeft = "set_slot_type_left";
        /// <summary>
        /// Cached name for the 'get_slot_type_left' method.
        /// </summary>
        public static readonly StringName GetSlotTypeLeft = "get_slot_type_left";
        /// <summary>
        /// Cached name for the 'set_slot_color_left' method.
        /// </summary>
        public static readonly StringName SetSlotColorLeft = "set_slot_color_left";
        /// <summary>
        /// Cached name for the 'get_slot_color_left' method.
        /// </summary>
        public static readonly StringName GetSlotColorLeft = "get_slot_color_left";
        /// <summary>
        /// Cached name for the 'set_slot_custom_icon_left' method.
        /// </summary>
        public static readonly StringName SetSlotCustomIconLeft = "set_slot_custom_icon_left";
        /// <summary>
        /// Cached name for the 'get_slot_custom_icon_left' method.
        /// </summary>
        public static readonly StringName GetSlotCustomIconLeft = "get_slot_custom_icon_left";
        /// <summary>
        /// Cached name for the 'set_slot_metadata_left' method.
        /// </summary>
        public static readonly StringName SetSlotMetadataLeft = "set_slot_metadata_left";
        /// <summary>
        /// Cached name for the 'get_slot_metadata_left' method.
        /// </summary>
        public static readonly StringName GetSlotMetadataLeft = "get_slot_metadata_left";
        /// <summary>
        /// Cached name for the 'is_slot_enabled_right' method.
        /// </summary>
        public static readonly StringName IsSlotEnabledRight = "is_slot_enabled_right";
        /// <summary>
        /// Cached name for the 'set_slot_enabled_right' method.
        /// </summary>
        public static readonly StringName SetSlotEnabledRight = "set_slot_enabled_right";
        /// <summary>
        /// Cached name for the 'set_slot_type_right' method.
        /// </summary>
        public static readonly StringName SetSlotTypeRight = "set_slot_type_right";
        /// <summary>
        /// Cached name for the 'get_slot_type_right' method.
        /// </summary>
        public static readonly StringName GetSlotTypeRight = "get_slot_type_right";
        /// <summary>
        /// Cached name for the 'set_slot_color_right' method.
        /// </summary>
        public static readonly StringName SetSlotColorRight = "set_slot_color_right";
        /// <summary>
        /// Cached name for the 'get_slot_color_right' method.
        /// </summary>
        public static readonly StringName GetSlotColorRight = "get_slot_color_right";
        /// <summary>
        /// Cached name for the 'set_slot_custom_icon_right' method.
        /// </summary>
        public static readonly StringName SetSlotCustomIconRight = "set_slot_custom_icon_right";
        /// <summary>
        /// Cached name for the 'get_slot_custom_icon_right' method.
        /// </summary>
        public static readonly StringName GetSlotCustomIconRight = "get_slot_custom_icon_right";
        /// <summary>
        /// Cached name for the 'set_slot_metadata_right' method.
        /// </summary>
        public static readonly StringName SetSlotMetadataRight = "set_slot_metadata_right";
        /// <summary>
        /// Cached name for the 'get_slot_metadata_right' method.
        /// </summary>
        public static readonly StringName GetSlotMetadataRight = "get_slot_metadata_right";
        /// <summary>
        /// Cached name for the 'is_slot_draw_stylebox' method.
        /// </summary>
        public static readonly StringName IsSlotDrawStylebox = "is_slot_draw_stylebox";
        /// <summary>
        /// Cached name for the 'set_slot_draw_stylebox' method.
        /// </summary>
        public static readonly StringName SetSlotDrawStylebox = "set_slot_draw_stylebox";
        /// <summary>
        /// Cached name for the 'set_ignore_invalid_connection_type' method.
        /// </summary>
        public static readonly StringName SetIgnoreInvalidConnectionType = "set_ignore_invalid_connection_type";
        /// <summary>
        /// Cached name for the 'is_ignoring_valid_connection_type' method.
        /// </summary>
        public static readonly StringName IsIgnoringValidConnectionType = "is_ignoring_valid_connection_type";
        /// <summary>
        /// Cached name for the 'set_slots_focus_mode' method.
        /// </summary>
        public static readonly StringName SetSlotsFocusMode = "set_slots_focus_mode";
        /// <summary>
        /// Cached name for the 'get_slots_focus_mode' method.
        /// </summary>
        public static readonly StringName GetSlotsFocusMode = "get_slots_focus_mode";
        /// <summary>
        /// Cached name for the 'get_input_port_count' method.
        /// </summary>
        public static readonly StringName GetInputPortCount = "get_input_port_count";
        /// <summary>
        /// Cached name for the 'get_input_port_position' method.
        /// </summary>
        public static readonly StringName GetInputPortPosition = "get_input_port_position";
        /// <summary>
        /// Cached name for the 'get_input_port_type' method.
        /// </summary>
        public static readonly StringName GetInputPortType = "get_input_port_type";
        /// <summary>
        /// Cached name for the 'get_input_port_color' method.
        /// </summary>
        public static readonly StringName GetInputPortColor = "get_input_port_color";
        /// <summary>
        /// Cached name for the 'get_input_port_slot' method.
        /// </summary>
        public static readonly StringName GetInputPortSlot = "get_input_port_slot";
        /// <summary>
        /// Cached name for the 'get_output_port_count' method.
        /// </summary>
        public static readonly StringName GetOutputPortCount = "get_output_port_count";
        /// <summary>
        /// Cached name for the 'get_output_port_position' method.
        /// </summary>
        public static readonly StringName GetOutputPortPosition = "get_output_port_position";
        /// <summary>
        /// Cached name for the 'get_output_port_type' method.
        /// </summary>
        public static readonly StringName GetOutputPortType = "get_output_port_type";
        /// <summary>
        /// Cached name for the 'get_output_port_color' method.
        /// </summary>
        public static readonly StringName GetOutputPortColor = "get_output_port_color";
        /// <summary>
        /// Cached name for the 'get_output_port_slot' method.
        /// </summary>
        public static readonly StringName GetOutputPortSlot = "get_output_port_slot";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GraphElement.SignalName
    {
        /// <summary>
        /// Cached name for the 'slot_updated' signal.
        /// </summary>
        public static readonly StringName SlotUpdated = "slot_updated";
        /// <summary>
        /// Cached name for the 'slot_sizes_changed' signal.
        /// </summary>
        public static readonly StringName SlotSizesChanged = "slot_sizes_changed";
    }
}

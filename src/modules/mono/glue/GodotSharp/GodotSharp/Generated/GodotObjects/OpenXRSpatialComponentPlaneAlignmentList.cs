namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Object for storing the queries plane alignment result data when calling <see cref="Godot.OpenXRSpatialEntityExtension.QuerySnapshot(Rid, Godot.Collections.Array{OpenXRSpatialComponentData}, OpenXRStructureBase)"/>.</para>
/// </summary>
public partial class OpenXRSpatialComponentPlaneAlignmentList : OpenXRSpatialComponentData
{
    public enum PlaneAlignment : long
    {
        /// <summary>
        /// <para>Plane is facing upward.</para>
        /// </summary>
        HorizontalUpward = 0,
        /// <summary>
        /// <para>Plane is facing downwards.</para>
        /// </summary>
        HorizontalDownward = 1,
        /// <summary>
        /// <para>Plane is vertically aligned.</para>
        /// </summary>
        Vertical = 2,
        /// <summary>
        /// <para>Plane has an arbitrary alignment.</para>
        /// </summary>
        Arbitrary = 3
    }

    private static readonly System.Type CachedType = typeof(OpenXRSpatialComponentPlaneAlignmentList);

    private static readonly StringName NativeName = "OpenXRSpatialComponentPlaneAlignmentList";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialComponentPlaneAlignmentList() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentPlaneAlignmentList(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentPlaneAlignmentList(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaneAlignment, 3340200270ul);

    /// <summary>
    /// <para>Returns the plane alignment for the parent entity at this <paramref name="index"/>.</para>
    /// </summary>
    public OpenXRSpatialComponentPlaneAlignmentList.PlaneAlignment GetPlaneAlignment(long index)
    {
        return (OpenXRSpatialComponentPlaneAlignmentList.PlaneAlignment)NativeCalls.godot_icall_1_562(MethodBind0, GodotObject.GetPtr(this), index);
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
    public new class PropertyName : OpenXRSpatialComponentData.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialComponentData.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_plane_alignment' method.
        /// </summary>
        public static readonly StringName GetPlaneAlignment = "get_plane_alignment";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialComponentData.SignalName
    {
    }
}

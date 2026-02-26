namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Camera3D"/> is a special node that displays what is visible from its current location. Cameras register themselves in the nearest <see cref="Godot.Viewport"/> node (when ascending the tree). Only one camera can be active per viewport. If no viewport is available ascending the tree, the camera will register in the global viewport. In other words, a camera just provides 3D display capabilities to a <see cref="Godot.Viewport"/>, and, without one, a scene registered in that <see cref="Godot.Viewport"/> (or higher viewports) can't be displayed.</para>
/// </summary>
public partial class Camera3D : Node3D
{
    public enum ProjectionType : long
    {
        /// <summary>
        /// <para>Perspective projection. Objects on the screen becomes smaller when they are far away.</para>
        /// </summary>
        Perspective = 0,
        /// <summary>
        /// <para>Orthogonal projection, also known as orthographic projection. Objects remain the same size on the screen no matter how far away they are.</para>
        /// </summary>
        Orthogonal = 1,
        /// <summary>
        /// <para>Frustum projection. This mode allows adjusting <see cref="Godot.Camera3D.FrustumOffset"/> to create "tilted frustum" effects.</para>
        /// </summary>
        Frustum = 2
    }

    public enum KeepAspectEnum : long
    {
        /// <summary>
        /// <para>Preserves the horizontal aspect ratio; also known as Vert- scaling. This is usually the best option for projects running in portrait mode, as taller aspect ratios will benefit from a wider vertical FOV.</para>
        /// </summary>
        Width = 0,
        /// <summary>
        /// <para>Preserves the vertical aspect ratio; also known as Hor+ scaling. This is usually the best option for projects running in landscape mode, as wider aspect ratios will automatically benefit from a wider horizontal FOV.</para>
        /// </summary>
        Height = 1
    }

    public enum DopplerTrackingEnum : long
    {
        /// <summary>
        /// <para>Disables <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> simulation (default).</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Simulate <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> by tracking positions of objects that are changed in <c>_process</c>. Changes in the relative velocity of this camera compared to those objects affect how audio is perceived (changing the audio's <see cref="Godot.AudioStreamPlayer3D.PitchScale"/>).</para>
        /// </summary>
        IdleStep = 1,
        /// <summary>
        /// <para>Simulate <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> by tracking positions of objects that are changed in <c>_physics_process</c>. Changes in the relative velocity of this camera compared to those objects affect how audio is perceived (changing the audio's <see cref="Godot.AudioStreamPlayer3D.PitchScale"/>).</para>
        /// </summary>
        PhysicsStep = 2
    }

    /// <summary>
    /// <para>The axis to lock during <see cref="Godot.Camera3D.Fov"/>/<see cref="Godot.Camera3D.Size"/> adjustments. Can be either <see cref="Godot.Camera3D.KeepAspectEnum.Width"/> or <see cref="Godot.Camera3D.KeepAspectEnum.Height"/>.</para>
    /// </summary>
    public Camera3D.KeepAspectEnum KeepAspect
    {
        get
        {
            return GetKeepAspectMode();
        }
        set
        {
            SetKeepAspectMode(value);
        }
    }

    /// <summary>
    /// <para>The culling mask that describes which <see cref="Godot.VisualInstance3D.Layers"/> are rendered by this camera. By default, all 20 user-visible layers are rendered.</para>
    /// <para><b>Note:</b> Since the <see cref="Godot.Camera3D.CullMask"/> allows for 32 layers to be stored in total, there are an additional 12 layers that are only used internally by the engine and aren't exposed in the editor. Setting <see cref="Godot.Camera3D.CullMask"/> using a script allows you to toggle those reserved layers, which can be useful for editor plugins.</para>
    /// <para>To adjust <see cref="Godot.Camera3D.CullMask"/> more easily using a script, use <see cref="Godot.Camera3D.GetCullMaskValue(int)"/> and <see cref="Godot.Camera3D.SetCullMaskValue(int, bool)"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.VoxelGI"/>, SDFGI and <see cref="Godot.LightmapGI"/> will always take all layers into account to determine what contributes to global illumination. If this is an issue, set <see cref="Godot.GeometryInstance3D.GIMode"/> to <see cref="Godot.GeometryInstance3D.GIModeEnum.Disabled"/> for meshes and <see cref="Godot.Light3D.LightBakeMode"/> to <see cref="Godot.Light3D.BakeMode.Disabled"/> for lights to exclude them from global illumination.</para>
    /// </summary>
    public uint CullMask
    {
        get
        {
            return GetCullMask();
        }
        set
        {
            SetCullMask(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Environment"/> to use for this camera.</para>
    /// </summary>
    public Environment Environment
    {
        get
        {
            return GetEnvironment();
        }
        set
        {
            SetEnvironment(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.CameraAttributes"/> to use for this camera.</para>
    /// </summary>
    public CameraAttributes Attributes
    {
        get
        {
            return GetAttributes();
        }
        set
        {
            SetAttributes(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Compositor"/> to use for this camera.</para>
    /// </summary>
    public Compositor Compositor
    {
        get
        {
            return GetCompositor();
        }
        set
        {
            SetCompositor(value);
        }
    }

    /// <summary>
    /// <para>The horizontal (X) offset of the camera viewport.</para>
    /// </summary>
    public float HOffset
    {
        get
        {
            return GetHOffset();
        }
        set
        {
            SetHOffset(value);
        }
    }

    /// <summary>
    /// <para>The vertical (Y) offset of the camera viewport.</para>
    /// </summary>
    public float VOffset
    {
        get
        {
            return GetVOffset();
        }
        set
        {
            SetVOffset(value);
        }
    }

    /// <summary>
    /// <para>If not <see cref="Godot.Camera3D.DopplerTrackingEnum.Disabled"/>, this camera will simulate the <a href="https://en.wikipedia.org/wiki/Doppler_effect">Doppler effect</a> for objects changed in particular <c>_process</c> methods.</para>
    /// <para><b>Note:</b> The Doppler effect will only be heard on <see cref="Godot.AudioStreamPlayer3D"/>s if <see cref="Godot.AudioStreamPlayer3D.DopplerTracking"/> is not set to <see cref="Godot.AudioStreamPlayer3D.DopplerTrackingEnum.Disabled"/>.</para>
    /// </summary>
    public Camera3D.DopplerTrackingEnum DopplerTracking
    {
        get
        {
            return GetDopplerTracking();
        }
        set
        {
            SetDopplerTracking(value);
        }
    }

    /// <summary>
    /// <para>The camera's projection mode. In <see cref="Godot.Camera3D.ProjectionType.Perspective"/> mode, objects' Z distance from the camera's local space scales their perceived size.</para>
    /// </summary>
    public Camera3D.ProjectionType Projection
    {
        get
        {
            return GetProjection();
        }
        set
        {
            SetProjection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the ancestor <see cref="Godot.Viewport"/> is currently using this camera.</para>
    /// <para>If multiple cameras are in the scene, one will always be made current. For example, if two <see cref="Godot.Camera3D"/> nodes are present in the scene and only one is current, setting one camera's <see cref="Godot.Camera3D.Current"/> to <see langword="false"/> will cause the other camera to be made current.</para>
    /// </summary>
    public bool Current
    {
        get
        {
            return IsCurrent();
        }
        set
        {
            SetCurrent(value);
        }
    }

    /// <summary>
    /// <para>The camera's field of view angle (in degrees). Only applicable in perspective mode. Since <see cref="Godot.Camera3D.KeepAspect"/> locks one axis, <see cref="Godot.Camera3D.Fov"/> sets the other axis' field of view angle.</para>
    /// <para>For reference, the default vertical field of view value (<c>75.0</c>) is equivalent to a horizontal FOV of:</para>
    /// <para>- ~91.31 degrees in a 4:3 viewport</para>
    /// <para>- ~101.67 degrees in a 16:10 viewport</para>
    /// <para>- ~107.51 degrees in a 16:9 viewport</para>
    /// <para>- ~121.63 degrees in a 21:9 viewport</para>
    /// </summary>
    public float Fov
    {
        get
        {
            return GetFov();
        }
        set
        {
            SetFov(value);
        }
    }

    /// <summary>
    /// <para>The camera's size in meters measured as the diameter of the width or height, depending on <see cref="Godot.Camera3D.KeepAspect"/>. Only applicable in orthogonal and frustum modes.</para>
    /// </summary>
    public float Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>The camera's frustum offset. This can be changed from the default to create "tilted frustum" effects such as <a href="https://zdoom.org/wiki/Y-shearing">Y-shearing</a>.</para>
    /// <para><b>Note:</b> Only effective if <see cref="Godot.Camera3D.Projection"/> is <see cref="Godot.Camera3D.ProjectionType.Frustum"/>.</para>
    /// </summary>
    public Vector2 FrustumOffset
    {
        get
        {
            return GetFrustumOffset();
        }
        set
        {
            SetFrustumOffset(value);
        }
    }

    /// <summary>
    /// <para>The distance to the near culling boundary for this camera relative to its local Z axis. Lower values allow the camera to see objects more up close to its origin, at the cost of lower precision across the <i>entire</i> range. Values lower than the default can lead to increased Z-fighting.</para>
    /// </summary>
    public float Near
    {
        get
        {
            return GetNear();
        }
        set
        {
            SetNear(value);
        }
    }

    /// <summary>
    /// <para>The distance to the far culling boundary for this camera relative to its local Z axis. Higher values allow the camera to see further away, while decreasing <see cref="Godot.Camera3D.Far"/> can improve performance if it results in objects being partially or fully culled.</para>
    /// </summary>
    public float Far
    {
        get
        {
            return GetFar();
        }
        set
        {
            SetFar(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Camera3D);

    private static readonly StringName NativeName = "Camera3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Camera3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Camera3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Camera3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ProjectRayNormal, 1718073306ul);

    /// <summary>
    /// <para>Returns a normal vector in world space, that is the result of projecting a point on the <see cref="Godot.Viewport"/> rectangle by the inverse camera projection. This is useful for casting rays in the form of (origin, normal) for object intersection or picking.</para>
    /// </summary>
    public unsafe Vector3 ProjectRayNormal(Vector2 screenPoint)
    {
        return NativeCalls.godot_icall_1_231(MethodBind0, GodotObject.GetPtr(this), &screenPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ProjectLocalRayNormal, 1718073306ul);

    /// <summary>
    /// <para>Returns a normal vector from the screen point location directed along the camera. Orthogonal cameras are normalized. Perspective cameras account for perspective, screen width/height, etc.</para>
    /// </summary>
    public unsafe Vector3 ProjectLocalRayNormal(Vector2 screenPoint)
    {
        return NativeCalls.godot_icall_1_231(MethodBind1, GodotObject.GetPtr(this), &screenPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ProjectRayOrigin, 1718073306ul);

    /// <summary>
    /// <para>Returns a 3D position in world space, that is the result of projecting a point on the <see cref="Godot.Viewport"/> rectangle by the inverse camera projection. This is useful for casting rays in the form of (origin, normal) for object intersection or picking.</para>
    /// </summary>
    public unsafe Vector3 ProjectRayOrigin(Vector2 screenPoint)
    {
        return NativeCalls.godot_icall_1_231(MethodBind2, GodotObject.GetPtr(this), &screenPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnprojectPosition, 3758901831ul);

    /// <summary>
    /// <para>Returns the 2D coordinate in the <see cref="Godot.Viewport"/> rectangle that maps to the given 3D point in world space.</para>
    /// <para><b>Note:</b> When using this to position GUI elements over a 3D viewport, use <see cref="Godot.Camera3D.IsPositionBehind(Vector3)"/> to prevent them from appearing if the 3D point is behind the camera:</para>
    /// <para><code>
    /// # This code block is part of a script that inherits from Node3D.
    /// # `control` is a reference to a node inheriting from Control.
    /// control.visible = not get_viewport().get_camera_3d().is_position_behind(global_transform.origin)
    /// control.position = get_viewport().get_camera_3d().unproject_position(global_transform.origin)
    /// </code></para>
    /// </summary>
    public unsafe Vector2 UnprojectPosition(Vector3 worldPoint)
    {
        return NativeCalls.godot_icall_1_232(MethodBind3, GodotObject.GetPtr(this), &worldPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPositionBehind, 3108956480ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given position is behind the camera (the blue part of the linked diagram). <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/camera3d_position_frustum.png">See this diagram</a> for an overview of position query methods.</para>
    /// <para><b>Note:</b> A position which returns <see langword="false"/> may still be outside the camera's field of view.</para>
    /// </summary>
    public unsafe bool IsPositionBehind(Vector3 worldPoint)
    {
        return NativeCalls.godot_icall_1_233(MethodBind4, GodotObject.GetPtr(this), &worldPoint).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ProjectPosition, 2171975744ul);

    /// <summary>
    /// <para>Returns the 3D point in world space that maps to the given 2D coordinate in the <see cref="Godot.Viewport"/> rectangle on a plane that is the given <paramref name="zDepth"/> distance into the scene away from the camera.</para>
    /// </summary>
    public unsafe Vector3 ProjectPosition(Vector2 screenPoint, float zDepth)
    {
        return NativeCalls.godot_icall_2_234(MethodBind5, GodotObject.GetPtr(this), &screenPoint, zDepth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPerspective, 2385087082ul);

    /// <summary>
    /// <para>Sets the camera projection to perspective mode (see <see cref="Godot.Camera3D.ProjectionType.Perspective"/>), by specifying a <paramref name="fov"/> (field of view) angle in degrees, and the <paramref name="zNear"/> and <paramref name="zFar"/> clip planes in world space units.</para>
    /// </summary>
    public void SetPerspective(float fov, float zNear, float zFar)
    {
        NativeCalls.godot_icall_3_235(MethodBind6, GodotObject.GetPtr(this), fov, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOrthogonal, 2385087082ul);

    /// <summary>
    /// <para>Sets the camera projection to orthogonal mode (see <see cref="Godot.Camera3D.ProjectionType.Orthogonal"/>), by specifying a <paramref name="size"/>, and the <paramref name="zNear"/> and <paramref name="zFar"/> clip planes in world space units.</para>
    /// <para>As a hint, 3D games that look 2D often use this projection, with <paramref name="size"/> specified in pixels.</para>
    /// </summary>
    public void SetOrthogonal(float size, float zNear, float zFar)
    {
        NativeCalls.godot_icall_3_235(MethodBind7, GodotObject.GetPtr(this), size, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrustum, 354890663ul);

    /// <summary>
    /// <para>Sets the camera projection to frustum mode (see <see cref="Godot.Camera3D.ProjectionType.Frustum"/>), by specifying a <paramref name="size"/>, an <paramref name="offset"/>, and the <paramref name="zNear"/> and <paramref name="zFar"/> clip planes in world space units. See also <see cref="Godot.Camera3D.FrustumOffset"/>.</para>
    /// </summary>
    public unsafe void SetFrustum(float size, Vector2 offset, float zNear, float zFar)
    {
        NativeCalls.godot_icall_4_236(MethodBind8, GodotObject.GetPtr(this), size, &offset, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeCurrent, 3218959716ul);

    /// <summary>
    /// <para>Makes this camera the current camera for the <see cref="Godot.Viewport"/> (see class description). If the camera node is outside the scene tree, it will attempt to become current once it's added.</para>
    /// </summary>
    public void MakeCurrent()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCurrent, 3216645846ul);

    /// <summary>
    /// <para>If this is the current camera, remove it from being current. If <paramref name="enableNext"/> is <see langword="true"/>, request to make the next camera current, if any.</para>
    /// </summary>
    public void ClearCurrent(bool enableNext = true)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enableNext.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrent, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrent(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCurrent, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCurrent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraTransform, 3229777777ul);

    /// <summary>
    /// <para>Returns the transform of the camera plus the vertical (<see cref="Godot.Camera3D.VOffset"/>) and horizontal (<see cref="Godot.Camera3D.HOffset"/>) offsets; and any other adjustments made to the position and orientation of the camera by subclassed cameras such as <see cref="Godot.XRCamera3D"/>.</para>
    /// </summary>
    public Transform3D GetCameraTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraProjection, 2910717950ul);

    /// <summary>
    /// <para>Returns the projection matrix that this camera uses to render to its associated viewport. The camera must be part of the scene tree to function.</para>
    /// </summary>
    public Projection GetCameraProjection()
    {
        return NativeCalls.godot_icall_0_237(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFov, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFov()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrustumOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetFrustumOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFar, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFar()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNear, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetNear()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFov, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFov(float fov)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), fov);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrustumOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFrustumOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind21, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFar, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFar(float far)
    {
        NativeCalls.godot_icall_1_67(MethodBind23, GodotObject.GetPtr(this), far);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNear, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNear(float near)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), near);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjection, 2624185235ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Camera3D.ProjectionType GetProjection()
    {
        return (Camera3D.ProjectionType)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProjection, 4218540108ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProjection(Camera3D.ProjectionType mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHOffset(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind27, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVOffset(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind29, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind31, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCullMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironment, 4143518816ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironment(Environment env)
    {
        NativeCalls.godot_icall_1_56(MethodBind33, GodotObject.GetPtr(this), GodotObject.GetPtr(env));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironment, 3082064660ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment GetEnvironment()
    {
        return (Environment)NativeCalls.godot_icall_0_63(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttributes, 2817810567ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttributes(CameraAttributes env)
    {
        NativeCalls.godot_icall_1_56(MethodBind35, GodotObject.GetPtr(this), GodotObject.GetPtr(env));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttributes, 3921283215ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CameraAttributes GetAttributes()
    {
        return (CameraAttributes)NativeCalls.godot_icall_0_63(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCompositor, 1586754307ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCompositor(Compositor compositor)
    {
        NativeCalls.godot_icall_1_56(MethodBind37, GodotObject.GetPtr(this), GodotObject.GetPtr(compositor));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCompositor, 3647707413ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Compositor GetCompositor()
    {
        return (Compositor)NativeCalls.godot_icall_0_63(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepAspectMode, 1740651252ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepAspectMode(Camera3D.KeepAspectEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind39, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeepAspectMode, 2790278316ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Camera3D.KeepAspectEnum GetKeepAspectMode()
    {
        return (Camera3D.KeepAspectEnum)NativeCalls.godot_icall_0_39(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDopplerTracking, 3109431270ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDopplerTracking(Camera3D.DopplerTrackingEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind41, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDopplerTracking, 1584483649ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Camera3D.DopplerTrackingEnum GetDopplerTracking()
    {
        return (Camera3D.DopplerTrackingEnum)NativeCalls.godot_icall_0_39(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrustum, 3995934104ul);

    /// <summary>
    /// <para>Returns the camera's frustum planes in world space units as an array of <see cref="Godot.Plane"/>s in the following order: near, far, left, top, right, bottom. Not to be confused with <see cref="Godot.Camera3D.FrustumOffset"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Plane> GetFrustum()
    {
        return new Godot.Collections.Array<Plane>(NativeCalls.godot_icall_0_120(MethodBind43, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPositionInFrustum, 3108956480ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given position is inside the camera's frustum (the green part of the linked diagram). <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/camera3d_position_frustum.png">See this diagram</a> for an overview of position query methods.</para>
    /// </summary>
    public unsafe bool IsPositionInFrustum(Vector3 worldPoint)
    {
        return NativeCalls.godot_icall_1_233(MethodBind44, GodotObject.GetPtr(this), &worldPoint).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the camera's RID from the <see cref="Godot.RenderingServer"/>.</para>
    /// </summary>
    public Rid GetCameraRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPyramidShapeRid, 529393457ul);

    /// <summary>
    /// <para>Returns the RID of a pyramid shape encompassing the camera's view frustum, ignoring the camera's near plane. The tip of the pyramid represents the position of the camera.</para>
    /// </summary>
    public Rid GetPyramidShapeRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.Camera3D.CullMask"/>, given a <paramref name="layerNumber"/> between 1 and 20.</para>
    /// </summary>
    public void SetCullMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind47, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.Camera3D.CullMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 20.</para>
    /// </summary>
    public bool GetCullMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind48, GodotObject.GetPtr(this), layerNumber).ToBool();
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'keep_aspect' property.
        /// </summary>
        public static readonly StringName KeepAspect = "keep_aspect";
        /// <summary>
        /// Cached name for the 'cull_mask' property.
        /// </summary>
        public static readonly StringName CullMask = "cull_mask";
        /// <summary>
        /// Cached name for the 'environment' property.
        /// </summary>
        public static readonly StringName Environment = "environment";
        /// <summary>
        /// Cached name for the 'attributes' property.
        /// </summary>
        public static readonly StringName Attributes = "attributes";
        /// <summary>
        /// Cached name for the 'compositor' property.
        /// </summary>
        public static readonly StringName Compositor = "compositor";
        /// <summary>
        /// Cached name for the 'h_offset' property.
        /// </summary>
        public static readonly StringName HOffset = "h_offset";
        /// <summary>
        /// Cached name for the 'v_offset' property.
        /// </summary>
        public static readonly StringName VOffset = "v_offset";
        /// <summary>
        /// Cached name for the 'doppler_tracking' property.
        /// </summary>
        public static readonly StringName DopplerTracking = "doppler_tracking";
        /// <summary>
        /// Cached name for the 'projection' property.
        /// </summary>
        public static readonly StringName Projection = "projection";
        /// <summary>
        /// Cached name for the 'current' property.
        /// </summary>
        public static readonly StringName Current = "current";
        /// <summary>
        /// Cached name for the 'fov' property.
        /// </summary>
        public static readonly StringName Fov = "fov";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'frustum_offset' property.
        /// </summary>
        public static readonly StringName FrustumOffset = "frustum_offset";
        /// <summary>
        /// Cached name for the 'near' property.
        /// </summary>
        public static readonly StringName Near = "near";
        /// <summary>
        /// Cached name for the 'far' property.
        /// </summary>
        public static readonly StringName Far = "far";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'project_ray_normal' method.
        /// </summary>
        public static readonly StringName ProjectRayNormal = "project_ray_normal";
        /// <summary>
        /// Cached name for the 'project_local_ray_normal' method.
        /// </summary>
        public static readonly StringName ProjectLocalRayNormal = "project_local_ray_normal";
        /// <summary>
        /// Cached name for the 'project_ray_origin' method.
        /// </summary>
        public static readonly StringName ProjectRayOrigin = "project_ray_origin";
        /// <summary>
        /// Cached name for the 'unproject_position' method.
        /// </summary>
        public static readonly StringName UnprojectPosition = "unproject_position";
        /// <summary>
        /// Cached name for the 'is_position_behind' method.
        /// </summary>
        public static readonly StringName IsPositionBehind = "is_position_behind";
        /// <summary>
        /// Cached name for the 'project_position' method.
        /// </summary>
        public static readonly StringName ProjectPosition = "project_position";
        /// <summary>
        /// Cached name for the 'set_perspective' method.
        /// </summary>
        public static readonly StringName SetPerspective = "set_perspective";
        /// <summary>
        /// Cached name for the 'set_orthogonal' method.
        /// </summary>
        public static readonly StringName SetOrthogonal = "set_orthogonal";
        /// <summary>
        /// Cached name for the 'set_frustum' method.
        /// </summary>
        public static readonly StringName SetFrustum = "set_frustum";
        /// <summary>
        /// Cached name for the 'make_current' method.
        /// </summary>
        public static readonly StringName MakeCurrent = "make_current";
        /// <summary>
        /// Cached name for the 'clear_current' method.
        /// </summary>
        public static readonly StringName ClearCurrent = "clear_current";
        /// <summary>
        /// Cached name for the 'set_current' method.
        /// </summary>
        public static readonly StringName SetCurrent = "set_current";
        /// <summary>
        /// Cached name for the 'is_current' method.
        /// </summary>
        public static readonly StringName IsCurrent = "is_current";
        /// <summary>
        /// Cached name for the 'get_camera_transform' method.
        /// </summary>
        public static readonly StringName GetCameraTransform = "get_camera_transform";
        /// <summary>
        /// Cached name for the 'get_camera_projection' method.
        /// </summary>
        public static readonly StringName GetCameraProjection = "get_camera_projection";
        /// <summary>
        /// Cached name for the 'get_fov' method.
        /// </summary>
        public static readonly StringName GetFov = "get_fov";
        /// <summary>
        /// Cached name for the 'get_frustum_offset' method.
        /// </summary>
        public static readonly StringName GetFrustumOffset = "get_frustum_offset";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'get_far' method.
        /// </summary>
        public static readonly StringName GetFar = "get_far";
        /// <summary>
        /// Cached name for the 'get_near' method.
        /// </summary>
        public static readonly StringName GetNear = "get_near";
        /// <summary>
        /// Cached name for the 'set_fov' method.
        /// </summary>
        public static readonly StringName SetFov = "set_fov";
        /// <summary>
        /// Cached name for the 'set_frustum_offset' method.
        /// </summary>
        public static readonly StringName SetFrustumOffset = "set_frustum_offset";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'set_far' method.
        /// </summary>
        public static readonly StringName SetFar = "set_far";
        /// <summary>
        /// Cached name for the 'set_near' method.
        /// </summary>
        public static readonly StringName SetNear = "set_near";
        /// <summary>
        /// Cached name for the 'get_projection' method.
        /// </summary>
        public static readonly StringName GetProjection = "get_projection";
        /// <summary>
        /// Cached name for the 'set_projection' method.
        /// </summary>
        public static readonly StringName SetProjection = "set_projection";
        /// <summary>
        /// Cached name for the 'set_h_offset' method.
        /// </summary>
        public static readonly StringName SetHOffset = "set_h_offset";
        /// <summary>
        /// Cached name for the 'get_h_offset' method.
        /// </summary>
        public static readonly StringName GetHOffset = "get_h_offset";
        /// <summary>
        /// Cached name for the 'set_v_offset' method.
        /// </summary>
        public static readonly StringName SetVOffset = "set_v_offset";
        /// <summary>
        /// Cached name for the 'get_v_offset' method.
        /// </summary>
        public static readonly StringName GetVOffset = "get_v_offset";
        /// <summary>
        /// Cached name for the 'set_cull_mask' method.
        /// </summary>
        public static readonly StringName SetCullMask = "set_cull_mask";
        /// <summary>
        /// Cached name for the 'get_cull_mask' method.
        /// </summary>
        public static readonly StringName GetCullMask = "get_cull_mask";
        /// <summary>
        /// Cached name for the 'set_environment' method.
        /// </summary>
        public static readonly StringName SetEnvironment = "set_environment";
        /// <summary>
        /// Cached name for the 'get_environment' method.
        /// </summary>
        public static readonly StringName GetEnvironment = "get_environment";
        /// <summary>
        /// Cached name for the 'set_attributes' method.
        /// </summary>
        public static readonly StringName SetAttributes = "set_attributes";
        /// <summary>
        /// Cached name for the 'get_attributes' method.
        /// </summary>
        public static readonly StringName GetAttributes = "get_attributes";
        /// <summary>
        /// Cached name for the 'set_compositor' method.
        /// </summary>
        public static readonly StringName SetCompositor = "set_compositor";
        /// <summary>
        /// Cached name for the 'get_compositor' method.
        /// </summary>
        public static readonly StringName GetCompositor = "get_compositor";
        /// <summary>
        /// Cached name for the 'set_keep_aspect_mode' method.
        /// </summary>
        public static readonly StringName SetKeepAspectMode = "set_keep_aspect_mode";
        /// <summary>
        /// Cached name for the 'get_keep_aspect_mode' method.
        /// </summary>
        public static readonly StringName GetKeepAspectMode = "get_keep_aspect_mode";
        /// <summary>
        /// Cached name for the 'set_doppler_tracking' method.
        /// </summary>
        public static readonly StringName SetDopplerTracking = "set_doppler_tracking";
        /// <summary>
        /// Cached name for the 'get_doppler_tracking' method.
        /// </summary>
        public static readonly StringName GetDopplerTracking = "get_doppler_tracking";
        /// <summary>
        /// Cached name for the 'get_frustum' method.
        /// </summary>
        public static readonly StringName GetFrustum = "get_frustum";
        /// <summary>
        /// Cached name for the 'is_position_in_frustum' method.
        /// </summary>
        public static readonly StringName IsPositionInFrustum = "is_position_in_frustum";
        /// <summary>
        /// Cached name for the 'get_camera_rid' method.
        /// </summary>
        public static readonly StringName GetCameraRid = "get_camera_rid";
        /// <summary>
        /// Cached name for the 'get_pyramid_shape_rid' method.
        /// </summary>
        public static readonly StringName GetPyramidShapeRid = "get_pyramid_shape_rid";
        /// <summary>
        /// Cached name for the 'set_cull_mask_value' method.
        /// </summary>
        public static readonly StringName SetCullMaskValue = "set_cull_mask_value";
        /// <summary>
        /// Cached name for the 'get_cull_mask_value' method.
        /// </summary>
        public static readonly StringName GetCullMaskValue = "get_cull_mask_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}

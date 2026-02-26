namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Defines the API that the editor uses to extract information from the underlying VCS. The implementation of this API is included in VCS plugins, which are GDExtension plugins that inherit <see cref="Godot.EditorVcsInterface"/> and are attached (on demand) to the singleton instance of <see cref="Godot.EditorVcsInterface"/>. Instead of performing the task themselves, all the virtual functions listed below are calling the internally overridden functions in the VCS plugins to provide a plug-n-play experience. A custom VCS plugin is supposed to inherit from <see cref="Godot.EditorVcsInterface"/> and override each of these virtual functions.</para>
/// </summary>
[GodotClassName("EditorVCSInterface")]
public partial class EditorVcsInterface : GodotObject
{
    public enum ChangeType : long
    {
        /// <summary>
        /// <para>A new file has been added.</para>
        /// </summary>
        New = 0,
        /// <summary>
        /// <para>An earlier added file has been modified.</para>
        /// </summary>
        Modified = 1,
        /// <summary>
        /// <para>An earlier added file has been renamed.</para>
        /// </summary>
        Renamed = 2,
        /// <summary>
        /// <para>An earlier added file has been deleted.</para>
        /// </summary>
        Deleted = 3,
        /// <summary>
        /// <para>An earlier added file has been typechanged.</para>
        /// </summary>
        Typechange = 4,
        /// <summary>
        /// <para>A file is left unmerged.</para>
        /// </summary>
        Unmerged = 5
    }

    public enum TreeArea : long
    {
        /// <summary>
        /// <para>A commit is encountered from the commit area.</para>
        /// </summary>
        Commit = 0,
        /// <summary>
        /// <para>A file is encountered from the staged area.</para>
        /// </summary>
        Staged = 1,
        /// <summary>
        /// <para>A file is encountered from the unstaged area.</para>
        /// </summary>
        Unstaged = 2
    }

    private static readonly System.Type CachedType = typeof(EditorVcsInterface);

    private static readonly StringName NativeName = "EditorVCSInterface";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorVcsInterface() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorVcsInterface(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorVcsInterface(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Checks out a <paramref name="branchName"/> in the VCS.</para>
    /// </summary>
    public virtual bool _CheckoutBranch(string branchName)
    {
        return default;
    }

    /// <summary>
    /// <para>Commits the currently staged changes and applies the commit <paramref name="msg"/> to the resulting commit.</para>
    /// </summary>
    public virtual void _Commit(string msg)
    {
    }

    /// <summary>
    /// <para>Creates a new branch named <paramref name="branchName"/> in the VCS.</para>
    /// </summary>
    public virtual void _CreateBranch(string branchName)
    {
    }

    /// <summary>
    /// <para>Creates a new remote destination with name <paramref name="remoteName"/> and points it to <paramref name="remoteUrl"/>. This can be an HTTPS remote or an SSH remote.</para>
    /// </summary>
    public virtual void _CreateRemote(string remoteName, string remoteUrl)
    {
    }

    /// <summary>
    /// <para>Discards the changes made in a file present at <paramref name="filePath"/>.</para>
    /// </summary>
    public virtual void _DiscardFile(string filePath)
    {
    }

    /// <summary>
    /// <para>Fetches new changes from the <paramref name="remote"/>, but doesn't write changes to the current working directory. Equivalent to <c>git fetch</c>.</para>
    /// </summary>
    public virtual void _Fetch(string remote)
    {
    }

    /// <summary>
    /// <para>Gets an instance of an <see cref="Godot.Collections.Array"/> of <see cref="string"/>s containing available branch names in the VCS.</para>
    /// </summary>
    public virtual Godot.Collections.Array<string> _GetBranchList()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the current branch name defined in the VCS.</para>
    /// </summary>
    public virtual string _GetCurrentBranchName()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.Collections.Dictionary"/> items (see <see cref="Godot.EditorVcsInterface.CreateDiffFile(string, string)"/>, <see cref="Godot.EditorVcsInterface.CreateDiffHunk(int, int, int, int)"/>, <see cref="Godot.EditorVcsInterface.CreateDiffLine(int, int, string, string)"/>, <see cref="Godot.EditorVcsInterface.AddLineDiffsIntoDiffHunk(Godot.Collections.Dictionary, Godot.Collections.Array{Godot.Collections.Dictionary})"/> and <see cref="Godot.EditorVcsInterface.AddDiffHunksIntoDiffFile(Godot.Collections.Dictionary, Godot.Collections.Array{Godot.Collections.Dictionary})"/>), each containing information about a diff. If <paramref name="identifier"/> is a file path, returns a file diff, and if it is a commit identifier, then returns a commit diff.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetDiff(string identifier, int area)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Collections.Dictionary"/> items (see <see cref="Godot.EditorVcsInterface.CreateDiffHunk(int, int, int, int)"/>), each containing a line diff between a file at <paramref name="filePath"/> and the <paramref name="text"/> which is passed in.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetLineDiff(string filePath, string text)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Collections.Dictionary"/> items (see <see cref="Godot.EditorVcsInterface.CreateStatusFile(string, EditorVcsInterface.ChangeType, EditorVcsInterface.TreeArea)"/>), each containing the status data of every modified file in the project folder.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetModifiedFilesData()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Collections.Dictionary"/> items (see <see cref="Godot.EditorVcsInterface.CreateCommit(string, string, string, long, long)"/>), each containing the data for a past commit.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetPreviousCommits(int maxCommits)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="string"/>s, each containing the name of a remote configured in the VCS.</para>
    /// </summary>
    public virtual Godot.Collections.Array<string> _GetRemotes()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the name of the underlying VCS provider.</para>
    /// </summary>
    public virtual string _GetVcsName()
    {
        return default;
    }

    /// <summary>
    /// <para>Initializes the VCS plugin when called from the editor. Returns whether or not the plugin was successfully initialized. A VCS project is initialized at <paramref name="projectPath"/>.</para>
    /// </summary>
    public virtual bool _Initialize(string projectPath)
    {
        return default;
    }

    /// <summary>
    /// <para>Pulls changes from the remote. This can give rise to merge conflicts.</para>
    /// </summary>
    public virtual void _Pull(string remote)
    {
    }

    /// <summary>
    /// <para>Pushes changes to the <paramref name="remote"/>. If <paramref name="force"/> is <see langword="true"/>, a force push will override the change history already present on the remote.</para>
    /// </summary>
    public virtual void _Push(string remote, bool force)
    {
    }

    /// <summary>
    /// <para>Remove a branch from the local VCS.</para>
    /// </summary>
    public virtual void _RemoveBranch(string branchName)
    {
    }

    /// <summary>
    /// <para>Remove a remote from the local VCS.</para>
    /// </summary>
    public virtual void _RemoveRemote(string remoteName)
    {
    }

    /// <summary>
    /// <para>Set user credentials in the underlying VCS. <paramref name="userName"/> and <paramref name="password"/> are used only during HTTPS authentication unless not already mentioned in the remote URL. <paramref name="sshPublicKeyPath"/>, <paramref name="sshPrivateKeyPath"/>, and <paramref name="sshPassphrase"/> are only used during SSH authentication.</para>
    /// </summary>
    public virtual void _SetCredentials(string userName, string password, string sshPublicKeyPath, string sshPrivateKeyPath, string sshPassphrase)
    {
    }

    /// <summary>
    /// <para>Shuts down VCS plugin instance. Called when the user either closes the editor or shuts down the VCS plugin through the editor UI.</para>
    /// </summary>
    public virtual bool _ShutDown()
    {
        return default;
    }

    /// <summary>
    /// <para>Stages the file present at <paramref name="filePath"/> to the staged area.</para>
    /// </summary>
    public virtual void _StageFile(string filePath)
    {
    }

    /// <summary>
    /// <para>Unstages the file present at <paramref name="filePath"/> from the staged area to the unstaged area.</para>
    /// </summary>
    public virtual void _UnstageFile(string filePath)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDiffLine, 2901184053ul);

    /// <summary>
    /// <para>Helper function to create a <see cref="Godot.Collections.Dictionary"/> for storing a line diff. <paramref name="newLineNo"/> is the line number in the new file (can be <c>-1</c> if the line is deleted). <paramref name="oldLineNo"/> is the line number in the old file (can be <c>-1</c> if the line is added). <paramref name="content"/> is the diff text. <paramref name="status"/> is a single character string which stores the line origin.</para>
    /// </summary>
    public Godot.Collections.Dictionary CreateDiffLine(int newLineNo, int oldLineNo, string content, string status)
    {
        return EditorNativeCalls.godot_icall_4_538(MethodBind0, GodotObject.GetPtr(this), newLineNo, oldLineNo, content, status);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDiffHunk, 3784842090ul);

    /// <summary>
    /// <para>Helper function to create a <see cref="Godot.Collections.Dictionary"/> for storing diff hunk data. <paramref name="oldStart"/> is the starting line number in old file. <paramref name="newStart"/> is the starting line number in new file. <paramref name="oldLines"/> is the number of lines in the old file. <paramref name="newLines"/> is the number of lines in the new file.</para>
    /// </summary>
    public Godot.Collections.Dictionary CreateDiffHunk(int oldStart, int newStart, int oldLines, int newLines)
    {
        return EditorNativeCalls.godot_icall_4_539(MethodBind1, GodotObject.GetPtr(this), oldStart, newStart, oldLines, newLines);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDiffFile, 2723227684ul);

    /// <summary>
    /// <para>Helper function to create a <see cref="Godot.Collections.Dictionary"/> for storing old and new diff file paths.</para>
    /// </summary>
    public Godot.Collections.Dictionary CreateDiffFile(string newFile, string oldFile)
    {
        return EditorNativeCalls.godot_icall_2_540(MethodBind2, GodotObject.GetPtr(this), newFile, oldFile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateCommit, 1075983584ul);

    /// <summary>
    /// <para>Helper function to create a commit <see cref="Godot.Collections.Dictionary"/> item. <paramref name="msg"/> is the commit message of the commit. <paramref name="author"/> is a single human-readable string containing all the author's details, e.g. the email and name configured in the VCS. <paramref name="id"/> is the identifier of the commit, in whichever format your VCS may provide an identifier to commits. <paramref name="unixTimestamp"/> is the UTC Unix timestamp of when the commit was created. <paramref name="offsetMinutes"/> is the timezone offset in minutes, recorded from the system timezone where the commit was created.</para>
    /// </summary>
    public Godot.Collections.Dictionary CreateCommit(string msg, string author, string id, long unixTimestamp, long offsetMinutes)
    {
        return EditorNativeCalls.godot_icall_5_541(MethodBind3, GodotObject.GetPtr(this), msg, author, id, unixTimestamp, offsetMinutes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateStatusFile, 1083471673ul);

    /// <summary>
    /// <para>Helper function to create a <see cref="Godot.Collections.Dictionary"/> used by editor to read the status of a file.</para>
    /// </summary>
    public Godot.Collections.Dictionary CreateStatusFile(string filePath, EditorVcsInterface.ChangeType changeType, EditorVcsInterface.TreeArea area)
    {
        return EditorNativeCalls.godot_icall_3_542(MethodBind4, GodotObject.GetPtr(this), filePath, (int)changeType, (int)area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDiffHunksIntoDiffFile, 4015243225ul);

    /// <summary>
    /// <para>Helper function to add an array of <paramref name="diffHunks"/> into a <paramref name="diffFile"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary AddDiffHunksIntoDiffFile(Godot.Collections.Dictionary diffFile, Godot.Collections.Array<Godot.Collections.Dictionary> diffHunks)
    {
        return EditorNativeCalls.godot_icall_2_543(MethodBind5, GodotObject.GetPtr(this), (godot_dictionary)(diffFile ?? new()).NativeValue, (godot_array)(diffHunks ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddLineDiffsIntoDiffHunk, 4015243225ul);

    /// <summary>
    /// <para>Helper function to add an array of <paramref name="lineDiffs"/> into a <paramref name="diffHunk"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary AddLineDiffsIntoDiffHunk(Godot.Collections.Dictionary diffHunk, Godot.Collections.Array<Godot.Collections.Dictionary> lineDiffs)
    {
        return EditorNativeCalls.godot_icall_2_543(MethodBind6, GodotObject.GetPtr(this), (godot_dictionary)(diffHunk ?? new()).NativeValue, (godot_array)(lineDiffs ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupError, 83702148ul);

    /// <summary>
    /// <para>Pops up an error message in the editor which is shown as coming from the underlying VCS. Use this to show VCS specific error messages.</para>
    /// </summary>
    public void PopupError(string msg)
    {
        NativeCalls.godot_icall_1_57(MethodBind7, GodotObject.GetPtr(this), msg);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__checkout_branch = "_CheckoutBranch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__commit = "_Commit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_branch = "_CreateBranch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_remote = "_CreateRemote";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__discard_file = "_DiscardFile";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__fetch = "_Fetch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_branch_list = "_GetBranchList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_current_branch_name = "_GetCurrentBranchName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_diff = "_GetDiff";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_line_diff = "_GetLineDiff";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_modified_files_data = "_GetModifiedFilesData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_previous_commits = "_GetPreviousCommits";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_remotes = "_GetRemotes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_vcs_name = "_GetVcsName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__initialize = "_Initialize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pull = "_Pull";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__push = "_Push";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__remove_branch = "_RemoveBranch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__remove_remote = "_RemoveRemote";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_credentials = "_SetCredentials";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shut_down = "_ShutDown";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__stage_file = "_StageFile";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__unstage_file = "_UnstageFile";

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
        if ((method == MethodProxyName__checkout_branch || method == MethodName._CheckoutBranch) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__checkout_branch.NativeValue))
        {
            var callRet = _CheckoutBranch(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__commit || method == MethodName._Commit) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__commit.NativeValue))
        {
            _Commit(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__create_branch || method == MethodName._CreateBranch) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_branch.NativeValue))
        {
            _CreateBranch(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__create_remote || method == MethodName._CreateRemote) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_remote.NativeValue))
        {
            _CreateRemote(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__discard_file || method == MethodName._DiscardFile) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__discard_file.NativeValue))
        {
            _DiscardFile(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__fetch || method == MethodName._Fetch) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__fetch.NativeValue))
        {
            _Fetch(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_branch_list || method == MethodName._GetBranchList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_branch_list.NativeValue))
        {
            var callRet = _GetBranchList();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_current_branch_name || method == MethodName._GetCurrentBranchName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_current_branch_name.NativeValue))
        {
            var callRet = _GetCurrentBranchName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_diff || method == MethodName._GetDiff) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_diff.NativeValue))
        {
            var callRet = _GetDiff(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_line_diff || method == MethodName._GetLineDiff) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_line_diff.NativeValue))
        {
            var callRet = _GetLineDiff(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_modified_files_data || method == MethodName._GetModifiedFilesData) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_modified_files_data.NativeValue))
        {
            var callRet = _GetModifiedFilesData();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_previous_commits || method == MethodName._GetPreviousCommits) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_previous_commits.NativeValue))
        {
            var callRet = _GetPreviousCommits(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_remotes || method == MethodName._GetRemotes) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_remotes.NativeValue))
        {
            var callRet = _GetRemotes();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_vcs_name || method == MethodName._GetVcsName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_vcs_name.NativeValue))
        {
            var callRet = _GetVcsName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__initialize || method == MethodName._Initialize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__initialize.NativeValue))
        {
            var callRet = _Initialize(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pull || method == MethodName._Pull) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__pull.NativeValue))
        {
            _Pull(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__push || method == MethodName._Push) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__push.NativeValue))
        {
            _Push(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__remove_branch || method == MethodName._RemoveBranch) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__remove_branch.NativeValue))
        {
            _RemoveBranch(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__remove_remote || method == MethodName._RemoveRemote) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__remove_remote.NativeValue))
        {
            _RemoveRemote(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_credentials || method == MethodName._SetCredentials) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_credentials.NativeValue))
        {
            _SetCredentials(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<string>(args[3]), VariantUtils.ConvertTo<string>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shut_down || method == MethodName._ShutDown) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__shut_down.NativeValue))
        {
            var callRet = _ShutDown();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__stage_file || method == MethodName._StageFile) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__stage_file.NativeValue))
        {
            _StageFile(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__unstage_file || method == MethodName._UnstageFile) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__unstage_file.NativeValue))
        {
            _UnstageFile(VariantUtils.ConvertTo<string>(args[0]));
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
        if (method == MethodName._CheckoutBranch)
        {
            if (HasGodotClassMethod(MethodProxyName__checkout_branch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Commit)
        {
            if (HasGodotClassMethod(MethodProxyName__commit.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateBranch)
        {
            if (HasGodotClassMethod(MethodProxyName__create_branch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateRemote)
        {
            if (HasGodotClassMethod(MethodProxyName__create_remote.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DiscardFile)
        {
            if (HasGodotClassMethod(MethodProxyName__discard_file.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Fetch)
        {
            if (HasGodotClassMethod(MethodProxyName__fetch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBranchList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_branch_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCurrentBranchName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_current_branch_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDiff)
        {
            if (HasGodotClassMethod(MethodProxyName__get_diff.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLineDiff)
        {
            if (HasGodotClassMethod(MethodProxyName__get_line_diff.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetModifiedFilesData)
        {
            if (HasGodotClassMethod(MethodProxyName__get_modified_files_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPreviousCommits)
        {
            if (HasGodotClassMethod(MethodProxyName__get_previous_commits.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRemotes)
        {
            if (HasGodotClassMethod(MethodProxyName__get_remotes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetVcsName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_vcs_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Initialize)
        {
            if (HasGodotClassMethod(MethodProxyName__initialize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Pull)
        {
            if (HasGodotClassMethod(MethodProxyName__pull.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Push)
        {
            if (HasGodotClassMethod(MethodProxyName__push.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RemoveBranch)
        {
            if (HasGodotClassMethod(MethodProxyName__remove_branch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RemoveRemote)
        {
            if (HasGodotClassMethod(MethodProxyName__remove_remote.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetCredentials)
        {
            if (HasGodotClassMethod(MethodProxyName__set_credentials.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShutDown)
        {
            if (HasGodotClassMethod(MethodProxyName__shut_down.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StageFile)
        {
            if (HasGodotClassMethod(MethodProxyName__stage_file.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UnstageFile)
        {
            if (HasGodotClassMethod(MethodProxyName__unstage_file.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_checkout_branch' method.
        /// </summary>
        public static readonly StringName _CheckoutBranch = "_checkout_branch";
        /// <summary>
        /// Cached name for the '_commit' method.
        /// </summary>
        public static readonly StringName _Commit = "_commit";
        /// <summary>
        /// Cached name for the '_create_branch' method.
        /// </summary>
        public static readonly StringName _CreateBranch = "_create_branch";
        /// <summary>
        /// Cached name for the '_create_remote' method.
        /// </summary>
        public static readonly StringName _CreateRemote = "_create_remote";
        /// <summary>
        /// Cached name for the '_discard_file' method.
        /// </summary>
        public static readonly StringName _DiscardFile = "_discard_file";
        /// <summary>
        /// Cached name for the '_fetch' method.
        /// </summary>
        public static readonly StringName _Fetch = "_fetch";
        /// <summary>
        /// Cached name for the '_get_branch_list' method.
        /// </summary>
        public static readonly StringName _GetBranchList = "_get_branch_list";
        /// <summary>
        /// Cached name for the '_get_current_branch_name' method.
        /// </summary>
        public static readonly StringName _GetCurrentBranchName = "_get_current_branch_name";
        /// <summary>
        /// Cached name for the '_get_diff' method.
        /// </summary>
        public static readonly StringName _GetDiff = "_get_diff";
        /// <summary>
        /// Cached name for the '_get_line_diff' method.
        /// </summary>
        public static readonly StringName _GetLineDiff = "_get_line_diff";
        /// <summary>
        /// Cached name for the '_get_modified_files_data' method.
        /// </summary>
        public static readonly StringName _GetModifiedFilesData = "_get_modified_files_data";
        /// <summary>
        /// Cached name for the '_get_previous_commits' method.
        /// </summary>
        public static readonly StringName _GetPreviousCommits = "_get_previous_commits";
        /// <summary>
        /// Cached name for the '_get_remotes' method.
        /// </summary>
        public static readonly StringName _GetRemotes = "_get_remotes";
        /// <summary>
        /// Cached name for the '_get_vcs_name' method.
        /// </summary>
        public static readonly StringName _GetVcsName = "_get_vcs_name";
        /// <summary>
        /// Cached name for the '_initialize' method.
        /// </summary>
        public static readonly StringName _Initialize = "_initialize";
        /// <summary>
        /// Cached name for the '_pull' method.
        /// </summary>
        public static readonly StringName _Pull = "_pull";
        /// <summary>
        /// Cached name for the '_push' method.
        /// </summary>
        public static readonly StringName _Push = "_push";
        /// <summary>
        /// Cached name for the '_remove_branch' method.
        /// </summary>
        public static readonly StringName _RemoveBranch = "_remove_branch";
        /// <summary>
        /// Cached name for the '_remove_remote' method.
        /// </summary>
        public static readonly StringName _RemoveRemote = "_remove_remote";
        /// <summary>
        /// Cached name for the '_set_credentials' method.
        /// </summary>
        public static readonly StringName _SetCredentials = "_set_credentials";
        /// <summary>
        /// Cached name for the '_shut_down' method.
        /// </summary>
        public static readonly StringName _ShutDown = "_shut_down";
        /// <summary>
        /// Cached name for the '_stage_file' method.
        /// </summary>
        public static readonly StringName _StageFile = "_stage_file";
        /// <summary>
        /// Cached name for the '_unstage_file' method.
        /// </summary>
        public static readonly StringName _UnstageFile = "_unstage_file";
        /// <summary>
        /// Cached name for the 'create_diff_line' method.
        /// </summary>
        public static readonly StringName CreateDiffLine = "create_diff_line";
        /// <summary>
        /// Cached name for the 'create_diff_hunk' method.
        /// </summary>
        public static readonly StringName CreateDiffHunk = "create_diff_hunk";
        /// <summary>
        /// Cached name for the 'create_diff_file' method.
        /// </summary>
        public static readonly StringName CreateDiffFile = "create_diff_file";
        /// <summary>
        /// Cached name for the 'create_commit' method.
        /// </summary>
        public static readonly StringName CreateCommit = "create_commit";
        /// <summary>
        /// Cached name for the 'create_status_file' method.
        /// </summary>
        public static readonly StringName CreateStatusFile = "create_status_file";
        /// <summary>
        /// Cached name for the 'add_diff_hunks_into_diff_file' method.
        /// </summary>
        public static readonly StringName AddDiffHunksIntoDiffFile = "add_diff_hunks_into_diff_file";
        /// <summary>
        /// Cached name for the 'add_line_diffs_into_diff_hunk' method.
        /// </summary>
        public static readonly StringName AddLineDiffsIntoDiffHunk = "add_line_diffs_into_diff_hunk";
        /// <summary>
        /// Cached name for the 'popup_error' method.
        /// </summary>
        public static readonly StringName PopupError = "popup_error";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}

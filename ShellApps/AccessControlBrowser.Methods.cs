using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace AquariusShell.ShellApps
{

    /// <summary>
    /// Method implementations
    /// </summary>
    public partial class AccessControlBrowser
    {

        /// <summary>
        /// Load security principals for the specified path
        /// </summary>
        /// <param name="path">Path to the file or directory</param>
        private void LoadSecurityPrincipals(string path)
        {
            List<string> uniqueList = new();

            if (Directory.Exists(path))
            {
                _type = ObjectTypes.Directory;

                DirectoryInfo directory = new(path);
                DirectorySecurity sec = directory.GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
                IdentityReference? fileOwner = sec.GetOwner(typeof(SecurityIdentifier));
                if (fileOwner != null)
                {
                    try
                    {
                        NTAccount ownerAccount = (NTAccount)fileOwner.Translate(typeof(NTAccount));
                        tbCurrentOwnerPrincipal.Text = ownerAccount.Value;
                        tbCurrentOwnerPrincipal.Tag = fileOwner.Value;
                        btnTakeOwnership.Enabled = (fileOwner.Value != _currentUserSID.Value);
                    }
                    catch (IdentityNotMappedException)
                    {
                        tbCurrentOwnerPrincipal.Text = UNRESOLVED_ACCOUNT_NAME;
                        tbCurrentOwnerPrincipal.Tag = null;
                        btnTakeOwnership.Enabled = false;
                    }
                }

                foreach (FileSystemAccessRule rule in sec.GetAccessRules(includeExplicit: true, includeInherited: true, targetType: typeof(SecurityIdentifier)))
                {
                    string accountName;
                    try
                    {
                        NTAccount ruleAccount = (NTAccount)rule.IdentityReference.Translate(typeof(NTAccount));
                        accountName = ruleAccount.ToString();
                    }
                    catch (IdentityNotMappedException)
                    {
                        accountName = UNRESOLVED_ACCOUNT_NAME;
                    }

                    if (!uniqueList.Any(i => i.Equals(rule.IdentityReference.Value, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        uniqueList.Add(rule.IdentityReference.Value);

                        ListItem principal = new(accountName, rule.IdentityReference);
                        lbPrincipalsList.Items.Add(principal);
                    }
                }
            }
            else if (File.Exists(path))
            {
                _type = ObjectTypes.File;

                FileInfo file = new(path);
                FileSecurity sec = file.GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
                IdentityReference? fileOwner = sec.GetOwner(typeof(SecurityIdentifier));
                if (fileOwner != null)
                {
                    try
                    {
                        NTAccount ownerAccount = (NTAccount)fileOwner.Translate(typeof(NTAccount));
                        tbCurrentOwnerPrincipal.Text = ownerAccount.Value;
                        tbCurrentOwnerPrincipal.Tag = fileOwner.Value;
                        btnTakeOwnership.Enabled = (fileOwner.Value != _currentUserSID.Value);
                    }
                    catch (IdentityNotMappedException)
                    {
                        tbCurrentOwnerPrincipal.Text = UNRESOLVED_ACCOUNT_NAME;
                        tbCurrentOwnerPrincipal.Tag = null;
                        btnTakeOwnership.Enabled = false;
                    }
                }

                foreach (FileSystemAccessRule rule in sec.GetAccessRules(includeExplicit: true, includeInherited: true, targetType: typeof(SecurityIdentifier)))
                {
                    string accountName;
                    try
                    {
                        NTAccount ruleAccount = (NTAccount)rule.IdentityReference.Translate(typeof(NTAccount));
                        accountName = ruleAccount.ToString();
                    }
                    catch (IdentityNotMappedException)
                    {
                        accountName = UNRESOLVED_ACCOUNT_NAME;
                    }

                    if (!uniqueList.Any(i => i.Equals(rule.IdentityReference.Value, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        uniqueList.Add(rule.IdentityReference.Value);

                        ListItem principal = new(accountName, rule.IdentityReference);
                        lbPrincipalsList.Items.Add(principal);
                    }
                }
            }
            else
            {
                //TODO: Handle non-FS objects
            }
        }

        /// <summary>
        /// Clear all ACL related controls or reset them to their default states
        /// </summary>
        private void ClearAclControls()
        {
            tbCurrentOwnerPrincipal.Text = "";

            // resolver might have set this to underlined
            if (tbPrincipalNameRaw.Font.Underline)
            {
                tbPrincipalNameRaw.Font = new(tbPrincipalNameRaw.Font, FontStyle.Regular);
            }

            btnTakeOwnership.Enabled = false;
            lbPrincipalsList.Items.Clear();
            btnDeletePrincipal.Enabled = false;

            btnEditPrincipal.Enabled = false;
            tbPrincipalNameRaw.Text = "";
            btnResolvePrincipalNameRaw.Enabled = false;
            chkMarkPrincipalOwner.Enabled = false;

            foreach (FileSystemRights right in _enumRightsValues)
            {
                string controlName = RightControlName(right);
                if (controlName == string.Empty)
                {
                    return;
                }

                ((ComboBox)aclLayoutTable.Controls[$"aclType{controlName}"]!).SelectedIndex = -1;
                ((CheckBox)aclLayoutTable.Controls[$"di{controlName}"]!).Checked = false;
                ((CheckBox)aclLayoutTable.Controls[$"oi{controlName}"]!).Checked = false;
                ((CheckBox)aclLayoutTable.Controls[$"break{controlName}"]!).Checked = false;
            }

            btnSavePermissionEdits.Enabled = false;
            SetAclEditControls(readOnly: true);
        }

        /// <summary>
        /// Set the Acl editing controls as readonly or modifiable
        /// </summary>
        /// <param name="readOnly">True to set them to readonly!</param>
        private void SetAclEditControls(bool readOnly = true)
        {
            tbPrincipalNameRaw.Enabled = !readOnly;
            if (tbPrincipalNameRaw.Font.Underline)
            {
                tbPrincipalNameRaw.Font = new(tbPrincipalNameRaw.Font, FontStyle.Regular);
            }

            // btnResolvePrincipalNameRaw is enabled when user types into tbPrincipalNameRaw.
            if (lbPrincipalsList.SelectedItem == null)
            {
                chkMarkPrincipalOwner.Enabled = !readOnly;
            }
            else
            {
                chkMarkPrincipalOwner.Enabled = (!readOnly) || (((SecurityIdentifier)((ListItem)lbPrincipalsList.SelectedItem!).Value!) != _currentUserSID);
            }

            foreach (FileSystemRights right in _enumRightsValues)
            {
                string controlName = RightControlName(right);
                if (controlName == string.Empty)
                {
                    return;
                }

                ((ComboBox)aclLayoutTable.Controls[$"aclType{controlName}"]!).Enabled = !readOnly;
                ((CheckBox)aclLayoutTable.Controls[$"di{controlName}"]!).Enabled = !readOnly;
                ((CheckBox)aclLayoutTable.Controls[$"oi{controlName}"]!).Enabled = !readOnly;
                ((CheckBox)aclLayoutTable.Controls[$"break{controlName}"]!).Enabled = !readOnly;
            }
            btnSavePermissionEdits.Enabled = !readOnly;
        }


        /// <summary>
        /// Adds an item to the treeview
        /// </summary>
        /// <param name="parent">The parent node in the treeview. If NULL, adds to root</param>
        /// <param name="text">Caption text</param>
        /// <param name="imageKey">ImageKey -- image should already have been added</param>
        /// <param name="objectFullPath">Full path to the object (to set up the Tag property)</param>
        /// <returns>The added item for further use by the caller</returns>
        private FileSystemNode AddItemToTreeView(TreeNode? parent, string text, string imageKey, string objectFullPath)
        {
            FileSystemNode icon = new(text, imageKey, objectFullPath);
            if (parent == null)
            {
                tvFilesystemBrowser.Nodes.Add(icon);
            }
            else
            {
                FileSystemNode parentNode = (FileSystemNode)parent;
                if (!parentNode.IsAlreadyEnumerated)
                {
                    parentNode.Nodes.Clear();
                }

                parent.Nodes.Add(icon);
            }

            return icon;
        }


        /// <summary>
        /// Add the given icon to both large and small imagelists
        /// </summary>
        /// <param name="key">Image key</param>
        /// <param name="icon">The icon image to add</param>
        private void AddIconToImageLists(string key, Icon icon)
        {
            ilFileSystemImages.Images.Add(key, icon);
        }

        /// <summary>
        /// Returns the stringed equivalent of the FSR
        /// </summary>
        /// <param name="right">An FSR to resolve</param>
        /// <returns>Human-readable name</returns>
        private static bool IsConsideredRight(FileSystemRights right)
            => right switch
            {
                FileSystemRights.CreateDirectories
                or FileSystemRights.CreateFiles
                or FileSystemRights.ReadAttributes
                or FileSystemRights.ListDirectory
                or FileSystemRights.ReadPermissions 
                or FileSystemRights.Delete 
                or FileSystemRights.DeleteSubdirectoriesAndFiles 
                or FileSystemRights.ChangePermissions 
                or FileSystemRights.ExecuteFile 
                or FileSystemRights.WriteAttributes 
                or FileSystemRights.WriteExtendedAttributes => true,

                // we only do pure rights
                _ => false
            };

        /// <summary>
        /// Returns the suffix for the control names for the given FSR
        /// </summary>
        /// <param name="right">The FSR to get the suffix for</param>
        /// <returns>Control name suffix</returns>
        private static string RightControlName(FileSystemRights right)
            => right switch
            {
                FileSystemRights.CreateDirectories => "CreateDirectory",
                FileSystemRights.CreateFiles => "CreateFiles",
                FileSystemRights.ReadAttributes => "ReadAttributes",
                FileSystemRights.ReadExtendedAttributes => "ReadExtendedAttributes",    // *
                FileSystemRights.ListDirectory => "ListRead",
                FileSystemRights.ReadPermissions => "ReadPermissions",
                FileSystemRights.Delete => "Delete",
                FileSystemRights.DeleteSubdirectoriesAndFiles => "DeleteRecursive",     // *
                FileSystemRights.ChangePermissions => "ChangePermissions",
                FileSystemRights.ExecuteFile => "Execute",
                FileSystemRights.WriteAttributes => "WriteAttributes",
                FileSystemRights.WriteExtendedAttributes => "WriteExtendedAttributes",  // *

                // we only do pure rights
                _ => string.Empty
            };
    }

}
using System;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace AquariusShell.ShellApps
{
    /// <summary>
    /// Event handlers for the form
    /// </summary>
    public partial class AccessControlBrowser
    {

        /// <summary>
        /// (AfterSelect)
        /// Load the principals permissioned at this level and show them in the listbox
        /// </summary>
        private void TreeViewFileSystem_ShowPrincipalsOnItemClick(object sender, TreeViewEventArgs e)
        {
            // first, prevent the icon from changing!
            if ((!_disableTreeViewActivation) && (e.Node != null) && (e.Node is FileSystemNode node) && (_lastLoaded != node))
            {
                _lastLoaded = node;

                ClearAclControls();
                LoadSecurityPrincipals(node.AbsolutePath);
            }
        }
        private FileSystemNode? _lastLoaded = null;
        private bool _disableTreeViewActivation = false;

        /// <summary>
        /// (SelectedIndexChanged)
        /// Show the permissions in the add/edit groupbox, but in read-only mode. 
        /// </summary>
        private void ListboxPrincipals_ShowPermissionsReadonly(object sender, EventArgs e)
        {
            FileSystemNode node = (FileSystemNode)tvFilesystemBrowser.SelectedNode;

            _populatingPrincipalPermissions = true;

            btnDeletePrincipal.Enabled = true;
            btnEditPrincipal.Enabled = true;

            ListItem principalItem = (ListItem)lbPrincipalsList.SelectedItem!;

            tbPrincipalNameRaw.Text = principalItem.Caption;
            tbPrincipalNameRaw.Enabled = false;
            btnResolvePrincipalNameRaw.Enabled = false;

            SecurityIdentifier selectedPrincipalSID = (SecurityIdentifier)principalItem.Value!;
            chkMarkPrincipalOwner.Enabled = false;              // use Take ownership instead!

            AuthorizationRuleCollection acls;
            if (_type == ObjectTypes.Directory)
            {
                DirectoryInfo dir = new(node.AbsolutePath);
                acls = dir
                        .GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner)
                            .GetAccessRules(includeExplicit: true, includeInherited: true, targetType: typeof(SecurityIdentifier));
            }
            else // if (_type == ObjectTypes.File)
            {
                FileInfo file = new(node.AbsolutePath);
                acls = file
                        .GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner)
                            .GetAccessRules(includeExplicit: true, includeInherited: true, targetType: typeof(SecurityIdentifier));
            }

            foreach (FileSystemRights right in _enumRightsValues)
            {
                foreach (FileSystemAccessRule rule in acls)
                {
                    if ((rule.IdentityReference.Value == selectedPrincipalSID.Value) && (rule.FileSystemRights != FileSystemRights.Synchronize))
                    {
                        SetupAcl(rule, right);
                    }
                }
            }


            SetAclEditControls(readOnly: true);
            _populatingPrincipalPermissions = false;

            //
            // Helper function to set up the ACL controls
            //
            void SetupAcl(FileSystemAccessRule rule, FileSystemRights right)
            {
                string controlName = RightControlName(right);
                if (controlName == string.Empty)
                {
                    return;
                }

                string aclType = rule.AccessControlType.ToString();
                ComboBox cbAllowDeny = (ComboBox)aclLayoutTable.Controls[$"aclType{controlName}"]!;
                cbAllowDeny.SelectedIndex = -1;
                for (int i = 0; i < cbAllowDeny.Items.Count; i++)
                {
                    if (aclType.Equals((string)cbAllowDeny.Items[i]!))
                    {
                        cbAllowDeny.SelectedIndex = i;
                        break;
                    }
                }
                cbAllowDeny.Enabled = false;

                CheckBox di = (CheckBox)aclLayoutTable.Controls[$"di{controlName}"]!;
                di.Checked = rule.InheritanceFlags.HasFlag(InheritanceFlags.ContainerInherit);
                di.Enabled = false;

                CheckBox oi = (CheckBox)aclLayoutTable.Controls[$"oi{controlName}"]!;
                oi.Checked = rule.InheritanceFlags.HasFlag(InheritanceFlags.ContainerInherit);
                oi.Enabled = false;

                CheckBox breakDelete = (CheckBox)aclLayoutTable.Controls[$"break{controlName}"]!;
                breakDelete.Checked = false;
                breakDelete.Enabled = false;
            }
        }
        private bool _populatingPrincipalPermissions = false;

        /// <summary>
        /// ("Delete Principal" button click)
        /// Delete the selected principal -- lbPrincipalsList is SINGLE select mode only.
        /// </summary>
        private void ListboxPrincipals_DeleteSelectedPrincipal(object sender, EventArgs e)
        {
            FileSystemNode node = (FileSystemNode)tvFilesystemBrowser.SelectedNode;
            FileSystemSecurity fsSecurity;
            if (_type == ObjectTypes.Directory)
            {
                fsSecurity = (new DirectoryInfo(node.AbsolutePath)).GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
            }
            else // if (_type == ObjectTypes.File)
            {
                fsSecurity = (new FileInfo(node.AbsolutePath)).GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
            }

            if (lbPrincipalsList.SelectedItem != null)
            {
                // edit mode
                SecurityIdentifier selectedPrincipalSid = (SecurityIdentifier)((ListItem)lbPrincipalsList.SelectedItem!).Value!;
                foreach(FileSystemAccessRule rule in fsSecurity.GetAccessRules(includeExplicit: true, includeInherited: true, targetType: typeof(SecurityIdentifier)))
                {
                    if (rule.IdentityReference.Value == selectedPrincipalSid.Value)
                    {
                        //Question: Is this okay or should we do RemoveAccessRule() ?
                        fsSecurity.RemoveAccessRuleSpecific(rule);
                    }
                }

                try
                {
                    if (_type == ObjectTypes.Directory)
                    {
                        (new DirectoryInfo(node.AbsolutePath)).SetAccessControl((DirectorySecurity)fsSecurity);
                    }
                    else // if (_type == ObjectTypes.File)
                    {
                        (new FileInfo(node.AbsolutePath)).SetAccessControl((FileSecurity)fsSecurity);
                    }

                    MessageBox.Show(
                            "Permissions changed successfully.",
                            "Aquarius Shell",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                }
                catch
                {
                    MessageBox.Show(
                            "Permissions could not be set. " +
                                $"This is most likely because you do not have permissions to change permissions on '{node.Text}'.",
                            "Aquarius Shell",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                }

                ClearAclControls();
                LoadSecurityPrincipals(node.AbsolutePath);
            }
        }

        /// <summary>
        /// ("Add..." principal button click)
        /// Clear the controls below and turn on editability
        /// </summary>
        private void ListboxPrincipals_AddPrincipal(object sender, EventArgs e)
        {
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
            SetAclEditControls(readOnly: false);
        }

        /// <summary>
        /// ("Edit..." principal button click)
        /// Enable controls in the "Add/Edit principal and permissions" group box for editing)
        /// </summary>
        private void ListboxPrincipals_EditSelectedPrincipal(object sender, EventArgs e)
        {
            SetAclEditControls(false);
        }

        /// <summary>
        /// (Add/Edit principal name) changed, enable Resolve button if required.
        /// </summary>
        private void OwnerNameRaw_EnableResolveName(object sender, EventArgs e)
        {
            if (!_populatingPrincipalPermissions)
            {
                tbPrincipalNameRaw.Font = new(tbPrincipalNameRaw.Font, FontStyle.Regular);
                btnResolvePrincipalNameRaw.Enabled = (!string.IsNullOrWhiteSpace(tbPrincipalNameRaw.Text));
            }
        }

        /// <summary>
        /// Resolve the raw string name provided in tbPrincipalNameRaw to a SID. 
        /// SID is then stored in tbPrincipalNameRaw's Tag.
        /// </summary>
        private void ButtonRawPrincipal_ResolveName(object sender, EventArgs e)
        {
            NTAccount resolver = new(tbPrincipalNameRaw.Text);

            try
            {
                SecurityIdentifier sid = (SecurityIdentifier)resolver.Translate(typeof(SecurityIdentifier));
                tbPrincipalNameRaw.Font = new(tbPrincipalNameRaw.Font, System.Drawing.FontStyle.Underline);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resolving principal name: " + ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPrincipalNameRaw.Focus();
            }
        }

        /// <summary>
        /// Take ownership button clicked, set ownership of file/directory to current user
        /// </summary>
        private void TakeOwnership_Clicked(object sender, EventArgs e)
        {
            FileSystemNode? node = (FileSystemNode?)tvFilesystemBrowser.SelectedNode;
            if (node != null)
            {
                try
                {
                    if (Directory.Exists(node.AbsolutePath))
                    {
                        DirectoryInfo directory = new(node.AbsolutePath);
                        DirectorySecurity security = directory.GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
                        security.SetOwner(_currentUserSID);
                        directory.SetAccessControl(security);

                    }
                    else
                    {
                        FileInfo file = new(node.AbsolutePath);
                        FileSecurity security = file.GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
                        security.SetOwner(_currentUserSID);
                        file.SetAccessControl(security);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error setting security: " + ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Save the changes made in the  "Add/Edit principal and permissions" group box
        /// </summary>
        private void AddEditPrincipals_SaveChanges(object sender, EventArgs e)
        {
            SecurityIdentifier? sidOfPrincipalInTextbox = null;

            // First, resolve the account in the textbox
            try
            {
                NTAccount resolver = new(tbPrincipalNameRaw.Text);
                sidOfPrincipalInTextbox = (SecurityIdentifier)resolver.Translate(typeof(SecurityIdentifier));
                if (sidOfPrincipalInTextbox == null)
                {
                    throw new Exception($"Unable to validate account name '{tbPrincipalNameRaw.Text}'");
                }
                tbPrincipalNameRaw.Font = new(tbPrincipalNameRaw.Font, System.Drawing.FontStyle.Underline);
            }
            catch (IdentityNotMappedException)
            {
                // This one is OKAY because it refers to a system identity
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resolving principal name: " + ex.Message, "Aquarius Shell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPrincipalNameRaw.Focus();
                return;
            }

            FileSystemNode node = (FileSystemNode)tvFilesystemBrowser.SelectedNode;
            FileSystemSecurity fsSecurity;
            if (_type == ObjectTypes.Directory)
            {
                fsSecurity = (new DirectoryInfo(node.AbsolutePath)).GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
            }
            else // if (_type == ObjectTypes.File)
            {
                fsSecurity = (new FileInfo(node.AbsolutePath)).GetAccessControl(AccessControlSections.Access | AccessControlSections.Owner);
            }

            // are we in add or edit mode?
            if (lbPrincipalsList.SelectedItem != null)
            {
                // edit mode
                SecurityIdentifier selectedPrincipalSid = (SecurityIdentifier)((ListItem)lbPrincipalsList.SelectedItem!).Value!;
                foreach (FileSystemRights right in _enumRightsValues)
                {
                    FileSystemAccessRule? modifiedRule = GetAcl(right, selectedPrincipalSid);
                    if (modifiedRule != null)
                    {
                        fsSecurity.SetAccessRule(modifiedRule);
                    }
                }
            }
            else
            {
                if (sidOfPrincipalInTextbox != null)
                {
                    // add mode
                    foreach (FileSystemRights right in _enumRightsValues)
                    {
                        FileSystemAccessRule? modifiedRule = GetAcl(right, sidOfPrincipalInTextbox);
                        if (modifiedRule != null)
                        {
                            fsSecurity.SetAccessRule(modifiedRule);
                        }
                    }
                }
            }

            try
            {
                if (_type == ObjectTypes.Directory)
                {
                    (new DirectoryInfo(node.AbsolutePath)).SetAccessControl((DirectorySecurity)fsSecurity);
                }
                else // if (_type == ObjectTypes.File)
                {
                    (new FileInfo(node.AbsolutePath)).SetAccessControl((FileSecurity)fsSecurity);
                }

                MessageBox.Show(
                        "Permissions were set successfully. " +
                            $"You may see a different combination of permissions for '{tbPrincipalNameRaw.Text}'. " +
                                "This is because of the way permissions are distributed between existing, explicit, implicit, group-based permissions.",
                        "Aquarius Shell",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
            }
            catch
            {
                MessageBox.Show(
                        "Permissions could not be set. " +
                            $"This is most likely because you do not have permissions to set permissions on '{node.Text}'.",
                        "Aquarius Shell",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
            }

            ClearAclControls();
            LoadSecurityPrincipals(node.AbsolutePath);

            //
            // Helper function to retrieve an ACL for a specific right
            //
            FileSystemAccessRule? GetAcl(FileSystemRights right, IdentityReference identity)
            {
                string controlName = RightControlName(right);
                if (controlName == string.Empty)
                {
                    return null;
                }

                AccessControlType type = AccessControlType.Allow;
                InheritanceFlags inheritance = InheritanceFlags.None;
                PropagationFlags propagation = PropagationFlags.None;

                ComboBox cbAllowDeny = (ComboBox)aclLayoutTable.Controls[$"aclType{controlName}"]!;
                for (int i = 0; i < cbAllowDeny.Items.Count; i++)
                {
                    if (cbAllowDeny.SelectedIndex == i)
                    {
                        type = ((((string)cbAllowDeny.Items[i]!) == "Allow") ? AccessControlType.Allow : AccessControlType.Deny);
                        break;
                    }
                }

                CheckBox di = (CheckBox)aclLayoutTable.Controls[$"di{controlName}"]!;
                if (di.Checked)
                {
                    inheritance |= InheritanceFlags.ContainerInherit;
                }

                CheckBox oi = (CheckBox)aclLayoutTable.Controls[$"oi{controlName}"]!;
                if (oi.Checked)
                {
                    inheritance |= InheritanceFlags.ObjectInherit;
                }

                CheckBox brk = (CheckBox)aclLayoutTable.Controls[$"break{controlName}"]!;
                if (brk.Checked)
                {
                    propagation = PropagationFlags.NoPropagateInherit;
                }
                else
                {
                    propagation = PropagationFlags.InheritOnly;
                }


                return new FileSystemAccessRule(identity, right, inheritance, propagation, type);
            }
        }

        /// <summary>
        /// The form is first shown
        /// </summary>
        private void AccessControlBrowser_Shown(object sender, EventArgs e)
        {
            this.Text = Caption;

            //_disableTreeViewActivation = true;
            //tvFilesystemBrowser.Refresh();
            //_disableTreeViewActivation = false;

            // Also trigger loading the final leaf item's principals... 
            tvFilesystemBrowser.SelectedNode = _hierarchy.Last!.Value;
        }

        /// <summary>
        /// Close button clicked, close the dialog discarding any changes (confirm first)
        /// </summary>
        private void CloseDialog_Clicked(object sender, EventArgs e)
        {
            //TODO: Check!

            if (AppClosed != null)
            {
                AppClosed(typeof(AccessControlBrowser));
            }
            this.Close();
        }
    }
}
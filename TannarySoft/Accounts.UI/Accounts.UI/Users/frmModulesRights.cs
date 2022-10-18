﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmModulesRights : MetroForm
    {
        public frmModulesRights()
        {
            InitializeComponent();
        }

        private void frmModulesRights_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FillData();
        }
        private void FillData()
        {
            FillUsers();
            FillModules();
        }
        private void FillUsers()
        {
            var manager = new UsersBLL();
            List<UsersEL> list = manager.GetAllUsers();
            if (list.Count > 0)
            {
                list.Insert(0, new UsersEL() { UserId = Guid.Empty, UserName = "Select User" });
                
                cbxUsers.DataSource = list;
                cbxUsers.DisplayMember = "UserName";
                cbxUsers.ValueMember = "UserId";
                cbxUsers.SelectedIndex = 0;
            }
        }
        private void FillModules()
        {
            var manager = new ModulesBLL();
            List<ModulesEL> list = manager.GetAllModules();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    grdModules.Rows.Add();
                    grdModules.Rows[i].Cells["colIdModule"].Value = list[i].IdModule;
                    grdModules.Rows[i].Cells["colIdUserModule"].Value = Guid.Empty;
                    grdModules.Rows[i].Cells["colModuleName"].Value = list[i].ModuleName;
                }
            }
        }
        private void grdModules_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                e.Value = "Allow";
            }
        }

        private void cbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manager = new UserModulesBLL();
            if (cbxUsers.SelectedIndex > 0)
            {
                List<UserModulesEL> list = manager.GetUserModulesById(Validation.GetSafeGuid(cbxUsers.SelectedValue));
                if (list.Count > 0)
                {
                    grdModules.Rows.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        grdModules.Rows.Add();
                        grdModules.Rows[i].Cells["colIdModule"].Value = list[i].IdModule;
                        grdModules.Rows[i].Cells["colIdUserModule"].Value = list[i].IdUserModule;
                        grdModules.Rows[i].Cells["colModuleName"].Value = list[i].ModuleName;
                        if (list[i].IdUserModule != Guid.Empty)
                        {
                            grdModules.Rows[i].Cells["colModuleRight"].Value = true;
                        }
                        else
                        {
                            grdModules.Rows[i].Cells["colModuleRight"].Value = false;
                        }
                    }
                }
            }
            else if (grdModules.Rows.Count > 0)
            {
                grdModules.Rows.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<UserModulesEL> listUserModules = new List<UserModulesEL>();
            var manager = new UserModulesBLL();
            if (Validation.GetSafeGuid(cbxUsers.SelectedValue) != Guid.Empty)
            {
                for (int i = 0; i < grdModules.Rows.Count; i++)
                {
                    UserModulesEL oelUserModule = new UserModulesEL();
                    oelUserModule.UserId = Validation.GetSafeGuid(cbxUsers.SelectedValue);
                    oelUserModule.IdModule = Validation.GetSafeGuid(grdModules.Rows[i].Cells["colIdModule"].Value);
                    if(Validation.GetSafeGuid(grdModules.Rows[i].Cells["colIdUserModule"].Value) == Guid.Empty)
                    {
                        oelUserModule.IdUserModule = Guid.NewGuid();                        
                    }
                    else
                    {
                        oelUserModule.IdUserModule = Validation.GetSafeGuid(grdModules.Rows[i].Cells["colIdUserModule"].Value);
                    }
                    if (Validation.GetSafeBooleanNullable(grdModules.Rows[i].Cells["colModuleRight"].Value) == true)
                    {
                        oelUserModule.ModuleAction = "Assign";                        
                    }
                    else
                    {
                        oelUserModule.ModuleAction = "Remove";
                    }
                    oelUserModule.CreatedDateTime = DateTime.Now;
                    listUserModules.Add(oelUserModule);
                }
                if (manager.AssignModules(listUserModules).IsSuccess)
                {
                    MessageBox.Show("Rights Assigned For Selected Modules");
                    cbxUsers_SelectedIndexChanged(sender,e);
                }
            }
            else
            {
                MessageBox.Show("Select User First For Modules Rights");
            }
        }
    }
}

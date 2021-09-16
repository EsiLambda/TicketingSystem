using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DA;

namespace TicketingSystem
{
    public partial class frmTicketing : Form
    {
        private string emailAuth { get; set; }

        public frmTicketing()
        {
            InitializeComponent();
        }

        private void FRM_Load(object sender, EventArgs e)
        {
            pnlLogIn.BringToFront();
            pnlAdmin.SendToBack();
            
            DepartmentDetermination();
        }


        /// <summary>
        /// tool strip buttons of main menue for showing proper panel
        /// </summary>
        private void TSB_Registeration_Click(object sender, EventArgs e)
        {
            pnlLogIn.SendToBack();
            pnlUserRegisteration.BringToFront();
        }

        private void TSB_LogIn_Click(object sender, EventArgs e)
        {
            pnlUserRegisteration.SendToBack();
            pnlLogIn.BringToFront();
        }


        /// <summary>
        /// save the information of new user
        /// </summary>
        private void PB_Register_Click(object sender, EventArgs e)
        {
            try
            {
                BL_UserInformation user = new BL_UserInformation();

                user.firstName = txtFirstName.Text;
                user.lastName = txtLastName.Text;
                user.email = txtEmail.Text;
                user.password = txtPassword.Text;
                user.roleID = 1;

                if (user.BL_Insert() == true)
                {
                    MessageBox.Show("اطلاعات وارد شده با موفقیت ثبت شد");
                    
                    txtFirstName.Focus();

                    ClearRegisterationBlank();
                }
                else
                {
                    MessageBox.Show("اطلاعات وارد شده نامعتبر است");

                    txtFirstName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// log in as user or admin
        /// </summary>
        private void PB_LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                BL_UserAuthentication userAuth = new BL_UserAuthentication();

                userAuth.email = txtLogInUserName.Text;
                userAuth.password = txtLogInPassword.Text;

                txtLogInUserName.Focus();

                if (userAuth.UserLogIn() == true)
                {
                    txtLogInUserName.Text = "";
                    txtLogInPassword.Text = "";

                    if (userAuth.Role() == 1)
                    {
                        pnlUser.BringToFront();

                        emailAuth = userAuth.email;

                        DefaultUserInfo(emailAuth);

                        Refresh_DGV_UserTicket_UserManipulation_Private();
                        Refresh_DGV_AdminTicket_UserManipulation();

                        CellBackColor();
                    }
                    else
                    {
                        pnlAdmin.BringToFront();

                        Refresh_DGV_UserInfo_AdminManipulation();
                        Refresh_DGV_UserTicket_UserManipulation_Public();
                        Refresh_DGV_Department_AdminManipulation();
                    }
                }
                else
                    MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// tool strip buttons of admin panel to show proper panel
        /// </summary>
        private void TSB_UserUpdate_AdminManipulation(object sender, EventArgs e)
        {
            pnlAdminTicket_AdminManipulation.SendToBack();
            pnlDepartmentDefenition_AdminManipulation.SendToBack();
            pnlUserInfo_AdminManipulation.BringToFront();
        }

        private void TSB_UserTicket_AdminManipulation(object sender, EventArgs e)
        {
            pnlUserInfo_AdminManipulation.SendToBack();
            pnlDepartmentDefenition_AdminManipulation.SendToBack();
            pnlAdminTicket_AdminManipulation.BringToFront();
        }

        private void TSB_DepartmentDefenition_AdminManipulation(object sender, EventArgs e)
        {
            pnlUserInfo_AdminManipulation.SendToBack();
            pnlAdminTicket_AdminManipulation.SendToBack();
            pnlDepartmentDefenition_AdminManipulation.BringToFront();
        }


        /// <summary>
        /// save, update and delete department in admin panel
        /// </summary>
        private void BTN_SaveDepartment_AdminManipulation(object sender, EventArgs e)
        {
            try
            {
                BL_Department department = new BL_Department();

                department.departmentName = txtDepartmentName.Text;
                department.departmentDescription = txtDepartmentDescription.Text;

                department.BL_Insert();
                
                Refresh_DGV_Department_AdminManipulation();

                ClearDepartmentBlanks();

                DepartmentDetermination();

                CellBackColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BTN_UpdateDepartment_AdminManipulation(object sender, EventArgs e)
        {
            try
            {
                BL_Department department = new BL_Department();

                department.id = (Guid)dgvDepartment.CurrentRow.Cells[0].Value;
                department.departmentName = txtDepartmentName.Text;
                department.departmentDescription = txtDepartmentDescription.Text;

                department.BL_Update();
                
                Refresh_DGV_Department_AdminManipulation();

                ClearDepartmentBlanks();

                txtDepartmentName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BTN_DeleteDepartment_AdminManipulation(object sender, EventArgs e)
        {
            try
            {
                BL_Department department = new BL_Department();

                department.id = (Guid)dgvDepartment.CurrentRow.Cells[0].Value;

                department.BL_Delete();
                
                Refresh_DGV_Department_AdminManipulation();

                ClearDepartmentBlanks();

                txtDepartmentName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// update user in admin panel
        /// </summary>
        private void PB_UpdateUser_AdminManipulation(object sender, EventArgs e)
        {
            BL_UserUpdate userUpdate = new BL_UserUpdate();

            userUpdate.email = dgvUsersInfo_AdminManipulation.CurrentRow.Cells[0].Value.ToString();

            userUpdate.password = txtUserPassword_AdminManipulation.Text;

            userUpdate.BL_UpdateUser();

            if (userUpdate.BL_UpdateUser() == true)
            {
                Refresh_DGV_UserInfo_AdminManipulation();

                MessageBox.Show("اطلاعات کاربر با موفقیت بروز رسانی شد");
            }
            else
                MessageBox.Show("لطفا فیلد رمز عبور را پر کنید");
        }


        /// <summary>
        /// save admin answer for the user in dgvAdminTicket
        /// </summary>
        private void BTN_AdminAnswer_AdminManipulation(object sender, EventArgs e)
        {
            BL_AdminTicket adminTicket = new BL_AdminTicket();

            try
            {
                adminTicket.id = (Guid)dgvUserTicket_AdminManipulation.CurrentRow.Cells[0].Value;

                adminTicket.adminAnswer = txtAdminAnswer_AdminManipulation.Text;

                adminTicket.BL_SendAdminAnswer();
                
                ClearAdminTicketBlanks();

                txtAdminAnswer_AdminManipulation.Focus();

                CellBackColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// tool strip buttons in user panel to show proper panel
        /// </summary>
        private void TSB_NewTicket(object sender, EventArgs e)
        {
            dgvUserTicket.BringToFront();
            pnlButtons.Show();
            txtDescription_UserManipulation.ReadOnly = false;
        }

        private void TSB_ShowTicketAnswers(object sender, EventArgs e)
        {
            dgvAdminTicket.BringToFront();
            pnlButtons.Hide();
            txtDescription_UserManipulation.ReadOnly = true;

            CellBackColor();
        }


        /// <summary>
        /// save, update and delete user
        /// </summary>
        private void BTN_SaveUserTicket_Click(object sender, EventArgs e)
        {
            try
            {
                BL_UserTicket userTicket = new BL_UserTicket();
                BL_AdminTicket adminTicket = new BL_AdminTicket();

                FillUserTicketInfo(userTicket);
                userTicket.BL_Insert();

                FillAdminTicketInfo(adminTicket, userTicket);
                adminTicket.BL_Insert();

                ClearUserTicketBlanks();

                MessageBox.Show("تیکت با موفقیت ذخیره شد");

                Refresh_DGV_UserTicket_UserManipulation_Private();
                Refresh_DGV_AdminTicket_UserManipulation();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BTN_UpdateUserTicekt_Click(object sender, EventArgs e)
        {
            try
            {
                BL_UserTicket userTicket = new BL_UserTicket();
                BL_AdminTicket adminTicket = new BL_AdminTicket();

                Guid id = (Guid)dgvUserTicket.CurrentRow.Cells[0].Value;
                FillUserTicketInfo(userTicket);

                userTicket.BL_Update(id);
                adminTicket.BL_UpdateAdminTicket(id);
                
                Refresh_DGV_UserTicket_UserManipulation_Private();
                Refresh_DGV_AdminTicket_UserManipulation();

                MessageBox.Show("تیکت با موفقیت بروز رسانی شد");

                ClearUserTicketBlanks();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BTN_DeleteUserTicket_Click(object sender, EventArgs e)
        {
            try
            {
                BL_UserTicket userTicket = new BL_UserTicket();

                Guid id = (Guid)dgvUserTicket.CurrentRow.Cells[0].Value;

                DGV_CellMouse_Click(null, null);

                userTicket.BL_Delete(id);
                
                Refresh_DGV_UserTicket_UserManipulation_Private();
                Refresh_DGV_AdminTicket_UserManipulation();

                ClearUserTicketBlanks();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }








        /// <summary>
        /// helper methods
        /// </summary>
        private void ClearRegisterationBlank()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private void DefaultUserInfo(string email)
        {
            BL_UserTicket defaultInfo = new BL_UserTicket();

            txtFirstName_UserManipulation.Text = defaultInfo.BL_SelectDeafaultInfo(email)[0].FirstName;
            txtLastName_UserManipulation.Text = defaultInfo.BL_SelectDeafaultInfo(email)[0].LastName;
            txtEmail_UserManipulation.Text = defaultInfo.BL_SelectDeafaultInfo(email)[0].Email;
        }

        private void ClearDepartmentBlanks()
        {
            txtDepartmentName.Text = "";
            txtDepartmentDescription.Text = "";
        }

        private void DGV_Department_CellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtDepartmentName.Text = dgvDepartment.CurrentRow.Cells[1].Value.ToString();
            txtDepartmentDescription.Text = dgvDepartment.CurrentRow.Cells[2].Value.ToString();
        }

        private void ClearAdminTicketBlanks()
        {
            txtUserMessage_AdminManipulation.Text = "";
            txtAdminAnswer_AdminManipulation.Text = "";
        }

        private void DGV_UserTicket_CellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtUserMessage_AdminManipulation.Text = dgvUserTicket_AdminManipulation.CurrentRow.Cells[8].Value.ToString();
        }

        private void ClearUserBlanks()
        {
            txtTopic_UserManipulation.Text = "";
            txtDescription_UserManipulation.Text = "";
        }

        private void DGV_UserInfo_CellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtUserFirstName_AdminManipulation.Text =
                dgvUsersInfo_AdminManipulation.CurrentRow.Cells[1].Value.ToString();
            txtUserLastName_AdminManipulation.Text =
                dgvUsersInfo_AdminManipulation.CurrentRow.Cells[2].Value.ToString();
        }

        private void FillUserTicketInfo(BL_UserTicket tick)
        {
            tick.email = txtEmail_UserManipulation.Text;
            tick.topic = txtTopic_UserManipulation.Text;
            tick.importance = cmbImportance_UserManipulation.Text;
            tick.section = cmbDepartment_UserManipulation.Text;
            tick.description = txtDescription_UserManipulation.Text;
        }

        private void FillAdminTicketInfo(BL_AdminTicket adminTicket, BL_UserTicket userTicket)
        {
            adminTicket.userTicketID = userTicket.BL_GetUserID();
            adminTicket.topic = userTicket.topic;
            adminTicket.section = userTicket.section;
            adminTicket.status = "پاسخ داه نشده";
        }
        
        private void ClearUserTicketBlanks()
        {
            txtTopic_UserManipulation.Text = "";
            cmbDepartment_UserManipulation.Text = "";
            cmbImportance_UserManipulation.Text = "";
            txtDescription_UserManipulation.Text = "";
        }

        private void DGV_CellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtTopic_UserManipulation.Text = dgvUserTicket.CurrentRow.Cells[4].Value.ToString();
            cmbDepartment_UserManipulation.Text = dgvUserTicket.CurrentRow.Cells[5].Value.ToString();
            cmbImportance_UserManipulation.Text = dgvUserTicket.CurrentRow.Cells[6].Value.ToString();
            txtDescription_UserManipulation.Text = dgvUserTicket.CurrentRow.Cells[8].Value.ToString();
        }

        private void DGV_AdminTicket_CellMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvAdminTicket.CurrentRow.Cells[7].Value != null ||
                    dgvAdminTicket.CurrentRow.Cells[7].Value != DBNull.Value)
                    txtDescription_UserManipulation.Text = dgvAdminTicket.CurrentRow.Cells[7].Value.ToString();
            }
            catch
            {
                MessageBox.Show("به پیام شما هنوز پاسخی داده نشده است");
                txtTopic_UserManipulation.Text = "";
                txtDescription_UserManipulation.Text = "";
            }
        }

        private void DepartmentDetermination()
        {
            BL_Department department = new BL_Department();

            var departmentArr = department.BL_SelectForCombo();

            foreach (var dep in departmentArr)
            {
                cmbDepartment_UserManipulation.Items.Remove(dep);
            }

            foreach (var dep in departmentArr)
            {
                cmbDepartment_UserManipulation.Items.Add(dep);
            }
        }

        private void CellBackColor()
        {
            try
            {
                foreach (DataGridViewRow row in dgvAdminTicket.Rows)
                {
                    if (row.Cells[4].Value.ToString() == "پاسخ داده شده")
                    {
                        row.Cells[4].Style.BackColor = Color.Green;
                        row.Cells[4].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells[4].Style.BackColor = Color.Red;
                        row.Cells[4].Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Refresh_DGV_UserTicket_UserManipulation_Private()
        {
            BL_UserTicket refresh = new BL_UserTicket();
            dgvUserTicket.DataSource = refresh.BL_ShowUserTicket(emailAuth);
        }

        private void Refresh_DGV_UserTicket_UserManipulation_Public()
        {
            BL_UserTicket refresh = new BL_UserTicket();
            dgvUserTicket_AdminManipulation.DataSource = refresh.BL_ShowAllTickets();
        }

        private void Refresh_DGV_AdminTicket_UserManipulation()
        {
            BL_AdminTicket refresh = new BL_AdminTicket();
            dgvAdminTicket.DataSource = refresh.BL_ShowAdminTickets(emailAuth);
        }

        private void Refresh_DGV_UserInfo_AdminManipulation()
        {
            BL_UserUpdate refresh = new BL_UserUpdate();
            dgvUsersInfo_AdminManipulation.DataSource = refresh.BL_ShowUpdatedUsers();
        }

        private void Refresh_DGV_Department_AdminManipulation()
        {
            BL_Department refresh = new BL_Department();
            dgvDepartment.DataSource = refresh.BL_ShowAllDepartments();
        }
    }
}
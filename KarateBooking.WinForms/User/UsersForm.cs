using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Commands.Delete;
using KarateBooking.Application.CQRS.User.Commands.Delete;
using KarateBooking.Application.CQRS.User.Queries.GetList;
using KarateBooking.Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateBooking.WinForms.User
{
    public partial class UsersForm : Form
    {

        private readonly IQueryHandler<GetUserListQuery, List<UserDto>> _getUserList;
        private readonly ICommandHandler<DeleteUserCommand, bool> _deleteHandler;
        private readonly Func<UserDto?, UserFormDialog> _createUserForm;
        public UsersForm(IQueryHandler<GetUserListQuery, List<UserDto>> getUserList, ICommandHandler<DeleteUserCommand, bool> deleteHandler,
            Func<UserDto?, UserFormDialog> createUserForm)
        {
            InitializeComponent();
            _getUserList = getUserList;
            _createUserForm = createUserForm;
            _deleteHandler = deleteHandler;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.MultiSelect = false;
            this.Load += UsersForm_Load!;

        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var users = await _getUserList.Handle(new GetUserListQuery());
                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



       

        private async void btnNewUser_Click_1(object sender, EventArgs e)
        {
            using var form = _createUserForm(null);

            if (form.ShowDialog() == DialogResult.OK)
                await LoadData();
        }

        private async void dgvUsers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var clickedUser = (UserDto)dgvUsers.Rows[e.RowIndex].DataBoundItem;
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Update")
            {
                

                using var form = _createUserForm(clickedUser);
                if (form.ShowDialog() == DialogResult.OK)
                    await LoadData();
            }
            else if (dgvUsers.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Da li ste sigurni da zelite izbrisati ovog korisnika"
                   , "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    await _deleteHandler.Handle(new DeleteUserCommand { Id = clickedUser.Id });
                    await LoadData();

                }
            }
           

           
        }
    }
}

using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.User.Commands.Create;
using KarateBooking.Application.CQRS.User.Commands.Update;
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
    public partial class UserFormDialog : Form
    {
        private readonly ICommandHandler<CreateUserCommand, UserDto> _createHandler;
        private readonly ICommandHandler<UpdateUserCommand, UserDto> _updateHandler;
        private readonly int? _userId;
        public UserFormDialog(ICommandHandler<CreateUserCommand, UserDto> createHandler,
            ICommandHandler<UpdateUserCommand, UserDto> updateHandler,
            UserDto? existingUser = null)
        {
            InitializeComponent();
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            if (existingUser != null)
            {
                _userId = existingUser.Id;
                Text = "Izmjena korisnika";
                txtName.Text = existingUser.FullName;
                txtEmail.Text = existingUser.Email;
                txtPhoneNumber.Text = existingUser.PhoneNumber;
            }
            else
            {
                Text = "Novi korisnik";
            }

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private async void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_userId == null)
                {
                    await _createHandler.Handle(new CreateUserCommand
                    {
                        FullName = txtName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    });
                }
                else
                {
                    await _updateHandler.Handle(new UpdateUserCommand
                    {
                        Id = _userId.Value,
                        FullName = txtName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    });
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

       
    }


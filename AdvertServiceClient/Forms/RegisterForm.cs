using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdvertServiceClient
{
    public partial class RegisterForm : Form
    {
        private readonly DatabaseHelper _dbHelper;

        public RegisterForm()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            LoadLocations();
        }

        private void LoadLocations()
        {
            try
            {
                SqlParameter[] parameters = Array.Empty<SqlParameter>();
                DataTable locations = _dbHelper.ExecuteStoredProcedure("sp_GetAllLocations", parameters);

                cmbLocation.Items.Clear();
                cmbLocation.Items.Add(new ComboBoxItem("Не указано", null));

                foreach (DataRow row in locations.Rows)
                {
                    string city = row["City"].ToString();
                    string ZipCode = row["ZipCode"].ToString();
                    string region = row["Region"] != DBNull.Value ? row["Region"].ToString() : "";

                    string displayText = !string.IsNullOrEmpty(region)
                        ? $"{city}, {region}, {ZipCode}"
                        : $"{city}, {ZipCode}";

                    cmbLocation.Items.Add(new ComboBoxItem(displayText, row["LocationID"]));
                }

                cmbLocation.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке местоположений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // Телефон не обязателен

            string pattern = @"^\+?[0-9]\d{1,14}$";
            return Regex.IsMatch(phone, pattern);
        }

        private bool ValidatePassword(string password)
        {
            return password.Length >= 5;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Все обязательные поля должны быть заполнены", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Валидация email
            if (!ValidateEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Введите корректный email адрес", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Валидация телефона
            if (!ValidatePhone(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Введите корректный номер телефона", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // Валидация пароля
            if (!ValidatePassword(txtPassword.Text))
            {
                MessageBox.Show("Пароль должен содержать не менее 5 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            // Получаем выбранное местоположение
            object locationId = (cmbLocation.SelectedItem as ComboBoxItem)?.Value ?? DBNull.Value;

            try
            {
                // Создаем параметры
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", txtUsername.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@Password", txtPassword.Text),
                    new SqlParameter("@Phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                    new SqlParameter("@LocationID", locationId),
                    new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

                // Выполняем процедуру
                int affectedRows = _dbHelper.ExecuteStoredProcedureNonQuery("sp_RegisterUser", parameters);


                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {   if (ex.Message == "Error executing stored procedure sp_RegisterUser: Вставка или обновление столбца конфликтует с правилом, наложенным предыдущей инструкцией CREATE RULE. Выполнение этой инструкции " +
                    "прервано. Конфликт произошел в базе данных \"Advert_service\", таблице \"dbo.User\", столбце \"Phone\".") 
                {
                    MessageBox.Show($"Номер телефона не соответствует формату(+7(8) ххх ххх хх хх )", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else 

                if (ex.Message == "Error executing stored procedure " +
                    "sp_RegisterUser: Имя пользователя уже занято")
                {
                    MessageBox.Show($"Имя пользователя уже занято", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else

                if (ex.Message == "Error executing stored procedure " +
                    "sp_RegisterUser: Email уже зарегистрирован")
                {
                    MessageBox.Show("Уже существует аккаунт с такой почтой", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Close();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboBoxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
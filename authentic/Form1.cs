using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using authentic.Properties;

namespace authentic
{
    public partial class Form1 : Form
    {

        private Form2 about = new Form2();
        private Form3 authorization = new Form3();
        private Form4 registration = new Form4();
        private Form5 deletion = new Form5();
        private Form6 userInfo = new Form6();
        private Form7 change = new Form7();

        private string currentUser;
        private const string adminHash = "b59c67bf196a4758191e42f76670ceba";
        Dictionary<string, string> usersDictionary = new Dictionary<string, string>();
        BinaryFormatter formatter = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
            Block();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            //все очистить
            DeactivateUsers();
            listBoxUsers.Items.Clear();
            usersDictionary.Clear();
            buttonLogIn.Enabled = false;

            //загрузить из файла пользователей
            LoadUsersFromFileToDictionary();
            //загрузить из словаря на форму
            LoadUsersFromDictionaryToListBox();
            OwnedForms();
        }

        private void Block()
        {
            if (IsAdmin())
            {
                //bool flag = ToolStripMenuItemBlock.Enabled;
                //ToolStripMenuItemBlock.Enabled = true;
                //int cf = (int)Settings.Default["Blocking"];
                if ((int)Settings.Default["Blocking"] == 1)
                {
                    
                    ToolStripMenuItemBlock.Text = "Заблокировать";

                }
                if ((int)Settings.Default["Blocking"] == 0)
                {
                    ToolStripMenuItemBlock.Text = "Разблокировать";

                }
                //ToolStripMenuItemBlock.Enabled = flag;
            }
        }

        private void OwnedForms()
        {
            AddOwnedForm(about);
            AddOwnedForm(authorization);
            AddOwnedForm(registration);
            AddOwnedForm(deletion);
            AddOwnedForm(userInfo);
            AddOwnedForm(change);
        }
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }
        private void LoadUsersFromFileToDictionary()
        {
            usersDictionary.Clear();
            if (System.IO.File.Exists("users.dat"))
            {
                using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                {
                    Dictionary<string, string> deserilizeUsers = (Dictionary<string, string>)formatter.Deserialize(fs);

                    foreach (KeyValuePair<string, string> user in deserilizeUsers)
                    {
                        usersDictionary.Add(user.Key, user.Value);
                    }
                }
            }
            if (!ContainedAdmin())
            {
                usersDictionary.Add("Admin", adminHash);
            } 
        }
        private bool ContainedAdmin()
        {
            foreach (KeyValuePair<string, string> user in usersDictionary)
            {
                if (user.Key == "Admin")
                    return true;
            }
            return false;
        }
        private void LoadUsersFromDictionaryToListBox()
        {
            listBoxUsers.Items.Clear();
            foreach (KeyValuePair<string, string> user in usersDictionary)
            {
                listBoxUsers.Items.Add(user.Key);
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if ((int)Settings.Default["Blocking"] == 1)
            {
                authorization.SelectedUser = listBoxUsers.Items[listBoxUsers.SelectedIndex].ToString();
                if (authorization.ShowDialog() == DialogResult.OK)
                {
                    AutorizeUser(authorization.EnteredLogin, authorization.EnteredPassword);
                }
            }
            else if (((int)Settings.Default["Blocking"] == 0) && (listBoxUsers.Items[listBoxUsers.SelectedIndex].ToString() == "Admin"))
            {
                authorization.SelectedUser = "Admin";
                if (authorization.ShowDialog() == DialogResult.OK)
                {
                    AutorizeUser(authorization.EnteredLogin, authorization.EnteredPassword);
                }
            }
            else
            {
                MessageBox.Show("Сервис недоступен", "Нет доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void AutorizeUser(string enteredLogin, string enteredPassword)
        {
            string hash = GetHash(enteredPassword);
            if (IsAdmin())
            {
                if (hash == adminHash)
                {
                    GetSuccessfulUserMessage();
                    userInfo.CurrentUserInfo = GetCurrentUserInfo();
                    if (userInfo.ShowDialog() == DialogResult.OK)
                    {
                        ActivateAdminMode();
                        currentUser = "Admin";
                    }
                }
                else
                    GetInvalidUserMessage();
            }
            else
            {
                if (hash == usersDictionary[enteredLogin])
                {
                    GetSuccessfulUserMessage();
                    userInfo.CurrentUserInfo = GetCurrentUserInfo();
                    if (userInfo.ShowDialog() == DialogResult.OK)
                    {
                        ActivateUserMode();
                        currentUser = enteredLogin;
                    }
                }
                else
                    GetInvalidUserMessage();
            }
        }

        private void ActivateAdminMode()
        {
            ToolStripMenuItemCreate.Enabled = true;
            ToolStripMenuItemBlock.Enabled = true;
            ToolStripMenuItemDelete.Enabled = true;
            ToolStripMenuItemChange.Enabled = false;
        }

        private void ActivateUserMode()
        {
            ToolStripMenuItemCreate.Enabled = false;
            ToolStripMenuItemBlock.Enabled = false;
            ToolStripMenuItemDelete.Enabled = false;
            ToolStripMenuItemChange.Enabled = true;
        }

        private void GetInvalidUserMessage()
        {
            MessageBox.Show("Неверно указано имя и пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void GetSuccessfulUserMessage()
        {
            MessageBox.Show("Авторизация прошла успешно","Результат авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetCurrentUserInfo()
        {
            string result = "";
            var Name = WindowsIdentity.GetCurrent().Name;
            var Token = WindowsIdentity.GetCurrent().Token;
            var IsAuthenticated = WindowsIdentity.GetCurrent().IsAuthenticated;
            var SID = WindowsIdentity.GetCurrent().User;
            var ISGuest = WindowsIdentity.GetCurrent().IsGuest;
            var IsSystem = WindowsIdentity.GetCurrent().IsSystem;
            var IsAnonymous = WindowsIdentity.GetCurrent().IsAnonymous;
            var Groups = "";
            foreach (var item in WindowsIdentity.GetCurrent().Groups)
            {
                Groups += Environment.NewLine + item.Value;
            }

            result = 
                "Имя пользователя: " + Name + Environment.NewLine + 
                "Аутентифицирован: " + IsAuthenticated + Environment.NewLine +
                "Запись системная: " + IsSystem + Environment.NewLine +
                "Запись гостевая: " + IsAuthenticated + Environment.NewLine +
                "Идентитификатор безопасности: " + Environment.NewLine + SID + Environment.NewLine +
                "Токен: " + Token + Environment.NewLine +
                "Группы Windows: " + Groups;
            return result;
        }

        private void DeactivateUsers()
        {
            ToolStripMenuItemCreate.Enabled = false;
            ToolStripMenuItemBlock.Enabled = false;
            ToolStripMenuItemDelete.Enabled = false;
            ToolStripMenuItemChange.Enabled = false;
        }

        private string GetHash(string str)
        {
            //переводим строку в байт-массим
            Byte[] strBytes = Encoding.Default.GetBytes(str);
            //создаем объект для получения средст шифрования
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //вычисляем хеш-представление в байтах
            Byte[] hashBytes = md5.ComputeHash(strBytes);
            //формируем одну цельную строку из массива
            string hash = string.Empty;
            foreach (var item in hashBytes)
            {
                hash += string.Format("{0:x2}", item);
            }
            return hash;
        }

        private void RewritePasswordFile()
        {
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, usersDictionary);
            }
        }

        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            if (registration.ShowDialog() == DialogResult.OK)
            {
                //проверка уникальности нового имени пользователя
                foreach (string key in usersDictionary.Keys)
                {
                    if (registration.Login == key)
                    {
                        MessageBox.Show("Такой пользователь уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                usersDictionary.Add(registration.Login, GetHash(registration.Password));
                RewritePasswordFile();
                listBoxUsers.Items.Clear();
                LoadUsersFromFileToDictionary();
                LoadUsersFromDictionaryToListBox();
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            deletion.Users.Clear();
            //загрузка пользователей на форму
            foreach (KeyValuePair<string, string> item in usersDictionary)
            {
                deletion.Users.Add(item.Key);
            }
            if (deletion.ShowDialog() == DialogResult.OK)
            {
                string s = String.Format("Вы действительно хотите удалить пользователя {0}?", deletion.RemoteUser);
                DialogResult res = new DialogResult();
                res = MessageBox.Show(s,
                                            "Выход из программы",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    usersDictionary.Remove(deletion.RemoteUser);
                    //пересериализовать
                    RewritePasswordFile();
                    LoadUsersFromFileToDictionary();
                    LoadUsersFromDictionaryToListBox();
                }
                else
                { return; }
            }
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            usersDictionary.Remove("Admin");
            RewritePasswordFile();
        }
        private bool IsAdmin()
        {
            AppDomain myDomain = Thread.GetDomain();
            myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
            WindowsIdentity identity = (WindowsIdentity)myPrincipal.Identity;
            return myPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userName = "";
            try
            {
                userName = listBoxUsers.Items[listBoxUsers.SelectedIndex].ToString();
            }
            catch (Exception ex)
            { }
            if ((IsAdmin() && userName == "Admin")
                 || (!IsAdmin() && !(userName == "Admin")))
            {
                buttonLogIn.Enabled = true;
            }
            else
            {
                buttonLogIn.Enabled = false;
            }
        }

        private void ToolStripMenuItemChange_Click(object sender, EventArgs e)
        {
            if (change.ShowDialog() == DialogResult.OK)
            {
                if (GetHash(change.OldPassword) != usersDictionary[currentUser])
                {
                    string str = String.Format("Неверно указан старый пароль пользователя {0}", currentUser);
                    MessageBox.Show(str, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    usersDictionary.Remove(currentUser);
                    usersDictionary.Add(currentUser, GetHash(change.NewPassword));
                    RewritePasswordFile();
                    LoadUsersFromFileToDictionary();
                    LoadUsersFromDictionaryToListBox();
                    string str = String.Format("Пароль пользователя {0} изменен", currentUser);
                    MessageBox.Show(str, "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ToolStripMenuItemBlock_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItemBlock.Text == "Заблокировать")
            {
                ToolStripMenuItemBlock.Text = "Разблокировать";
                Settings.Default["Blocking"] = 0;
                Settings.Default.Save();
                //ToolStripMenuItemBlock.Text = Settings.Default.ToString();
            }
            else if(ToolStripMenuItemBlock.Text == "Разблокировать")
            {
                ToolStripMenuItemBlock.Text = "Заблокировать";
                Settings.Default["Blocking"] = 1;
                Settings.Default.Save();
                //ToolStripMenuItemBlock.Text = Settings.Default.ToString();
            }
            
            
        }
    }
}

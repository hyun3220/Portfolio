using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace DominoLibrary
{
    public partial class LibraryManagement : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private Point mousePoint;

        ///<Summary>
        /// Gets the answer
        ///</Summary>
        
        public LibraryManagement()
        {
            InitializeComponent();

            // 폼의 전체적인 디자인 (모서리 둥글게) 설정
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panNav.Height = btnSearch.Height;
            panNav.Top = btnSearch.Top;
            panNav.Left = btnSearch.Left;
        }

        private void LibraryManagement_Load(object sender, EventArgs e)
        {
            // 로그인을 한 회원의 이름을 왼쪽 상단에 출력
            if(LoginForm.UserName == null)
            {
                this.lblUserName.Text = "침입자";  // 로그인 하지 않고 비정상적인 접근 시 처리
            }
            else
            {
                this.lblUserName.Text = LoginForm.UserName.ToString() + "님";
            }

            // 관리자 계정, 사용자 계정 로그인 시 처리
            if(LoginForm.userID.ToString() == "admin")
            {
                this.btnBookManager.Visible = true;
                this.btnLibManager.Visible = true;
                this.btnUserManager.Visible = true;
            }
            else
            {
                this.btnBookManager.Visible = false;
                this.btnLibManager.Visible = false;
                this.btnUserManager.Visible = false;
            }
        }

        // 도서관 관리 버튼 클릭 처리
        private void btnLibManager_Click(object sender, EventArgs e)
        {
            // 대시보드 메뉴 클릭시 도서관 관리 폼이 오른쪽에 바로 뜨도록 작성

            this.lblTitle.Text = "Domino Library";

            // 버튼 클릭 시 기존에 출력되었던 판넬 모두 지움
            this.pnLibFormLoad.Controls.Clear();
            mainForm mForm = new mainForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };    // 판넬에 불러올 폼을 객체 생성
            mForm.FormBorderStyle = FormBorderStyle.None;   // 불러올 폼의 border를 None으로 설정
            this.pnLibFormLoad.Controls.Add(mForm);         // Panel에 생성한 보여질 폼을 Add
            mForm.Show();   // 화면 출력 처리

            panNav.Height = btnLibManager.Height;
            panNav.Top = btnLibManager.Top;
            panNav.Left = btnLibManager.Left;
            btnLibManager.BackColor = Color.AliceBlue; // 대시보드 왼쪽 panel의 버튼 클릭시 버튼 배경을 오른쪽 메인 화면 배경색과 동일하게 지정
            
            btnBookManager.BackColor = Color.FromArgb(196, 222, 255);
            btnUserManager.BackColor = Color.FromArgb(196, 222, 255);
            btnConfig.BackColor = Color.FromArgb(196, 222, 255);
            btnBreak.BackColor = Color.FromArgb(196, 222, 255);
            btnSearch.BackColor = Color.FromArgb(196, 222, 255);
        }

        private void btnBookManager_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "Book Management";

            this.pnLibFormLoad.Controls.Clear();
            BookManagerForm bookMForm = new BookManagerForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            bookMForm.FormBorderStyle = FormBorderStyle.None;
            this.pnLibFormLoad.Controls.Add(bookMForm);
            bookMForm.Show();

            panNav.Height = btnBookManager.Height;
            panNav.Top = btnBookManager.Top;
            btnBookManager.BackColor = Color.AliceBlue;

            btnUserManager.BackColor = Color.FromArgb(196, 222, 255);
            btnLibManager.BackColor = Color.FromArgb(196, 222, 255);
            btnConfig.BackColor = Color.FromArgb(196, 222, 255);
            btnBreak.BackColor = Color.FromArgb(196, 222, 255);
            btnSearch.BackColor = Color.FromArgb(196, 222, 255);
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "User Management";

            this.pnLibFormLoad.Controls.Clear();
            userManagerForm userMForm = new userManagerForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            userMForm.FormBorderStyle = FormBorderStyle.None;
            this.pnLibFormLoad.Controls.Add(userMForm);
            userMForm.Show();

            panNav.Height = btnUserManager.Height;
            panNav.Top = btnUserManager.Top;
            btnUserManager.BackColor = Color.AliceBlue;

            btnLibManager.BackColor = Color.FromArgb(196, 222, 255); 
            btnBookManager.BackColor = Color.FromArgb(196, 222, 255);
            btnConfig.BackColor = Color.FromArgb(196, 222, 255);
            btnBreak.BackColor = Color.FromArgb(196, 222, 255);
            btnSearch.BackColor = Color.FromArgb(196, 222, 255);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "User Cofig";

            this.pnLibFormLoad.Controls.Clear();
            userConfig userConfigForm = new userConfig() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            userConfigForm.FormBorderStyle = FormBorderStyle.None;
            this.pnLibFormLoad.Controls.Add(userConfigForm);
            userConfigForm.Show();

            panNav.Height = btnConfig.Height;
            panNav.Top = btnConfig.Top;
            btnConfig.BackColor = Color.AliceBlue;

            btnLibManager.BackColor = Color.FromArgb(196, 222, 255);
            btnUserManager.BackColor = Color.FromArgb(196, 222, 255);
            btnBookManager.BackColor = Color.FromArgb(196, 222, 255);
            btnBreak.BackColor = Color.FromArgb(196, 222, 255);
            btnSearch.BackColor = Color.FromArgb(196, 222, 255);
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "Delete User Account";

            this.pnLibFormLoad.Controls.Clear();
            DeleteAccountForm deleteAccountForm = new DeleteAccountForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            deleteAccountForm.FormBorderStyle = FormBorderStyle.None;
            this.pnLibFormLoad.Controls.Add(deleteAccountForm);
            deleteAccountForm.Show();

            panNav.Height = btnBreak.Height;
            panNav.Top = btnBreak.Top;
            panNav.Left = btnBreak.Left;
            btnBreak.BackColor = Color.AliceBlue;

            btnLibManager.BackColor = Color.FromArgb(196, 222, 255);
            btnUserManager.BackColor = Color.FromArgb(196, 222, 255);
            btnBookManager.BackColor = Color.FromArgb(196, 222, 255);
            btnConfig.BackColor = Color.FromArgb(196, 222, 255);
            btnSearch.BackColor = Color.FromArgb(196, 222, 255);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "Searching...";

            this.pnLibFormLoad.Controls.Clear();
            BookSearchForm bookSearchForm = new BookSearchForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            bookSearchForm.FormBorderStyle = FormBorderStyle.None;
            this.pnLibFormLoad.Controls.Add(bookSearchForm);
            bookSearchForm.Show();

            panNav.Height = btnSearch.Height;
            panNav.Top = btnSearch.Top;
            panNav.Left = btnSearch.Left;
            btnSearch.BackColor = Color.AliceBlue;

            btnLibManager.BackColor = Color.FromArgb(196, 222, 255);
            btnUserManager.BackColor = Color.FromArgb(196, 222, 255);
            btnBookManager.BackColor = Color.FromArgb(196, 222, 255);
            btnConfig.BackColor = Color.FromArgb(196, 222, 255);
            btnBreak.BackColor = Color.FromArgb(196, 222, 255);
        }


        // 다른 버튼 클릭 시 뒷 배경 처리
        private void btnLibManager_Leave(object sender, EventArgs e)
        {
            btnLibManager.BackColor = Color.FromArgb(196, 222, 255);
        }
        private void btnBreak_Leave(object sender, EventArgs e)
        {
            btnBreak.BackColor = Color.FromArgb(196, 222, 255);
        }
        private void btnBookManager_Leave(object sender, EventArgs e)
        {
            btnBookManager.BackColor = Color.FromArgb(196, 222, 255);
        }
        private void btnSearch_Leave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(196, 222, 255);
        }
        private void btnUserManager_Leave(object sender, EventArgs e)
        {
            btnUserManager.BackColor = Color.FromArgb(196, 222, 255);
        }
        private void btnConfig_Leave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(196, 222, 255);
        }
        // 우측 상단 X 버튼 클릭 시 처리
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // FormBorderStyle을 None으로 설정 => 폼 이동이 불가능 하므로, 이동 할 수 있도록 처리
        private void LibraryManagement_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); // 현재 윈도우의 좌표 저장
        }

        private void LibraryManagement_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            { 
                int x = mousePoint.X - e.X; 
                int y = mousePoint.Y - e.Y; 
                Location = new Point(this.Left - x, this.Top - y); 
            }
        }

    }
}

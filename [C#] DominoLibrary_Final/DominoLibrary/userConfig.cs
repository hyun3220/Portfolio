using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace DominoLibrary
{
    public partial class userConfig : Form
    {
        public userConfig()
        {
            InitializeComponent();
        }
        FirebaseConfig fdc = new FirebaseConfig
        {
            AuthSecret = "tVFOq3eKA6ELM1KaGPUMbshm2rZxz0Ipuv4GpT68",
            BasePath = "https://dominolibraryjoin-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        // 폼 로드 시 처리
        private void userConfig_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = LoginForm.userID.ToString();
            this.txtName.Text = LoginForm.UserName.ToString();
            this.txtUsername.Enabled = false;
            this.txtName.Focus();

            try
            {
                client = new FireSharp.FirebaseClient(fdc);
            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 수정 버튼 클릭 시 처리
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string pw = this.txtPW.Text;

            // 비밀번호, 비밀번호 확인 상자에 입력한 값이 일치하지 않을 경우 처리
            if (this.txtPW.Text != this.txtPWCheck.Text)
            {
                this.lblPWCheck.Text = "✔ 비밀번호가 서로 일치하지 않습니다.";
                this.lblBlank.Text = "";
                this.txtPW.Text = "";
                this.txtPWCheck.Text = "";
                this.lblPwResult.Text = "";
                this.lblPwResult2.Text = "";
                this.txtPW.Focus();
            }
            else
            {
                var result = client.Get("가입자 명단/" + this.txtUsername.Text);
                Upload upd1 = result.ResultAs<Upload>();

                if (this.txtName.Text == "" || this.txtPW.Text == "" || this.txtPWCheck.Text == "")
                {
                    this.lblBlank.Text = "* 빈 칸을 모두 입력해 주세요.";
                }
                else if(upd1.pw.ToString() == this.txtPW.Text)  // 기존에 등록된 비밀번호와 동일할 경우 처리
                {
                    this.txtPW.Text = "";
                    this.txtPWCheck.Text = "";
                    this.lblPwResult.Text = "";
                    this.lblPwResult2.Text = "";
                    this.lblPWCheck.Text = "✔ 기존 비밀번호와 동일합니다." + "\n" + "    새로 작성해 주세요.";
                    this.txtPW.Focus();
                }
                else if(pwCheck(pw) == false)   // 비밀번호 정규식을 통한 조건 만족 체크
                {
                    this.txtPW.Text = "";
                    this.txtPWCheck.Text = "";
                    this.lblPwResult.Text = " ✔ 8자 이상의 숫자와 문자가 포함되어야 합니다.";
                    this.lblPwResult2.Text = " ✔ 하나 이상의 특수문자를 포함해야 합니다.";
                    this.lblPWCheck.Text = "";
                    this.lblBlank.Text = "";
                    this.txtPW.Focus();
                }
                else
                {
                    this.lblPWCheck.Text = "";
                    var configResult = MessageBox.Show("정말 수정 하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (configResult == DialogResult.Yes)
                    {
                        Upload upd2 = new Upload()
                        {
                            name = this.txtName.Text,
                            id = this.txtUsername.Text,
                            pw = this.txtPW.Text
                        };

                        var send = client.Set("가입자 명단/" + this.txtUsername.Text, upd2);
                        MessageBox.Show("회원 정보가 변경되었습니다." + "\n" + "다시 로그인 해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }


                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtPW.Text = "";
            this.txtPWCheck.Text = "";
            this.pnMain.Visible = true;
        }

        // 패스워드 정규식 메소드 작성
        public static bool pwCheck(string password)
        {
            Regex regex = new Regex(@"^(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(password);
            return match.Success;
        }
    }
}

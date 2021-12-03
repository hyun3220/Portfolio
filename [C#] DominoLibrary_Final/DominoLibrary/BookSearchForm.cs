using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoLibrary
{
    public partial class BookSearchForm : Form
    {
        
        public BookSearchForm()
        {
            InitializeComponent();
            this.txtBookName.Focus();
            dataGridView1.DataSource = DataManager.Books;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchValue = this.txtBookName.Text;
            bool valueResult = false;    // 도서의 존재 여부 판단을 위한 플래그 변수

            // 데이터그리드뷰에서 행을 하나씩 읽어옴
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // TextBox에 입력한 값과 불러온 행의 값과 비교
                if (row.Cells[1].Value.ToString().Equals(searchValue))
                {
                    // 입력한 행을 선택(Selected)
                    row.Selected = true;
                    valueResult = true;    // 입력한 도서가 존재할 경우 false
                }

                // TextBox 입력 값과 일치하지 않으면 Selected 되었던 값을 false로 변경 (선택 해제)
                if (row.Cells[1].Value.ToString() != searchValue)
                {
                    row.Selected = false;
                }
            }

            // 입력한 도서가 존재하지 않을 경우 처리
            if (valueResult == false)
            {
                MessageBox.Show("<" + searchValue + ">" + " 도서는 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtBookName.Text = "";
                this.txtBookName.Focus();
            }


        }

        private void BookSearchForm_Load(object sender, EventArgs e)
        {
            this.txtBookName.Focus();
        }

        private void txtBookName_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void BookSearchForm_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null; 
        }
    }
}

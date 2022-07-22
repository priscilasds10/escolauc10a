using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoEscola

{
     [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class FrmCadastros : Form
    {
        public FrmCadastros()
        {
            InitializeComponent();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }

}


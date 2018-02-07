#if !NETCOREAPP2_0
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lsj.Util.Text;

namespace Lsj.Util.Logs.Logger
{
    /// <summary>
    /// LogView
    /// </summary>
    public sealed partial class LogView : RichTextBox
    {
        /// <summary>
        /// LogView
        /// </summary>
        public LogView()
        {
            InitializeComponent();
            this.Init();
        }
        internal bool IsNewAdd;
        private void Init()
        {
            this.ReadOnly = true;
            this.BackColor = Color.Black;
            this.SelectionColor = Color.White;
            LogView.CheckForIllegalCrossThreadCalls = false;
            this.AppendLine("=================================LogView===============================");

        }

        /// <summary>
        /// LogView
        /// </summary>
        /// <param name="container"></param>
        public LogView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.Init();
        }
        /// <summary>
        /// OnTextChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (!IsNewAdd)
            {
                return;
            }
            IsNewAdd = false;
            if (this.Lines.Length > 1000)
            {
                var a = this.Rtf;
                var x = a.IndexOf(@"=\par");
                var head = a.Substring(0, x + 5).ToStringBuilder();
                var left = a.Substring(x + 5);

                var lines = left.Split(@"\cf");
                var last = lines.Skip(lines.Length - 500);

                foreach (var line in last)
                {
                    head.Append(@"\cf");
                    head.Append(line);

                }
                this.Rtf = head.ToString();
            }




            ScrollToCaret();

        }
    }
}
#endif

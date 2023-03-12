namespace MonitoringPacket
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnShutdown = new Bunifu.UI.WinForms.BunifuImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dropdownNIC = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnScan = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GridIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridMacAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnGetPCAP = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtTargetMac = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnAttack = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtTargetIP = new Bunifu.UI.WinForms.BunifuTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.bunifuPanel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.btnShutdown);
            this.bunifuPanel1.Controls.Add(this.label1);
            this.bunifuPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(582, 35);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // btnShutdown
            // 
            this.btnShutdown.ActiveImage = null;
            this.btnShutdown.AllowAnimations = true;
            this.btnShutdown.AllowBuffering = false;
            this.btnShutdown.AllowToggling = false;
            this.btnShutdown.AllowZooming = false;
            this.btnShutdown.AllowZoomingOnFocus = false;
            this.btnShutdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnShutdown.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShutdown.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShutdown.ErrorImage")));
            this.btnShutdown.FadeWhenInactive = false;
            this.btnShutdown.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShutdown.Image = ((System.Drawing.Image)(resources.GetObject("btnShutdown.Image")));
            this.btnShutdown.ImageActive = null;
            this.btnShutdown.ImageLocation = null;
            this.btnShutdown.ImageMargin = 12;
            this.btnShutdown.ImageSize = new System.Drawing.Size(13, 13);
            this.btnShutdown.ImageZoomSize = new System.Drawing.Size(25, 25);
            this.btnShutdown.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShutdown.InitialImage")));
            this.btnShutdown.Location = new System.Drawing.Point(544, 3);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Rotation = 0;
            this.btnShutdown.ShowActiveImage = true;
            this.btnShutdown.ShowCursorChanges = true;
            this.btnShutdown.ShowImageBorders = false;
            this.btnShutdown.ShowSizeMarkers = false;
            this.btnShutdown.Size = new System.Drawing.Size(25, 25);
            this.btnShutdown.TabIndex = 5;
            this.btnShutdown.ToolTipText = "";
            this.btnShutdown.WaitOnLoad = false;
            this.btnShutdown.Zoom = 12;
            this.btnShutdown.ZoomSpeed = 10;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scan network";
            // 
            // dropdownNIC
            // 
            this.dropdownNIC.BackColor = System.Drawing.Color.Transparent;
            this.dropdownNIC.BackgroundColor = System.Drawing.Color.White;
            this.dropdownNIC.BorderColor = System.Drawing.Color.Silver;
            this.dropdownNIC.BorderRadius = 1;
            this.dropdownNIC.Color = System.Drawing.Color.Silver;
            this.dropdownNIC.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dropdownNIC.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownNIC.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dropdownNIC.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownNIC.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dropdownNIC.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.dropdownNIC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dropdownNIC.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dropdownNIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownNIC.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdownNIC.FillDropDown = true;
            this.dropdownNIC.FillIndicator = false;
            this.dropdownNIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownNIC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dropdownNIC.ForeColor = System.Drawing.Color.Black;
            this.dropdownNIC.FormattingEnabled = true;
            this.dropdownNIC.Icon = null;
            this.dropdownNIC.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdownNIC.IndicatorColor = System.Drawing.Color.Gray;
            this.dropdownNIC.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdownNIC.ItemBackColor = System.Drawing.Color.White;
            this.dropdownNIC.ItemBorderColor = System.Drawing.Color.White;
            this.dropdownNIC.ItemForeColor = System.Drawing.Color.Black;
            this.dropdownNIC.ItemHeight = 25;
            this.dropdownNIC.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.dropdownNIC.ItemHighLightForeColor = System.Drawing.Color.White;
            this.dropdownNIC.ItemTopMargin = 3;
            this.dropdownNIC.Location = new System.Drawing.Point(12, 56);
            this.dropdownNIC.Name = "dropdownNIC";
            this.dropdownNIC.Size = new System.Drawing.Size(275, 31);
            this.dropdownNIC.TabIndex = 3;
            this.dropdownNIC.Text = null;
            this.dropdownNIC.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdownNIC.TextLeftMargin = 5;
            this.dropdownNIC.SelectedIndexChanged += new System.EventHandler(this.dropdownNIC_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select network";
            // 
            // btnScan
            // 
            this.btnScan.AllowAnimations = true;
            this.btnScan.AllowMouseEffects = true;
            this.btnScan.AllowToggling = false;
            this.btnScan.AnimationSpeed = 200;
            this.btnScan.AutoGenerateColors = false;
            this.btnScan.AutoRoundBorders = false;
            this.btnScan.AutoSizeLeftIcon = true;
            this.btnScan.AutoSizeRightIcon = true;
            this.btnScan.BackColor = System.Drawing.Color.Transparent;
            this.btnScan.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnScan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScan.BackgroundImage")));
            this.btnScan.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnScan.ButtonText = "Scan";
            this.btnScan.ButtonTextMarginLeft = 0;
            this.btnScan.ColorContrastOnClick = 45;
            this.btnScan.ColorContrastOnHover = 45;
            this.btnScan.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnScan.CustomizableEdges = borderEdges4;
            this.btnScan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScan.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnScan.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnScan.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnScan.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnScan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.ForeColor = System.Drawing.Color.White;
            this.btnScan.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScan.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnScan.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnScan.IconMarginLeft = 11;
            this.btnScan.IconPadding = 10;
            this.btnScan.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScan.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnScan.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnScan.IconSize = 25;
            this.btnScan.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnScan.IdleBorderRadius = 5;
            this.btnScan.IdleBorderThickness = 1;
            this.btnScan.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnScan.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnScan.IdleIconLeftImage")));
            this.btnScan.IdleIconRightImage = null;
            this.btnScan.IndicateFocus = false;
            this.btnScan.Location = new System.Drawing.Point(248, 94);
            this.btnScan.Name = "btnScan";
            this.btnScan.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnScan.OnDisabledState.BorderRadius = 5;
            this.btnScan.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnScan.OnDisabledState.BorderThickness = 1;
            this.btnScan.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnScan.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnScan.OnDisabledState.IconLeftImage = null;
            this.btnScan.OnDisabledState.IconRightImage = null;
            this.btnScan.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnScan.onHoverState.BorderRadius = 5;
            this.btnScan.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnScan.onHoverState.BorderThickness = 1;
            this.btnScan.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnScan.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnScan.onHoverState.IconLeftImage = null;
            this.btnScan.onHoverState.IconRightImage = null;
            this.btnScan.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnScan.OnIdleState.BorderRadius = 5;
            this.btnScan.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnScan.OnIdleState.BorderThickness = 1;
            this.btnScan.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnScan.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnScan.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnScan.OnIdleState.IconLeftImage")));
            this.btnScan.OnIdleState.IconRightImage = null;
            this.btnScan.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnScan.OnPressedState.BorderRadius = 5;
            this.btnScan.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnScan.OnPressedState.BorderThickness = 1;
            this.btnScan.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnScan.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnScan.OnPressedState.IconLeftImage = null;
            this.btnScan.OnPressedState.IconRightImage = null;
            this.btnScan.Size = new System.Drawing.Size(73, 30);
            this.btnScan.TabIndex = 11;
            this.btnScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnScan.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnScan.TextMarginLeft = 0;
            this.btnScan.TextPadding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnScan.UseDefaultRadiusAndThickness = true;
            this.btnScan.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridIPAddress,
            this.GridMacAddress,
            this.GridHostname});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(15, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(553, 178);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // GridIPAddress
            // 
            this.GridIPAddress.HeaderText = "IPAddress";
            this.GridIPAddress.Name = "GridIPAddress";
            this.GridIPAddress.ReadOnly = true;
            // 
            // GridMacAddress
            // 
            this.GridMacAddress.HeaderText = "MacAddress";
            this.GridMacAddress.Name = "GridMacAddress";
            this.GridMacAddress.ReadOnly = true;
            // 
            // GridHostname
            // 
            this.GridHostname.HeaderText = "Hostname";
            this.GridHostname.Name = "GridHostname";
            this.GridHostname.ReadOnly = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(293, 56);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(275, 31);
            this.progressBar1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnGetPCAP);
            this.groupBox1.Controls.Add(this.txtTargetMac);
            this.groupBox1.Controls.Add(this.btnAttack);
            this.groupBox1.Controls.Add(this.txtTargetIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 114);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "...";
            // 
            // btnStop
            // 
            this.btnStop.AllowAnimations = true;
            this.btnStop.AllowMouseEffects = true;
            this.btnStop.AllowToggling = false;
            this.btnStop.AnimationSpeed = 200;
            this.btnStop.AutoGenerateColors = false;
            this.btnStop.AutoRoundBorders = false;
            this.btnStop.AutoSizeLeftIcon = true;
            this.btnStop.AutoSizeRightIcon = true;
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnStop.ButtonText = "Stop attack";
            this.btnStop.ButtonTextMarginLeft = 0;
            this.btnStop.ColorContrastOnClick = 45;
            this.btnStop.ColorContrastOnHover = 45;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnStop.CustomizableEdges = borderEdges1;
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStop.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnStop.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnStop.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnStop.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnStop.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnStop.IconMarginLeft = 11;
            this.btnStop.IconPadding = 10;
            this.btnStop.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnStop.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnStop.IconSize = 25;
            this.btnStop.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnStop.IdleBorderRadius = 5;
            this.btnStop.IdleBorderThickness = 1;
            this.btnStop.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnStop.IdleIconLeftImage = null;
            this.btnStop.IdleIconRightImage = null;
            this.btnStop.IndicateFocus = false;
            this.btnStop.Location = new System.Drawing.Point(233, 72);
            this.btnStop.Name = "btnStop";
            this.btnStop.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnStop.OnDisabledState.BorderRadius = 5;
            this.btnStop.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnStop.OnDisabledState.BorderThickness = 1;
            this.btnStop.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnStop.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnStop.OnDisabledState.IconLeftImage = null;
            this.btnStop.OnDisabledState.IconRightImage = null;
            this.btnStop.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnStop.onHoverState.BorderRadius = 5;
            this.btnStop.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnStop.onHoverState.BorderThickness = 1;
            this.btnStop.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnStop.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnStop.onHoverState.IconLeftImage = null;
            this.btnStop.onHoverState.IconRightImage = null;
            this.btnStop.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnStop.OnIdleState.BorderRadius = 5;
            this.btnStop.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnStop.OnIdleState.BorderThickness = 1;
            this.btnStop.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(65)))));
            this.btnStop.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnStop.OnIdleState.IconLeftImage = null;
            this.btnStop.OnIdleState.IconRightImage = null;
            this.btnStop.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnStop.OnPressedState.BorderRadius = 5;
            this.btnStop.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnStop.OnPressedState.BorderThickness = 1;
            this.btnStop.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnStop.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnStop.OnPressedState.IconLeftImage = null;
            this.btnStop.OnPressedState.IconRightImage = null;
            this.btnStop.Size = new System.Drawing.Size(77, 30);
            this.btnStop.TabIndex = 22;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStop.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStop.TextMarginLeft = 0;
            this.btnStop.TextPadding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnStop.UseDefaultRadiusAndThickness = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGetPCAP
            // 
            this.btnGetPCAP.AllowAnimations = true;
            this.btnGetPCAP.AllowMouseEffects = true;
            this.btnGetPCAP.AllowToggling = false;
            this.btnGetPCAP.AnimationSpeed = 200;
            this.btnGetPCAP.AutoGenerateColors = false;
            this.btnGetPCAP.AutoRoundBorders = false;
            this.btnGetPCAP.AutoSizeLeftIcon = true;
            this.btnGetPCAP.AutoSizeRightIcon = true;
            this.btnGetPCAP.BackColor = System.Drawing.Color.Transparent;
            this.btnGetPCAP.BackColor1 = System.Drawing.Color.Teal;
            this.btnGetPCAP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGetPCAP.BackgroundImage")));
            this.btnGetPCAP.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnGetPCAP.ButtonText = "GetPCAP";
            this.btnGetPCAP.ButtonTextMarginLeft = 0;
            this.btnGetPCAP.ColorContrastOnClick = 45;
            this.btnGetPCAP.ColorContrastOnHover = 45;
            this.btnGetPCAP.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnGetPCAP.CustomizableEdges = borderEdges2;
            this.btnGetPCAP.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGetPCAP.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGetPCAP.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGetPCAP.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGetPCAP.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnGetPCAP.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPCAP.ForeColor = System.Drawing.Color.White;
            this.btnGetPCAP.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetPCAP.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnGetPCAP.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnGetPCAP.IconMarginLeft = 11;
            this.btnGetPCAP.IconPadding = 10;
            this.btnGetPCAP.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetPCAP.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnGetPCAP.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnGetPCAP.IconSize = 25;
            this.btnGetPCAP.IdleBorderColor = System.Drawing.Color.Teal;
            this.btnGetPCAP.IdleBorderRadius = 5;
            this.btnGetPCAP.IdleBorderThickness = 1;
            this.btnGetPCAP.IdleFillColor = System.Drawing.Color.Teal;
            this.btnGetPCAP.IdleIconLeftImage = null;
            this.btnGetPCAP.IdleIconRightImage = null;
            this.btnGetPCAP.IndicateFocus = false;
            this.btnGetPCAP.Location = new System.Drawing.Point(316, 72);
            this.btnGetPCAP.Name = "btnGetPCAP";
            this.btnGetPCAP.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGetPCAP.OnDisabledState.BorderRadius = 5;
            this.btnGetPCAP.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnGetPCAP.OnDisabledState.BorderThickness = 1;
            this.btnGetPCAP.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGetPCAP.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGetPCAP.OnDisabledState.IconLeftImage = null;
            this.btnGetPCAP.OnDisabledState.IconRightImage = null;
            this.btnGetPCAP.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnGetPCAP.onHoverState.BorderRadius = 5;
            this.btnGetPCAP.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnGetPCAP.onHoverState.BorderThickness = 1;
            this.btnGetPCAP.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnGetPCAP.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnGetPCAP.onHoverState.IconLeftImage = null;
            this.btnGetPCAP.onHoverState.IconRightImage = null;
            this.btnGetPCAP.OnIdleState.BorderColor = System.Drawing.Color.Teal;
            this.btnGetPCAP.OnIdleState.BorderRadius = 5;
            this.btnGetPCAP.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnGetPCAP.OnIdleState.BorderThickness = 1;
            this.btnGetPCAP.OnIdleState.FillColor = System.Drawing.Color.Teal;
            this.btnGetPCAP.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnGetPCAP.OnIdleState.IconLeftImage = null;
            this.btnGetPCAP.OnIdleState.IconRightImage = null;
            this.btnGetPCAP.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnGetPCAP.OnPressedState.BorderRadius = 5;
            this.btnGetPCAP.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnGetPCAP.OnPressedState.BorderThickness = 1;
            this.btnGetPCAP.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnGetPCAP.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnGetPCAP.OnPressedState.IconLeftImage = null;
            this.btnGetPCAP.OnPressedState.IconRightImage = null;
            this.btnGetPCAP.Size = new System.Drawing.Size(77, 30);
            this.btnGetPCAP.TabIndex = 21;
            this.btnGetPCAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGetPCAP.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGetPCAP.TextMarginLeft = 0;
            this.btnGetPCAP.TextPadding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnGetPCAP.UseDefaultRadiusAndThickness = true;
            this.btnGetPCAP.Click += new System.EventHandler(this.btnGetPCAP_Click);
            // 
            // txtTargetMac
            // 
            this.txtTargetMac.AcceptsReturn = false;
            this.txtTargetMac.AcceptsTab = false;
            this.txtTargetMac.AnimationSpeed = 200;
            this.txtTargetMac.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTargetMac.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTargetMac.BackColor = System.Drawing.Color.Transparent;
            this.txtTargetMac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTargetMac.BackgroundImage")));
            this.txtTargetMac.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtTargetMac.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtTargetMac.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtTargetMac.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtTargetMac.BorderRadius = 1;
            this.txtTargetMac.BorderThickness = 1;
            this.txtTargetMac.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTargetMac.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTargetMac.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtTargetMac.DefaultText = "";
            this.txtTargetMac.FillColor = System.Drawing.Color.White;
            this.txtTargetMac.HideSelection = true;
            this.txtTargetMac.IconLeft = null;
            this.txtTargetMac.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTargetMac.IconPadding = 10;
            this.txtTargetMac.IconRight = null;
            this.txtTargetMac.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTargetMac.Lines = new string[0];
            this.txtTargetMac.Location = new System.Drawing.Point(281, 35);
            this.txtTargetMac.MaxLength = 32767;
            this.txtTargetMac.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTargetMac.Modified = false;
            this.txtTargetMac.Multiline = false;
            this.txtTargetMac.Name = "txtTargetMac";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTargetMac.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtTargetMac.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTargetMac.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTargetMac.OnIdleState = stateProperties4;
            this.txtTargetMac.Padding = new System.Windows.Forms.Padding(3);
            this.txtTargetMac.PasswordChar = '\0';
            this.txtTargetMac.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTargetMac.PlaceholderText = "";
            this.txtTargetMac.ReadOnly = false;
            this.txtTargetMac.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTargetMac.SelectedText = "";
            this.txtTargetMac.SelectionLength = 0;
            this.txtTargetMac.SelectionStart = 0;
            this.txtTargetMac.ShortcutsEnabled = true;
            this.txtTargetMac.Size = new System.Drawing.Size(269, 31);
            this.txtTargetMac.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtTargetMac.TabIndex = 20;
            this.txtTargetMac.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTargetMac.TextMarginBottom = 0;
            this.txtTargetMac.TextMarginLeft = 3;
            this.txtTargetMac.TextMarginTop = 0;
            this.txtTargetMac.TextPlaceholder = "";
            this.txtTargetMac.UseSystemPasswordChar = false;
            this.txtTargetMac.WordWrap = true;
            // 
            // btnAttack
            // 
            this.btnAttack.AllowAnimations = true;
            this.btnAttack.AllowMouseEffects = true;
            this.btnAttack.AllowToggling = false;
            this.btnAttack.AnimationSpeed = 200;
            this.btnAttack.AutoGenerateColors = false;
            this.btnAttack.AutoRoundBorders = false;
            this.btnAttack.AutoSizeLeftIcon = true;
            this.btnAttack.AutoSizeRightIcon = true;
            this.btnAttack.BackColor = System.Drawing.Color.Transparent;
            this.btnAttack.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAttack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAttack.BackgroundImage")));
            this.btnAttack.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAttack.ButtonText = "Attack";
            this.btnAttack.ButtonTextMarginLeft = 0;
            this.btnAttack.ColorContrastOnClick = 45;
            this.btnAttack.ColorContrastOnHover = 45;
            this.btnAttack.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnAttack.CustomizableEdges = borderEdges3;
            this.btnAttack.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAttack.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAttack.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAttack.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAttack.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAttack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttack.ForeColor = System.Drawing.Color.White;
            this.btnAttack.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttack.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAttack.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAttack.IconMarginLeft = 11;
            this.btnAttack.IconPadding = 10;
            this.btnAttack.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttack.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAttack.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAttack.IconSize = 25;
            this.btnAttack.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAttack.IdleBorderRadius = 5;
            this.btnAttack.IdleBorderThickness = 1;
            this.btnAttack.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAttack.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAttack.IdleIconLeftImage")));
            this.btnAttack.IdleIconRightImage = null;
            this.btnAttack.IndicateFocus = false;
            this.btnAttack.Location = new System.Drawing.Point(148, 72);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAttack.OnDisabledState.BorderRadius = 5;
            this.btnAttack.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAttack.OnDisabledState.BorderThickness = 1;
            this.btnAttack.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAttack.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAttack.OnDisabledState.IconLeftImage = null;
            this.btnAttack.OnDisabledState.IconRightImage = null;
            this.btnAttack.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnAttack.onHoverState.BorderRadius = 5;
            this.btnAttack.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAttack.onHoverState.BorderThickness = 1;
            this.btnAttack.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(85)))), ((int)(((byte)(103)))));
            this.btnAttack.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAttack.onHoverState.IconLeftImage = null;
            this.btnAttack.onHoverState.IconRightImage = null;
            this.btnAttack.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAttack.OnIdleState.BorderRadius = 5;
            this.btnAttack.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAttack.OnIdleState.BorderThickness = 1;
            this.btnAttack.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAttack.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAttack.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAttack.OnIdleState.IconLeftImage")));
            this.btnAttack.OnIdleState.IconRightImage = null;
            this.btnAttack.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAttack.OnPressedState.BorderRadius = 5;
            this.btnAttack.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAttack.OnPressedState.BorderThickness = 1;
            this.btnAttack.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAttack.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAttack.OnPressedState.IconLeftImage = null;
            this.btnAttack.OnPressedState.IconRightImage = null;
            this.btnAttack.Size = new System.Drawing.Size(77, 30);
            this.btnAttack.TabIndex = 19;
            this.btnAttack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAttack.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAttack.TextMarginLeft = 0;
            this.btnAttack.TextPadding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnAttack.UseDefaultRadiusAndThickness = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // txtTargetIP
            // 
            this.txtTargetIP.AcceptsReturn = false;
            this.txtTargetIP.AcceptsTab = false;
            this.txtTargetIP.AnimationSpeed = 200;
            this.txtTargetIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTargetIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTargetIP.BackColor = System.Drawing.Color.Transparent;
            this.txtTargetIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTargetIP.BackgroundImage")));
            this.txtTargetIP.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtTargetIP.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtTargetIP.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtTargetIP.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtTargetIP.BorderRadius = 1;
            this.txtTargetIP.BorderThickness = 1;
            this.txtTargetIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTargetIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTargetIP.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtTargetIP.DefaultText = "";
            this.txtTargetIP.FillColor = System.Drawing.Color.White;
            this.txtTargetIP.HideSelection = true;
            this.txtTargetIP.IconLeft = null;
            this.txtTargetIP.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTargetIP.IconPadding = 10;
            this.txtTargetIP.IconRight = null;
            this.txtTargetIP.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTargetIP.Lines = new string[0];
            this.txtTargetIP.Location = new System.Drawing.Point(9, 35);
            this.txtTargetIP.MaxLength = 32767;
            this.txtTargetIP.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTargetIP.Modified = false;
            this.txtTargetIP.Multiline = false;
            this.txtTargetIP.Name = "txtTargetIP";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTargetIP.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtTargetIP.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTargetIP.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtTargetIP.OnIdleState = stateProperties8;
            this.txtTargetIP.Padding = new System.Windows.Forms.Padding(3);
            this.txtTargetIP.PasswordChar = '\0';
            this.txtTargetIP.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTargetIP.PlaceholderText = "";
            this.txtTargetIP.ReadOnly = false;
            this.txtTargetIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTargetIP.SelectedText = "";
            this.txtTargetIP.SelectionLength = 0;
            this.txtTargetIP.SelectionStart = 0;
            this.txtTargetIP.ShortcutsEnabled = true;
            this.txtTargetIP.Size = new System.Drawing.Size(266, 31);
            this.txtTargetIP.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtTargetIP.TabIndex = 18;
            this.txtTargetIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTargetIP.TextMarginBottom = 0;
            this.txtTargetIP.TextMarginLeft = 3;
            this.txtTargetIP.TextMarginTop = 0;
            this.txtTargetIP.TextPlaceholder = "";
            this.txtTargetIP.UseSystemPasswordChar = false;
            this.txtTargetIP.WordWrap = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Target Mac address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Target IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 440);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dropdownNIC);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuDropdown dropdownNIC;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnScan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnGetPCAP;
        private Bunifu.UI.WinForms.BunifuTextBox txtTargetMac;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAttack;
        private Bunifu.UI.WinForms.BunifuTextBox txtTargetIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridMacAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridHostname;
        private Bunifu.UI.WinForms.BunifuImageButton btnShutdown;
    }
}


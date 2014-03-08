namespace SimInterface
{
    partial class MainForm
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
            this.mcp_cmd_a = new System.Windows.Forms.RadioButton();
            this.btn_mcp_cmd_a = new System.Windows.Forms.Button();
            this.btn_efis_wxr = new System.Windows.Forms.Button();
            this.btn_efis_terr = new System.Windows.Forms.Button();
            this.btn_efis_arpt = new System.Windows.Forms.Button();
            this.btn_efis_data = new System.Windows.Forms.Button();
            this.btn_efis_pos = new System.Windows.Forms.Button();
            this.btn_efis_wpt = new System.Windows.Forms.Button();
            this.btn_efis_sta = new System.Windows.Forms.Button();
            this.efis_wxr = new System.Windows.Forms.RadioButton();
            this.efis_terr = new System.Windows.Forms.RadioButton();
            this.efis_data = new System.Windows.Forms.RadioButton();
            this.efis_arpt = new System.Windows.Forms.RadioButton();
            this.efis_sta = new System.Windows.Forms.RadioButton();
            this.efis_wpt = new System.Windows.Forms.RadioButton();
            this.efis_pos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.efis_mins_radio = new System.Windows.Forms.Button();
            this.efis_mins_baro = new System.Windows.Forms.Button();
            this.efis_mins_reset = new System.Windows.Forms.Button();
            this.efis_mins_inc = new System.Windows.Forms.Button();
            this.efis_mins_dec = new System.Windows.Forms.Button();
            this.btn_efis_sel_l_vor = new System.Windows.Forms.Button();
            this.btn_efis_sel_l_off = new System.Windows.Forms.Button();
            this.btn_efis_sel_l_adf = new System.Windows.Forms.Button();
            this.btn_efis_mode_ctr = new System.Windows.Forms.Button();
            this.btn_efis_mode_app = new System.Windows.Forms.Button();
            this.btn_efis_mode_vor = new System.Windows.Forms.Button();
            this.btn_efis_mode_map = new System.Windows.Forms.Button();
            this.btn_efis_mode_pln = new System.Windows.Forms.Button();
            this.btn_efis_range_160 = new System.Windows.Forms.Button();
            this.btn_efis_range_80 = new System.Windows.Forms.Button();
            this.btn_efis_range_10 = new System.Windows.Forms.Button();
            this.btn_efis_range_5 = new System.Windows.Forms.Button();
            this.btn_efis_tfc = new System.Windows.Forms.Button();
            this.btn_efis_range_20 = new System.Windows.Forms.Button();
            this.btn_efis_range_40 = new System.Windows.Forms.Button();
            this.btn_efis_range_640 = new System.Windows.Forms.Button();
            this.btn_efis_range_320 = new System.Windows.Forms.Button();
            this.btn_efis_sel_r_adf = new System.Windows.Forms.Button();
            this.btn_efis_sel_r_off = new System.Windows.Forms.Button();
            this.btn_efis_sel_r_vor = new System.Windows.Forms.Button();
            this.btn_efis_baro_dec = new System.Windows.Forms.Button();
            this.btn_efis_baro_inc = new System.Windows.Forms.Button();
            this.btn_efis_baro_std = new System.Windows.Forms.Button();
            this.btn_efis_baro_hpa = new System.Windows.Forms.Button();
            this.btn_efis_baro_in = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.efis_ctr = new System.Windows.Forms.RadioButton();
            this.efis_tfc = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // mcp_cmd_a
            // 
            this.mcp_cmd_a.AutoSize = true;
            this.mcp_cmd_a.Enabled = false;
            this.mcp_cmd_a.Location = new System.Drawing.Point(776, 44);
            this.mcp_cmd_a.Name = "mcp_cmd_a";
            this.mcp_cmd_a.Size = new System.Drawing.Size(14, 13);
            this.mcp_cmd_a.TabIndex = 15;
            this.mcp_cmd_a.UseVisualStyleBackColor = true;
            // 
            // btn_mcp_cmd_a
            // 
            this.btn_mcp_cmd_a.Location = new System.Drawing.Point(761, 12);
            this.btn_mcp_cmd_a.Name = "btn_mcp_cmd_a";
            this.btn_mcp_cmd_a.Size = new System.Drawing.Size(45, 45);
            this.btn_mcp_cmd_a.TabIndex = 16;
            this.btn_mcp_cmd_a.Text = "CMD A";
            this.btn_mcp_cmd_a.UseVisualStyleBackColor = true;
            this.btn_mcp_cmd_a.Click += new System.EventHandler(this.btn_mcp_cmd_a_Click);
            // 
            // btn_efis_wxr
            // 
            this.btn_efis_wxr.Location = new System.Drawing.Point(12, 172);
            this.btn_efis_wxr.Name = "btn_efis_wxr";
            this.btn_efis_wxr.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_wxr.TabIndex = 17;
            this.btn_efis_wxr.Text = "WXR";
            this.btn_efis_wxr.UseVisualStyleBackColor = true;
            this.btn_efis_wxr.Click += new System.EventHandler(this.btn_efis_wxr_Click);
            // 
            // btn_efis_terr
            // 
            this.btn_efis_terr.Location = new System.Drawing.Point(318, 172);
            this.btn_efis_terr.Name = "btn_efis_terr";
            this.btn_efis_terr.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_terr.TabIndex = 18;
            this.btn_efis_terr.Text = "TERR";
            this.btn_efis_terr.UseVisualStyleBackColor = true;
            this.btn_efis_terr.Click += new System.EventHandler(this.btn_efis_terr_Click);
            // 
            // btn_efis_arpt
            // 
            this.btn_efis_arpt.Location = new System.Drawing.Point(166, 172);
            this.btn_efis_arpt.Name = "btn_efis_arpt";
            this.btn_efis_arpt.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_arpt.TabIndex = 19;
            this.btn_efis_arpt.Text = "ARPT";
            this.btn_efis_arpt.UseVisualStyleBackColor = true;
            this.btn_efis_arpt.Click += new System.EventHandler(this.btn_efis_arpt_Click);
            // 
            // btn_efis_data
            // 
            this.btn_efis_data.Location = new System.Drawing.Point(217, 172);
            this.btn_efis_data.Name = "btn_efis_data";
            this.btn_efis_data.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_data.TabIndex = 20;
            this.btn_efis_data.Text = "DATA";
            this.btn_efis_data.UseVisualStyleBackColor = true;
            this.btn_efis_data.Click += new System.EventHandler(this.btn_efis_data_Click);
            // 
            // btn_efis_pos
            // 
            this.btn_efis_pos.Location = new System.Drawing.Point(268, 172);
            this.btn_efis_pos.Name = "btn_efis_pos";
            this.btn_efis_pos.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_pos.TabIndex = 21;
            this.btn_efis_pos.Text = "POS";
            this.btn_efis_pos.UseVisualStyleBackColor = true;
            this.btn_efis_pos.Click += new System.EventHandler(this.btn_efis_pos_Click);
            // 
            // btn_efis_wpt
            // 
            this.btn_efis_wpt.Location = new System.Drawing.Point(115, 172);
            this.btn_efis_wpt.Name = "btn_efis_wpt";
            this.btn_efis_wpt.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_wpt.TabIndex = 22;
            this.btn_efis_wpt.Text = "WPT";
            this.btn_efis_wpt.UseVisualStyleBackColor = true;
            this.btn_efis_wpt.Click += new System.EventHandler(this.btn_efis_wpt_Click);
            // 
            // btn_efis_sta
            // 
            this.btn_efis_sta.Location = new System.Drawing.Point(63, 172);
            this.btn_efis_sta.Name = "btn_efis_sta";
            this.btn_efis_sta.Size = new System.Drawing.Size(45, 45);
            this.btn_efis_sta.TabIndex = 23;
            this.btn_efis_sta.Text = "STA";
            this.btn_efis_sta.UseVisualStyleBackColor = true;
            this.btn_efis_sta.Click += new System.EventHandler(this.btn_efis_sta_Click);
            // 
            // efis_wxr
            // 
            this.efis_wxr.AutoSize = true;
            this.efis_wxr.Enabled = false;
            this.efis_wxr.Location = new System.Drawing.Point(28, 204);
            this.efis_wxr.Name = "efis_wxr";
            this.efis_wxr.Size = new System.Drawing.Size(14, 13);
            this.efis_wxr.TabIndex = 24;
            this.efis_wxr.UseVisualStyleBackColor = true;
            // 
            // efis_terr
            // 
            this.efis_terr.AutoSize = true;
            this.efis_terr.Enabled = false;
            this.efis_terr.Location = new System.Drawing.Point(334, 204);
            this.efis_terr.Name = "efis_terr";
            this.efis_terr.Size = new System.Drawing.Size(14, 13);
            this.efis_terr.TabIndex = 25;
            this.efis_terr.UseVisualStyleBackColor = true;
            // 
            // efis_data
            // 
            this.efis_data.AutoSize = true;
            this.efis_data.Enabled = false;
            this.efis_data.Location = new System.Drawing.Point(233, 204);
            this.efis_data.Name = "efis_data";
            this.efis_data.Size = new System.Drawing.Size(14, 13);
            this.efis_data.TabIndex = 27;
            this.efis_data.UseVisualStyleBackColor = true;
            // 
            // efis_arpt
            // 
            this.efis_arpt.AutoSize = true;
            this.efis_arpt.Enabled = false;
            this.efis_arpt.Location = new System.Drawing.Point(182, 204);
            this.efis_arpt.Name = "efis_arpt";
            this.efis_arpt.Size = new System.Drawing.Size(14, 13);
            this.efis_arpt.TabIndex = 26;
            this.efis_arpt.UseVisualStyleBackColor = true;
            // 
            // efis_sta
            // 
            this.efis_sta.AutoSize = true;
            this.efis_sta.Enabled = false;
            this.efis_sta.Location = new System.Drawing.Point(78, 204);
            this.efis_sta.Name = "efis_sta";
            this.efis_sta.Size = new System.Drawing.Size(14, 13);
            this.efis_sta.TabIndex = 30;
            this.efis_sta.UseVisualStyleBackColor = true;
            // 
            // efis_wpt
            // 
            this.efis_wpt.AutoSize = true;
            this.efis_wpt.Enabled = false;
            this.efis_wpt.Location = new System.Drawing.Point(130, 204);
            this.efis_wpt.Name = "efis_wpt";
            this.efis_wpt.Size = new System.Drawing.Size(14, 13);
            this.efis_wpt.TabIndex = 29;
            this.efis_wpt.UseVisualStyleBackColor = true;
            // 
            // efis_pos
            // 
            this.efis_pos.AutoSize = true;
            this.efis_pos.Enabled = false;
            this.efis_pos.Location = new System.Drawing.Point(283, 204);
            this.efis_pos.Name = "efis_pos";
            this.efis_pos.Size = new System.Drawing.Size(14, 13);
            this.efis_pos.TabIndex = 28;
            this.efis_pos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "MINS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // efis_mins_radio
            // 
            this.efis_mins_radio.Location = new System.Drawing.Point(30, 25);
            this.efis_mins_radio.Name = "efis_mins_radio";
            this.efis_mins_radio.Size = new System.Drawing.Size(50, 20);
            this.efis_mins_radio.TabIndex = 32;
            this.efis_mins_radio.Text = "RADIO";
            this.efis_mins_radio.UseVisualStyleBackColor = true;
            this.efis_mins_radio.Click += new System.EventHandler(this.efis_mins_radio_Click);
            // 
            // efis_mins_baro
            // 
            this.efis_mins_baro.Location = new System.Drawing.Point(85, 25);
            this.efis_mins_baro.Name = "efis_mins_baro";
            this.efis_mins_baro.Size = new System.Drawing.Size(50, 20);
            this.efis_mins_baro.TabIndex = 33;
            this.efis_mins_baro.Text = "BARO";
            this.efis_mins_baro.UseVisualStyleBackColor = true;
            this.efis_mins_baro.Click += new System.EventHandler(this.efis_mins_baro_Click);
            // 
            // efis_mins_reset
            // 
            this.efis_mins_reset.Location = new System.Drawing.Point(62, 48);
            this.efis_mins_reset.Name = "efis_mins_reset";
            this.efis_mins_reset.Size = new System.Drawing.Size(40, 40);
            this.efis_mins_reset.TabIndex = 36;
            this.efis_mins_reset.Text = "RST";
            this.efis_mins_reset.UseVisualStyleBackColor = true;
            this.efis_mins_reset.Click += new System.EventHandler(this.efis_mins_reset_Click);
            // 
            // efis_mins_inc
            // 
            this.efis_mins_inc.Location = new System.Drawing.Point(108, 58);
            this.efis_mins_inc.Name = "efis_mins_inc";
            this.efis_mins_inc.Size = new System.Drawing.Size(20, 20);
            this.efis_mins_inc.TabIndex = 37;
            this.efis_mins_inc.Text = "+";
            this.efis_mins_inc.UseVisualStyleBackColor = true;
            this.efis_mins_inc.Click += new System.EventHandler(this.efis_mins_inc_Click);
            // 
            // efis_mins_dec
            // 
            this.efis_mins_dec.Location = new System.Drawing.Point(36, 58);
            this.efis_mins_dec.Name = "efis_mins_dec";
            this.efis_mins_dec.Size = new System.Drawing.Size(20, 20);
            this.efis_mins_dec.TabIndex = 38;
            this.efis_mins_dec.Text = "-";
            this.efis_mins_dec.UseVisualStyleBackColor = true;
            this.efis_mins_dec.Click += new System.EventHandler(this.efis_mins_dec_Click);
            // 
            // btn_efis_sel_l_vor
            // 
            this.btn_efis_sel_l_vor.Location = new System.Drawing.Point(12, 94);
            this.btn_efis_sel_l_vor.Name = "btn_efis_sel_l_vor";
            this.btn_efis_sel_l_vor.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_sel_l_vor.TabIndex = 39;
            this.btn_efis_sel_l_vor.Text = "VOR 1";
            this.btn_efis_sel_l_vor.UseVisualStyleBackColor = true;
            this.btn_efis_sel_l_vor.Click += new System.EventHandler(this.btn_efis_sel_l_vor_Click);
            // 
            // btn_efis_sel_l_off
            // 
            this.btn_efis_sel_l_off.Location = new System.Drawing.Point(12, 120);
            this.btn_efis_sel_l_off.Name = "btn_efis_sel_l_off";
            this.btn_efis_sel_l_off.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_sel_l_off.TabIndex = 40;
            this.btn_efis_sel_l_off.Text = "OFF";
            this.btn_efis_sel_l_off.UseVisualStyleBackColor = true;
            this.btn_efis_sel_l_off.Click += new System.EventHandler(this.btn_efis_sel_l_off_Click);
            // 
            // btn_efis_sel_l_adf
            // 
            this.btn_efis_sel_l_adf.Location = new System.Drawing.Point(12, 146);
            this.btn_efis_sel_l_adf.Name = "btn_efis_sel_l_adf";
            this.btn_efis_sel_l_adf.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_sel_l_adf.TabIndex = 41;
            this.btn_efis_sel_l_adf.Text = "ADF 1";
            this.btn_efis_sel_l_adf.UseVisualStyleBackColor = true;
            this.btn_efis_sel_l_adf.Click += new System.EventHandler(this.btn_efis_sel_l_adf_Click);
            // 
            // btn_efis_mode_ctr
            // 
            this.btn_efis_mode_ctr.Location = new System.Drawing.Point(112, 127);
            this.btn_efis_mode_ctr.Name = "btn_efis_mode_ctr";
            this.btn_efis_mode_ctr.Size = new System.Drawing.Size(39, 39);
            this.btn_efis_mode_ctr.TabIndex = 42;
            this.btn_efis_mode_ctr.Text = "CTR";
            this.btn_efis_mode_ctr.UseVisualStyleBackColor = true;
            this.btn_efis_mode_ctr.Click += new System.EventHandler(this.btn_efis_mode_ctr_Click);
            // 
            // btn_efis_mode_app
            // 
            this.btn_efis_mode_app.Location = new System.Drawing.Point(72, 109);
            this.btn_efis_mode_app.Name = "btn_efis_mode_app";
            this.btn_efis_mode_app.Size = new System.Drawing.Size(36, 20);
            this.btn_efis_mode_app.TabIndex = 43;
            this.btn_efis_mode_app.Text = "APP";
            this.btn_efis_mode_app.UseVisualStyleBackColor = true;
            this.btn_efis_mode_app.Click += new System.EventHandler(this.btn_efis_mode_app_Click);
            // 
            // btn_efis_mode_vor
            // 
            this.btn_efis_mode_vor.Location = new System.Drawing.Point(112, 100);
            this.btn_efis_mode_vor.Name = "btn_efis_mode_vor";
            this.btn_efis_mode_vor.Size = new System.Drawing.Size(39, 20);
            this.btn_efis_mode_vor.TabIndex = 44;
            this.btn_efis_mode_vor.Text = "VOR";
            this.btn_efis_mode_vor.UseVisualStyleBackColor = true;
            this.btn_efis_mode_vor.Click += new System.EventHandler(this.btn_efis_mode_vor_Click);
            // 
            // btn_efis_mode_map
            // 
            this.btn_efis_mode_map.Location = new System.Drawing.Point(152, 109);
            this.btn_efis_mode_map.Name = "btn_efis_mode_map";
            this.btn_efis_mode_map.Size = new System.Drawing.Size(38, 20);
            this.btn_efis_mode_map.TabIndex = 45;
            this.btn_efis_mode_map.Text = "MAP";
            this.btn_efis_mode_map.UseVisualStyleBackColor = true;
            this.btn_efis_mode_map.Click += new System.EventHandler(this.btn_efis_mode_map_Click);
            // 
            // btn_efis_mode_pln
            // 
            this.btn_efis_mode_pln.Location = new System.Drawing.Point(152, 128);
            this.btn_efis_mode_pln.Name = "btn_efis_mode_pln";
            this.btn_efis_mode_pln.Size = new System.Drawing.Size(36, 20);
            this.btn_efis_mode_pln.TabIndex = 46;
            this.btn_efis_mode_pln.Text = "PLN";
            this.btn_efis_mode_pln.UseVisualStyleBackColor = true;
            this.btn_efis_mode_pln.Click += new System.EventHandler(this.btn_efis_mode_pln_Click);
            // 
            // btn_efis_range_160
            // 
            this.btn_efis_range_160.Location = new System.Drawing.Point(264, 109);
            this.btn_efis_range_160.Name = "btn_efis_range_160";
            this.btn_efis_range_160.Size = new System.Drawing.Size(33, 20);
            this.btn_efis_range_160.TabIndex = 51;
            this.btn_efis_range_160.Text = "160";
            this.btn_efis_range_160.UseVisualStyleBackColor = true;
            this.btn_efis_range_160.Click += new System.EventHandler(this.btn_efis_range_160_Click);
            // 
            // btn_efis_range_80
            // 
            this.btn_efis_range_80.Location = new System.Drawing.Point(249, 100);
            this.btn_efis_range_80.Name = "btn_efis_range_80";
            this.btn_efis_range_80.Size = new System.Drawing.Size(27, 20);
            this.btn_efis_range_80.TabIndex = 50;
            this.btn_efis_range_80.Text = "80";
            this.btn_efis_range_80.UseVisualStyleBackColor = true;
            this.btn_efis_range_80.Click += new System.EventHandler(this.btn_efis_range_80_Click);
            // 
            // btn_efis_range_10
            // 
            this.btn_efis_range_10.Location = new System.Drawing.Point(194, 109);
            this.btn_efis_range_10.Name = "btn_efis_range_10";
            this.btn_efis_range_10.Size = new System.Drawing.Size(27, 20);
            this.btn_efis_range_10.TabIndex = 49;
            this.btn_efis_range_10.Text = "10";
            this.btn_efis_range_10.UseVisualStyleBackColor = true;
            this.btn_efis_range_10.Click += new System.EventHandler(this.btn_efis_range_10_Click);
            // 
            // btn_efis_range_5
            // 
            this.btn_efis_range_5.Location = new System.Drawing.Point(194, 128);
            this.btn_efis_range_5.Name = "btn_efis_range_5";
            this.btn_efis_range_5.Size = new System.Drawing.Size(17, 20);
            this.btn_efis_range_5.TabIndex = 48;
            this.btn_efis_range_5.Text = "5";
            this.btn_efis_range_5.UseVisualStyleBackColor = true;
            this.btn_efis_range_5.Click += new System.EventHandler(this.btn_efis_range_5_Click);
            // 
            // btn_efis_tfc
            // 
            this.btn_efis_tfc.Location = new System.Drawing.Point(220, 126);
            this.btn_efis_tfc.Name = "btn_efis_tfc";
            this.btn_efis_tfc.Size = new System.Drawing.Size(39, 39);
            this.btn_efis_tfc.TabIndex = 47;
            this.btn_efis_tfc.Text = "TFC";
            this.btn_efis_tfc.UseVisualStyleBackColor = true;
            this.btn_efis_tfc.Click += new System.EventHandler(this.btn_efis_tfc_Click);
            // 
            // btn_efis_range_20
            // 
            this.btn_efis_range_20.Location = new System.Drawing.Point(205, 97);
            this.btn_efis_range_20.Name = "btn_efis_range_20";
            this.btn_efis_range_20.Size = new System.Drawing.Size(27, 20);
            this.btn_efis_range_20.TabIndex = 52;
            this.btn_efis_range_20.Text = "20";
            this.btn_efis_range_20.UseVisualStyleBackColor = true;
            this.btn_efis_range_20.Click += new System.EventHandler(this.btn_efis_range_20_Click);
            // 
            // btn_efis_range_40
            // 
            this.btn_efis_range_40.Location = new System.Drawing.Point(227, 94);
            this.btn_efis_range_40.Name = "btn_efis_range_40";
            this.btn_efis_range_40.Size = new System.Drawing.Size(27, 20);
            this.btn_efis_range_40.TabIndex = 53;
            this.btn_efis_range_40.Text = "40";
            this.btn_efis_range_40.UseVisualStyleBackColor = true;
            this.btn_efis_range_40.Click += new System.EventHandler(this.btn_efis_range_40_Click);
            // 
            // btn_efis_range_640
            // 
            this.btn_efis_range_640.Location = new System.Drawing.Point(264, 147);
            this.btn_efis_range_640.Name = "btn_efis_range_640";
            this.btn_efis_range_640.Size = new System.Drawing.Size(33, 20);
            this.btn_efis_range_640.TabIndex = 54;
            this.btn_efis_range_640.Text = "640";
            this.btn_efis_range_640.UseVisualStyleBackColor = true;
            this.btn_efis_range_640.Click += new System.EventHandler(this.btn_efis_range_640_Click);
            // 
            // btn_efis_range_320
            // 
            this.btn_efis_range_320.Location = new System.Drawing.Point(269, 128);
            this.btn_efis_range_320.Name = "btn_efis_range_320";
            this.btn_efis_range_320.Size = new System.Drawing.Size(33, 20);
            this.btn_efis_range_320.TabIndex = 55;
            this.btn_efis_range_320.Text = "320";
            this.btn_efis_range_320.UseVisualStyleBackColor = true;
            this.btn_efis_range_320.Click += new System.EventHandler(this.btn_efis_range_320_Click);
            // 
            // btn_efis_sel_r_adf
            // 
            this.btn_efis_sel_r_adf.Location = new System.Drawing.Point(313, 146);
            this.btn_efis_sel_r_adf.Name = "btn_efis_sel_r_adf";
            this.btn_efis_sel_r_adf.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_sel_r_adf.TabIndex = 58;
            this.btn_efis_sel_r_adf.Text = "ADF 2";
            this.btn_efis_sel_r_adf.UseVisualStyleBackColor = true;
            this.btn_efis_sel_r_adf.Click += new System.EventHandler(this.btn_efis_sel_r_adf_Click);
            // 
            // btn_efis_sel_r_off
            // 
            this.btn_efis_sel_r_off.Location = new System.Drawing.Point(313, 120);
            this.btn_efis_sel_r_off.Name = "btn_efis_sel_r_off";
            this.btn_efis_sel_r_off.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_sel_r_off.TabIndex = 57;
            this.btn_efis_sel_r_off.Text = "OFF";
            this.btn_efis_sel_r_off.UseVisualStyleBackColor = true;
            this.btn_efis_sel_r_off.Click += new System.EventHandler(this.btn_efis_sel_r_off_Click);
            // 
            // btn_efis_sel_r_vor
            // 
            this.btn_efis_sel_r_vor.Location = new System.Drawing.Point(313, 94);
            this.btn_efis_sel_r_vor.Name = "btn_efis_sel_r_vor";
            this.btn_efis_sel_r_vor.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_sel_r_vor.TabIndex = 56;
            this.btn_efis_sel_r_vor.Text = "VOR 2";
            this.btn_efis_sel_r_vor.UseVisualStyleBackColor = true;
            this.btn_efis_sel_r_vor.Click += new System.EventHandler(this.btn_efis_sel_r_vor_Click);
            // 
            // btn_efis_baro_dec
            // 
            this.btn_efis_baro_dec.Location = new System.Drawing.Point(264, 58);
            this.btn_efis_baro_dec.Name = "btn_efis_baro_dec";
            this.btn_efis_baro_dec.Size = new System.Drawing.Size(20, 20);
            this.btn_efis_baro_dec.TabIndex = 64;
            this.btn_efis_baro_dec.Text = "-";
            this.btn_efis_baro_dec.UseVisualStyleBackColor = true;
            this.btn_efis_baro_dec.Click += new System.EventHandler(this.btn_efis_baro_dec_Click);
            // 
            // btn_efis_baro_inc
            // 
            this.btn_efis_baro_inc.Location = new System.Drawing.Point(336, 58);
            this.btn_efis_baro_inc.Name = "btn_efis_baro_inc";
            this.btn_efis_baro_inc.Size = new System.Drawing.Size(20, 20);
            this.btn_efis_baro_inc.TabIndex = 63;
            this.btn_efis_baro_inc.Text = "+";
            this.btn_efis_baro_inc.UseVisualStyleBackColor = true;
            this.btn_efis_baro_inc.Click += new System.EventHandler(this.btn_efis_baro_inc_Click);
            // 
            // btn_efis_baro_std
            // 
            this.btn_efis_baro_std.Location = new System.Drawing.Point(290, 48);
            this.btn_efis_baro_std.Name = "btn_efis_baro_std";
            this.btn_efis_baro_std.Size = new System.Drawing.Size(40, 40);
            this.btn_efis_baro_std.TabIndex = 62;
            this.btn_efis_baro_std.Text = "STD";
            this.btn_efis_baro_std.UseVisualStyleBackColor = true;
            this.btn_efis_baro_std.Click += new System.EventHandler(this.btn_efis_baro_std_Click);
            // 
            // btn_efis_baro_hpa
            // 
            this.btn_efis_baro_hpa.Location = new System.Drawing.Point(313, 25);
            this.btn_efis_baro_hpa.Name = "btn_efis_baro_hpa";
            this.btn_efis_baro_hpa.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_baro_hpa.TabIndex = 61;
            this.btn_efis_baro_hpa.Text = "HPA";
            this.btn_efis_baro_hpa.UseVisualStyleBackColor = true;
            this.btn_efis_baro_hpa.Click += new System.EventHandler(this.btn_efis_baro_hpa_Click);
            // 
            // btn_efis_baro_in
            // 
            this.btn_efis_baro_in.Location = new System.Drawing.Point(258, 25);
            this.btn_efis_baro_in.Name = "btn_efis_baro_in";
            this.btn_efis_baro_in.Size = new System.Drawing.Size(50, 20);
            this.btn_efis_baro_in.TabIndex = 60;
            this.btn_efis_baro_in.Text = "IN";
            this.btn_efis_baro_in.UseVisualStyleBackColor = true;
            this.btn_efis_baro_in.Click += new System.EventHandler(this.btn_efis_baro_in_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(290, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "BARO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // efis_ctr
            // 
            this.efis_ctr.AutoSize = true;
            this.efis_ctr.Enabled = false;
            this.efis_ctr.Location = new System.Drawing.Point(125, 154);
            this.efis_ctr.Name = "efis_ctr";
            this.efis_ctr.Size = new System.Drawing.Size(14, 13);
            this.efis_ctr.TabIndex = 65;
            this.efis_ctr.UseVisualStyleBackColor = true;
            // 
            // efis_tfc
            // 
            this.efis_tfc.AutoSize = true;
            this.efis_tfc.Enabled = false;
            this.efis_tfc.Location = new System.Drawing.Point(233, 154);
            this.efis_tfc.Name = "efis_tfc";
            this.efis_tfc.Size = new System.Drawing.Size(14, 13);
            this.efis_tfc.TabIndex = 66;
            this.efis_tfc.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 229);
            this.Controls.Add(this.efis_tfc);
            this.Controls.Add(this.efis_ctr);
            this.Controls.Add(this.btn_efis_baro_dec);
            this.Controls.Add(this.btn_efis_baro_inc);
            this.Controls.Add(this.btn_efis_baro_std);
            this.Controls.Add(this.btn_efis_baro_hpa);
            this.Controls.Add(this.btn_efis_baro_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_efis_sel_r_adf);
            this.Controls.Add(this.btn_efis_sel_r_off);
            this.Controls.Add(this.btn_efis_sel_r_vor);
            this.Controls.Add(this.btn_efis_range_40);
            this.Controls.Add(this.btn_efis_range_20);
            this.Controls.Add(this.btn_efis_range_80);
            this.Controls.Add(this.btn_efis_range_10);
            this.Controls.Add(this.btn_efis_range_5);
            this.Controls.Add(this.btn_efis_tfc);
            this.Controls.Add(this.btn_efis_mode_pln);
            this.Controls.Add(this.btn_efis_mode_map);
            this.Controls.Add(this.btn_efis_mode_vor);
            this.Controls.Add(this.btn_efis_mode_app);
            this.Controls.Add(this.btn_efis_mode_ctr);
            this.Controls.Add(this.btn_efis_sel_l_adf);
            this.Controls.Add(this.btn_efis_sel_l_off);
            this.Controls.Add(this.btn_efis_sel_l_vor);
            this.Controls.Add(this.efis_mins_dec);
            this.Controls.Add(this.efis_mins_inc);
            this.Controls.Add(this.efis_mins_reset);
            this.Controls.Add(this.efis_mins_baro);
            this.Controls.Add(this.efis_mins_radio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.efis_sta);
            this.Controls.Add(this.efis_wpt);
            this.Controls.Add(this.efis_pos);
            this.Controls.Add(this.efis_data);
            this.Controls.Add(this.efis_arpt);
            this.Controls.Add(this.efis_terr);
            this.Controls.Add(this.efis_wxr);
            this.Controls.Add(this.btn_efis_sta);
            this.Controls.Add(this.btn_efis_wpt);
            this.Controls.Add(this.btn_efis_pos);
            this.Controls.Add(this.btn_efis_data);
            this.Controls.Add(this.btn_efis_arpt);
            this.Controls.Add(this.btn_efis_terr);
            this.Controls.Add(this.btn_efis_wxr);
            this.Controls.Add(this.mcp_cmd_a);
            this.Controls.Add(this.btn_mcp_cmd_a);
            this.Controls.Add(this.btn_efis_range_160);
            this.Controls.Add(this.btn_efis_range_320);
            this.Controls.Add(this.btn_efis_range_640);
            this.Name = "MainForm";
            this.Text = "SimInterface";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton mcp_cmd_a;
        private System.Windows.Forms.Button btn_mcp_cmd_a;
        private System.Windows.Forms.Button btn_efis_wxr;
        private System.Windows.Forms.Button btn_efis_terr;
        private System.Windows.Forms.Button btn_efis_arpt;
        private System.Windows.Forms.Button btn_efis_data;
        private System.Windows.Forms.Button btn_efis_pos;
        private System.Windows.Forms.Button btn_efis_wpt;
        private System.Windows.Forms.Button btn_efis_sta;
        private System.Windows.Forms.RadioButton efis_wxr;
        private System.Windows.Forms.RadioButton efis_terr;
        private System.Windows.Forms.RadioButton efis_data;
        private System.Windows.Forms.RadioButton efis_arpt;
        private System.Windows.Forms.RadioButton efis_sta;
        private System.Windows.Forms.RadioButton efis_wpt;
        private System.Windows.Forms.RadioButton efis_pos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button efis_mins_radio;
        private System.Windows.Forms.Button efis_mins_baro;
        private System.Windows.Forms.Button efis_mins_reset;
        private System.Windows.Forms.Button efis_mins_inc;
        private System.Windows.Forms.Button efis_mins_dec;
        private System.Windows.Forms.Button btn_efis_sel_l_vor;
        private System.Windows.Forms.Button btn_efis_sel_l_off;
        private System.Windows.Forms.Button btn_efis_sel_l_adf;
        private System.Windows.Forms.Button btn_efis_mode_ctr;
        private System.Windows.Forms.Button btn_efis_mode_app;
        private System.Windows.Forms.Button btn_efis_mode_vor;
        private System.Windows.Forms.Button btn_efis_mode_map;
        private System.Windows.Forms.Button btn_efis_mode_pln;
        private System.Windows.Forms.Button btn_efis_range_160;
        private System.Windows.Forms.Button btn_efis_range_80;
        private System.Windows.Forms.Button btn_efis_range_10;
        private System.Windows.Forms.Button btn_efis_range_5;
        private System.Windows.Forms.Button btn_efis_tfc;
        private System.Windows.Forms.Button btn_efis_range_20;
        private System.Windows.Forms.Button btn_efis_range_40;
        private System.Windows.Forms.Button btn_efis_range_640;
        private System.Windows.Forms.Button btn_efis_range_320;
        private System.Windows.Forms.Button btn_efis_sel_r_adf;
        private System.Windows.Forms.Button btn_efis_sel_r_off;
        private System.Windows.Forms.Button btn_efis_sel_r_vor;
        private System.Windows.Forms.Button btn_efis_baro_dec;
        private System.Windows.Forms.Button btn_efis_baro_inc;
        private System.Windows.Forms.Button btn_efis_baro_std;
        private System.Windows.Forms.Button btn_efis_baro_hpa;
        private System.Windows.Forms.Button btn_efis_baro_in;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton efis_ctr;
        private System.Windows.Forms.RadioButton efis_tfc;
    }
}


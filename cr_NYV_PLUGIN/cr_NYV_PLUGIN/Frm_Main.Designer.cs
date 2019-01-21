namespace cr_NYV_PLUGIN
{
    partial class Frm_Main
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
            this.okApplyModifyGetOnOffCancel1 = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.cbb_Type = new Tekla.Structures.Dialog.UIControls.BoltCatalogSize();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CrankRatio = new System.Windows.Forms.TextBox();
            this.txt_Distance = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbb_Spaccing = new Tekla.Structures.Dialog.UIControls.BoltCatalogSize();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Spacing = new System.Windows.Forms.TextBox();
            this.txt_LapLenght = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_CrankOrientation = new Tekla.Structures.Dialog.UIControls.BoltCatalogSize();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // okApplyModifyGetOnOffCancel1
            // 
            this.structuresExtender.SetAttributeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.okApplyModifyGetOnOffCancel1, null);
            this.okApplyModifyGetOnOffCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(0, 421);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(800, 29);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 0;
            // 
            // cbb_Type
            // 
            this.structuresExtender.SetAttributeName(this.cbb_Type, null);
            this.structuresExtender.SetAttributeTypeName(this.cbb_Type, "Combo_Type");
            this.structuresExtender.SetBindPropertyName(this.cbb_Type, "String");
            this.cbb_Type.FormattingEnabled = true;
            this.cbb_Type.Items.AddRange(new object[] {
            "Crank ratio",
            "Distance"});
            this.cbb_Type.Location = new System.Drawing.Point(193, 58);
            this.cbb_Type.Name = "cbb_Type";
            this.cbb_Type.Size = new System.Drawing.Size(99, 21);
            this.cbb_Type.TabIndex = 3;
            this.cbb_Type.SelectedIndexChanged += new System.EventHandler(this.cbb_Type_SelectedIndexChanged);
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(190, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type";
            // 
            // txt_CrankRatio
            // 
            this.structuresExtender.SetAttributeName(this.txt_CrankRatio, "CrankRatio");
            this.structuresExtender.SetAttributeTypeName(this.txt_CrankRatio, "Integer");
            this.structuresExtender.SetBindPropertyName(this.txt_CrankRatio, null);
            this.txt_CrankRatio.Location = new System.Drawing.Point(328, 59);
            this.txt_CrankRatio.Name = "txt_CrankRatio";
            this.txt_CrankRatio.Size = new System.Drawing.Size(68, 20);
            this.txt_CrankRatio.TabIndex = 5;
            // 
            // txt_Distance
            // 
            this.structuresExtender.SetAttributeName(this.txt_Distance, "Distance");
            this.structuresExtender.SetAttributeTypeName(this.txt_Distance, "Double");
            this.structuresExtender.SetBindPropertyName(this.txt_Distance, null);
            this.txt_Distance.Location = new System.Drawing.Point(414, 59);
            this.txt_Distance.Name = "txt_Distance";
            this.txt_Distance.Size = new System.Drawing.Size(68, 20);
            this.txt_Distance.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox1, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox1, null);
            this.pictureBox1.Image = global::cr_NYV_PLUGIN.Properties.Resources.image1_20;
            this.pictureBox1.Location = new System.Drawing.Point(153, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // cbb_Spaccing
            // 
            this.structuresExtender.SetAttributeName(this.cbb_Spaccing, null);
            this.structuresExtender.SetAttributeTypeName(this.cbb_Spaccing, "Combo_Spacing");
            this.structuresExtender.SetBindPropertyName(this.cbb_Spaccing, "String");
            this.cbb_Spaccing.FormattingEnabled = true;
            this.cbb_Spaccing.Items.AddRange(new object[] {
            "Auto",
            "Fixed"});
            this.cbb_Spaccing.Location = new System.Drawing.Point(87, 134);
            this.cbb_Spaccing.Name = "cbb_Spaccing";
            this.cbb_Spaccing.Size = new System.Drawing.Size(60, 21);
            this.cbb_Spaccing.TabIndex = 8;
            this.cbb_Spaccing.SelectedIndexChanged += new System.EventHandler(this.cbb_Spaccing_SelectedIndexChanged);
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(84, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Spacing";
            // 
            // txt_Spacing
            // 
            this.structuresExtender.SetAttributeName(this.txt_Spacing, "Spacing");
            this.structuresExtender.SetAttributeTypeName(this.txt_Spacing, "Double");
            this.structuresExtender.SetBindPropertyName(this.txt_Spacing, null);
            this.txt_Spacing.Location = new System.Drawing.Point(87, 165);
            this.txt_Spacing.Name = "txt_Spacing";
            this.txt_Spacing.Size = new System.Drawing.Size(60, 20);
            this.txt_Spacing.TabIndex = 10;
            // 
            // txt_LapLenght
            // 
            this.structuresExtender.SetAttributeName(this.txt_LapLenght, "LapLenght");
            this.structuresExtender.SetAttributeTypeName(this.txt_LapLenght, "Double");
            this.structuresExtender.SetBindPropertyName(this.txt_LapLenght, null);
            this.txt_LapLenght.Location = new System.Drawing.Point(302, 234);
            this.txt_LapLenght.Name = "txt_LapLenght";
            this.txt_LapLenght.Size = new System.Drawing.Size(68, 20);
            this.txt_LapLenght.TabIndex = 11;
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(306, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lap Length";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(468, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Crank orientation";
            // 
            // cbb_CrankOrientation
            // 
            this.structuresExtender.SetAttributeName(this.cbb_CrankOrientation, null);
            this.structuresExtender.SetAttributeTypeName(this.cbb_CrankOrientation, "Combo_Crank");
            this.structuresExtender.SetBindPropertyName(this.cbb_CrankOrientation, "String");
            this.cbb_CrankOrientation.FormattingEnabled = true;
            this.cbb_CrankOrientation.Items.AddRange(new object[] {
            "Under",
            "On"});
            this.cbb_CrankOrientation.Location = new System.Drawing.Point(463, 234);
            this.cbb_CrankOrientation.Name = "cbb_CrankOrientation";
            this.cbb_CrankOrientation.Size = new System.Drawing.Size(99, 21);
            this.cbb_CrankOrientation.TabIndex = 14;
            // 
            // Frm_Main
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbb_CrankOrientation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_LapLenght);
            this.Controls.Add(this.txt_Spacing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbb_Spaccing);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_Distance);
            this.Controls.Add(this.txt_CrankRatio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_Type);
            this.Controls.Add(this.okApplyModifyGetOnOffCancel1);
            this.Name = "Frm_Main";
            this.Text = "Crank";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel okApplyModifyGetOnOffCancel1;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogSize cbb_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CrankRatio;
        private System.Windows.Forms.TextBox txt_Distance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogSize cbb_Spaccing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Spacing;
        private System.Windows.Forms.TextBox txt_LapLenght;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Tekla.Structures.Dialog.UIControls.BoltCatalogSize cbb_CrankOrientation;
    }
}
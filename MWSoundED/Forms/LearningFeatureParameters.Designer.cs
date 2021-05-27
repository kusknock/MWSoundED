namespace MWSoundED
{
    partial class LearningFeatureParameters
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
            this.groupCepstre = new System.Windows.Forms.GroupBox();
            this.checkEnergy = new System.Windows.Forms.CheckBox();
            this.checkDeltaDelta = new System.Windows.Forms.CheckBox();
            this.checkDelta = new System.Windows.Forms.CheckBox();
            this.checkVariance = new System.Windows.Forms.CheckBox();
            this.checkMean = new System.Windows.Forms.CheckBox();
            this.checkCepstreOld = new System.Windows.Forms.CheckBox();
            this.numCoeffCepstre = new System.Windows.Forms.NumericUpDown();
            this.lblCoeffCepstre = new System.Windows.Forms.Label();
            this.groupBands = new System.Windows.Forms.GroupBox();
            this.checkBanksOld = new System.Windows.Forms.CheckBox();
            this.numUpFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblUpFrequency = new System.Windows.Forms.Label();
            this.numLowFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblLowFrequency = new System.Windows.Forms.Label();
            this.numFilters = new System.Windows.Forms.NumericUpDown();
            this.lblNumFilter = new System.Windows.Forms.Label();
            this.comboBands = new System.Windows.Forms.ComboBox();
            this.groupDiscreteTransform = new System.Windows.Forms.GroupBox();
            this.numA = new System.Windows.Forms.NumericUpDown();
            this.lblA = new System.Windows.Forms.Label();
            this.checkPreemphasis = new System.Windows.Forms.CheckBox();
            this.checkFillNull = new System.Windows.Forms.CheckBox();
            this.checkShort = new System.Windows.Forms.CheckBox();
            this.numWindowSize = new System.Windows.Forms.NumericUpDown();
            this.lblWindowSize = new System.Windows.Forms.Label();
            this.numWindowShift = new System.Windows.Forms.NumericUpDown();
            this.lblWindowShift = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.groupCepstre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffCepstre)).BeginInit();
            this.groupBands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilters)).BeginInit();
            this.groupDiscreteTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowShift)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCepstre
            // 
            this.groupCepstre.Controls.Add(this.checkEnergy);
            this.groupCepstre.Controls.Add(this.checkDeltaDelta);
            this.groupCepstre.Controls.Add(this.checkDelta);
            this.groupCepstre.Controls.Add(this.checkVariance);
            this.groupCepstre.Controls.Add(this.checkMean);
            this.groupCepstre.Controls.Add(this.checkCepstreOld);
            this.groupCepstre.Controls.Add(this.numCoeffCepstre);
            this.groupCepstre.Controls.Add(this.lblCoeffCepstre);
            this.groupCepstre.Location = new System.Drawing.Point(666, 12);
            this.groupCepstre.Name = "groupCepstre";
            this.groupCepstre.Size = new System.Drawing.Size(321, 141);
            this.groupCepstre.TabIndex = 57;
            this.groupCepstre.TabStop = false;
            this.groupCepstre.Text = "Кепстральные коэффициенты:";
            // 
            // checkEnergy
            // 
            this.checkEnergy.AutoSize = true;
            this.checkEnergy.Location = new System.Drawing.Point(141, 104);
            this.checkEnergy.Name = "checkEnergy";
            this.checkEnergy.Size = new System.Drawing.Size(128, 21);
            this.checkEnergy.TabIndex = 52;
            this.checkEnergy.Text = "Energy Feature";
            this.checkEnergy.UseVisualStyleBackColor = true;
            // 
            // checkDeltaDelta
            // 
            this.checkDeltaDelta.AutoSize = true;
            this.checkDeltaDelta.Location = new System.Drawing.Point(9, 105);
            this.checkDeltaDelta.Name = "checkDeltaDelta";
            this.checkDeltaDelta.Size = new System.Drawing.Size(126, 21);
            this.checkDeltaDelta.TabIndex = 51;
            this.checkDeltaDelta.Text = "Add delta-delta";
            this.checkDeltaDelta.UseVisualStyleBackColor = true;
            // 
            // checkDelta
            // 
            this.checkDelta.AutoSize = true;
            this.checkDelta.Location = new System.Drawing.Point(191, 78);
            this.checkDelta.Name = "checkDelta";
            this.checkDelta.Size = new System.Drawing.Size(90, 21);
            this.checkDelta.TabIndex = 50;
            this.checkDelta.Text = "Add delta";
            this.checkDelta.UseVisualStyleBackColor = true;
            // 
            // checkVariance
            // 
            this.checkVariance.AutoSize = true;
            this.checkVariance.Location = new System.Drawing.Point(9, 78);
            this.checkVariance.Name = "checkVariance";
            this.checkVariance.Size = new System.Drawing.Size(176, 21);
            this.checkVariance.TabIndex = 49;
            this.checkVariance.Text = "Variance Normalization";
            this.checkVariance.UseVisualStyleBackColor = true;
            // 
            // checkMean
            // 
            this.checkMean.AutoSize = true;
            this.checkMean.Location = new System.Drawing.Point(9, 49);
            this.checkMean.Name = "checkMean";
            this.checkMean.Size = new System.Drawing.Size(155, 21);
            this.checkMean.TabIndex = 48;
            this.checkMean.Text = "Mean Normalization";
            this.checkMean.UseVisualStyleBackColor = true;
            // 
            // checkCepstreOld
            // 
            this.checkCepstreOld.AutoSize = true;
            this.checkCepstreOld.Location = new System.Drawing.Point(170, 49);
            this.checkCepstreOld.Name = "checkCepstreOld";
            this.checkCepstreOld.Size = new System.Drawing.Size(128, 21);
            this.checkCepstreOld.TabIndex = 47;
            this.checkCepstreOld.Text = "Старая версия";
            this.checkCepstreOld.UseVisualStyleBackColor = true;
            // 
            // numCoeffCepstre
            // 
            this.numCoeffCepstre.Location = new System.Drawing.Point(212, 21);
            this.numCoeffCepstre.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numCoeffCepstre.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCoeffCepstre.Name = "numCoeffCepstre";
            this.numCoeffCepstre.Size = new System.Drawing.Size(102, 22);
            this.numCoeffCepstre.TabIndex = 40;
            this.numCoeffCepstre.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lblCoeffCepstre
            // 
            this.lblCoeffCepstre.AutoSize = true;
            this.lblCoeffCepstre.Location = new System.Drawing.Point(39, 23);
            this.lblCoeffCepstre.Name = "lblCoeffCepstre";
            this.lblCoeffCepstre.Size = new System.Drawing.Size(167, 17);
            this.lblCoeffCepstre.TabIndex = 41;
            this.lblCoeffCepstre.Text = "Кол-во коэффициентов:";
            // 
            // groupBands
            // 
            this.groupBands.Controls.Add(this.checkBanksOld);
            this.groupBands.Controls.Add(this.numUpFrequency);
            this.groupBands.Controls.Add(this.lblUpFrequency);
            this.groupBands.Controls.Add(this.numLowFrequency);
            this.groupBands.Controls.Add(this.lblLowFrequency);
            this.groupBands.Controls.Add(this.numFilters);
            this.groupBands.Controls.Add(this.lblNumFilter);
            this.groupBands.Controls.Add(this.comboBands);
            this.groupBands.Location = new System.Drawing.Point(339, 12);
            this.groupBands.Name = "groupBands";
            this.groupBands.Size = new System.Drawing.Size(321, 185);
            this.groupBands.TabIndex = 56;
            this.groupBands.TabStop = false;
            this.groupBands.Text = "Банки фильтров:";
            // 
            // checkBanksOld
            // 
            this.checkBanksOld.AutoSize = true;
            this.checkBanksOld.Location = new System.Drawing.Point(9, 118);
            this.checkBanksOld.Name = "checkBanksOld";
            this.checkBanksOld.Size = new System.Drawing.Size(128, 21);
            this.checkBanksOld.TabIndex = 47;
            this.checkBanksOld.Text = "Старая версия";
            this.checkBanksOld.UseVisualStyleBackColor = true;
            // 
            // numUpFrequency
            // 
            this.numUpFrequency.Location = new System.Drawing.Point(179, 53);
            this.numUpFrequency.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.numUpFrequency.Name = "numUpFrequency";
            this.numUpFrequency.Size = new System.Drawing.Size(102, 22);
            this.numUpFrequency.TabIndex = 44;
            this.numUpFrequency.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // lblUpFrequency
            // 
            this.lblUpFrequency.AutoSize = true;
            this.lblUpFrequency.Location = new System.Drawing.Point(49, 55);
            this.lblUpFrequency.Name = "lblUpFrequency";
            this.lblUpFrequency.Size = new System.Drawing.Size(124, 17);
            this.lblUpFrequency.TabIndex = 45;
            this.lblUpFrequency.Text = "Верхняя частота:";
            // 
            // numLowFrequency
            // 
            this.numLowFrequency.Location = new System.Drawing.Point(179, 25);
            this.numLowFrequency.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.numLowFrequency.Name = "numLowFrequency";
            this.numLowFrequency.Size = new System.Drawing.Size(102, 22);
            this.numLowFrequency.TabIndex = 42;
            this.numLowFrequency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblLowFrequency
            // 
            this.lblLowFrequency.AutoSize = true;
            this.lblLowFrequency.Location = new System.Drawing.Point(53, 26);
            this.lblLowFrequency.Name = "lblLowFrequency";
            this.lblLowFrequency.Size = new System.Drawing.Size(120, 17);
            this.lblLowFrequency.TabIndex = 43;
            this.lblLowFrequency.Text = "Нижняя частота:";
            // 
            // numFilters
            // 
            this.numFilters.Location = new System.Drawing.Point(179, 81);
            this.numFilters.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numFilters.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numFilters.Name = "numFilters";
            this.numFilters.Size = new System.Drawing.Size(102, 22);
            this.numFilters.TabIndex = 40;
            this.numFilters.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblNumFilter
            // 
            this.lblNumFilter.AutoSize = true;
            this.lblNumFilter.Location = new System.Drawing.Point(43, 83);
            this.lblNumFilter.Name = "lblNumFilter";
            this.lblNumFilter.Size = new System.Drawing.Size(125, 17);
            this.lblNumFilter.TabIndex = 41;
            this.lblNumFilter.Text = "Кол-во фильтров:";
            // 
            // comboBands
            // 
            this.comboBands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBands.FormattingEnabled = true;
            this.comboBands.Items.AddRange(new object[] {
            "Банк мел-фильтров",
            "Банк гамматон-фильтров"});
            this.comboBands.Location = new System.Drawing.Point(9, 145);
            this.comboBands.Name = "comboBands";
            this.comboBands.Size = new System.Drawing.Size(305, 24);
            this.comboBands.TabIndex = 11;
            // 
            // groupDiscreteTransform
            // 
            this.groupDiscreteTransform.Controls.Add(this.numA);
            this.groupDiscreteTransform.Controls.Add(this.lblA);
            this.groupDiscreteTransform.Controls.Add(this.checkPreemphasis);
            this.groupDiscreteTransform.Controls.Add(this.checkFillNull);
            this.groupDiscreteTransform.Controls.Add(this.checkShort);
            this.groupDiscreteTransform.Controls.Add(this.numWindowSize);
            this.groupDiscreteTransform.Controls.Add(this.lblWindowSize);
            this.groupDiscreteTransform.Controls.Add(this.numWindowShift);
            this.groupDiscreteTransform.Controls.Add(this.lblWindowShift);
            this.groupDiscreteTransform.Location = new System.Drawing.Point(12, 12);
            this.groupDiscreteTransform.Name = "groupDiscreteTransform";
            this.groupDiscreteTransform.Size = new System.Drawing.Size(321, 135);
            this.groupDiscreteTransform.TabIndex = 55;
            this.groupDiscreteTransform.TabStop = false;
            this.groupDiscreteTransform.Text = "Оконное преобразование Фурье:";
            // 
            // numA
            // 
            this.numA.DecimalPlaces = 2;
            this.numA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numA.Location = new System.Drawing.Point(152, 101);
            this.numA.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numA.Name = "numA";
            this.numA.Size = new System.Drawing.Size(102, 22);
            this.numA.TabIndex = 47;
            this.numA.Value = new decimal(new int[] {
            97,
            0,
            0,
            131072});
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(126, 103);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(28, 17);
            this.lblA.TabIndex = 48;
            this.lblA.Text = "a =";
            // 
            // checkPreemphasis
            // 
            this.checkPreemphasis.AutoSize = true;
            this.checkPreemphasis.Location = new System.Drawing.Point(16, 102);
            this.checkPreemphasis.Name = "checkPreemphasis";
            this.checkPreemphasis.Size = new System.Drawing.Size(112, 21);
            this.checkPreemphasis.TabIndex = 46;
            this.checkPreemphasis.Text = "Preemphasis";
            this.checkPreemphasis.UseVisualStyleBackColor = true;
            // 
            // checkFillNull
            // 
            this.checkFillNull.AutoSize = true;
            this.checkFillNull.Checked = true;
            this.checkFillNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFillNull.Location = new System.Drawing.Point(16, 75);
            this.checkFillNull.Name = "checkFillNull";
            this.checkFillNull.Size = new System.Drawing.Size(163, 21);
            this.checkFillNull.TabIndex = 45;
            this.checkFillNull.Text = "Заполнение нулями";
            this.checkFillNull.UseVisualStyleBackColor = true;
            // 
            // checkShort
            // 
            this.checkShort.AutoSize = true;
            this.checkShort.Location = new System.Drawing.Point(185, 75);
            this.checkShort.Name = "checkShort";
            this.checkShort.Size = new System.Drawing.Size(73, 21);
            this.checkShort.TabIndex = 44;
            this.checkShort.Text = "16 бит";
            this.checkShort.UseVisualStyleBackColor = true;
            // 
            // numWindowSize
            // 
            this.numWindowSize.Location = new System.Drawing.Point(212, 19);
            this.numWindowSize.Name = "numWindowSize";
            this.numWindowSize.Size = new System.Drawing.Size(102, 22);
            this.numWindowSize.TabIndex = 40;
            this.numWindowSize.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblWindowSize
            // 
            this.lblWindowSize.AutoSize = true;
            this.lblWindowSize.Location = new System.Drawing.Point(80, 21);
            this.lblWindowSize.Name = "lblWindowSize";
            this.lblWindowSize.Size = new System.Drawing.Size(126, 17);
            this.lblWindowSize.TabIndex = 41;
            this.lblWindowSize.Text = "Размер окна (мс):";
            // 
            // numWindowShift
            // 
            this.numWindowShift.Location = new System.Drawing.Point(212, 47);
            this.numWindowShift.Name = "numWindowShift";
            this.numWindowShift.Size = new System.Drawing.Size(102, 22);
            this.numWindowShift.TabIndex = 38;
            this.numWindowShift.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblWindowShift
            // 
            this.lblWindowShift.AutoSize = true;
            this.lblWindowShift.Location = new System.Drawing.Point(31, 48);
            this.lblWindowShift.Name = "lblWindowShift";
            this.lblWindowShift.Size = new System.Drawing.Size(175, 17);
            this.lblWindowShift.TabIndex = 39;
            this.lblWindowShift.Text = "Размер перекрытия (мс):";
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(906, 159);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(87, 38);
            this.btnHide.TabIndex = 58;
            this.btnHide.Text = "Закрыть";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // LearningFeatureParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 206);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.groupCepstre);
            this.Controls.Add(this.groupBands);
            this.Controls.Add(this.groupDiscreteTransform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LearningFeatureParameters";
            this.Text = "Параметры признаков - MWSoundED";
            this.groupCepstre.ResumeLayout(false);
            this.groupCepstre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffCepstre)).EndInit();
            this.groupBands.ResumeLayout(false);
            this.groupBands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilters)).EndInit();
            this.groupDiscreteTransform.ResumeLayout(false);
            this.groupDiscreteTransform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCepstre;
        private System.Windows.Forms.Label lblCoeffCepstre;
        private System.Windows.Forms.GroupBox groupBands;
        private System.Windows.Forms.Label lblUpFrequency;
        private System.Windows.Forms.Label lblLowFrequency;
        private System.Windows.Forms.Label lblNumFilter;
        private System.Windows.Forms.GroupBox groupDiscreteTransform;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblWindowSize;
        private System.Windows.Forms.Label lblWindowShift;
        public System.Windows.Forms.CheckBox checkEnergy;
        public System.Windows.Forms.CheckBox checkDeltaDelta;
        public System.Windows.Forms.CheckBox checkDelta;
        public System.Windows.Forms.CheckBox checkVariance;
        public System.Windows.Forms.CheckBox checkMean;
        public System.Windows.Forms.CheckBox checkCepstreOld;
        public System.Windows.Forms.NumericUpDown numCoeffCepstre;
        public System.Windows.Forms.CheckBox checkBanksOld;
        public System.Windows.Forms.NumericUpDown numUpFrequency;
        public System.Windows.Forms.NumericUpDown numLowFrequency;
        public System.Windows.Forms.NumericUpDown numFilters;
        public System.Windows.Forms.ComboBox comboBands;
        public System.Windows.Forms.NumericUpDown numA;
        public System.Windows.Forms.CheckBox checkPreemphasis;
        public System.Windows.Forms.CheckBox checkFillNull;
        public System.Windows.Forms.CheckBox checkShort;
        public System.Windows.Forms.NumericUpDown numWindowSize;
        public System.Windows.Forms.NumericUpDown numWindowShift;
        private System.Windows.Forms.Button btnHide;
    }
}
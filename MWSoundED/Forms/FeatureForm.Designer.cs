namespace MWSoundED
{
    partial class FeatureForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecorderForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelpFeatures = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.graphControl = new ZedGraph.ZedGraphControl();
            this.groupGraph = new System.Windows.Forms.GroupBox();
            this.bandsPanel = new MWSoundED.SpectrogramPlot();
            this.spectrogramPanel = new MWSoundED.SpectrogramPlot();
            this.featuresPanel = new MWSoundED.SpectrogramPlot();
            this.groupBank = new System.Windows.Forms.GroupBox();
            this.bankPlot = new MWSoundED.GroupPlot();
            this.comboGraph = new System.Windows.Forms.ComboBox();
            this.groupDiscreteTransform = new System.Windows.Forms.GroupBox();
            this.btnPlaySegment = new System.Windows.Forms.Button();
            this.numStartValue = new System.Windows.Forms.NumericUpDown();
            this.lblStartValue = new System.Windows.Forms.Label();
            this.btnFourier = new System.Windows.Forms.Button();
            this.numA = new System.Windows.Forms.NumericUpDown();
            this.lblA = new System.Windows.Forms.Label();
            this.checkPreemphasis = new System.Windows.Forms.CheckBox();
            this.checkFillNull = new System.Windows.Forms.CheckBox();
            this.checkShort = new System.Windows.Forms.CheckBox();
            this.numEndValue = new System.Windows.Forms.NumericUpDown();
            this.numWindowSize = new System.Windows.Forms.NumericUpDown();
            this.lblEndSegment = new System.Windows.Forms.Label();
            this.lblWindowSize = new System.Windows.Forms.Label();
            this.numWindowShift = new System.Windows.Forms.NumericUpDown();
            this.lblWindowShift = new System.Windows.Forms.Label();
            this.groupBands = new System.Windows.Forms.GroupBox();
            this.checkBanksOld = new System.Windows.Forms.CheckBox();
            this.numUpFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblUpFrequency = new System.Windows.Forms.Label();
            this.numLowFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblLowFrequency = new System.Windows.Forms.Label();
            this.numFilters = new System.Windows.Forms.NumericUpDown();
            this.lblNumFilter = new System.Windows.Forms.Label();
            this.comboBands = new System.Windows.Forms.ComboBox();
            this.btnBands = new System.Windows.Forms.Button();
            this.groupCepstre = new System.Windows.Forms.GroupBox();
            this.checkEnergy = new System.Windows.Forms.CheckBox();
            this.checkDeltaDelta = new System.Windows.Forms.CheckBox();
            this.checkDelta = new System.Windows.Forms.CheckBox();
            this.checkVariance = new System.Windows.Forms.CheckBox();
            this.checkMean = new System.Windows.Forms.CheckBox();
            this.checkCepstreOld = new System.Windows.Forms.CheckBox();
            this.numCoeffCepstre = new System.Windows.Forms.NumericUpDown();
            this.lblCoeffCepstre = new System.Windows.Forms.Label();
            this.btnCepstre = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupExtractWav = new System.Windows.Forms.GroupBox();
            this.btnPathSaveWave = new System.Windows.Forms.Button();
            this.txbPathSaveWave = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnPathVideo = new System.Windows.Forms.Button();
            this.txbPathVideo = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupGraph.SuspendLayout();
            this.groupBank.SuspendLayout();
            this.groupDiscreteTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowShift)).BeginInit();
            this.groupBands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilters)).BeginInit();
            this.groupCepstre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffCepstre)).BeginInit();
            this.groupExtractWav.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1144, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnRecorderForm,
            this.btnClose});
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(57, 24);
            this.btnFile.Text = "Файл";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(185, 26);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRecorderForm
            // 
            this.btnRecorderForm.Name = "btnRecorderForm";
            this.btnRecorderForm.Size = new System.Drawing.Size(185, 26);
            this.btnRecorderForm.Text = "Записать (Rec)";
            this.btnRecorderForm.Click += new System.EventHandler(this.btnRecorderForm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(185, 26);
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHelpFeatures});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // btnHelpFeatures
            // 
            this.btnHelpFeatures.Name = "btnHelpFeatures";
            this.btnHelpFeatures.Size = new System.Drawing.Size(231, 26);
            this.btnHelpFeatures.Text = "Справка «Признаки»";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 518);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1144, 25);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(57, 20);
            this.StatusLabel.Text = "Готово";
            // 
            // graphControl
            // 
            this.graphControl.BackColor = System.Drawing.SystemColors.Control;
            this.graphControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.graphControl.Location = new System.Drawing.Point(3, 418);
            this.graphControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphControl.Name = "graphControl";
            this.graphControl.ScrollGrace = 0D;
            this.graphControl.ScrollMaxX = 0D;
            this.graphControl.ScrollMaxY = 0D;
            this.graphControl.ScrollMaxY2 = 0D;
            this.graphControl.ScrollMinX = 0D;
            this.graphControl.ScrollMinY = 0D;
            this.graphControl.ScrollMinY2 = 0D;
            this.graphControl.Size = new System.Drawing.Size(468, 200);
            this.graphControl.TabIndex = 6;
            this.graphControl.UseExtendedPrintDialog = true;
            this.graphControl.Visible = false;
            this.graphControl.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            this.graphControl.ZoomStepFraction = 0D;
            // 
            // groupGraph
            // 
            this.groupGraph.Controls.Add(this.bandsPanel);
            this.groupGraph.Controls.Add(this.graphControl);
            this.groupGraph.Controls.Add(this.spectrogramPanel);
            this.groupGraph.Controls.Add(this.featuresPanel);
            this.groupGraph.Location = new System.Drawing.Point(9, 61);
            this.groupGraph.Name = "groupGraph";
            this.groupGraph.Size = new System.Drawing.Size(474, 220);
            this.groupGraph.TabIndex = 10;
            this.groupGraph.TabStop = false;
            this.groupGraph.Text = "Графическое представление сигнала";
            // 
            // bandsPanel
            // 
            this.bandsPanel.AutoScroll = true;
            this.bandsPanel.BackColor = System.Drawing.Color.Black;
            this.bandsPanel.ColorMapName = "viridis";
            this.bandsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bandsPanel.Location = new System.Drawing.Point(3, 618);
            this.bandsPanel.Markline = null;
            this.bandsPanel.MarklineThickness = 0;
            this.bandsPanel.Name = "bandsPanel";
            this.bandsPanel.Size = new System.Drawing.Size(468, 200);
            this.bandsPanel.Spectrogram = null;
            this.bandsPanel.TabIndex = 9;
            this.bandsPanel.Visible = false;
            // 
            // spectrogramPanel
            // 
            this.spectrogramPanel.AutoScroll = true;
            this.spectrogramPanel.BackColor = System.Drawing.Color.Black;
            this.spectrogramPanel.ColorMapName = "viridis";
            this.spectrogramPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.spectrogramPanel.Location = new System.Drawing.Point(3, 218);
            this.spectrogramPanel.Markline = null;
            this.spectrogramPanel.MarklineThickness = 0;
            this.spectrogramPanel.Name = "spectrogramPanel";
            this.spectrogramPanel.Size = new System.Drawing.Size(468, 200);
            this.spectrogramPanel.Spectrogram = null;
            this.spectrogramPanel.TabIndex = 7;
            this.spectrogramPanel.Visible = false;
            // 
            // featuresPanel
            // 
            this.featuresPanel.AutoScroll = true;
            this.featuresPanel.BackColor = System.Drawing.Color.Black;
            this.featuresPanel.ColorMapName = "viridis";
            this.featuresPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.featuresPanel.Location = new System.Drawing.Point(3, 18);
            this.featuresPanel.Markline = null;
            this.featuresPanel.MarklineThickness = 0;
            this.featuresPanel.Name = "featuresPanel";
            this.featuresPanel.Size = new System.Drawing.Size(468, 200);
            this.featuresPanel.Spectrogram = null;
            this.featuresPanel.TabIndex = 8;
            this.featuresPanel.Visible = false;
            // 
            // groupBank
            // 
            this.groupBank.Controls.Add(this.bankPlot);
            this.groupBank.Enabled = false;
            this.groupBank.Location = new System.Drawing.Point(12, 287);
            this.groupBank.Name = "groupBank";
            this.groupBank.Size = new System.Drawing.Size(468, 217);
            this.groupBank.TabIndex = 11;
            this.groupBank.TabStop = false;
            this.groupBank.Text = "График банка фильтров";
            // 
            // bankPlot
            // 
            this.bankPlot.AutoScroll = true;
            this.bankPlot.BackColor = System.Drawing.Color.White;
            this.bankPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bankPlot.Gain = 100;
            this.bankPlot.Groups = null;
            this.bankPlot.Location = new System.Drawing.Point(3, 18);
            this.bankPlot.Name = "bankPlot";
            this.bankPlot.Size = new System.Drawing.Size(462, 196);
            this.bankPlot.Stride = 2;
            this.bankPlot.TabIndex = 9;
            // 
            // comboGraph
            // 
            this.comboGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGraph.FormattingEnabled = true;
            this.comboGraph.Location = new System.Drawing.Point(9, 31);
            this.comboGraph.Name = "comboGraph";
            this.comboGraph.Size = new System.Drawing.Size(375, 24);
            this.comboGraph.TabIndex = 12;
            this.comboGraph.SelectedIndexChanged += new System.EventHandler(this.comboGraph_SelectedIndexChanged);
            // 
            // groupDiscreteTransform
            // 
            this.groupDiscreteTransform.Controls.Add(this.btnPlaySegment);
            this.groupDiscreteTransform.Controls.Add(this.numStartValue);
            this.groupDiscreteTransform.Controls.Add(this.lblStartValue);
            this.groupDiscreteTransform.Controls.Add(this.btnFourier);
            this.groupDiscreteTransform.Controls.Add(this.numA);
            this.groupDiscreteTransform.Controls.Add(this.lblA);
            this.groupDiscreteTransform.Controls.Add(this.checkPreemphasis);
            this.groupDiscreteTransform.Controls.Add(this.checkFillNull);
            this.groupDiscreteTransform.Controls.Add(this.checkShort);
            this.groupDiscreteTransform.Controls.Add(this.numEndValue);
            this.groupDiscreteTransform.Controls.Add(this.numWindowSize);
            this.groupDiscreteTransform.Controls.Add(this.lblEndSegment);
            this.groupDiscreteTransform.Controls.Add(this.lblWindowSize);
            this.groupDiscreteTransform.Controls.Add(this.numWindowShift);
            this.groupDiscreteTransform.Controls.Add(this.lblWindowShift);
            this.groupDiscreteTransform.Enabled = false;
            this.groupDiscreteTransform.Location = new System.Drawing.Point(489, 31);
            this.groupDiscreteTransform.Name = "groupDiscreteTransform";
            this.groupDiscreteTransform.Size = new System.Drawing.Size(321, 243);
            this.groupDiscreteTransform.TabIndex = 15;
            this.groupDiscreteTransform.TabStop = false;
            this.groupDiscreteTransform.Text = "Оконное преобразование Фурье:";
            // 
            // btnPlaySegment
            // 
            this.btnPlaySegment.Location = new System.Drawing.Point(173, 199);
            this.btnPlaySegment.Name = "btnPlaySegment";
            this.btnPlaySegment.Size = new System.Drawing.Size(141, 36);
            this.btnPlaySegment.TabIndex = 52;
            this.btnPlaySegment.Text = "Играть сегмент";
            this.btnPlaySegment.UseVisualStyleBackColor = true;
            this.btnPlaySegment.Click += new System.EventHandler(this.btnPlaySegment_Click);
            // 
            // numStartValue
            // 
            this.numStartValue.DecimalPlaces = 3;
            this.numStartValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numStartValue.Location = new System.Drawing.Point(212, 75);
            this.numStartValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStartValue.Name = "numStartValue";
            this.numStartValue.Size = new System.Drawing.Size(102, 22);
            this.numStartValue.TabIndex = 50;
            // 
            // lblStartValue
            // 
            this.lblStartValue.AutoSize = true;
            this.lblStartValue.Location = new System.Drawing.Point(55, 77);
            this.lblStartValue.Name = "lblStartValue";
            this.lblStartValue.Size = new System.Drawing.Size(151, 17);
            this.lblStartValue.TabIndex = 51;
            this.lblStartValue.Text = "Старт сегмента (сек):";
            // 
            // btnFourier
            // 
            this.btnFourier.Location = new System.Drawing.Point(6, 199);
            this.btnFourier.Name = "btnFourier";
            this.btnFourier.Size = new System.Drawing.Size(162, 36);
            this.btnFourier.TabIndex = 49;
            this.btnFourier.Text = "Старт";
            this.btnFourier.UseVisualStyleBackColor = true;
            this.btnFourier.Click += new System.EventHandler(this.btnFourier_Click);
            // 
            // numA
            // 
            this.numA.DecimalPlaces = 2;
            this.numA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numA.Location = new System.Drawing.Point(148, 171);
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
            this.lblA.Location = new System.Drawing.Point(122, 173);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(28, 17);
            this.lblA.TabIndex = 48;
            this.lblA.Text = "a =";
            // 
            // checkPreemphasis
            // 
            this.checkPreemphasis.AutoSize = true;
            this.checkPreemphasis.Location = new System.Drawing.Point(12, 172);
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
            this.checkFillNull.Location = new System.Drawing.Point(12, 145);
            this.checkFillNull.Name = "checkFillNull";
            this.checkFillNull.Size = new System.Drawing.Size(163, 21);
            this.checkFillNull.TabIndex = 45;
            this.checkFillNull.Text = "Заполнение нулями";
            this.checkFillNull.UseVisualStyleBackColor = true;
            // 
            // checkShort
            // 
            this.checkShort.AutoSize = true;
            this.checkShort.Location = new System.Drawing.Point(181, 145);
            this.checkShort.Name = "checkShort";
            this.checkShort.Size = new System.Drawing.Size(73, 21);
            this.checkShort.TabIndex = 44;
            this.checkShort.Text = "16 бит";
            this.checkShort.UseVisualStyleBackColor = true;
            // 
            // numEndValue
            // 
            this.numEndValue.DecimalPlaces = 3;
            this.numEndValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numEndValue.Location = new System.Drawing.Point(212, 104);
            this.numEndValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEndValue.Name = "numEndValue";
            this.numEndValue.Size = new System.Drawing.Size(102, 22);
            this.numEndValue.TabIndex = 42;
            // 
            // numWindowSize
            // 
            this.numWindowSize.Location = new System.Drawing.Point(212, 19);
            this.numWindowSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numWindowSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numWindowSize.Name = "numWindowSize";
            this.numWindowSize.Size = new System.Drawing.Size(102, 22);
            this.numWindowSize.TabIndex = 40;
            this.numWindowSize.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblEndSegment
            // 
            this.lblEndSegment.AutoSize = true;
            this.lblEndSegment.Location = new System.Drawing.Point(51, 106);
            this.lblEndSegment.Name = "lblEndSegment";
            this.lblEndSegment.Size = new System.Drawing.Size(153, 17);
            this.lblEndSegment.TabIndex = 43;
            this.lblEndSegment.Text = "Конец сегмента (сек):";
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
            this.numWindowShift.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numWindowShift.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
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
            this.groupBands.Controls.Add(this.btnBands);
            this.groupBands.Enabled = false;
            this.groupBands.Location = new System.Drawing.Point(489, 280);
            this.groupBands.Name = "groupBands";
            this.groupBands.Size = new System.Drawing.Size(321, 224);
            this.groupBands.TabIndex = 50;
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
            64,
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
            // btnBands
            // 
            this.btnBands.Location = new System.Drawing.Point(9, 175);
            this.btnBands.Name = "btnBands";
            this.btnBands.Size = new System.Drawing.Size(306, 41);
            this.btnBands.TabIndex = 5;
            this.btnBands.Text = "Старт";
            this.btnBands.UseVisualStyleBackColor = true;
            this.btnBands.Click += new System.EventHandler(this.btnBands_Click);
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
            this.groupCepstre.Controls.Add(this.btnCepstre);
            this.groupCepstre.Enabled = false;
            this.groupCepstre.Location = new System.Drawing.Point(816, 31);
            this.groupCepstre.Name = "groupCepstre";
            this.groupCepstre.Size = new System.Drawing.Size(321, 180);
            this.groupCepstre.TabIndex = 51;
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
            // btnCepstre
            // 
            this.btnCepstre.Location = new System.Drawing.Point(6, 132);
            this.btnCepstre.Name = "btnCepstre";
            this.btnCepstre.Size = new System.Drawing.Size(306, 41);
            this.btnCepstre.TabIndex = 5;
            this.btnCepstre.Text = "Старт";
            this.btnCepstre.UseVisualStyleBackColor = true;
            this.btnCepstre.Click += new System.EventHandler(this.btnCepstre_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(390, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 24);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupExtractWav
            // 
            this.groupExtractWav.Controls.Add(this.btnPathSaveWave);
            this.groupExtractWav.Controls.Add(this.txbPathSaveWave);
            this.groupExtractWav.Controls.Add(this.btnExtract);
            this.groupExtractWav.Controls.Add(this.btnPathVideo);
            this.groupExtractWav.Controls.Add(this.txbPathVideo);
            this.groupExtractWav.Location = new System.Drawing.Point(816, 217);
            this.groupExtractWav.Name = "groupExtractWav";
            this.groupExtractWav.Size = new System.Drawing.Size(321, 130);
            this.groupExtractWav.TabIndex = 53;
            this.groupExtractWav.TabStop = false;
            this.groupExtractWav.Text = "Извлечение аудиодорожки";
            // 
            // btnPathSaveWave
            // 
            this.btnPathSaveWave.Location = new System.Drawing.Point(241, 49);
            this.btnPathSaveWave.Name = "btnPathSaveWave";
            this.btnPathSaveWave.Size = new System.Drawing.Size(75, 23);
            this.btnPathSaveWave.TabIndex = 7;
            this.btnPathSaveWave.Text = "...";
            this.btnPathSaveWave.UseVisualStyleBackColor = true;
            this.btnPathSaveWave.Click += new System.EventHandler(this.btnPathSaveWave_Click);
            // 
            // txbPathSaveWave
            // 
            this.txbPathSaveWave.Location = new System.Drawing.Point(6, 50);
            this.txbPathSaveWave.Name = "txbPathSaveWave";
            this.txbPathSaveWave.Size = new System.Drawing.Size(214, 22);
            this.txbPathSaveWave.TabIndex = 6;
            this.txbPathSaveWave.Text = "Папка для сохранения";
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(6, 83);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(308, 35);
            this.btnExtract.TabIndex = 5;
            this.btnExtract.Text = "Извлечь";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnPathVideo
            // 
            this.btnPathVideo.Location = new System.Drawing.Point(241, 20);
            this.btnPathVideo.Name = "btnPathVideo";
            this.btnPathVideo.Size = new System.Drawing.Size(75, 23);
            this.btnPathVideo.TabIndex = 2;
            this.btnPathVideo.Text = "...";
            this.btnPathVideo.UseVisualStyleBackColor = true;
            this.btnPathVideo.Click += new System.EventHandler(this.btnPathVideo_Click);
            // 
            // txbPathVideo
            // 
            this.txbPathVideo.Location = new System.Drawing.Point(6, 21);
            this.txbPathVideo.Name = "txbPathVideo";
            this.txbPathVideo.Size = new System.Drawing.Size(214, 22);
            this.txbPathVideo.TabIndex = 0;
            this.txbPathVideo.Text = "Путь до видео";
            // 
            // FeatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1144, 543);
            this.Controls.Add(this.groupExtractWav);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupCepstre);
            this.Controls.Add(this.groupBands);
            this.Controls.Add(this.groupDiscreteTransform);
            this.Controls.Add(this.comboGraph);
            this.Controls.Add(this.groupBank);
            this.Controls.Add(this.groupGraph);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FeatureForm";
            this.Text = "Признаки - MWSoundED";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupGraph.ResumeLayout(false);
            this.groupBank.ResumeLayout(false);
            this.groupDiscreteTransform.ResumeLayout(false);
            this.groupDiscreteTransform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowShift)).EndInit();
            this.groupBands.ResumeLayout(false);
            this.groupBands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilters)).EndInit();
            this.groupCepstre.ResumeLayout(false);
            this.groupCepstre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffCepstre)).EndInit();
            this.groupExtractWav.ResumeLayout(false);
            this.groupExtractWav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnHelpFeatures;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private ZedGraph.ZedGraphControl graphControl;
        private SpectrogramPlot spectrogramPanel;
        private SpectrogramPlot featuresPanel;
        private GroupPlot bankPlot;
        private System.Windows.Forms.ToolStripMenuItem btnRecorderForm;
        private System.Windows.Forms.GroupBox groupGraph;
        private System.Windows.Forms.GroupBox groupBank;
        private System.Windows.Forms.ComboBox comboGraph;
        private System.Windows.Forms.GroupBox groupDiscreteTransform;
        private System.Windows.Forms.NumericUpDown numEndValue;
        private System.Windows.Forms.Label lblEndSegment;
        private System.Windows.Forms.NumericUpDown numWindowSize;
        private System.Windows.Forms.Label lblWindowSize;
        private System.Windows.Forms.NumericUpDown numWindowShift;
        private System.Windows.Forms.Label lblWindowShift;
        private System.Windows.Forms.CheckBox checkFillNull;
        private System.Windows.Forms.CheckBox checkShort;
        private System.Windows.Forms.NumericUpDown numA;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.CheckBox checkPreemphasis;
        private System.Windows.Forms.Button btnFourier;
        private System.Windows.Forms.GroupBox groupBands;
        private System.Windows.Forms.NumericUpDown numUpFrequency;
        private System.Windows.Forms.Label lblUpFrequency;
        private System.Windows.Forms.NumericUpDown numLowFrequency;
        private System.Windows.Forms.Label lblLowFrequency;
        private System.Windows.Forms.NumericUpDown numFilters;
        private System.Windows.Forms.Label lblNumFilter;
        private System.Windows.Forms.ComboBox comboBands;
        private System.Windows.Forms.Button btnBands;
        private System.Windows.Forms.CheckBox checkBanksOld;
        private SpectrogramPlot bandsPanel;
        private System.Windows.Forms.GroupBox groupCepstre;
        private System.Windows.Forms.CheckBox checkCepstreOld;
        private System.Windows.Forms.NumericUpDown numCoeffCepstre;
        private System.Windows.Forms.Label lblCoeffCepstre;
        private System.Windows.Forms.Button btnCepstre;
        private System.Windows.Forms.CheckBox checkMean;
        private System.Windows.Forms.CheckBox checkDeltaDelta;
        private System.Windows.Forms.CheckBox checkDelta;
        private System.Windows.Forms.CheckBox checkVariance;
        private System.Windows.Forms.CheckBox checkEnergy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numStartValue;
        private System.Windows.Forms.Label lblStartValue;
        private System.Windows.Forms.Button btnPlaySegment;
        private System.Windows.Forms.GroupBox groupExtractWav;
        private System.Windows.Forms.Button btnPathSaveWave;
        private System.Windows.Forms.TextBox txbPathSaveWave;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnPathVideo;
        private System.Windows.Forms.TextBox txbPathVideo;
    }
}


namespace MWSoundED
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
            this.components = new System.ComponentModel.Container();
            this.graphControl = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAudioAnalyse = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLearning = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentTimeWave = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupEvents = new System.Windows.Forms.GroupBox();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.btnPlayEvent = new System.Windows.Forms.Button();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.rtxbLog = new System.Windows.Forms.RichTextBox();
            this.groupAlgorithm = new System.Windows.Forms.GroupBox();
            this.tabAlgorithm = new System.Windows.Forms.TabControl();
            this.tabGmm = new System.Windows.Forms.TabPage();
            this.btnSearchEvents = new System.Windows.Forms.Button();
            this.numFrameSize = new System.Windows.Forms.NumericUpDown();
            this.lblFrameSize = new System.Windows.Forms.Label();
            this.lblModelsFolder = new System.Windows.Forms.Label();
            this.txbModelsFolder = new System.Windows.Forms.TextBox();
            this.btnModelsFolder = new System.Windows.Forms.Button();
            this.btnLoadModels = new System.Windows.Forms.Button();
            this.tabRnn = new System.Windows.Forms.TabPage();
            this.numFrameSizeRnn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchEventsRnn = new System.Windows.Forms.Button();
            this.numFrameAmountRnn = new System.Windows.Forms.NumericUpDown();
            this.lblFrameAmountRnn = new System.Windows.Forms.Label();
            this.lblLoadRnn = new System.Windows.Forms.Label();
            this.txbLoadRnn = new System.Windows.Forms.TextBox();
            this.btnLoadRnnPath = new System.Windows.Forms.Button();
            this.btnLoadRnn = new System.Windows.Forms.Button();
            this.tabCnn = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.spectrogramPanel = new MWSoundED.SpectrogramPlot();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupEvents.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.groupAlgorithm.SuspendLayout();
            this.tabAlgorithm.SuspendLayout();
            this.tabGmm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSize)).BeginInit();
            this.tabRnn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeRnn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameAmountRnn)).BeginInit();
            this.tabCnn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // graphControl
            // 
            this.graphControl.BackColor = System.Drawing.SystemColors.Control;
            this.graphControl.Location = new System.Drawing.Point(13, 32);
            this.graphControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphControl.Name = "graphControl";
            this.graphControl.ScrollGrace = 0D;
            this.graphControl.ScrollMaxX = 0D;
            this.graphControl.ScrollMaxY = 0D;
            this.graphControl.ScrollMaxY2 = 0D;
            this.graphControl.ScrollMinX = 0D;
            this.graphControl.ScrollMinY = 0D;
            this.graphControl.ScrollMinY2 = 0D;
            this.graphControl.Size = new System.Drawing.Size(1095, 177);
            this.graphControl.TabIndex = 6;
            this.graphControl.UseExtendedPrintDialog = true;
            this.graphControl.ZoomButtons = System.Windows.Forms.MouseButtons.Right;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.btnAudioAnalyse,
            this.btnLearning,
            this.btnHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnParameters,
            this.btnExit});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(165, 26);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnParameters
            // 
            this.btnParameters.Name = "btnParameters";
            this.btnParameters.Size = new System.Drawing.Size(165, 26);
            this.btnParameters.Text = "Параметры";
            this.btnParameters.Click += new System.EventHandler(this.btnParameters_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(165, 26);
            this.btnExit.Text = "Выход";
            // 
            // btnAudioAnalyse
            // 
            this.btnAudioAnalyse.Name = "btnAudioAnalyse";
            this.btnAudioAnalyse.Size = new System.Drawing.Size(113, 24);
            this.btnAudioAnalyse.Text = "Аудиоанализ";
            this.btnAudioAnalyse.Click += new System.EventHandler(this.btnAudioAnalyse_Click);
            // 
            // btnLearning
            // 
            this.btnLearning.Name = "btnLearning";
            this.btnLearning.Size = new System.Drawing.Size(174, 24);
            this.btnLearning.Text = "Признаки и обучение";
            this.btnLearning.Click += new System.EventHandler(this.btnLearning_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(79, 24);
            this.btnHelp.Text = "Справка";
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(13, 401);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 30);
            this.btnPlay.TabIndex = 8;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(94, 401);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentTimeWave});
            this.statusStrip1.Location = new System.Drawing.Point(0, 763);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1120, 25);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentTimeWave
            // 
            this.lblCurrentTimeWave.Name = "lblCurrentTimeWave";
            this.lblCurrentTimeWave.Size = new System.Drawing.Size(122, 20);
            this.lblCurrentTimeWave.Text = "00:00:00.0000000";
            // 
            // groupEvents
            // 
            this.groupEvents.Controls.Add(this.listEvents);
            this.groupEvents.Controls.Add(this.btnPlayEvent);
            this.groupEvents.Location = new System.Drawing.Point(409, 437);
            this.groupEvents.Name = "groupEvents";
            this.groupEvents.Size = new System.Drawing.Size(699, 161);
            this.groupEvents.TabIndex = 29;
            this.groupEvents.TabStop = false;
            this.groupEvents.Text = "Журнал событий:";
            // 
            // listEvents
            // 
            this.listEvents.FormattingEnabled = true;
            this.listEvents.ItemHeight = 16;
            this.listEvents.Location = new System.Drawing.Point(6, 21);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(687, 100);
            this.listEvents.TabIndex = 32;
            this.listEvents.SelectedIndexChanged += new System.EventHandler(this.listEvents_SelectedIndexChanged);
            // 
            // btnPlayEvent
            // 
            this.btnPlayEvent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPlayEvent.Location = new System.Drawing.Point(3, 129);
            this.btnPlayEvent.Name = "btnPlayEvent";
            this.btnPlayEvent.Size = new System.Drawing.Size(693, 29);
            this.btnPlayEvent.TabIndex = 31;
            this.btnPlayEvent.Text = "Прослушать выбранное событие";
            this.btnPlayEvent.UseVisualStyleBackColor = true;
            this.btnPlayEvent.Click += new System.EventHandler(this.btnPlayEvent_Click);
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.rtxbLog);
            this.groupLog.Location = new System.Drawing.Point(412, 604);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(696, 152);
            this.groupLog.TabIndex = 30;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "Лог:";
            // 
            // rtxbLog
            // 
            this.rtxbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxbLog.Location = new System.Drawing.Point(3, 18);
            this.rtxbLog.Name = "rtxbLog";
            this.rtxbLog.Size = new System.Drawing.Size(690, 131);
            this.rtxbLog.TabIndex = 1;
            this.rtxbLog.Text = "";
            // 
            // groupAlgorithm
            // 
            this.groupAlgorithm.Controls.Add(this.tabAlgorithm);
            this.groupAlgorithm.Location = new System.Drawing.Point(13, 437);
            this.groupAlgorithm.Name = "groupAlgorithm";
            this.groupAlgorithm.Size = new System.Drawing.Size(390, 319);
            this.groupAlgorithm.TabIndex = 31;
            this.groupAlgorithm.TabStop = false;
            this.groupAlgorithm.Text = "Методы для тестирования:";
            // 
            // tabAlgorithm
            // 
            this.tabAlgorithm.Controls.Add(this.tabGmm);
            this.tabAlgorithm.Controls.Add(this.tabRnn);
            this.tabAlgorithm.Controls.Add(this.tabCnn);
            this.tabAlgorithm.Location = new System.Drawing.Point(6, 21);
            this.tabAlgorithm.Name = "tabAlgorithm";
            this.tabAlgorithm.SelectedIndex = 0;
            this.tabAlgorithm.Size = new System.Drawing.Size(378, 292);
            this.tabAlgorithm.TabIndex = 29;
            // 
            // tabGmm
            // 
            this.tabGmm.Controls.Add(this.btnSearchEvents);
            this.tabGmm.Controls.Add(this.numFrameSize);
            this.tabGmm.Controls.Add(this.lblFrameSize);
            this.tabGmm.Controls.Add(this.lblModelsFolder);
            this.tabGmm.Controls.Add(this.txbModelsFolder);
            this.tabGmm.Controls.Add(this.btnModelsFolder);
            this.tabGmm.Controls.Add(this.btnLoadModels);
            this.tabGmm.Location = new System.Drawing.Point(4, 25);
            this.tabGmm.Name = "tabGmm";
            this.tabGmm.Padding = new System.Windows.Forms.Padding(3);
            this.tabGmm.Size = new System.Drawing.Size(370, 263);
            this.tabGmm.TabIndex = 0;
            this.tabGmm.Text = "Гауссовы смеси";
            this.tabGmm.UseVisualStyleBackColor = true;
            // 
            // btnSearchEvents
            // 
            this.btnSearchEvents.Location = new System.Drawing.Point(6, 121);
            this.btnSearchEvents.Name = "btnSearchEvents";
            this.btnSearchEvents.Size = new System.Drawing.Size(358, 36);
            this.btnSearchEvents.TabIndex = 31;
            this.btnSearchEvents.Text = "Поиск событий";
            this.btnSearchEvents.UseVisualStyleBackColor = true;
            this.btnSearchEvents.Click += new System.EventHandler(this.btnSearchEvents_Click);
            // 
            // numFrameSize
            // 
            this.numFrameSize.Location = new System.Drawing.Point(242, 93);
            this.numFrameSize.Name = "numFrameSize";
            this.numFrameSize.Size = new System.Drawing.Size(120, 22);
            this.numFrameSize.TabIndex = 30;
            this.numFrameSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblFrameSize
            // 
            this.lblFrameSize.AutoSize = true;
            this.lblFrameSize.Location = new System.Drawing.Point(53, 95);
            this.lblFrameSize.Name = "lblFrameSize";
            this.lblFrameSize.Size = new System.Drawing.Size(183, 17);
            this.lblFrameSize.TabIndex = 29;
            this.lblFrameSize.Text = "Размер окна для анализа:";
            // 
            // lblModelsFolder
            // 
            this.lblModelsFolder.AutoSize = true;
            this.lblModelsFolder.Location = new System.Drawing.Point(6, 3);
            this.lblModelsFolder.Name = "lblModelsFolder";
            this.lblModelsFolder.Size = new System.Drawing.Size(134, 17);
            this.lblModelsFolder.TabIndex = 27;
            this.lblModelsFolder.Text = "Папка с моделями:";
            // 
            // txbModelsFolder
            // 
            this.txbModelsFolder.Location = new System.Drawing.Point(6, 23);
            this.txbModelsFolder.Name = "txbModelsFolder";
            this.txbModelsFolder.Size = new System.Drawing.Size(289, 22);
            this.txbModelsFolder.TabIndex = 26;
            // 
            // btnModelsFolder
            // 
            this.btnModelsFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnModelsFolder.Location = new System.Drawing.Point(301, 23);
            this.btnModelsFolder.Name = "btnModelsFolder";
            this.btnModelsFolder.Size = new System.Drawing.Size(63, 22);
            this.btnModelsFolder.TabIndex = 25;
            this.btnModelsFolder.Text = "...";
            this.btnModelsFolder.UseVisualStyleBackColor = true;
            this.btnModelsFolder.Click += new System.EventHandler(this.btnModelsFolder_Click);
            // 
            // btnLoadModels
            // 
            this.btnLoadModels.Location = new System.Drawing.Point(5, 51);
            this.btnLoadModels.Name = "btnLoadModels";
            this.btnLoadModels.Size = new System.Drawing.Size(359, 28);
            this.btnLoadModels.TabIndex = 24;
            this.btnLoadModels.Text = "Загрузить модели";
            this.btnLoadModels.UseVisualStyleBackColor = true;
            this.btnLoadModels.Click += new System.EventHandler(this.btnLoadModels_Click);
            // 
            // tabRnn
            // 
            this.tabRnn.Controls.Add(this.numFrameSizeRnn);
            this.tabRnn.Controls.Add(this.label3);
            this.tabRnn.Controls.Add(this.btnSearchEventsRnn);
            this.tabRnn.Controls.Add(this.numFrameAmountRnn);
            this.tabRnn.Controls.Add(this.lblFrameAmountRnn);
            this.tabRnn.Controls.Add(this.lblLoadRnn);
            this.tabRnn.Controls.Add(this.txbLoadRnn);
            this.tabRnn.Controls.Add(this.btnLoadRnnPath);
            this.tabRnn.Controls.Add(this.btnLoadRnn);
            this.tabRnn.Location = new System.Drawing.Point(4, 25);
            this.tabRnn.Name = "tabRnn";
            this.tabRnn.Padding = new System.Windows.Forms.Padding(3);
            this.tabRnn.Size = new System.Drawing.Size(370, 263);
            this.tabRnn.TabIndex = 1;
            this.tabRnn.Text = "RNN";
            this.tabRnn.UseVisualStyleBackColor = true;
            // 
            // numFrameSizeRnn
            // 
            this.numFrameSizeRnn.Location = new System.Drawing.Point(242, 121);
            this.numFrameSizeRnn.Name = "numFrameSizeRnn";
            this.numFrameSizeRnn.Size = new System.Drawing.Size(120, 22);
            this.numFrameSizeRnn.TabIndex = 40;
            this.numFrameSizeRnn.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Размер окна:";
            // 
            // btnSearchEventsRnn
            // 
            this.btnSearchEventsRnn.Location = new System.Drawing.Point(6, 154);
            this.btnSearchEventsRnn.Name = "btnSearchEventsRnn";
            this.btnSearchEventsRnn.Size = new System.Drawing.Size(358, 36);
            this.btnSearchEventsRnn.TabIndex = 38;
            this.btnSearchEventsRnn.Text = "Поиск событий";
            this.btnSearchEventsRnn.UseVisualStyleBackColor = true;
            this.btnSearchEventsRnn.Click += new System.EventHandler(this.btnSearchEventsRnn_Click);
            // 
            // numFrameAmountRnn
            // 
            this.numFrameAmountRnn.Location = new System.Drawing.Point(242, 93);
            this.numFrameAmountRnn.Name = "numFrameAmountRnn";
            this.numFrameAmountRnn.Size = new System.Drawing.Size(120, 22);
            this.numFrameAmountRnn.TabIndex = 37;
            this.numFrameAmountRnn.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // lblFrameAmountRnn
            // 
            this.lblFrameAmountRnn.AutoSize = true;
            this.lblFrameAmountRnn.Location = new System.Drawing.Point(57, 95);
            this.lblFrameAmountRnn.Name = "lblFrameAmountRnn";
            this.lblFrameAmountRnn.Size = new System.Drawing.Size(179, 17);
            this.lblFrameAmountRnn.TabIndex = 36;
            this.lblFrameAmountRnn.Text = "Кол-во окон для анализа:";
            // 
            // lblLoadRnn
            // 
            this.lblLoadRnn.AutoSize = true;
            this.lblLoadRnn.Location = new System.Drawing.Point(6, 3);
            this.lblLoadRnn.Name = "lblLoadRnn";
            this.lblLoadRnn.Size = new System.Drawing.Size(240, 17);
            this.lblLoadRnn.TabIndex = 35;
            this.lblLoadRnn.Text = "Загрузить модель нейронной сети:";
            // 
            // txbLoadRnn
            // 
            this.txbLoadRnn.Location = new System.Drawing.Point(6, 23);
            this.txbLoadRnn.Name = "txbLoadRnn";
            this.txbLoadRnn.Size = new System.Drawing.Size(289, 22);
            this.txbLoadRnn.TabIndex = 34;
            // 
            // btnLoadRnnPath
            // 
            this.btnLoadRnnPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadRnnPath.Location = new System.Drawing.Point(301, 23);
            this.btnLoadRnnPath.Name = "btnLoadRnnPath";
            this.btnLoadRnnPath.Size = new System.Drawing.Size(63, 22);
            this.btnLoadRnnPath.TabIndex = 33;
            this.btnLoadRnnPath.Text = "...";
            this.btnLoadRnnPath.UseVisualStyleBackColor = true;
            this.btnLoadRnnPath.Click += new System.EventHandler(this.btnLoadRnnPath_Click);
            // 
            // btnLoadRnn
            // 
            this.btnLoadRnn.Location = new System.Drawing.Point(5, 51);
            this.btnLoadRnn.Name = "btnLoadRnn";
            this.btnLoadRnn.Size = new System.Drawing.Size(359, 28);
            this.btnLoadRnn.TabIndex = 32;
            this.btnLoadRnn.Text = "Загрузить";
            this.btnLoadRnn.UseVisualStyleBackColor = true;
            this.btnLoadRnn.Click += new System.EventHandler(this.btnLoadRnn_Click);
            // 
            // tabCnn
            // 
            this.tabCnn.Controls.Add(this.numericUpDown2);
            this.tabCnn.Controls.Add(this.label4);
            this.tabCnn.Controls.Add(this.button1);
            this.tabCnn.Controls.Add(this.numericUpDown1);
            this.tabCnn.Controls.Add(this.label1);
            this.tabCnn.Controls.Add(this.label2);
            this.tabCnn.Controls.Add(this.textBox1);
            this.tabCnn.Controls.Add(this.button2);
            this.tabCnn.Controls.Add(this.button3);
            this.tabCnn.Location = new System.Drawing.Point(4, 25);
            this.tabCnn.Name = "tabCnn";
            this.tabCnn.Padding = new System.Windows.Forms.Padding(3);
            this.tabCnn.Size = new System.Drawing.Size(370, 263);
            this.tabCnn.TabIndex = 2;
            this.tabCnn.Text = "CNN";
            this.tabCnn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(358, 36);
            this.button1.TabIndex = 45;
            this.button1.Text = "Поиск событий";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(242, 93);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 44;
            this.numericUpDown1.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Кол-во окон для анализа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Загрузить модель нейронной сети:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 22);
            this.textBox1.TabIndex = 41;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(301, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 22);
            this.button2.TabIndex = 40;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(359, 28);
            this.button3.TabIndex = 39;
            this.button3.Text = "Загрузить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // spectrogramPanel
            // 
            this.spectrogramPanel.AutoScroll = true;
            this.spectrogramPanel.BackColor = System.Drawing.Color.Black;
            this.spectrogramPanel.ColorMapName = "magma";
            this.spectrogramPanel.Location = new System.Drawing.Point(13, 206);
            this.spectrogramPanel.Markline = null;
            this.spectrogramPanel.MarklineThickness = 0;
            this.spectrogramPanel.Name = "spectrogramPanel";
            this.spectrogramPanel.Size = new System.Drawing.Size(1095, 189);
            this.spectrogramPanel.Spectrogram = null;
            this.spectrogramPanel.TabIndex = 32;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(242, 121);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown2.TabIndex = 47;
            this.numericUpDown2.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Размер окна:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 788);
            this.Controls.Add(this.spectrogramPanel);
            this.Controls.Add(this.groupAlgorithm);
            this.Controls.Add(this.groupLog);
            this.Controls.Add(this.groupEvents);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.graphControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MD Sound Event Detection - Тестирование";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupEvents.ResumeLayout(false);
            this.groupLog.ResumeLayout(false);
            this.groupAlgorithm.ResumeLayout(false);
            this.tabAlgorithm.ResumeLayout(false);
            this.tabGmm.ResumeLayout(false);
            this.tabGmm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSize)).EndInit();
            this.tabRnn.ResumeLayout(false);
            this.tabRnn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeRnn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameAmountRnn)).EndInit();
            this.tabCnn.ResumeLayout(false);
            this.tabCnn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl graphControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTimeWave;
        private System.Windows.Forms.ToolStripMenuItem btnParameters;
        private System.Windows.Forms.ToolStripMenuItem btnAudioAnalyse;
        private System.Windows.Forms.ToolStripMenuItem btnLearning;
        private System.Windows.Forms.GroupBox groupEvents;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.RichTextBox rtxbLog;
        private System.Windows.Forms.GroupBox groupAlgorithm;
        private System.Windows.Forms.TabControl tabAlgorithm;
        private System.Windows.Forms.TabPage tabGmm;
        private System.Windows.Forms.Label lblModelsFolder;
        private System.Windows.Forms.TextBox txbModelsFolder;
        private System.Windows.Forms.Button btnModelsFolder;
        private System.Windows.Forms.Button btnLoadModels;
        private System.Windows.Forms.TabPage tabRnn;
        private System.Windows.Forms.TabPage tabCnn;
        private System.Windows.Forms.NumericUpDown numFrameSize;
        private System.Windows.Forms.Label lblFrameSize;
        private System.Windows.Forms.Button btnPlayEvent;
        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.Button btnSearchEvents;
        private System.Windows.Forms.Button btnSearchEventsRnn;
        private System.Windows.Forms.NumericUpDown numFrameAmountRnn;
        private System.Windows.Forms.Label lblFrameAmountRnn;
        private System.Windows.Forms.Label lblLoadRnn;
        private System.Windows.Forms.TextBox txbLoadRnn;
        private System.Windows.Forms.Button btnLoadRnnPath;
        private System.Windows.Forms.Button btnLoadRnn;
        private SpectrogramPlot spectrogramPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numFrameSizeRnn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
    }
}
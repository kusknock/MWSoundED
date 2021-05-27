namespace MWSoundED
{
    partial class LearningForm
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
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.rtxbLog = new System.Windows.Forms.RichTextBox();
            this.groupLearning = new System.Windows.Forms.GroupBox();
            this.lblTypeFileParse = new System.Windows.Forms.Label();
            this.lblCsvFile = new System.Windows.Forms.Label();
            this.txbCsvFile = new System.Windows.Forms.TextBox();
            this.btnCsvFile = new System.Windows.Forms.Button();
            this.lblLearnFolder = new System.Windows.Forms.Label();
            this.txbLearnFolder = new System.Windows.Forms.TextBox();
            this.btnLearnFolder = new System.Windows.Forms.Button();
            this.progressBarParse = new System.Windows.Forms.ProgressBar();
            this.comboTypeFile = new System.Windows.Forms.ComboBox();
            this.btnGetLearningFiles = new System.Windows.Forms.Button();
            this.groupConcatFeatures = new System.Windows.Forms.GroupBox();
            this.btnSaveFeatures = new System.Windows.Forms.Button();
            this.lblSaveLearningSample = new System.Windows.Forms.Label();
            this.txbSaveLearningSample = new System.Windows.Forms.TextBox();
            this.btnSaveLearningSample = new System.Windows.Forms.Button();
            this.btnFeatureParameters = new System.Windows.Forms.Button();
            this.lblTypeFeatures = new System.Windows.Forms.Label();
            this.rbtnCepstre = new System.Windows.Forms.RadioButton();
            this.rbtnBands = new System.Windows.Forms.RadioButton();
            this.lblClassSample = new System.Windows.Forms.Label();
            this.btnConcatFeatures = new System.Windows.Forms.Button();
            this.progressBarConcat = new System.Windows.Forms.ProgressBar();
            this.comboClasses = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txbClass = new System.Windows.Forms.TextBox();
            this.txbFeatureFilePath = new System.Windows.Forms.TextBox();
            this.btnFeatureFilePath = new System.Windows.Forms.Button();
            this.checkLoadDataFromFile = new System.Windows.Forms.CheckBox();
            this.lblSaveModelPath = new System.Windows.Forms.Label();
            this.numK = new System.Windows.Forms.NumericUpDown();
            this.txbSaveModelPath = new System.Windows.Forms.TextBox();
            this.lblK = new System.Windows.Forms.Label();
            this.btnSaveModelPath = new System.Windows.Forms.Button();
            this.checkKMeans = new System.Windows.Forms.CheckBox();
            this.btnStartLearnGmm = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGmm = new System.Windows.Forms.TabPage();
            this.lblNoiseModel = new System.Windows.Forms.Label();
            this.txbNoiseModel = new System.Windows.Forms.TextBox();
            this.btnNoiseModel = new System.Windows.Forms.Button();
            this.checkNoiseModel = new System.Windows.Forms.CheckBox();
            this.tabRnn = new System.Windows.Forms.TabPage();
            this.lblRnnFrameSize = new System.Windows.Forms.Label();
            this.numFrameSizeRnn = new System.Windows.Forms.NumericUpDown();
            this.lblSaveModelRnn = new System.Windows.Forms.Label();
            this.txbSaveModelRnn = new System.Windows.Forms.TextBox();
            this.btnFolderSaveModelRnn = new System.Windows.Forms.Button();
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.numBatchSize = new System.Windows.Forms.NumericUpDown();
            this.lblLearningRate = new System.Windows.Forms.Label();
            this.numLearningRate = new System.Windows.Forms.NumericUpDown();
            this.lblIterations = new System.Windows.Forms.Label();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.lblDropout = new System.Windows.Forms.Label();
            this.numDropout = new System.Windows.Forms.NumericUpDown();
            this.lblLstmCellSize = new System.Windows.Forms.Label();
            this.numLstmCellSize = new System.Windows.Forms.NumericUpDown();
            this.lblLstmCells = new System.Windows.Forms.Label();
            this.numLstmCells = new System.Windows.Forms.NumericUpDown();
            this.lblFeaturesFolder = new System.Windows.Forms.Label();
            this.txbFeaturesFolder = new System.Windows.Forms.TextBox();
            this.btnFeaturesFolder = new System.Windows.Forms.Button();
            this.btnLearnRnn = new System.Windows.Forms.Button();
            this.lblInputFrames = new System.Windows.Forms.Label();
            this.numInFrames = new System.Windows.Forms.NumericUpDown();
            this.tabCnn = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txbCnnFeature = new System.Windows.Forms.TextBox();
            this.btnCnnFeaturePath = new System.Windows.Forms.Button();
            this.btnCnnFit = new System.Windows.Forms.Button();
            this.groupLearnAlgorithms = new System.Windows.Forms.GroupBox();
            this.groupLog.SuspendLayout();
            this.groupLearning.SuspendLayout();
            this.groupConcatFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGmm.SuspendLayout();
            this.tabRnn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeRnn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDropout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLstmCellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLstmCells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInFrames)).BeginInit();
            this.tabCnn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupLearnAlgorithms.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.rtxbLog);
            this.groupLog.Location = new System.Drawing.Point(731, 12);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(402, 612);
            this.groupLog.TabIndex = 4;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "Журнал событий:";
            // 
            // rtxbLog
            // 
            this.rtxbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxbLog.Location = new System.Drawing.Point(3, 18);
            this.rtxbLog.Name = "rtxbLog";
            this.rtxbLog.Size = new System.Drawing.Size(396, 591);
            this.rtxbLog.TabIndex = 1;
            this.rtxbLog.Text = "";
            // 
            // groupLearning
            // 
            this.groupLearning.Controls.Add(this.lblTypeFileParse);
            this.groupLearning.Controls.Add(this.lblCsvFile);
            this.groupLearning.Controls.Add(this.txbCsvFile);
            this.groupLearning.Controls.Add(this.btnCsvFile);
            this.groupLearning.Controls.Add(this.lblLearnFolder);
            this.groupLearning.Controls.Add(this.txbLearnFolder);
            this.groupLearning.Controls.Add(this.btnLearnFolder);
            this.groupLearning.Controls.Add(this.progressBarParse);
            this.groupLearning.Controls.Add(this.comboTypeFile);
            this.groupLearning.Controls.Add(this.btnGetLearningFiles);
            this.groupLearning.Location = new System.Drawing.Point(12, 12);
            this.groupLearning.Name = "groupLearning";
            this.groupLearning.Size = new System.Drawing.Size(320, 234);
            this.groupLearning.TabIndex = 5;
            this.groupLearning.TabStop = false;
            this.groupLearning.Text = "Получение обучающей выборки:";
            // 
            // lblTypeFileParse
            // 
            this.lblTypeFileParse.AutoSize = true;
            this.lblTypeFileParse.Location = new System.Drawing.Point(6, 21);
            this.lblTypeFileParse.Name = "lblTypeFileParse";
            this.lblTypeFileParse.Size = new System.Drawing.Size(176, 17);
            this.lblTypeFileParse.TabIndex = 20;
            this.lblTypeFileParse.Text = "Тип файла для парсинга:";
            // 
            // lblCsvFile
            // 
            this.lblCsvFile.AutoSize = true;
            this.lblCsvFile.Enabled = false;
            this.lblCsvFile.Location = new System.Drawing.Point(6, 146);
            this.lblCsvFile.Name = "lblCsvFile";
            this.lblCsvFile.Size = new System.Drawing.Size(39, 17);
            this.lblCsvFile.TabIndex = 19;
            this.lblCsvFile.Text = "CSV:";
            // 
            // txbCsvFile
            // 
            this.txbCsvFile.Enabled = false;
            this.txbCsvFile.Location = new System.Drawing.Point(6, 166);
            this.txbCsvFile.Name = "txbCsvFile";
            this.txbCsvFile.Size = new System.Drawing.Size(239, 22);
            this.txbCsvFile.TabIndex = 18;
            // 
            // btnCsvFile
            // 
            this.btnCsvFile.Enabled = false;
            this.btnCsvFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCsvFile.Location = new System.Drawing.Point(250, 166);
            this.btnCsvFile.Name = "btnCsvFile";
            this.btnCsvFile.Size = new System.Drawing.Size(63, 22);
            this.btnCsvFile.TabIndex = 17;
            this.btnCsvFile.Text = "...";
            this.btnCsvFile.UseVisualStyleBackColor = true;
            this.btnCsvFile.Click += new System.EventHandler(this.btnCsvFile_Click);
            // 
            // lblLearnFolder
            // 
            this.lblLearnFolder.AutoSize = true;
            this.lblLearnFolder.Location = new System.Drawing.Point(6, 99);
            this.lblLearnFolder.Name = "lblLearnFolder";
            this.lblLearnFolder.Size = new System.Drawing.Size(212, 17);
            this.lblLearnFolder.TabIndex = 16;
            this.lblLearnFolder.Text = "Папка с обучающей выборкой:";
            // 
            // txbLearnFolder
            // 
            this.txbLearnFolder.Location = new System.Drawing.Point(6, 119);
            this.txbLearnFolder.Name = "txbLearnFolder";
            this.txbLearnFolder.Size = new System.Drawing.Size(239, 22);
            this.txbLearnFolder.TabIndex = 15;
            // 
            // btnLearnFolder
            // 
            this.btnLearnFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLearnFolder.Location = new System.Drawing.Point(251, 119);
            this.btnLearnFolder.Name = "btnLearnFolder";
            this.btnLearnFolder.Size = new System.Drawing.Size(63, 22);
            this.btnLearnFolder.TabIndex = 14;
            this.btnLearnFolder.Text = "...";
            this.btnLearnFolder.UseVisualStyleBackColor = true;
            this.btnLearnFolder.Click += new System.EventHandler(this.btnLearnFolder_Click);
            // 
            // progressBarParse
            // 
            this.progressBarParse.Location = new System.Drawing.Point(6, 71);
            this.progressBarParse.Name = "progressBarParse";
            this.progressBarParse.Size = new System.Drawing.Size(307, 23);
            this.progressBarParse.TabIndex = 13;
            // 
            // comboTypeFile
            // 
            this.comboTypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypeFile.FormattingEnabled = true;
            this.comboTypeFile.Items.AddRange(new object[] {
            "YAML",
            "CSV"});
            this.comboTypeFile.Location = new System.Drawing.Point(6, 41);
            this.comboTypeFile.Name = "comboTypeFile";
            this.comboTypeFile.Size = new System.Drawing.Size(307, 24);
            this.comboTypeFile.TabIndex = 12;
            this.comboTypeFile.SelectedIndexChanged += new System.EventHandler(this.comboTypeFile_SelectedIndexChanged);
            // 
            // btnGetLearningFiles
            // 
            this.btnGetLearningFiles.Location = new System.Drawing.Point(6, 194);
            this.btnGetLearningFiles.Name = "btnGetLearningFiles";
            this.btnGetLearningFiles.Size = new System.Drawing.Size(307, 33);
            this.btnGetLearningFiles.TabIndex = 11;
            this.btnGetLearningFiles.Text = "Старт";
            this.btnGetLearningFiles.UseVisualStyleBackColor = true;
            this.btnGetLearningFiles.Click += new System.EventHandler(this.btnGetLearningFiles_Click);
            // 
            // groupConcatFeatures
            // 
            this.groupConcatFeatures.Controls.Add(this.btnSaveFeatures);
            this.groupConcatFeatures.Controls.Add(this.lblSaveLearningSample);
            this.groupConcatFeatures.Controls.Add(this.txbSaveLearningSample);
            this.groupConcatFeatures.Controls.Add(this.btnSaveLearningSample);
            this.groupConcatFeatures.Controls.Add(this.btnFeatureParameters);
            this.groupConcatFeatures.Controls.Add(this.lblTypeFeatures);
            this.groupConcatFeatures.Controls.Add(this.rbtnCepstre);
            this.groupConcatFeatures.Controls.Add(this.rbtnBands);
            this.groupConcatFeatures.Controls.Add(this.lblClassSample);
            this.groupConcatFeatures.Controls.Add(this.btnConcatFeatures);
            this.groupConcatFeatures.Controls.Add(this.progressBarConcat);
            this.groupConcatFeatures.Controls.Add(this.comboClasses);
            this.groupConcatFeatures.Location = new System.Drawing.Point(12, 252);
            this.groupConcatFeatures.Name = "groupConcatFeatures";
            this.groupConcatFeatures.Size = new System.Drawing.Size(320, 284);
            this.groupConcatFeatures.TabIndex = 14;
            this.groupConcatFeatures.TabStop = false;
            this.groupConcatFeatures.Text = "Конкатенация признаков для обучения:";
            // 
            // btnSaveFeatures
            // 
            this.btnSaveFeatures.Location = new System.Drawing.Point(6, 240);
            this.btnSaveFeatures.Name = "btnSaveFeatures";
            this.btnSaveFeatures.Size = new System.Drawing.Size(308, 31);
            this.btnSaveFeatures.TabIndex = 29;
            this.btnSaveFeatures.Text = "Сохранить данные признаков";
            this.btnSaveFeatures.UseVisualStyleBackColor = true;
            this.btnSaveFeatures.Click += new System.EventHandler(this.btnSaveFeatures_Click);
            // 
            // lblSaveLearningSample
            // 
            this.lblSaveLearningSample.AutoSize = true;
            this.lblSaveLearningSample.Location = new System.Drawing.Point(6, 192);
            this.lblSaveLearningSample.Name = "lblSaveLearningSample";
            this.lblSaveLearningSample.Size = new System.Drawing.Size(222, 17);
            this.lblSaveLearningSample.TabIndex = 28;
            this.lblSaveLearningSample.Text = "Папка для сохранения выборки:";
            // 
            // txbSaveLearningSample
            // 
            this.txbSaveLearningSample.Location = new System.Drawing.Point(6, 212);
            this.txbSaveLearningSample.Name = "txbSaveLearningSample";
            this.txbSaveLearningSample.Size = new System.Drawing.Size(239, 22);
            this.txbSaveLearningSample.TabIndex = 27;
            // 
            // btnSaveLearningSample
            // 
            this.btnSaveLearningSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveLearningSample.Location = new System.Drawing.Point(251, 212);
            this.btnSaveLearningSample.Name = "btnSaveLearningSample";
            this.btnSaveLearningSample.Size = new System.Drawing.Size(63, 22);
            this.btnSaveLearningSample.TabIndex = 26;
            this.btnSaveLearningSample.Text = "...";
            this.btnSaveLearningSample.UseVisualStyleBackColor = true;
            this.btnSaveLearningSample.Click += new System.EventHandler(this.btnSaveLearningSample_Click);
            // 
            // btnFeatureParameters
            // 
            this.btnFeatureParameters.Location = new System.Drawing.Point(159, 144);
            this.btnFeatureParameters.Name = "btnFeatureParameters";
            this.btnFeatureParameters.Size = new System.Drawing.Size(155, 44);
            this.btnFeatureParameters.TabIndex = 25;
            this.btnFeatureParameters.Text = "Параметры признаков";
            this.btnFeatureParameters.UseVisualStyleBackColor = true;
            this.btnFeatureParameters.Click += new System.EventHandler(this.btnFeatureParameters_Click);
            // 
            // lblTypeFeatures
            // 
            this.lblTypeFeatures.AutoSize = true;
            this.lblTypeFeatures.Location = new System.Drawing.Point(6, 97);
            this.lblTypeFeatures.Name = "lblTypeFeatures";
            this.lblTypeFeatures.Size = new System.Drawing.Size(110, 17);
            this.lblTypeFeatures.TabIndex = 24;
            this.lblTypeFeatures.Text = "Тип признаков:";
            // 
            // rbtnCepstre
            // 
            this.rbtnCepstre.AutoSize = true;
            this.rbtnCepstre.Checked = true;
            this.rbtnCepstre.Location = new System.Drawing.Point(134, 117);
            this.rbtnCepstre.Name = "rbtnCepstre";
            this.rbtnCepstre.Size = new System.Drawing.Size(149, 21);
            this.rbtnCepstre.TabIndex = 23;
            this.rbtnCepstre.TabStop = true;
            this.rbtnCepstre.Text = "Cepstrum Features";
            this.rbtnCepstre.UseVisualStyleBackColor = true;
            // 
            // rbtnBands
            // 
            this.rbtnBands.AutoSize = true;
            this.rbtnBands.Location = new System.Drawing.Point(6, 117);
            this.rbtnBands.Name = "rbtnBands";
            this.rbtnBands.Size = new System.Drawing.Size(122, 21);
            this.rbtnBands.TabIndex = 22;
            this.rbtnBands.Text = "Band Features";
            this.rbtnBands.UseVisualStyleBackColor = true;
            // 
            // lblClassSample
            // 
            this.lblClassSample.AutoSize = true;
            this.lblClassSample.Location = new System.Drawing.Point(6, 21);
            this.lblClassSample.Name = "lblClassSample";
            this.lblClassSample.Size = new System.Drawing.Size(111, 17);
            this.lblClassSample.TabIndex = 21;
            this.lblClassSample.Text = "Класс событий:";
            // 
            // btnConcatFeatures
            // 
            this.btnConcatFeatures.Location = new System.Drawing.Point(6, 144);
            this.btnConcatFeatures.Name = "btnConcatFeatures";
            this.btnConcatFeatures.Size = new System.Drawing.Size(146, 44);
            this.btnConcatFeatures.TabIndex = 20;
            this.btnConcatFeatures.Text = "Старт";
            this.btnConcatFeatures.UseVisualStyleBackColor = true;
            this.btnConcatFeatures.Click += new System.EventHandler(this.btnConcatFeatures_Click);
            // 
            // progressBarConcat
            // 
            this.progressBarConcat.Location = new System.Drawing.Point(6, 71);
            this.progressBarConcat.Name = "progressBarConcat";
            this.progressBarConcat.Size = new System.Drawing.Size(308, 23);
            this.progressBarConcat.TabIndex = 14;
            // 
            // comboClasses
            // 
            this.comboClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClasses.FormattingEnabled = true;
            this.comboClasses.Location = new System.Drawing.Point(6, 41);
            this.comboClasses.Name = "comboClasses";
            this.comboClasses.Size = new System.Drawing.Size(308, 24);
            this.comboClasses.TabIndex = 12;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(29, 16);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(125, 17);
            this.lblClass.TabIndex = 32;
            this.lblClass.Text = "Название класса:";
            // 
            // txbClass
            // 
            this.txbClass.Location = new System.Drawing.Point(163, 13);
            this.txbClass.Name = "txbClass";
            this.txbClass.Size = new System.Drawing.Size(172, 22);
            this.txbClass.TabIndex = 30;
            // 
            // txbFeatureFilePath
            // 
            this.txbFeatureFilePath.Enabled = false;
            this.txbFeatureFilePath.Location = new System.Drawing.Point(29, 171);
            this.txbFeatureFilePath.Name = "txbFeatureFilePath";
            this.txbFeatureFilePath.Size = new System.Drawing.Size(239, 22);
            this.txbFeatureFilePath.TabIndex = 31;
            // 
            // btnFeatureFilePath
            // 
            this.btnFeatureFilePath.Enabled = false;
            this.btnFeatureFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFeatureFilePath.Location = new System.Drawing.Point(272, 171);
            this.btnFeatureFilePath.Name = "btnFeatureFilePath";
            this.btnFeatureFilePath.Size = new System.Drawing.Size(63, 22);
            this.btnFeatureFilePath.TabIndex = 30;
            this.btnFeatureFilePath.Text = "...";
            this.btnFeatureFilePath.UseVisualStyleBackColor = true;
            this.btnFeatureFilePath.Click += new System.EventHandler(this.btnFeatureFilePath_Click);
            // 
            // checkLoadDataFromFile
            // 
            this.checkLoadDataFromFile.AutoSize = true;
            this.checkLoadDataFromFile.Location = new System.Drawing.Point(29, 144);
            this.checkLoadDataFromFile.Name = "checkLoadDataFromFile";
            this.checkLoadDataFromFile.Size = new System.Drawing.Size(216, 21);
            this.checkLoadDataFromFile.TabIndex = 29;
            this.checkLoadDataFromFile.Text = "Загрузить данные из файла";
            this.checkLoadDataFromFile.UseVisualStyleBackColor = true;
            this.checkLoadDataFromFile.CheckedChanged += new System.EventHandler(this.checkLoadDataFromFile_CheckedChanged);
            // 
            // lblSaveModelPath
            // 
            this.lblSaveModelPath.AutoSize = true;
            this.lblSaveModelPath.Location = new System.Drawing.Point(29, 95);
            this.lblSaveModelPath.Name = "lblSaveModelPath";
            this.lblSaveModelPath.Size = new System.Drawing.Size(215, 17);
            this.lblSaveModelPath.TabIndex = 23;
            this.lblSaveModelPath.Text = "Папка для сохранения модели:";
            // 
            // numK
            // 
            this.numK.Location = new System.Drawing.Point(215, 41);
            this.numK.Name = "numK";
            this.numK.Size = new System.Drawing.Size(120, 22);
            this.numK.TabIndex = 28;
            this.numK.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // txbSaveModelPath
            // 
            this.txbSaveModelPath.Location = new System.Drawing.Point(29, 115);
            this.txbSaveModelPath.Name = "txbSaveModelPath";
            this.txbSaveModelPath.Size = new System.Drawing.Size(239, 22);
            this.txbSaveModelPath.TabIndex = 22;
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(58, 43);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(147, 17);
            this.lblK.TabIndex = 27;
            this.lblK.Text = "Кол-во компонентов:";
            // 
            // btnSaveModelPath
            // 
            this.btnSaveModelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveModelPath.Location = new System.Drawing.Point(272, 115);
            this.btnSaveModelPath.Name = "btnSaveModelPath";
            this.btnSaveModelPath.Size = new System.Drawing.Size(63, 22);
            this.btnSaveModelPath.TabIndex = 21;
            this.btnSaveModelPath.Text = "...";
            this.btnSaveModelPath.UseVisualStyleBackColor = true;
            this.btnSaveModelPath.Click += new System.EventHandler(this.btnSaveModelPath_Click);
            // 
            // checkKMeans
            // 
            this.checkKMeans.AutoSize = true;
            this.checkKMeans.Checked = true;
            this.checkKMeans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkKMeans.Location = new System.Drawing.Point(29, 71);
            this.checkKMeans.Name = "checkKMeans";
            this.checkKMeans.Size = new System.Drawing.Size(195, 21);
            this.checkKMeans.TabIndex = 26;
            this.checkKMeans.Text = "Использовать К-Средних";
            this.checkKMeans.UseVisualStyleBackColor = true;
            // 
            // btnStartLearnGmm
            // 
            this.btnStartLearnGmm.Location = new System.Drawing.Point(27, 275);
            this.btnStartLearnGmm.Name = "btnStartLearnGmm";
            this.btnStartLearnGmm.Size = new System.Drawing.Size(307, 34);
            this.btnStartLearnGmm.TabIndex = 20;
            this.btnStartLearnGmm.Text = "Старт";
            this.btnStartLearnGmm.UseVisualStyleBackColor = true;
            this.btnStartLearnGmm.Click += new System.EventHandler(this.btnStartLearnGmm_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGmm);
            this.tabControl1.Controls.Add(this.tabRnn);
            this.tabControl1.Controls.Add(this.tabCnn);
            this.tabControl1.Location = new System.Drawing.Point(6, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 490);
            this.tabControl1.TabIndex = 27;
            // 
            // tabGmm
            // 
            this.tabGmm.Controls.Add(this.lblNoiseModel);
            this.tabGmm.Controls.Add(this.txbNoiseModel);
            this.tabGmm.Controls.Add(this.btnNoiseModel);
            this.tabGmm.Controls.Add(this.checkNoiseModel);
            this.tabGmm.Controls.Add(this.lblClass);
            this.tabGmm.Controls.Add(this.checkKMeans);
            this.tabGmm.Controls.Add(this.txbClass);
            this.tabGmm.Controls.Add(this.btnStartLearnGmm);
            this.tabGmm.Controls.Add(this.txbFeatureFilePath);
            this.tabGmm.Controls.Add(this.btnSaveModelPath);
            this.tabGmm.Controls.Add(this.btnFeatureFilePath);
            this.tabGmm.Controls.Add(this.lblK);
            this.tabGmm.Controls.Add(this.checkLoadDataFromFile);
            this.tabGmm.Controls.Add(this.txbSaveModelPath);
            this.tabGmm.Controls.Add(this.lblSaveModelPath);
            this.tabGmm.Controls.Add(this.numK);
            this.tabGmm.Location = new System.Drawing.Point(4, 25);
            this.tabGmm.Name = "tabGmm";
            this.tabGmm.Padding = new System.Windows.Forms.Padding(3);
            this.tabGmm.Size = new System.Drawing.Size(367, 461);
            this.tabGmm.TabIndex = 0;
            this.tabGmm.Text = "Гауссовы смеси";
            this.tabGmm.UseVisualStyleBackColor = true;
            // 
            // lblNoiseModel
            // 
            this.lblNoiseModel.AutoSize = true;
            this.lblNoiseModel.Location = new System.Drawing.Point(29, 227);
            this.lblNoiseModel.Name = "lblNoiseModel";
            this.lblNoiseModel.Size = new System.Drawing.Size(193, 17);
            this.lblNoiseModel.TabIndex = 36;
            this.lblNoiseModel.Text = "Папка с признаками шумов:";
            // 
            // txbNoiseModel
            // 
            this.txbNoiseModel.Enabled = false;
            this.txbNoiseModel.Location = new System.Drawing.Point(28, 247);
            this.txbNoiseModel.Name = "txbNoiseModel";
            this.txbNoiseModel.Size = new System.Drawing.Size(239, 22);
            this.txbNoiseModel.TabIndex = 35;
            // 
            // btnNoiseModel
            // 
            this.btnNoiseModel.Enabled = false;
            this.btnNoiseModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNoiseModel.Location = new System.Drawing.Point(271, 247);
            this.btnNoiseModel.Name = "btnNoiseModel";
            this.btnNoiseModel.Size = new System.Drawing.Size(63, 22);
            this.btnNoiseModel.TabIndex = 34;
            this.btnNoiseModel.Text = "...";
            this.btnNoiseModel.UseVisualStyleBackColor = true;
            this.btnNoiseModel.Click += new System.EventHandler(this.btnNoiseModel_Click);
            // 
            // checkNoiseModel
            // 
            this.checkNoiseModel.AutoSize = true;
            this.checkNoiseModel.Location = new System.Drawing.Point(28, 203);
            this.checkNoiseModel.Name = "checkNoiseModel";
            this.checkNoiseModel.Size = new System.Drawing.Size(188, 21);
            this.checkNoiseModel.TabIndex = 33;
            this.checkNoiseModel.Text = "Обучение модели шума";
            this.checkNoiseModel.UseVisualStyleBackColor = true;
            this.checkNoiseModel.CheckedChanged += new System.EventHandler(this.checkNoiseModel_CheckedChanged);
            // 
            // tabRnn
            // 
            this.tabRnn.Controls.Add(this.lblRnnFrameSize);
            this.tabRnn.Controls.Add(this.numFrameSizeRnn);
            this.tabRnn.Controls.Add(this.lblSaveModelRnn);
            this.tabRnn.Controls.Add(this.txbSaveModelRnn);
            this.tabRnn.Controls.Add(this.btnFolderSaveModelRnn);
            this.tabRnn.Controls.Add(this.lblBatchSize);
            this.tabRnn.Controls.Add(this.numBatchSize);
            this.tabRnn.Controls.Add(this.lblLearningRate);
            this.tabRnn.Controls.Add(this.numLearningRate);
            this.tabRnn.Controls.Add(this.lblIterations);
            this.tabRnn.Controls.Add(this.numIterations);
            this.tabRnn.Controls.Add(this.lblDropout);
            this.tabRnn.Controls.Add(this.numDropout);
            this.tabRnn.Controls.Add(this.lblLstmCellSize);
            this.tabRnn.Controls.Add(this.numLstmCellSize);
            this.tabRnn.Controls.Add(this.lblLstmCells);
            this.tabRnn.Controls.Add(this.numLstmCells);
            this.tabRnn.Controls.Add(this.lblFeaturesFolder);
            this.tabRnn.Controls.Add(this.txbFeaturesFolder);
            this.tabRnn.Controls.Add(this.btnFeaturesFolder);
            this.tabRnn.Controls.Add(this.btnLearnRnn);
            this.tabRnn.Controls.Add(this.lblInputFrames);
            this.tabRnn.Controls.Add(this.numInFrames);
            this.tabRnn.Location = new System.Drawing.Point(4, 25);
            this.tabRnn.Name = "tabRnn";
            this.tabRnn.Padding = new System.Windows.Forms.Padding(3);
            this.tabRnn.Size = new System.Drawing.Size(367, 461);
            this.tabRnn.TabIndex = 1;
            this.tabRnn.Text = "RNN";
            this.tabRnn.UseVisualStyleBackColor = true;
            // 
            // lblRnnFrameSize
            // 
            this.lblRnnFrameSize.AutoSize = true;
            this.lblRnnFrameSize.Location = new System.Drawing.Point(93, 48);
            this.lblRnnFrameSize.Name = "lblRnnFrameSize";
            this.lblRnnFrameSize.Size = new System.Drawing.Size(117, 17);
            this.lblRnnFrameSize.TabIndex = 58;
            this.lblRnnFrameSize.Text = "Размер фрейма:";
            // 
            // numFrameSizeRnn
            // 
            this.numFrameSizeRnn.Location = new System.Drawing.Point(241, 46);
            this.numFrameSizeRnn.Name = "numFrameSizeRnn";
            this.numFrameSizeRnn.Size = new System.Drawing.Size(120, 22);
            this.numFrameSizeRnn.TabIndex = 59;
            this.numFrameSizeRnn.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lblSaveModelRnn
            // 
            this.lblSaveModelRnn.AutoSize = true;
            this.lblSaveModelRnn.Location = new System.Drawing.Point(29, 289);
            this.lblSaveModelRnn.Name = "lblSaveModelRnn";
            this.lblSaveModelRnn.Size = new System.Drawing.Size(215, 17);
            this.lblSaveModelRnn.TabIndex = 57;
            this.lblSaveModelRnn.Text = "Папка для сохранения модели:";
            // 
            // txbSaveModelRnn
            // 
            this.txbSaveModelRnn.Location = new System.Drawing.Point(29, 309);
            this.txbSaveModelRnn.Name = "txbSaveModelRnn";
            this.txbSaveModelRnn.Size = new System.Drawing.Size(239, 22);
            this.txbSaveModelRnn.TabIndex = 56;
            // 
            // btnFolderSaveModelRnn
            // 
            this.btnFolderSaveModelRnn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFolderSaveModelRnn.Location = new System.Drawing.Point(274, 309);
            this.btnFolderSaveModelRnn.Name = "btnFolderSaveModelRnn";
            this.btnFolderSaveModelRnn.Size = new System.Drawing.Size(63, 22);
            this.btnFolderSaveModelRnn.TabIndex = 55;
            this.btnFolderSaveModelRnn.Text = "...";
            this.btnFolderSaveModelRnn.UseVisualStyleBackColor = true;
            this.btnFolderSaveModelRnn.Click += new System.EventHandler(this.btnFolderSaveModelRnn_Click);
            // 
            // lblBatchSize
            // 
            this.lblBatchSize.AutoSize = true;
            this.lblBatchSize.Location = new System.Drawing.Point(122, 216);
            this.lblBatchSize.Name = "lblBatchSize";
            this.lblBatchSize.Size = new System.Drawing.Size(111, 17);
            this.lblBatchSize.TabIndex = 53;
            this.lblBatchSize.Text = "Размер пакета:";
            // 
            // numBatchSize
            // 
            this.numBatchSize.Location = new System.Drawing.Point(241, 214);
            this.numBatchSize.Name = "numBatchSize";
            this.numBatchSize.Size = new System.Drawing.Size(120, 22);
            this.numBatchSize.TabIndex = 54;
            this.numBatchSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblLearningRate
            // 
            this.lblLearningRate.AutoSize = true;
            this.lblLearningRate.Location = new System.Drawing.Point(93, 188);
            this.lblLearningRate.Name = "lblLearningRate";
            this.lblLearningRate.Size = new System.Drawing.Size(140, 17);
            this.lblLearningRate.TabIndex = 51;
            this.lblLearningRate.Text = "Скорость обучения:";
            // 
            // numLearningRate
            // 
            this.numLearningRate.DecimalPlaces = 5;
            this.numLearningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLearningRate.Location = new System.Drawing.Point(241, 186);
            this.numLearningRate.Name = "numLearningRate";
            this.numLearningRate.Size = new System.Drawing.Size(120, 22);
            this.numLearningRate.TabIndex = 52;
            this.numLearningRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(16, 160);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(219, 17);
            this.lblIterations.TabIndex = 49;
            this.lblIterations.Text = "Кол-во итераций для обучения:";
            // 
            // numIterations
            // 
            this.numIterations.Location = new System.Drawing.Point(241, 158);
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(120, 22);
            this.numIterations.TabIndex = 50;
            this.numIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblDropout
            // 
            this.lblDropout.AutoSize = true;
            this.lblDropout.Location = new System.Drawing.Point(172, 132);
            this.lblDropout.Name = "lblDropout";
            this.lblDropout.Size = new System.Drawing.Size(63, 17);
            this.lblDropout.TabIndex = 47;
            this.lblDropout.Text = "Dropout:";
            // 
            // numDropout
            // 
            this.numDropout.DecimalPlaces = 2;
            this.numDropout.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDropout.Location = new System.Drawing.Point(241, 130);
            this.numDropout.Name = "numDropout";
            this.numDropout.Size = new System.Drawing.Size(120, 22);
            this.numDropout.TabIndex = 48;
            this.numDropout.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // lblLstmCellSize
            // 
            this.lblLstmCellSize.AutoSize = true;
            this.lblLstmCellSize.Location = new System.Drawing.Point(81, 104);
            this.lblLstmCellSize.Name = "lblLstmCellSize";
            this.lblLstmCellSize.Size = new System.Drawing.Size(154, 17);
            this.lblLstmCellSize.TabIndex = 45;
            this.lblLstmCellSize.Text = "Размер LSTM-ячейки:";
            // 
            // numLstmCellSize
            // 
            this.numLstmCellSize.Location = new System.Drawing.Point(241, 102);
            this.numLstmCellSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLstmCellSize.Name = "numLstmCellSize";
            this.numLstmCellSize.Size = new System.Drawing.Size(120, 22);
            this.numLstmCellSize.TabIndex = 46;
            this.numLstmCellSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // lblLstmCells
            // 
            this.lblLstmCells.AutoSize = true;
            this.lblLstmCells.Location = new System.Drawing.Point(93, 76);
            this.lblLstmCells.Name = "lblLstmCells";
            this.lblLstmCells.Size = new System.Drawing.Size(142, 17);
            this.lblLstmCells.TabIndex = 43;
            this.lblLstmCells.Text = "Кол-во LSTM-ячеек:";
            // 
            // numLstmCells
            // 
            this.numLstmCells.Location = new System.Drawing.Point(241, 74);
            this.numLstmCells.Name = "numLstmCells";
            this.numLstmCells.Size = new System.Drawing.Size(120, 22);
            this.numLstmCells.TabIndex = 44;
            this.numLstmCells.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblFeaturesFolder
            // 
            this.lblFeaturesFolder.AutoSize = true;
            this.lblFeaturesFolder.Location = new System.Drawing.Point(30, 238);
            this.lblFeaturesFolder.Name = "lblFeaturesFolder";
            this.lblFeaturesFolder.Size = new System.Drawing.Size(147, 17);
            this.lblFeaturesFolder.TabIndex = 42;
            this.lblFeaturesFolder.Text = "Папка с признаками:";
            // 
            // txbFeaturesFolder
            // 
            this.txbFeaturesFolder.Location = new System.Drawing.Point(29, 258);
            this.txbFeaturesFolder.Name = "txbFeaturesFolder";
            this.txbFeaturesFolder.Size = new System.Drawing.Size(239, 22);
            this.txbFeaturesFolder.TabIndex = 41;
            // 
            // btnFeaturesFolder
            // 
            this.btnFeaturesFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFeaturesFolder.Location = new System.Drawing.Point(272, 258);
            this.btnFeaturesFolder.Name = "btnFeaturesFolder";
            this.btnFeaturesFolder.Size = new System.Drawing.Size(63, 22);
            this.btnFeaturesFolder.TabIndex = 40;
            this.btnFeaturesFolder.Text = "...";
            this.btnFeaturesFolder.UseVisualStyleBackColor = true;
            this.btnFeaturesFolder.Click += new System.EventHandler(this.btnFeaturesFolder_Click);
            // 
            // btnLearnRnn
            // 
            this.btnLearnRnn.Location = new System.Drawing.Point(29, 337);
            this.btnLearnRnn.Name = "btnLearnRnn";
            this.btnLearnRnn.Size = new System.Drawing.Size(307, 34);
            this.btnLearnRnn.TabIndex = 37;
            this.btnLearnRnn.Text = "Старт";
            this.btnLearnRnn.UseVisualStyleBackColor = true;
            this.btnLearnRnn.Click += new System.EventHandler(this.btnLearnRnn_Click);
            // 
            // lblInputFrames
            // 
            this.lblInputFrames.AutoSize = true;
            this.lblInputFrames.Location = new System.Drawing.Point(20, 20);
            this.lblInputFrames.Name = "lblInputFrames";
            this.lblInputFrames.Size = new System.Drawing.Size(215, 17);
            this.lblInputFrames.TabIndex = 38;
            this.lblInputFrames.Text = "Кол-во фреймов для обучения:";
            // 
            // numInFrames
            // 
            this.numInFrames.Location = new System.Drawing.Point(241, 18);
            this.numInFrames.Name = "numInFrames";
            this.numInFrames.Size = new System.Drawing.Size(120, 22);
            this.numInFrames.TabIndex = 39;
            this.numInFrames.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // tabCnn
            // 
            this.tabCnn.Controls.Add(this.label1);
            this.tabCnn.Controls.Add(this.textBox1);
            this.tabCnn.Controls.Add(this.button1);
            this.tabCnn.Controls.Add(this.label2);
            this.tabCnn.Controls.Add(this.numericUpDown1);
            this.tabCnn.Controls.Add(this.label3);
            this.tabCnn.Controls.Add(this.numericUpDown2);
            this.tabCnn.Controls.Add(this.label4);
            this.tabCnn.Controls.Add(this.numericUpDown3);
            this.tabCnn.Controls.Add(this.label8);
            this.tabCnn.Controls.Add(this.txbCnnFeature);
            this.tabCnn.Controls.Add(this.btnCnnFeaturePath);
            this.tabCnn.Controls.Add(this.btnCnnFit);
            this.tabCnn.Location = new System.Drawing.Point(4, 25);
            this.tabCnn.Name = "tabCnn";
            this.tabCnn.Padding = new System.Windows.Forms.Padding(3);
            this.tabCnn.Size = new System.Drawing.Size(367, 461);
            this.tabCnn.TabIndex = 2;
            this.tabCnn.Text = "CNN";
            this.tabCnn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Папка для сохранения модели:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 22);
            this.textBox1.TabIndex = 77;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(269, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 22);
            this.button1.TabIndex = 76;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Размер пакета:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(241, 122);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 75;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "Скорость обучения:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 5;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDown2.Location = new System.Drawing.Point(241, 94);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown2.TabIndex = 73;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 17);
            this.label4.TabIndex = 70;
            this.label4.Text = "Кол-во итераций для обучения:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(241, 66);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown3.TabIndex = 71;
            this.numericUpDown3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 17);
            this.label8.TabIndex = 63;
            this.label8.Text = "Папка с признаками:";
            // 
            // txbCnnFeature
            // 
            this.txbCnnFeature.Location = new System.Drawing.Point(24, 172);
            this.txbCnnFeature.Name = "txbCnnFeature";
            this.txbCnnFeature.Size = new System.Drawing.Size(239, 22);
            this.txbCnnFeature.TabIndex = 62;
            // 
            // btnCnnFeaturePath
            // 
            this.btnCnnFeaturePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCnnFeaturePath.Location = new System.Drawing.Point(267, 172);
            this.btnCnnFeaturePath.Name = "btnCnnFeaturePath";
            this.btnCnnFeaturePath.Size = new System.Drawing.Size(63, 22);
            this.btnCnnFeaturePath.TabIndex = 61;
            this.btnCnnFeaturePath.Text = "...";
            this.btnCnnFeaturePath.UseVisualStyleBackColor = true;
            this.btnCnnFeaturePath.Click += new System.EventHandler(this.btnCnnFeaturePath_Click);
            // 
            // btnCnnFit
            // 
            this.btnCnnFit.Location = new System.Drawing.Point(24, 251);
            this.btnCnnFit.Name = "btnCnnFit";
            this.btnCnnFit.Size = new System.Drawing.Size(307, 34);
            this.btnCnnFit.TabIndex = 58;
            this.btnCnnFit.Text = "Старт";
            this.btnCnnFit.UseVisualStyleBackColor = true;
            this.btnCnnFit.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupLearnAlgorithms
            // 
            this.groupLearnAlgorithms.Controls.Add(this.tabControl1);
            this.groupLearnAlgorithms.Location = new System.Drawing.Point(338, 19);
            this.groupLearnAlgorithms.Name = "groupLearnAlgorithms";
            this.groupLearnAlgorithms.Size = new System.Drawing.Size(387, 517);
            this.groupLearnAlgorithms.TabIndex = 28;
            this.groupLearnAlgorithms.TabStop = false;
            this.groupLearnAlgorithms.Text = "Обучение классификаторов";
            // 
            // LearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 636);
            this.Controls.Add(this.groupLearnAlgorithms);
            this.Controls.Add(this.groupConcatFeatures);
            this.Controls.Add(this.groupLearning);
            this.Controls.Add(this.groupLog);
            this.Name = "LearningForm";
            this.Text = "Обучение классификаторов - MWSoundED";
            this.groupLog.ResumeLayout(false);
            this.groupLearning.ResumeLayout(false);
            this.groupLearning.PerformLayout();
            this.groupConcatFeatures.ResumeLayout(false);
            this.groupConcatFeatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGmm.ResumeLayout(false);
            this.tabGmm.PerformLayout();
            this.tabRnn.ResumeLayout(false);
            this.tabRnn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeRnn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDropout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLstmCellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLstmCells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInFrames)).EndInit();
            this.tabCnn.ResumeLayout(false);
            this.tabCnn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupLearnAlgorithms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.RichTextBox rtxbLog;
        private System.Windows.Forms.GroupBox groupLearning;
        private System.Windows.Forms.ProgressBar progressBarParse;
        private System.Windows.Forms.ComboBox comboTypeFile;
        private System.Windows.Forms.Button btnGetLearningFiles;
        private System.Windows.Forms.GroupBox groupConcatFeatures;
        private System.Windows.Forms.ComboBox comboClasses;
        private System.Windows.Forms.Label lblCsvFile;
        private System.Windows.Forms.TextBox txbCsvFile;
        private System.Windows.Forms.Button btnCsvFile;
        private System.Windows.Forms.Label lblLearnFolder;
        private System.Windows.Forms.TextBox txbLearnFolder;
        private System.Windows.Forms.Button btnLearnFolder;
        private System.Windows.Forms.Label lblTypeFileParse;
        private System.Windows.Forms.Label lblClassSample;
        private System.Windows.Forms.Button btnConcatFeatures;
        private System.Windows.Forms.ProgressBar progressBarConcat;
        private System.Windows.Forms.Label lblTypeFeatures;
        private System.Windows.Forms.RadioButton rbtnCepstre;
        private System.Windows.Forms.RadioButton rbtnBands;
        private System.Windows.Forms.Button btnFeatureParameters;
        private System.Windows.Forms.CheckBox checkKMeans;
        private System.Windows.Forms.Button btnStartLearnGmm;
        private System.Windows.Forms.NumericUpDown numK;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblSaveModelPath;
        private System.Windows.Forms.TextBox txbSaveModelPath;
        private System.Windows.Forms.Button btnSaveModelPath;
        private System.Windows.Forms.Label lblSaveLearningSample;
        private System.Windows.Forms.TextBox txbSaveLearningSample;
        private System.Windows.Forms.Button btnSaveLearningSample;
        private System.Windows.Forms.Button btnSaveFeatures;
        private System.Windows.Forms.TextBox txbFeatureFilePath;
        private System.Windows.Forms.Button btnFeatureFilePath;
        private System.Windows.Forms.CheckBox checkLoadDataFromFile;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txbClass;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGmm;
        private System.Windows.Forms.TextBox txbNoiseModel;
        private System.Windows.Forms.Button btnNoiseModel;
        private System.Windows.Forms.CheckBox checkNoiseModel;
        private System.Windows.Forms.TabPage tabRnn;
        private System.Windows.Forms.TabPage tabCnn;
        private System.Windows.Forms.GroupBox groupLearnAlgorithms;
        private System.Windows.Forms.Label lblNoiseModel;
        private System.Windows.Forms.Label lblFeaturesFolder;
        private System.Windows.Forms.TextBox txbFeaturesFolder;
        private System.Windows.Forms.Button btnFeaturesFolder;
        private System.Windows.Forms.Button btnLearnRnn;
        private System.Windows.Forms.Label lblInputFrames;
        private System.Windows.Forms.NumericUpDown numInFrames;
        private System.Windows.Forms.Label lblLstmCells;
        private System.Windows.Forms.NumericUpDown numLstmCells;
        private System.Windows.Forms.Label lblDropout;
        private System.Windows.Forms.NumericUpDown numDropout;
        private System.Windows.Forms.Label lblLstmCellSize;
        private System.Windows.Forms.NumericUpDown numLstmCellSize;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Label lblBatchSize;
        private System.Windows.Forms.NumericUpDown numBatchSize;
        private System.Windows.Forms.Label lblLearningRate;
        private System.Windows.Forms.NumericUpDown numLearningRate;
        private System.Windows.Forms.Label lblSaveModelRnn;
        private System.Windows.Forms.TextBox txbSaveModelRnn;
        private System.Windows.Forms.Button btnFolderSaveModelRnn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbCnnFeature;
        private System.Windows.Forms.Button btnCnnFeaturePath;
        private System.Windows.Forms.Button btnCnnFit;
        private System.Windows.Forms.Label lblRnnFrameSize;
        private System.Windows.Forms.NumericUpDown numFrameSizeRnn;
    }
}
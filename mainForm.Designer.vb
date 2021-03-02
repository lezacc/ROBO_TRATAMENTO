<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotinaAutomáticaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenovarTokenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BasePrestadorAtualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecutarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotinaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lbl_wf_id = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.nomeEndereco = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbMicrosoftStatico = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbChromeStatico = New System.Windows.Forms.PictureBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pbMicrosoftAnimado = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbChromeAnimado = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.processarCancelamento = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.rotina = New System.Windows.Forms.Label()
        Me.timerChrome = New System.Windows.Forms.Timer(Me.components)
        Me.timerMicrosoft = New System.Windows.Forms.Timer(Me.components)
        Me.pbRotina = New System.Windows.Forms.PictureBox()
        Me.tmrPopCheck = New System.Windows.Forms.Timer(Me.components)
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.dtgItensEmSelecao = New System.Windows.Forms.DataGridView()
        Me.AtualizarPrestadoresEmSeleçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.username = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pbMicrosoftStatico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbChromeStatico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMicrosoftAnimado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbChromeAnimado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRotina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgItensEmSelecao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraçõesToolStripMenuItem, Me.ExecutarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1012, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraçõesToolStripMenuItem
        '
        Me.ConfiguraçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RotinaAutomáticaToolStripMenuItem, Me.RenovarTokenToolStripMenuItem, Me.BasePrestadorAtualizarToolStripMenuItem, Me.AtualizarPrestadoresEmSeleçãoToolStripMenuItem})
        Me.ConfiguraçõesToolStripMenuItem.Name = "ConfiguraçõesToolStripMenuItem"
        Me.ConfiguraçõesToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ConfiguraçõesToolStripMenuItem.Text = "Configurar"
        '
        'RotinaAutomáticaToolStripMenuItem
        '
        Me.RotinaAutomáticaToolStripMenuItem.Name = "RotinaAutomáticaToolStripMenuItem"
        Me.RotinaAutomáticaToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.RotinaAutomáticaToolStripMenuItem.Text = "Tempo Rotina Automática"
        '
        'RenovarTokenToolStripMenuItem
        '
        Me.RenovarTokenToolStripMenuItem.Name = "RenovarTokenToolStripMenuItem"
        Me.RenovarTokenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.RenovarTokenToolStripMenuItem.Text = "Token"
        '
        'BasePrestadorAtualizarToolStripMenuItem
        '
        Me.BasePrestadorAtualizarToolStripMenuItem.Name = "BasePrestadorAtualizarToolStripMenuItem"
        Me.BasePrestadorAtualizarToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.BasePrestadorAtualizarToolStripMenuItem.Text = "Base Prestador (Atualizar)"
        '
        'ExecutarToolStripMenuItem
        '
        Me.ExecutarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RotinaToolStripMenuItem})
        Me.ExecutarToolStripMenuItem.Name = "ExecutarToolStripMenuItem"
        Me.ExecutarToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.ExecutarToolStripMenuItem.Text = "Executar"
        '
        'RotinaToolStripMenuItem
        '
        Me.RotinaToolStripMenuItem.Name = "RotinaToolStripMenuItem"
        Me.RotinaToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.RotinaToolStripMenuItem.Text = "Rotina"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Robô-SGV"
        Me.NotifyIcon1.Visible = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 59)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(988, 664)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgItensEmSelecao)
        Me.TabPage1.Controls.Add(Me.lbl_wf_id)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.nomeEndereco)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.pbMicrosoftStatico)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.pbChromeStatico)
        Me.TabPage1.Controls.Add(Me.DataGridView2)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.pbMicrosoftAnimado)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.pbChromeAnimado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(980, 638)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Seleção de Empresa"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lbl_wf_id
        '
        Me.lbl_wf_id.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_wf_id.AutoSize = True
        Me.lbl_wf_id.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wf_id.Location = New System.Drawing.Point(923, 307)
        Me.lbl_wf_id.Name = "lbl_wf_id"
        Me.lbl_wf_id.Size = New System.Drawing.Size(50, 17)
        Me.lbl_wf_id.TabIndex = 13
        Me.lbl_wf_id.Text = "<Null>"
        Me.lbl_wf_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(837, 588)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 41)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Selecionar Prestador"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'nomeEndereco
        '
        Me.nomeEndereco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nomeEndereco.AutoSize = True
        Me.nomeEndereco.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomeEndereco.Location = New System.Drawing.Point(139, 309)
        Me.nomeEndereco.Name = "nomeEndereco"
        Me.nomeEndereco.Size = New System.Drawing.Size(50, 17)
        Me.nomeEndereco.TabIndex = 11
        Me.nomeEndereco.Text = "<Null>"
        Me.nomeEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 311)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Prestadores Próximos de:"
        '
        'pbMicrosoftStatico
        '
        Me.pbMicrosoftStatico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMicrosoftStatico.ErrorImage = Global.Robo_SGV_TStark.My.Resources.Resources.excel
        Me.pbMicrosoftStatico.Image = Global.Robo_SGV_TStark.My.Resources.Resources.microsoft_parado
        Me.pbMicrosoftStatico.Location = New System.Drawing.Point(838, 1)
        Me.pbMicrosoftStatico.Name = "pbMicrosoftStatico"
        Me.pbMicrosoftStatico.Size = New System.Drawing.Size(31, 38)
        Me.pbMicrosoftStatico.TabIndex = 10
        Me.pbMicrosoftStatico.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(873, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Importar do Excel"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(732, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Importar do SGV"
        '
        'pbChromeStatico
        '
        Me.pbChromeStatico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbChromeStatico.ErrorImage = Global.Robo_SGV_TStark.My.Resources.Resources.internet_explorer
        Me.pbChromeStatico.Image = Global.Robo_SGV_TStark.My.Resources.Resources.chrome
        Me.pbChromeStatico.Location = New System.Drawing.Point(694, 0)
        Me.pbChromeStatico.Name = "pbChromeStatico"
        Me.pbChromeStatico.Size = New System.Drawing.Size(41, 44)
        Me.pbChromeStatico.TabIndex = 7
        Me.pbChromeStatico.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(9, 333)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(968, 237)
        Me.DataGridView2.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 62)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(965, 237)
        Me.DataGridView1.TabIndex = 2
        '
        'pbMicrosoftAnimado
        '
        Me.pbMicrosoftAnimado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMicrosoftAnimado.ErrorImage = Global.Robo_SGV_TStark.My.Resources.Resources.excel
        Me.pbMicrosoftAnimado.Image = Global.Robo_SGV_TStark.My.Resources.Resources.microsoft
        Me.pbMicrosoftAnimado.Location = New System.Drawing.Point(777, -43)
        Me.pbMicrosoftAnimado.Name = "pbMicrosoftAnimado"
        Me.pbMicrosoftAnimado.Size = New System.Drawing.Size(153, 116)
        Me.pbMicrosoftAnimado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbMicrosoftAnimado.TabIndex = 6
        Me.pbMicrosoftAnimado.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Vistorias Pendentes de Seleção:"
        '
        'pbChromeAnimado
        '
        Me.pbChromeAnimado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbChromeAnimado.ErrorImage = Global.Robo_SGV_TStark.My.Resources.Resources.internet_explorer
        Me.pbChromeAnimado.Image = Global.Robo_SGV_TStark.My.Resources.Resources.chrome_gif
        Me.pbChromeAnimado.Location = New System.Drawing.Point(673, -14)
        Me.pbChromeAnimado.Name = "pbChromeAnimado"
        Me.pbChromeAnimado.Size = New System.Drawing.Size(75, 58)
        Me.pbChromeAnimado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbChromeAnimado.TabIndex = 6
        Me.pbChromeAnimado.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.processarCancelamento)
        Me.TabPage2.Controls.Add(Me.DataGridView3)
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(980, 638)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cancelamento de Vistoria"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'processarCancelamento
        '
        Me.processarCancelamento.Location = New System.Drawing.Point(898, 572)
        Me.processarCancelamento.Name = "processarCancelamento"
        Me.processarCancelamento.Size = New System.Drawing.Size(75, 38)
        Me.processarCancelamento.TabIndex = 14
        Me.processarCancelamento.Text = "Go!"
        Me.processarCancelamento.UseVisualStyleBackColor = True
        '
        'DataGridView3
        '
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(7, 63)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(966, 503)
        Me.DataGridView3.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.ErrorImage = Global.Robo_SGV_TStark.My.Resources.Resources.excel
        Me.PictureBox1.Image = Global.Robo_SGV_TStark.My.Resources.Resources.microsoft_parado
        Me.PictureBox1.Location = New System.Drawing.Point(837, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 38)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(872, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Importar do Excel"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.ErrorImage = Global.Robo_SGV_TStark.My.Resources.Resources.excel
        Me.PictureBox2.Image = Global.Robo_SGV_TStark.My.Resources.Resources.microsoft
        Me.PictureBox2.Location = New System.Drawing.Point(776, -29)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(153, 116)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Vistorias para Cancelar:"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(1241, 38)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(118, 561)
        Me.WebBrowser1.TabIndex = 2
        Me.WebBrowser1.Visible = False
        '
        'rotina
        '
        Me.rotina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rotina.AutoSize = True
        Me.rotina.Location = New System.Drawing.Point(888, 737)
        Me.rotina.Name = "rotina"
        Me.rotina.Size = New System.Drawing.Size(101, 13)
        Me.rotina.TabIndex = 4
        Me.rotina.Text = "Rodando Rotina..."
        Me.rotina.Visible = False
        '
        'timerChrome
        '
        Me.timerChrome.Interval = 10000
        '
        'timerMicrosoft
        '
        Me.timerMicrosoft.Interval = 7000
        '
        'pbRotina
        '
        Me.pbRotina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRotina.Image = Global.Robo_SGV_TStark.My.Resources.Resources.loading
        Me.pbRotina.Location = New System.Drawing.Point(946, 720)
        Me.pbRotina.Name = "pbRotina"
        Me.pbRotina.Size = New System.Drawing.Size(61, 50)
        Me.pbRotina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRotina.TabIndex = 3
        Me.pbRotina.TabStop = False
        Me.pbRotina.Visible = False
        '
        'tmrPopCheck
        '
        Me.tmrPopCheck.Interval = 10
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(12, 729)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(833, 213)
        Me.WebBrowser2.TabIndex = 15
        Me.WebBrowser2.Visible = False
        '
        'dtgItensEmSelecao
        '
        Me.dtgItensEmSelecao.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgItensEmSelecao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgItensEmSelecao.Location = New System.Drawing.Point(9, 576)
        Me.dtgItensEmSelecao.Name = "dtgItensEmSelecao"
        Me.dtgItensEmSelecao.Size = New System.Drawing.Size(292, 57)
        Me.dtgItensEmSelecao.TabIndex = 14
        Me.dtgItensEmSelecao.Visible = False
        '
        'AtualizarPrestadoresEmSeleçãoToolStripMenuItem
        '
        Me.AtualizarPrestadoresEmSeleçãoToolStripMenuItem.Name = "AtualizarPrestadoresEmSeleçãoToolStripMenuItem"
        Me.AtualizarPrestadoresEmSeleçãoToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.AtualizarPrestadoresEmSeleçãoToolStripMenuItem.Text = "Atualizar Prestadores Em Seleção"
        '
        'username
        '
        Me.username.AutoSize = True
        Me.username.Location = New System.Drawing.Point(13, 726)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(63, 13)
        Me.username.TabIndex = 16
        Me.username.Text = "[username]"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 759)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.rotina)
        Me.Controls.Add(Me.pbRotina)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "mainForm"
        Me.Text = "Robo-SGV-TStark"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pbMicrosoftStatico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbChromeStatico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMicrosoftAnimado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbChromeAnimado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRotina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgItensEmSelecao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ConfiguraçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RotinaAutomáticaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Timer1 As Timer
    Friend WithEvents RenovarTokenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents pbMicrosoftAnimado As PictureBox
    Friend WithEvents pbChromeAnimado As PictureBox
    Friend WithEvents pbRotina As PictureBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents rotina As Label
    Friend WithEvents pbChromeStatico As PictureBox
    Friend WithEvents timerChrome As Timer
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pbMicrosoftStatico As PictureBox
    Friend WithEvents timerMicrosoft As Timer
    Friend WithEvents nomeEndereco As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents processarCancelamento As Button
    Friend WithEvents ExecutarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RotinaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents tmrPopCheck As Timer
    Friend WithEvents lbl_wf_id As Label
    Friend WithEvents WebBrowser2 As WebBrowser
    Friend WithEvents BasePrestadorAtualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dtgItensEmSelecao As DataGridView
    Friend WithEvents AtualizarPrestadoresEmSeleçãoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents username As Label
End Class

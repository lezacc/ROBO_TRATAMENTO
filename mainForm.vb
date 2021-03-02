Imports System.Runtime.InteropServices
Public Class mainForm

    Dim arquivo As New CONFIG
    Dim sgv As New SGV

    'DLL IMPORTED FUNCTIONS FOR GETTING ACTIVE JS ALERT BOX AND SENDING A CLOSE MESSAGE TO IT
    <DllImport("user32.dll")>
    Private Shared Function GetLastActivePopup(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function PostMessage(
                             ByVal hWnd As IntPtr,
                             ByVal Msg As Integer,
                             ByVal wParam As IntPtr,
                             ByVal lParam As IntPtr) As Boolean
    End Function



    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        'START THE TIMER TO CHECK FOR POPUP
        ' tmrPopCheck.Start()

    End Sub
    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
    Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            username.Text = GetUserName()
        Catch ex As Exception
            username.Text = "Desconhecido"
        End Try

        arquivo.criarArquivoConfiguracao()
        ajustarIntervaloTimer(arquivo.valorSalvoAtual("intervaloExecucaoAutomatica"), Timer1)

    End Sub

    Private Sub mainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            NotifyIcon1.Visible = True
            NotifyIcon1.ShowBalloonTip(1, "Robô-SGV-TStark", "Sistema rodando...", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False

    End Sub

    Private Sub RenovarTokenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenovarTokenToolStripMenuItem.Click

        mostrarTokenSalvo()

    End Sub

    Public Sub mostrarTokenSalvo()

        Dim tokenAtual As String = arquivo.valorSalvoAtual("token")

        Dim tokenNovo As String = InputBox("Insira um novo token de acesso...", "Token", tokenAtual)

        If forDiferente(tokenNovo, tokenAtual) Then

            arquivo.alterarValorSalvo("token", tokenNovo)

            Exit Sub

        End If

    End Sub

    Public Function forDiferente(valorNovo As String, valorAntigo As String) As Boolean
        If valorNovo <> valorAntigo And valorNovo <> "" Then
            Return True
        End If
        Return False
    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MsgBox("teste")
    End Sub

    Private Sub ConfiguraçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraçõesToolStripMenuItem.Click

    End Sub
    Public Sub mostrarTempoAtual()
        Dim segundoAtual As Integer = arquivo.valorSalvoAtual("intervaloExecucaoAutomatica") / 1000

        Dim segundoNovo As Integer

        Try
            segundoNovo = InputBox("Tempo de cada execução em segundos." & vbNewLine & "Digite 0 para desativar a rotina automática.", "Segundos", segundoAtual)
        Catch ex As Exception

        End Try

        If IsNumeric(segundoNovo) Then

            If segundoNovo > 0 And segundoNovo < 60 Then segundoNovo = 60

            If forDiferente(segundoNovo, segundoAtual) Then
                arquivo.alterarValorSalvo("intervaloExecucaoAutomatica", segundoNovo * 1000)
                ajustarIntervaloTimer(segundoNovo * 1000, Timer1)
            End If

        End If

    End Sub

    Public Sub ajustarIntervaloTimer(tempoDoTick As Integer, timer As Timer)
        If tempoDoTick <= 0 Then
            timer.Stop()
        Else
            timer.Interval = tempoDoTick
            timer.Start()
        End If

    End Sub

    Private Sub RotinaAutomáticaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RotinaAutomáticaToolStripMenuItem.Click
        mostrarTempoAtual()
        Dim v As New CONFIG

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)



    End Sub

    Public Sub animarChrome()

        timerChrome.Start()
        pbChromeAnimado.Image = My.Resources.chrome_gif
        pbChromeStatico.Visible = False
    End Sub
    Public Sub animarMicrosoft()

        timerMicrosoft.Start()
        pbMicrosoftAnimado.Image = My.Resources.microsoft
        pbMicrosoftStatico.Visible = False
    End Sub



    Private Sub timerChrome_Tick(sender As Object, e As EventArgs) Handles timerChrome.Tick
        timerChrome.Stop()
        pbChromeStatico.Visible = True
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

        Dim tabela As DataTable = importarDadosSGV(sgv.ATIVIDADE.SelecaoEmpresa)
        tabela.Columns.Remove("&nbsp;")
        tabela.Columns.Remove("Data da ultima execução")
        tabela.Columns.Remove("Tipo de inspeção")
        tabela.Columns.Remove("Situação")
        tabela.Columns.Remove("Data de agendamento")
        tabela.Columns.Remove("Prestador")

        DataGridView1.DataSource = tabela

    End Sub

    Public Function importarDadosSGV(atividade As String) As DataTable
        'animarChrome()
        sgv.WEB = WebBrowser1
        sgv.TOKEN = arquivo.valorSalvoAtual("token")
        sgv.logarSGV()
        sgv.selecionarAtividade(atividade)
        Dim tabela As DataTable = sgv.tabelaDTGInstanciasParaDataTable()


        Return tabela
    End Function

    Private Sub timerMicrosoft_Tick(sender As Object, e As EventArgs) Handles timerMicrosoft.Tick
        timerMicrosoft.Stop()
        pbMicrosoftStatico.Image = My.Resources.microsoft_parado_1
        pbMicrosoftStatico.Visible = True
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        animarMicrosoft()

        Dim file As New OpenFileDialog

        file.ShowDialog()

        If file.FileName <> "" Then


            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & file.FileName & "';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Planilha1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            DataGridView1.DataSource = DtSet.Tables(0)
            MyConnection.Close()
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)



    End Sub

    Public Sub buscarPrestadoresProximos(nomeEndereco As String)

        Dim buscaBING As New BING
        Dim PontoGEO As BING.PontoGPS
        Dim DB As New BancoDeDados
        Dim pesquisaBaseInterna As BING.PontoGPS = DB.pontoGEOBaseInterna(nomeEndereco)

        If pesquisaBaseInterna.latitude <> "" Then
            PontoGEO = pesquisaBaseInterna
        Else
            PontoGEO = buscaBING.gpsPorEndereco(nomeEndereco)
            DB.inserirEnderecoNaBase(nomeEndereco, PontoGEO.latitude, PontoGEO.longitude)
        End If

        DataGridView2.DataSource = DB.prestadoresProximos(PontoGEO)
        DataGridView2.DataMember = "id_prestador"

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            Dim nomeColuna As String = DataGridView1.Columns(e.ColumnIndex).Name

            If nomeColuna = "Município" Then
                Dim wf_id As String = DataGridView1.Item(0, e.RowIndex).Value
                Dim municipio As String = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                Dim uf As String = DataGridView1.Item(e.ColumnIndex + 1, e.RowIndex).Value
                Dim enderecoVistoria As String = municipio.Trim & ", " & uf.Trim & " , Brazil"

                lbl_wf_id.Text = wf_id
                buscarPrestadoresProximos(enderecoVistoria)
                adicionarDistanciaRealNaTabela(enderecoVistoria)
                nomeEndereco.Text = Trim(enderecoVistoria)
                pintarPrestadoresAnteriores(wf_id)

            End If

        End If
    End Sub

    Public Sub adicionarDistanciaRealNaTabela(enderecoVistoria As String)

        Dim buscaBing As New BING
        Dim bancoDadosInterno As New BancoDeDados

        Dim municipioPrestador As String = ""
        Dim ufPrestador As String = ""
        Dim enderecoPrestador As String = ""


        For Each c As DataGridViewColumn In DataGridView2.Columns
            If c.Name = "distancia_real" Then

                For linha As Integer = 0 To 5
                    municipioPrestador = DataGridView2.Item(3, linha).Value
                    ufPrestador = DataGridView2.Item(4, linha).Value
                    enderecoPrestador = municipioPrestador.Trim & ", " & ufPrestador.Trim & ", Brazil"
                    Dim kmBaseInterna As String = bancoDadosInterno.kmBaseInterna(enderecoPrestador, enderecoVistoria)
                    Dim kmFinal As String = ""
                    If kmBaseInterna = "" Then
                        kmFinal = buscaBing.calcularKM(enderecoPrestador, enderecoVistoria)
                        DataGridView2.Item(c.Index, linha).Value = kmFinal
                        bancoDadosInterno.inserirKmNaBase(enderecoPrestador, enderecoVistoria, kmFinal)
                    Else
                        kmFinal = kmBaseInterna
                        DataGridView2.Item(c.Index, linha).Value = kmFinal
                    End If

                Next


            End If

        Next


    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim file As New OpenFileDialog

        file.ShowDialog()

        If file.FileName <> "" Then

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & file.FileName & "';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Planilha1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            DataGridView3.DataSource = DtSet.Tables(0)
            MyConnection.Close()
        End If

    End Sub

    Private Sub processarCancelamento_Click(sender As Object, e As EventArgs) Handles processarCancelamento.Click

        Dim wfID, nomePrestador, km, obs, inspecao_ID As String
        Dim sgv As New SGV With {
            .WEB = WebBrowser2
        }

        Dim bancoDados As New BancoDeDados

        For linha As Integer = 0 To DataGridView3.Rows.Count - 2

            wfID = DataGridView3.Item(0, linha).Value
            obs = DataGridView3.Item(1, linha).Value
            inspecao_ID = bancoDados.inspecaoID(wfID)

            If inspecao_ID = "" Then
                inspecao_ID = inspecaoIDSGV(wfID)
            End If

            If inspecao_ID = "" Then
                MsgBox("Não foi possivel recuperar o numero de inspeção MAPFRE. WF: " & wfID, vbExclamation, "Atenção")
                DataGridView3.Rows(linha).DefaultCellStyle.BackColor = Color.Red
                DataGridView3.Rows(linha).DefaultCellStyle.ForeColor = Color.White
            End If

            Dim TOKEN As String = arquivo.valorSalvoAtual("token")


        Next


    End Sub

    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

    End Sub

    Private Sub WebBrowser2_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser2.Navigated
        '  InjectAlertBlocker()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)

    End Sub
    Public Function regraCancelaPrevaloracao(ramo As String, prestador As String) As Boolean
        regraCancelaPrevaloracao = False

        If prestador = "MAPFRE SEGUROS GERAIS S/A " Then
            If ramo = "1485" Then regraCancelaPrevaloracao = True
            If ramo = "1685" Then regraCancelaPrevaloracao = True
            If ramo = "1804" Then regraCancelaPrevaloracao = True
            If ramo = "1884" Then regraCancelaPrevaloracao = True
            If ramo = "1885" Then regraCancelaPrevaloracao = True
            If ramo = "7185" Then regraCancelaPrevaloracao = True
            If ramo = "3002" Then regraCancelaPrevaloracao = True
            If ramo = "6201" Then regraCancelaPrevaloracao = True

        End If

    End Function

    Public Function regraValidarPrevaloracao(ramo As String, prestador As String) As Boolean
        regraValidarPrevaloracao = False

        If prestador <> "MAPFRE SEGUROS GERAIS S/A " Then
            If ramo = "1485" Then regraValidarPrevaloracao = True
            If ramo = "1685" Then regraValidarPrevaloracao = True
            If ramo = "1804" Then regraValidarPrevaloracao = True
            If ramo = "1884" Then regraValidarPrevaloracao = True
            If ramo = "1885" Then regraValidarPrevaloracao = True
            If ramo = "7185" Then regraValidarPrevaloracao = True
            If ramo = "3002" Then regraValidarPrevaloracao = True
            If ramo = "6201" Then regraValidarPrevaloracao = True

        End If

    End Function
    Public Function regraValidarPrevalizacao(ramo As String, prestador As String) As Boolean
        regraValidarPrevalizacao = False


        If prestador <> "Prestador" Then
            If ramo = "1485" Then regraValidarPrevalizacao = True
            If ramo = "1685" Then regraValidarPrevalizacao = True
            If ramo = "1804" Then regraValidarPrevalizacao = True
            If ramo = "1884" Then regraValidarPrevalizacao = True
            If ramo = "1885" Then regraValidarPrevalizacao = True
            If ramo = "7185" Then regraValidarPrevalizacao = True
            If ramo = "3002" Then regraValidarPrevalizacao = True
            If ramo = "6201" Then regraValidarPrevalizacao = True

        End If


    End Function


    Public Sub executaValicaoECancelamentoPrevaloracao()
        Dim bancoDados As New BancoDeDados
        Dim arquivo As New CONFIG
        sgv.WEB = WebBrowser1

        Dim dtgv As New DataGridView

        Dim tabela As DataTable = importarDadosSGV(sgv.ATIVIDADE.ValidacaoPreValorizacao)
        tabela.Columns.Remove("&nbsp;")
        tabela.Columns.Remove("Data da ultima execução")
        tabela.Columns.Remove("Tipo de inspeção")
        tabela.Columns.Remove("Situação")
        tabela.Columns.Remove("Data de agendamento")
        tabela.Columns.Remove("Data de inclusão")
        tabela.Columns.Remove("Proponente")
        tabela.Columns.Remove("CNPJ")
        tabela.Columns.Remove("Endereço")
        tabela.Columns.Remove("Município")
        tabela.Columns.Remove("UF")

        DataGridView3.DataSource = tabela

        Dim prestador As String = ""
        Dim subRamo As String = ""
        Dim wfID As String = ""
        Dim inspecaoID As String = ""
        Dim token As String = arquivo.valorSalvoAtual("token")

        For linha As Integer = 0 To DataGridView3.Rows.Count - 2
            prestador = DataGridView3.Item(2, linha).Value
            subRamo = DataGridView3.Item(1, linha).Value
            wfID = DataGridView3.Item(0, linha).Value
            inspecaoID = bancoDados.inspecaoID(wfID)

            If inspecaoID = "" Then
                inspecaoID = inspecaoIDSGV(wfID)
            End If

            If regraValidarPrevaloracao(subRamo, prestador) Then

                sgv.validacaoDaPrevalorizacao("32189", wfID, inspecaoID, token)

            ElseIf regraCancelaPrevaloracao(subRamo, prestador) Then

                sgv.cancelamentoDaPrevalorizacao("32189", wfID, inspecaoID, token)
            End If

        Next

    End Sub
    Public Sub executaValidacaoDaValorizacao()
        Dim bancoDados As New BancoDeDados
        Dim arquivo As New CONFIG
        sgv.WEB = WebBrowser1

        Dim dtgv As New DataGridView

        Dim tabela As DataTable = importarDadosSGV(sgv.ATIVIDADE.ValidacaoDaValorizacao)
        tabela.Columns.Remove("&nbsp;")
        tabela.Columns.Remove("Data da ultima execução")
        tabela.Columns.Remove("Tipo de inspeção")
        tabela.Columns.Remove("Situação")
        tabela.Columns.Remove("Data de agendamento")
        tabela.Columns.Remove("Data de inclusão")
        tabela.Columns.Remove("Proponente")
        tabela.Columns.Remove("CNPJ")
        tabela.Columns.Remove("Endereço")
        tabela.Columns.Remove("Município")
        tabela.Columns.Remove("UF")

        DataGridView3.DataSource = tabela

        Dim prestador As String = ""
        Dim subRamo As String = ""
        Dim wfID As String = ""
        Dim inspecaoID As String = ""
        Dim token As String = arquivo.valorSalvoAtual("token")

        For linha As Integer = 0 To DataGridView3.Rows.Count - 2
            prestador = DataGridView3.Item(2, linha).Value
            subRamo = DataGridView3.Item(1, linha).Value
            wfID = DataGridView3.Item(0, linha).Value
            inspecaoID = bancoDados.inspecaoID(wfID)

            If inspecaoID = "" Then
                inspecaoID = inspecaoIDSGV(wfID)
            End If

            If regraValidarPrevalizacao(subRamo, prestador) Then

                sgv.liberacaoPreValidacao("32189", wfID, inspecaoID, token)

            End If

        Next


    End Sub


    Public Sub rodarRotinaAutomatica()




        ' sgv.validacaoDaPrevalorizacao("",)

    End Sub

    Private Sub RotinaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RotinaToolStripMenuItem.Click
        rotina.Visible = True
        rotina.Text = "Running..."
        pbRotina.Visible = True
        executaValicaoECancelamentoPrevaloracao()
        executaValidacaoDaValorizacao()
        MsgBox("Done!", MsgBoxStyle.Information, "Sexta-Feira")
        rotina.Visible = False
        rotina.Text = ""
        pbRotina.Visible = False


    End Sub

    Public Sub atualizarListaSelecao()


        Dim tabela As DataTable = importarDadosSGV(sgv.ATIVIDADE.SelecaoEmpresa)
        tabela.Columns.Remove("&nbsp;")
        tabela.Columns.Remove("Data da ultima execução")
        tabela.Columns.Remove("Tipo de inspeção")
        tabela.Columns.Remove("Situação")
        tabela.Columns.Remove("Data de agendamento")
        tabela.Columns.Remove("Prestador")

        dtgItensEmSelecao.DataSource = tabela


    End Sub

    Public Function wfIDEmSelecao(wf_id As String, dtv As DataGridView) As Boolean
        Dim retorno As Boolean
        retorno = False
        For i As Integer = 0 To dtv.Rows.Count - 1
            If dtv.Item(0, i).Value = wf_id Then
                retorno = True
            End If

        Next
        Return retorno

    End Function
    Public Function inspecaoIDSGV(wf_id As String) As String
        sgv.WEB = WebBrowser1
        sgv.TOKEN = arquivo.valorSalvoAtual("token")
        sgv.logarSGV()
        inspecaoIDSGV = sgv.inspecaoIdViaSGV(wf_id)

    End Function

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click

        If dtgItensEmSelecao.Rows.Count = 0 Then
            atualizarListaSelecao()
        End If


        If wfIDEmSelecao(lbl_wf_id.Text, dtgItensEmSelecao) Then

            Dim bancoDados As New BancoDeDados
            ' MsgBox(DataGridView2.SelectedRows(0).Index)
            ' MsgBox(DataGridView2.Item(0, DataGridView2.SelectedRows(0).Index).Value)

            Dim nomePrestador As String = DataGridView2.Item(0, DataGridView2.SelectedRows(0).Index).Value
            Dim nomePrestadorDescricao As String = DataGridView2.Item(1, DataGridView2.SelectedRows(0).Index).Value
            Dim km As Double = Replace(DataGridView2.Item(8, DataGridView2.SelectedRows(0).Index).Value, ".", ",")
            Dim obs As String = "Robô_" & nomePrestadorDescricao
            Dim wfID As String = lbl_wf_id.Text
            Dim inspecaoID As String = bancoDados.inspecaoID(wfID)
            Dim TOKEN As String = arquivo.valorSalvoAtual("token")

            If inspecaoID = "" Then
                inspecaoID = inspecaoIDSGV(wfID)
            End If

            ' MsgBox(inspecaoID)
            Try
                sgv.WEB = WebBrowser2
                sgv.selecionarPrestadorF(nomePrestador, km, obs, wfID, inspecaoID, TOKEN)
                bancoDados.inserirDemandaBase(wfID, nomePrestador, GetUserName())
                pintarCelula(wfID, DataGridView1, Color.DarkGreen)

            Catch ex As Exception
                MsgBox("Erro. Selecione a linha inteira do prestador.", vbExclamation, "Atenção")
                'pintarCelula(wfID, DataGridView1, Color.Purple)
            End Try


        Else
            MsgBox("WfID não está com status de seleção de empresa.", vbExclamation, "Atenção")
            pintarCelula(lbl_wf_id.Text, DataGridView1, Color.Red)
        End If



    End Sub

    Public Sub pintarCelula(wf_id As String, dtv As DataGridView, cor As Color)
        For i As Integer = 0 To dtv.Rows.Count - 2
            If dtv.Item(0, i).Value = wf_id Then
                dtv.Rows(i).DefaultCellStyle.BackColor = cor
                dtv.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End If
        Next

    End Sub


    Private Sub tmrPopCheck_Tick(sender As Object, e As EventArgs) Handles tmrPopCheck.Tick
        'tmrPopCheck.Stop()

        'GET HANDLE OF ACTIVE IE POPUP (AKA JS ALERT)
        ' Dim PopupHandle As IntPtr = GetLastActivePopup(Me.Handle)

        'IF THE POPUP HANDLE IS NOT 0, AND IT IS NOT THE WB HANDLE
        'THEN SEND A WM_CLOSE MESSAGE (&H10) TO THE POPUP
        'SEE http://msdn2.microsoft.com/en-us/library/ms633507.aspx
        'FOR MORE INFO ON RETURN VALUE OF GetLastActivePopup
        ' If (PopupHandle <> IntPtr.Zero) AndAlso (PopupHandle <> WebBrowser1.Handle) Then
        'PostMessage(PopupHandle, &H10, New IntPtr(1), IntPtr.Zero)

        'End If


    End Sub

    Private Sub BasePrestadorAtualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BasePrestadorAtualizarToolStripMenuItem.Click

        Dim bancoDados As New BancoDeDados
        bancoDados.apagarBasePrestador()
        bancoDados.atualizarBasePrestador()

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub AtualizarPrestadoresEmSeleçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtualizarPrestadoresEmSeleçãoToolStripMenuItem.Click

        If dtgItensEmSelecao.Rows.Count > 0 Then
            dtgItensEmSelecao.DataSource = Nothing
            dtgItensEmSelecao.Rows.Clear()
        End If

        atualizarListaSelecao()
        MsgBox("Prestadores atualizados com sucesso", vbInformation, "Sucesso")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)



    End Sub

    Public Sub pintarPrestadoresAnteriores(wf_id As String)
        Dim bancoDados As New BancoDeDados
        Dim ds As New DataSet
        ds = bancoDados.prestadoresAnteriores(wf_id)
        Dim id_prestador As String = "null"
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            'Dim someVar As Integer = Integer.Parse(ds.Tables(0).Rows(i)(0).ToString())
            id_prestador = ds.Tables(0).Rows(i)(0).ToString()
            Try
                pintarCelula(id_prestador, DataGridView2, Color.LightGray)
            Catch ex As Exception

            End Try


        Next

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class
